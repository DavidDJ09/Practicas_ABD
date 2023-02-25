using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.BACKEND;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Libro objLibro = new Libro();
                objLibro.Id = Convert.ToInt32(txtId.Text.Trim());
                objLibro.ISBN = txtIsbn.Text.Trim();
                objLibro.Titulo = txtTitulo.Text.Trim();
                objLibro.NumeroEdicion = Convert.ToInt32(txtNumEdicion.Text.Trim());
                objLibro.AnioPublicacion = txtAnio.Text.Trim();
                objLibro.NombreAutores = txtAutores.Text.Trim();
                objLibro.Pais = txtPais.Text.Trim();
                objLibro.Sinopsis = txtSinopsis.Text.Trim();
                objLibro.Carrera = txtCarrera.Text.Trim();
                objLibro.Materia = txtMateria.Text.Trim();

                bool resultado = false;

                int idGenerado = new DAOLibros().agregar(objLibro);
                resultado = (idGenerado > 0);

                if (resultado)
                {
                    lblResultado.Text="Registro realizado correctamente";

                    gdvDatos.DataSourceID="SqlDataSource1";

                    txtId.Text="";
                    txtIsbn.Text="";
                    txtTitulo.Text="";
                    txtNumEdicion.Text="";
                    txtAnio.Text="";
                    txtAutores.Text="";
                    txtPais.Text="";
                    txtSinopsis.Text="";
                    txtCarrera.Text="";
                    txtMateria.Text="";
                }
                else
                {
                    lblResultado.Text="No fue posible realizar el registro";
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text="No fue posible conectarse a la base de datos "+ex.Message;
            }
        }
    }
}