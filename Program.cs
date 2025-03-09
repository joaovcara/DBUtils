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
            // Verifica se o mutex j� foi adquirido por outra inst�ncia
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // Inicia a aplica��o normalmente se n�o houver outra inst�ncia em execu��o
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DBUtils());  // Executa o formul�rio principal
            }
            else
            {
                // Se a inst�ncia j� estiver em execu��o, mostra um alerta e sai
                MessageBox.Show("Uma inst�ncia do DBUtils j� est� em execu��o.", "Aten��o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}