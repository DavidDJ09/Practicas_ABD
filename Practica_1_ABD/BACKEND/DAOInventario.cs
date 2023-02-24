using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND
{
    public class DAOInventario
    {
        public List<Inventario> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * from Inventario;");
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Inventario> lista = new List<Inventario>();
                    Inventario objInventario = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInventario = new Inventario();
                        objInventario.Id = Convert.ToInt32(fila["Id"]);
                        objInventario.NombreCorto = fila["NombreCorto"].ToString();
                        objInventario.Descripcion = fila["Descripcion"].ToString();
                        objInventario.Serie = fila["Serie"].ToString();
                        objInventario.Color = fila["Color"].ToString();
                        objInventario.FechaAdquisicion = (DateTime)fila["FechaAdquisicion"];
                        objInventario.TipoAdquisicion = fila["TipoAdquision"].ToString();
                        objInventario.Observaciones = fila["Observaciones"].ToString();
                        objInventario.AREAS_Id = Convert.ToInt32(fila["AREAS_Id"]);

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
                throw new Exception("No se pudo obtener la información del inventariow");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

    }
}
