using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository
{
   

        public class Conexao
        {
            //atributos
            protected SqlConnection con;
            protected SqlCommand cmd;
            protected SqlDataReader dr;
            protected SqlTransaction tr;

            //método para abrir conexão com o banco
            protected void OpenConnection()
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["aula"].ConnectionString);
                con.Open(); //conectado!
            }

            //método para fechar conexão com o banco
            protected void CloseConnection()
            {
                con.Close(); //desconectado!
            }
        }
}
