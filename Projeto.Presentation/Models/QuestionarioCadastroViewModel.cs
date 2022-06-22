using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class QuestionarioCadastroViewModel
    {
        public int IdClienteCpf { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Questao1 { get; set; }
        public string Questao2 { get; set; }
        public string Questao3 { get; set; }
        public string Questao4 { get; set; }
        public string Questao5 { get; set; }
        public string Questao6 { get; set; }
        public string Questao7 { get; set; }
        public string Questao8 { get; set; }
        public string Questao9 { get; set; }
    }
}