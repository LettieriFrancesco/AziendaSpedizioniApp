using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AziendaSpedizioniApp.Models
{
    public class CercaSpedizione
    {
        [Display(Name = "Cod.Fiscale(Privati)")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "PartitaIVA(Aziende)")]
        public string PartivaIva {  get; set; }

        public CercaSpedizione() { }
        public CercaSpedizione(string codiceFiscale, string partivaIva)
        {
            CodiceFiscale = codiceFiscale;
            PartivaIva = partivaIva;
        }
    }
}