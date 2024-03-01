using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Polizia.Models
{
    public class PuntiDecurtati
    {
       




            public string Trasgressore { get; set; }
            public string TrasgressoreCognome { get; set; }
            public int Punti{ get; set; }




            public PuntiDecurtati() { }



            public PuntiDecurtati(int punti, string trasgressore, string trasgressoreCognome)
            {
                Trasgressore = trasgressore;
                TrasgressoreCognome = trasgressoreCognome;
                Punti = punti;


            }

        
    }
}