using CodeHB.HealthUnitsPoa.Web.Models;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

            if (TempData["startAddress"] != null)
            {
                HttpResponseMessage response = client.GetAsync("/api/action/datastore_search?resource_id=ecf0e670-2968-4a01-b256-69f64e3e9ca2").Result;
                if (response.IsSuccessStatusCode)
                {
                    var ret = response.Content.ReadAsAsync<HealthUnit>().Result;
                    units = ret.Result.Records;

                    double latitude;
                    double longitude;

                    GetCoordinates(out latitude, out longitude, TempData["startAddress"].ToString());

                    foreach (var un in units)
                    {
                        var sCoord = new GeoCoordinate(latitude, longitude);
                        var eCoord = new GeoCoordinate(un.Latitude, un.Longitude);
                        un.Distance = Math.Round((sCoord.GetDistanceTo(eCoord) / 1000), 1);
                    }
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
            Route route = new Route()
            {
                StartAddress = startAddress,
                EndAddress = endAddress
            };
            return View(route);
        }

        public void GetCoordinates(out double latitude, out double longitude, string endereco)
        {
            latitude = 0;
            longitude = 0;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://maps.googleapis.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/maps/api/geocode/json?address=" + endereco + "&key=AIzaSyBqouaVNf0Y3G4fP2VAvde5sDZc3U5C2d4").Result;
            if (response.IsSuccessStatusCode)
            {
                var ret = response.Content.ReadAsAsync<AddressCoordinate>().Result;
                latitude = ret.results[0].geometry.location.lat;
                longitude = ret.results[0].geometry.location.lng;            
            }
        }
    }
}