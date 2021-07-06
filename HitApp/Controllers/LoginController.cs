using HitApp.Models;
using HitApp.Repositories;
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
        private readonly UserRepository userRepository;

        public LoginController()
        {
            context = new ApplicationDbContext();
            userRepository = new UserRepository(context);
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
            if (userRepository.GetUserDetails(user.UserName, user.PassWord) == null)
            {
                user.LoginErrorMessage = "Wrong username or password";

                return View("Index", user);
            }
            else
            {
                Session["userId"] = user.UserId;
                Session["userName"] = user.UserName;
                
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