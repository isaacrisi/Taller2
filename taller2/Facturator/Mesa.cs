
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facturator
    {
        class Mesa
        {
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
        

    }
    }


