using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class QuestionarioCadastroViewModel
    {
        public int IdClienteCpf { get; set; }
        [Required(ErrorMessage = "Informe um Cpf.")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Informe um E-mail.")]
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