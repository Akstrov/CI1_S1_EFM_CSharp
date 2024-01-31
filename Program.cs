using System.Data.SqlClient;

namespace efm_c_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        public static SqlConnection GetConnexion()
        {
            return new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=efm_cs; Integrated Security=true");
        }

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}