using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase para productos compuestos que contienen varios productos
public class ComposedProduct : Product
{
    public float Discount { get; set; }
    public List<Product> Products { get; set; }

    public override decimal CalculateTotal()
    {
        decimal total = 0;

        foreach (var product in Products)
        {
            total += product.CalculateTotal();
        }

        return total - (total * (decimal)Discount);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{Id} {Description}" +
                           $"\n     Products...: {string.Join(", ", Products.Select(p => p.Description))}" +
                           $"\n     Discount...:        {(Discount * 100).ToString("N2", CultureInfo.InvariantCulture)}%" +
                           $"\n     Value......:   ${CalculateTotal().ToString("N2", CultureInfo.InvariantCulture)}");
        return builder.ToString();
    }
}
