using Consultorio.Model;

namespace Consultorio.ViewModel.Atores
{
    public sealed class SingletonAtorLogado
    {
        static SingletonAtorLogado _instancia;
        public static SingletonAtorLogado Instancia
        {
            get { return _instancia ?? (_instancia = new SingletonAtorLogado()); }
        }
        private SingletonAtorLogado() { }
        public Ator Ator { get; set; }
    }
}
