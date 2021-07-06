using HitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitApp.Repositories
{
    public class KindsOfSuppliersRepository
    {
        private readonly ApplicationDbContext _context;
        public KindsOfSuppliersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}