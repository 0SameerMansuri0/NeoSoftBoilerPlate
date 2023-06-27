using EMartProject.Models;
using EMartProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMartProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       //[Authorize]
       // [Route("api/GetAll")]
        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<Product> allproducts = _productRepository.GetAllProducts();



            return Ok(allproducts);
        }



       // [Route("api/AddProduct")]
        [HttpPost]

        //argumets call model binding
        public IActionResult AddProduct(Product product)
        {

            bool addProductStatus = _productRepository.AddProduct(product);
            return Ok(addProductStatus);
        }


       // [Route("api/DeleteProduct")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productRepository.deleteByI(id);
            return Ok();
        }
        //[Authorize]
        [HttpGet("id")]
       // [Route("api/GetById")]
        public Product GetByProductID(int id)
        {
           Product p= _productRepository.GetByID(id);

            return p;
        }



       // [Route("api/EditProduct")]
        [HttpPut]
        public ActionResult Edit(Product product)
        {
            _productRepository.Update(product);
            return Ok();
        }


    }
}
