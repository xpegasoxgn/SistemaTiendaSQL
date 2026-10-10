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
        Console.WriteLine("3. Eliminar producto");
        Console.WriteLine("4. Actualizar producto");
        Console.WriteLine("0. Salir");
        Console.WriteLine("selecione una opcion:   ");
        opcion = Convert.ToInt32(Console.ReadLine());
        switch(opcion)
        {
            case 1:
                MostrarProductos(productoDatos);
                break;
            case 2:
                RegistrarProducto(productoDatos);
                break;
            case 3:
                EliminarProducto(productoDatos);
                break;
            case 4:
                ActualizarProducto(productoDatos);
                break;
            case 0:
                Console.WriteLine("Saliendo del programa...");
                break;

            default:
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                break;

        }
    } while (opcion != 0);
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
            Console.WriteLine("Debe indicado no exite.");
            break;
        case -2:
            Console.WriteLine("debe introducir un nombre valido.");
            break;
        case -3:
            Console.WriteLine("Debe introducir un precio valido.");
            break;
        case -4:
            Console.WriteLine("Debe introducir stock valido.");
            break;
        default:
            Console.WriteLine("Ocurrió un error al registrar el producto.");
            break;
    }
}

static void EliminarProducto(ProductoDatos productoDatos)
{
    Console.WriteLine();
    Console.WriteLine("=====Eliminar Producto=========");
    Console.WriteLine("Ingrese el ID del producto que desea eliminar:");

    string entrada = Console.ReadLine()??"";
    
    bool esnumero = int.TryParse(entrada, out int idProducto);
    if (!esnumero || idProducto <= 0)
    {
        Console.WriteLine("Debe introducir un ID de producto valido.");
        return;
    }
    Console.WriteLine("esta seguro que desea eliminar el producto? (s/n)");
    string confirmacion = Console.ReadLine() ?? "N";
    if (confirmacion.ToLower() != "s")
    {
        Console.WriteLine("Eliminación cancelada.");
        return;
    }
    try
    {

        bool resultado = productoDatos.EliminarProducto(idProducto);
        if (resultado)
        {
            Console.WriteLine("Producto eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("El producto no existe.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error al eliminar el producto: " + ex.Message);
    }

}

static void ActualizarProducto(ProductoDatos productoDatos)
{
    Producto productoActualizado = new Producto();
    Console.WriteLine("Ingrese el ID del producto que desea actualizar:");
    productoActualizado.IdProducto = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el nuevo nombre del producto:");
    productoActualizado.Nombre = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el nuevo precio del producto:");
    productoActualizado.Precio = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Ingrese el nuevo stock del producto:");
    productoActualizado.Stock = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el nuevo ID de la categoría del producto:");
    productoActualizado.IdCategoria = Convert.ToInt32(Console.ReadLine());
    int resultado = productoDatos.ActualizarProducto(productoActualizado);
    switch (resultado)
    {
        case 1:
            Console.WriteLine("Producto registrado exitosamente.");
            break;
        case -1:
            Console.WriteLine("Debe indicado no exite.");
            break;
        case -2:
            Console.WriteLine("debe introducir un nombre valido.");
            break;
        case -3:
            Console.WriteLine("Debe introducir un precio valido.");
            break;
        case -4:
            Console.WriteLine("Debe introducir stock valido.");
            break;
        case -5:
            Console.WriteLine("Debe introducir stock valido.");
            break;
        default:
            Console.WriteLine("Ocurrió un error al registrar el producto.");
            break;
    }
}