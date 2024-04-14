using System;

namespace Facturator
{
    internal class InputValidator
    {
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
