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
   public class EnvioEmailCpfRepository
    {

        //atributo para armazenar a connectionstring
        private string connectionString = ConfigurationManager
                            .ConnectionStrings["aula"].ConnectionString;

        //método para inserir um usuario no banco de dados
        public void Insert(LogEnvioClienteCpf Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "insert into LogEnvioClienteCpf(IdEnvio, Email, DataCriacao) "
                             + "values(@IdEnvio, @Email, GetDate())";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para atualizar um usuario no banco de dados
        public void Update(LogEnvioClienteCpf Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "update LogEnvioClienteCpf set Nome = @Nome, Email = @Email, Senha = @Senha "
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
                string query = "delete from LogEnvioClienteCpf where IdClienteCnpj = @IdClienteCnpj";

                con.Execute(query, new { IdClienteCnpj = id });
            }
        }

        //método para consultar todos os usuarios no banco de dados
        public List<LogEnvioClienteCpf> FindAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from LogEnvioClienteCpf";

                return con.Query<LogEnvioClienteCpf>(query)
                            .ToList();
            }
        }

        //método para retornar 1 usuario pelo id no banco de dados
        public LogEnvioClienteCpf FindById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from ClienteEmpresa where IdClienteCnpj = @IdClienteCnpj";

                return con.Query<LogEnvioClienteCpf>(query,
                        new { IdClienteCnpj = id })
                            .FirstOrDefault();
            }
        }

        //método para retornar 1 usuario pelo email e senha
        public LogEnvioClienteCpf Find(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from LogEnvioClienteCpf where Email = @Email and Senha = @Senha";

                return con.Query<LogEnvioClienteCpf>(query,
                        new { Email = email, Senha = senha })
                            .FirstOrDefault();
            }
        }

        //método booleano para verificar se um email ja esta cadastrado na tabela
        public bool HasEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select count(Email) from LogEnvioClienteCpf where Email = @Email";

                return con.Query<int>(query,
                        new { Email = email })
                        .FirstOrDefault() > 0;
            }
        }
    }
}
