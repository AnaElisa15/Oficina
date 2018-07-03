﻿using OficinaMecanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OficinaMecanica.Controllers
{
    public class ServicosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Servicos.Add(servico);
                contexto.SaveChanges();
                return RedirectToAction("List");
            }
            return View(servico);
        }

        public ActionResult List()
        {

            MeuContexto contexto = new MeuContexto();

            List<Servico> lista = contexto.Servicos.ToList();

            return View(lista);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Servico ser = contexto.Servicos.Find(id);

            if (ser == null)
            {
                return HttpNotFound();
            }

            return View(ser);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Servico ser = contexto.Servicos.Find(id);

            if (ser == null)
            {
                return HttpNotFound();
            }

            return View(ser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Servico ser)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(ser).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("List");
            }
            return View(ser);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Servico ser = contexto.Servicos.Find(id);
            if (ser == null)
            {
                return HttpNotFound();
            }

            return View(ser);

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Servico ser= contexto.Servicos.Find(id);

            contexto.Servicos.Remove(ser);
            contexto.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

