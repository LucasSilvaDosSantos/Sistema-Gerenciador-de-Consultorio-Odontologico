using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Consultorio.ViewModel.Atores;
using Consultorio.Model.Enums;

namespace Consultorio.Data.Consultas
{
    class ConsultasData
    {
        public static List<Consulta> ListaDeConsultas(DateTime entrada)
        {
            List<Consulta> consultas = new List<Consulta>();
            try {              
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    consultas = ctx.Consultas.Where(a => a.Inicio.Day == entrada.Day && a.Inicio.Month == entrada.Month && a.Inicio.Year == entrada.Year).Include(c => c.Cliente).Include(p => p.Procedimento).OrderBy(c => c.Inicio).ToList();
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

        public static string EditarConsulta(Consulta entrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {

                    ctx.Entry(entrada).State = EntityState.Modified;
                    ctx.SaveChanges();

                    EditarProcedimentoDaConsulta(entrada);

                    return ("Consulta Atualizada!");
                }
            }
            catch (Exception e)
            {
                return ("Erro: " + e.Message);
            }
        }

        //usado apenas para atualizar a o procedimento da consulta, feito assim pois colocando no mesmo metodo ou nao atualiza os atributos base ou nao atualiza o procedimento
        private static void EditarProcedimentoDaConsulta(Consulta entrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var procedimento = ctx.Procedimentos.Find(entrada.Procedimento.Id);
                    var consulta = ctx.Consultas.Find(entrada.Id);

                    consulta.Procedimento = procedimento;

                    ctx.Entry(consulta).State = EntityState.Modified;

                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

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
                    msg = "Salva nova consulta";
                }
            }
            catch
            {
                msg = "Ocorreu um Erro e a consulta NÂO pode ser salva!";
            }
            return msg;
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

        public static Cliente BuscarClientePorId(int entrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var c = ctx.Clientes.Find(entrada);

                    return c;
                }
            }
            catch (Exception)
            {
                Cliente c = null;
                return c;
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

        public static Consulta SelecionarConsulta(int id)
        {
            Consulta c = new Consulta();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    //c = ctx.Consultas.Find(id);
                    c = ctx.Consultas.Include(a => a.Cliente).Include(b => b.Procedimento).Include(e => e.Procedimento.Produtos).SingleOrDefault(d => d.Id == id);
                    return c;
                }
            }
            catch (Exception)
            {
                return c;
            }
        }

        public static List<Consulta> BuscarConsultaPorClienteId(int id)
        {
            List<Consulta> consultas = new List<Consulta>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    consultas = ctx.Consultas.Include(a => a.Cliente).Include(b => b.Procedimento).Where(a => a.Cliente.Id == id).OrderBy(c => c.Inicio).ToList();
                    return consultas;
                }
            }
            catch (Exception)
            {
                return consultas;
            }
        }

        public static List<Consulta> BuscarConsultaPorClienteNome(string nome)
        {
            List<Consulta> consultas = new List<Consulta>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    string var = nome;
                    consultas = ctx.Consultas.Include(a => a.Cliente).Include(b => b.Procedimento).Where(c => c.Cliente.Nome.Contains(nome)).OrderBy(c => c.Inicio).ToList();

                    return consultas;
                }
            }
            catch (Exception)
            {
                return consultas;
            }
        }

        public static bool SalvarInicioDaConsulta(Consulta consultaEntrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Ator atorLogado = ctx.Atores.Find(SingletonAtorLogado.Instancia.Ator.Id);

                    consultaEntrada.Inicio = DateTime.Now;
                    consultaEntrada.Status = StatusConsulta.Iniciada;
                    consultaEntrada.QuemRealizou = atorLogado;
                    ctx.Entry(consultaEntrada).State = EntityState.Modified;

                    //Log 
                    var log = new Log();
                    log.Ator = atorLogado;
                    log.ComoEra = "Nova Entrada";
                    log.ComoFicou = $"Consulta Id:{consultaEntrada.Id}, Consulta iniciada em:{consultaEntrada.Inicio}";
                    log.Date = DateTime.Now;
                    
                    ctx.Logs.Add(log);
                    //Fim log

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool SalvarStatusDeConsulta(Consulta consultaEntrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Ator atorLogado = ctx.Atores.Find(SingletonAtorLogado.Instancia.Ator.Id);

                    consultaEntrada.QuemRealizou = atorLogado;
                    ctx.Entry(consultaEntrada).State = EntityState.Modified;

                    //Log 
                    var log = new Log();
                    log.Ator = atorLogado;
                    log.ComoEra = "Nova Entrada";
                    log.ComoFicou = $"Consulta Id:{consultaEntrada.Id}, Consulta status em:{consultaEntrada.Status}";
                    log.Date = DateTime.Now;

                    ctx.Logs.Add(log);
                    //Fim log

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Consulta> BuscarConsultaPorPeriodo(DateTime inicio, DateTime fim)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    fim = fim.AddDays(1);
                    var lista = ctx.Consultas.Where(a => (a.Inicio >= inicio && a.Fim <= fim)).Include(c => c.Cliente).Include(p => p.Procedimento).Include(m => m.QuemRealizou).ToList();

                    return lista;
                }
            }
            catch
            {
                return new List<Consulta>();
            }
        }

        public static void SalvarLogDeAtestadosGerados(Dictionary<string, string> dicionario)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var log = new Log();
                    var ator = ctx.Atores.Find(SingletonAtorLogado.Instancia.Ator.Id);
                    log.Ator = ator;
                    log.Date = DateTime.Now;
                    log.ComoEra = ("Atestado");
                    log.ComoFicou = ($"IdCliente={dicionario["Id"]}, " +
                        $"FinalidadeDoAtestado={dicionario["Finalidade"]}, " +
                        $"Comparecimento={dicionario["Inicio"]} até {dicionario["Fim"]}, " +
                        $"Dia={dicionario["Data"]}, " +
                        $"DiasAfastamento{dicionario["AfastamentoDias"]}, " +
                        $"CID={dicionario["Cid"]}");
                    ctx.Logs.Add(log);
                    ctx.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
