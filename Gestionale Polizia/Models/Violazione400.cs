using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Gestionale_Polizia.Models
{
    public class Violazione400
    {


        public int Costo { get; set; }

        public string Descrizione { get; set; }




        public Violazione400() { }



        public Violazione400(int costo, string descrizione)
        {
            Costo = costo;
            Descrizione = descrizione;


        }


    }
}