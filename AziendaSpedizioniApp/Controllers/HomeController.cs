using AziendaSpedizioniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AziendaSpedizioniApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public JsonResult MetodoProva()
        {
            //Comandi sql invece della lista
            List<Cliente> listcliente = new List<Cliente>();
            Cliente cliente = new Cliente { Nome = "Francesco", Cognome = "Lettieri", CodiceFiscale = "123456" };
            listcliente.Add(cliente);
            return Json(listcliente);
        }
        public ActionResult CercaSpedizione() 
        {
            return View();
        }
    }
}