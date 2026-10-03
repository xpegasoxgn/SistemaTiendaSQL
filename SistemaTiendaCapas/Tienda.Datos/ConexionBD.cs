using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Datos
{
    internal class ConexionBD
    {
        public static string CadenaConexion { get; } = "Server=localhost;"+
            "Database=cursoDotNet;"+
            "Trusted_Connection=True;"+
            "TrustServerCertificate=true;";
    }
}
