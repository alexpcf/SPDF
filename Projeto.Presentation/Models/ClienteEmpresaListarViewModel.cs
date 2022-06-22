using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ClienteEmpresaListarViewModel
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
    }
}