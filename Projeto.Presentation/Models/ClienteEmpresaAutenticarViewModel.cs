using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ClienteEmpresaAutenticarViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public int IdClienteCnpj { get; set; }


        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }
    }
}