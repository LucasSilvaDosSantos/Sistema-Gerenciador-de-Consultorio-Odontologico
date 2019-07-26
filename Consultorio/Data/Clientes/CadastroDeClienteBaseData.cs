using Consultorio.Model;
using System;

namespace Consultorio.Data.Clientes
{
    class CadastroDeClienteBaseData
    {
        //Cadastrar Novo Cliente
        public static string CadastroDeNovoCliente(Cliente cliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Clientes.Add(cliente);
                    ctx.SaveChanges();
                    return "Novo Cliente Salvo!";
                }
            }
            catch (Exception e){
                return(e.Message);
            }
        }

        //arrumr codigo de salvar clientes novos e altaraçoes 
        //Altarar Cliente Existente
        public static string AlterarCliente(Cliente cliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Cliente c = ctx.Clientes.Find(cliente.Id);
                  
                    c.Nome = cliente.Nome;
                    c.Nascimento = cliente.Nascimento;
                    c.Cpf = cliente.Cpf;                   
                    c.Rg = cliente.Rg;
                    c.Email = cliente.Email;
                    c.Telefone1 = cliente.Telefone1;
                    c.Telefone2 = cliente.Telefone2;
                    c.Endereco = cliente.Endereco;
                    c.Bairro = cliente.Bairro;
                    c.Uf = cliente.Uf;
                    c.Cidade = cliente.Cidade;
                    c.Cep = cliente.Cep;                   
                    c.Obs = cliente.Obs;

                    ctx.SaveChanges();
                    return "Cliente Alterado!";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
