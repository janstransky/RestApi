using Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol;
using System.Text.Json;
using RestApi;

namespace RestApi.Controllers
{
    /// <summary>
    /// product controller
    /// </summary>
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// get id product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(string Id)
        {
            if (_context.Products == null)
                return NotFound();

            var todoItem = await _context.Products.FindAsync(Id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        /// <summary>
        /// insert/update products
        /// </summary>
        /// <param name="sProduct"></param>
        /// <returns></returns>
        [HttpPost(Name = "PostProducts")]
        public async Task<ActionResult<Product>> PostProducts(string sProduct)
        {           
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(sProduct);// JsonConvert.DeserializeObject
            
            foreach (var _product in products)
            {     
                //update
                if (ProductExists(_product.productId))
                    _context.Products.Where(x => x.productId == _product.productId).FirstOrDefault().AddQuantity(_product.quantity);
                //insert
                else
                    _context.Products.Add(_product);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Product>> DeleteMovie(string Id)
        {
            if(_context.Products is null)
                return NotFound();

            var todoItem = await _context.Products.FindAsync(Id);

            if(todoItem == null)
                return NotFound();

            _context.Products.Remove(todoItem);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// dto product
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        private static Product ProductToDTO(Product todoItem) =>
            new Product
        {
          productId = todoItem.productId,
          quantity = todoItem.quantity
        };

        /// <summary>
        /// exists product in db context
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ProductExists(string id)
        {
            return _context.Products.Any(x => x.productId == id);
        }
    }
}
