
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facturator
    {
        class Mesa
        {
        /*
            public int Numero
            {
                get; set;
            }
            public string Estado
            {
                get; set;
            }
            public List<Producto> Productos { get; set; }

            public Mesa()
            {

            }
            public Mesa(int numero, string estado)
            {
                Numero = numero;
                Estado = estado;
                Productos = new List<Producto>();

            }
        */
        private static HashSet<int> MesasOcupadas = new HashSet<int>();

        static Mesa()
        {
            // Configurar la mesa tres como ocupada por defecto
            MesasOcupadas.Add(3);
        }

        public static void MostrarEstadoMesas()
        {
            Console.WriteLine("Estado de las mesas:");
            Console.WriteLine("╔══════════════════════════════╗");
            for (int i = 1; i <= 5; i++)
            {
                string estado = MesasOcupadas.Contains(i) ? "Ocupada" : "Libre";
                string mesa = $"Mesa {i}: {estado}";
                Console.WriteLine($"║ {mesa,-28} ║");
            }
            Console.WriteLine("╚══════════════════════════════╝");
        }

        public static int ElegirMesa()
        {
            Console.WriteLine("Por favor, elija una mesa disponible:");
            MostrarEstadoMesas();
            int mesa;
            while (!int.TryParse(Console.ReadLine(), out mesa) || mesa < 1 || mesa > 5 || MesasOcupadas.Contains(mesa))
            {
                Console.WriteLine("Mesa inválida o ocupada. Por favor, elija otra mesa.");
            }
            MesasOcupadas.Add(mesa); // Marcar la mesa como ocupada
            return mesa;
        }

        public static void LiberarMesa(int mesa)
        {
            MesasOcupadas.Remove(mesa); // Marcar la mesa como liberada
        }
    }
    }


