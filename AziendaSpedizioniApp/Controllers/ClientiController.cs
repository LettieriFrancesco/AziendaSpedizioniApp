using AziendaSpedizioniApp.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AziendaSpedizioniApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cl) 
        {
            if(ModelState.IsValid)
            {
                DB.CreaCliente(cl);
                return View();
            }
            else { return View("Error"); }
        }
        public ActionResult Edit(int id)
        {
            Cliente c = DB.getClienteById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(Cliente c) 
        {
            if (ModelState.IsValid)
            {
                DB.UpdateCliente(c.Id, c.Nome, c.Cognome, c.CodiceFiscale, c.PartitaIva);
                return RedirectToAction("Create", "Clienti");
            }
            else return View(c);
        }
        public ActionResult Delete(int id)
        {
            DB.DeleteCliente(id);
            return RedirectToAction("Create");
        }
        public ActionResult RecuperoClienti()
        {
            List<Cliente> clienti = DB.ListaClienti();
            return View(clienti);
        }
        public ActionResult GetPartialViewClienti()
        {
            List<Cliente> clienti = DB.ListaClienti();
            return PartialView(clienti);
        }
    }
}