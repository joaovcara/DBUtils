namespace DBUtils
{
    partial class GerarBanco
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarBanco));
            btnGeraBanco = new Button();
            groupBox2 = new GroupBox();
            label1 = new Label();
            txtNomeBanco = new TextBox();
            txtDestino = new TextBox();
            btnSelecionarDestino = new Button();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGeraBanco
            // 
            btnGeraBanco.BackColor = SystemColors.HotTrack;
            btnGeraBanco.BackgroundImageLayout = ImageLayout.None;
            btnGeraBanco.FlatAppearance.BorderSize = 0;
            btnGeraBanco.FlatStyle = FlatStyle.Flat;
            btnGeraBanco.ForeColor = SystemColors.ControlLightLight;
            btnGeraBanco.Location = new Point(65, 145);
            btnGeraBanco.Name = "btnGeraBanco";
            btnGeraBanco.Size = new Size(155, 40);
            btnGeraBanco.TabIndex = 2;
            btnGeraBanco.Text = "Criar";
            btnGeraBanco.UseVisualStyleBackColor = false;
            btnGeraBanco.Click += btnGeraBanco_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtNomeBanco);
            groupBox2.Controls.Add(txtDestino);
            groupBox2.Controls.Add(btnSelecionarDestino);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnGeraBanco);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(285, 196);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Selecionar base de dados";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 25);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 5;
            label1.Text = "Nome do Banco";
            // 
            // txtNomeBanco
            // 
            txtNomeBanco.Location = new Point(123, 22);
            txtNomeBanco.Name = "txtNomeBanco";
            txtNomeBanco.Size = new Size(156, 23);
            txtNomeBanco.TabIndex = 0;
            // 
            // txtDestino
            // 
            txtDestino.BorderStyle = BorderStyle.None;
            txtDestino.Enabled = false;
            txtDestino.ForeColor = Color.Red;
            txtDestino.Location = new Point(6, 88);
            txtDestino.Multiline = true;
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(273, 51);
            txtDestino.TabIndex = 3;
            // 
            // btnSelecionarDestino
            // 
            btnSelecionarDestino.Location = new Point(123, 55);
            btnSelecionarDestino.Name = "btnSelecionarDestino";
            btnSelecionarDestino.Size = new Size(156, 23);
            btnSelecionarDestino.TabIndex = 1;
            btnSelecionarDestino.Text = "Selecionar ";
            btnSelecionarDestino.UseVisualStyleBackColor = true;
            btnSelecionarDestino.Click += btnSelecionarDestino_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 58);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 1;
            label4.Text = "Estrutura (json)";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // GerarBanco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(309, 221);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GerarBanco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novo banco de dados";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGeraBanco;
        private GroupBox groupBox2;
        private ComboBox cbDataBases;
        private TextBox txtDestino;
        private Button btnSelecionarDestino;
        private Label label4;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private TextBox txtNomeBanco;
    }
}
