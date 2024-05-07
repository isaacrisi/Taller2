using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator
{
    class Factura
    {
        private string fecha;
        private int estado_actual;
        private string medio_pago;
        private float iva;
        private float total;
        private Producto[] canasta;
        private int indice;
        private int numero_factura;
        private List<Producto> Productos;


        public Factura()
        {
            Productos1 = new List<Producto>();
        }

        public Factura(int cantidad_productos)
        {
            Canasta = new Producto[cantidad_productos];
        }
        public Factura(List<Producto> productos)
        {
            Productos1 = productos;
        }

        public Factura(string fecha, int estado_actual, string medio_pago, float iva, float total)
        {
            this.fecha = fecha;
            this.estado_actual = estado_actual;
            this.medio_pago = medio_pago;
            this.iva = iva;
            this.total = total;
        }

        public void MostrarProducto(int indice)
        {
            int cantidad = Canasta[indice].Cantidad;
            Console.Write(Utilitario.FomatearDigito(cantidad.ToString()));//Se hace de esta forma, para que la función de convertir digitos sea versátil
            Utilitario.ImprimirEspacios(1);
            Console.Write(Utilitario.ImprimirEspaciosFin(Canasta[indice].Nombre, Constantes.CANTIDAD_CARACTERES_NOMBRE_PRODUCTO));
            Utilitario.ImprimirEspacios(1);
            Console.Write(Utilitario.ImprimirEspaciosInicio(Canasta[indice].Precio.ToString(), Constantes.CANTIDAD_CARACTERES_PRECIO_UNITARIO));
            Utilitario.ImprimirEspacios(1);
            Console.WriteLine(Utilitario.ImprimirEspaciosInicio((Canasta[indice].Precio * cantidad).ToString(), Constantes.CANTIDAD_CARACTERES_PRECIO_SUBTOTAL));

        }

        public void ImprimirCabezote()
        {
            Utilitario.ImprimirSeparador('*', Constantes.ANCHO_TIRILLA);
            Utilitario.CentrarPalabra(Constantes.NOMBRE_NEGOCIO, Constantes.ANCHO_TIRILLA);
            Utilitario.CentrarPalabra("#" + numero_factura, Constantes.ANCHO_TIRILLA);
            Utilitario.ImprimirSeparador('*', Constantes.ANCHO_TIRILLA);
        }

        public float CalcularImpuesto(float subtotal)
        {
            return subtotal * Constantes.IMPUESTO;
        }

        public void ImprimirPata()
        {
            float subtotal = CalcularSubtotal();
            string texto_subtotal = "Subtotal $" + subtotal;
            string texto_impuesto = "Impuesto $" + CalcularImpuesto(subtotal);
            Utilitario.ImprimirSeparador('*', Constantes.ANCHO_TIRILLA);
            Utilitario.ImprimirEspacios(Constantes.ANCHO_TIRILLA - (texto_subtotal.Length));
            Console.WriteLine(texto_subtotal);
            Utilitario.ImprimirEspacios(Constantes.ANCHO_TIRILLA - (texto_impuesto.Length));
            Console.Write(texto_impuesto);
        }

        public void ImprimirTirilla()
        {
            ImprimirCabezote();

            for (int i = 0; i < indice; i++)
            {
                MostrarProducto(i);
            }
            //Pendiente calcular la propina, el impuesto, el método de pago y si aplica devuelta.
            ImprimirPata();
        }

        public void AgregarProducto(Producto producto)
        {

            if (indice + 1 <= Canasta.Length)
            {
                Canasta[indice++] = producto;
            }
        }

        public void AgregarProducto(string nombre, float precio, int cantidad)
        {
            AgregarProducto(new Producto(nombre, precio, cantidad));
        }

        public void AgregarProductos(string[] nombres, string[] precios)
        {
            float precio;
            int cantidad;
            string[] precio_cantidad;

            for (int i = 0; i < nombres.Length; i++)
            {
                precio_cantidad = Utilitario.SepararCadena(precios[i], LectorArchivo.SEPARADOR_CANTIDAD);
                precio = Utilitario.ConvertirFlotante(precio_cantidad[0]);
                cantidad = Utilitario.ConvertirEntero(precio_cantidad[1]);

                if (precio > 0 && cantidad > 0)
                {
                    AgregarProducto(nombres[i], precio, cantidad);
                }
                else
                {
                    Console.WriteLine("Error al leer el dato:" + nombres[i]);//Cambiar por una exepcion
                }
            }
        }

        public float CalcularSubtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < Canasta.Length; i++)
            {
                subtotal += Canasta[i].Precio * Canasta[i].Cantidad;
            }

            return subtotal;
        }
        public void ExportarCSV(string nombreArchivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(nombreArchivo))
                {
                    // Escribir el encabezado del archivo CSV
                    writer.WriteLine("Nombre Producto,Precio,Cantidad,Total");

                    // Escribir cada producto de la factura en el archivo CSV
                    foreach (var producto in Productos1)
                    {
                        string linea = $"{producto.Nombre},{producto.Precio},{producto.Cantidad},{producto.Precio * producto.Cantidad}";
                        writer.WriteLine(linea);
                    }
                }

                Console.WriteLine("Factura exportada exitosamente como archivo CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al exportar la factura como archivo CSV: {ex.Message}");
            }
        }


        public string Fecha { get => fecha; set => fecha = value; }
        public int Estado_actual { get => estado_actual; set => estado_actual = value; }
        public string Medio_pago { get => medio_pago; set => medio_pago = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Total { get => total; set => total = value; }
        public int Numero_factura { get => numero_factura; set => numero_factura = value; }
        public Producto[] Canasta { get => canasta; set => canasta = value; }
        public List<Producto> Productos1 { get => Productos; set => Productos = value; }
    }

}
