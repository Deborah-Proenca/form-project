using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteFabio.Controllers
{
    public class ProjetosController : Controller
    {
        // GET: Projetos
        public ActionResult Index()
        {
            return View();
        }
    }
}