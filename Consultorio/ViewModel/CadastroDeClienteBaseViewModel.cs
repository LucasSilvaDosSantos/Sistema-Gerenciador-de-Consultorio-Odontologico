using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class CadastroDeClienteBaseViewModel
    {
        //Cadastrar Novo Cliente
        public static void CadastroDeNovoCliente(Cliente cliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Clientes.Add(cliente);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        //arrumr codigo de salvar clientes novos e altaraçoes 
        //Altarar Cliente Existente
        public static void AlterarCliente(Cliente cliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Cliente c = ctx.Clientes.Find(cliente.Id);

                    c.Nome = cliente.Nome;
                    c.Nascimento = cliente.Nascimento;
                    c.Obs = cliente.Obs;
                    c.Rg = cliente.Rg;
                    c.Telefone1 = cliente.Telefone1;
                    c.Telefone2 = cliente.Telefone2;
                    c.Uf = cliente.Uf;
                    c.Endereco = cliente.Endereco;
                    c.Email = cliente.Email;
                    c.Cpf = cliente.Cpf;
                    c.Cidade = cliente.Cidade;
                    c.Cep = cliente.Cep;
                    c.Bairro = cliente.Bairro;

                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
