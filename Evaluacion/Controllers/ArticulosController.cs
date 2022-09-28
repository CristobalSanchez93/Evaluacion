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
    public class ArticulosController : Controller
    {
        public ActionResult Index()
        {
            var client = new RestClient("https://localhost:44382/api/Articulos");
            var request = new RestRequest(new Uri("https://localhost:44382/api/Articulos"), Method.Get);
            var response = client.Execute(request);
            List<Articulo> items = JsonConvert.DeserializeObject<List<Articulo>>(response.Content);

            return View(items);
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            Articulo art = new Articulo();
            return PartialView("_ArticuloData", art);
        }

        // POST: Articulos/Create
        [HttpPost]
        public ActionResult Create(Articulo art)
        {
            try
            {
                var client = new RestClient("https://localhost:44382/api/Articulos");
                var request = new RestRequest(new Uri("https://localhost:44382/api/Articulos"), Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(art);
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

        // GET: Articulos/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient("https://localhost:44382/api/Articulos/" + id);
            var request = new RestRequest(new Uri("https://localhost:44382/api/Articulos/" + id), Method.Get);
            var response = client.Execute(request);
            Articulo item = JsonConvert.DeserializeObject<Articulo>(response.Content);

            return PartialView("_ArticuloDataEdit", item);
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        public ActionResult Edit(Articulo art)
        {
            try
            {
                var client = new RestClient("https://localhost:44382/api/Articulos/" + art.Art_ID.ToString());
                var request = new RestRequest(new Uri("https://localhost:44382/api/Articulos/" + art.Art_ID.ToString()), Method.Put);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(art);
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

        // GET: Articulos/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Articulos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var client = new RestClient("https://localhost:44382/api/Articulos/" + id.ToString());
                    var request = new RestRequest(new Uri("https://localhost:44382/api/Articulos/" + id.ToString()), Method.Delete);
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