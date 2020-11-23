using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class ManejoBaseDeDatos
    {
        static SqlConnection conexionALaBase;
        
        /// <summary>
        /// Constructor estatico 
        /// </summary>
        static ManejoBaseDeDatos()
        {
            conexionALaBase = new SqlConnection();
            conexionALaBase.ConnectionString = "Data Source=.\\sqlexpress; Initial Catalog=TP4; Integrated Security=True;";

        }

        /// <summary>
        /// Trae los productos de la tabla Hardware
        /// </summary>
        /// <returns></returns>
        public static List<Hardware> ObtenerProductosHardware()
        {
            SqlCommand comandoAEjecutar;
            comandoAEjecutar = new SqlCommand();

            try
            {
                List<Hardware> listaDeProductos = new List<Hardware>();

                comandoAEjecutar.Connection = conexionALaBase;
                comandoAEjecutar.CommandType = CommandType.Text;
                comandoAEjecutar.CommandText = "select * from Hardware";

                if (conexionALaBase.State != ConnectionState.Open)
                {
                    conexionALaBase.Open();
                }

                SqlDataReader lector = comandoAEjecutar.ExecuteReader();

                while (lector.Read())
                {
                    listaDeProductos.Add(new Hardware((int)((decimal)lector["idHardware"]), lector["nombre"].ToString(), (double)lector["precio"], (int)((decimal)lector["cantidad"]), (int)((decimal)lector["numeroDeParte"])));
                }

                return listaDeProductos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conexionALaBase.State != ConnectionState.Closed)
                {
                    conexionALaBase.Close();
                }
            }
        }

        /// <summary>
        /// Trae los productos de la tabla Software
        /// </summary>
        /// <returns></returns>
        public static List<Software> ObtenerProductosSoftware()
        {
            SqlCommand comandoAEjecutar;
            comandoAEjecutar = new SqlCommand();

            try
            {
                List<Software> listaDeProductos = new List<Software>();

                comandoAEjecutar.Connection = conexionALaBase;
                comandoAEjecutar.CommandType = CommandType.Text;
                comandoAEjecutar.CommandText = "select * from Software";

                if (conexionALaBase.State != ConnectionState.Open)
                {
                    conexionALaBase.Open();
                }

                SqlDataReader lector = comandoAEjecutar.ExecuteReader();

                while (lector.Read())
                {
                    listaDeProductos.Add(new Software((int)((decimal)lector["idSoftware"]), lector["nombre"].ToString(), (double)lector["precio"], (int)((decimal)lector["cantidad"]), lector["licenciaDelSoftware"].ToString()));
                }


                return listaDeProductos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conexionALaBase.State != ConnectionState.Closed)
                {
                    conexionALaBase.Close();
                }
            }
        }

        /// <summary>
        /// Utilizado para insertar productos a la tabla Hardware en la base de datos
        /// </summary>
        /// <param name="auxHardware"></param>
        /// <returns></returns>
        public static bool InsertarHardware(Hardware auxHardware)
        {
            SqlCommand comandoAEjecutar;
            comandoAEjecutar = new SqlCommand();
            bool exito = false;
            try
            {
                comandoAEjecutar.Connection = conexionALaBase;
                comandoAEjecutar.CommandType = CommandType.Text;

                comandoAEjecutar.CommandText = "Insert into Hardware(nombre,precio, cantidad, numeroDeParte)" +
                "values(@auxNombre,@auxPrecio, @auxCantidad, @numeroDeParte)"; ;

                comandoAEjecutar.Parameters.Clear();
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxNombre", auxHardware.NombreProducto));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxPrecio", auxHardware.Precio));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxCantidad", auxHardware.Cantidad));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@numeroDeParte", auxHardware.NumeroDeParte));

                if (conexionALaBase.State != ConnectionState.Open)
                {
                    conexionALaBase.Open();
                }

                comandoAEjecutar.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception e)
            {
                exito = false;
                throw e;
            }
            finally
            {
                if (conexionALaBase.State != ConnectionState.Closed)
                {
                    conexionALaBase.Close();
                }
            }

            return exito;
        }

        /// <summary>
        /// Utilizado para insertar productos a la tabla Software en la base de datos
        /// </summary>
        /// <param name="auxSoftware"></param>
        /// <returns></returns>
        public static bool InsertarSoftware(Software auxSoftware)
        {
            SqlCommand comandoAEjecutar;
            comandoAEjecutar = new SqlCommand();
            bool exito = false;
            try
            {
                comandoAEjecutar.Connection = conexionALaBase;
                comandoAEjecutar.CommandType = CommandType.Text;

                comandoAEjecutar.CommandText = "Insert into Software(nombre,precio, cantidad, licenciaDelSoftware)" +
                "values(@auxNombre,@auxPrecio, @auxCantidad, @licenciaDelSoftware)"; ;

                comandoAEjecutar.Parameters.Clear();
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxNombre", auxSoftware.NombreProducto));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxPrecio", auxSoftware.Precio));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxCantidad", auxSoftware.Cantidad));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@licenciaDelSoftware", auxSoftware.LicenciaDelSoftware));

                if (conexionALaBase.State != ConnectionState.Open)
                {
                    conexionALaBase.Open();
                }

                comandoAEjecutar.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception e)
            {
                exito = false;
                throw e;
            }
            finally
            {
                if (conexionALaBase.State != ConnectionState.Closed)
                {
                    conexionALaBase.Close();
                }
            }

            return exito;
        }

        /// <summary>
        /// Realiza un update en la base de datos, actualizando el campo cantidad 
        /// Es utilizado cuando se realizan ventas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="productoParaActualizar"></param>
        /// <returns></returns>
        public static bool ActualizarProductoVendido<T>(T productoParaActualizar) where T : Producto
        {
            SqlCommand comandoAEjecutar;
            comandoAEjecutar = new SqlCommand();
            bool exito = false;
            try
            {
                comandoAEjecutar.Connection = conexionALaBase;
                comandoAEjecutar.CommandType = CommandType.Text;

                if (productoParaActualizar.GetType() == typeof(Software))
                {
                    comandoAEjecutar.CommandText = "Update Software Set cantidad = @auxCantidad" + " " + 
                    "where idSoftware = @auxId"; 
                }
                else
                {
                    comandoAEjecutar.CommandText = "Update Hardware Set cantidad = @auxCantidad" + " " +
                    "where idHardware = @auxId";
                }

                comandoAEjecutar.Parameters.Clear();
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxId", productoParaActualizar.IdProducto));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxCantidad", productoParaActualizar.Cantidad));

                if (conexionALaBase.State != ConnectionState.Open)
                {
                    conexionALaBase.Open();
                }

                comandoAEjecutar.ExecuteNonQuery();
                exito = true;

            }
            catch(Exception error)
            {
                throw error;
            }
            return exito;
        }



    }

}

