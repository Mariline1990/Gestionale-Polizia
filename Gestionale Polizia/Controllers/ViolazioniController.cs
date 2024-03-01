using Gestionale_Polizia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Polizia.Controllers
{
    public class ViolazioniController : Controller
    {
        // GET: Violazioni
        public ActionResult Index()
        {
            return View();
        }


        

        [HttpGet]
        public ActionResult List()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))

                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    conn.Open();



                    cmd.CommandText = "SELECT * FROM VIOLAZIONE";
                    SqlDataReader reader = cmd.ExecuteReader();
                    Response.Write(reader);

                    List<Violazioni> ScarpaList = new List<Violazioni>();

                while (reader.Read())
                {

                        Violazioni Violazione = new Violazioni
                        {

                         
                            id_tipo_violazione = Convert.ToInt32(reader["ID_TIPO_VIOLAZIONE"]),
                            Descrizione = reader["DESCRIZIONE"].ToString(),
                    
                        
                    };

                    ScarpaList.Add(Violazione);
                }

                return View(ScarpaList);
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

      
          
        }

    }
}