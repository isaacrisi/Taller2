using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class LectorArchivo {

        public const char SEPARADOR_NOMBRES = '-';
        public const char SEPARADOR_PRECIOS = '#';
        public const char SEPARADOR_REGISTROS = ';';//Revisar cual es el separado de un archivo csv dependiendo del sistema operativo
        public const char SEPARADOR_CANTIDAD = 'C';

        /*
            En este primer ejemplo, vamos a leer todas las lineas de un archivo, para empezar a revisar el tema de lectura de datos externos,
            sin embargo aclaro que este enfoque no es el más recomendable, sobretodo para archivos que pueden ser grandes, más adelante usaremos
            un buffer, que es una mejor forma de procesar un archivo.

            tomado de: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
        */

        public Factura[] cargarFacturas()
        {
            Factura[] facturas = null;

            try
            {
                // Example #2
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lineas = System.IO.File.ReadAllLines(@"../../archivo/facturas.csv");

                // Display the file contents by using a foreach loop.
                Debug.Log("Contenido del archivo facturas = ");
                facturas = ProcesarLineas(lineas);
                
            }
            catch(NullReferenceException e1)
            {
                Console.WriteLine("Error al procesar los items del archivo");
            }
            catch(Exception e2)
            {
                //Pendiente personalizar la excepcion
                Console.WriteLine("Error al leer el archivo, revise que el archivo este cerrado");
            }
            return facturas;
        }
        
        public Factura[] ProcesarLineas(string[] lineas) {

            string[] temp;
            string[] nombres, precios;

            Factura[] facturas = new Factura[lineas.Length];//Peniente hacer refactoring

            for (int i = 1; i < lineas.Length; i++)//Empezamos en 1 para saltarnos el encabezado de la tabla
            {
                temp = Utilitario.SepararCadena(lineas[i], SEPARADOR_REGISTROS);
                //temp[0] Fecha
                nombres = ProcesarRegistro(temp[1], SEPARADOR_NOMBRES);
                precios = ProcesarRegistro(temp[2], SEPARADOR_PRECIOS);
                Debug.Log(i + " " + nombres.Length);
                facturas[i] = new Factura(nombres.Length);                
                facturas[i].AgregarProductos(nombres,precios);
                facturas[i].Numero_factura = Utilitario.ConvertirEntero(temp[5]);
                //temp[3] Medio de pago
                //temp[4] Estado actual
                //temp[5] Numero factura
            }
            return facturas;
        }
        
        public string[] ProcesarRegistro(string registro,char separador) {
            
            string[] temp = Utilitario.SepararCadena(registro, separador);
            string[] salida = new string[temp.Length];

            for(int i=0;i<temp.Length;i++) {
                salida[i] = temp[i];
            }

            return salida;
        }

    }
}
