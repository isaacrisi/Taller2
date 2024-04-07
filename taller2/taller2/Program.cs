using System;

namespace taller2
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            restaurante.AddMesa(new Mesa(1));
            restaurante.AddMesa(new Mesa(2));

            // Encontrar una mesa específica
            Mesa mesa1 = restaurante.EncontrarMesa(1);
            if (mesa1 != null)
            {
                Console.WriteLine("Mesa encontrada: " + mesa1.NumMesa);
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }

            // Imprimir el menú
            restaurante.PrintMenu();

            // Editar el menú
            restaurante.EditMenu();

            // Cargar datos desde un archivo
            restaurante.LoadFromFile("datos.txt");

            // Guardar datos en un archivo
            restaurante.SaveToFile("datos_guardados.txt");

            // Aquí puedes continuar con la lógica de tu programa según tus necesidades
        }
    }
}
