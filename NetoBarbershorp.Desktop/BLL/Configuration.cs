using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

namespace NetoBarbershorp.Desktop.BLL
{
    public static class Configuration
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + Application.ProductName;
        private static string arquivoJson = Path.Combine(path, "configuration.json");

        public static string? AppSettings()
        {
            var dados = Properties.Settings.Default.dados;

            if (dados != null)
            {
                return dados;
            }

            return null;
        }
    }
}
