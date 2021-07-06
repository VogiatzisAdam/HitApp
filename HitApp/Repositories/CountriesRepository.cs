using HitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitApp.Repositories
{
    public class CountriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CountriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}