using Tienda.Datos;
using Tienda.Entidades;

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


    //Buscador de Productos
    Console.WriteLine("Ingrese el nombre del producto que desea buscar:");
    string nombreProducto = Console.ReadLine();

    bool productoEncontrado = false;
    foreach (Producto producto in productos)
    {
        if (producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase))
        {
            productoEncontrado = true;
            Console.WriteLine("PRODUCTO ENCONTRADO!");
            Console.WriteLine($"ID: {producto.IdProducto}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: {producto.Precio}");
            Console.WriteLine($"Stock: {producto.Stock}");
            Console.WriteLine($"Categoria: {producto.NombreCategoria}");
            if (producto.Stock > 0)
            {
                Console.WriteLine("El producto está disponible.");
            }
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
        }
    }
    if (!productoEncontrado)
    {
        Console.WriteLine("Producto no encontrado.");
    }

    // Permitir buscar escribiendo solamente una parte del nombre del producto Contains
    Console.WriteLine();
    Console.WriteLine("Ingrese parte del nombre del producto a buscar:");
    string textoBuscar = Console.ReadLine();

    bool huboCoincidencias = false;

    foreach (Producto producto in productos)
    {
        // Contains con OrdinalIgnoreCase ignora mayúsculas y minúsculas
        if (producto.Nombre != null && producto.Nombre.Contains(textoBuscar, StringComparison.OrdinalIgnoreCase))
        {
            huboCoincidencias = true;
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRODUCTO ENCONTRADO!");
            Console.WriteLine($"ID: {producto.IdProducto}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: {producto.Precio}");
            Console.WriteLine($"Stock: {producto.Stock}");
            Console.WriteLine($"Categoria: {producto.NombreCategoria}");
            if (producto.Stock > 0)
            {
                Console.WriteLine("El producto está disponible.");
            }
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
        }
    }

    if (!huboCoincidencias)
    {
        Console.WriteLine("No se encontraron productos que contengan ese término.");
    }



}

catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine("Ocurrió un error:");
    Console.WriteLine(ex.Message);
}