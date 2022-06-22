using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class LogEnvioEmailViewModel
    {
        public int IdLogEnvio { get; set; }
        public int IdEnvio { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}