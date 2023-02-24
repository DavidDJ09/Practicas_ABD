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
    public partial class frmAreas : Form
    {
        public bool Borrado { get; set; }
        public frmAreas()
        {
            InitializeComponent();
            this.dgvAreas.DefaultCellStyle.Font = new Font("Tahoma", 10);
            this.dgvAreas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            cargarTabla();
        }

        private void cargarTabla()
        {
            dgvAreas.DataSource = new DAOArea().ObtenerTodos();
            //dgvInventario.Columns["Id"].Visible=false;
            dgvAreas.Columns["Ubicacion"].HeaderText="Ubicación";
            foreach (DataGridViewColumn columna in dgvAreas.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRegistroAreas registro = new frmRegistroAreas();
            registro.ShowDialog();
            if (registro.Guardado==true)
            {
                cargarTabla();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count>0)
            {
                int id = int.Parse(dgvAreas.SelectedRows[0].Cells["Id"].Value.ToString());

                int categoria = dgvAreas.SelectedRows[0].Index;
                frmRegistroAreas producto = new frmRegistroAreas(id);

                producto.ShowDialog();
                if (producto.Guardado==true)
                {
                    //Actualizar la lista
                    cargarTabla();
                }
            }
            else
            {
                MessageBox.Show("Selecciona el registro a editar", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una registro a eliminar", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de eliminar el registro de " +
                    dgvAreas.SelectedRows[0].Cells[1].Value.ToString() + "?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    try
                    {
                        int seleccion = Convert.ToInt32(dgvAreas.SelectedRows[0].Cells[0].Value.ToString());
                        if (new DAOArea().eliminar(seleccion))
                        {
                            Borrado=true;
                            MessageBox.Show("Registro eliminado correctamente", "Eliminado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            cargarTabla();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
