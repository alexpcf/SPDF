using Projeto.Entities;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Business
{
    public class ClienteEmpresaBusiness
    {
        private ClienteEmpresaRepository repository;

        //construtor..
        public ClienteEmpresaBusiness()
        {
            //inicializar o atributo da classe ClienteRepository
            repository = new ClienteEmpresaRepository();
        }

        //método para cadastrar o cliente
        public void Cadastrar(ClienteEmpresa c)
        {
            repository.Insert(c);
        }

        //método para atualizar o cliente
        public void Atualizar(ClienteEmpresa c)
        {
            repository.Update(c);
        }

        //método para excluir o cliente
        public void Excluir(int IdClienteCnpj)
        {
            repository.Delete(IdClienteCnpj);
        }

        //método para consultar todos os clientes
        public List<ClienteEmpresa> ConsultarTodos()
        {
            return repository.FindAll();
        }

        //método para obter 1 cliente pelo id
        public ClienteEmpresa ConsultarPorId(int IdClienteCnpj)
        {
            return repository.FindById(IdClienteCnpj);
        }
    }
}