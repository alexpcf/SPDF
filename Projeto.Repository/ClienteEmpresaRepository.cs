using Dapper;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository
{
   public class ClienteEmpresaRepository : Conexao
    {
        //atributo para armazenar a connectionstring
        private string connectionString = ConfigurationManager
                            .ConnectionStrings["aula"].ConnectionString;

        //método para inserir um usuario no banco de dados
        public void Insert(ClienteEmpresa Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "insert into ClienteEmpresa(NomeClienteEmpresa, Cnpj, DataNascimento,Sexo,Telefone,Endereco,Cidade, Cep, Numero, Email, Senha, DataCriacao) "
                             + "values(@NomeClienteEmpresa,@Cnpj,@DataNascimento,@Sexo,@Telefone,@Endereco,@Cidade,@Cep, @Numero, @Email, @Senha, GetDate())";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para atualizar um usuario no banco de dados
        public void Update(ClienteEmpresa Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "update ClienteEmpresa set NomeClienteEmpresa = @NomeClienteEmpresa, Email = @Email, Cnpj = @Cnpj,Telefone=@Telefone  "
                             + "where IdClienteCnpj = @IdClienteCnpj";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para excluir um usuario no banco de dados
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "delete from ClienteEmpresa where IdClienteCnpj = @IdClienteCnpj";

                con.Execute(query, new { IdClienteCnpj = id });
            }
        }

        //método para consultar todos os usuarios no banco de dados
        public List<ClienteEmpresa> FindAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from ClienteEmpresa";

                return con.Query<ClienteEmpresa>(query)
                            .ToList();
            }
        }

        //método para retornar 1 usuario pelo id no banco de dados
        public ClienteEmpresa  FindById(int idClienteCnpj)
        {
            OpenConnection();
            //comando SQL que será executado no banco de dados
            string query = "select * from ClienteEmpresa where IdClienteCnpj = @IdClienteCnpj";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdClienteCnpj", idClienteCnpj);
            dr = cmd.ExecuteReader();

            ClienteEmpresa c = null; //sem espaço de memória

            if (dr.Read()) //se algum registro foi encontrado..
            {
                c = new ClienteEmpresa(); //instanciando..

                c.IdClienteCnpj = Convert.ToInt32(dr["IdClienteCnpj"]);
                c.Cnpj = Convert.ToString(dr["Cnpj"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Telefone = Convert.ToString(dr["Telefone"]);
                c.NomeClienteEmpresa = Convert.ToString(dr["NomeClienteEmpresa"]);


            }
            CloseConnection();
            return c; //retornar o cliente
        }

        //método para retornar 1 usuario pelo email e senha
        public ClienteEmpresa Find(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from ClienteEmpresa where Email = @Email and Senha = @Senha";

                return con.Query<ClienteEmpresa>(query,
                        new { Email = email, Senha = senha })
                            .FirstOrDefault();
            }
        }

        //método booleano para verificar se um email ja esta cadastrado na tabela
        public bool HasEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select count(Email) from ClienteEmpresa where Email = @Email";

                return con.Query<int>(query,
                        new { Email = email })
                        .FirstOrDefault() > 0;
            }
        }
    }
}

