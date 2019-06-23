using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        //Atributos
        private static  SqlCommand comando;
        private static SqlConnection conexion;

        //Constructor de Clase
        /// <summary>
        /// Establecemos la conexion con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            string commandStr = @"Data Source= .\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";
            //string commandStr = @"Data Source= ALPHA\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";
            try
            {
                conexion = new SqlConnection(commandStr);
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Metodo Insertar 
        /// </summary>
        /// <param name="p">Paquete a insertar en la base de datos</param>
        /// <returns>true = lo inserto correctamente - false = no pudo insertarlo</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string peticion;
            peticion = string.Format("INSERT INTO Paquetes(direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','Navarro Nicolas')",p.DireccionEntrega,p.TrackingID);
            try
            {
                comando.CommandText = peticion;
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch(Exception)
            {
                retorno = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return retorno;
        }
    }
}
