using HitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitApp.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User GetUserDetails(string userName, string userPassword)
        {
            return _context.Users
                .Where(u => u.UserName == userName && u.PassWord == userPassword)
                .FirstOrDefault();
        }
    }
}