using System.Collections.Generic;

class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:";
        foreach (Product product in _products)
        {
            label += $"{System.Environment.NewLine}{product.GetName()} (Product ID: {product.GetProductId()})";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:{System.Environment.NewLine}{_customer.GetName()}{System.Environment.NewLine}{_customer.GetAddress().GetFullAddress()}";
    }
}