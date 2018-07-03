using OficinaMecanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OficinaMecanica.Controllers
{
    public class SituacoesController : Controller
    {
        // GET: Editoras
        public ActionResult Index()
    {

        MeuContexto contexto = new MeuContexto();

        List<Situacao> situacoes = contexto.Situacaos.ToList();

        return View(situacoes);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Situacao situacao)
    {
        if (ModelState.IsValid)
        {
            MeuContexto contexto = new MeuContexto();
            contexto.Situacaos.Add(situacao);
            contexto.SaveChanges();
            return RedirectToAction("List");
        }
        return View(situacao);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        MeuContexto contexto = new MeuContexto();

        Situacao sit = contexto.Situacaos.Find(id);

        if (sit == null)
        {
            return HttpNotFound();
        }

        return View(sit);
    }
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        MeuContexto contexto = new MeuContexto();

        Situacao sit = contexto.Situacaos.Find(id);

        if (sit == null)
        {
            return HttpNotFound();
        }

        return View(sit);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Situacao sit)
    {
        if (ModelState.IsValid)
        {
            MeuContexto contexto = new MeuContexto();
            contexto.Entry(sit).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
            return RedirectToAction("List");
        }
        return View(sit);
    }
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        MeuContexto contexto = new MeuContexto();

        Situacao sit = contexto.Situacaos.Find(id);
        if (sit == null)
        {
            return HttpNotFound();
        }

        return View(sit);

    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        MeuContexto contexto = new MeuContexto();
        Situacao sit = contexto.Situacaos.Find(id);

        contexto.Situacaos.Remove(sit);
        contexto.SaveChanges();
        return RedirectToAction("List");
    }
}
}