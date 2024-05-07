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
            Console.WriteLine("  |                           3. Buscar Factura                               |");
            Console.WriteLine("  |                           4. Exportar factura                             |");//Imprimir en PDF, csv, html
            Console.WriteLine("  |                          -1. Salir                                        |");
            Console.WriteLine("  |                                                                           |");
            Console.WriteLine("  +---------------------------------------------------------------------------+");
            Console.WriteLine();
            Console.Write("  ->");
        }
        private static void PintarCabezoteMenuInventario()
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
            Console.WriteLine("  |                           1. Agregar Producto                             |");
            Console.WriteLine("  |                           2. Eliminar Producto                            |");// TODO:crud busqueda
            Console.WriteLine("  |                           3. Editar Producto                              |");
            Console.WriteLine("  |                           4. Mostrar inventario                           |");
            Console.WriteLine("  |                          -1. Volver al Menú                               |");
            Console.WriteLine("  |                                                                           |");
            Console.WriteLine("  +---------------------------------------------------------------------------+");
            Console.WriteLine();
            Console.Write("  ->");
        }

        public static int Menu(Caja caja)
        {
            int opc = 0;
            UI.caja = caja;
            Factura factura = new Factura();
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
                            MostrarMenuInventario(caja);
                            break;
                        case 3:
                            BuscarFactura();
                            break;
                        case 4:
                            factura.ExportarCSV("factura.csv");
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
        public static void MostrarMenuInventario(Caja caja)
        {
            int opcion;
            do
            {
                PintarCabezoteMenuInventario();

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nombre del nuevo producto:");
                            string nombreProducto = Console.ReadLine();

                            Console.WriteLine("Ingrese el precio del nuevo producto:");
                            float precioProducto;
                            while (!float.TryParse(Console.ReadLine(), out precioProducto) || precioProducto <= 0)
                            {
                                Console.WriteLine("Precio inválido. Ingrese un precio válido:");
                            }

                            // Crear un nuevo objeto Producto y agregarlo al inventario
                            Producto nuevoProducto = new Producto(nombreProducto, precioProducto, 0); // La cantidad se puede dejar en 0 inicialmente
                            Producto.AgregarProducto(caja, nuevoProducto);
                            Console.WriteLine("¡Producto agregado con éxito!");
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
                            string nombreProductoEliminar = Console.ReadLine();
                            Producto productoEliminar = Producto.inventario.FirstOrDefault(p => p.Nombre == nombreProductoEliminar);
                            if (productoEliminar != null)
                            {
                                Producto.EliminarProducto(productoEliminar);
                                Console.WriteLine($"¡Producto '{nombreProductoEliminar}' eliminado con éxito!");
                            }
                            else
                            {
                                Console.WriteLine("¡Producto no encontrado!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Ingrese el nombre del producto que desea editar:");
                            string nombreProductoEditar = Console.ReadLine();
                            Producto productoEditar = Producto.inventario.FirstOrDefault(p => p.Nombre == nombreProductoEditar);
                            if (productoEditar != null)
                            {
                                Console.WriteLine("Ingrese el nuevo nombre del producto:");
                                string nuevoNombreProducto = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio del producto:");
                                float nuevoPrecioProducto;
                                while (!float.TryParse(Console.ReadLine(), out nuevoPrecioProducto) || nuevoPrecioProducto <= 0)
                                {
                                    Console.WriteLine("Precio inválido. Ingrese un precio válido:");
                                }
                                Producto.EditarProducto(productoEditar, nuevoNombreProducto, nuevoPrecioProducto);
                                Console.WriteLine($"¡Producto '{nombreProductoEditar}' editado con éxito!");
                            }
                            else
                            {
                                Console.WriteLine("¡Producto no encontrado!");
                            }
                            break;
                        case 4:
                            Producto.MostrarInventario(caja);
                            break;

                        case -1:
                            Console.WriteLine("Volviendo al menú principal...");
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

            } while (opcion != -1);
        }


    }
}
