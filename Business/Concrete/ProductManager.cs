﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public IResult Add(Product product)
        {
            throw new NotImplementedException();
        }

        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
