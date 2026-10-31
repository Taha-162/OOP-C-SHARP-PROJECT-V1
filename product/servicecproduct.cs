
using System.Collections.Generic;

namespace Cosmetic_Store_Management_system
{
    internal class store_service
    {
        private repository repo; //object banaya ha repository ka
        private List<product> products; //product ki list pass ki ha

        //ab constructor banana ha
        public store_service()
        {
            repo = new repository();
            products = repo.GetAll();
            if (products.Count == 0)
            {
                products.Add(new product("medoralipstick", 200, 19, 0));
                products.Add(new product("pondsfacewash", 300, 12, 0));
                products.Add(new product("coverfoundation", 650, 9, 0));
                products.Add(new product("xqmbase", 300, 10, 5));
                products.Add(new product("hudabeautyprimer", 250, 5, 10));

                repo.saveall(products);
            }
        }


        //functions

        //view product
        public List<product> view_product()
        {
            return products;
        }

        //  searchh product
        public product search_product(string name)
        {
            foreach (var product in products)
            {
                if(product.name == name)
                {
                    return product;
                }
            }
            return null;
        }

        //add product
        public bool add_product(product product)
        {
            
            //agr product null enter hota ha to false return krdo,ya pichla project jasa user input krta ha to wo bhi false return krdo 

            if (product == null)
            {
                return false;
            }
            if (product.name == "")
            {
                return false;
            }
            if (search_product(product.name) != null)
            {
                return false;
            }
            // discount 0 or 0 sa zayada or 100 sa kam ho or price or stock negittive or 0 na ho
            if (product.price <= 0 || product.stock <= 0 || product.discount < 0 || product.discount > 100)
            {
                return false;
            }
            products.Add(product);
            repo.saveall(products);
            return true;
        }
        // update product
        public bool update_product(string name, int price, int stock)
        {
            product produc = search_product(name);
            if (produc == null)
            {
                return false;
            }
            if (price <= 0 || stock <= 0)
            {
                return false;
            }
            produc.price = price;
            produc.stock = stock;
            repo.saveall(products);
            return true;

        }
        //delete product
        public bool delete_product(string name)
        {
            product product = search_product(name);
            if (product == null)
            {
                return false;
            }
            products.Remove(product);
            repo.saveall(products);
            return true;
        }
        //low stock product
        public List<product> low_stockproduct()
        {
            List<product> low = new List<product>();
            foreach (var product in products)
            {
                if (product.stock < 7)
                {
                    low.Add(product);
                }
            }
            return low;
        }
        //apply discount
        public bool apply_discount(string name, int discount)
        {
            product product= search_product(name);
            if(product == null)
            {
                return false;
            }
            if (discount < 0 || discount > 100)
            {
                return false;
            }
            product.discount = discount;
            repo.saveall(products);
            return true;
        }
        // total inventry value
        public int total_inventryvalue()
        {
            int total_value = 0;
            foreach(var product in products)
            {
                total_value=total_value+(product.price*product.stock);
            }
            return total_value;
        }
        //check product stock
        public string check_stock(string name)
        {
            product product= search_product(name);
            if( product == null)
            {
                return "product not found:";

            }
            if (product.stock > 0)
            {
                return product.name + " is in stock. quantity: " + product.stock;
            }
            else
            {
                return product.name + "is not in stock :(";
            }
        }
        //discount offer
        public List<product> disocunt_offer()
        {
            List<product> sale = new List<product>();
            foreach(var product in products)
            {
                if (product.discount > 0)
                {
                    sale.Add(product);

                }
            }
            return sale;

        }
        //  buy product
        public string buy_product(string name, int quantity)
        {
            product product = search_product(name);

            if (product == null)
            {
                return "Product not found.";
            }

            if (quantity <= 0)
            {
                return "Quantity must be greater than zero.";
            }

            if (product.stock < quantity)
            {
                return "Not enough stock.";
            }

            int discountedPrice = product.price - (product.price * product.discount / 100);


            int bill = discountedPrice * quantity;

            if (bill >= 1500)
            {
                bill = bill - (bill * 5 / 100);
            }

            product.stock = product.stock - quantity;

            repo.saveall(products);

            return "Purchase successful. Total bill: " + bill;
        }
    }
}