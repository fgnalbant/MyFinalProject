using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product> // Entity içindeki product ile ilgili veritabanı operasyonları interface'im.
    {
        List<ProductDetailDto> GetProductDetails();
    }        
}
