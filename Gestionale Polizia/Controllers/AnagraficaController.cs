using Gestionale_Polizia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Polizia.Controllers
{
    public class AnagraficaController : Controller
    {
        // GET: Anagrafica
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Anagrafica());
        }


            [HttpPost]
        public ActionResult Create(Anagrafica model) 
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
               
                string query = "INSERT INTO ANAGRAFICA (NOME, COGNOME , INDIRIZZO, CITTA, Cap , CF, FK_ID_VERBALE) VALUES ( @nome, @cognome, @indirizzo,@città, @cap, @cf, @fk)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", model.Nome);
                cmd.Parameters.AddWithValue("@cognome", model.Cognome);
                cmd.Parameters.AddWithValue("@indirizzo", model.Indirizzo);
                cmd.Parameters.AddWithValue("@città", model.Città);
                cmd.Parameters.AddWithValue("@cap", model.Cap);
                cmd.Parameters.AddWithValue("@cf", model.CF);
                cmd.Parameters.AddWithValue("@fk", model.FK_ID_VERBALE);

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

            return RedirectToAction("Index","Anagrafica");
        }



    }




}