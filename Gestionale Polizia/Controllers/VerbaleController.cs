using Gestionale_Polizia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Polizia.Controllers
{
    public class VerbaleController : Controller
    {
        // GET: Verbale
        public ActionResult Index()
        {


            return View();
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View(new Verbale());
        }
     


        [HttpPost]
        public ActionResult Create(Verbale model)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
                string query = "INSERT INTO VERBALE (DATA_VIOLAZIONE, INDIRIZZO_VIOLAZIONE , NOMINATIVO_AGENTE, DATA_TRASCRIZIONE_VERBALE, IMPORTO , DECURTAMENTO_PUNTI, FK_ID_VIOLAZIONE,FK_ID_ANAGRAFICA) VALUES ( @data, @indirizzo, @nominativoAgente,@dataTrascrizione, @importo, @decurtamentoPunti, @fk_Violazione,@fk_Anagrafica)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data", model.Data_Violazione);
                cmd.Parameters.AddWithValue("@indirizzo", model.Indirizzo);
                cmd.Parameters.AddWithValue("@nominativoAgente", model.Nominativo_Agente);
                cmd.Parameters.AddWithValue("@dataTrascrizione", model.Data_Trascrizione);
                cmd.Parameters.AddWithValue("@importo", model.Importo);
                cmd.Parameters.AddWithValue("@decurtamentoPunti", model.Decurtamento_punti);
                cmd.Parameters.AddWithValue("@fk_Violazione", model.FK_ID_VIOLAZIONE);
                cmd.Parameters.AddWithValue("@fk_Anagrafica", model.FK_ID_Anagrafica);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                return View(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Create", "Verbale");
        }
    }
}