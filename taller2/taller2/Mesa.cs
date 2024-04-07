using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Mesa
    {
        public int NumMesa { get; private set; }
        private List<Producto> productos;

        public Mesa(int numMesa)
        {
            NumMesa = numMesa;
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void EditarProducto(int idProducto, Producto nuevoProducto)
        {
            // Implementa la lógica para editar un producto de la mesa
        }

        public Factura GenerarFactura()
        {
            // Implementa la lógica para generar una factura para la mesa
            return new Factura(productos);
        }

    }
}
