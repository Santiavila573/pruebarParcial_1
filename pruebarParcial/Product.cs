using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Capa de Lógica de Negocio

// Clase base para representar un producto
public class Product
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public float Tax { get; set; }

    public virtual decimal CalculateTotal()
    {
        return Price + (Price * (decimal)Tax);
    }

    public override string ToString()
    {
        return $"{Id} {Description}" +
               $"\n     Price......:   ${Price.ToString("N2", CultureInfo.InvariantCulture)}" +
               $"\n     Tax........:        {(Tax * 100).ToString("N2", CultureInfo.InvariantCulture)}%" +
               $"\n     Value......:   ${CalculateTotal().ToString("N2", CultureInfo.InvariantCulture)}";
    }
}
