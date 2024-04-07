using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Restaurante
    {
        private List<Mesa> mesas;

        public Restaurante()
        {
            mesas = new List<Mesa>();
        }

        public void AddMesa(Mesa mesa)
        {
            mesas.Add(mesa);
        }

        public Mesa EncontrarMesa(int numMesa)
        {
            return mesas.Find(mesa => Mesa.NumMesa == numMesa);
        }

        public void PrintMenu()
        {
            // Implementación para imprimir el menú aquí
        }

        public void EditMenu()
        {
            // Implementación para editar el menú aquí
        }

        public void LoadFromFile(string fileName)
        {
            // Implementación para cargar datos desde un archivo aquí
        }

        public void SaveToFile(string fileName)
        {
            // Implementación para guardar datos en un archivo aquí
        }
    }

}

