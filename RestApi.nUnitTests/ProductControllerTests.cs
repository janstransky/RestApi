using Data;
using Microsoft.EntityFrameworkCore;
using RestApi.Controllers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RestApi.nUnitTests
{
    public class ProductControllerTests
    {
        /// <summary>
        /// test get all products
        /// </summary>
        [Test]
        public void GetProducts_Equal()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
             .UseInMemoryDatabase(databaseName: "ProductListProducts")
             .Options;

            using (var _context = new ProductContext(options))
            {
                _context.Products.Add(new Product() { productId = "10", quantity = 5 });
                _context.Products.Add(new Product() { productId = "15", quantity = 7 });
                _context.Products.Add(new Product() { productId = "20", quantity = 10 });
                _context.SaveChanges();

                ProductController productController = new ProductController(_context);

                //act
                productController.GetProducts();

                //Assert
                Assert.AreEqual(3, _context.Products.Count());
            }
        }

        /// <summary>
        /// test get product
        /// </summary>
        /// <param name="quantity"></param>
        [Test]
        public void GetProduct_Equal()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
             .UseInMemoryDatabase(databaseName: "ProductListProduct")
             .Options;

            //options.
            using (var _context = new ProductContext(options))
            {
                _context.Products.Add(new Product() { productId = "10", quantity = 5 });
                _context.Products.Add(new Product() { productId = "15", quantity = 7 });
                _context.Products.Add(new Product() { productId = "20", quantity = 10 });
                _context.SaveChanges();

                ProductController productController = new ProductController(_context);

                //act
                var product = productController.GetProduct("10");

                //Assert
                Assert.IsNotNull(product);
            }
        }
    }
}
