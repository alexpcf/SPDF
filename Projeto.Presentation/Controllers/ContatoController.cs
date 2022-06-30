using Projeto.Entities;
using Projeto.Presentation.Models;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Controllers
{
    public class ContatoController:Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Contato()
        {
            return View();
        }
        public ActionResult ListaContato()
        {

            //executar a consulta de clientes
            var lista = ObterConsultaDeContatos();

            //enviando  a lista para a página..
            return View(lista);
        }
        private ContatoBusiness business;
        public ContatoController()
        {
            //inicializar o atributo ClienteBusiness..
            business = new ContatoBusiness();
        }



        [HttpPost] //recebe requisições do tipo POST (FormMethod.Post)
        public ActionResult CadastrarContato(ContatoCadastroViewModel model)
        {
            //verificar se as validações foram realizadas com sucesso
            if (ModelState.IsValid)
            {
                try
                {
                    ContatoRepository rep = new ContatoRepository();

                    Contato Ce = new Contato();
                    Ce.Nome = model.Nome;
                    Ce.Email = model.Email;
                    Ce.Mensagem = model.Mensagem;
                    Ce.DataCriacao = model.DataCriacao;

                    rep.Insert(Ce); //gravando..

                    ViewBag.Mensagem = $"Contato { Ce.Nome}, cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário

                }
                catch (Exception e)
                {
                    //mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }

            //retornando para a página..
            return View("Contato"); //nome da página..
        }
        private List<ContatoListarViewModel> ObterConsultaDeContatos()
        {
            //declarando e inicializando uma lista
            var lista = new List<ContatoListarViewModel>();

            //acessando a camada business para consultar os clientes
            foreach (Contato q in business.ConsultarTodos())
            {
                var model = new ContatoListarViewModel();
                model.IdContato = q.IdContato;
                model.Nome = q.Nome;
                model.Email = q.Email;
                model.DataCriacao = q.DataCriacao;
                model.Mensagem = q.Mensagem;

                lista.Add(model); //adicionar na lista
            }

            //retornando a lista
            return lista;
        }

    }
}