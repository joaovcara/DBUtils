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
            btnGerarScript = new Button();
            btnGerarBkp = new Button();
            btnGerarJSON = new Button();
            btnCriarBanco = new Button();
            toolTip = new ToolTip(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.Text = "notifyIcon";
            notifyIcon.Visible = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGerarScript);
            groupBox1.Controls.Add(btnGerarBkp);
            groupBox1.Controls.Add(btnGerarJSON);
            groupBox1.Controls.Add(btnCriarBanco);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(433, 137);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ferramentas";
            // 
            // btnGerarScript
            // 
            btnGerarScript.BackColor = Color.Transparent;
            btnGerarScript.BackgroundImage = (Image)resources.GetObject("btnGerarScript.BackgroundImage");
            btnGerarScript.BackgroundImageLayout = ImageLayout.Center;
            btnGerarScript.FlatAppearance.BorderSize = 0;
            btnGerarScript.ForeColor = Color.Transparent;
            btnGerarScript.Location = new Point(8, 22);
            btnGerarScript.Name = "btnGerarScript";
            btnGerarScript.Size = new Size(100, 100);
            btnGerarScript.TabIndex = 9;
            toolTip.SetToolTip(btnGerarScript, "Gerar script Versão");
            btnGerarScript.UseVisualStyleBackColor = false;
            btnGerarScript.Click += btnGerarScript_Click;
            // 
            // btnGerarBkp
            // 
            btnGerarBkp.BackColor = Color.Transparent;
            btnGerarBkp.BackgroundImage = (Image)resources.GetObject("btnGerarBkp.BackgroundImage");
            btnGerarBkp.BackgroundImageLayout = ImageLayout.Center;
            btnGerarBkp.FlatAppearance.BorderSize = 0;
            btnGerarBkp.ForeColor = Color.Transparent;
            btnGerarBkp.Location = new Point(220, 22);
            btnGerarBkp.Name = "btnGerarBkp";
            btnGerarBkp.Size = new Size(100, 100);
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
            btnGerarJSON.Location = new Point(114, 22);
            btnGerarJSON.Name = "btnGerarJSON";
            btnGerarJSON.Size = new Size(100, 100);
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
            btnCriarBanco.Location = new Point(326, 22);
            btnCriarBanco.Name = "btnCriarBanco";
            btnCriarBanco.Size = new Size(100, 100);
            btnCriarBanco.TabIndex = 6;
            toolTip.SetToolTip(btnCriarBanco, "Novo banco de dados");
            btnCriarBanco.UseVisualStyleBackColor = false;
            btnCriarBanco.Click += btnCriarBanco_Click;
            // 
            // DBUtils
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 162);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DBUtils";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DBUtils";
            groupBox1.ResumeLayout(false);
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
        private Button btnGerarScript;
    }
}