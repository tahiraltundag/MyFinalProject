using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak",UnitPrice=15, UnitsInStock=18},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera",UnitPrice=500, UnitsInStock=5},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon",UnitPrice=1500, UnitsInStock=32},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=200, UnitsInStock=7},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare",UnitPrice=130, UnitsInStock=56},
            };   
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //SingleOrDefalut bir tane ara demektir. 

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan Listedeki ürünü  bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //SingleOrDefalut bir tane ara demektir. 
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve listeler
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
