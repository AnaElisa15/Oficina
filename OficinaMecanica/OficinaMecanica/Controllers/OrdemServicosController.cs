using OficinaMecanica.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Collections.Generic;

namespace OficinaMecanica.Controllers
{
    public class OrdemServicosController : Controller
    {

        public MeuContexto Contexto = new MeuContexto();

        public OrdemServicosController()
        {

        }

        public ActionResult Index()
        {


            var ordemServicos = this.Contexto.OrdemServicos.ToList();
            var situacoes = this.Contexto.Situacaos.ToList();
            
            var model = new OrdemServicoViewModels (ordemServicos, situacoes);

            return View(model);
        }


        public ActionResult Create()
        {



            ViewBag.SituacaoID = new SelectList(
            this.Contexto.Situacaos.ToList(),
            "SituacaoID",
            "Nome"
             );

            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdemServico ordemServico, string situacaoId)
        {
            if (ModelState.IsValid)
            {

                this.Contexto.OrdemServicos.Add(ordemServico);
                this.Contexto.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.SituacaoID = new SelectList(
            this.Contexto.Situacaos.ToList(),
            "SituacaoID",
            "Nome",
            situacaoId
             );


            return View(ordemServico);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            OrdemServico os = contexto.OrdemServicos.Find(id);

            if (os == null)
            {
                return HttpNotFound();
            }

            return View(os);
        }
        public ActionResult Edit(int? id)
        {
            var ordemServico = this.Contexto.OrdemServicos.FirstOrDefault(_ => _.OrdemServicoID == id);
            var situacao = this.Contexto.Situacaos.ToList();
            

            ViewBag.SituacaoID = new SelectList(
                this.Contexto.Situacaos.ToList(),
                "SituacaoID",
                "Nome"
                );

            

            var model = new EditViewModels(ordemServico, situacao);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdemServico ordemServico, string situacaoId)
        {
            if (ModelState.IsValid)
            {
                ordemServico.SituacaoID = int.Parse(situacaoId);
               

                this.Contexto.Entry(ordemServico).State = EntityState.Modified;
                this.Contexto.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.SituacaoID = new SelectList(
               this.Contexto.Situacaos.ToList(),
               "SituacaoID",
               "Nome",
              situacaoId
               );

            return View(ordemServico);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            OrdemServico os = Contexto.OrdemServicos.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }

            return View(os);

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            OrdemServico os = Contexto.OrdemServicos.Find(id);

            this.Contexto.OrdemServicos.Remove(os);
            this.Contexto.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult BuscaPorPlaca()
        {
            Session["lista"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult BuscaPorPlaca(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var serie = contexto.OrdemServicos.Where(c => c.Placa.ToLower().Equals(nome.ToLower()));
            List<OrdemServico> lista = serie.ToList();
            ViewBag.Lista = lista;
            if (lista.Count > 0)
            {
                Session["lista"] = serie;
            }
            else
            {
                Session["lista"] = null;
                ViewBag.Message = "Nada encontrado no sistema com a placa : " + nome;
            }

            return View();
        }

    }
}
