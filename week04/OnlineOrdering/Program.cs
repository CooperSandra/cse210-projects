using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1640 Lincoln St", "Chicago", "IL", "USA");
        Customer customer1 = new Customer("AnnMarie Cooper", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Lenovo Laptop", "SN92680", 1299.99, 1));
        order1.AddProduct(new Product("Wireless Mouse Set", "SN89243", 24.99, 1));

        Address address2 = new Address("51 Bay Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Kenan Swain", address2);
        Order order2 = new Order(customer2);
        order1.AddProduct(new Product("Acer Gaming Desktop", "i7-14700F", 1494.99, 1));
        order1.AddProduct(new Product("Samsung Odyssey Monitor", "6549291", 1499.99, 1));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
        Console.WriteLine();
    }
}