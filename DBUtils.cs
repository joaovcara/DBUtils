using DBUtils.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBUtils
{
    public partial class DBUtils : Form
    {
        private bool isFormVisible = false;
        private SqlConnection _Conn;
        private string connectionString;
        private SaveFileDialog _SaveFileDialog;

        public DBUtils()
        {
            InitializeComponent();
            ConfiguraFormulario();

            txtSenha.PasswordChar = '*';
            btnDesconectar.Enabled = false;

            btnCriarBanco.Enabled = false;
            btnGerarJSON.Enabled = false;
            btnGerarBkp.Enabled = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // Receber os dados da tela (supondo que você tenha TextBoxes para instância, usuário e senha)
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

            // Verifica se a conexão já foi estabelecida

            if (ConnectionManager.CheckConnection(_Conn))
            {
                MessageBox.Show("Já existe uma conexão aberta com banco de dados!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return; // Se a conexão já estiver aberta, não faz nada
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
                // Defina a string de conexão uma vez
                ConnectionManager.SetConnectionString(connectionString);
                SqlConnection conn = ConnectionManager.GetConnection();
                
                MessageBox.Show("Conectado com sucesso!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnConectar.Enabled = false;
                txtInstancia.Enabled = false;
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
                chkAutenticaWindows.Enabled = false;

                btnDesconectar.Enabled = true;
                btnCriarBanco.Enabled = true;
                btnGerarJSON.Enabled = true;
                btnGerarBkp.Enabled = true;
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

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (ConnectionManager.CheckConnection(_Conn))
            {
                _Conn.Close();

                MessageBox.Show("Conexão encerrada!",
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtInstancia.Enabled = true;
                txtUsuario.Enabled = true;
                txtSenha.Enabled = true;
                chkAutenticaWindows.Enabled = true;
                chkAutenticaWindows.Checked = false;
                btnConectar.Enabled = true;

                btnDesconectar.Enabled = false;
                btnCriarBanco.Enabled = false;
                btnGerarJSON.Enabled = false;
                btnGerarBkp.Enabled = false;
            }
            else
            {
                MessageBox.Show("Não existem conexões ativas!", 
                    "Alerta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void chkAutenticaWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtUsuario.Enabled = !chkAutenticaWindows.Checked;
            txtSenha.Enabled = !chkAutenticaWindows.Checked;
        }

        // Evento de clique na notificação
        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            // Torna o formulário visível novamente e o traz para o foco
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void ShowForm()
        {
            if (!isFormVisible)
            {
                this.Show(); // Exibe o formulário
                this.ShowInTaskbar = true; // Mostra na barra de tarefas
                this.WindowState = FormWindowState.Normal; // Garante que não está minimizado
            }
        }

        private void ExitApplication()
        {
            // Libera os recursos usados pelo NotifyIcon
            notifyIcon.Visible = false;
            notifyIcon.Dispose();

            // Encerra a aplicação
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Oculta o formulário em vez de fechá-lo
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
            isFormVisible = false;
        }

        private void btnCriarBanco_Click(object sender, EventArgs e)
        {
            GerarBanco gerarBanco = new GerarBanco();
            gerarBanco.Show();
        }

        private void btnGerarJSON_Click(object sender, EventArgs e)
        {
            GerarJson gerarJson = new GerarJson();
            gerarJson.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            GerarBkp gerarBkp = new GerarBkp();
            gerarBkp.Show();
        }

        private void ConfiguraFormulario()
        {
            // Configurações do formulário
            this.Text = "DBUtils";
            this.WindowState = FormWindowState.Minimized; // Inicializa minimizado
            this.ShowInTaskbar = false; // Não mostrar na barra de tarefas inicialmente

            // Inicializando o NotifyIcon
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon(System.IO.Path.Combine(Application.StartupPath, "Resources", "utility.ico")), // Carrega o ícone usando o caminho
                Text = "DBUtils", // Texto ao passar o mouse sobre o ícone
                Visible = true, // Torna o ícone visível
                BalloonTipTitle = "Bem-vindo!", // Título da notificação
                BalloonTipText = "DBUtils iniciado com sucesso.", // Texto da notificação
                BalloonTipIcon = ToolTipIcon.Info // Tipo de ícone da notificação
            };

            // Exibe a notificação na bandeja do sistema
            notifyIcon.ShowBalloonTip(3000); // Exibe a notificação por 3 segundos

            // Evento para exibir o aplicativo ao clicar na notificação
            notifyIcon.BalloonTipClicked += (s, e) => ShowForm();

            // Adiciona um menu de contexto usando ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Abrir", null, (s, e) => ShowForm());
            contextMenu.Items.Add("Sair", null, (s, e) => ExitApplication());
            notifyIcon.ContextMenuStrip = contextMenu;

            // Adiciona o evento de duplo clique
            notifyIcon.MouseDoubleClick += (s, e) => ShowForm();

            // Minimiza e esconde o formulário ao iniciar
            this.Load += (s, e) => { this.Hide(); };
        }
    }
}
