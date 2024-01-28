using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase para representar un recibo con productos específicos
public class Receipt
{
    private List<Product> products;

    public Receipt(List<Product> products)
    {
        this.products = products;
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
        builder.AppendLine("RECEIPT");
        builder.AppendLine("-------------------------------------------------");

        foreach (var product in products)
        {
            builder.AppendLine(product.ToString());
        }

        builder.AppendLine("                   =============");
        builder.AppendLine($"TOTAL:               ${CalculateTotal().ToString("N2", CultureInfo.InvariantCulture),-10}");

        return builder.ToString();
    }
}