using Consultorio.Model;
using Consultorio.ViewModel.Atores;

namespace Consultorio.ViewModel.Relatorios
{
    public class RelatoriosViewModel
    {
        public Ator AtorLogado { get; set; } = SingletonAtorLogado.Instancia.Ator;

        public RelatoriosViewModel()
        {

        }
    }
}
