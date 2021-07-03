using HitApp.Models;
using HitApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var countries = context.Countries.ToList();
            var kindsOfSuppliers=context.KindsOfSuppliers.ToList();
            var viewModel = new SupplierFormViewModel
            {
                Countries = countries,
                KindsOfSuppliers = kindsOfSuppliers,
                Heading= "Add a Supplier"
            };

            return View("SupplierForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var supplier = context.Suppliers
                .Single(s => s.SupplierId ==id);
            var viewModel = new SupplierFormViewModel
            {
                Id = supplier.SupplierId,
                Heading = "Edit a Supplier",
                Name = supplier.Name,
                KindsOfSuppliers=context.KindsOfSuppliers,
                KindsOfSupplierId=supplier.KindsOfSupplierId,
                TIN = supplier.TIN,
                Address = supplier.Address,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email,
                Countries=context.Countries,
                CountryId = supplier.CountryId,
                IsActive = supplier.IsActive
            };
                             
            return View("SupplierForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SupplierFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Countries = context.Countries.ToList();
                viewModel.KindsOfSuppliers = context.KindsOfSuppliers.ToList();

                return View("SupplierForm", viewModel);
            }

            var supplier = context.Suppliers
                .Single(s => s.SupplierId == viewModel.Id);
            supplier.Name = viewModel.Name;
            supplier.KindsOfSupplierId = viewModel.KindsOfSupplierId;
            supplier.TIN = viewModel.TIN;
            supplier.Address = viewModel.Address;
            supplier.PhoneNumber = viewModel.PhoneNumber;
            supplier.Email = viewModel.Email;
            supplier.CountryId = viewModel.CountryId;
            supplier.IsActive = viewModel.IsActive;

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierFormViewModel viewModel)
        {
            var name = viewModel.Name;
            var exists = context.Suppliers.Any(s => s.Name == name);
            if (exists)
                //return View("The Supplier allready exists");
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (!ModelState.IsValid)
            {
                viewModel.Countries = context.Countries.ToList();
                viewModel.KindsOfSuppliers = context.KindsOfSuppliers.ToList();

                return View("SupplierForm", viewModel);
            }
                

            var supplier = new Supplier
            {
                Name=viewModel.Name,
                KindsOfSupplierId=viewModel.KindsOfSupplierId,
                TIN=viewModel.TIN,
                Address=viewModel.Address,
                PhoneNumber=viewModel.PhoneNumber,
                Email=viewModel.Email,
                CountryId=viewModel.CountryId,
                IsActive =viewModel.IsActive
            };

            context.Suppliers.Add(supplier);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}