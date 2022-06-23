using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ClienteEmpresaTelaInicialViewModel
    {

        public int IdClienteCnpj { get; set; }
        public string NomeClienteEmpresa { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Email { get; set; }
        
    }
}