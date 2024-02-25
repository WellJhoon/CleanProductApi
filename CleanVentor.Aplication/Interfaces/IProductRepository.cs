using CleanVentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanVentor.Aplication.Interfaces
{
    public interface IProductRepository
    {
        List<Products> GetAllProducts();

        Products CreateProduct(Products product);
    }
}
