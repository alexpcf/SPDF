using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Questionario
    {

        public int IdClienteQuestionario { get; set; }
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
       


        public Questionario()
        {
            //vazio
        }

        public Questionario(int idClienteQuestionario, string cpf, string email, DateTime dataCriacao, string questao1, string questao2, string questao3, string questao4, string questao5, string questao6, string questao7)
        {
            IdClienteQuestionario = idClienteQuestionario;
            Cpf = cpf;
            Email = email;
            DataCriacao = dataCriacao;
            Questao1 = questao1;
            Questao2 = questao2;
            Questao3 = questao3;
            Questao4 = questao4;
            Questao5 = questao5;
            Questao6 = questao6;
            Questao7 = questao7;
        }

        public override string ToString()
        {
            return $"Id: {IdClienteQuestionario},Cpf: {Cpf},Email: {Email}, Data de Criação: {DataCriacao}, Questao1:{Questao1},Questao2:{Questao2},Questao3:{Questao3},Questao4:{Questao4},Questao5:{Questao5},Questao6:{Questao6},Questao7:{Questao7}";
        }

    }
}
