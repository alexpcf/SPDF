using Newtonsoft.Json;
using Projeto.Entities;
using Projeto.Presentation.Business;
using Projeto.Presentation.Models;
using Projeto.Presentation.Utils;
using Projeto.Repository;
using Projeto.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto.Presentation.Controllers
{
    public class ClienteEmpresaController:Controller
    {
        // GET: Usuario/Autenticar
        public ActionResult Autenticar()
        {
            return View();
        }

        // GET: Usuario/CriarConta
        public ActionResult CriarConta()
        {
            return View();
        }

        public ActionResult ListaEmpresa()
        {

            //executar a consulta de clientes
            var lista = ObterConsultaDeClienteEmpresa();

            //enviando  a lista para a página..
            return View(lista);
        }
        private ClienteEmpresaBusiness business;
        public ClienteEmpresaController()
        {
            //inicializar o atributo ClienteBusiness..
            business = new ClienteEmpresaBusiness();
        }


        [HttpPost] //recebe requisições do tipo POST (FormMethod.Post)
        [ValidateAntiForgeryToken] //pedindo uma chave de segurança..
        public ActionResult CadastrarClienteEmpresa(ClienteEmpresaCriarContaViewModel model)
        {
            //verificar se as validações foram realizadas com sucesso
            if (ModelState.IsValid)
            {
                try
                {
                    ClienteEmpresaRepository rep = new ClienteEmpresaRepository();

                    //verificar se o email ja esta cadastrado
                    if (rep.HasEmail(model.Email))
                    {
                        ModelState.AddModelError("Email",
                            "Este email já foi cadastrado, por favor tente outro.");
                    }
                    else
                    {
                        ClienteEmpresa Ce = new ClienteEmpresa();
                        Ce.NomeClienteEmpresa = model.NomeClienteEmpresa;
                        Ce.Email = model.Email;
                        Ce.Cnpj = model.Cnpj;
                        Ce.Endereco = model.Endereco;
                        Ce.Cep = model.Cep;
                        Ce.Sexo = model.Sexo;
                        Ce.Telefone = model.Telefone;
                        Ce.Cidade = model.Cidade;
                        Ce.Numero = model.Numero;
                        Ce.DataNascimento = model.DataNascimento;
                        Ce.Senha = Criptografia.EncriptarSenha(model.Senha);

                        rep.Insert(Ce); //gravando..

                        ViewBag.Mensagem = $"Cliente { Ce.NomeClienteEmpresa}, cadastrado com sucesso.";
                        ModelState.Clear(); //limpar os campos do formulário
                    }
                }
                catch (Exception e)
                {
                    //mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }

            //retornando para a página..
            return View("CriarConta"); //nome da página..
        }

        private List<ClienteEmpresaListarViewModel> ObterConsultaDeClienteEmpresa()
        {
            //declarando e inicializando uma lista
            var lista = new List<ClienteEmpresaListarViewModel>();

            //acessando a camada business para consultar os clientes
            foreach (ClienteEmpresa q in business.ConsultarTodos())
            {
                var model = new ClienteEmpresaListarViewModel();
                model.IdClienteCnpj = q.IdClienteCnpj;
                model.Email = q.Email;
                model.DataCriacao = q.DataCriacao;
                model.Cep = q.Cep;
                model.Cidade = q.Cidade;
                model.Cnpj = q.Cnpj;
                model.DataNascimento = q.DataNascimento;
                model.Endereco = q.Endereco;
                model.Telefone = q.Telefone;
                model.Sexo = q.Sexo;
                model.Numero = q.Numero;
                model.NomeClienteEmpresa = q.NomeClienteEmpresa;


                lista.Add(model); //adicionar na lista
            }

            //retornando a lista
            return lista;
        }


        private List<ClienteEmpresaTelaInicialViewModel> ObterConsultaDeClienteEmpresaTelaInicial()
        {
            //declarando e inicializando uma lista
            var lista = new List<ClienteEmpresaTelaInicialViewModel>();

            //acessando a camada business para consultar os clientes
            foreach (ClienteEmpresa q in business.ConsultarTodosTelaInicial())
            {
                var model = new ClienteEmpresaTelaInicialViewModel();
                model.IdClienteCnpj = q.IdClienteCnpj;
                model.Email = q.Email;
                model.DataCriacao = q.DataCriacao;
                model.NomeClienteEmpresa = q.NomeClienteEmpresa;


                lista.Add(model); //adicionar na lista
            }

            //retornando a lista
            return lista;
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //pedindo uma chave de segurança..
        public ActionResult AutenticarClienteEmpresa(ClienteEmpresaAutenticarViewModel model)
        {
            //verificando se a model não contem erros de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //buscar o usuario no banco de dados pelo email e senha
                    ClienteEmpresaRepository rep = new ClienteEmpresaRepository();
                    ClienteEmpresa Ce = rep.Find(model.Email, Criptografia.EncriptarSenha(model.Senha));

                    //verifica se o usuario não é null
                    if (Ce != null)
                    {
                        ClienteEmpresaAutenticarViewModel auth = new ClienteEmpresaAutenticarViewModel();
                        auth.IdClienteCnpj = Ce.IdClienteCnpj;
                        auth.Email = Ce.Email;
                       
                        //converter o objeto para JSON..
                        string authJSON = JsonConvert.SerializeObject(auth);

                        //criar o ticket de acesso..
                        FormsAuthenticationTicket ticket =
                            new FormsAuthenticationTicket(authJSON, false, 5);

                        //gravar o ticket em cookie..
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                           FormsAuthentication.Encrypt(ticket));
                        Response.Cookies.Add(cookie); //gravar no navegador..

                        //redirecionar para a área restrita
                        return RedirectToAction("Index", "Principal", new { area = "AreaRestrita" });
                    }
                    else
                    {
                        ViewBag.Mensagem = "Acesso Negado. Usuário não encontrado.";
                    }
                }
                catch (Exception e)
                {
                    //exibir mensagem de erro..
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            return View("Autenticar"); //nome da página
        }

        public ActionResult Edicao(int id)
        {
            var model = new ClienteEmpresaListarViewModel();

            try
            {
                //buscar o cliente pelo id..
                ClienteEmpresa q = business.ConsultarPorId(id);

                model.IdClienteCnpj = q.IdClienteCnpj;
                model.Email = q.Email;
                model.Cnpj = q.Cnpj;
                model.Telefone = q.Telefone;
                model.NomeClienteEmpresa = q.NomeClienteEmpresa;
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
            var model = new ClienteEmpresaExclusaoViewModel();

            try
            {
                //buscar o cliente pelo id..
                ClienteEmpresa q = business.ConsultarPorId(id);

                model.IdClienteCnpj = q.IdClienteCnpj;
                model.Email = q.Email;
                model.Cnpj = q.Cnpj;

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View(model);
        }

        [HttpPost] //método recebe os dados enviados por FormMethod.POST
        public ActionResult ExcluirCliente(ClienteEmpresaExclusaoViewModel model)
        {
            //verificar se os dados recebidos 
            //passaram nas regras de validação
            if (ModelState.IsValid)
            {
                var UsuarioLogado = JsonConvert.DeserializeObject<ClienteEmpresa>(HttpContext.User.Identity.Name);

                try
                {
                    if(UsuarioLogado.IdClienteCnpj == 7)
                    {
                        business.Excluir(model.IdClienteCnpj);
                        ViewBag.Mensagem = "Cliente excluído com sucesso.";
                    }
                   
                    ViewBag.Mensagem = "Condição Somente para Administradores.";
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
        public ActionResult AtualizarClienteEmpresa(ClienteEmpresaListarViewModel model)
        {
            //verificar se os dados recebidos 
            //passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {

                    var UsuarioLogado = JsonConvert.DeserializeObject<ClienteEmpresa>(HttpContext.User.Identity.Name);
                    if(UsuarioLogado.IdClienteCnpj == 7)
                    {
                        //transferindo os dados da viewmodel para a entidade
                        ClienteEmpresa q = new ClienteEmpresa();
                        q.IdClienteCnpj = model.IdClienteCnpj;
                        q.Email = model.Email;
                        q.Telefone = model.Telefone;
                        q.NomeClienteEmpresa = model.NomeClienteEmpresa;
                        q.Cnpj = model.Cnpj;


                        business.Atualizar(q);

                        ViewBag.Mensagem = $"Cliente {q.NomeClienteEmpresa}, atualizado com sucesso.";
                    }
                    else
                    {
                        ViewBag.Mensagem = $"Condição Somente para Administradores";
                    }
                   
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
            conteudo.Append("<th>Código </th>");
            conteudo.Append("<th>Nome</th>");
            conteudo.Append("<th>Email</th>");
            conteudo.Append("<th>Telefone</th>");
            conteudo.Append("<th>Data Criação</th>");
            conteudo.Append("<th>Cidade</th>");
            conteudo.Append("<th>Cnpj</th>");
            conteudo.Append("<th>Data Nascimento</th>");
            conteudo.Append("<th>Cep</th>");
            conteudo.Append("<th>Cidade</th>");
            conteudo.Append("<th>Endereço</th>");

            conteudo.Append("</tr>");

            ClienteEmpresaRepository rep = new ClienteEmpresaRepository();

            foreach (ClienteEmpresa e in rep.FindAll())
            {
                conteudo.Append("<tr>");
                conteudo.Append($"<td>{e.IdClienteCnpj}</td>");
                conteudo.Append($"<td>{e.NomeClienteEmpresa}</td>");
                conteudo.Append($"<td>{e.Email}</td>");
                conteudo.Append($"<td>{e.Telefone}</td>");
                conteudo.Append($"<td>{e.DataCriacao}</td>");
                conteudo.Append($"<td>{e.Cidade}</td>");
                conteudo.Append($"<td>{e.Cnpj}</td>");
                conteudo.Append($"<td>{e.DataNascimento}</td>");
                conteudo.Append($"<td>{e.Cep}</td>");
                conteudo.Append($"<td>{e.Cidade}</td>");
                conteudo.Append($"<td>{e.Endereco}</td>");

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




        public ActionResult Logout()
        {
            //destruir o ticket do usuario gravado
            //em cookie no navegador
            FormsAuthentication.SignOut();

            //redirecionar para a página de login
            return View("Autenticar");
        }

    }
}