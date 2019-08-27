using System;

namespace Consultorio.Model
{
    public class Log
    {
        public int Id { get; set; }
        public Ator Ator { get; set; }
        public DateTime Date { get; set; }

        public string ComoEra { get; set; }
        public string ComoFicou { get; set; }

        public Log()
        {
        }
    }
}
