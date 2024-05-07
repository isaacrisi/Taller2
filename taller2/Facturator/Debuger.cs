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
        public static void Momaso()
        {
            Console.WriteLine("!!PAGUE!!!!");
            Console.WriteLine("            ___                       ");     
            Console.WriteLine("          /]_ /                                 ");    
            Console.WriteLine("         |\\/|.--/'-.                         ");
            Console.WriteLine("         \\|/:o /  /\\      ._,               ");
            Console.WriteLine("            \\_/_.'0/      _|_             ");
            Console.WriteLine("             \\____]] (> [___] =]]]===     ");
            Console.WriteLine("             /    \\___/ P{]              ");
            Console.WriteLine("          __//    /----\\/                 ");
            Console.WriteLine("         (_[-'\\__/_                       ");
            Console.WriteLine("             / | | \\                      ");
            Console.WriteLine("           '==' = '=='                   ");
            Console.WriteLine("           ____||||___                  ");
            Console.WriteLine("         (_\"\"_ / \\_\"\"_)                     ");
        }                                                

    }
}
