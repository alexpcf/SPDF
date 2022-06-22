using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class ClienteEmpresa
    {



        public int IdClienteCnpj { get; set; }
        public string NomeClienteEmpresa { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        public ClienteEmpresa()
        {
            //vazio
        }

        public ClienteEmpresa(int idClienteCnpj, string nomeClienteEmpresa, string cnpj, DateTime dataNascimento, string sexo, string telefone, string email, string endereco, string cidade, string cep, string senha, string numero, DateTime dataCriacao)
        {
            IdClienteCnpj = idClienteCnpj;
            NomeClienteEmpresa = nomeClienteEmpresa;
            Cnpj = cnpj;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Cidade = cidade;
            Cep = cep;
            Senha = senha;
            this.Numero = numero;
            DataCriacao = dataCriacao;
        }

        public override string ToString()
        {
            return $"Id: {IdClienteCnpj}, Nome: {NomeClienteEmpresa}, Email: {Email}, Data de Nascimento: {DataNascimento},Cnpj: {Cnpj},Sexo: {Sexo}, Telefone: {Telefone},Email: {Email},Endereço: {Endereco},Cidade: {Cidade}, Cep: {Cep},Senha: {Senha}, Numero: {Numero}, Data de Criação: {DataCriacao}";
        }

    }
}
