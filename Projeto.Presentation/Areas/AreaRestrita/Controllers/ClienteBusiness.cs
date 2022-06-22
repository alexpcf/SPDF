using Projeto.Entities;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    public class ClienteBusiness
    {
        private ClienteCpfRepository repository;

        //construtor..
        public ClienteBusiness()
        {
            //inicializar o atributo da classe ClienteRepository
            repository = new ClienteCpfRepository();
        }

        //método para cadastrar o cliente
        public void Cadastrar(ClienteCpf c)
        {
            repository.Insert(c);
        }

        //método para atualizar o cliente
        public void Atualizar(ClienteCpf c)
        {
            repository.Update(c);
        }

        //método para excluir o cliente
        public void Excluir(int IdClienteCpf)
        {
            repository.Delete(IdClienteCpf);
        }

        //método para consultar todos os clientes
        public List<ClienteCpf> ConsultarTodos()
        {
            return repository.FindAll();
        }

        //método para obter 1 cliente pelo id
        public ClienteCpf ConsultarPorId(int IdClienteCpf)
        {
            return repository.FindById(IdClienteCpf);
        }
    }
}