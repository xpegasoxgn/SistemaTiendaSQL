using System;
using System.Collections.Generic;
using System.Data;
using Tienda.Entidades;
using Microsoft.Data.SqlClient;

namespace Tienda.Datos
{
    public class ProductoDatos
    {
        public List<Productos> ListarProductos()
        {
            List<Productos> lista = new List<Productos>();

            using (SqlConnection cn = new SqlConnection(ConexionBD.cadenaconexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_listarproductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Productos p = new Productos();
                            p.IdProducto = Convert.ToInt32(lector["IdProducto"]);
                            p.Nombre = lector["Nombre"]?.ToString() ?? string.Empty;
                            p.Precio = Convert.ToDecimal(lector["Precio"]);
                            p.stock = Convert.ToInt32(lector["stock"]);
                            p.NombreCategoria = lector["NombreCategoria"]?.ToString() ?? string.Empty;

                            lista.Add(p);
                        }
                    }
                }
            }

            return lista;
        }
    }
}