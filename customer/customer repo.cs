
using System;
using System.Collections.Generic;
using System.IO;

namespace Cosmetic_Store_Management_system
{
    internal class customer_repository
    {
        private readonly string _filepath =
        @"D:\2nd semester\Object Oriented Programing\oop lab tasks\project C#\Cosmetic Store Management system\Cosmetic Store Management system\customer.txt";

        public void save_customer(customers customers)
        {
            using (StreamWriter write = new StreamWriter(_filepath, true))
            {
                write.WriteLine(customers.ToString());
            }
        }
        public void save_all_cust(List<customers> customers)
        {
            using (StreamWriter stream = new StreamWriter(_filepath, false))
            {
                stream.WriteLine("Customer Name,Product Name,quantity,total bill");
                foreach (var cust in customers)
                {
                    stream.WriteLine(cust.ToString());
                }
            }
        }
        public List<customers> get_all_cust()
        {
            List<customers> customers = new List<customers>();

            if (!File.Exists(_filepath))
            {
                return customers;
            }

            using (StreamReader reade = new StreamReader(_filepath))
            {
                string line;

                while ((line = reade.ReadLine()) != null)
                {
                    if (line == "" || line == "Customer Name,Product Name,quantity,total bill")
                    {
                        continue;
                    }

                    string[] data = line.Split(',');

                    if (data.Length == 4)
                    {
                        customers cust = new customers(
                            data[0],
                            data[1],
                            int.Parse(data[2]),
                            int.Parse(data[3])
                        );

                        customers.Add(cust);
                    }
                }
            }

            return customers;
        }


        public void clearall()
        {
            File.WriteAllText(_filepath, string.Empty);
        }
    }
}
