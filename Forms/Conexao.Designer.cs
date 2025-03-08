namespace DBUtils.Forms
{
    partial class Conexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conexao));
            groupBox1 = new GroupBox();
            btnConectar = new Button();
            txtSenha = new TextBox();
            labelSenha = new Label();
            txtUsuario = new TextBox();
            label2 = new Label();
            chkAutenticaWindows = new CheckBox();
            txtInstancia = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConectar);
            groupBox1.Controls.Add(txtSenha);
            groupBox1.Controls.Add(labelSenha);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(chkAutenticaWindows);
            groupBox1.Controls.Add(txtInstancia);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 243);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados da Conexão";
            // 
            // btnConectar
            // 
            btnConectar.BackColor = SystemColors.HotTrack;
            btnConectar.BackgroundImageLayout = ImageLayout.None;
            btnConectar.FlatAppearance.BorderSize = 0;
            btnConectar.FlatStyle = FlatStyle.Flat;
            btnConectar.ForeColor = SystemColors.ControlLightLight;
            btnConectar.Location = new Point(136, 187);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(155, 38);
            btnConectar.TabIndex = 7;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = false;
            btnConectar.Click += btnConectar_Click;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(66, 144);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(331, 23);
            txtSenha.TabIndex = 6;
            // 
            // labelSenha
            // 
            labelSenha.AutoSize = true;
            labelSenha.Location = new Point(6, 147);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(39, 15);
            labelSenha.TabIndex = 5;
            labelSenha.Text = "Senha";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(66, 111);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(331, 23);
            txtUsuario.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 114);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "Usuário";
            // 
            // chkAutenticaWindows
            // 
            chkAutenticaWindows.AutoSize = true;
            chkAutenticaWindows.Location = new Point(6, 74);
            chkAutenticaWindows.Name = "chkAutenticaWindows";
            chkAutenticaWindows.Size = new Size(175, 19);
            chkAutenticaWindows.TabIndex = 2;
            chkAutenticaWindows.Text = "Autenticação com Windows";
            chkAutenticaWindows.UseVisualStyleBackColor = true;
            chkAutenticaWindows.CheckedChanged += chkAutenticaWindows_CheckedChanged;
            // 
            // txtInstancia
            // 
            txtInstancia.Location = new Point(66, 34);
            txtInstancia.Name = "txtInstancia";
            txtInstancia.Size = new Size(331, 23);
            txtInstancia.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 37);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Instância";
            // 
            // Conexao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 266);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Conexao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conexao";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtUsuario;
        private Label label2;
        private CheckBox chkAutenticaWindows;
        private TextBox txtInstancia;
        private Label label1;
        private TextBox txtSenha;
        private Label labelSenha;
        private Button btnConectar;
    }
}