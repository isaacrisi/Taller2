using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Producto {
        public static List<Producto> inventario = new List<Producto>();

        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, float precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public static void AgregarProducto(Caja caja, Producto producto)
        {
            inventario.Add(producto);
            caja.Inventario.Add(producto);
        }



        public static void EliminarProducto(Producto producto)
        {
            inventario.Remove(producto);
        }

        public static void EditarProducto(Producto producto, string nuevoNombre, float nuevoPrecio)
        {
            producto.Nombre = nuevoNombre;
            producto.Precio = nuevoPrecio;
        }

        public static void MostrarInventario()
        {
            Console.WriteLine("Inventario de productos:");
            foreach (var producto in inventario)
            {
                Console.WriteLine($"- {producto.Nombre} (${producto.Precio}) - Cantidad: {producto.Cantidad}");
            }
        }
    }
}
