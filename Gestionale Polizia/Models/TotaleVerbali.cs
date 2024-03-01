using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Polizia.Models
{
    public class TotaleVerbali
    {


        

        public string Trasgressore { get; set; }
      public string  TrasgressoreCognome { get; set; }
        public int TotaleVerbale { get; set; }




        public TotaleVerbali() { }



    public TotaleVerbali(int totale_Verbale , string trasgressore, string trasgressoreCognome)
    {
            Trasgressore = trasgressore;
            TrasgressoreCognome = trasgressoreCognome;
            TotaleVerbale = totale_Verbale;


    }

}
}