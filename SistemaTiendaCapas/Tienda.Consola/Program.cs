//using Tienda.Datos;
//using Tienda.Entidades;
using Tienda.Datos;
using Tienda.Entidades;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la clase de capas ");
        Console.WriteLine("Esta es una aplicación de ejemplo para demostrar el uso de capas en .NET");

        try
        {
            ProductoDatos productoDatos = new ProductoDatos();

            List<Producto> productos = productoDatos.ListarProductos();

            foreach (Producto producto in productos)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Código: {producto.IdProducto}");

                Console.WriteLine(
                    $"Producto: {producto.Nombre}");

                Console.WriteLine(
                    $"Precio: {producto.Precio:0.00} Bs");

                Console.WriteLine(
                    $"Stock: {producto.Stock}");

                Console.WriteLine(
                    $"Categoría: {producto.NombreCategoria}");

                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine(
                $"Total de productos: {productos.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("Ocurrió un error:");
            Console.WriteLine(ex.Message);
        }
    }
}