
using System;
using System.Collections.Generic;

namespace Cosmetic_Store_Management_system
{
    internal class customer_ui
    {
        private customer_service service;

        public customer_ui()
        {
            service = new customer_service();
        }

        public void view_customers()
        {
            List<customers> customer = service.view_customers();

            Console.WriteLine();
            Console.WriteLine("CUSTOMER RECORDS");
            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("Customer Name\tProduct Name\tQuantity\tTotal Bill");

            Console.WriteLine("------------------------------------------------------------");

            if (customer.Count == 0)
            {
                Console.WriteLine("No customer records found.");
            }
            else
            {
                foreach (var cust in customer)
                {
                    Console.WriteLine($"{cust.name}  \t\t {cust.product_name}  \t\t {cust.quantity}  \t\t { cust.total_bill}");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
