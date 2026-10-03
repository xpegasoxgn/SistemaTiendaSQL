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
        public List<Productos> ListarProductos()
        {
            List<Productos> productos = new List<Productos>();
            //conexion
            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("usp_listarProductos", conexion);
            comando.CommandType= CommandType.StoredProcedure;
            conexion.Open();
            using SqlDataReader lector =
                 comando.ExecuteReader();

            while (lector.Read())
            {
                Productos producto = new Productos();

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