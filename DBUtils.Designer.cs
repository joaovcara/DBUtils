namespace DBUtils
{
    partial class DBUtils
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBUtils));
            notifyIcon = new NotifyIcon(components);
            groupBox1 = new GroupBox();
            btnGerarBkp = new Button();
            btnGerarJSON = new Button();
            btnCriarBanco = new Button();
            toolTip = new ToolTip(components);
            groupBox2 = new GroupBox();
            btnDesconectar = new Button();
            chkAutenticaWindows = new CheckBox();
            btnConectar = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtSenha = new TextBox();
            txtUsuario = new TextBox();
            txtInstancia = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.Text = "notifyIcon";
            notifyIcon.Visible = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGerarBkp);
            groupBox1.Controls.Add(btnGerarJSON);
            groupBox1.Controls.Add(btnCriarBanco);
            groupBox1.Location = new Point(12, 193);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 116);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ferramentas";
            // 
            // btnGerarBkp
            // 
            btnGerarBkp.BackColor = Color.Transparent;
            btnGerarBkp.BackgroundImage = (Image)resources.GetObject("btnGerarBkp.BackgroundImage");
            btnGerarBkp.BackgroundImageLayout = ImageLayout.Center;
            btnGerarBkp.FlatAppearance.BorderSize = 0;
            btnGerarBkp.ForeColor = Color.Transparent;
            btnGerarBkp.Location = new Point(199, 22);
            btnGerarBkp.Name = "btnGerarBkp";
            btnGerarBkp.Size = new Size(80, 80);
            btnGerarBkp.TabIndex = 8;
            toolTip.SetToolTip(btnGerarBkp, "Gerar backup");
            btnGerarBkp.UseVisualStyleBackColor = false;
            btnGerarBkp.Click += btnBackup_Click;
            // 
            // btnGerarJSON
            // 
            btnGerarJSON.BackColor = Color.Transparent;
            btnGerarJSON.BackgroundImage = (Image)resources.GetObject("btnGerarJSON.BackgroundImage");
            btnGerarJSON.BackgroundImageLayout = ImageLayout.Center;
            btnGerarJSON.FlatAppearance.BorderSize = 0;
            btnGerarJSON.ForeColor = Color.Transparent;
            btnGerarJSON.Location = new Point(103, 22);
            btnGerarJSON.Name = "btnGerarJSON";
            btnGerarJSON.Size = new Size(80, 80);
            btnGerarJSON.TabIndex = 7;
            toolTip.SetToolTip(btnGerarJSON, "Exportar Database.json");
            btnGerarJSON.UseVisualStyleBackColor = false;
            btnGerarJSON.Click += btnGerarJSON_Click;
            // 
            // btnCriarBanco
            // 
            btnCriarBanco.BackColor = Color.Transparent;
            btnCriarBanco.BackgroundImage = (Image)resources.GetObject("btnCriarBanco.BackgroundImage");
            btnCriarBanco.BackgroundImageLayout = ImageLayout.Center;
            btnCriarBanco.FlatAppearance.BorderSize = 0;
            btnCriarBanco.ForeColor = Color.Transparent;
            btnCriarBanco.Location = new Point(6, 22);
            btnCriarBanco.Name = "btnCriarBanco";
            btnCriarBanco.Size = new Size(80, 80);
            btnCriarBanco.TabIndex = 6;
            toolTip.SetToolTip(btnCriarBanco, "Novo banco de dados");
            btnCriarBanco.UseVisualStyleBackColor = false;
            btnCriarBanco.Click += btnCriarBanco_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDesconectar);
            groupBox2.Controls.Add(chkAutenticaWindows);
            groupBox2.Controls.Add(btnConectar);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtSenha);
            groupBox2.Controls.Add(txtUsuario);
            groupBox2.Controls.Add(txtInstancia);
            groupBox2.Location = new Point(12, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(285, 180);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados da Conexão";
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(66, 145);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(102, 23);
            btnDesconectar.TabIndex = 9;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // chkAutenticaWindows
            // 
            chkAutenticaWindows.AutoSize = true;
            chkAutenticaWindows.Location = new Point(9, 58);
            chkAutenticaWindows.Name = "chkAutenticaWindows";
            chkAutenticaWindows.Size = new Size(175, 19);
            chkAutenticaWindows.TabIndex = 2;
            chkAutenticaWindows.Text = "Autenticação com Windows";
            chkAutenticaWindows.UseVisualStyleBackColor = true;
            chkAutenticaWindows.CheckedChanged += chkAutenticaWindows_CheckedChanged;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(173, 145);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(106, 23);
            btnConectar.TabIndex = 5;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 115);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 86);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 5;
            label2.Text = "Usuário";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 4;
            label1.Text = "Instância";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(66, 112);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(213, 23);
            txtSenha.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(66, 83);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(213, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtInstancia
            // 
            txtInstancia.Location = new Point(66, 29);
            txtInstancia.Name = "txtInstancia";
            txtInstancia.Size = new Size(213, 23);
            txtInstancia.TabIndex = 1;
            // 
            // DBUtils
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 321);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DBUtils";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DBUtils";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon;
        private GroupBox groupBox1;
        private Button btnGerarBkp;
        private Button btnGerarJSON;
        private Button btnCriarBanco;
        private ToolTip toolTip;
        private GroupBox groupBox2;
        private Button btnDesconectar;
        private CheckBox chkAutenticaWindows;
        private Button btnConectar;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private TextBox txtInstancia;
    }
}