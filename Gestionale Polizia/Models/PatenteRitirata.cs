using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Polizia.Models
{
    public class PatenteRitirata
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataViolazione { get; set; }
        public int DecurtamentoPunti { get; set; }



        public PatenteRitirata() { 
        }

        public PatenteRitirata(string nome, string cognome, DateTime dataViolazione, int decurtamentoPunti)
        {
            Nome = nome;
            Cognome = cognome;
            DataViolazione = dataViolazione;
            DecurtamentoPunti = decurtamentoPunti;
        }
    }
}