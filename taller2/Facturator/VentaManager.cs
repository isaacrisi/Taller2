using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Facturator
    {
        internal class VentaManager
        {
            public static void RealizarVenta(Caja caja)
            {
                Console.Clear();
                UI.MostrarProductos(caja);
                List<Producto> productosSeleccionados = EscogerProductos(caja);
                float total = CalcularTotal(productosSeleccionados);
                Console.WriteLine($"El total a pagar es: ${total}");
            }

            public static List<Producto> EscogerProductos(Caja caja)
            {
                List<Producto> productosSeleccionados = new List<Producto>();

                while (true)
                {
                    Console.WriteLine("\nIngrese el nombre del producto que desea comprar (o escriba 'listo' para terminar):");
                    string nombreProducto = Console.ReadLine();

                    if (nombreProducto.ToLower() == "listo")
                    {
                        break;
                    }

                    Producto productoEncontrado = caja.Inventario.Find(p => p.Nombre.ToLower() == nombreProducto.ToLower());

                    if (productoEncontrado == null)
                    {
                        Console.WriteLine("¡Producto no encontrado! Por favor, intente nuevamente.");
                        continue;
                    }

                    Console.WriteLine($"Producto: {productoEncontrado.Nombre} - Precio: ${productoEncontrado.Precio}");

                    int cantidad = InputValidator.PedirCantidad();

                    if (cantidad > 0)
                    {
                        productoEncontrado.Cantidad = cantidad;
                        productosSeleccionados.Add(productoEncontrado);
                    }
                    else
                    {
                        Console.WriteLine("La cantidad debe ser mayor que cero. Por favor, intente nuevamente.");
                    }
                }

                return productosSeleccionados;
            }

            public static float CalcularTotal(List<Producto> productos)
            {
                float total = 0;
                foreach (var producto in productos)
                {
                    total += producto.Precio * producto.Cantidad;
                }
                return total;
            }
        }
    }




