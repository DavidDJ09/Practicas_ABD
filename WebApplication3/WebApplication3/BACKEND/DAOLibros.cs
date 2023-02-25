using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.BACKEND
{
    public class DAOLibros
    {
        public int agregar(Libro libro)
        {
            try
            {
                if (Conexion.conectar())
                {
                    SqlCommand comando = new SqlCommand(
                        @"INSERT INTO libros
                        VALUES(@id,@isbn,@titulo,@numeroEdicion,@anioPublicacion,@autores,@pais,@sinopsis,
                        @carrera,@materia);");

                    comando.Parameters.AddWithValue("@id", libro.Id);
                    comando.Parameters.AddWithValue("@isbn", libro.ISBN);
                    comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                    comando.Parameters.AddWithValue("@numeroEdicion", libro.NumeroEdicion);
                    comando.Parameters.AddWithValue("@anioPublicacion", libro.AnioPublicacion);
                    comando.Parameters.AddWithValue("@autores", libro.NombreAutores);
                    comando.Parameters.AddWithValue("@pais", libro.Pais);
                    comando.Parameters.AddWithValue("@sinopsis", libro.Sinopsis);
                    comando.Parameters.AddWithValue("@carrera", libro.Carrera);
                    comando.Parameters.AddWithValue("@materia", libro.Materia);
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    int filasAgregadas = comando.ExecuteNonQuery();

                    return filasAgregadas;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 1062) //Unique
                {
                    throw new Exception("No se pudo realizar el registro, el nombre ya se encuentra en uso");
                }
                else if (ex.Number == 1452) //Llave foránea
                {
                    throw new Exception("No se pudo realizar el registro, fallo en llenado de llaves foráneas");
                }
                else
                {
                    throw new Exception("No se pudo realizar el registro" + ex.Message);
                }
            }
            finally
            {
                Conexion.desconectar();
            }
        
        }
    }
}