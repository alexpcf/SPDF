using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class RelatorioExclusaoViewModel
    {
        public int IdClienteQuestionario { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}