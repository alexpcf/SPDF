using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class LogEnvioClienteCpfViewModel
    {
        public int IdLogEnvio { get; set; }
        public int IdEnvio { get; set; }
        [Required(ErrorMessage = "Por favor, informe o Email do cliente.")]
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}