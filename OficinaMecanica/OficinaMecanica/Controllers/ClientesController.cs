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
    public class ClientesController : Controller
    {


        // GET: Clientes
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
        public ActionResult Create(Cliente cli)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    MeuContexto contexto = new MeuContexto();
                    contexto.Clientes.Add(cli);
                    contexto.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception e)
                {
                    return View(e);
                }
            }

            return View(cli);
        }

        public ActionResult List()
        {
            MeuContexto contexto = new MeuContexto();
            List<Cliente> lista = contexto.Clientes.ToList();

            return View(lista);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //retorna erro http diferente, requisição mau feita.
            }

            MeuContexto contexto = new MeuContexto();
            Cliente cli = contexto.Clientes.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }


            return View(cli);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Cliente cli)
        {

            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                EditEndereco(cli);
                contexto.Entry(cli).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                EditEndereco(cli);
                return RedirectToAction("/List");
            }

            return View(cli);
        }

        public void EditEndereco(Cliente cli)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco end = contexto.Enderecos.Where(c => c.EnderecoID.Equals(cli.EnderecoID)).FirstOrDefault();
            end.Rua = cli._Endereco.Rua;
            end.Numero = cli._Endereco.Numero;
            end.Estado = cli._Endereco.Estado;
            end.Bairro = cli._Endereco.Bairro;
            end.CEP = cli._Endereco.CEP;
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
            Cliente cli = contexto.Clientes.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(cli);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                MeuContexto contexto = new MeuContexto();
                Cliente cli = contexto.Clientes.Find(id);
                contexto.Clientes.Remove(cli);
                contexto.SaveChanges();
                DeleteEndereco(cli);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }

        public void DeleteEndereco(Cliente cli)
        {
            MeuContexto contexto = new MeuContexto();
            Endereco serie = contexto.Enderecos.Where(c => c.EnderecoID.Equals(cli.EnderecoID)).FirstOrDefault();
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
            Cliente cli = contexto.Clientes.Find(id);

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(cli);
        }

    }

}