using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data
{
    class SecretariaData
    {
        public static string CadastroDeNovaSecretaria(Secretaria secretaria)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    secretaria.Senha = AtoresData.GerarHashMd5(secretaria.Senha);
                    ctx.Secretarias.Add(secretaria);
                    ctx.SaveChanges();
                    return ("Salva nova Secretária!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }

        public static string AlterarSecretaria(Secretaria secretaria)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Secretaria s = ctx.Secretarias.Find(secretaria.Id);

                    s.Nome = secretaria.Nome;
                    s.Email = secretaria.Email;
                    s.Telefone1 = secretaria.Telefone1;
                    s.Telefone2 = secretaria.Telefone2;
                    s.Crosp = secretaria.Crosp;
                    s.Login = secretaria.Login;
                    secretaria.Senha = AtoresData.GerarHashMd5(secretaria.Senha);
                    s.Senha = secretaria.Senha;
                    s.CrudClientes = secretaria.CrudClientes;
                    s.CrudSecretarias = secretaria.CrudSecretarias;
                    s.CrudProdutos = secretaria.CrudProdutos;
                    s.CrudGestoresDeEstoque = secretaria.CrudGestoresDeEstoque;

                    ctx.Entry(s).State = EntityState.Modified;

                    ctx.SaveChanges();
                    return ("Salvo alterações na secretária!");
                }
            }
            catch (Exception e)
            {
                return ("error" + e.Message);
            }
        }
    }
}
