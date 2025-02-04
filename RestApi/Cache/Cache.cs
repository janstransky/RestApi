using Data;
using System.Text.Json;

namespace RestApi
{
    /// <summary>
    /// test static class
    /// </summary>
    public class Cache
    {
        public static Product[] cacheListProduct { get; set; }

        //public static void SetCache()
        //{
        //    cacheListProduct = new Product[3];
        //    for (int i = 0; i < cacheListProduct.Length; i++)
        //    {
        //        cacheListProduct[i] = new Product()
        //        {
        //            productId = Random.Shared.Next(1, 300).ToString(),
        //            quantity = Random.Shared.Next(1, 100)
        //        };
        //    }          
        //}

        //public static void WriteListToJsonConsole()
        //{
        //    try
        //    {
        //        Console.Out.WriteLine(JsonSerializer.Serialize(cacheListProduct));
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}
    }
}
