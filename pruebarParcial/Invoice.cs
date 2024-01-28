using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase para representar una factura que contiene varios productos
public class Invoice
{
    private List<Product> products;

    public Invoice()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.CalculateTotal();
        }
        return total;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("INVOICE");
        builder.AppendLine("-------------------------------------------------");
        foreach (var product in products)
        {
            builder.AppendLine(product.ToString());
        }
        builder.AppendLine("-------------------------------------------------");
        builder.AppendLine($"   Total Invoice: ${CalculateTotal().ToString("N2", CultureInfo.InvariantCulture),-10}");
        return builder.ToString();
    }
}