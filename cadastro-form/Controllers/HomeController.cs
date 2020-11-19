using cadastro_form.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteFabio.Models;

namespace TesteFabio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ContatoModel model = new ContatoModel())
            return View();
        }


        public ActionResult Formulario()
        {
           
            return View();
        }

        public ActionResult About()
        {
            var model = new TesteFabio.Models.Formulario();
            //model.Nome = "Deborah";
            return View(model);
        }

        [HttpPost]
        public ActionResult Salvar(TesteFabio.Models.Formulario model)
        {
            Formulario contato = new Formulario();
            contato.Nome = model.Nome;
            contato.Email = model.Email;
            contato.Telefone = model.Telefone;

            using (ContatoModel models = new ContatoModel())
            {
                models.Create(contato);
                return RedirectToAction("Index");
            }

            return Redirect("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sobre: ";
            

            return View();
        }
    }
}