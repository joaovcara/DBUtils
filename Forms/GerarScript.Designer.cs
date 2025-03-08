namespace DBUtils.Forms
{
    partial class GerarScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarScript));
            txtVersao = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            txtScript = new TextBox();
            btnPesquisar = new Button();
            cmbTipoScript = new ComboBox();
            btnAdicionar = new Button();
            label4 = new Label();
            btnGerarScript = new Button();
            groupBox2 = new GroupBox();
            label5 = new Label();
            txtDestino = new TextBox();
            btnDestino = new Button();
            lstScripts = new ListView();
            Script = new ColumnHeader();
            Tipo = new ColumnHeader();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtVersao
            // 
            txtVersao.Location = new Point(112, 17);
            txtVersao.Name = "txtVersao";
            txtVersao.Size = new Size(185, 23);
            txtVersao.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Número Versão";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtScript);
            groupBox1.Controls.Add(btnPesquisar);
            groupBox1.Controls.Add(cmbTipoScript);
            groupBox1.Controls.Add(btnAdicionar);
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(586, 144);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selecionar Script";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 25);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 7;
            label3.Text = "Script";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 62);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "Tipo";
            // 
            // txtScript
            // 
            txtScript.Location = new Point(68, 22);
            txtScript.Name = "txtScript";
            txtScript.Size = new Size(431, 23);
            txtScript.TabIndex = 6;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(505, 22);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 5;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // cmbTipoScript
            // 
            cmbTipoScript.FormattingEnabled = true;
            cmbTipoScript.Location = new Point(68, 59);
            cmbTipoScript.Name = "cmbTipoScript";
            cmbTipoScript.Size = new Size(512, 23);
            cmbTipoScript.TabIndex = 4;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = SystemColors.HotTrack;
            btnAdicionar.BackgroundImageLayout = ImageLayout.None;
            btnAdicionar.FlatAppearance.BorderSize = 0;
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.ForeColor = SystemColors.ControlLightLight;
            btnAdicionar.Location = new Point(228, 91);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(155, 40);
            btnAdicionar.TabIndex = 3;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 202);
            label4.Name = "label4";
            label4.Size = new Size(176, 15);
            label4.TabIndex = 6;
            label4.Text = "Scripts selecionados para versão";
            // 
            // btnGerarScript
            // 
            btnGerarScript.BackColor = SystemColors.HotTrack;
            btnGerarScript.BackgroundImageLayout = ImageLayout.None;
            btnGerarScript.FlatAppearance.BorderSize = 0;
            btnGerarScript.FlatStyle = FlatStyle.Flat;
            btnGerarScript.ForeColor = SystemColors.ControlLightLight;
            btnGerarScript.Location = new Point(228, 67);
            btnGerarScript.Name = "btnGerarScript";
            btnGerarScript.Size = new Size(155, 40);
            btnGerarScript.TabIndex = 3;
            btnGerarScript.Text = "Gerar Script";
            btnGerarScript.UseVisualStyleBackColor = false;
            btnGerarScript.Click += btnGerarScript_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtDestino);
            groupBox2.Controls.Add(btnDestino);
            groupBox2.Controls.Add(btnGerarScript);
            groupBox2.Location = new Point(12, 466);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(586, 128);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Destino";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 25);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 13;
            label5.Text = "Caminho";
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(68, 22);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(431, 23);
            txtDestino.TabIndex = 12;
            // 
            // btnDestino
            // 
            btnDestino.Location = new Point(505, 22);
            btnDestino.Name = "btnDestino";
            btnDestino.Size = new Size(75, 23);
            btnDestino.TabIndex = 11;
            btnDestino.Text = "Pesquisar";
            btnDestino.UseVisualStyleBackColor = true;
            btnDestino.Click += btnDestino_Click;
            // 
            // lstScripts
            // 
            lstScripts.Columns.AddRange(new ColumnHeader[] { Script, Tipo });
            lstScripts.Location = new Point(12, 220);
            lstScripts.Name = "lstScripts";
            lstScripts.Size = new Size(586, 240);
            lstScripts.TabIndex = 12;
            lstScripts.UseCompatibleStateImageBehavior = false;
            lstScripts.View = View.Details;
            // 
            // Script
            // 
            Script.Text = "Script";
            Script.Width = 450;
            // 
            // Tipo
            // 
            Tipo.Text = "Tipo";
            Tipo.Width = 130;
            // 
            // GerarScript
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 612);
            Controls.Add(lstScripts);
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(txtVersao);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GerarScript";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GerarScript";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVersao;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cmbTipoScript;
        private TextBox txtScript;
        private Button btnPesquisar;
        private Label label3;
        private Label label2;
        private Button btnAdicionar;
        private Label label4;
        private Button btnGerarScript;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtDestino;
        private Button btnDestino;
        private ListView lstScripts;
        private ColumnHeader Script;
        private ColumnHeader Tipo;
    }
}