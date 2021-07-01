using HitApp.Models;
using HitApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HitApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext context;

        public SupplierController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Supplier
        public ActionResult Create()
        {
            //var countries = context.Countries.ToLookup(c=>c.CountryId);
           // var supcountry = context.Suppliers.ToLookup(s => s.CountryId);
            var countries = context.Countries.ToList();
            var kindsOfSuppliers=context.KindsOfSuppliers.ToList();
            var viewModel = new SupplierFormViewModel
            {
                Countries = countries,
                KindsOfSuppliers = kindsOfSuppliers
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(SupplierFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Countries = context.Countries.ToList();
                viewModel.KindsOfSuppliers = context.KindsOfSuppliers.ToList();

                return View("Create", viewModel);
            }
                

            var supplier = new Supplier
            {
                Name=viewModel.Name,
                KindsOfSupplierId=viewModel.KindsOfSupplierId,
                TIN=viewModel.TIN,
                Address=viewModel.Address,
                PhoneNumber=viewModel.PhoneNumber,
                Email=viewModel.Email,
                CountryId=viewModel.CountryId
            };

            context.Suppliers.Add(supplier);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}