using PedidoCigarro.Contexts;
using PedidoCigarro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PedidoCigarro.Controllers
{
    [HandleError]
    public class CigarrosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Cigarros
        public ActionResult Index()
        {
            return View(context.Cigarro.OrderBy(c => c.IdCigarro));
        }

        // GET Detalhes
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Cigarro cigarro = context.Cigarro.Find(id);
            if (cigarro == null)
            {
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            return View(cigarro);
        }

        // GET Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Cigarro cigarro)
        {
            try
            {
                context.Cigarro.Add(cigarro);
                context.SaveChanges();
                TempData["Mensagem"] = "Dados inseridos com sucesso.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro de inserção.";
                return View(cigarro);
            }
        }

        // GET Editar
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Cigarro cigarro = context.Cigarro.Find(id);
            if (cigarro == null)
            {
                //return HttpNotFound();
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            return View(cigarro);
        }

        // POST Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cigarro cigarro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(cigarro).State = EntityState.Modified;
                    context.SaveChanges();
                    TempData["Mensagem"] = "Dados alterados com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(cigarro);
            }
            catch
            {
                TempData["Mensagem"] = "Dados não puderam ser alterados.";
                return View(cigarro);
            }

        }

        // GET Deletar
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Cigarro cigarro = context.Cigarro.Find(id);
            if (cigarro == null)
            {
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            return View(cigarro);
        }

        // POST Deletar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {
            try
            {
                Cigarro cigarro = context.Cigarro.Find(id);
                context.Cigarro.Remove(cigarro);
                context.SaveChanges();
                TempData["Mensagem"] = cigarro.NomeCigarro + " foi removido com sucesso.";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Dados não puderam ser Deletados.";
                return View();
            }
        }
    }
}