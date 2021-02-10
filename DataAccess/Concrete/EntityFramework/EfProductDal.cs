﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal //EfEntityRep içinde IprodDal ın istediği operasyonlar var.
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName=p.ProductName,
                             CategoryName =c.CategoryName,UnitInStock=p.UnitsInStock};
                //Ürünler ile kategorileri categoryId leri eşit olanlara göre birleştir
                //select kısmındaki sütunları getir.
                return result.ToList();
            }
        }
    }
}
