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
    public class RelatorioController : Controller
    {

        [NoCache]
        public ActionResult Relatorio()
        {

            //executar a consulta de clientes
            var lista = ObterConsultaDeRelatorios();

            //enviando  a lista para a página..
            return View(lista);
        }
        //public string SQL()
        //{
        //    string sSQL = "select day(data_entrega) 'dia'  " +
        //                        ",sum(peso_roadnet) 'peso' " +
        //                    "from ConsultaFreteRot2 " +
        //                    "where DATA_ENTREGA between '2018-03-01' " +
        //                           " and '2018-03-28' " +
        //                    "group by day(DATA_ENTREGA) " +
        //                    "order by dia";
        //    return sSQL;
        //}
        private RelatorioBusiness business;
        public RelatorioController()
        {
            //inicializar o atributo ClienteBusiness..
            business = new RelatorioBusiness();
        }

        private List<RelatorioViewModel> ObterConsultaDeRelatorios()
        {
            //declarando e inicializando uma lista
            var lista = new List<RelatorioViewModel>();

            //acessando a camada business para consultar os clientes
            foreach (Questionario q in business.ConsultarTodos())
            {
                var model = new RelatorioViewModel();
                model.IdClienteQuestionario = q.IdClienteQuestionario;
                model.Email = q.Email;
                model.DataCriacao = q.DataCriacao;
                model.Cpf = q.Cpf;
                model.Questao1 = q.Questao1;
                model.Questao2 = q.Questao2;
                model.Questao3 = q.Questao3;
                model.Questao4 = q.Questao4;
                model.Questao5 = q.Questao5;
                model.Questao6 = q.Questao6;
                model.Questao7 = q.Questao7;

                lista.Add(model); //adicionar na lista
            }

            //retornando a lista
            return lista;
        }


        public ActionResult Edicao(int id)
        {
            var model = new RelatorioViewModel();

            try
            {
                //buscar o cliente pelo id..
                Questionario q = business.ConsultarPorId(id);

                model.IdClienteQuestionario = q.IdClienteQuestionario;
                model.Email = q.Email;
                model.Cpf = q.Cpf;
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View(model);
        }

        public void RelatorioPDF()
        {
            //criando o conteudo do relatorio..
            StringBuilder conteudo = new StringBuilder();

            conteudo.Append("<h1>Relatório de Clientes</h1>");
            conteudo.Append($"<p>Relatório gerado em: {DateTime.Now} </p>");
            conteudo.Append("<br/>");

            conteudo.Append("<table>");
            conteudo.Append("<tr>");
            conteudo.Append("<th>Código </th>");
            conteudo.Append("<th>Email</th>");
            conteudo.Append("<th>Cpf</th>");
            conteudo.Append("<th>Data Criação</th>");
            conteudo.Append("<th>Questão1</th>");
            conteudo.Append("<th>Questão2</th>");
            conteudo.Append("<th>Questão3</th>");
            conteudo.Append("<th>Questão4</th>");
            conteudo.Append("<th>Questão5</th>");
            conteudo.Append("<th>Questão6</th>");
            conteudo.Append("<th>Questão7</th>");

            conteudo.Append("</tr>");

            QuestionarioRepository rep = new QuestionarioRepository();

            foreach (Questionario e in rep.FindAll())
            {
                conteudo.Append("<tr>");
                conteudo.Append($"<td>{e.IdClienteQuestionario}</td>");
                conteudo.Append($"<td>{e.Email}</td>");
                conteudo.Append($"<td>{e.Cpf}</td>");
                conteudo.Append($"<td>{e.DataCriacao}</td>");
                conteudo.Append($"<td>{e.Questao1}</td>");
                conteudo.Append($"<td>{e.Questao2}</td>");
                conteudo.Append($"<td>{e.Questao3}</td>");
                conteudo.Append($"<td>{e.Questao4}</td>");
                conteudo.Append($"<td>{e.Questao5}</td>");
                conteudo.Append($"<td>{e.Questao6}</td>");
                conteudo.Append($"<td>{e.Questao7}</td>");

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


        //GET: Cliente/Exclusao?id=1
        public ActionResult Exclusao(int id)
        {
            var model = new RelatorioExclusaoViewModel();

            try
            {
                //buscar o cliente pelo id..
                Questionario q = business.ConsultarPorId(id);

                model.IdClienteQuestionario = q.IdClienteQuestionario;
                model.Email = q.Email;
                model.Cpf = q.Cpf;
               
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
                    ViewBag.Mensagem = "Questionario excluído com sucesso.";
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
        public ActionResult AtualizarRelatorio(RelatorioViewModel model)
        {
            //verificar se os dados recebidos 
            //passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //transferindo os dados da viewmodel para a entidade
                    Questionario q = new Questionario();
                    q.IdClienteQuestionario = model.IdClienteQuestionario;
                    q.Email = model.Email;
                    q.Cpf = model.Cpf;
                  

                    business.Atualizar(q);

                    ViewBag.Mensagem = $"Cliente {q.Cpf}, atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            //voltar para a página..
            return View("Edicao");
        }



    }
}