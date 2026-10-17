using Tienda.Datos;
using Tienda.Entidades;


namespace Tienda.Presentacion
{
    public partial class FormProductos : Form
    {
        private readonly ProductoDatos productoDatos= new ProductoDatos();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }
    }
}
