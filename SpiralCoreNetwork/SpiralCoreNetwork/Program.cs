using SpiralCoreNetwork.Utils;

namespace SpiralCoreNetwork
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SpiralCoreEntryPoint.InitializeObj();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}