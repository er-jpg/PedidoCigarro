using PedidoCigarro.Contexts;
using PedidoCigarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PedidoCigarro.Controllers
{
    [HandleError]
    public class PedidosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidos = context.Pedido.Include(c => c.Corredor).Include(f => f.Cigarro).OrderBy(n => n.IdPedido);
            return View(pedidos);
        }

        // GET Detalhes
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Pedido pedido = context.Pedido.Find(id);
            if (pedido == null)
            {
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            ViewBag.IdCigarro = new SelectList(context.Cigarro.OrderBy(c => c.IdCigarro), "IdCigarro", "IdCigarro", pedido.IdCigarro);
            ViewBag.IdCorredor = new SelectList(context.Corredor.OrderBy(c => c.IdCorredor), "IdCorredor", "IdCorredor", pedido.IdCorredor);
            return View(pedido);
        }

        // GET Criar
        public ActionResult Criar()
        {
            ViewBag.IdCigarro = new SelectList(context.Cigarro.OrderBy(c => c.IdCigarro), "IdCigarro", "NomeCigarro");
            ViewBag.IdCorredor = new SelectList(context.Corredor.OrderBy(c => c.IdCorredor), "IdCorredor", "NomeCorredor");
            return View();
        }

        // POST Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Pedido pedido)
        {
            try
            {
                context.Pedido.Add(pedido);
                context.SaveChanges();
                TempData["Mensagem"] = "Dados inseridos com sucesso.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro de inserção.";
                return View(pedido);
            }

        }

        // GET Editar
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCigarro = new SelectList(context.Cigarro.OrderBy(c => c.IdCigarro), "IdCigarro", "IdCigarro", pedido.IdCigarro);
            ViewBag.IdCorredor = new SelectList(context.Corredor.OrderBy(c => c.IdCorredor), "IdCorredor", "IdCorredor", pedido.IdCorredor);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Pedido pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(pedido).State = EntityState.Modified;
                    context.SaveChanges();
                    TempData["Mensagem"] = "Dados alterados com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(pedido);
            }
            catch
            {
                return View(pedido);
            }
        }

        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Pedido pedido = context.Pedido.Find(id);
            if (pedido == null)
            {
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            ViewBag.IdCigarro = new SelectList(context.Cigarro.OrderBy(c => c.IdCigarro), "IdCigarro", "IdCigarro", pedido.IdCigarro);
            ViewBag.IdCorredor = new SelectList(context.Corredor.OrderBy(c => c.IdCorredor), "IdCorredor", "IdCorredor", pedido.IdCorredor);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {
            try
            {
                Pedido pedido = context.Pedido.Find(id);
                context.Pedido.Remove(pedido);
                context.SaveChanges();
                TempData["Mensagem"] = pedido.NomePedido + " foi removido com sucesso.";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Dados não puderam ser deletados.";
                return View();

            }
        }
    }
}