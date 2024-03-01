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
    public class TotaleVerbaliController : Controller
    {
        // GET: TotaleVerbali
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



                    cmd.CommandText = "SELECT NOME, COGNOME AS  COGNOME,COUNT(FK_ID_ANAGRAFICA) AS TOTALE FROM ANAGRAFICA JOIN VERBALE  ON ID_ANAGRAFICA = FK_ID_ANAGRAFICA  GROUP BY  NOME,COGNOME";
                    SqlDataReader reader = cmd.ExecuteReader();
                    Response.Write(reader);

                    List<TotaleVerbali> Totale  = new List<TotaleVerbali>();

                    while (reader.Read())
                    {

                        TotaleVerbali verbaleTot = new TotaleVerbali
                        {
                           

                            Trasgressore =  reader["NOME"].ToString(),
                            TrasgressoreCognome = reader["COGNOME"].ToString(),
                            TotaleVerbale = Convert.ToInt32(reader["TOTALE"]),


                        };

                        Totale.Add(verbaleTot);
                    }

                    return View(Totale);
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