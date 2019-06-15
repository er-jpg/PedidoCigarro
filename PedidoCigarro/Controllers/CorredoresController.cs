using Newtonsoft.Json;
using PedidoCigarro.Contexts;
using PedidoCigarro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PedidoCigarro.Controllers
{
    [HandleError]
    public class CorredoresController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Corredores
        public ActionResult Index()
        {
            return View(context.Corredor.OrderBy(c => c.IdCorredor));
            //return View(context.Corredor.OrderBy(c => c.IdCorredor));
        }

        // GET Detalhes
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Corredor corredor = context.Corredor.Find(id);
            if (corredor == null)
            {
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            return View(corredor);
        }

        // GET Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Corredor corredor)
        {
            try
            {
                context.Corredor.Add(corredor);
                context.SaveChanges();
                TempData["Mensagem"] = "Dados inseridos com sucesso.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro de inserção.";
                return View(corredor);
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
            Corredor corredor = context.Corredor.Find(id);
            if (corredor == null)
            {
                //return HttpNotFound();
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            return View(corredor);
        }

        // POST Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Corredor corredor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(corredor).State = EntityState.Modified;
                    context.SaveChanges();
                    TempData["Mensagem"] = "Dados alterados com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(corredor);
            }
            catch
            {
                TempData["Mensagem"] = "Dados não puderam ser alterados.";
                return View(corredor);
            }

        }

        // GET Deletar
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SolicitacaoInvalida", "Erro");
            }
            Corredor corredor = context.Corredor.Find(id);
            if (corredor == null)
            {
                return RedirectToAction("NaoEncontrado", "Erro");
            }
            return View(corredor);
        }

        // POST Deletar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {
            try
            {
                Corredor corredor = context.Corredor.Find(id);
                context.Corredor.Remove(corredor);
                context.SaveChanges();
                TempData["Mensagem"] = corredor.NomeCorredor + " foi removido com sucesso.";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Dados não puderam ser deletados.";
                return View();
            }
        }

        //public ActionResult Grafico()
        //{
        //    new Chart(1600, 900, ChartTheme.Vanilla)
        //        .AddTitle("Quem corre mais?")
        //        .DataBindTable(context.Corredor, "QtdePedidos")
        //        .Write("png");
        //    return View(context.Corredor);
        //}

        public ActionResult Grafico()
        {
            ViewBag.Valores = JsonConvert.SerializeObject(context.Corredor.ToList());
            return View();
        }
    }
}