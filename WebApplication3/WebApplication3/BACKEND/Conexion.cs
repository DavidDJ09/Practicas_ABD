using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.BACKEND
{
    public class Conexion
    {
        public static SqlConnection conexion;
        static string usuario = "sa";
        static string password = "root";
        static string bd = "practica2";
        static string servidor = "JUAN-CARLOS";
        //static string puerto = "3306";

        /// <summary>
        /// Realizar conexión a base de datos local
        /// </summary>
        /// <returns>true: se conecto sin problemas, false: no se pudo conectar</returns>
        public static bool conectar()
        {
            try
            {
                conexion = new SqlConnection("Initial Catalog="+bd+";DataSource="+servidor+";User Id="+usuario+";Password="+password);
                //"Server=LAPTOP-GS3EPFJV;Database=practica2;Trusted_Connection=True;");
                conexion.Open();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Terminar la conexión estblecida
        /// </summary>
        public static void desconectar()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception)
            { }
        }
    }
}