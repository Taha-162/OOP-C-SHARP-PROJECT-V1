
using System;
using System.Collections.Generic;

namespace Cosmetic_Store_Management_system
{
    internal class store_ui
    {
        private store_service service;
        private customer_service customer_service;
        private customer_ui customer_ui;

        public store_ui()
        {
            service = new store_service();
            customer_service = new customer_service();
            customer_ui = new customer_ui();
        }

        public void clear_screen()
        {
            Console.Clear();
        }

        public void pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Display all product :-)
        public void show_products(List<product> prod)
        {
            Console.WriteLine();
            Console.WriteLine("---PRODUCTS---");
            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("Product Name\t\tPrice\t\tStock\t\tDiscount");

            if (prod.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                foreach (product products in prod)
                {
                    Console.WriteLine($"{products.name}\t\t{products.price}\t\t{products.stock}\t\t{products.discount}%");
                }
            }
        }

        // Main Menu
        public void main_menu()
        {
            while (true)
            {
                clear_screen();

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----COSMETIC STORE MANAGEMENT SYSTEM---");
                Console.WriteLine("----------------------------------------------");

                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3.page_problem1 menu");
                Console.WriteLine("4. problem2 menu");
                   
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    admin_login();
                }
                else if (choice == "2")
                {
                    user_menu();
                }
                else if (choice == "3")
                {
                    problemonemeun();
                }
                else if(choice=="4")
                {
                    second_problem();
                }
                else if (choice == "5")
                {
                    clear_screen();
                    Console.WriteLine("Thank you for using Cosmetic Store  Management System :-D ");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    pause();
                }
            }
        }

        // Admin Login
        public void admin_login()
        {
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                clear_screen();

                Console.WriteLine("----------ADMIN LOGIN----------");

                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == "taha" && password == "7271")
                {
                    Console.WriteLine("Login successful! :-D");
                    pause();

                    admin_menu();
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect username or password.");
                    Console.WriteLine("Attempts remaining: " + (3 - attempt));

                    pause();
                }
            }

            Console.WriteLine("Maximum attempts reached.:-(");
            pause();
        }

        // Admin Menu
        public void admin_menu()
        {
            while (true)
            {
                clear_screen();

                Console.WriteLine("-------- ADMIN MENU ----------");

                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. View Low Stock Items");
                Console.WriteLine("7. Apply Discount");
                Console.WriteLine("8. Total Inventory Value");
                Console.WriteLine("9. View Customers");
                Console.WriteLine("10. Logout");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    clear_screen();
                    show_products(service.view_product());
                    pause();
                }
                else if (choice == "2")
                {
                    add_productui();
                }
                else if (choice == "3")
                {
                    update_productui();
                }
                else if (choice == "4")
                {
                    delete_productui();
                }
                else if (choice == "5")
                {
                    search_productui();
                }
                else if (choice == "6")
                {
                    low_stockui();
                }
                else if (choice == "7")
                {
                    discountui();
                }
                else if (choice == "8")
                {
                    inventory_valueui();
                }
                else if (choice == "9")
                {
                    clear_screen();

                    // Load latest customer records
                    customer_ui = new customer_ui();
                    customer_ui.view_customers();
                }
                else if (choice == "10")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    pause();
                }
            }
        }

        // Add Product
        public void add_productui()
        {
            clear_screen();

            Console.WriteLine("------ ADD PRODUCT ---------");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Enter stock: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter discount: ");
            int discount = int.Parse(Console.ReadLine());

            product product = new product(name, price, stock, discount);

            service.add_product(product);

            Console.WriteLine("Product added successfully:-)");
            pause();
        }

        // Update Product
        public void update_productui()
        {
            clear_screen();

            Console.WriteLine("-------- UPDATE PRODUCT --------");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            product product = service.search_product(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.Write("Enter new price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Enter new stock: ");
                int stock = int.Parse(Console.ReadLine());

                service.update_product(name, price, stock);

                Console.WriteLine("Product Update sucessfully :-)");
            }

            pause();
        }

        // Delete Product
        public void delete_productui()
        {
            clear_screen();

            Console.WriteLine("------ DELETE PRODUCT -----");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            product product = service.search_product(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                service.delete_product(name);

                Console.WriteLine("Delete request completed.");
            }

            pause();
        }

        // Search Product
        public void search_productui()
        {
            clear_screen();

            Console.WriteLine("-------- SEARCH PRODUCT --------");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            product product = service.search_product(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                List<product> products = new List<product>();

                products.Add(product);

                show_products(products);
            }

            pause();
        }

        // Low Stock Products
        public void low_stockui()
        {
            clear_screen();

            Console.WriteLine("--------- LOW STOCK PRODUCTS ---------");

            List<product> products = service.view_product();

            List<product> lowstock = new List<product>();

            foreach (product product in products)
            {
                if (product.stock <= 5)
                {
                    lowstock.Add(product);
                }
            }

            show_products(lowstock);

            pause();
        }

        // Apply Discount
        public void discountui()
        {
            clear_screen();

            Console.WriteLine("-------- APPLY DISCOUNT ----------");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            product product = service.search_product(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.Write("Enter discount percentage: ");
                int discount = int.Parse(Console.ReadLine());

                service.apply_discount(name, discount);

                Console.WriteLine("Dicount apply sucessfully :-)");
            }

            pause();
        }

        // Total Inventory Value
        public void inventory_valueui()
        {
            clear_screen();

            Console.WriteLine("---------- INVENTORY VALUE ----------");

            List<product> products = service.view_product();

            int total = 0;

            foreach (product product in products)
            {
                int discount =product.price - (product.price * product.discount / 100);

                total = total + (discount * product.stock);
            }

            Console.WriteLine("Total Inventory Value: " + total);

            pause();
        }

        // User Menu
        public void user_menu()
        {
            while (true)
            {
                clear_screen();

                Console.WriteLine("-------- USER MENU -------");

                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Buy Product");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Check Product Stock");
                Console.WriteLine("5. View Discount Offers");
                Console.WriteLine("6. Logout");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    clear_screen();
                    show_products(service.view_product());
                    pause();
                }
                else if (choice == "2")
                {
                    buy_productui();
                }
                else if (choice == "3")
                {
                    search_productui();
                }
                else if (choice == "4")
                {
                    check_stockui();
                }
                else if (choice == "5")
                {
                    discount_offersui();
                }
                else if (choice == "6")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    pause();
                }
            }
        }

        // Buy Product
        public void buy_productui()
        {
            clear_screen();

            Console.WriteLine("--------- BUY PRODUCT ----------");

            Console.Write("Enter your name: ");
            string customername = Console.ReadLine();

            if (customername == "")
            {
                Console.WriteLine("Customer name cannot be empty.");
                pause();
                return;
            }

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            product products = service.search_product(name);

            if (products == null)
            {
                Console.WriteLine("Product not found.");
                pause();
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                pause();
                return;
            }

            if (products.stock < quantity)
            {
                Console.WriteLine("Not enough stock.");
                pause();
                return;
            }

            // Calculate final bill
            int discount =products.price - (products.price * products.discount / 100);

            int bill = discount * quantity;

            // Extra 5% discount on bills of 1500 or more
            if (bill >= 1500)
            {
                bill = bill - (bill * 5 / 100);
            }

            // Update product stock through service
            string result = service.buy_product(name, quantity);

            Console.WriteLine(result);

            if (result != "Product not found." &&
                result != "Quantity must be greater than zero." &&
                result != "Not enough stock.")
            {
                customers customer = new customers(
                    customername, name, quantity, bill);

                bool saved = customer_service.add_customer(customer);

                if (saved == true)
                {
                    Console.WriteLine("Customer record saved successfully.");
                }
                else
                {
                    Console.WriteLine("Customer record could not be saved.");
                }
            }

            pause();
        }

        // Check Product Stock
        public void check_stockui()
        {
            clear_screen();

            Console.WriteLine("========== CHECK PRODUCT STOCK ==========");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            product product = service.search_product(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.WriteLine("Product Name: " + product.name);
                Console.WriteLine("Available Stock: " + product.stock);
            }

            pause();
        }

        // View Discount Offers
        public void discount_offersui()
        {
            clear_screen();

            Console.WriteLine("========== DISCOUNT OFFERS ==========");

            List<product> products = service.view_product();

            List<product> offers = new List<product>();

            foreach (product product in products)
            {
                if (product.discount > 0)
                {
                    offers.Add(product);
                }
            }

            show_products(offers);

            pause();
        }
        //problem 1
        public void problemonemeun()
        {
            clear_screen() ;
            Console.WriteLine("problem 1 menu");
            Console.WriteLine("1.first page");
            Console.WriteLine("N.Next Page");
            Console.WriteLine("P.Previous page");
            Console.WriteLine("L.Last page");
            Console.WriteLine("X.Exit ");
            string choice= Console.ReadLine();
            while (true)
            {

                if (choice == "1")
                {
                    show_products(service.first_page());
                }
                else if (choice == "N")
                {
                    show_products(service.second_page());
                }
                else if(choice == "P")
                {
                    show_products(service.first_page());
                }
                else if( choice == "L")
                {
                    show_products(service.last_page());
                }
                else if(choice == "X")
                {
                    clear_screen();
                    break;
                }
                else
                {
                    Console.WriteLine("invalid chocie");
                }
                Console.WriteLine("Thanx for using our system");
                pause();
            }
            
        }
        // problem 2
        public void second_problem()
        {
            clear_screen();
            Console.WriteLine("problem 2 menu");
            Console.WriteLine("1.product_catagory");
            Console.WriteLine("2.total_count");
            Console.WriteLine("3.highest value");
            Console.WriteLine("4.Exit ");
            string choice = Console.ReadLine();
            while (true)
            {
                if (choice == "1")
                {
                    show_products(service.filter(300));
                }
                else if (choice == "2")
                {
                    show_products(service.counts(300));
                }
                else if (choice == "3")
                {
                    show_products(service.shighest(300));
                }
                
                else if (choice == "4")
                {
                    clear_screen();
                    break;
                }
                else
                {
                    Console.WriteLine("invalid chocie");
                }
                Console.WriteLine("Thanx for using our system");
                pause();
            }

        }

    }
}
