using Consultorio.Data.Produtos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Produtos
{
    public class BaixaDeProdutoViewModel : INotifyPropertyChanged
    {
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Atributos**********-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private Produto _Produto;
        public Produto Produto
        {
            get { return _Produto; }
            set { _Produto = value; OnPropertyChanged("Produto"); }
        }

        private string _Motivo;
        public string Motivo
        {
            get { return _Motivo; }
            set { _Motivo = value; OnPropertyChanged("Motivo"); }
        }

        private int _QtdRetirada;
        public int QtdRetirada
        {
            get { return _QtdRetirada; }
            set { _QtdRetirada = value; OnPropertyChanged("QtdRetirada"); }
        }

        public BaixaDeProdutoViewModel(int id)
        {
            Produto = ProdutoData.SelecionarProduto(id);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public List<string> VerificarCamposObrigatorios(out bool camposOk)
        {
            List<string> lista = new List<string>();
            if (Motivo == "" || Motivo == null)
            {
                lista.Add("Motivo não pode ficar em branco");
            }
            if (QtdRetirada <= 0 || QtdRetirada > Produto.Quantidade)
            {
                lista.Add("A quantidade retirada não pode ser superior a quantidade em estoque e nem abaixo de 0");
            }
            if (lista.Count > 0)
            {
                camposOk = false;
                return lista;
            }
            camposOk = true;
            return lista;
        }

        public string SalvarBaixa()
        {
            VerificarCamposObrigatorios(out bool ok);
            if (ok)
            {
                Produto.Quantidade = Produto.Quantidade - QtdRetirada;

                return ProdutoData.RetiradaDeEstoque(Produto, Motivo);
            }
            return "";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********PropertyChanged**********-----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
        }
    }
}
