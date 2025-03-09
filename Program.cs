namespace DBUtils
{
    internal static class Program
    {

        static Mutex mutex = new Mutex(true, "{DBUtilsAppMutex}");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Verifica se o mutex já foi adquirido por outra instância
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // Inicia a aplicação normalmente se não houver outra instância em execução
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DBUtils());  // Executa o formulário principal
            }
            else
            {
                // Se a instância já estiver em execução, mostra um alerta e sai
                MessageBox.Show("Uma instância do DBUtils já está em execução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}