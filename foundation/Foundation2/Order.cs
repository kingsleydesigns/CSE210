public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total cost of the order
    public decimal CalculateTotalCost()
    {
        decimal total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += _customer.LivesInUSA() ? 5 : 35;

        return total;
    }

    // Method to generate the packing label
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _products)
        {
            packingLabel += $"- {product.GetProductDetails()}\n";
        }
        return packingLabel;
    }

    // Method to generate the shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}
