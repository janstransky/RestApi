using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Data
{
    public class Product 
    {
        public string productId { get; set; }
        public int quantity { get; set; }

        public Product()
        {
            
        }

        public void AddQuantity(int iQuantity)
        {
            this.quantity += iQuantity;
        }
    }   
}
