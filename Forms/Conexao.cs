using DBUtils.Utils;
using Microsoft.Data.SqlClient;

namespace DBUtils.Forms
{
    public partial class Conexao : Form
    {
        private SqlConnection _Conn;
        private string connectionString;

        public SqlConnection Connection => _Conn;

        public Conexao()
        {
            InitializeComponent();
        }

        private void chkAutenticaWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtUsuario.Enabled = !chkAutenticaWindows.Checked;
            txtSenha.Enabled = !chkAutenticaWindows.Checked;
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (ConnectionManager.CheckConnection(_Conn))
            {
                _Conn.Close();

                MessageBox.Show("Conexão encerrada!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ResetForm();
            }
            else
            {
                MessageBox.Show("Não existem conexões ativas!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string server = txtInstancia.Text.Trim();
            bool autenticaWindows = chkAutenticaWindows.Checked;
            string user = txtUsuario.Text.Trim();
            string password = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(server))
            {
                MessageBox.Show("Preencha a instância do banco de dados!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (ConnectionManager.CheckConnection(_Conn))
            {
                MessageBox.Show("Já existe uma conexão aberta com banco de dados!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!autenticaWindows)
            {
                if (string.IsNullOrWhiteSpace(user))
                {
                    MessageBox.Show("Preencha o usuário!",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Preencha a senha!",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                connectionString = $"Data Source={server};Initial Catalog=master;User ID={user};Password={password};TrustServerCertificate=True;MultipleActiveResultSets=True";
            }
            else
            {
                connectionString = $"Data Source={server};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
            }

            try
            {
                ConnectionManager.SetConnectionString(connectionString);
                _Conn = ConnectionManager.GetConnection(); // Store the connection
                this.DialogResult = DialogResult.OK;

                MessageBox.Show("Conectado com sucesso!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close(); // Close the form after successful connection
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + sqlEx.Message,
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message,
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            txtInstancia.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            chkAutenticaWindows.Enabled = true;
            chkAutenticaWindows.Checked = false;
            btnConectar.Enabled = true;
        }
    }
}
