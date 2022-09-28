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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            var client = new RestClient("https://localhost:44382/api/Clientes");
            var request = new RestRequest(new Uri("https://localhost:44382/api/Clientes"), Method.Get);
            var response = client.Execute(request);
            List<Cliente> items = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);

            return View(items);
        }

        // GET: Clientes/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Clientes/Create
        public ActionResult Create()
        {
            Cliente cli = new Cliente();
            return PartialView("_ClienteData", cli);
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cli)
        {
            try
            {
                var client = new RestClient("https://localhost:44382/api/Clientes");
                var request = new RestRequest(new Uri("https://localhost:44382/api/Clientes"), Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(cli);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);
                //Console.WriteLine(response.Content);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient("https://localhost:44382/api/Clientes/" + id);
            var request = new RestRequest(new Uri("https://localhost:44382/api/Clientes/" + id), Method.Get);
            var response = client.Execute(request);
            Cliente item = JsonConvert.DeserializeObject<Cliente>(response.Content);

            return PartialView("_ClienteDataEdit", item);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cli)
        {
            try
            {
                var client = new RestClient("https://localhost:44382/api/Clientes/" + cli.Cli_ID.ToString());
                var request = new RestRequest(new Uri("https://localhost:44382/api/Clientes/" + cli.Cli_ID.ToString()), Method.Put);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(cli);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Clientes/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var client = new RestClient("https://localhost:44382/api/Clientes/" + id.ToString());
                    var request = new RestRequest(new Uri("https://localhost:44382/api/Clientes/" + id.ToString()), Method.Delete);
                    var response = client.Execute(request);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}