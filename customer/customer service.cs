
using System.Collections.Generic;

namespace Cosmetic_Store_Management_system
{
    internal class customer_service
    {
        private customer_repository repos;
        private List<customers> customer_list;

        public customer_service()
        {
            repos = new customer_repository();
            customer_list = repos.get_all_cust();
        }

        // add customer
        public bool add_customer(customers customer)
        {
            if (customer == null)
                return false;

            if (customer.name == "")
                return false;

            if (customer.product_name == "")
                return false;

            if (customer.quantity <= 0)
                return false;

            if (customer.total_bill <= 0)
                return false;

            customer_list.Add(customer);

            repos.save_all_cust(customer_list);

            return true;
        }

        // view all customers
        public List<customers> view_customers()
        {
            return customer_list;
        }

        // Customer ka record clear karna
        public void clear_customers()
        {
            customer_list.Clear();
            repos.clearall();
        }
    }
}
