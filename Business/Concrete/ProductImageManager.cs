using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        IFileHelper  _fileHelper;

        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
            
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run
        }

        public IResult Delete(ProductImage productImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<ProductImage> GetByImageId(int imageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            throw new NotImplementedException();
        }


        private IResult CheckIfProductImageLimit(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if(result >=7)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private List<ProductImage> CheckIfProductImageNull(int id)
        {
            string path = @"\images\default-product.png";
            var result = _productImageDal.GetAll(p=>p.ProductId == id).Any();
            if(!result)
            {
                return new List<ProductImage>
                {
                    new ProductImage
                    {
                        ProductId = id,
                        ImagePath = path,
                        Date = DateTime.Now,
                    }
                };
            }
            return _productImageDal.GetAll(p => p.ProductId == id);
        }

        
    }
}
