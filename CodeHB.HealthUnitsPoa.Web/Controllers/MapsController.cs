using CodeHB.HealthUnitsPoa.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace CodeHB.HealthUnitsPoa.Web.Controllers
{
    public class MapsController : Controller
    {
        HttpClient client = new HttpClient();

        public MapsController()
        {
            client.BaseAddress = new Uri("http://datapoa.com.br");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: InitMap
        public ActionResult InitMap()
        {
            return View();
        }

        public JsonResult GetPins()
        {
            List<Pin> pins = new List<Pin>();

            HttpResponseMessage response = client.GetAsync("/api/action/datastore_search?resource_id=ecf0e670-2968-4a01-b256-69f64e3e9ca2").Result;

            if (response.IsSuccessStatusCode)
            {
                HealthUnit unit = new HealthUnit();
                unit = response.Content.ReadAsAsync<HealthUnit>().Result;
                foreach (var item in unit.Result.Records)
                {
                    pins.Add(new Pin(item));
                }
            }

            return Json(pins, JsonRequestBehavior.AllowGet);
        }
    }
}