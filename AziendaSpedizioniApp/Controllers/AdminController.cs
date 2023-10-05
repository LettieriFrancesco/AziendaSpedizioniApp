using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AziendaSpedizioniApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.messaggio = "Benvenuto nella sezione Amministratori";
            return View();
        }
    }
}