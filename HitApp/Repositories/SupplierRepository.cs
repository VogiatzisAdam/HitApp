using HitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HitApp.Repositories
{
    public class SupplierRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        

    }
}