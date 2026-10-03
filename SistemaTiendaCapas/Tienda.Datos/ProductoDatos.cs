using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tienda.Entidades;
namespace Tienda.Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarProductos()
        {
            List < Producto >= productos = new List<Producto>();
            //conexion
            using SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
            using SqlCommand comando = new SqlCommand("usp_listarProductos",conexion);
            comando.CommandType = CommandType
            return null;
        }
    }
}
