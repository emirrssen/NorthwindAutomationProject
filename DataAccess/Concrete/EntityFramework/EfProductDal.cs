using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetails()
        {
            using (var context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join category in context.Categories
                             on p.CategoryId equals category.CategoryId
                             select new ProductDetailsDto
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = category.CategoryName,
                                 QuantityPerUnit = p.QuantityPerUnit,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock,
                                 Rate = p.TotalRates / p.NumberOfRates
                             };

                return result.ToList();
            }
        }
    }
}
