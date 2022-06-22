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
   public class ClienteCpfRepository : Conexao
    {
    
        //atributo para armazenar a connectionstring
        private string connectionString = ConfigurationManager
                            .ConnectionStrings["aula"].ConnectionString;

        //método para inserir um usuario no banco de dados
        public void Insert(ClienteCpf Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "insert into ClienteCpf(NomeClienteEmpresa, Cnpj, DataNascimento,Sexo,Telefone,Endereco,Cidade, Cep, Numero, Email, Senha, DataCriacao) "
                             + "values(@NomeClienteEmpresa,@Cnpj,@DataNascimento,@Sexo,@Telefone,@Endereco,@Cidade,@Cep, @Numero, @Email, @Senha, GetDate())";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para atualizar um usuario no banco de dados
        public void Update(ClienteCpf Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "update ClienteCpf set NomeClienteCpf = @NomeClienteCpf, Email = @Email, Cpf = @Cpf, @Estado=Estado "
                             + "where IdClienteCpf = @IdClienteCpf";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para excluir um usuario no banco de dados
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "delete from ClienteCpf where IdClienteCpf = @IdClienteCpf";

                con.Execute(query, new { IdClienteCnpj = id });
            }
        }

        //método para consultar todos os usuarios no banco de dados
        public List<ClienteCpf> FindAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from ClienteCpf";

                return con.Query<ClienteCpf>(query)
                            .ToList();
            }
        }

        //método para retornar 1 usuario pelo id no banco de dados
        public ClienteCpf FindById(int idClienteCpf)
        {
            using (SqlConnection con = new SqlConnection(connectionString))

                OpenConnection();
            //comando SQL que será executado no banco de dados
            string query = "select * from ClienteCpf where IdClienteCpf = @IdClienteCpf";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdClienteCpf", idClienteCpf);
            dr = cmd.ExecuteReader();

            ClienteCpf c = null; //sem espaço de memória

            if (dr.Read()) //se algum registro foi encontrado..
            {
                c = new ClienteCpf(); //instanciando..

                c.IdClienteCpf = Convert.ToInt32(dr["IdClienteCpf"]);
                c.Cpf = Convert.ToString(dr["Cpf"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Estado = Convert.ToString(dr["Estado"]);
                c.NomeClienteCpf = Convert.ToString(dr["NomeClienteCpf"]);


            }
            CloseConnection();
            return c; //retornar o cliente
        }

        //método para retornar 1 usuario pelo email e senha
        public ClienteCpf Find(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from ClienteCpf where Email = @Email and Senha = @Senha";

                return con.Query<ClienteCpf>(query,
                        new { Email = email, Senha = senha })
                            .FirstOrDefault();
            }
        }

        //método booleano para verificar se um email ja esta cadastrado na tabela
        public bool HasEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select count(Email) from ClienteCpf where Email = @Email";

                return con.Query<int>(query,
                        new { Email = email })
                        .FirstOrDefault() > 0;
            }
        }
    }
}
