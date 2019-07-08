using Consultorio.Data;
using Consultorio.Model;
using Consultorio.ViewModel;
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
using System.Windows.Shapes;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para ViewListaDeColaboradores.xaml
    /// </summary>
    public partial class ListaDeColaboradoresView : Window
    {
        public SingletonAtorLogado AtorLogado { get; set; }

        public ListaDeColaboradoresView()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            CadastroDeColaboradoresViewModel cadastroDeColaboradoresViewModel = new CadastroDeColaboradoresViewModel();
            this.Close();
            //this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RecarregarGrid();
        }

        private void DgListaAtores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgListaAtores.SelectedIndex >= 0)
            {
                var ator = (Atores)dgListaAtores.Items[dgListaAtores.SelectedIndex];

                if (ator.GetType().ToString() == "Consultorio.Model.Dentista")
                {
                    this.Hide();
                    DentistaViewModel dentistaViewModel = new DentistaViewModel((Dentista)ator);                  
                    this.Visibility = Visibility.Visible;
                }
                else if (ator.GetType().ToString() == "Consultorio.Model.Secretaria")
                {
                    SecretariaView viewSecretaria = new SecretariaView((Secretaria)ator);
                    this.Hide();
                    viewSecretaria.ShowDialog();
                    this.Visibility = Visibility.Visible;
                }
                else if (ator.GetType().ToString() == "Consultorio.Model.GestorDeEstoque")
                {
                    GestorDeEstoqueView viewGestorDeEstoque = new GestorDeEstoqueView((GestorDeEstoque)ator);
                    this.Hide();
                    viewGestorDeEstoque.ShowDialog();
                    this.Visibility = Visibility.Visible;
                }
            }
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaAtores.SelectedIndex >= 0)
            {
                Atores atorSelecionado = (Atores)dgListaAtores.Items[dgListaAtores.SelectedIndex];
                string atorSelecionadoType = atorSelecionado.GetType().Name;

                var atorLogadoType = AtorLogado.Ator.GetType();
                //edição dos atores iniciada por uma secretaria
                if (atorLogadoType.Name == "Secretaria")
                {
                    Secretaria secretaria = (Secretaria)AtorLogado.Ator;

                    if (atorSelecionadoType == "Dentista")
                    {
                        MessageBox.Show("Operação não permitida para este tipo de usuario", "Acesso negado!");
                        return;
                    }
                    else if (atorSelecionadoType == "GestorDeEstoque")
                    {
                        if(secretaria.CrudGestoresDeEstoque == true)
                        {
                            EditarGestor((GestorDeEstoque)atorSelecionado);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Operação não permitida para este usuario", "Acesso negado!");
                            return;
                        }
                    }
                    else if (atorSelecionadoType == "Secretaria")
                    {
                        if (secretaria.CrudSecretarias == true)
                        {
                            EditarSecretaria((Secretaria)atorSelecionado);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Operação não permitida para este usuario", "Acesso negado!");
                            return;
                        }
                    }
                }
                // Ediçao dos atores iniciada por um adm
                else
                {
                    if (atorSelecionadoType == "Dentista")
                    {
                        EditarDentista((Dentista)atorSelecionado);
                        return;
                    }
                    else if (atorSelecionadoType == "Secretaria")
                    {
                        EditarSecretaria((Secretaria)atorSelecionado);
                        return;
                    }
                    else if (atorSelecionadoType == "GestorDeEstoque")
                    {
                        EditarGestor((GestorDeEstoque)atorSelecionado);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum elemento selecionado!", "Erro");
            }     
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void RecarregarGrid()
        {
            dgListaAtores.ItemsSource = ColaboradoresData.ListarAtores();
            //Login
            dgListaAtores.Columns[5].Visibility = Visibility.Collapsed;
            //Senha
            dgListaAtores.Columns[6].Visibility = Visibility.Collapsed;
        }

        private void EditarSecretaria(Secretaria atorSelecionado)
        {
            SecretariaView viewSecretaria = new SecretariaView(atorSelecionado);
            this.Hide();
            viewSecretaria.ShowDialog();
            RecarregarGrid();
            this.Visibility = Visibility.Visible;
        }

        private void EditarGestor(GestorDeEstoque atorSelecionado)
        {
            GestorDeEstoqueView viewGestorDeEstoque = new GestorDeEstoqueView(atorSelecionado);
            this.Hide();
            viewGestorDeEstoque.ShowDialog();
            RecarregarGrid();
            this.Visibility = Visibility.Visible;
        }

        private void EditarDentista(Dentista atorSelecionado)
        {
            this.Hide();
            DentistaViewModel dentistaViewModel = new DentistaViewModel(atorSelecionado);
            RecarregarGrid();
            this.Visibility = Visibility.Visible;
        }
    }
}
