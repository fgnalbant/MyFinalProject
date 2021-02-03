using DataAccess.Abstract;
using Entities.Concrete;
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
        //private object productToDelete;

        public InMemoryProductDal() //bellekte referans aldığı anda çalışacak alan - constractor
        {
            //Simule edebilmek için veritabanından geliyormuş gibi bir tablo oluşturduk.
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product); //yeni bir ürün geldiğinde listeye ekleme
        }

        public void Delete(Product product)
        {
            // LINQ=Language Integrated Query -- Dile bağlı sorgulama
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //(her p için)(p nin prod Id si)(benim gönderdiğim prodId ye eşitse referansı eşitle
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products; //tüm veritabanı döndürülür.
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün ID sine sahip olan listedeki ürünü bul demek.Forech i kısa yoldan yaptık.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;            
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();//içindeki koşula uyanları listeleyip onu listeler.

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
