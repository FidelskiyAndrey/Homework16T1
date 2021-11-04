using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Homework16T1
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Product [] products = new Product[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Опишите товар {0}",i+1);

                Console.WriteLine("Введите код товара");
                int Code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите имя товара");
                string Name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double Price = Convert.ToDouble(Console.ReadLine());
               
                Product product =new Product(Code,Name,Price);

                products[i] = product;

            }
           
            string jsonProduct = JsonSerializer.Serialize(products);
            Console.WriteLine(jsonProduct);
            Console.ReadKey();

            string path = @"C:\Users\andrey\Serialize.json";
            FileStream fs = File.Create(path);
            fs.Close();
            
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(jsonProduct);
            }
        }
    }public class Product
    {

        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
       

        public Product(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
    
}
