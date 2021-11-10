using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;
using System.Web.Script.Serialization;
/*Необходимо разработать программу для получения информации о товаре из json-файла.
Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:/Products.json";
            string json = "";
            double maxPrice = 0;
            string maxName = "";
            StreamReader sr = new StreamReader(path);
            using (sr)
            {
                json = sr.ReadToEnd();
            }
            //Пришлось использовать JavaScriptSerializer, потому что с JsonSerializer что-то массив не вытаскивался
            //Или я чего-то не понял как там вытягивать массив объектов
            Product[] pArray = new JavaScriptSerializer().Deserialize<Product[]>(json);

            foreach (Product p in pArray)
            {
                if (maxPrice<p.Price)
                {
                    maxPrice = p.Price;
                    maxName = p.Name;
                }
            }
            Console.WriteLine($"Самый дорогой товар - {maxName}");
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
