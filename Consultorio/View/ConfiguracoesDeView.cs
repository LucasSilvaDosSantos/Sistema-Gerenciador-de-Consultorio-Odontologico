using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Consultorio.View
{
    class ConfiguracoesDeView
    {
        static public void ConfigurarWindow(Window windowAtual, Window windowNova )
        {
            windowNova.Height = windowAtual.ActualHeight;
            windowNova.Width = windowAtual.ActualWidth;

            if (windowAtual.WindowState == WindowState.Maximized)
            {
                windowNova.WindowState = WindowState.Maximized;
            }
            else
            {
                windowNova.Top = windowAtual.Top;
                windowNova.Left = windowAtual.Left;
            }
        }
    }
}
