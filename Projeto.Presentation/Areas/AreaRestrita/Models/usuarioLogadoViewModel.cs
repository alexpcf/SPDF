using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class usuarioLogadoViewModel
    {

        public int IdClienteCnpj { get; set; }
        public string NomeClienteEmpresa { get; set; }
        public string Email { get; set; }
    }
}