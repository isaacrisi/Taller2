using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facturator
{
    internal class VentaManager
    {
        Mesa mesa1 = new Mesa();
        Debug debug = new Debug();

        public static void RealizarVenta(Caja caja)
        {
            Console.Clear();
            int mesa = Mesa.ElegirMesa(); // El usuario elige una mesa
            Console.WriteLine($"Mesa {mesa} seleccionada.");
            UI.MostrarProductos(caja);
            List<Producto> productosSeleccionados = EscogerProductos(caja);
            float total = CalcularTotal(productosSeleccionados, mesa); // Pasar el número de mesa
            Console.WriteLine($"El total a pagar para la Mesa {mesa} es: ${total}");
            Debug.Momaso();
            Factura factura = new Factura();
            factura.Productos1 = productosSeleccionados;
            Mesa.LiberarMesa(mesa); // Liberar la mesa después de la venta


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

        public static float CalcularTotal(List<Producto> productos, int mesa)
        {
            float total = 0;

            // Imprimir encabezado de la factura con el número de mesa
            Factura factura = new Factura();
            factura.ImprimirCabezote();
            Utilitario.ImprimirSeparador('_', Constantes.ANCHO_TIRILLA);
            Console.WriteLine($"Mesa: {mesa}");
            Utilitario.ImprimirSeparador('_', Constantes.ANCHO_TIRILLA);
            Console.WriteLine("Producto     Precio     Cantidad");
            Utilitario.ImprimirSeparador('-', Constantes.ANCHO_TIRILLA);

            // Iterar sobre cada producto en la lista
            foreach (var producto in productos)
            {
                // Calcular el subtotal del producto
                float subtotalProducto = producto.Precio * producto.Cantidad;

                // Imprimir el nombre, precio y cantidad del producto
                Console.WriteLine($"{producto.Nombre,-15} ${producto.Precio,-10} {producto.Cantidad,-10}");

                // Sumar al total el subtotal del producto
                total += subtotalProducto;
            }

            Utilitario.ImprimirSeparador('-', Constantes.ANCHO_TIRILLA);
            Console.WriteLine($"TOTAL: ${total}");
            Utilitario.ImprimirSeparador('*', Constantes.ANCHO_TIRILLA);

            return total;
        }

    }
}




