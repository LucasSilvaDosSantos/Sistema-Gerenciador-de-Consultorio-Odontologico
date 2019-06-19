using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch (Exception e)
            {
                msg = "Erro:" + e.Message;
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
                    c = ctx.Consultas.Include(a => a.Cliente).Include(b => b.Procedimento).SingleOrDefault(d => d.Id == id);
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
                    //string var = "teste";
                    consultas = ctx.Consultas.Include(a => a.Cliente).Include(b => b.Procedimento).Where(a => a.Id == id).ToList();

                    /*consultas = ctx.Consultas.Include(d => d.Cliente).Where(d => d.Cliente.Id == id).ToList();*/
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
                    consultas = ctx.Consultas.Include(a => a.Cliente).Include(b => b.Procedimento).Where(c => c.Cliente.Nome.Contains(nome)).ToList();

                    /*consultas = ctx.Consultas.Include(d => d.Cliente).Where(d => d.Cliente.Id == id).ToList();*/
                    return consultas;
                }
            }
            catch (Exception)
            {
                return consultas;
            }
        }
    }
}
