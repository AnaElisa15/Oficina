using OficinaMecanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OficinaMecanica.Controllers
{
    public class EmpresasControllers : Controller
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
        public ActionResult Create(Endereco end)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    contexto.Enderecos.Add(end);
                    contexto.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception e)
                {
                    return View(end);
                }
            }

            return View(end);
        }

        public ActionResult List()
        {
            MeuContexto contexto = new MeuContexto();
            List<Endereco> lista = contexto.Enderecos.ToList();

            return View(lista);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            Empresa emp = contexto.Empresas.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(emp);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Empresa emp)
        {

            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                EditEndereco(emp);
                contexto.Entry(emp).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                EditEndereco(emp);
                return RedirectToAction("/List");
            }

            return View(emp);
        }

        public void EditEndereco(Empresa emp)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco end = contexto.Enderecos.Where(c => c.EnderecoID.Equals(emp.EnderecoID)).FirstOrDefault();
            end.Rua = emp._Endereco.Rua;
            end.Numero = emp._Endereco.Numero;
            end.Estado = emp._Endereco.Estado;
            end.Bairro = emp._Endereco.Bairro;
            end.CEP = emp._Endereco.CEP;
            contexto.Entry(end).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }
       
    }
}