using Projeto.Entities;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    public class RelatorioBusiness
    {

        private QuestionarioRepository repository;

        //construtor..
        public RelatorioBusiness()
        {
            //inicializar o atributo da classe ClienteRepository
            repository = new QuestionarioRepository();
        }

        //método para cadastrar o cliente
        public void Cadastrar(Questionario q)
        {
            repository.Insert(q);
        }

        //método para atualizar o cliente
        public void Atualizar(Questionario q)
        {
            repository.Update(q);
        }

        //método para excluir o cliente
        public void Excluir(int IdClienteQuestionario)
        {
            repository.Delete(IdClienteQuestionario);
        }

        //método para consultar todos os clientes
        public List<Questionario> ConsultarTodos()
        {
            return repository.FindAll();
        }

        //método para obter 1 cliente pelo id
        public Questionario ConsultarPorId(int IdClienteQuestionario)
        {
            return repository.FindById(IdClienteQuestionario);
        }
    }
}
