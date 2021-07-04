using HitApp.Models;
using HitApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HitApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var suppliers = context.Suppliers
                .Include(k => k.KindOfSupplier)
                .Include(c => c.Country);
            
            //var viewModel = new HomeViewModel
            //{
            //    Suppliers=suppliers
            //};

            return View(suppliers);
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
    }
}