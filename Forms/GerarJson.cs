using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using DBUtils.Utils;
using DBUtils.Models;
using DBUtils.Forms;

namespace DBUtils
{
    public partial class GerarJson : Form
    {
        private SqlConnection _Conn;
        public SqlConnection Connection => _Conn;
        private SaveFileDialog _SaveFileDialog = new SaveFileDialog();

        public GerarJson()
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
            GetDatabases();
        }

        private List<string> GetDatabases()
        {
            var databases = new List<string>();
            string getDatabasesQuery = "SELECT name FROM sys.databases WHERE state_desc = 'ONLINE'";

            if (!ConnectionManager.CheckConnection(_Conn))
                _Conn.Open();

            using (SqlCommand command = new SqlCommand(getDatabasesQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString() != "msdb" &&
                        reader["name"].ToString() != "tempdb" &&
                        reader["name"].ToString() != "model" &&
                        reader["name"].ToString() != "master")
                    {
                        databases.Add(reader["name"].ToString() ?? "");
                    }
                }
            }
            // Listar os bancos de dados disponíveis
            cbDataBases.Items.Clear(); // Limpa o ComboBox antes de adicionar novos itens

            foreach (var db in databases)
            {
                cbDataBases.Items.Add(db); // Adiciona os bancos ao ComboBox
            }

