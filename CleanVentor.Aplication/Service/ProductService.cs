using CleanVentor.Aplication.Interfaces;
using CleanVentor.Domain.Models;


namespace CleanVentor.Aplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        //Ctor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Products CreateProduct(Products products)
        {
           _productRepository.CreateProduct(products);
            return products;
        }

        public List<Products> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return products;
        }
    }
}
