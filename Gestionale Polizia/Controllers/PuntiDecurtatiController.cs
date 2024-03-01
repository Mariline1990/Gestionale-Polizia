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
    public class PuntiDecurtatiController : Controller
    {
        // GET: PuntiDecurtati
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult List() 
        
        
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))

                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    conn.Open();



                    cmd.CommandText = "SELECT NOME, COGNOME AS  COGNOME,SUM(DECURTAMENTO_PUNTI) AS TOTALE FROM ANAGRAFICA JOIN VERBALE  ON ID_ANAGRAFICA = FK_ID_ANAGRAFICA  GROUP BY  NOME,COGNOME";
                    SqlDataReader reader = cmd.ExecuteReader();
                    Response.Write(reader);

                    List<PuntiDecurtati> TotalePunti = new List<PuntiDecurtati>();

                    while (reader.Read())
                    {

                        PuntiDecurtati PuntiTolti = new PuntiDecurtati
                        {


                            Trasgressore = reader["NOME"].ToString(),
                            TrasgressoreCognome = reader["COGNOME"].ToString(),
                            Punti = Convert.ToInt32(reader["TOTALE"]),


                        };

                        TotalePunti.Add(PuntiTolti);
                    }

                    return View(TotalePunti);
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