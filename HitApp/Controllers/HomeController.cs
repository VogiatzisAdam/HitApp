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

        public ActionResult IndexAdmin(string sortOrder)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParam = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewBag.SuppliersRoleSortParam = sortOrder == "suppliersRole_asc" ? "suppliersRole_desc" : "suppliersRole_asc";
            ViewBag.TinSortParam = sortOrder == "tin_asc" ? "tin_desc" : "tin_asc";
            ViewBag.AddressSortParam = sortOrder == "address_asc" ? "address_desc" : "address_asc";
            ViewBag.PhonNumberSortParam = sortOrder == "phoneNumber_asc" ? "phoneNumber_desc" : "phoneNumber_asc";
            ViewBag.EmailSortParam = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            ViewBag.CountrySortParam = sortOrder == "country_asc" ? "country_desc" : "country_asc";

            var suppliers = context.Suppliers
                .Include(k => k.KindOfSupplier)
                .Include(c => c.Country);

            switch (sortOrder)
            {
                case "name_desc":suppliers= suppliers.OrderByDescending(n => n.Name); break;
                case "id_desc":suppliers = suppliers.OrderByDescending(n => n.SupplierId);break;     
                case "id_asc":suppliers = suppliers.OrderBy(n => n.SupplierId);break;     
                case "suppliersRole_desc":suppliers= suppliers.OrderByDescending(n => n.KindOfSupplier.Heading); break;
                case "suppliersRole_asc":suppliers= suppliers.OrderBy(n => n.KindOfSupplier.Heading); break;
                case "tin_desc":suppliers= suppliers.OrderByDescending(n => n.TIN.ToString()); break;
                case "tin_asc":suppliers= suppliers.OrderBy(n => n.TIN.ToString()); break;
                case "address_desc":suppliers= suppliers.OrderByDescending(n => n.Address); break;
                case "address_asc":suppliers= suppliers.OrderBy(n => n.Address); break;
                case "phoneNumber_desc":suppliers= suppliers.OrderByDescending(n => n.PhoneNumber.ToString()); break;
                case "phoneNumber_asc":suppliers= suppliers.OrderBy(n => n.PhoneNumber.ToString()); break;
                case "email_desc":suppliers= suppliers.OrderByDescending(n => n.Email); break;
                case "email_asc":suppliers= suppliers.OrderBy(n => n.Email); break;
                case "country_desc":suppliers= suppliers.OrderByDescending(n => n.Country.Name); break;
                case "country_asc":suppliers= suppliers.OrderBy(n => n.Country.Name); break;

                default:suppliers= suppliers.OrderBy(s => s.Name); break;

            }

                    return View("Index",suppliers);
        }

        public ActionResult Index()
        {
            var suppliers = context.Suppliers
                .Include(k => k.KindOfSupplier)
                .Include(c => c.Country);

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