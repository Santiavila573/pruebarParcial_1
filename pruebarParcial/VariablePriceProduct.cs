using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VariablePriceProduct : Product
{
    public string Measurement { get; set; }
    public float Quantity { get; set; }

    public override decimal CalculateTotal()
    {
        return Price * (decimal)Quantity + (Price * (decimal)Tax);
    }

    public override string ToString()
    {
        return $"{Id} {Description}" +
               $"\n     Measurement: {Measurement}" +
               $"\n     Quantity...:         {Quantity.ToString("N2", CultureInfo.InvariantCulture)}" +
               $"\n     Price......:   ${Price.ToString("N2", CultureInfo.InvariantCulture)}" +
               $"\n     Tax........:        {(Tax * 100).ToString("N2", CultureInfo.InvariantCulture)}%" +
               $"\n     Value......:   ${CalculateTotal().ToString("N2", CultureInfo.InvariantCulture)}";
    }
}