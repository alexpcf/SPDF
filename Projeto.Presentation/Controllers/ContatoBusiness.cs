using Projeto.Entities;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Controllers
{
    public class ContatoBusiness
    {


        private ContatoRepository repository;

        //construtor..
        public ContatoBusiness()
        {
            //inicializar o atributo da classe ClienteRepository
            repository = new ContatoRepository();
        }

        //método para cadastrar o cliente
        public void Cadastrar(Contato q)
        {
            repository.Insert(q);
        }

        //método para atualizar o cliente
        public void Atualizar(Contato q)
        {
            repository.Update(q);
        }

        //método para excluir o cliente
        public void Excluir(int IdClienteQuestionario)
        {
            repository.Delete(IdClienteQuestionario);
        }

        //método para consultar todos os clientes
        public List<Contato> ConsultarTodos()
        {
            return repository.FindAll();
        }

        //método para obter 1 cliente pelo id
        public Contato ConsultarPorId(int idContato)
        {
            return repository.FindById(idContato);
        }
    }
}
