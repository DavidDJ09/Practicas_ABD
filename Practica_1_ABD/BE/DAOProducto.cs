using BE;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND
{
    public class DAOProducto
    {
        public List<Producto> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT i.*, a.nombre as area FROM Inventario i
                            JOIN Areas a ON i.areas_id=a.id
                            ORDER BY i.Id;");
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Producto> lista = new List<Producto>();
                    Producto objInventario = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInventario = new Producto();
                        objInventario.Id = Convert.ToInt32(fila["Id"]);
                        objInventario.NombreCorto = fila["NombreCorto"].ToString();
                        objInventario.Descripcion = fila["Descripcion"].ToString();
                        objInventario.Serie = fila["Serie"].ToString();
                        objInventario.Color = fila["Color"].ToString();
                        objInventario.FechaAdquisicion = (DateTime)fila["FechaAdquisicion"];
                        objInventario.TipoAdquisicion = fila["TipoAdquisicion"].ToString();
                        objInventario.Observaciones = fila["Observaciones"].ToString();
                        objInventario.AREAS_Id = Convert.ToInt32(fila["AREAS_Id"]);
                        objInventario.Area = fila["Area"].ToString();

                        lista.Add(objInventario);
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
                throw new Exception("No se pudo obtener la información del inventario"+ex.ToString());
                
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<Area> ObtenerAreas()
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
                throw new Exception("No se pudo obtener la información del inventario"+ex.ToString());

            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Producto ObtenerUno(int id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT i.*, a.nombre as area FROM Inventario i
                            JOIN Areas a ON i.areas_id=a.id
                            WHERE i.Id = @Id;");

                    comando.Parameters.AddWithValue("@Id", id);
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Producto objInventario = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInventario = new Producto();
                        objInventario.Id = Convert.ToInt32(fila["Id"]);
                        objInventario.NombreCorto = fila["NombreCorto"].ToString();
                        objInventario.Descripcion = fila["Descripcion"].ToString();
                        objInventario.Serie = fila["Serie"].ToString();
                        objInventario.Color = fila["Color"].ToString();
                        objInventario.FechaAdquisicion = (DateTime)fila["FechaAdquisicion"];
                        objInventario.TipoAdquisicion = fila["TipoAdquisicion"].ToString();
                        objInventario.Observaciones = fila["Observaciones"].ToString();
                        objInventario.AREAS_Id = Convert.ToInt32(fila["AREAS_Id"]);
                        objInventario.Area = fila["Area"].ToString();

                    }

                    return objInventario;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información de la categoría");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int agregar(Producto inventario)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"INSERT INTO Inventario
                        VALUES(@id,@NombreCorto,@Descripcion,@Serie,@Color,@FechaAdquisicion,@TipoAdquisicion,
                        @Observaciones,@AREAS_Id);");

                    comando.Parameters.AddWithValue("@id", inventario.Id);
                    comando.Parameters.AddWithValue("@NombreCorto", inventario.NombreCorto);
                    comando.Parameters.AddWithValue("@Descripcion", inventario.Descripcion);
                    comando.Parameters.AddWithValue("@Serie", inventario.Serie);
                    comando.Parameters.AddWithValue("@Color", inventario.Color);
                    comando.Parameters.AddWithValue("@FechaAdquisicion", inventario.FechaAdquisicion);
                    comando.Parameters.AddWithValue("@TipoAdquisicion", inventario.TipoAdquisicion);
                    comando.Parameters.AddWithValue("@Observaciones", inventario.Observaciones);
                    comando.Parameters.AddWithValue("@AREAS_Id", inventario.AREAS_Id);
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

        public bool editar(Producto inventario)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE Inventario
                            SET Id=@Id, 
                            NombreCorto=@NombreCorto,
                            Descripcion=@Descripcion,
                            Serie=@Serie,
                            Color=@Color,
                            FechaAdquisicion=@FechaAdquisicion,
                            TipoAdquisicion=@TipoAdquisicion,
                            Observaciones=@Observaciones,
                            AREAS_Id=@AREAS_Id
                            WHERE Id=@id");

                    comando.Parameters.AddWithValue("@id", inventario.Id);
                    comando.Parameters.AddWithValue("@NombreCorto", inventario.NombreCorto);
                    comando.Parameters.AddWithValue("@Descripcion", inventario.Descripcion);
                    comando.Parameters.AddWithValue("@Serie", inventario.Serie);
                    comando.Parameters.AddWithValue("@Color", inventario.Color);
                    comando.Parameters.AddWithValue("@FechaAdquisicion", inventario.FechaAdquisicion);
                    comando.Parameters.AddWithValue("@TipoAdquisicion", inventario.TipoAdquisicion);
                    comando.Parameters.AddWithValue("@Observaciones", inventario.Observaciones);
                    comando.Parameters.AddWithValue("@AREAS_Id", inventario.AREAS_Id);

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
                        @"DELETE FROM Inventario 
                            WHERE Id=@id");

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
