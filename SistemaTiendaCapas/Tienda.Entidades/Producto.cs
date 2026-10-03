using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tienda.Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; } = string.Empty;
    }
}
