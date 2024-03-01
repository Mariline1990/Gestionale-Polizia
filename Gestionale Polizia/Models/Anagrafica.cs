using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Polizia.Models
{
    public class Anagrafica
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string Indirizzo { get; set; }
        public string Città { get; set; }

        public int Cap { get; set; }
        public string CF { get; set; }

        public int FK_ID_VERBALE { get; set; }



        public Anagrafica() { }



        public Anagrafica(string nome, string cognome, string indirizzo, string città, int cap, string cf, int fk_id_verbale)
        {

            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;          
            Città = città;      
            Cap = cap;
            CF = cf;
            FK_ID_VERBALE = fk_id_verbale;
        }
    }
}