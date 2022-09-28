using Evaluacion.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluacion.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            var client = new RestClient("https://localhost:44382/api/Compras");
            var request = new RestRequest(new Uri("https://localhost:44382/api/Compras"), Method.Get);
            var response = client.Execute(request);
            List<Compra_Cab> items = JsonConvert.DeserializeObject<List<Compra_Cab>>(response.Content);

            return View(items);
        }

        
       
    }
}