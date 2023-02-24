using BACKEND;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DAOArea
    {
        public List<Area> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM Areas;");
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Area> lista = new List<Area>();
                    Area objArea = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objArea = new Area();
                        objArea.Id = Convert.ToInt32(fila["Id"]);
                        objArea.Nombre = fila["Nombre"].ToString();
                        objArea.Ubicacion = fila["Ubicacion"].ToString();

                        lista.Add(objArea);
                    }

                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información de las áreas" +ex.ToString());

            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Area ObtenerUno(int id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM Areas
                            WHERE Id = @Id;");

                    comando.Parameters.AddWithValue("@Id", id);
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Area objArea = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objArea = new Area();
                        objArea.Id = Convert.ToInt32(fila["Id"]);
                        objArea.Nombre = fila["Nombre"].ToString();
                        objArea.Ubicacion = fila["Ubicacion"].ToString();

                    }

                    return objArea;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la informaciónl área solicitada");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int agregar(Area area)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"INSERT INTO Areas
                        VALUES(@id,@Nombre,@Ubicacion);");

                    comando.Parameters.AddWithValue("@id", area.Id);
                    comando.Parameters.AddWithValue("@Nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@Ubicacion", area.Ubicacion);
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
            catch (MySqlException ex)
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

        public bool editar(Area area)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE Areas
                            SET Id=@Id, 
                            Nombre=@Nombre,
                            Ubicacion=@Ubicacion
                            WHERE Id=@id;");

                    comando.Parameters.AddWithValue("@id", area.Id);
                    comando.Parameters.AddWithValue("@Nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@Ubicacion", area.Ubicacion);

                    comando.Connection = Conexion.conexion;

                    int filasActualizadas = comando.ExecuteNonQuery();

                    return (filasActualizadas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) //Unique
                {
                    throw new Exception("No se pudo realizar la modificación, el nombre ya se encuentra en uso");
                }
                else if (ex.Number == 1452) //Llave foránea
                {
                    throw new Exception("No se pudo realizar la modificación, fallo en llenado de llaves foráneas");
                }
                else
                {
                    throw new Exception("No se pudo realizar la modificación" + ex.Number);
                }
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"DELETE FROM Areas 
                            WHERE Id=@id;");

                    comando.Parameters.AddWithValue("@id", id);

                    comando.Connection = Conexion.conexion;

                    int filasBorradas = comando.ExecuteNonQuery();

                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                //if (ex.Number==1451)
                //{
                //    return borradoLógico(id);
                //}
                //else
                //{
                throw new Exception("Error al intentar eliminar la categoría");
                //}
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
