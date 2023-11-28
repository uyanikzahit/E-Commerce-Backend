using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpPost("add")]
        public ActionResult Add([FromForm] IFormFile file, [FromForm] ProductImage productImage) 
        {
            var result = _productImageService.Add(file, productImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public ActionResult Delete(ProductImage productImage)
        {
            var productDeleteImage = _productImageService.GetByImageId(productImage.ImageId).Data;
            var result =_productImageService.Delete(productDeleteImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update([FromForm] IFormFile file, [FromBody] ProductImage productImage)
        {
            var result = _productImageService.Update(file, productImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public ActionResult GetAll() 
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyimageid")]
        public ActionResult GetByImageId(int imageId)
        {
            var result = _productImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyproductid")]
        public ActionResult GetByProductId(int productId)
        {
            var result = _productImageService.GetByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
