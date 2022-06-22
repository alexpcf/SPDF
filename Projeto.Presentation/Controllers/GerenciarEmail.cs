using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Projeto.Presentation.Controllers
{
    public class GerenciarEmail
    {
        protected void EnviarEmail(ClienteEmpresa ClienteEmpresa)
        {

            string corpoMsg = string.Format("<h2>Contato - SPDF</h2>" +
               "<b>Nome: </b> {0} <br />" +
               "<b>E-mail: </b> {1} <br />" +
               //"<b>Texto: </b> {2} <br />" +
               "<br /> E-mail enviado automaticamente do site SPDF.",
               ClienteEmpresa.NomeClienteEmpresa,
               ClienteEmpresa.Email
               );

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("alex.castriola89@gmail.com", "Pato@2401");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("alex.castriola89@gmail.com", "Teste");
            mail.From = new MailAddress("alex.castriola89@gmail.com", "Teste");
            mail.To.Add(new MailAddress(ClienteEmpresa.Email, ClienteEmpresa.NomeClienteEmpresa));
            mail.Subject = "Contato";
            mail.Body = corpoMsg;
            //mail.Body = " Mensagem do site:<br/> Nome:  " + senderName.Text + "<br/> Email : " + senderEmail.Text + " <br/> Mensagem : " + message.Text;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception e)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }

        }
    }
}