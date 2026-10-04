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
            comando.CommandType = CommandType.StoredProcedure;
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
        // registrar producto
        public int RegistrarProducto(Producto producto)
        {
            using SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
            using SqlCommand comando = new SqlCommand("dbo.usp_RegistrarProductos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = producto.Nombre;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal, 18).Value = producto.Precio;
            comando.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = producto.IdCategoria;

            //capturar el valor que devuelve el procedimiento almacenado
            SqlParameter parametricoRetorno = comando.Parameters.Add("@ValorRetorno", SqlDbType.Int);
            parametricoRetorno.Direction = ParameterDirection.ReturnValue;
            conexion.Open();
            comando.ExecuteNonQuery();
            return Convert.ToInt32(parametricoRetorno.Value);
        }
    }
}