using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Task.Models
{
    public class ProductService
    {
        ProductsEntities context;
        public ProductService()
        {
            context = new ProductsEntities();
        }

        public List<ProductDTO> GetProducts(string category)
        {
            var prds = context.GetProducts(category).ToList();
            var products = new List<ProductDTO>();
            foreach (var prd in prds)
            {
                var product = new ProductDTO()
                {
                    Id = prd.Id,
                    ProductName = prd.ProductName,
                    ProductDescription = prd.ProductDescription,
                    Category = prd.Category,
                    Price = prd.Price,
                    ProductImage=prd.ProductImage
                };
                products.Add(product);
            }
            return products;
        }
        public ProductDTO GetProduct(int id)
        {
            var prd = context.GetProduct(id).FirstOrDefault();
            var product = new ProductDTO()
            {
                Id = prd.Id,
                ProductName = prd.ProductName,
                ProductDescription = prd.ProductDescription,
                Category = prd.Category,
                Price = prd.Price,
                ProductImage = prd.ProductImage
            };
            return product;
        }

        public void AddProduct(ProductDTO product)
        {
            context.AddProduct(product.ProductName, product.ProductDescription, product.Category, product.Price,product.ProductImage);
        }

        public void EditProduct(int id, ProductDTO product)
        {
            if (id != product.Id)
                return;
            context.EditProduct(id, product.ProductName, product.ProductDescription, product.Category, product.Price, product.ProductImage);
        }

        public void DeleteProduct(int id)
        {
            context.DeleteProduct(id);
        }
    }
}