            return databases;
        }

        private void btnGeraJson_Click(object sender, EventArgs e)
        {
            string? bancoSelecionado = cbDataBases.SelectedItem != null ? cbDataBases.SelectedItem.ToString() : "";

            if (string.IsNullOrWhiteSpace(bancoSelecionado))
            {
                MessageBox.Show("Selecione o banco de dados!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_SaveFileDialog == null)
            {
                MessageBox.Show("Selecione o caminho de destino!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var databaseStructure = GetDatabaseStructure(bancoSelecionado);
            string json = JsonConvert.SerializeObject(new { database = databaseStructure }, Formatting.Indented);
            File.WriteAllText(_SaveFileDialog.FileName, json);

            MessageBox.Show("Arquivo database.json gerado com sucesso!",
                "Alerta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            this.Close();
        }

        private Dictionary<string, object> GetDatabaseStructure(string database)
        {
            var databaseStructure = new Dictionary<string, object>();

            if (!ConnectionManager.CheckConnection(_Conn))
                _Conn.Open();

            using (_Conn)
            {
                // Selecionar banco de dados
                ExecuteNonQuery($"USE {database}");

                // Nome do banco de dados
                databaseStructure["databaseName"] = ExecuteScalar("SELECT DB_NAME()")?.ToString() ?? "";

                // Schemas e tabelas associadas
                var schemas = new List<object>();
                string getSchemasQuery = "SELECT s.name AS SchemaName FROM sys.schemas s";
                using (SqlCommand command = new SqlCommand(getSchemasQuery, _Conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string schemaName = reader["SchemaName"].ToString() ?? "";
                        var schema = new Dictionary<string, object>
                        {
                            ["schemaName"] = schemaName,
                            ["tables"] = GetTablesBySchema(schemaName)
                        };
                        schemas.Add(schema);
                    }
                }
                databaseStructure["schemas"] = schemas;

                databaseStructure["indices"] = GetIndices();

                // Stored Procedures, Functions, Constraints, Triggers, Índices e Views
                //databaseStructure["procedures"] = GetProcedures();
                //databaseStructure["functions"] = GetFunctions();
                //databaseStructure["constraints"] = GetConstraints();
                //databaseStructure["triggers"] = GetTriggers();
                //databaseStructure["views"] = GetViews();
            }

            return databaseStructure;
        }

        private List<object> GetTablesBySchema(string schemaName)
        {
            var tables = new List<object>();
            string getTablesQuery = @"
                SELECT TABLE_NAME 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = @SchemaName";
            using (SqlCommand command = new SqlCommand(getTablesQuery, _Conn))
            {
                command.Parameters.AddWithValue("@SchemaName", schemaName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tableName = reader["TABLE_NAME"].ToString() ?? "";
                        var table = new Dictionary<string, object>
                        {
                            ["name"] = tableName,
                            ["columns"] = GetColumnsByTable(schemaName, tableName)
                        };
                        tables.Add(table);
                    }
                }
            }
            return tables;
        }

        private List<object> GetColumnsByTable(string schemaName, string tableName)
        {
            var columns = new List<object>();
            string getColumnsQuery = @"
                SELECT COLUMN_NAME, 
                       DATA_TYPE,
                       CASE 
                           WHEN COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 1 THEN 'YES'
                           ELSE 'NO'
                       END AS COMPUTED,
                       CASE 
                           WHEN DATA_TYPE = 'text' THEN ''
                           WHEN DATA_TYPE = 'xml' THEN NULL 
                           WHEN CHARACTER_MAXIMUM_LENGTH = -1 THEN 'MAX' 
                           ELSE CAST(CHARACTER_MAXIMUM_LENGTH AS VARCHAR) 
                       END AS CHARACTER_MAXIMUM_LENGTH, 
                       NUMERIC_PRECISION, 
                       NUMERIC_SCALE,
                       IS_NULLABLE,
                       CASE 
                           WHEN COLLATION_NAME IS NULL THEN 'N/A'
                           WHEN DATA_TYPE IN ('varchar', 'nvarchar') THEN 'NO'
                           WHEN DATA_TYPE IN ('char', 'nchar', 'binary') THEN 'YES'
                           ELSE 'NO'
                       END AS TRIMTRAILINGBLANKS,
                       CASE 
                           WHEN COLLATION_NAME IS NULL THEN 'N/A'
                           WHEN DATA_TYPE IN ('char', 'nchar', 'binary', 'varchar') AND IS_NULLABLE = 'YES' THEN 'YES'
                           ELSE 'NO'
                       END AS FIXEDLENNULLINSOURCE,
                       COLLATION_NAME AS COLLATION,
                       COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS ISIDENTITY
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_SCHEMA = @SchemaName AND TABLE_NAME = @TableName";

            using (SqlCommand command = new SqlCommand(getColumnsQuery, _Conn))
            {
                command.Parameters.AddWithValue("@SchemaName", schemaName);
                command.Parameters.AddWithValue("@TableName", tableName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(new Column
                        {
                            Column_name = reader["COLUMN_NAME"].ToString() ?? "",
                            Type = reader["DATA_TYPE"].ToString() ?? "",
                            Computed = reader["COMPUTED"].ToString() == "YES",
                            Length = reader["CHARACTER_MAXIMUM_LENGTH"].ToString(),
                            Precision = reader["NUMERIC_PRECISION"] != DBNull.Value ? Convert.ToInt32(reader["NUMERIC_PRECISION"]) : (int?)null,
                            Scale = reader["NUMERIC_SCALE"] != DBNull.Value ? Convert.ToInt32(reader["NUMERIC_SCALE"]) : (int?)null,
                            Nullable = reader["IS_NULLABLE"].ToString() == "YES",
                            TrimTrailingBlanks = reader["TRIMTRAILINGBLANKS"].ToString(),
                            FixedLenNullInSource = reader["FIXEDLENNULLINSOURCE"].ToString(),
                            Collation = reader["COLLATION"].ToString(),
                            IsIdentity = reader["ISIDENTITY"] != DBNull.Value && Convert.ToBoolean(reader["ISIDENTITY"])
                        });
                    }
                }
            }
            return columns;
        }

        private List<object> GetProcedures()
        {
            var procedures = new List<object>();
            string getProceduresQuery = "SELECT name, OBJECT_DEFINITION(OBJECT_ID) AS Definition FROM sys.procedures";
            using (SqlCommand command = new SqlCommand(getProceduresQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    procedures.Add(new
                    {
                        name = reader["name"].ToString(),
                        definition = reader["Definition"].ToString()
                    });
                }
            }
            return procedures;
        }

        private List<object> GetFunctions()
        {
            var functions = new List<object>();
            string getFunctionsQuery = "SELECT name, OBJECT_DEFINITION(OBJECT_ID) AS Definition FROM sys.objects WHERE type IN ('FN', 'IF', 'TF')";
            using (SqlCommand command = new SqlCommand(getFunctionsQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    functions.Add(new
                    {
                        name = reader["name"].ToString(),
                        definition = reader["Definition"].ToString()
                    });
                }
            }
            return functions;
        }

        private List<object> GetConstraints()
        {
            var constraints = new List<object>();
            string getConstraintsQuery = "SELECT TABLE_NAME, CONSTRAINT_NAME, CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS";
            using (SqlCommand command = new SqlCommand(getConstraintsQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    constraints.Add(new
                    {
                        tableName = reader["TABLE_NAME"].ToString(),
                        constraintName = reader["CONSTRAINT_NAME"].ToString(),
                        constraintType = reader["CONSTRAINT_TYPE"].ToString()
                    });
                }
            }
            return constraints;
        }

        private List<object> GetTriggers()
        {
            var triggers = new List<object>();
            string getTriggersQuery = "SELECT name, OBJECT_DEFINITION(OBJECT_ID) AS Definition FROM sys.triggers";
            using (SqlCommand command = new SqlCommand(getTriggersQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    triggers.Add(new
                    {
                        name = reader["name"].ToString(),
                        definition = reader["Definition"].ToString()
                    });
                }
            }
            return triggers;
        }

        private List<object> GetIndices()
        {
            var indices = new List<object>();
            string getIndicesQuery = @"
                SELECT i.name AS IndexName, 
                       t.name AS TableName, 
                       i.type_desc AS IndexType
                FROM sys.indexes i
                INNER JOIN sys.tables t ON i.object_id = t.object_id
                WHERE i.is_primary_key = 0 AND i.is_unique = 0";
            using (SqlCommand command = new SqlCommand(getIndicesQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    indices.Add(new
                    {
                        indexName = reader["IndexName"].ToString(),
                        tableName = reader["TableName"].ToString(),
                        indexType = reader["IndexType"].ToString()
                    });
                }
            }
            return indices;
        }

        private List<object> GetViews()
        {
            var views = new List<object>();
            string getViewsQuery = "SELECT name, OBJECT_DEFINITION(OBJECT_ID) AS Definition FROM sys.views";
            using (SqlCommand command = new SqlCommand(getViewsQuery, _Conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    views.Add(new
                    {
                        name = reader["name"].ToString(),
                        definition = reader["Definition"].ToString()
                    });
                }
            }
            return views;
        }

        private object ExecuteScalar(string query)
        {
            using (SqlCommand command = new SqlCommand(query, _Conn))
            {
                return command.ExecuteScalar();
            }
        }

        private void ExecuteNonQuery(string query)
        {
            using (SqlCommand command = new SqlCommand(query, _Conn))
            {
                command.ExecuteNonQuery();
            }
        }
    
        private void btnSelecionarDestino_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",  // Filtro para arquivos JSON
                Title = "Selecione onde salvar o arquivo JSON",  // Título do diálogo
                FileName = "database.json"  // Nome padrão do arquivo
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                _SaveFileDialog = saveFileDialog;
                txtDestino.Text = filePath;
            }
        }
    }
}
