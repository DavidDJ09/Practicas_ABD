using BACKEND;
using BE;
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
    public partial class frmRegistroAreas : Form
    {
        public bool Guardado { get; set; }
        public frmRegistroAreas()
        {
            InitializeComponent();
        }

        private int idRegistro;
        public frmRegistroAreas(int id) : this()
        {
            idRegistro = id;
            //Cargar el usuario de la BD
            try
            {
                Area objArea = new DAOArea().ObtenerUno(id);
                txtId.Text = objArea.Id.ToString();
                txtNombre.Text = objArea.Nombre;
                txtUbicacion.Text = objArea.Ubicacion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Area objArea = new Area();
                objArea.Id = Convert.ToInt32(txtId.Text.Trim());
                objArea.Nombre = txtNombre.Text.Trim();
                objArea.Ubicacion = txtUbicacion.Text.Trim();
                bool resultado = false;
                //Agregar empleado
                if (idRegistro == 0)
                {
                    int idGenerado = new DAOArea().agregar(objArea);
                    resultado = (idGenerado > 0);
                }
                else
                {//Modificar el usuario
                    objArea.Id = idRegistro;
                    resultado = new DAOArea().editar(objArea);
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
