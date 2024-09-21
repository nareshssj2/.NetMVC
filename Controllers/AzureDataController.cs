using AzureWebApplication1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureWebApplication1.Controllers
{
    public class AzureDataController : Controller
    {
        // GET: AzureData
        private Courserepo _repository = new Courserepo();

        public ActionResult Index()
        {
            var data = _repository.GetAllData();
            return View(data);
        }
    }
}