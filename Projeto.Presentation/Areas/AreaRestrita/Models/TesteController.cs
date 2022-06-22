using Projeto.Entities;
using Projeto.Presentation.Models;
using Projeto.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class TesteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> iData = new List<object>();
            //Creating sample data
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee", System.Type.GetType("System.String"));
            dt.Columns.Add("Credit", System.Type.GetType("System.String"));
            Questionario Qe = new Questionario();
            QuestionarioCadastroViewModel model = new QuestionarioCadastroViewModel();
            QuestionarioRepository rep = new QuestionarioRepository();
            StringBuilder sb = new StringBuilder();

            //string de conexão
            string sConString = ConfigurationManager.ConnectionStrings[
             "aula"].ToString();
            SqlConnection con = new SqlConnection(sConString);
            //configura objeto com informações da Stored Procedure
            SqlCommand cmd = new SqlCommand("spCliente", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id = cmd.ExecuteScalar();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("spQuestao12", con);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id2 = cmd2.ExecuteScalar();
            con.Close();

            SqlCommand cmd3 = new SqlCommand("spQuestao13", con);
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id3= cmd3.ExecuteScalar();
            con.Close();

            SqlCommand cmd4= new SqlCommand("spQuestao14", con);
            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id4 = cmd4.ExecuteScalar();
            con.Close();

            SqlCommand cmd5 = new SqlCommand("spQuestao15", con);
            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id5 = cmd5.ExecuteScalar();
            con.Close();

            //rep.FindAll2(); //gravando..
            //var teste = rep.FindAll2();
            DataRow dr = dt.NewRow();
            dr["Employee"] = " Ruim";
            dr["Credit"] = id;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = " Razoável";
            dr["Credit"] = id2;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = " Bom";
            dr["Credit"] = id3;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = " Muito bom";
            dr["Credit"] = id4;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Employee"] = " Excelente";
            dr["Credit"] = id5;
            dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["Employee"] = "Someone";
            //dr["Credit"] = rawData.Where(a => a.person == "Someone").Count().ToString();
            //dt.Rows.Add(dr);

            //Looping and extracting each DataColumn to List<Object>
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult NewChart2()
        {
            List<object> iData = new List<object>();
            //Creating sample data
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee", System.Type.GetType("System.String"));
            dt.Columns.Add("Credit", System.Type.GetType("System.String"));
            Questionario Qe = new Questionario();
            QuestionarioCadastroViewModel model = new QuestionarioCadastroViewModel();
            QuestionarioRepository rep = new QuestionarioRepository();
            StringBuilder sb = new StringBuilder();

            //string de conexão
            string sConString = ConfigurationManager.ConnectionStrings[
             "aula"].ToString();
            SqlConnection con = new SqlConnection(sConString);
            //configura objeto com informações da Stored Procedure
            SqlCommand cmd = new SqlCommand("spQuestao21", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id = cmd.ExecuteScalar();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("spQuestao22", con);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id2 = cmd2.ExecuteScalar();
            con.Close();

            SqlCommand cmd3 = new SqlCommand("spQuestao23", con);
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id3 = cmd3.ExecuteScalar();
            con.Close();

            SqlCommand cmd4 = new SqlCommand("spQuestao24", con);
            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id4 = cmd4.ExecuteScalar();
            con.Close();

            SqlCommand cmd5 = new SqlCommand("spQuestao25", con);
            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            Object id5 = cmd5.ExecuteScalar();
            con.Close();

            //rep.FindAll2(); //gravando..
            //var teste = rep.FindAll2();
            DataRow dr = dt.NewRow();
            dr["Employee"] = " Ruim";
            dr["Credit"] = id;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = " Razoável";
            dr["Credit"] = id2;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = " Bom";
            dr["Credit"] = id3;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = " Muito bom";
            dr["Credit"] = id4;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Employee"] = " Excelente";
            dr["Credit"] = id5;
            dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["Employee"] = "Someone";
            //dr["Credit"] = rawData.Where(a => a.person == "Someone").Count().ToString();
            //dt.Rows.Add(dr);

            //Looping and extracting each DataColumn to List<Object>
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
    }
}
