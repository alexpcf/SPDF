using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ClienteEmpresaCriarContaViewModel
    {

        public int IdClienteCnpj { get; set; }
        [Required(ErrorMessage = "Informe seu Nome.")]
        public string NomeClienteEmpresa { get; set; }
        [Required(ErrorMessage = "Informe um Cnpj.")]
        [MaxLength(18, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe um E-mail.")]
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        [MaxLength(9, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Cep { get; set; }
        public string Numero { get; set; }
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Confirme a senha do usuário.")]
        public string SenhaConfirm { get; set; }

    }
}