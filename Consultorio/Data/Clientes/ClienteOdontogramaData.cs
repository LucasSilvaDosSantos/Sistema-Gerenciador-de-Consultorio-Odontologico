using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data.Clientes
{
    class ClienteOdontogramaData
    {
        public static Cliente CarregarOdontograma(int idCliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Cliente cliente = ctx.Clientes.Where(c => c.Id == idCliente).Include(b => b.Odontograma).FirstOrDefault();

                    return cliente;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string SalvarOdontograma(Cliente clienteEntrada, Odontograma odontogramaEntrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    string msg;
                    Cliente cliente = ctx.Clientes.Include(a => a.Odontograma).First(c => c.Id == clienteEntrada.Id);
                    if (cliente.Odontograma == null)
                    {                       
                        cliente.Odontograma = odontogramaEntrada;
                        msg = "Odontograma Cadastrado com Sucesso!";
                    }
                    else
                    {
                        cliente.Odontograma.Dente01 = odontogramaEntrada.Dente01;
                        cliente.Odontograma.Dente02 = odontogramaEntrada.Dente02;
                        cliente.Odontograma.Dente03 = odontogramaEntrada.Dente03;
                        cliente.Odontograma.Dente04 = odontogramaEntrada.Dente04;
                        cliente.Odontograma.Dente05 = odontogramaEntrada.Dente05;
                        cliente.Odontograma.Dente06 = odontogramaEntrada.Dente06;
                        cliente.Odontograma.Dente07 = odontogramaEntrada.Dente07;
                        cliente.Odontograma.Dente08 = odontogramaEntrada.Dente08;
                        cliente.Odontograma.Dente09 = odontogramaEntrada.Dente09;
                        cliente.Odontograma.Dente10 = odontogramaEntrada.Dente10;
                        cliente.Odontograma.Dente11 = odontogramaEntrada.Dente11;
                        cliente.Odontograma.Dente12 = odontogramaEntrada.Dente12;
                        cliente.Odontograma.Dente13 = odontogramaEntrada.Dente13;
                        cliente.Odontograma.Dente14 = odontogramaEntrada.Dente14;
                        cliente.Odontograma.Dente15 = odontogramaEntrada.Dente15;
                        cliente.Odontograma.Dente16 = odontogramaEntrada.Dente16;

                        cliente.Odontograma.Dente17 = odontogramaEntrada.Dente17;
                        cliente.Odontograma.Dente18 = odontogramaEntrada.Dente18;
                        cliente.Odontograma.Dente19 = odontogramaEntrada.Dente19;
                        cliente.Odontograma.Dente20 = odontogramaEntrada.Dente20;
                        cliente.Odontograma.Dente21 = odontogramaEntrada.Dente21;
                        cliente.Odontograma.Dente22 = odontogramaEntrada.Dente22;
                        cliente.Odontograma.Dente23 = odontogramaEntrada.Dente23;
                        cliente.Odontograma.Dente24 = odontogramaEntrada.Dente24;
                        cliente.Odontograma.Dente25 = odontogramaEntrada.Dente25;
                        cliente.Odontograma.Dente26 = odontogramaEntrada.Dente26;
                        cliente.Odontograma.Dente27 = odontogramaEntrada.Dente27;
                        cliente.Odontograma.Dente28 = odontogramaEntrada.Dente28;
                        cliente.Odontograma.Dente29 = odontogramaEntrada.Dente29;
                        cliente.Odontograma.Dente30 = odontogramaEntrada.Dente30;
                        cliente.Odontograma.Dente31 = odontogramaEntrada.Dente31;
                        cliente.Odontograma.Dente32 = odontogramaEntrada.Dente32;
                        msg = "Odontograma Modificado com Sucesso!";
                    }
                    ctx.SaveChanges();
                    return msg;
                }
            }catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
