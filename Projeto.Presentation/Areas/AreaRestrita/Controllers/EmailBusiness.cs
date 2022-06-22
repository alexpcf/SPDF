using Projeto.Entities;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    public class EmailBusiness
    {

        private EnvioEmailCpfRepository repository;

        //construtor..
        public EmailBusiness()
        {
            //inicializar o atributo da classe ClienteRepository
            repository = new EnvioEmailCpfRepository();
        }

        //método para cadastrar o cliente
        public void Cadastrar(LogEnvioClienteCpf lo)
        {
            repository.Insert(lo);
        }

        //método para atualizar o cliente
        public void Atualizar(LogEnvioClienteCpf lo)
        {
            repository.Update(lo);
        }

        //método para excluir o cliente
        public void Excluir(int IdLogEnvio)
        {
            repository.Delete(IdLogEnvio);
        }

        //método para consultar todos os clientes
        public List<LogEnvioClienteCpf> ConsultarTodos()
        {
            return repository.FindAll();
        }

        //método para obter 1 cliente pelo id
        public LogEnvioClienteCpf ConsultarPorId(int IdLogEnvio)
        {
            return repository.FindById(IdLogEnvio);
        }
    }
}
