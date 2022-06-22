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
    public class QuestionarioRepository : Conexao
    {

        //atributo para armazenar a connectionstring
        private string connectionString = ConfigurationManager
                            .ConnectionStrings["aula"].ConnectionString;

        //método para inserir um usuario no banco de dados
        public void Insert(Questionario Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "insert into Questionario(Cpf, Email, DataCriacao,Questao1,Questao2,Questao3,Questao4, Questao5, Questao6, Questao7) "
                             + "values(@Cpf,@Email,GetDate(),@Questao1,@Questao2,@Questao3,@Questao4,@Questao5, @Questao6, @Questao7)";

                con.Execute(query, Ce); //executando..
            }
        }

        public Questionario FindAll2()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select count(questao1) from questionario where questao1 = 1");
                //comando SQL que será executado no banco de dados
                //string query = "select cf.NomeClienteCpf,Cf.Email,qe.cpf,qe.DataCriacao , case when  qe.questao1=1 then 'Ruim' when qe.questao1=2 then 'Razoável' when qe.questao1=3 then 'Bom' when qe.questao1=4 then 'Muito Bom' when qe.questao1=5 then 'Excelente'when qe.questao1=6 then 'Excelente' end questao1,qe.questao2,qe.questao3,qe.questao4,qe.questao5,qe.questao6,qe.questao7 from clienteCpf Cf join questionario qe on qe.Cpf = Cf.Cpf order by cf.IdClienteCpf desc";

                return con.Query<Questionario>(Convert.ToString(sb))
                            .FirstOrDefault();
            }
        }


        public bool HasEmail(string questao1)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select count(questao1) from questionario where questao1 = 1";

                return con.Query<int>(query
                        )
                        .FirstOrDefault() > 0;
            }
        }

        //método para atualizar um usuario no banco de dados
        public void Update(Questionario Ce)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "update Questionario set Email = @Email, Cpf = @Cpf "
                             + "where IdClienteQuestionario = @IdClienteQuestionario";

                con.Execute(query, Ce); //executando..
            }
        }

        //método para excluir um usuario no banco de dados
        public void Delete(int idClienteQuestionario)
        {
            OpenConnection();

            string query = "delete from Questionario where IdClienteQuestionario = @IdClienteQuestionario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idClienteQuestionario", idClienteQuestionario);
            cmd.ExecuteNonQuery(); //executar

            CloseConnection();
        }

        //método para consultar todos os usuarios no banco de dados
        public List<Questionario> FindAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select qe.IdClienteQuestionario, cf.NomeClienteCpf,Cf.Email,qe.cpf,qe.DataCriacao,");
                sb.AppendLine("case when  qe.questao1=1 then 'Ruim' when qe.questao1=2 then 'Razoável' when qe.questao1=3 then 'Bom' when qe.questao1=4 then 'Muito Bom' when qe.questao1=5 then 'Excelente'  end questao1,");
                sb.AppendLine("case when  qe.questao2=1 then 'Ruim' when qe.questao2=2 then 'Razoável' when qe.questao2=3 then 'Bom' when qe.questao2=4 then 'Muito Bom' when qe.questao2=5 then 'Excelente'  end questao2,");
                sb.AppendLine("case when  qe.questao3=1 then 'Ruim' when qe.questao3=2 then 'Razoável' when qe.questao3=3 then 'Bom' when qe.questao3=4 then 'Muito Bom' when qe.questao3=5 then 'Excelente'  end questao3,");
                sb.AppendLine("case when  qe.questao4=1 then 'Ruim' when qe.questao4=2 then 'Razoável' when qe.questao4=3 then 'Bom' when qe.questao4=4 then 'Muito Bom' when qe.questao4=5 then 'Excelente'  end questao4,");
                sb.AppendLine("case when  qe.questao5=1 then 'Ruim' when qe.questao5=2 then 'Razoável' when qe.questao5=3 then 'Bom' when qe.questao5=4 then 'Muito Bom' when qe.questao5=5 then 'Excelente'  end questao5,");
                sb.AppendLine("case when  qe.questao6=1 then 'Ruim' when qe.questao6=2 then 'Razoável' when qe.questao6=3 then 'Bom' when qe.questao6=4 then 'Muito Bom' when qe.questao6=5 then 'Excelente'  end questao6,");
                sb.AppendLine("qe.questao7 from clienteCpf Cf join questionario qe on qe.Cpf = Cf.Cpf order by cf.IdClienteCpf desc");
                //comando SQL que será executado no banco de dados
                //string query = "select cf.NomeClienteCpf,Cf.Email,qe.cpf,qe.DataCriacao , case when  qe.questao1=1 then 'Ruim' when qe.questao1=2 then 'Razoável' when qe.questao1=3 then 'Bom' when qe.questao1=4 then 'Muito Bom' when qe.questao1=5 then 'Excelente'when qe.questao1=6 then 'Excelente' end questao1,qe.questao2,qe.questao3,qe.questao4,qe.questao5,qe.questao6,qe.questao7 from clienteCpf Cf join questionario qe on qe.Cpf = Cf.Cpf order by cf.IdClienteCpf desc";
                return con.Query<Questionario>(Convert.ToString(sb))
                           .ToList();
                //return con.Query<Questionario>(query)
                //            .ToList();
            }
        }

        //método para retornar 1 usuario pelo id no banco de dados
        public Questionario FindById(int idClienteQuestionario)
        {

            OpenConnection();
            //comando SQL que será executado no banco de dados
            string query = "select * from Questionario where IdClienteQuestionario = @IdClienteQuestionario";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdClienteQuestionario", idClienteQuestionario);
            dr = cmd.ExecuteReader();

            Questionario c = null; //sem espaço de memória

            if (dr.Read()) //se algum registro foi encontrado..
            {
                c = new Questionario(); //instanciando..

                c.IdClienteQuestionario = Convert.ToInt32(dr["IdClienteQuestionario"]);
                c.Cpf = Convert.ToString(dr["Cpf"]);
                c.Email = Convert.ToString(dr["Email"]);


            }
            CloseConnection();
            return c; //retornar o cliente
        }

        //método para retornar 1 usuario pelo email e senha
        public Questionario Find(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from Questionario where Email = @Email and Senha = @Senha";

                return con.Query<Questionario>(query,
                        new { Email = email, Senha = senha })
                            .FirstOrDefault();
            }
        }


    }
}

