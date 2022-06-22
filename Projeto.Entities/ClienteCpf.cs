using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class ClienteCpf
    {

        public int IdClienteCpf { get; set; }
        public string NomeClienteCpf { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriacao { get; set; }

        public ClienteCpf()
        {
            //vazio
        }
        public ClienteCpf(int idClienteCpf, string nomeClienteCpf, string email, string estado, string cpf, DateTime dataCriacao)
        {
            IdClienteCpf = idClienteCpf;
            NomeClienteCpf = nomeClienteCpf;
            Email = email;
            Estado = estado;
            Cpf = cpf;
            DataCriacao = dataCriacao;
        }
        public override string ToString()
        {
            return $"Id: {IdClienteCpf}, Nome: {NomeClienteCpf}, Email: {Email},Estado: {Estado},Cpf: {Cpf}, Data de Criação: {DataCriacao}";
        }


    }
}
