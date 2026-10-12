using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Tienda.Entidades;

namespace Tienda.Datos
{
    public class ProductoDatos
    {
        public List<Productos> ListarProductos()
        {
            List<Productos> productos = new List<Productos>();

            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("usp_listarProductos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Productos producto = new Productos
                {
                    IdProducto = Convert.ToInt32(lector["IdProducto"]),
                    Nombre = lector["Producto"].ToString() ?? string.Empty,
                    Precio = Convert.ToDecimal(lector["Precio"]),
                    Stock = Convert.ToInt32(lector["Stock"]),
                    NombreCategoria = lector["Categoria"].ToString() ?? string.Empty
                };

                productos.Add(producto);
            }

            return productos;
        }

        public int registrarProducto(Productos producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                return -1;

            if (producto.Precio <= 0)
                return -2;

            if (producto.Stock < 0)
                return -3;

            if (producto.IdCategoria <= 0)
                return -4;

            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("usp_RegistrarProductos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto.Nombre;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal, 10).Value = producto.Precio;
            comando.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = producto.IdCategoria;
            conexion.Open();
            comando.ExecuteNonQuery();
            return 1;
        }

        public List<Productos> BuscarProducto(string producto)
        {
            List<Productos> productos = new List<Productos>();
            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("usp_BuscarPorProducto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                productos.Add(new Productos
                {
                    IdProducto = Convert.ToInt32(lector["IdProducto"]),
                    Nombre = lector["Producto"].ToString() ?? string.Empty,
                    Precio = Convert.ToDecimal(lector["Precio"]),
                    Stock = Convert.ToInt32(lector["Stock"]),
                    NombreCategoria = lector["Categoria"].ToString() ?? string.Empty
                });
            }

            return productos;
        }

        public bool EliminarProducto(int idProducto)
        {
            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("dbo.usp_EliminarProducto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

            conexion.Open();
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas > 0;
        }

        public int ActualizarProducto(Productos producto)
        {
            if (producto.IdProducto <= 0)
                return -1;

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                return -2;

            if (producto.Precio <= 0)
                return -3;

            if (producto.Stock < 0)
                return -4;

            if (producto.IdCategoria <= 0)
                return -5;

            using SqlConnection conexion = new SqlConnection(ConexionBD.cadenaconexion);
            using SqlCommand comando = new SqlCommand("dbo.usp_actualizarProducto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = producto.IdProducto;
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto.Nombre;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal, 18).Value = producto.Precio;
            comando.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = producto.IdCategoria;

            SqlParameter parametroRetorno = new SqlParameter("@valorretorno", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            comando.Parameters.Add(parametroRetorno);

            conexion.Open();
            comando.ExecuteNonQuery();
            return Convert.ToInt32(parametroRetorno.Value);
        }
    }
}