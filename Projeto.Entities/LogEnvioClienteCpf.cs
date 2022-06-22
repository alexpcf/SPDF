using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class LogEnvioClienteCpf
    {
       
        public int IdLogEnvio { get; set; }
        public int IdEnvio{ get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }

        public LogEnvioClienteCpf()
        {
            //vazio
        }

        public LogEnvioClienteCpf(int idLogEnvio, int idEnvio, string email, DateTime dataCriacao)
        {
            IdLogEnvio = idLogEnvio;
            IdEnvio = idEnvio;
            Email = email;
            DataCriacao = dataCriacao;
        }
        public override string ToString()
        {
            return $"Id: {IdLogEnvio}, IdEnvio: {IdEnvio}, Email: {Email}, Data de Criação: {DataCriacao}";
        }
    }
}
