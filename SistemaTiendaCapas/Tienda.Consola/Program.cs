using Tienda.Datos;
using Tienda.Entidades;

Console.WriteLine("Bienvenido a la clase de capas ");
Console.WriteLine("Esta es una aplicación de ejemplo para demostrar el uso de capas en .NET");

try
{
    ProductoDatos productoDatos = new ProductoDatos();

    //List<Producto> productos = productoDatos.ListarProductos();

    //foreach (Producto producto in productos)
    //{
    //    Console.WriteLine();
    //    Console.WriteLine(
    //        $"Código: {producto.IdProducto}");

    //    Console.WriteLine(
    //        $"Producto: {producto.Nombre}");

    //    Console.WriteLine(
    //        $"Precio: {producto.Precio:0.00} Bs");

    //    Console.WriteLine(
    //        $"Stock: {producto.Stock}");

    //    Console.WriteLine(
    //        $"Categoría: {producto.NombreCategoria}");

    //    Console.WriteLine("----------------------------------");
    //}

    //Console.WriteLine(
    //    $"Total de productos: {productos.Count}");


    //// buscador de productos
    //Producto nuevoProducto =new Producto();
    //Console.WriteLine("Ingrese el nombre del producto que desea buscar:");
    //nuevoProducto.Nombre = Console.ReadLine()?? "";
    //Console.WriteLine("Ingrese el precio del producto:");
    //nuevoProducto.Precio = Convert.ToDecimal(Console.ReadLine());
    //Console.WriteLine("Ingrese el stock del producto:");
    //nuevoProducto.Stock = Convert.ToInt32(Console.ReadLine());
    //Console.WriteLine("Ingrese el id de la categoria del producto:");
    //nuevoProducto.IdCategoria = Convert.ToInt32(Console.ReadLine());


    //int resultado = productoDatos.RegistrarProducto(nuevoProducto);
    //switch(resultado)
    //{
    //    case 1:
    //        Console.WriteLine("Producto registrado exitosamente.");
    //        break;
    //    case -1:
    //        Console.WriteLine("Debe introducir un nombre valido.");
    //        break;
    //    case -2:
    //        Console.WriteLine("Debe introducir un precio valido y mayor a 0.");
    //        break;
    //    case -3:
    //        Console.WriteLine("Debe introducir un stock valido.");
    //        break;
    //    case -4:
    //        Console.WriteLine("Debe introducir un id de categoria valido mayor a 0.");
    //        break;
    //    default:
    //        Console.WriteLine("Ocurrió un error al registrar el producto.");
    //        break;
    //}


    //List<Producto> productosActualizados = productoDatos.ListarProductos();

    //foreach (Producto producto in productosActualizados)
    //{
    //    Console.WriteLine();
    //    Console.WriteLine(
    //        $"Código: {producto.IdProducto}");

    //    Console.WriteLine(
    //        $"Producto: {producto.Nombre}");

    //    Console.WriteLine(
    //        $"Precio: {producto.Precio:0.00} Bs");

    //    Console.WriteLine(
    //        $"Stock: {producto.Stock}");

    //    Console.WriteLine(
    //        $"Categoría: {producto.NombreCategoria}");

    //    Console.WriteLine("----------------------------------");
    //}


    int opcion;
    do
    {
        Console.WriteLine();
        Console.WriteLine("============MENU DE OPCIONES============");
        Console.WriteLine("1. Listar productos");
        Console.WriteLine("2. Registrar producto");
        Console.WriteLine("3. Buscar productos");
        Console.WriteLine("4. Salir");
        Console.Write("selecione una opcion: ");
        //Agregar la opcion para buscar productos
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                MostrarProductos(productoDatos);
                break;
            case 2:
                RegistrarProducto(productoDatos);
                break;
            case 3:
                BuscarProducto(productoDatos);
                break;
            case 4:
                Console.WriteLine("Saliendo del programa...");
                break;

            default:
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                break;

        }
    } while (opcion != 4);
}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine("Ocurrió un error:");
    Console.WriteLine(ex.Message);
}

static void MostrarProductos(ProductoDatos productoDatos)
{
    List<Producto> productos = productoDatos.ListarProductos();
    Console.WriteLine("=====Productos=========");
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

static void RegistrarProducto(ProductoDatos productoDatos)
{
    Producto nuevoProducto = new Producto();
    Console.WriteLine("Ingrese el nombre del producto que desea registrar:");
    nuevoProducto.Nombre = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el precio del producto:");
    nuevoProducto.Precio = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Ingrese el stock del producto:");
    nuevoProducto.Stock = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el id de la categoria del producto:");
    nuevoProducto.IdCategoria = Convert.ToInt32(Console.ReadLine());
    int resultado = productoDatos.RegistrarProducto(nuevoProducto);
    switch (resultado)
    {
        case 1:
            Console.WriteLine("Producto registrado exitosamente.");
            break;
        case -1:
            Console.WriteLine("Debe introducir un nombre valido.");
            break;
        case -2:
            Console.WriteLine("Debe introducir un precio valido y mayor a 0.");
            break;
        case -3:
            Console.WriteLine("Debe introducir un stock valido.");
            break;
        case -4:
            Console.WriteLine("Debe introducir un id de categoria valido mayor a 0.");
            break;
        default:
            Console.WriteLine("Ocurrió un error al registrar el producto.");
            break;
    }
}

static void BuscarProducto(ProductoDatos productoDatos)
{
    Console.WriteLine();
    Console.WriteLine("===== Buscar Producto =====");
    Console.Write("Ingrese parte del nombre del producto a buscar: ");
    string textoBuscar = Console.ReadLine() ?? "";

    List<Producto> productos = productoDatos.ListarProductos();
    bool encontrado = false;

    foreach (Producto producto in productos)
    {
        if (producto.Nombre != null && producto.Nombre.Contains(textoBuscar, StringComparison.OrdinalIgnoreCase))
        {
            encontrado = true;
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Código: {producto.IdProducto}");
            Console.WriteLine($"Producto: {producto.Nombre}");
            Console.WriteLine($"Precio: {producto.Precio:0.00} Bs");
            Console.WriteLine($"Stock: {producto.Stock}");
            Console.WriteLine($"Categoría: {producto.NombreCategoria}");
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("No se encontraron productos con ese criterio de búsqueda.");
    }
}