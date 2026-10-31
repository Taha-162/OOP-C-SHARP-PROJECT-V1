using System;
using System.Collections.Generic;
using System.IO;

namespace Cosmetic_Store_Management_system
{
    internal class repository
    {
        private readonly string _filepath =
           @"D:\2nd semester\Object Oriented Programing\oop lab tasks\project C#\Cosmetic Store Management system\Cosmetic Store Management system\product.txt.txt";

        public void save(product product)
        {
            using (StreamWriter stream = new StreamWriter(_filepath, true))
            {
                stream.WriteLine(product.ToString());
            }
        }

        public void saveall(List<product> products)
        {
            

            using (StreamWriter stream = new StreamWriter(_filepath, false))
            {
                stream.WriteLine("Product Name,Price,Stock,Discount");
                foreach (var prod in products)
                {
                    stream.WriteLine(prod.ToString());
                }

                
            }
        }

        

        public List<product> GetAll()
        {
            List<product> products = new List<product>();

            if (!File.Exists(_filepath))
            {
                return products;
            }

            using (StreamReader read = new StreamReader(_filepath))
            {
                string line;

                while ((line = read.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        continue;
                    }

                    string[] data = line.Split('|');

                    if (data.Length == 4)
                    {
                       
                            product prod = new product(
                                data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]));

                            products.Add(prod);
                        
                    }
                }
            }

            return products;
        }

       

        public void clearall()
        {
            File.WriteAllText(_filepath, string.Empty);
        }
    }
}