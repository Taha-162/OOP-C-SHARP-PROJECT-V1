using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_Store_Management_system
{
    internal class product
    {
        public string name;
        public int price;
        public int stock;
        public int discount;
        public product(string name, int price, int stock, int discount)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.discount = discount;
        }

        public override string ToString()
        {
            return name + "," + price + "," + stock + "," + discount;
        }
    }
}
