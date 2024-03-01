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
    public class PatenteRitirataController : Controller
    {
        // GET: PatenteRitirata
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



                    cmd.CommandText = "SELECT NOME, COGNOME, DATA_VIOLAZIONE, SUM(DECURTAMENTO_PUNTI) AS TOTALE FROM ANAGRAFICA JOIN VERBALE ON ID_ANAGRAFICA = FK_ID_ANAGRAFICA GROUP BY NOME, COGNOME, DATA_VIOLAZIONE HAVING SUM(DECURTAMENTO_PUNTI) = 10;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    Response.Write(reader);

                    List<PatenteRitirata> Punti = new List<PatenteRitirata>();

                    while (reader.Read())
                    {

                        PatenteRitirata dieciPunti = new PatenteRitirata
                        {


                            Nome = reader["NOME"].ToString(),
                            Cognome = reader["COGNOME"].ToString(),
                            DataViolazione = Convert.ToDateTime(reader["DATA_VIOLAZIONE"]),
                            DecurtamentoPunti = Convert.ToInt32(reader["TOTALE"])


                        };

                        Punti.Add(dieciPunti);
                    }

                    return View(Punti);
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