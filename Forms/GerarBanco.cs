using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using DBUtils.Utils;
using DBUtils.Models;
using DBUtils.Forms;

namespace DBUtils
{
    public partial class GerarBanco : Form
    {
        private SqlConnection _Conn;
        private OpenFileDialog _OpenFileDialog = new OpenFileDialog();

        public SqlConnection Connection => _Conn;

        LogSistema logSistema = new LogSistema();

        public GerarBanco()
        {
            if (_Conn == null || _Conn.State != System.Data.ConnectionState.Open)
            {
                var conexaoForm = new Conexao();
                if (conexaoForm.ShowDialog() == DialogResult.OK)
                {
                    _Conn = ConnectionManager.GetConnection();
                }
                else
                {
                    this.Hide();
                    return;
                }
            }
            InitializeComponent();
        }

        private void btnSelecionarDestino_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",  // Filtro para arquivos JSON
                Title = "Selecione onde salvar o arquivo JSON",  // T�tulo do di�logo
                FileName = "database.json"  // Nome padr�o do arquivo
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                _OpenFileDialog = openFileDialog;
                txtDestino.Text = filePath;
            }
        }

        private void btnGeraBanco_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeBanco.Text))
            {
                MessageBox.Show("Informe o nome do banco.",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_OpenFileDialog == null)
            {
                MessageBox.Show("Selecione o arquivo de estrutura.",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string jsonContent = File.ReadAllText(_OpenFileDialog.FileName);
            DatabaseStructure databaseStructure = JsonConvert.DeserializeObject<DatabaseStructure>(jsonContent) ?? new DatabaseStructure();

            if(databaseStructure != null)
                ApplyDatabaseStructureFromJson(databaseStructure, txtNomeBanco.Text);

            MessageBox.Show("Banco de dados criado com sucesso!",
                "Alerta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void ApplyDatabaseStructureFromJson(DatabaseStructure databaseStructure, string databaseName)
        {
            // Abre a conex�o com o banco de dados
            if (!ConnectionManager.CheckConnection(_Conn))
                _Conn.Open();

            using (_Conn)
            {
                // 1. Cria��o do banco de dados
                var createDbQuery = $"IF DB_ID(N'{databaseName}') IS NULL CREATE DATABASE [{databaseName}]";
                using (SqlCommand command = new SqlCommand(createDbQuery, _Conn))
                {
                    command.ExecuteNonQuery();
                }
                _Conn.ChangeDatabase(databaseName);

                // 2. Cria��o de Schemas
                if(databaseStructure.Database.Schemas != null)
                {
                    foreach (var schema in databaseStructure.Database.Schemas)
                    {
                        var schemaName = schema.SchemaName.ToString();
                        var createSchemaQuery = $"IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '{schemaName}') EXEC('CREATE SCHEMA [{schemaName}]')";

                        ExecuteCommand(createSchemaQuery);

                        // 3. Cria��o de Tabelas e Colunas dentro do schema
                        var tables = schema.Tables;
                        foreach (var table in tables)
                        {
                            var tableName = table.Name.ToString();
                            var createTableQuery = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}' AND TABLE_SCHEMA = '{schemaName}') BEGIN ";
                            createTableQuery += $"CREATE TABLE [{schemaName}].[{tableName}] (";

                            var columns = table.Columns;
                            foreach (var column in columns)
                            {
                                var columnName = column.Column_name.ToString();
                                var columnType = column.Type.ToString();
                                var isNullable = column.Nullable ? "NULL" : "NOT NULL";
                                var isIdentity = column.IsIdentity ? "IDENTITY(1,1)" : "";
                                var maxLength = !string.IsNullOrEmpty(column.Length) && column.Length != "MAX" ? $"({column.Length})" : column.Length == "MAX" ? "(MAX)" : "";
                                var precisionScale = (column.Precision != null && column.Scale != null) ? $"({column.Precision},{column.Scale})" : "";
                                var collation = !string.IsNullOrEmpty(column.Collation) && column.Collation != "N/A" ? $"COLLATE {column.Collation}" : "";

                                // Definindo o tipo de dado com comprimento ou precis�o/escala, se aplic�vel
                                var columnDefinition = $"{columnType}{(columnType == "decimal" || columnType == "numeric" ? precisionScale : maxLength)}";

                                // Adicionando a coluna ao comando de cria��o de tabela
                                createTableQuery += $"[{columnName}] {columnDefinition} {isIdentity} {collation} {isNullable}, ";
                            }

                            // Remove a �ltima v�rgula e espa�o, fecha o comando de cria��o de tabela e executa
                            createTableQuery = createTableQuery.TrimEnd(',', ' ') + "); END";

                            try
                            {
                                ExecuteCommand(createTableQuery);
                            }
                            catch (Exception ex)
                            {
                                RegisterError(ex, createTableQuery);
                                continue; // Ignora o erro e passa para a pr�xima tabela
                            }

                            // 3.1 Cria��o de �ndices (se houver)
                            var indexes = table.Indexes;
                            if (indexes != null)
                            {
                                foreach (var index in indexes)
                                {
                                    var indexName = index.GetType().GetProperty("indexName")?.GetValue(index)?.ToString();
                                    var indexColumns = index.GetType().GetProperty("columns")?.GetValue(index) as List<string>;
                                    var unique = index.GetType().GetProperty("unique")?.GetValue(index)?.ToString() == "True" ? "UNIQUE" : "";

                                    // Verifica se o �ndice j� existe
                                    var indexQuery = $@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = '{indexName}' AND object_id = OBJECT_ID('{schemaName}.{tableName}'))
                                                        BEGIN
                                                            CREATE {unique} INDEX [{indexName}] ON [{schemaName}].[{tableName}] ({string.Join(", ", indexColumns.Select(c => $"[{c}]"))})
                                                        END";

                                    try
                                    {
                                        ExecuteCommand(indexQuery);
                                    }
                                    catch (Exception ex)
                                    {
                                        RegisterError(ex, indexQuery);
                                        continue; //Ignora o erro e passa para o pr�ximo index
                                    }
                                }
                            }
                        }
                    }
                }

                // 4. Cria��o de Stored Procedures
                if(databaseStructure.Database.Procedures != null)
                {
                    foreach (var proc in databaseStructure.Database.Procedures)
                    {
                        var procName = proc.Name;
                        var procDefinition = proc.Definition;

                        try
                        {
                            ExecuteCommand(procDefinition);
                        }
                        catch (Exception ex)
                        {
                            RegisterError(ex, procDefinition);
                            continue; // Ignora o erro e passa para a pr�xima stored procedure
                        }
                    }
                }

                // 5. Cria��o de Fun��es
                if(databaseStructure.Database.Functions != null)
                {
                    foreach (var func in databaseStructure.Database.Functions)
                    {
                        var funcName = func.Name;
                        var funcDefinition = func.Definition;

                        try
                        {
                            ExecuteCommand(funcDefinition);
                        }
                        catch (Exception ex)
                        {
                            RegisterError(ex, funcDefinition);
                            continue; // Ignora o erro e passa para a pr�xima fun��o
                        }
                    }
                }

                // 6. Cria��o de Triggers (opcional)
                if(databaseStructure.Database.Triggers != null)
                {
                    foreach (var trigger in databaseStructure.Database.Triggers)
                    {
                        var triggerName = trigger.Name;
                        var triggerDefinition = trigger.Definition;

                        try
                        {
                            ExecuteCommand(triggerDefinition);
                        }
                        catch (Exception ex)
                        {
                            RegisterError(ex, triggerDefinition);
                            continue; // Ignora o erro e passa para o pr�ximo trigger
                        }
                    }
                }

                // 7. Cria��o de
                if(databaseStructure.Database.Views != null)
                {
                    foreach (var view in databaseStructure.Database.Views)
                    {
                        var viewName = view.Name;
                        var viewDefinition = view.Definition;

                        try
                        {
                            ExecuteCommand(viewDefinition);
                        }
                        catch (Exception ex)
                        {
                            RegisterError(ex, viewDefinition);
                            continue; // Ignora o erro e passa para a pr�xima view
                        }
                    }
                }
            }
        }

        private void ExecuteCommand(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, _Conn))
            {
                command.ExecuteNonQuery();
            }
        }

        private void RegisterError(Exception ex, string sql)
        {
            logSistema.GenerateLog(string.Empty);
            logSistema.GenerateLog("ERRO - " + ex);
            logSistema.GenerateLog("COMANDO - " + sql);
        }
    }
}
