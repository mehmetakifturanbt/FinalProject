using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product>
            _products; //Naming convension (isimlendirme standardı) _ alt çizgi global değişken (bu sınıf için) olduğunu bildiriyor

        public InMemoryProductDal() //constractor yani yapıcı metot
        {
            _products = new List<Product>
            {
                //Oracle, Sql Server, Postgres, MongoDb
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product {ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query (Dile gömülü sorgulama)
            // => işaretine Lambda deniliyor
            //Product productToDelete = null;
            //foreach (var p in _products) //Bu foreach yerine linq ile SingleOrDefault(p=>) kodunu kullanıyoruz.
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //SingleOrDefault metodu yerine First veya FirstOrDefault kullansak da olur
            _products.Remove(productToDelete);
            //_products.Remove(product);//yukarıda referans tip olduğu için bu şekilde listeden silme işlemi yapıLAmaz.

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
