using Business.Abstract;
using Business.Constans;
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
            IResult result = BusinessRules.Run(CheckIfProductImageLimit(productImage.ProductId));
            if(result != null)
            {
                return result;
            }
            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll()); 
        }

        public IDataResult<ProductImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p=>p.ImageId == imageId));
        }

        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            var result = BusinessRules.Run(CheckProductImageExists(productId));
            if(result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(GetDefaultImage(productId).Data); 
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p=>p.ProductId == productId));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath=_fileHelper.Update(file, PathConstants.ImagePath + productImage.ImagePath, PathConstants.ImagePath);
            productImage.Date = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
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

        private IResult CheckProductImageExists(int productId)
        {
            var result  = _productImageDal.GetAll(p=>p.ProductId==productId).Count;
            if(result >0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        private IDataResult<List<ProductImage>> GetDefaultImage(int productId)
        {
            List<ProductImage> productImages = new List<ProductImage>();
            productImages.Add(new ProductImage { Date = DateTime.Now, ProductId = productId, ImagePath="DefaultImage.jpg" });
            return new SuccessDataResult<List<ProductImage>>(productImages);
        }

        
    }
}
