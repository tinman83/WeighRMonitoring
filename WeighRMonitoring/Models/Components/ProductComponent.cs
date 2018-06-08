using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
  public class ProductComponent
    {
        //private readonly WeighRDbContext _db;
        //public ProductComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddProduct(Product product)
        {
           
                _db.Products.Add(product);
                _db.SaveChanges();

        }
        public void UpdateProduct(Product product)
        {
            
                _db.Products.Attach(product);
                _db.SaveChanges();
 
        }

        public Product GetProduct(string productCode)
        {
            
                return _db.Products
                    .Where(p => p.ProductCode == productCode).FirstOrDefault();

        }

        public Product GetProductById(int id)
        {
           
                return _db.Products
                    .Where(p => p.ProductId == id).FirstOrDefault();

            
        }

        public List<Product> GetProducts()
        {
           
                return _db.Products.ToList();

            
        }

        public List<Product> GetProductsByProductCode(string productCode)
        {
           
                return _db.Products
                    .Where(p=>p.ProductCode==productCode)
                    .ToList();

            
        }

        public Product GetCurrentProduct()
        {
           
                return _db.Products
                    .Where(p => p.isCurrent == true).FirstOrDefault();

            
        }
        public Product GetLastAddedProduct()
        {
            
                return _db.Products
                    .OrderByDescending(p=>p.ProductId)
                    .Take(1)
                    .FirstOrDefault();

            
        }

        public Product SetCurrentProduct(string productCode)
        {
            
                var previousCurrent= _db.Products
                    .Where(p => p.isCurrent == true).FirstOrDefault();

                if (previousCurrent != null)
                {
                    previousCurrent.isCurrent = false;
                    _db.Products.Attach(previousCurrent);
                }
                    

                var current= _db.Products
                    .Where(p => p.ProductCode == productCode).FirstOrDefault();

                current.isCurrent = true;
                _db.Products.Attach(current);
                _db.SaveChanges();

                return current;
            
        }


    }
}
