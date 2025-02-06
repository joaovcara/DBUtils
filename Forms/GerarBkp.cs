using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DBUtils.Utils;
using Microsoft.Data.SqlClient;

namespace DBUtils
{
    public partial class GerarBkp : Form
    {
        private SqlConnection _Conn;
        private string database;
        private SaveFileDialog _SaveFileDialog;

        public GerarBkp()
        {
            _Conn = ConnectionManager.GetConnection();
            InitializeComponent();
            GetDatabases();
        }

        // Evento para gerar o backup
        private void btnGeraBkp_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se o caminho do arquivo de backup foi selecionado
                if (_SaveFileDialog == null || string.IsNullOrEmpty(_SaveFileDialog.FileName))
                {
                    MessageBox.Show("Por favor, selecione o destino do arquivo de backup!",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // SQL para backup
                string backupQuery = $"BACKUP DATABASE [{database}] TO DISK = '{_SaveFileDialog.FileName}' WITH INIT";

                if (!ConnectionManager.CheckConnection(_Conn))
                    _Conn.Open();

                using (SqlCommand command = new SqlCommand(backupQuery, _Conn))
                {
                    // Executa o comando SQL para realizar o backup
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Backup realizado com sucesso!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o backup: " + ex.Message,
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Método para obter os bancos de dados
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

        // Evento para selecionar o destino do backup
        private void btnSelecionarDestino_Click(object sender, EventArgs e)
        {
            // Cria o diálogo de salvar arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos de Backup (*.bak)|*.bak|All Files (*.*)|*.*",  // Filtro para arquivos .bak
                Title = "Selecione onde salvar o arquivo de backup",  // Título do diálogo
                FileName = database + ".bak"  // Nome padrão do arquivo
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Atribui o caminho do arquivo ao _SaveFileDialog
                _SaveFileDialog = saveFileDialog;
                txtDestino.Text = saveFileDialog.FileName;  // Exibe o caminho no TextBox
            }
        }

        // Evento para selecionar o banco de dados
        private void cbDataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Atualiza o banco de dados selecionado
            database = cbDataBases.SelectedItem.ToString();
        }
    }
}
