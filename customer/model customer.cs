namespace Cosmetic_Store_Management_system
{
    internal class customers
    {
        public string name;
        public string product_name;
        public int quantity;
        public int total_bill;

        public customers(string name, string product_name,
                        int quantity, int total_bill)
        {
            this.name = name;
            this.product_name = product_name;
            this.quantity = quantity;
            this.total_bill = total_bill;
        }


        public override string ToString()
        {
            return name + "," + product_name + "," +
                   quantity + "," + total_bill;
        }


    }
}