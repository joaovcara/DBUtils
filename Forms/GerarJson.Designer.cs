namespace DBUtils
{
    partial class GerarJson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarJson));
            btnGeraJson = new Button();
            groupBox2 = new GroupBox();
            txtDestino = new TextBox();
            btnSelecionarDestino = new Button();
            label4 = new Label();
            cbDataBases = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGeraJson
            // 
            btnGeraJson.BackColor = SystemColors.HotTrack;
            btnGeraJson.BackgroundImageLayout = ImageLayout.None;
            btnGeraJson.FlatAppearance.BorderSize = 0;
            btnGeraJson.FlatStyle = FlatStyle.Flat;
            btnGeraJson.ForeColor = SystemColors.ControlLightLight;
            btnGeraJson.Location = new Point(65, 145);
            btnGeraJson.Name = "btnGeraJson";
            btnGeraJson.Size = new Size(155, 40);
            btnGeraJson.TabIndex = 2;
            btnGeraJson.Text = "Exportar";
            btnGeraJson.UseVisualStyleBackColor = false;
            btnGeraJson.Click += btnGeraJson_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtDestino);
            groupBox2.Controls.Add(btnSelecionarDestino);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cbDataBases);
            groupBox2.Controls.Add(btnGeraJson);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(285, 196);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Selecionar base de dados";
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
            txtDestino.TabIndex = 4;
            // 
            // btnSelecionarDestino
            // 
            btnSelecionarDestino.Location = new Point(123, 55);
            btnSelecionarDestino.Name = "btnSelecionarDestino";
            btnSelecionarDestino.Size = new Size(156, 23);
            btnSelecionarDestino.TabIndex = 1;
            btnSelecionarDestino.Text = "Selecionar Pasta";
            btnSelecionarDestino.UseVisualStyleBackColor = true;
            btnSelecionarDestino.Click += btnSelecionarDestino_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 58);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 1;
            label4.Text = "Caminho de destino";
            // 
            // cbDataBases
            // 
            cbDataBases.FormattingEnabled = true;
            cbDataBases.Location = new Point(6, 27);
            cbDataBases.Name = "cbDataBases";
            cbDataBases.Size = new Size(273, 23);
            cbDataBases.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // GerarJson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(309, 221);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GerarJson";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exportar banco de dados";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGeraJson;
        private GroupBox groupBox2;
        private ComboBox cbDataBases;
        private TextBox txtDestino;
        private Button btnSelecionarDestino;
        private Label label4;
        private OpenFileDialog openFileDialog1;
    }
}
