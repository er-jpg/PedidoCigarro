using PedidoCigarro.Models;
using PedidoCigarro.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidoCigarro.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            var log = context.Logins.Where(a => a.Usuario.Equals(login.Usuario) && a.Senha.Equals(login.Senha)).FirstOrDefault();
            if (log != null)
            {
                Session["LogedUserId"] = log.Usuario.ToString();
                return RedirectToAction("Index", "Pedidos");
            }
            else
            {
                TempData["Mensagem"] = "Login ou senha inválidos.";
                return View(login);
            }


        }
    }
}