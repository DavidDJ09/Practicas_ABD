using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BACKEND;

namespace Practica_1_ABD
{
    public partial class frmProductos : Form
    {
        public bool Borrado { get; set; }
        public frmProductos()
        {
            InitializeComponent();
            this.dgvInventario.DefaultCellStyle.Font = new Font("Tahoma", 10);
            this.dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            cargarTabla();
        }

        private void cargarTabla()
        {
            dgvInventario.DataSource=new DAOProducto().ObtenerTodos();
            //dgvInventario.Columns["Id"].Visible=false;
            dgvInventario.Columns["NombreCorto"].HeaderText="Nombre";
            dgvInventario.Columns["Descripcion"].HeaderText="Descripción";
            dgvInventario.Columns["FechaAdquisicion"].HeaderText="Fecha Adqusición";
            dgvInventario.Columns["TipoAdquisicion"].HeaderText="Tipo Adqusición";
            dgvInventario.Columns["AREAS_Id"].Visible=false;
            dgvInventario.Columns["Area"].HeaderText="Área";
            foreach (DataGridViewColumn columna in dgvInventario.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRegistroProductos registro = new frmRegistroProductos();
            registro.ShowDialog();
            if (registro.Guardado==true)
            {
                cargarTabla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una registro a eliminar", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de eliminar el registro de " +
                    dgvInventario.SelectedRows[0].Cells[1].Value.ToString() + "?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    try
                    {
                        int seleccion = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells[0].Value.ToString());
                        if (new DAOProducto().eliminar(seleccion))
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count>0)
            {
                int id = int.Parse(dgvInventario.SelectedRows[0].Cells["Id"].Value.ToString());
                
                int categoria = dgvInventario.SelectedRows[0].Index;
                frmRegistroProductos producto = new frmRegistroProductos(id);
                
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
