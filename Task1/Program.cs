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
/*Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

Разработать класс для моделирования объекта «Товар». 
Предусмотреть члены класса 
«Код товара» (целое число), 
«Название товара» (строка), 
«Цена товара» (вещественное число).
Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] pArray = new Product[5];
            string json = "";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            for (int i = 0; i < 5; i++)
            {
                pArray[i] = new Product();
                Console.WriteLine($"Введите код для {i+1}-го товара:");
                pArray[i].Code = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Введите имя {i+1}-го товара:");
                pArray[i].Name = Console.ReadLine();
                Console.WriteLine($"Введите цену {i+1}-го товара:");
                pArray[i].Price = Double.Parse(Console.ReadLine());
            }
            json = JsonSerializer.Serialize(pArray, options);
            string path = "D:/Products.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
            }

            Console.ReadKey();
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
}
