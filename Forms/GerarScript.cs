using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DBUtils.Forms
{
    public partial class GerarScript : Form
    {
        public GerarScript()
        {
            InitializeComponent();
            CarregaTipoScript();
        }

        private void CarregaTipoScript()
        {
            cmbTipoScript.Items.AddRange(new object[] { "", "Tabela", "Script", "Dados Padrão" });
            cmbTipoScript.SelectedIndex = 0;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQL Files|*.sql",
                Title = "Selecione os arquivos SQL",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtScript.Text = string.Join(";", openFileDialog.FileNames);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string scriptPaths = txtScript.Text;
            string tipoSelecionado = cmbTipoScript.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(scriptPaths) && !string.IsNullOrEmpty(tipoSelecionado))
            {
                string[] paths = scriptPaths.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var scriptPath in paths)
                {
                    ListViewItem item = new ListViewItem(scriptPath.Trim());
                    item.SubItems.Add(tipoSelecionado);
                    lstScripts.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um arquivo e um tipo de script.");
            }

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtScript.Text = string.Empty;
            cmbTipoScript.SelectedIndex = 0;
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Selecione o destino para salvar o arquivo SQL",
                FileName = "script_" + txtVersao.Text.ToString() + ".sql",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinoPath = saveFileDialog.FileName;
                txtDestino.Text = destinoPath;
            }
        }

        private void btnGerarScript_Click(object sender, EventArgs e)
        {
            if (lstScripts.Items.Count == 0)
            {
                MessageBox.Show("Por favor, adicione scripts antes de gerar.");
                return;
            }

            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.AppendLine(GeraComentarioScript());

            // Ordena os itens da ListView
            var sortedItems = lstScripts.Items.Cast<ListViewItem>()
                .OrderBy(item => GetOrder(item.SubItems[1].Text))
                .ToList();

            bool isFirstTable = true;
            bool isFirstScript = true;
            bool isFirstDataDefault = true;

            foreach (ListViewItem item in sortedItems)
            {
                string scriptPath = item.Text;
                string tipoSelecionado = item.SubItems[1].Text;

                try
                {
                    if (tipoSelecionado == "Tabela")
                    {
                        // Verifica se o tipo selecionado é "Table"
                        // Se for a primeira vez que estamos lidando com este tipo,
                        // adiciona um comentário ao script indicando que a seção a seguir
                        // contém scripts de criação de tabelas e dados.
                        if (isFirstTable)
                        {
                            scriptBuilder.AppendLine("-----------------------------------------------------------------------");
                            scriptBuilder.AppendLine("-------------------- SCRIPTS DE CRIAÇÃO DE TABELAS --------------------");
                            
                            isFirstTable = false; // Marca que já lidamos com este tipo
                        }
                    }
                    else if (tipoSelecionado == "Script")
                    {
                        // Verifica se o tipo selecionado é "Script"
                        // Se for a primeira vez que estamos lidando com este tipo,
                        // adiciona um comentário ao script indicando que a seção a seguir
                        // contém scripts de alteração de estrutura.
                        if (isFirstScript)
                        {
                            scriptBuilder.AppendLine("-----------------------------------------------------------------------");
                            scriptBuilder.AppendLine("------------------ SCRIPTS DE ALTERAÇÃO DE ESTRUTURA ------------------");
                            
                            isFirstScript = false; // Marca que já lidamos com este tipo
                        }
                    }
                    else if (tipoSelecionado == "Dados Padrão")
                    {
                        // Verifica se o tipo selecionado é "DataDefault"
                        // Se for a primeira vez que estamos lidando com este tipo,
                        // adiciona um comentário ao script indicando que a seção a seguir
                        // contém scripts de inserção de dados padrão.
                        if (isFirstDataDefault)
                        {
                            scriptBuilder.AppendLine("-----------------------------------------------------------------------");
                            scriptBuilder.AppendLine("----------------- SCRIPTS DE INSERÇÃO DE DADOS PADRÃO -----------------");
                            
                            isFirstDataDefault = false; // Marca que já lidamos com este tipo
                        }
                    }

                    // Lê o conteúdo do arquivo com a codificação correta
                    string scriptContent = System.IO.File.ReadAllText(scriptPath, Encoding.GetEncoding("ISO-8859-1"));

                    scriptBuilder.AppendLine("-----------------------------------------------------------------------");
                    string fileName = System.IO.Path.GetFileName(scriptPath);
                    scriptBuilder.AppendLine("-- Arquivo: " + fileName);
                    DateTime lastModified = System.IO.File.GetLastWriteTime(scriptPath);
                    scriptBuilder.AppendLine("-- Data de alteração: " + lastModified.ToString("dd/MM/yyyy HH:mm:ss"));
                    scriptBuilder.AppendLine("-----------------------------------------------------------------------");
                    scriptBuilder.AppendLine(scriptContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ler o arquivo {scriptPath}: {ex.Message}");
                }
            }

            string destinoPath = txtDestino.Text;
            if (string.IsNullOrEmpty(destinoPath))
            {
                MessageBox.Show("Por favor, selecione um destino para salvar o script gerado.");
                return;
            }

            try
            {
                System.IO.File.WriteAllText(destinoPath, scriptBuilder.ToString(), Encoding.UTF8);
                MessageBox.Show("Script gerado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}");
            }
        }

        private string GeraComentarioScript()
        {
            string comentario = string.Empty;
            comentario += "-----------------------------------------------------------------------";
            comentario += Environment.NewLine;
            comentario += "-- Script gerado pela ferramenta DBUtils.";
            comentario += Environment.NewLine;
            comentario += "-- Versão: " + txtVersao.Text;
            comentario += Environment.NewLine;
            comentario += "-- Data Geração: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            comentario += Environment.NewLine;

            return comentario;
        }

        private int GetOrder(string tipo)
        {
            switch (tipo)
            {
                case "Tabela":
                    return 1;
                case "Script":
                    return 2;
                case "Dados Padrão":
                    return 3;
                default:
                    return 4; // Para tipos não reconhecidos
            }

        }
    }
}