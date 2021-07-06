using HitApp.Models;
using HitApp.Repositories;
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
        
        public ActionResult Create()
        {
            //countries, kindsOfSuppliers, "Add a Supplier"
            var countries = context.Countries.ToList();
            var kindsOfSuppliers = context.KindsOfSuppliers.ToList();
            var viewModel = new SupplierFormViewModel()
            {
                Countries = countries,
                KindsOfSuppliers = kindsOfSuppliers,
                Heading = "Add a Supplier"
            };

            return View("SupplierForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var supplier = context.Suppliers
                .Single(s => s.SupplierId == id);
            //supplier.SupplierId,"Edit a Supplier",supplier.Name, context.KindsOfSuppliers,supplier.KindsOfSupplierId,supplier.TIN,supplier.Address,supplier.PhoneNumber,supplier.Email, context.Countries,supplier.CountryId,supplier.IsActive
            var viewModel = new SupplierFormViewModel()
            {
                Id = supplier.SupplierId,
                Heading = "Edit a Supplier",
                Name = supplier.Name,
                KindsOfSuppliers = context.KindsOfSuppliers,
                KindsOfSupplierId = supplier.KindsOfSupplierId,
                TIN = supplier.TIN,
                Address = supplier.Address,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email,
                Countries = context.Countries,
                CountryId = supplier.CountryId,
                IsActive = supplier.IsActive
            };

            return View("SupplierForm", viewModel);
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
            
            supplier.UpdateSupplier(viewModel.Name, viewModel.KindsOfSupplierId, viewModel.TIN, viewModel.Address, viewModel.PhoneNumber, viewModel.Email, viewModel.CountryId, viewModel.IsActive);

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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (!ModelState.IsValid)
            {
                viewModel.Countries = context.Countries.ToList();
                viewModel.KindsOfSuppliers = context.KindsOfSuppliers.ToList();

                return View("SupplierForm", viewModel);
            }

            var supplier = new Supplier(viewModel.Name, viewModel.KindsOfSupplierId, viewModel.TIN, viewModel.Address, viewModel.PhoneNumber, viewModel.Email, viewModel.CountryId, viewModel.IsActive);

            context.Suppliers.Add(supplier);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete (int id)
        {
            var supplier = context.Suppliers
                .Single(s => s.SupplierId == id);

            //supplier.SupplierId, "Edit a Supplier", supplier.Name, context.KindsOfSuppliers, supplier.KindsOfSupplierId, supplier.TIN, supplier.Address, supplier.PhoneNumber, supplier.Email, context.Countries, supplier.CountryId, supplier.IsActive
            var viewModel = new SupplierFormViewModel()
            {
                Id = supplier.SupplierId,
                Heading = "Remove a Supplier",
                Name = supplier.Name,
                KindsOfSuppliers = context.KindsOfSuppliers,
                KindsOfSupplierId = supplier.KindsOfSupplierId,
                TIN = supplier.TIN,
                Address = supplier.Address,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email,
                Countries = context.Countries,
                CountryId = supplier.CountryId,
                IsActive = supplier.IsActive
            };
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupplier (int id)
        {
            var supplier = context.Suppliers
                .SingleOrDefault(s => s.SupplierId == id);

            if (supplier == null)
                return HttpNotFound();

            context.Suppliers.Remove(supplier);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}