﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //Soyut nesne ile bağlantı kuracağız. Ne inmemory ismi geçecek ne de entity frame work ismi geçecek

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();
            //Bir iş sınıfı başka sınıfları new lemez.
            return _productDal.GetAll();
        }
    }
}
