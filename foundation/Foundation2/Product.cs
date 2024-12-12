public class Product
{
    private string _name;
    private string _productId;
    private decimal _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    // Method to calculate the total cost for this product
    public decimal GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }

    // Method to get product details for the packing label
    public string GetProductDetails()
    {
        return $"{_name} ({_quantity}) (ID: {_productId})";
    }
}
