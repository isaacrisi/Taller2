using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator
{
    class Debug
    {
        public static bool activar_debug;
        //Pendiente crear un miembro dato que almacene y sirva de log sin persistencia y luego con persistencia
        public static void Log(string linea)
        {
            if (activar_debug)
            {
                Console.WriteLine(linea);
            }
        }

    }
}
