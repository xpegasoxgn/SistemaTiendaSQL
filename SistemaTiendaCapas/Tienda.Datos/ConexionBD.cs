using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Datos
{
    internal class ConexionBD
    {

        public static string CadenaConexion { get; }= "Server=localhost;" +
            "Database=TiendaBD;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=true;";
    }
}
