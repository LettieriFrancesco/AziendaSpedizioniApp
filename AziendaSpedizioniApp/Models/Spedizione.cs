using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AziendaSpedizioniApp.Models
{
    public class Spedizione
    {
        [Display(Name = "Cod.Spedizione")]
        public int IdSpedizione { get; set; }
        [Display(Name = "Mittente")]
        [Required(ErrorMessage = "Il campo Mittente è obbligatorio!")]
        public int IdCliente { get; set; }
        [Display(Name = "Data/Ora Spedizione")]
        [Required(ErrorMessage = "E obbligatorio specificare Data/Ora Spedizione!")]
        public DateTime DataSpedizione { get; set; }
        [Required(ErrorMessage = "Specificare peso consegna!")]
        public int Peso {  get; set; }
        [Display(Name = "Città Destinatario")]
        [Required(ErrorMessage = "Specificare Città destinatario!")]
        public string CittaDestinatario { get; set; }
        [Display(Name = "Indirizzo Destinatario")]
        [Required(ErrorMessage = "Specificare indirizzo destinatario!")]
        public string IndirizzoDestinatario { get; set; }
        [Display(Name = "Destinatario")]
        [Required(ErrorMessage = "Nominativo destinatario obbligatorio!")]
        public string NominativoDestinatario { get; set; }
        [Required(ErrorMessage = "Specificare costo spedizione!")]
        public double Costo { get; set; }
        [Display(Name = "Data/Ora Consegna")]
        [Required(ErrorMessage = "Il campo Data/Ora consegna è obbligatorio!")]
        public DateTime DataConsegna { get; set; }

        public Spedizione() { }
        public Spedizione(int _idSpedizione, int _idCliente, DateTime _dataSpedizione, int _peso, string _cittadestinatario, string _indirizzoDestinatario, string _nominativoDestinatario, double _costo, DateTime _dataConsegna) 
        {
            IdSpedizione = _idSpedizione;
            IdCliente = _idCliente;
            DataSpedizione = _dataSpedizione;
            Peso = _peso;
            CittaDestinatario = _cittadestinatario;
            IndirizzoDestinatario = _indirizzoDestinatario;
            NominativoDestinatario = _nominativoDestinatario;
            Costo = _costo;
            DataConsegna = _dataConsegna;
        }
        public Spedizione(int _idSpedizione, DateTime _dataSpedizione, int _peso, string _cittadestinatario, string _indirizzoDestinatario, string _nominativoDestinatario, double _costo, DateTime _dataConsegna)
        {
            IdSpedizione = _idSpedizione;
            DataSpedizione = _dataSpedizione;
            Peso = _peso;
            CittaDestinatario = _cittadestinatario;
            IndirizzoDestinatario = _indirizzoDestinatario;
            NominativoDestinatario = _nominativoDestinatario;
            Costo = _costo;
            DataConsegna = _dataConsegna;
        }

    }
}