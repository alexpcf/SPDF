using Projeto.Entities;
using Projeto.Presentation.Areas.AreaRestrita.Models;
using Projeto.Presentation.Filters;
using Projeto.Presentation.Utils;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    public class ClienteCpfController:Controller
    {
        [NoCache]
        public ActionResult Index()
        {
            return View();
        }

        private ClienteBusiness business;

        //construtor..
        public ClienteCpfController()
        {
            //inicializar o atributo ClienteBusiness..
            business = new ClienteBusiness();
        }
        public ActionResult Consulta()
        {
            //executar a consulta de clientes
            var lista = ObterConsultaDeClientes();

            //enviando  a lista para a página..
            return View(lista);
        }


        //método para acessar a camada de negocio e retornar a consulta de clientes
        private List<ClienteCpfViewModel> ObterConsultaDeClientes()
        {
            //declarando e inicializando uma lista
            var lista = new List<ClienteCpfViewModel>();

            //acessando a camada business para consultar os clientes
            foreach (ClienteCpf c in business.ConsultarTodos())
            {
                var model = new ClienteCpfViewModel();
                model.IdClienteCpf = c.IdClienteCpf;
                model.NomeClienteCpf = c.NomeClienteCpf;
                model.Email = c.Email;
                model.Estado = c.Estado;
                model.Cpf = c.Cpf;
                model.DataCriacao = c.DataCriacao;
            

                lista.Add(model); //adicionar na lista
            }

            //retornando a lista
            return lista;
        }

        public ActionResult Edicao(int id)
        {
            var model = new ClienteCpfViewModel();

            try
            {
                //buscar o cliente pelo id..
                ClienteCpf q = business.ConsultarPorId(id);

                model.IdClienteCpf = q.IdClienteCpf;
                model.Email = q.Email;
                model.Cpf = q.Cpf;
                model.Estado = q.Estado;
                model.NomeClienteCpf = q.NomeClienteCpf;
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View(model);
        }


        //GET: Cliente/Exclusao?id=1
        public ActionResult Exclusao(int id)
        {
            var model = new ClienteCpfExlusao();

            try
            {
                //buscar o cliente pelo id..
                ClienteCpf q = business.ConsultarPorId(id);

                model.IdClienteCpf = q.IdClienteCpf;
                model.Email = q.Email;
                model.Cpf = q.Cpf;
                model.NomeClienteCpf = q.NomeClienteCpf;

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View(model);
        }

        [HttpPost] //método recebe os dados enviados por FormMethod.POST
        public ActionResult ExcluirCliente(RelatorioExclusaoViewModel model)
        {
            //verificar se os dados recebidos 
            //passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    business.Excluir(model.IdClienteQuestionario);
                    ViewBag.Mensagem = "Cliente excluído com sucesso.";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            //voltar para a página..
            //var lista = ObterConsultaDeRelatorios();
            //voltar para a página..
            return View("Exclusao");
        }



        [HttpPost] //método recebe os dados enviados por FormMethod.POST
        public ActionResult AtualizarClienteCpf(ClienteCpfViewModel model)
        {
            //verificar se os dados recebidos 
            //passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //transferindo os dados da viewmodel para a entidade
                    ClienteCpf q = new ClienteCpf();
                    q.IdClienteCpf = model.IdClienteCpf;
                    q.NomeClienteCpf = model.NomeClienteCpf;
                    q.Email = model.Email;
                    q.Cpf = model.Cpf;
                    q.Estado = model.Estado;


                    business.Atualizar(q);

                    ViewBag.Mensagem = $"Cliente {q.NomeClienteCpf}, atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            //voltar para a página..
            return View("Edicao");
        }

        public void Relatorio()
        {
            //criando o conteudo do relatorio..
            StringBuilder conteudo = new StringBuilder();

            conteudo.Append("<h1>Relatório de Clientes</h1>");
            conteudo.Append($"<p>Relatório gerado em: {DateTime.Now} </p>");
            conteudo.Append("<br/>");

            conteudo.Append("<table>");
            conteudo.Append("<tr>");
            conteudo.Append("<th>Código do Cliente</th>");
            conteudo.Append("<th>Nome do Cliente</th>");
            conteudo.Append("<th>Email</th>");
            conteudo.Append("<th>Estado</th>");
            conteudo.Append("<th>Data</th>");
            conteudo.Append("<th>Cpf</th>");
            conteudo.Append("</tr>");

            ClienteCpfRepository rep = new ClienteCpfRepository();

            foreach (ClienteCpf e in rep.FindAll())
            {
                conteudo.Append("<tr>");
                conteudo.Append($"<td>{e.IdClienteCpf}</td>");
                conteudo.Append($"<td>{e.NomeClienteCpf}</td>");
                conteudo.Append($"<td>{e.Email}</td>");
                conteudo.Append($"<td>{e.Estado}</td>");
                conteudo.Append($"<td>{e.DataCriacao}</td>");
                conteudo.Append($"<td>{e.Cpf}</td>");
                conteudo.Append("</tr>");
            }

            conteudo.Append("</table>");
            var css = Server.MapPath("/Areas/AreaRestrita/Css/relatorio.css");

            //transformando o conteudo em arquivo PDF..
            ReportsUtil util = new ReportsUtil();
            byte[] pdf = util.GetPDF(conteudo.ToString(), css);

            //Download..
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=relatorio.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.BinaryWrite(pdf);
            Response.End();
        }

    }
}