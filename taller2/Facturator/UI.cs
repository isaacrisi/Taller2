using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facturator
{
    class UI
    {

        public static Caja caja;

        public static void BuscarFactura()
        {
            int id_factura;
            do
            {
                Console.WriteLine("  Ingrese el id de la factura solicitada");
            } while (!int.TryParse(Console.ReadLine(), out id_factura));

            caja.ImprimirFactura(id_factura);
            Console.ReadKey();
        }

        public static void PintarCabezoteMenu()
        {
            Console.WriteLine("                                    /\\    /\\                                   ");
            Console.WriteLine("  +--------------------------------(´・(oo)・｀)---------------------------------+");
            Console.WriteLine("  |  _____   ____     __  ______  __ __  ____    ____  ______   ___   ____    |");
            Console.WriteLine("  | |     | /    |   /  ]|      ||  |  ||    \\  /    ||      | /   \\ |    \\   |");
            Console.WriteLine("  | |   __||  o  |  /  / |      ||  |  ||  D  )|  o  ||      +|     |+  D  )  |");
            Console.WriteLine("  | |  |_  |     | /  /  |_|  |_|+  |  ||    / |     +|_|  |_|+  O  ||    /   |");
            Console.WriteLine("  | |   _] |  _  |/   \\_   |  |  |  :  ||    \\ |  _  |  |  |  |     ||    \\   |");
            Console.WriteLine("  | |  |   |  |  |\\     |  |  |  |     ||  .  \\|  |  |  |  |  |     |+  .  \\  |");
            Console.WriteLine("  | |__|   |__|__| \\____|  |__|   \\__,_||__|\\_||__|__|  |__|   \\___/ |__|\\_|  |");
            Console.WriteLine("  |                                                                           |");
            Console.WriteLine("  |                                                                           |");
            Console.WriteLine("  |                          Ingrese una opción así:                          |");
            Console.WriteLine("  |                           1. Realizar venta                               |");
            Console.WriteLine("  |                           2. Operaciones con productos                    |");// TODO:crud busqueda
            Console.WriteLine("  |                           3. Imprimir inventario                          |");
            Console.WriteLine("  |                           4. Buscar Factura                               |");
            Console.WriteLine("  |                           5. Exportar factura                             |");//Imprimir en PDF, csv, html
            Console.WriteLine("  |                          -1. Salir                                        |");
            Console.WriteLine("  |                                                                           |");
            Console.WriteLine("  +---------------------------------------------------------------------------+");
            Console.WriteLine();
            Console.Write("  ->");
        }

        public static int Menu(Caja caja)
        {
            int opc = 0;
            UI.caja = caja;
            //TODO: Personalizar el menu ascii            
            do
            {
                PintarCabezoteMenu();

                if (int.TryParse(Console.ReadLine(), out opc))
                {
                    switch (opc)
                    {
                        case 1:
                            VentaManager.RealizarVenta(caja);
                            break;
                        case 2:
                            // Otras opciones del menú
                            break;
                        case 3:
                            // Otras opciones del menú
                            break;
                        case 4:
                            BuscarFactura();
                            break;
                        case 5:
                            // Otras opciones del menú
                            break;
                        case -1:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese un número válido.");
                }


            } while (opc != -1);

            return opc;
        }

        public static void MostrarProductos(Caja caja)
        {
            Console.WriteLine("Productos disponibles:");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("| Nombre       | Precio|");
            Console.WriteLine("+----------------------+");
            foreach (Producto producto in caja.Inventario)
            {
                Console.WriteLine($"| {producto.Nombre,-12} | ${producto.Precio,5} |");
            }
            Console.WriteLine("+----------------------+");
        }


    }
}
