using Tienda.Datos;
using Tienda.Entidades;


namespace Tienda.Presentacion
{
    public partial class FormProductos : Form
    {
        private readonly ProductoDatos productoDatos = new ProductoDatos();
        public FormProductos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                List<Producto> productos = productoDatos.ListarProductos();
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
                // opcional ocultamos  el codigo de categoria
                if (dgvProductos.Columns["IdCategoria"] != null)
                {
                    dgvProductos.Columns["IdCategoria"].Visible = false;
                }

                MessageBox.Show($"Se cargaron {productos.Count} productos.", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            txtIdProducto.Text = fila.Cells["IdProducto"].Value.ToString();
            txtIdProducto.Text = fila.Cells["IdProducto"].Value?.ToString();

            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();

            txtPrecio.Text = fila.Cells["Precio"].Value?.ToString();

            txtStock.Text = fila.Cells["Stock"].Value?.ToString();

            txtIdCategoria.Text = fila.Cells["IdCategoria"].Value?.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtIdCategoria.Clear();
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }
    }
}
