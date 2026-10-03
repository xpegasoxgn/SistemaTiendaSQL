using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using Tienda.Entidades;

namespace Tienda.Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            //conexion
            using SqlConnection conexion = new SqlConnection(ConexionDB.CadenaConexion);
            using SqlCommand comando = new SqlCommand("usp_ListarProductos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                productos.Add(new Producto
                {
                    IdProducto = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    stock = lector.GetInt32(3),
                    IdCategoria = lector.GetInt32(4),
                    nombreCategoria = lector.GetString(5)
                });
            }
            return productos;
        }
    }
}
