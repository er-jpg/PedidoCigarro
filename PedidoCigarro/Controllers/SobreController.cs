using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using PedidoCigarro.Models;
using System.Net;

namespace PedidoCigarro.Controllers
{
    [HandleError]
    public class SobreController : Controller
    {
        // GET: Sobre
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Sobre sobre)
        {
            if(true)
            {
                try
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(sobre.Email, sobre.Nome);
                    mailMessage.To.Add("brunosaragosa@gmail.com");
                    mailMessage.Subject = "Tomate entregas: " + sobre.Assunto;
                    mailMessage.Body = String.Format("Nome: {1}\nEmail: {0}\nMensagem: {2}", sobre.Email.ToString(), sobre.Nome.ToString(), sobre.Mensagem);
                    //ViewBag.Email = mailMessage.ToString();

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        // Mude o email e a senha aqui, caso tenha problemas é a falta de conexão com o servidor do gmail
                        // terá que acessar e permitir o acesso da sua conta por aplicativos não confiáveis pela google
                        smtp.Credentials = new NetworkCredential("EMAIL", "SENHA");
                        smtp.EnableSsl = true;
                        smtp.Send(mailMessage);
                    }

                    ModelState.Clear();
                    TempData["Mensagem"] = "Obrigado por nos contatar";
                }
                catch (Exception erro)
                {
                    ModelState.Clear();
                    TempData["Mensagem"] = $"Estamos encontrando um problema em {erro.Message}.";
                }
            }
            return View();
        }
    }
}