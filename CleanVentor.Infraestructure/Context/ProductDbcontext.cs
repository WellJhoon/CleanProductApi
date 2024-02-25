using CleanVentor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanVentor.Infraestructure.Context
{
    public class ProductDbcontext : DbContext
    {
        public ProductDbcontext(DbContextOptions<ProductDbcontext> options )  : base (options)
        {

        }

        public DbSet<Products> Productss { get; set; }
    }
}
