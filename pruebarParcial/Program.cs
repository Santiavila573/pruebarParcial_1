using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase principal para interactuar con la capa de interfaz de usuario
class Program
{
    static void Main()
    {
        Console.WriteLine("PRODUCTS");
        Console.WriteLine("-------------------------------------------------");

        // Crear productos
        Product product1 = new FixedPriceProduct()
        {
            Description = "Vino Gato Negro",
            Id = 1010,
            Price = 46000M,
            Tax = 0.19F
        };

        Product product2 = new FixedPriceProduct()
        {
            Description = "Pan Bimbo Artesanal",
            Id = 2020,
            Price = 1560M,
            Tax = 0.19F
        };

        Product product3 = new VariablePriceProduct()
        {
            Description = "Queso Holandes",
            Id = 3030,
            Measurement = "Kilo",
            Price = 32000M,
            Quantity = 0.54F,
            Tax = 0.19F
        };

        Product product4 = new VariablePriceProduct()
        {
            Description = "Cabano",
            Id = 4040,
            Measurement = "Kilo",
            Price = 18000M,
            Quantity = 0.39F,
            Tax = 0.19F
        };

        Product product5 = new ComposedProduct()
        {
            Description = "Ancheta #1",
            Discount = 0.12F,
            Id = 5050,
            Products = new List<Product>() { product1, product2, product3, product4 }
        };

        // Mostrar productos
        Console.WriteLine(product1);
        Console.WriteLine(product2);
        Console.WriteLine(product3);
        Console.WriteLine(product4);
        Console.WriteLine(product5);

        // Crear factura y mostrarla
        List<Product> productsForInvoice = new List<Product> { product1, product3, product5 };
        Invoice invoice = new Invoice();
        foreach (var product in productsForInvoice)
        {
            invoice.AddProduct(product);
        }
        Console.WriteLine(invoice);

        // Crear recibo y mostrarlo
        Receipt receipt = new Receipt(productsForInvoice);
        Console.WriteLine(receipt);
    }
}

