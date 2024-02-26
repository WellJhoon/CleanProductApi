using CleanVentor.Aplication.Interfaces;
using CleanVentor.Domain.Models;
using System.Collections.Generic;

namespace CleanVentor.Aplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Products CreateProduct(Products products)
        {
            return _productRepository.CreateProduct(products);
        }

        public List<Products> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Products GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void UpdateProduct(Products product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
