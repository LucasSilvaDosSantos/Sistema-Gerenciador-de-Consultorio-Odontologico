using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Consultorio.Data
{
    class ConsultasData
    {
        public static List<Consulta> ListaDeConsultas(DateTime entrada)
        {
            List<Consulta> consultas = new List<Consulta>();
            try {              
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    consultas = ctx.Consultas.Where(a => a.Inicio.Day == entrada.Day && a.Inicio.Month == entrada.Month && a.Inicio.Year == entrada.Year).Include(c => c.Cliente).Include(p => p.Procedimento).ToList();
                    return consultas;
                }
            }catch (Exception)
            {
                return consultas;
            }
        }

        public static List<Procedimento> ListarTodosOsProcedimentos()
        {
            List<Procedimento> procedimentos = new List<Procedimento>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    procedimentos = ctx.Procedimentos.ToList();
                    return procedimentos;
                }
            }
            catch (Exception)
            {
                return procedimentos;
            }
        }

        public static string AlterarConsulta(Consulta entrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Consulta c = ctx.Consultas.Find(entrada.Id);

                    Cliente cliente = ctx.Clientes.Find(entrada.Cliente.Id);
                    c.Cliente = cliente;
                    c.Dente = entrada.Dente;
                    c.Inicio = entrada.Inicio;
                    c.Fim = entrada.Fim;
                    if (entrada.Procedimento != null)
                    {
                        Procedimento p = ctx.Procedimentos.Find(entrada.Procedimento.Id);
                        c.Procedimento = p;
                    }
                    c.Realizada = entrada.Realizada;

                    ctx.SaveChanges();

                    return ("Consulta alterada com sucesso");
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static Procedimento BuscarProcedimento(Procedimento entrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var p = ctx.Procedimentos.Find(entrada.Id);
                    
                    return p;
                }
            }
            catch (Exception)
            {
                Procedimento p = null;
                return p;
            }
        }

        public static List<Consulta> BuscarConsultas(DateTime data)
        {
            List<Consulta> consultas = new List<Consulta>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    consultas = ctx.Consultas.Where(a => a.Inicio.Day == data.Day && a.Inicio.Month == data.Month && a.Inicio.Year == data.Year).Include(c => c.Cliente).Include(p => p.Procedimento).ToList();
                    return consultas;                 
                }
            }
            catch (Exception)
            {
                return consultas;
            }
        }

        public static string SalvarNovaConsulta(Consulta c)
        {
            string msg;
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Cliente a = ctx.Clientes.Find(c.Cliente.Id);
                    Procedimento p = ctx.Procedimentos.Find(c.Procedimento.Id);

                    c.Cliente = a;
                    c.Procedimento = p;

                    ctx.Consultas.Add(c);
                    ctx.SaveChanges();
                    msg = "Salvo nova consulta";
                }
            }
            catch (Exception e)
            {
                msg = "Erro:" + e.Message;
            }
            return msg;
        }

    }
}
