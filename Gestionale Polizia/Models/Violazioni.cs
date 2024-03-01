using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Polizia.Models
{
    public class Violazioni
    {

        public int id_tipo_violazione { get; set; }

        public string Descrizione { get; set; }
       

      

        public Violazioni() { }



        public Violazioni( int id_violazione, string descrizione)
        {
            id_tipo_violazione = id_violazione;
            Descrizione = descrizione;


        }

    }
}