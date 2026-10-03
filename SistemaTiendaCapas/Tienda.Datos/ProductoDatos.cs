using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tienda.Entidades;
using Microsoft.Data.SqlClient;

namespace Tienda.Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            //conexion
            using SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
            using SqlCommand comando = new SqlCommand("usp_listarProductos", conexion);
            comando.CommandType= CommandType.StoredProcedure;
            conexion.Open();
            using SqlDataReader lector =
                 comando.ExecuteReader();

            while (lector.Read())
            {
                Producto producto = new Producto();

                producto.IdProducto =
                    Convert.ToInt32(lector["IdProducto"]);

                producto.Nombre =
                    lector["Producto"].ToString() ?? "";

                producto.Precio =
                    Convert.ToDecimal(lector["Precio"]);

                producto.Stock =
                    Convert.ToInt32(lector["Stock"]);

                producto.NombreCategoria =
                    lector["Categoria"].ToString() ?? "";



                productos.Add(producto);
            }

           

            return productos;
        }
    }
}
