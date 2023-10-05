using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AziendaSpedizioniApp.Models
{
    public class AggiornamentoSpedizioni
    {
        [Display(Name = "Cod. Aggiornamento Consegna")]

        public int IdAggiornamento { get; set; }
        [Display(Name = "Cod.Spedizione")]
        public int IdSpedizione { get; set; }
        [Display(Name = "Stato consegna")]
        public string Stato { get; set; }
        public string Luogo { get; set; }
        public string Descrizione { get; set; }
        [Display(Name = "Data Aggiornamento")]
        public DateTime DataAggiornamento { get; set; }

        public AggiornamentoSpedizioni() { }
        public AggiornamentoSpedizioni(int _idAggiornamento,int _idSpedizione,string _stato,string _luogo,string _descrizione, DateTime _dataAggiornamento) 
        {
            IdAggiornamento = _idAggiornamento;
            IdSpedizione = _idSpedizione;
            Stato = _stato;
            Luogo = _luogo;
            Descrizione = _descrizione;
            DataAggiornamento = _dataAggiornamento;
        }
    }
}