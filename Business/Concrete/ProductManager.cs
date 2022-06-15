using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _iProductDal;
        public ProductManager(IProductDal iProductDal)
        {
            _iProductDal = iProductDal;
        }

        public List<Product> GetAll()
        {
            return _iProductDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _iProductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _iProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
