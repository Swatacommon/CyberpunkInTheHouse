using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace CyberpunkInTheHouse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            OracleConnection con;
            con = new OracleConnection();
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.Password = "";
            ocsb.UserID = "SYS";
            ocsb.DBAPrivilege = "SYSDBA";
            ocsb.DataSource = "172.20.10.11:1521/cyberpunk";
            con.ConnectionString = ocsb.ConnectionString;
            con.Open();
            ViewBag.Message = con.State;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}