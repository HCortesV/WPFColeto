using ElColeto.Views.Home;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ElColeto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (new Login().ShowDialog() == true)
                {
                    new Home().ShowDialog();
                }
                else
                {
                    MessageBox.Show("login failed");
                }
            }
            finally
            {
                Shutdown();
            }
        }
    }
}
