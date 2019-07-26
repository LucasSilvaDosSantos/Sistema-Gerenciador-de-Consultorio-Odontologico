using Consultorio.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace Consultorio.Data.Clientes
{
    class CadastroDeClienteAnamneseData
    {
        public static string CadastrarOuAlterarAnamnese(Cliente clienteEntrada, Anamnese anamneseEntrada) {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    string msg;
                    Cliente cliente = ctx.Clientes.Include(c => c.Anamnese).FirstOrDefault(c => c.Id == clienteEntrada.Id);
                    if (cliente.Anamnese == null)
                    {
                        cliente.Anamnese = anamneseEntrada;
                        msg = "Anamnese Adicionada!";
                    }
                    else
                    {
                        Anamnese anamneseFind = ctx.Anamneses.Find(cliente.Anamnese.Id);
                                               
                        /* altera a anamnese */
                        anamneseFind.P01 = anamneseEntrada.P01;
                        anamneseFind.P02 = anamneseEntrada.P02;
                        anamneseFind.P03 = anamneseEntrada.P03;
                        anamneseFind.P04 = anamneseEntrada.P04;
                        anamneseFind.P05 = anamneseEntrada.P05;
                        anamneseFind.P06 = anamneseEntrada.P06;
                        anamneseFind.P07 = anamneseEntrada.P07;
                        anamneseFind.P08 = anamneseEntrada.P08;
                        anamneseFind.P09 = anamneseEntrada.P09;
                        anamneseFind.P10 = anamneseEntrada.P10;
                        anamneseFind.P11 = anamneseEntrada.P11;
                        anamneseFind.P12 = anamneseEntrada.P12;
                        anamneseFind.P13 = anamneseEntrada.P13;
                        anamneseFind.P14 = anamneseEntrada.P14;
                        anamneseFind.P15 = anamneseEntrada.P15;
                        anamneseFind.P16 = anamneseEntrada.P16;
                        anamneseFind.P17 = anamneseEntrada.P17;
                        anamneseFind.P18 = anamneseEntrada.P18;
                        anamneseFind.P19 = anamneseEntrada.P19;
                        anamneseFind.P20 = anamneseEntrada.P20;
                        anamneseFind.P21 = anamneseEntrada.P21;
                        anamneseFind.P22 = anamneseEntrada.P22;
                        anamneseFind.P23 = anamneseEntrada.P23;
                        anamneseFind.P24 = anamneseEntrada.P24;
                        anamneseFind.P25 = anamneseEntrada.P25;
                        anamneseFind.P26 = anamneseEntrada.P26;
                        anamneseFind.P27 = anamneseEntrada.P27;
                        anamneseFind.Obs = anamneseEntrada.Obs;
                        anamneseFind.P01ComplementoPq = anamneseEntrada.P01ComplementoPq;
                        anamneseFind.P01ComplementoTel = anamneseEntrada.P01ComplementoTel;
                        anamneseFind.P02Complemento = anamneseEntrada.P02Complemento;
                        anamneseFind.P03Complemento = anamneseEntrada.P03Complemento;
                        anamneseFind.P04Complemento = anamneseEntrada.P04Complemento;
                        anamneseFind.P05Complemento = anamneseEntrada.P05Complemento;
                        anamneseFind.P09Complemento = anamneseEntrada.P09Complemento;
                        anamneseFind.P17Complemento = anamneseEntrada.P17Complemento;
                        /**/

                        msg = "Anamnese Alterada!";
                    }               

                    ctx.SaveChanges();
                    return msg;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public static Anamnese CarregarAnamnese(Cliente clienteEntrada)
        {
            try
            {
                using(ConsultorioContext ctx = new ConsultorioContext())
                {
                    var cliente = ctx.Clientes.Where(c => c.Id == clienteEntrada.Id).Include(b => b.Anamnese).FirstOrDefault();
                    
                    Anamnese anamnese = cliente.Anamnese;

                    return anamnese;
                }
            }
            catch (Exception)
            {
                Anamnese anamnese = new Anamnese();
                return anamnese;
            }           
        }
    }
}
