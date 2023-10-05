using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AziendaSpedizioniApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        [Display(Name = "Cod.Fiscale(Sez.Privati)")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "P.IVA(Sez.Aziende)")]
        public string PartitaIva {  get; set; }

        public Cliente() { }
        public Cliente(int _id, string _nomeCliente, string _cognomeCliente, string _codiceFiscale, string _partitaIva) 
        {
            Id = _id;
            Nome = _nomeCliente;
            Cognome = _cognomeCliente;
            CodiceFiscale = _codiceFiscale;
            PartitaIva = _partitaIva;
        }
        public Cliente(string _nomeCliente, string _cognomeCliente, string _codiceFiscale, string _partitaIva)
        {
            Nome = _nomeCliente;
            Cognome = _cognomeCliente;
            CodiceFiscale = _codiceFiscale;
            PartitaIva = _partitaIva;
        }
    }
}