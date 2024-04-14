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
            Console.WriteLine("Productos disponibles:");
            UI.MostrarProductos(caja);
            EscogerProductos(caja);
        }

        public static void EscogerProductos(Caja caja)
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

                int cantidad = PedirCantidad();

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

            // Aquí podrías hacer algo con los productos seleccionados, como mostrar un resumen, 
            // calcular el total, etc.
        }

        public static int PedirCantidad()
        {
            while (true)
            {
                Console.WriteLine("Ingrese la cantidad que desea comprar:");
                string inputCantidad = Console.ReadLine();

                if (int.TryParse(inputCantidad, out int cantidad) && cantidad > 0)
                {
                    return cantidad;
                }

                Console.WriteLine("Cantidad inválida. Por favor, ingrese un número entero mayor que cero.");
            }
        }
    }

}

