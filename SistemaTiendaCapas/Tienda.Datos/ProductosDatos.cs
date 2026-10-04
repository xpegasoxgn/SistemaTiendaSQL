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
        public int registrarProducto(Productos producto)
        {
            int resultado = 0;
            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("usp_RegistrarProductos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar,100).Value =producto.Nombre;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal,100).Value =producto.Precio;
            comando.Parameters.Add("@Stock",SqlDbType.Int).Value=producto.Stock;
           comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = producto.IdCategoria;
            SqlParameter parametroRetorno = new SqlParameter("@Resultado", SqlDbType.Int);
            conexion.Open();
            comando.ExecuteNonQuery();
            resultado = Convert.ToInt32(parametroRetorno.Value);
            return resultado;
        }

        public int BuscarProducto(string producto)
        {
            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("usp_BuscarPorProducto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto;
            conexion.Open();
            return Convert.ToInt32(comando.ExecuteScalar());
        }
    }
}