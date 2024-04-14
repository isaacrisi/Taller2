using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Caja {
        private Factura[] facturas;
        private List<Producto> inventario;

        public Caja() 
        {
            inventario = new List<Producto>();
        }
        public void AgregarProducto(Producto producto)
        {
            inventario.Add(producto);
        }

        public Factura[] Facturas { get => facturas; set => facturas = value; }
        public List<Producto> Inventario { get => inventario; set => inventario = value; }

        public void ImprimirFactura(int id_factura)
        {
            Factura f;
            
            if(id_factura >=0 && id_factura<facturas.Length)
            {
                f = facturas[id_factura];
                f.ImprimirTirilla();
                Console.WriteLine();                
            }
            else
            {
                Console.WriteLine(Constantes.ERROR_AL_BUSCAR_FACTURA);
            }
        }
    }
}
