using mvcProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace mvcProject.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            IEnumerable<MVCItemModel> itemList;
            HttpResponseMessage response = Globalvariables.WebApiClient.GetAsync("Item").Result;

            string customersString = await response.Content.ReadAsStringAsync();
            itemList = JsonConvert.DeserializeObject<List<MVCItemModel>>(customersString);



            return View(itemList);
        }
    }
}