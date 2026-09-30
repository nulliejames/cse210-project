using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address domesticAddress = new Address("123 Maple Street", "Rexburg", "Idaho", "USA");
        Customer domesticCustomer = new Customer("Morgan Ellis", domesticAddress);
        Order domesticOrder = new Order(domesticCustomer);
        domesticOrder.AddProduct(new Product("Insulated Water Bottle", "WB-104", 18.50m, 2));
        domesticOrder.AddProduct(new Product("Trail Backpack", "BP-208", 42.00m, 1));

        Address internationalAddress = new Address("45 King Street", "Toronto", "Ontario", "Canada");
        Customer internationalCustomer = new Customer("Jamie Chen", internationalAddress);
        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Travel Mug", "MG-315", 16.75m, 1));
        internationalOrder.AddProduct(new Product("Wool Scarf", "SC-427", 24.50m, 2));
        internationalOrder.AddProduct(new Product("Notebook Set", "NB-532", 8.25m, 3));

        List<Order> orders = new List<Order> { domesticOrder, internationalOrder };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total cost: ${order.GetTotalCost():F2}");
            Console.WriteLine();
        }
    }
}