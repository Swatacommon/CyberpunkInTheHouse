using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberConnectedLayer;
using CyberpunkInTheHouse.Models;
using Oracle.ManagedDataAccess.Client;

namespace CyberpunkInTheHouse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cookie = new HttpCookie("test_cookie")
            {
                Name = "test_cookie",
                Value = DateTime.Now.ToString("dd.MM.yyyy"),
                Expires = DateTime.Now.AddMinutes(10),
            };

            Response.SetCookie(cookie);

            var cookie_poluch = Request.Cookies["test_cookie"];
            CyberDAL.OpenConnection("CYBER", "134576290Cyberpunk", String.Empty);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            List<Client> clients = new List<Client>();
            var reader = CyberDAL.ShowUsers();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Client client = new Client(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(6), reader.GetString(7));
                    clients.Add(client);
                }
            }
            ViewBag.Message = "Сотрудники нашего магазина!";
            return View(clients);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            Client client = new Client();
            return View(client);
        }

        [HttpPost]
        public ActionResult Registration(Client client)
        {
            if (ModelState.IsValid)
            {
                CyberDAL.Registration(2, client.FirstName, client.LastName, client.Email, client.Password, client.Telephone, client.Adres);
                if (CyberDAL.command.ExecuteNonQueryAsync().IsFaulted)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpGet]
        public ActionResult Authorized()
        {
            if (Client.Clienty != null)
            {
                ViewData["Current_user"] = Client.Clienty.Role;
            }
            else
            {
                ViewData["Current_user"] = 1;
            }
            Client client = new Client();
            return View(client);
        }

        [HttpPost]
        public ActionResult Authorized(Client client)
        {
            var reader = CyberDAL.Authorized(client.Email);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client = new Client(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(6), reader.GetString(7));
                }
                Client.Clienty = client;
            }
            ViewData["Current_user"] = Client.Clienty.Role;
            return View();
        }
    }
}