using Newtonsoft.Json;
using Projeto.Entities;
using Projeto.Presentation.Areas.AreaRestrita.Models;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    public class EnvioEmailController: Controller
    {
        public ActionResult EnviarEmail()
        {
            return View();
        }
        public ActionResult EnviarEmailNovo()
        {
            var lista = ObterConsultaDeClientes();

            //enviando  a lista para a página..
            return View(lista);
        }
        private EmailBusiness business;
        public EnvioEmailController()
        {
            //inicializar o atributo ClienteBusiness..
            business = new EmailBusiness();
        }
        private List<LogEnvioEmailViewModel> ObterConsultaDeClientes()
        {
            //declarando e inicializando uma lista
            var lista = new List<LogEnvioEmailViewModel>();

            //acessando a camada business para consultar os clientes
            foreach (LogEnvioClienteCpf c in business.ConsultarTodos())
            {
                var model = new LogEnvioEmailViewModel();
                model.IdLogEnvio = c.IdLogEnvio;
                model.IdEnvio = c.IdEnvio;
                model.Email = c.Email;
                model.DataCriacao = c.DataCriacao;

                lista.Add(model); //adicionar na lista
            }

            //retornando a lista
            return lista;
        }

        [HttpPost]
        public ActionResult EnviaEmail()
        {
            if (ModelState.IsValid)
            {
                EnvioEmailCpfRepository repLog = new EnvioEmailCpfRepository();
                LogEnvioClienteCpf Log = new LogEnvioClienteCpf();
                string emailDestinatario = Request.Form["txtEmail"];
                SendMail(emailDestinatario);

                var UsuarioLogado = JsonConvert.DeserializeObject<ClienteEmpresa>(HttpContext.User.Identity.Name);
                LogEnvioEmailViewModel EnvioModel = new LogEnvioEmailViewModel();
                Log.IdLogEnvio = EnvioModel.IdLogEnvio;
                Log.IdEnvio = UsuarioLogado.IdClienteCnpj;
                Log.Email = emailDestinatario;
                Log.DataCriacao = EnvioModel.DataCriacao;
                repLog.Insert(Log); //gravando..
                ViewBag.Mensagem = $"E-mail enviado para { emailDestinatario} com sucesso.";
                ModelState.Clear(); //limpar os campos do formulário

            }
            //return RedirectToAction("Index");

            return RedirectToAction("EnviarEmailNovo", "EnvioEmail", new { area = "AreaRestrita" });
        }

        public bool SendMail(string email)
        {
            try
            {
                string corpoMsg = string.Format("<h2>Contato - SPDS</h2>" +
               "<b>Nome: </b> <br />" +
               "<a href=\"http://localhost:54409/Questionario/CriarQuestionario\" > Clique aqui para Responder o Questionário.</a>" +
               //"<b>Texto: </b> {2} <br />" +
               "<br /> E-mail enviado do site SPDS."
               //ClienteEmpresa.NomeClienteEmpresa,
               //ClienteEmpresa.Email
               );

                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("spdfprojeto@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Contato SPDS";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = corpoMsg;

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("spdfprojeto@gmail.com", "Spdf@0701");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);



                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}