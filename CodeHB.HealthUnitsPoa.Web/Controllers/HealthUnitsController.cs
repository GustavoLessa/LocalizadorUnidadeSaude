using CodeHB.HealthUnitsPoa.Web.Models;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace CodeHB.HealthUnitsPoa.Web.Controllers
{
    public class HealthUnitsController : Controller
    {
        HttpClient client = new HttpClient();        

        public HealthUnitsController()
        {
            client.BaseAddress = new Uri("http://datapoa.com.br");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
        }

        // GET: HealthUnits
        public ActionResult Index()
        {
            List<Record> units = new List<Record>();

            HttpResponseMessage response = client.GetAsync("/api/action/datastore_search?resource_id=ecf0e670-2968-4a01-b256-69f64e3e9ca2").Result;

            if (response.IsSuccessStatusCode)
            {
                var ret = response.Content.ReadAsAsync<HealthUnit>().Result;
                units = ret.Result.Records;

                foreach (var un in units)
                {
                    var sCoord = new GeoCoordinate(-29.940156409146375, -50.99966549999999);
                    var eCoord = new GeoCoordinate(un.Latitude, un.Longitude);

                    un.Distance = Math.Round((sCoord.GetDistanceTo(eCoord)/1000), 1);                   
                }
            }

            return View(units.OrderBy(d => d.Distance));
        }

        public ActionResult ListUnits(string startAddress)
        {
           
            TempData["startAddress"] = startAddress;

            return RedirectToAction("Index");
        }

        public ActionResult GetRoute(string startAddress, string endAddress)
        {
            Route route = new Route();
            route.StartAddress = startAddress;
            route.EndAddress = endAddress;

            return View(route);
        }
    }
}