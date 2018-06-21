using OficinaMecanica.Models;
using OficinaMecanica.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OficinaMecanica.Controllers
{
    public class FuncionariosController : Controller
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
        public ActionResult Create(Funcionario func)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    contexto.Funcionarios.Add(func);
                    contexto.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception e)
                {
                    return View(e);
                }
            }

            return View(func);
        }

        public ActionResult List()
        {
            MeuContexto contexto = new MeuContexto();
            List<Funcionario> lista = contexto.Funcionarios.ToList();

            return View(lista);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            Funcionario func = contexto.Funcionarios.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(func);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Funcionario func)
        {

            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                EditEndereco(func);
                contexto.Entry(func).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                EditEndereco(func);
                return RedirectToAction("/List");
            }

            return View(func);
        }

        public void EditEndereco(Funcionario func)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco end = contexto.Enderecos.Where(c => c.EnderecoID.Equals(func.EnderecoID)).FirstOrDefault();
            end.Rua = func._Endereco.Rua;
            end.Numero = func._Endereco.Numero;
            end.Estado = func._Endereco.Estado;
            end.Bairro = func._Endereco.Bairro;
            end.CEP = func._Endereco.CEP;
            contexto.Entry(end).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            Funcionario func = contexto.Funcionarios.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(func);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                MeuContexto contexto = new MeuContexto();
                Funcionario func = contexto.Funcionarios.Find(id);
                contexto.Funcionarios.Remove(func);
                contexto.SaveChanges();
                DeleteEndereco(func);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }

        public void DeleteEndereco(Funcionario func)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco serie = contexto.Enderecos.Where(c => c.EnderecoID.Equals(func.EnderecoID)).FirstOrDefault();
            contexto.Enderecos.Remove(serie);
            contexto.SaveChanges();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            Funcionario func = contexto.Funcionarios.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(func);
        }

    }
}
