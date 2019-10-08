using Consultorio.Data.Consultas;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;

namespace Consultorio.ViewModel.Relatorios
{
    public class RelatorioReceitaMedicaViewModel
    {
        public Ator AtorLogado { get; set; } = SingletonAtorLogado.Instancia.Ator;

        public void SalvarLogAnotacoes(string anotacoes)
        {
            ConsultasData.GerarLogDeReceituario(anotacoes);
        }
    }
}
