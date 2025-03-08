using DBUtils.Forms;

namespace DBUtils
{
    public partial class DBUtils : Form
    {
        private bool isFormVisible = false;

        public DBUtils()
        {
            InitializeComponent();
            ConfiguraFormulario();

            // Associa o evento FormClosing ao método DBUtils_FormClosing
            this.FormClosing += DBUtils_FormClosing;
        }

        // Exibir o formulário quando solicitado
        private void ShowForm()
        {
            if (!isFormVisible)
            {
                this.Show(); // Exibe o formulário
                this.ShowInTaskbar = true; // Mostra na barra de tarefas
                this.WindowState = FormWindowState.Normal; // Garante que não está minimizado
                this.Activate(); // Ativa o formulário (pode ser útil se a janela estiver em segundo plano)
                isFormVisible = true; // Marca o formulário como visível
            }
        }

        // Método para encerrar a aplicação e liberar recursos
        private void ExitApplication()
        {
            // Libera os recursos usados pelo NotifyIcon
            notifyIcon.Visible = false;
            notifyIcon.Dispose();

            // Encerra a aplicação
            Application.Exit();
        }

        // Clique para gerar o script
        private void btnGerarScript_Click(object sender, EventArgs e)
        {
            GerarScript gerarScript = new GerarScript();
            gerarScript.Show();
        }

        // Clique para criar o banco
        private void btnCriarBanco_Click(object sender, EventArgs e)
        {
            GerarBanco gerarBanco = new GerarBanco();
            if (gerarBanco.Connection != null)
            {
                gerarBanco.Show();
            }
        }

        // Clique para gerar o JSON
        private void btnGerarJSON_Click(object sender, EventArgs e)
        {
            GerarJson gerarJson = new GerarJson();
            if (gerarJson.Connection != null)
            {
                gerarJson.Show();
            }
        }

        // Clique para realizar o backup
        private void btnBackup_Click(object sender, EventArgs e)
        {
            GerarBkp gerarBkp = new GerarBkp();
            if (gerarBkp.Connection != null)
            {
                gerarBkp.Show();
            }
        }

        // Configurações do formulário e NotifyIcon
        private void ConfiguraFormulario()
        {
            this.MaximizeBox = false;  // Desabilita o botão de maximizar
            this.MinimizeBox = false;  // Desabilita o botão de minimizar

            // Configurações iniciais
            this.Text = "DBUtils";
            this.WindowState = FormWindowState.Minimized; // Inicializa minimizado
            this.ShowInTaskbar = false; // Não mostrar na barra de tarefas inicialmente

            // Inicializando o NotifyIcon
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon(System.IO.Path.Combine(Application.StartupPath, "Resources", "utility.ico")), // Carrega o ícone
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

            // Adiciona um menu de contexto ao ícone da bandeja
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Abrir", null, (s, e) => ShowForm()); // Abre o formulário
            contextMenu.Items.Add("Sair", null, (s, e) => ExitApplication()); // Encerra a aplicação
            notifyIcon.ContextMenuStrip = contextMenu;

            // Adiciona o evento de duplo clique
            notifyIcon.MouseDoubleClick += (s, e) => ShowForm();

            // Minimiza e esconde o formulário ao iniciar
            this.Load += (s, e) => { this.Hide(); };
        }

        // Impede que o formulário seja fechado, apenas minimizado para a bandeja
        private void DBUtils_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Evita que o formulário seja fechado
                isFormVisible = false;
                e.Cancel = true;
                this.Hide(); // Esconde o formulário
            }
        }
    }
}
