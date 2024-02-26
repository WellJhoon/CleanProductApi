using CleanVentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanVentor.Aplication.Interfaces
{
    public interface IProductService
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
        void UpdateProduct(Products product);
        void DeleteProduct(int id);
        Products CreateProduct(Products products);
    }
}
