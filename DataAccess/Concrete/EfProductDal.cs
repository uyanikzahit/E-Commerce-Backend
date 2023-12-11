using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ECommerceContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId

                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName, UnitsInStock = p.UnitInStockt

                             };
            return result.ToList();

            }


         }
    }
}

