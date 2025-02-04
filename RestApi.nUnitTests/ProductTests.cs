using Data;
using Microsoft.EntityFrameworkCore;
using RestApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RestApi.nUnitTests
{
    public class ProductTests
    {
        /// <summary>
        /// prodact quantity test
        /// </summary>
        /// <param name="quantity"></param>
        [TestCase(10)]
        public void ProductQuantity_Equal(int quantity)
        {
            Product _product = new Product();

            _product.AddQuantity(quantity);

            Assert.AreEqual(_product.quantity, quantity);
        }        
    }
}
