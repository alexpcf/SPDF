using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Filters;
using System.Data;
using System.Web.Security;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        // GET: AreaRestrita/Principal
        [NoCache]
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
            dt.Columns.Add("Credit", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            dr["Employee"] = "Sam";
            dr["Credit"] = 123;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Alex";
            dr["Credit"] = 456;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Michael";
            dr["Credit"] = 587;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Julio";
            dr["Credit"] = 587;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Employee"] = "Carlos";
            dr["Credit"] = 587;
            dt.Rows.Add(dr);
            string userId = Membership.GetUser().ProviderUserKey.ToString();
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