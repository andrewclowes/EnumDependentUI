using EnumDependentUI.Infrastructure.Enumerations;
using EnumDependentUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnumDependentUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EnumDependent()
        {
            var categoriesArray = (OfferCategories[])Enum.GetValues(typeof(OfferCategories));

            // Do the availableTypes check on the following line in the Vouchercloud code
            var typesArray = ((OfferTypes[])Enum.GetValues(typeof(OfferTypes))).Where(x => (x & (OfferTypes)categoriesArray[0]) != 0).ToArray();

            var model = new EnumDependentViewModel
            {
                OfferCategories = (OfferCategories[])Enum.GetValues(typeof(OfferCategories)),
                OfferTypeGroup = getTypeObjects((int)categoriesArray[0]),
                OfferCategory = ((OfferCategories[])Enum.GetValues(typeof(OfferCategories)))[0],
                OfferType = typesArray[0]
            };

            return View(model);
        }

        public async Task<ActionResult> OfferTypes(int id)
        {
            var typesArray = getTypeObjects(id);
             
            return Json(typesArray, JsonRequestBehavior.AllowGet);
        }

        private object[] getTypeObjects(int id)
        {
            return ((OfferTypes[])Enum.GetValues(typeof(OfferTypes))).Where(x => (x & (OfferTypes)id) != 0).Select(t => new { name = Enum.GetName(typeof(OfferTypes), t), val = t }).ToArray();
        }
    }
}