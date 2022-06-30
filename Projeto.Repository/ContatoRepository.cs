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
   public class ContatoRepository:Conexao
    {


        //atributo para armazenar a connectionstring
        private string connectionString = ConfigurationManager
                            .ConnectionStrings["aula"].ConnectionString;

        //método para inserir um usuario no banco de dados
        public void Insert(Contato Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "insert into Contato(Nome, Email,Mensagem, DataCriacao) "
                             + "values(@Nome,@Email,@Mensagem,GetDate())";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para atualizar um usuario no banco de dados
        public void Update(Contato Ce)
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
                string query = "delete from Contato where IdClienteCpf = @IdClienteCpf";

                con.Execute(query, new { IdClienteCnpj = id });
            }
        }

        //método para consultar todos os usuarios no banco de dados
        public List<Contato> FindAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from Contato";

                return con.Query<Contato>(query)
                            .ToList();
            }
        }

        //método para retornar 1 usuario pelo id no banco de dados
        public Contato FindById(int idClienteCpf)
        {
            using (SqlConnection con = new SqlConnection(connectionString))

                OpenConnection();
            //comando SQL que será executado no banco de dados
            string query = "select * from ClienteCpf where IdClienteCpf = @IdClienteCpf";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdClienteCpf", idClienteCpf);
            dr = cmd.ExecuteReader();

            Contato c = null; //sem espaço de memória

            if (dr.Read()) //se algum registro foi encontrado..
            {
                c = new Contato(); //instanciando..

                c.IdContato = Convert.ToInt32(dr["IdClienteCpf"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Mensagem = Convert.ToString(dr["Estado"]);
                //c.DataCriacao = Convert.ToString(dr["NomeClienteCpf"]);


            }
            CloseConnection();
            return c; //retornar o cliente
        }

        //método para retornar 1 usuario pelo email e senha
        public Contato Find(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from ClienteCpf where Email = @Email and Senha = @Senha";

                return con.Query<Contato>(query,
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

