using OficinaMecanica.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;



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
            var clientes = this.Contexto.Clientes.ToList();
            var funcionarios = this.Contexto.Funcionarios.ToList();
            var servicos = this.Contexto.Servicos.ToList();

            var model = new OrdemServicoViewModels (ordemServicos, clientes, funcionarios, servicos);

            return View(model);
        }


        public ActionResult Create()
        {



            ViewBag.EditoraID = new SelectList(
            this.Contexto.Clientes.ToList(),
            "ClienteID",
            "Nome"
             );

            ViewBag.CategoriaID = new SelectList(
            this.Contexto.Funcionarios.ToList(),
            "FuncionarioID",
            "Nome"
             );

            ViewBag.AssuntoID = new SelectList(
            this.Contexto.Servicos.ToList(),
            "ServicoID",
            "Nome"
             );
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdemServico ordemServico, string clienteId, string funcionarioId, string servicoId)
        {
            if (ModelState.IsValid)
            {

                this.Contexto.OrdemServicos.Add(ordemServico);
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(
            this.Contexto.Clientes.ToList(),
            "ClienteID",
            "Nome",
            clienteId
             );

            ViewBag.CategoriaID = new SelectList(
            this.Contexto.Funcionarios.ToList(),
            "FuncionarioID",
            "Nome",
            funcionarioId
             );

            ViewBag.AssuntoID = new SelectList(
            this.Contexto.Servicos.ToList(),
            "ServicoID",
            "Nome",
            servicoId
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
            var cliente = this.Contexto.Clientes.ToList();
            var funcionario = this.Contexto.Funcionarios.ToList();
            var servico = this.Contexto.Servicos.ToList();

            ViewBag.ClienteID = new SelectList(
                this.Contexto.Clientes.ToList(),
                "ClienteID",
                "Nome"
                );

            ViewBag.FuncionarioID = new SelectList(
            this.Contexto.Funcionarios.ToList(),
            "FuncionarioID",
            "Nome"
            );

            ViewBag.ServicoID = new SelectList(
            this.Contexto.Servicos.ToList(),
            "ServicoID",
            "Nome"
            );

            var model = new EditViewModel(ordemServico, cliente, funcionario, servico);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdemServico ordemServico, string clienteId, string funcionarioId, string servicoId)
        {
            if (ModelState.IsValid)
            {
                ordemServico.ClienteID = int.Parse(funcionarioId);
                ordemServico.FuncionarioID = int.Parse(servicoId);
                ordemServico.ServicoID = int.Parse(clienteId);

                this.Contexto.Entry(ordemServico).State = EntityState.Modified;
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(
               this.Contexto.Clientes.ToList(),
               "ClienteID",
               "Nome",
               clienteId
               );

            ViewBag.FuncionarioID = new SelectList(
            this.Contexto.Funcionarios.ToList(),
            "FuncionarioID",
            "Nome",
            funcionarioId
            );

            ViewBag.ServicoID = new SelectList(
            this.Contexto.Servicos.ToList(),
            "ServicoID",
            "Nome",
            servicoId
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
            return RedirectToAction("Index");
        }
    }
}
