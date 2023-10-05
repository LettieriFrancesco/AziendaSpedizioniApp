using AziendaSpedizioniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AziendaSpedizioniApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpedizioniController : Controller
    {
       
        // GET: Spedizioni
        public ActionResult Index()
        {
            List<Spedizione> spedizioni = DB.ListaSpedizioni();
            return View(spedizioni);
        }
        public List<SelectListItem> DescrizioneMittente
        {
            get
            {
                List<Cliente> listaClienti = new List<Cliente>();
                listaClienti = DB.ListaClienti();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Cliente c in listaClienti)
                {
                    SelectListItem select = new SelectListItem { Text = $"{c.Nome} {c.Cognome}", Value = c.Id.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        [HttpGet]
        public ActionResult AggiornamentoSped()
        {
            List<AggiornamentoSpedizioni>aggSpedizioni = DB.ListaAggiornamenti();
            return View(aggSpedizioni);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            ViewBag.listaClienti = DescrizioneMittente;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {
                DB.CreaSpedizione(spedizione);
                return RedirectToAction("Index");
            }
            else { return View(); }
        }
    }
}