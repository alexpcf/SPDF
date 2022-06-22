using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class ClienteCpfViewModel
    {
        public int IdClienteCpf { get; set; }
        public string NomeClienteCpf { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}