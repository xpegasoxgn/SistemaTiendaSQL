using Tienda.Entidades;
using Tienda.Datos;

Console.WriteLine("Bienvenido a la clase de capas");
Console.WriteLine("Esta es una aplicación de consola que demuestra la arquitectura de capas en .NET.");


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
            $"Stock: {producto.stock}");

        Console.WriteLine(
            $"Categoría: {producto.nombreCategoria}");

    }

}
catch (Exception ex)
{
    Console.WriteLine("Ocurrió un error al listar los productos: " + ex.Message);
}