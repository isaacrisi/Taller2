using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Program {
        static void Main(string[] args) {

            Caja caja = new Caja();
            LectorArchivo temp = new LectorArchivo();
            caja.Facturas = temp.cargarFacturas();
            Factura factura = new Factura();
            //caja.ImprimirFactura(7);¨
            Producto hamburguesa = new Producto("Hamburguesa", 5.99f, 20);
            Producto espagueti = new Producto("Espagueti", 8.99f, 20);
            Producto lasagna = new Producto("Lasagna", 10.99f, 20);
            caja.AgregarProducto(hamburguesa);
            caja.AgregarProducto(espagueti);
            caja.AgregarProducto(lasagna);
            UI.Menu(caja);
            Console.ReadKey();
            

        }
    }
}
