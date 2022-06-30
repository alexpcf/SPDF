using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ContatoCadastroViewModel
    {

        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}