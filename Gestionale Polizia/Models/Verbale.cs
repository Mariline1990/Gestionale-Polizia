using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Polizia.Models
{
    public class Verbale
    {
      
        public DateTime Data_Violazione { get; set; }

        public string Nominativo_Agente { get; set; }
        public string Indirizzo { get; set; }
          
        public DateTime Data_Trascrizione { get; set; }
        public int Importo { get; set; }
        public int Decurtamento_punti { get; set; }
        public int FK_ID_VIOLAZIONE { get; set; }
        public int FK_ID_Anagrafica { get; set; }

        public Verbale() { }



        public Verbale(DateTime dataViolazione, string indirizzo, string nominativoAgente, DateTime dataTrascrizione, int importo, int decurtamentoPunti, int fk_id_violazione, int fk_id_anagrafica)
        {

            Data_Violazione = dataViolazione;
            Nominativo_Agente = nominativoAgente;
            Indirizzo = indirizzo;
            Data_Trascrizione = dataTrascrizione;
            Importo = importo;
            Decurtamento_punti = decurtamentoPunti;
            FK_ID_VIOLAZIONE = fk_id_violazione;
            FK_ID_Anagrafica = fk_id_anagrafica;
        }
    }
}