using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Producto {
        private string nombre;
        private int tamano;
        private float precio;
        private float peso;
        private int cantidad;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Tamano { get => tamano; set => tamano = value; }
        public float Precio { get => precio; set => precio = value; }
        public float Peso { get => peso; set => peso = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public Producto() 
        {

        }

        public Producto(string nombre, float precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public Producto(string nombre, float precio, int cantidad) 
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
        }
    }
}
