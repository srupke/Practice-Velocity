using PV.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PV.UI.MVCApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<SelectListItem> providers = new List<SelectListItem>();

            List<string> providerList = EventProviderManager.ProviderList();

            for (int i = 0; i < providerList.Count; i++)
			{
                string providerName = providerList[i];

                providers.Add(new SelectListItem() { Value = i.ToString(), Text = providerName });
			}            

            ViewData["ddlEventProvider"] = providers;

            return View();
        }

        public ActionResult GetResults(string providerName)
        {
            EventTypeBase provider = EventProviderManager.Providers[providerName];

            return PartialView(provider.GetResults());
        }

    }
}
