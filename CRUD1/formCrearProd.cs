using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD1
{
    public partial class formCrearProd : Form
    {
        private static int id = 0;

        DbConection clsDbConection = new DbConection();

        public formCrearProd()
        {
            InitializeComponent();
        }

        /*private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/

        private void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = clsDbConection.Listar();
        }

        private void formCrearProd_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnCrearProd_Click(object sender, EventArgs e)
        {
            CRUDTable objAgregar = new CRUDTable();
            objAgregar.nombre_producto = txtNombreProd.Text;
            objAgregar.precio_producto = Convert.ToDecimal(txtPrecioProd.Text);
            objAgregar.disponibilidad_producto = Convert.ToInt32(txtDisponProd.Text);
            objAgregar.descripcion_producto = txtDescrProd.Text;
            clsDbConection.Agregar(objAgregar);
            Limpiar();
            MessageBox.Show("Registro Guardado");
            Cargar();
        }

        private void Limpiar()
        {
            txtNombreProd.Text = String.Empty;
            txtPrecioProd.Text = String.Empty;
            txtDisponProd.Text = String.Empty;
            txtDescrProd.Text = String.Empty;
            id = 0;
        }
        private void btnLimpiarFormulario_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Obtener(int id)
        {
            CRUDTable objeto = clsDbConection.Obtener(id);
            txtNombreProd.Text = objeto.nombre_producto;
            txtPrecioProd.Text = Convert.ToString(objeto.precio_producto);
            txtDisponProd.Text = Convert.ToString(objeto.disponibilidad_producto);
            txtDescrProd.Text = objeto.descripcion_producto;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    id = int.Parse(row.Cells[0].Value.ToString());
                    Obtener(id);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                CRUDTable objAgregar = new CRUDTable();
                objAgregar.id_productos = id;
                objAgregar.nombre_producto = txtNombreProd.Text;
                objAgregar.precio_producto = Convert.ToDecimal(txtPrecioProd.Text);
                objAgregar.disponibilidad_producto = Convert.ToInt32(txtDisponProd.Text);
                objAgregar.descripcion_producto = txtDescrProd.Text;
                clsDbConection.Actualizar(objAgregar);
                Limpiar();
                MessageBox.Show("Registro actualizado");
                Cargar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id !=0)
            {
                clsDbConection.Eliminar(id);
                Limpiar();
                MessageBox.Show("Registro eliminado");
                Cargar();
            }
        }
    }
}
