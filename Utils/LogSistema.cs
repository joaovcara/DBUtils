using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtils.Utils
{
    public class LogSistema
    {
        public void GenerateLog(string message)
        {
            // Obter a data atual e formatá-la como parte do nome do arquivo
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs"); // Diretório de logs
            string logFileName = $"appLog_{currentDate}.txt"; // Nome do arquivo de log com a data
            string logFilePath = Path.Combine(logDirectory, logFileName); // Caminho completo do arquivo de log
            string logMessage = $"|| {DateTime.Now:yyyy-MM-dd HH:mm:ss} || DBUtils || {message}"; // Mensagem de log com data e hora

            try
            {
                // Verificar se o diretório de logs existe, se não, criar
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Escrever a mensagem de log no arquivo
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    if (string.IsNullOrWhiteSpace(message))
                    {
                        writer.WriteLine(message);
                    }
                    else
                    {
                        writer.WriteLine(logMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao escrever no arquivo de log: {ex.Message}");
            }
        }
    }
}
