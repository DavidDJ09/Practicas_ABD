using BACKEND;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_1_ABD
{
    public partial class frmRegistroProductos : Form
    {
        public bool Guardado { get; set; }
        public frmRegistroProductos()
        {
            InitializeComponent();
            cboArea.DataSource=new DAOProducto().ObtenerAreas();
            cboArea.DisplayMember="Nombre";
            cboArea.ValueMember="Id";
        }
        private int idRegistro;
        public frmRegistroProductos(int id) : this()
        {
            idRegistro = id;
            //Cargar el usuario de la BD
            try
            {
                Producto objInventario = new DAOProducto().ObtenerUno(id);
                txtId.Text = objInventario.Id.ToString();
                txtNombre.Text = objInventario.NombreCorto;
                txtDescripcion.Text = objInventario.Descripcion;
                txtSerie.Text = objInventario.Serie;
                txtColor.Text = objInventario.Color;
                dtpFecha.Value = objInventario.FechaAdquisicion;
                txtObservaciones.Text = objInventario.Observaciones;
                cboTipo.Text = objInventario.TipoAdquisicion.ToString();
                //cboArea.SelectedIndex=Convert.ToInt32(objInventario.AREAS_Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
                try
                {
                    Producto objInventario = new Producto();
                objInventario.Id = Convert.ToInt32(txtId.Text.Trim());
                objInventario.NombreCorto = txtNombre.Text.Trim();
                objInventario.Descripcion = txtDescripcion.Text.Trim();
                objInventario.Serie = txtSerie.Text.Trim();
                objInventario.Color = txtColor.Text.Trim();
                objInventario.FechaAdquisicion = dtpFecha.Value;
                objInventario.TipoAdquisicion = cboTipo.SelectedItem.ToString().Trim();
                objInventario.Observaciones = txtObservaciones.Text.Trim();
                objInventario.AREAS_Id = Convert.ToInt32(cboArea.SelectedValue);
                bool resultado = false;
                    //Agregar empleado
                    if (idRegistro == 0)
                    {
                        int idGenerado = new DAOProducto().agregar(objInventario);
                        resultado = (idGenerado > 0);
                    }
                    else
                    {//Modificar el usuario
                        objInventario.Id = idRegistro;
                        resultado = new DAOProducto().editar(objInventario);
                    }

                    if (resultado)
                    {
                        Guardado = true;
                        MessageBox.Show("Registro almacenado correctamente", "Guardado", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Se ha encontrado un error al almacenar, verifique la información" +
                            " e inténtelo de nuevo más tarde", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(this, ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Datos incompletos o inválidos " +
            //        "\nPosiciona el cursor sobre las cajas de texto para obtener más información ",
            //        "Error", MessageBoxButtons.OK
            //        , MessageBoxIcon.Warning);
            //}
        }
    }
}
