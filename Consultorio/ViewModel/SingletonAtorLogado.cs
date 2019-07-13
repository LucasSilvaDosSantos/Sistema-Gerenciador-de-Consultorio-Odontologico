using Consultorio.Model;

namespace Consultorio.ViewModel
{
    public sealed class SingletonAtorLogado
    {
        static SingletonAtorLogado _instancia;
        public static SingletonAtorLogado Instancia
        {
            get { return _instancia ?? (_instancia = new SingletonAtorLogado()); }
        }
        private SingletonAtorLogado() { }
        public Atores Ator { get; set; }
    }
}
