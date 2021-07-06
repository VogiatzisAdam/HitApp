using HitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HitApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext context;

        public LoginController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorize(User user)
        {
            var userdetails = context.Users.Where(u => u.UserName == user.UserName && u.PassWord == user.PassWord).FirstOrDefault();

            if (userdetails == null)
            {
                user.LoginErrorMessage = "Wrong username or password";

                return View("Index", user);
            }
            else
            {
                Session["userId"] = userdetails.UserId;
                Session["userName"] = userdetails.UserName;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}