using Consultorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Consultorio.View;

namespace Consultorio
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            /* usando apenas para teste 
            using(ConsultorioContext context = new ConsultorioContext())
            {
                GestorDeEstoque gestor = new GestorDeEstoque("GestorTeste", "TesteSobrenome", "TesteEmail", "TesteTelefone1", "TesteTelefone2", "teste", "teste");

                context.Gestores.Add(gestor);
                context.SaveChanges();
            }

            Console.WriteLine("Cliente salvo");*/
        }

        private void BtEntrar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            opcoes.Show();
            this.Close(); //para fechar
            //this.Hide(); //para esconder
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
