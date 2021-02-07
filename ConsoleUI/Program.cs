using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFrameWork;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            //Data Transformation Object - DTO
            ProductTest();
            //IoC Container öğrenince new kullanmayacağız
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+"/"+product.CategoryName);
            }
        }
    }
}
