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
    public class QuestionarioController : Controller
    {
        public ActionResult CriarQuestionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuestionarioPergunta(FormCollection formCollection)
        {

            if (ModelState.IsValid)
            {
                Questionario Qe = new Questionario();
                QuestionarioCadastroViewModel model = new QuestionarioCadastroViewModel();
                QuestionarioRepository rep = new QuestionarioRepository();
                bool  CpfQuestionario = false, EmailQuestionario = false, RdQuestao1= false, RdQuestao2 = false, RdQuestao3 = false, RdQuestao4 = false
                    , RdQuestao5 = false, RdQuestao6 = false, RdQuestao7 = false;
                //string chkecoValue = "";
                //string chkbussValue = "";
                string CpfValue = "";
                string EmailValue = "";
                string Questao1Value = "";
                string Questao2Value = "";
                string Questao3Value = "";
                string Questao4Value = "";
                string Questao5Value = "";
                string Questao6Value = "";
                string Questao7Value = "";
                //if (!string.IsNullOrEmpty(formCollection["chkeco"])) { chkeco = true; }
                //if (!string.IsNullOrEmpty(formCollection["chkbuss"])) { chkbuss = true; }
                //if (chkeco) { chkecoValue = formCollection["chkeco"]; }
                //if (chkbuss) { chkbussValue = formCollection["chkbuss"]; }

                if (!string.IsNullOrEmpty(formCollection["CpfQuestionario"])) { CpfQuestionario = true; }
                if (CpfQuestionario) { CpfValue = formCollection["CpfQuestionario"]; }
                if (!string.IsNullOrEmpty(formCollection["EmailQuestionario"])) { EmailQuestionario = true; }
                if (EmailQuestionario) { EmailValue = formCollection["EmailQuestionario"]; }
                if (!string.IsNullOrEmpty(formCollection["RdQuestao1"])) { RdQuestao1 = true; }
                if (RdQuestao1) { Questao1Value = formCollection["RdQuestao1"]; }

                if (!string.IsNullOrEmpty(formCollection["RdQuestao2"])) { RdQuestao2 = true; }
                if (RdQuestao2) { Questao2Value = formCollection["RdQuestao2"]; }

                if (!string.IsNullOrEmpty(formCollection["RdQuestao3"])) { RdQuestao3 = true; }
                if (RdQuestao3) { Questao3Value = formCollection["RdQuestao3"]; }

                if (!string.IsNullOrEmpty(formCollection["RdQuestao4"])) { RdQuestao4 = true; }
                if (RdQuestao4) { Questao4Value = formCollection["RdQuestao4"]; }

                if (!string.IsNullOrEmpty(formCollection["RdQuestao5"])) { RdQuestao5 = true; }
                if (RdQuestao5) { Questao5Value = formCollection["RdQuestao5"]; }

                if (!string.IsNullOrEmpty(formCollection["RdQuestao6"])) { RdQuestao6 = true; }
                if (RdQuestao6) { Questao6Value = formCollection["RdQuestao6"]; }

                if (!string.IsNullOrEmpty(formCollection["RdQuestao7"])) { RdQuestao7 = true; }
                if (RdQuestao7) { Questao7Value = formCollection["RdQuestao7"]; }

                Qe.Cpf = CpfValue;
                Qe.Email = EmailValue;
                Qe.Questao1 = Questao1Value;
                Qe.Questao2 = Questao2Value;
                Qe.Questao3 = Questao3Value;
                Qe.Questao4 = Questao4Value;
                Qe.Questao5 = Questao5Value;
                Qe.Questao6 = Questao6Value;
                Qe.Questao7 = Questao7Value;


                //Qe.Questao1 = chkbussValue;


                if (EmailValue != "")
                {
                    rep.Insert(Qe); //gravando..
                    ViewBag.Mensagem = $"Questionário { Qe.Email}, cadastrado com sucesso.";
                }
                else
                {
                    ViewBag.Mensagem = $"Preencha os Campos Obrigatórios";
                }

               

             
                ModelState.Clear(); //limpar os campos do formulário

            }
            return View("CriarQuestionario"); //nome da página..
        }
    }
}