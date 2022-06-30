using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
   public class Contato
    {

        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; }

        public Contato()
        {
            //vazio
        }

        public Contato(int idContato, string nome, string email, string mensagem, DateTime dataCriacao)
        {
            IdContato = idContato;
            Nome = nome;
            Email = email;
            Mensagem = mensagem;
            DataCriacao = dataCriacao;
        }


        public override string ToString()
        {
            return $"Id: {IdContato}, Nome: {Nome}, Email: {Email},Mensagem:`{Mensagem}, Data de Criação: {DataCriacao}";
        }

    }
}
