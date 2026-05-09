using System;
using System.Windows.Forms;

namespace CalculadoraDeMedias01
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormCalculadora());
        }
    }
}
