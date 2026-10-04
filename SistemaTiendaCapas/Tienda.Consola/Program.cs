﻿﻿using Tienda.Datos;
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
        Console.WriteLine("3. Salir");
        Console.WriteLine("4. Buscar producto por nombre");
        Console.WriteLine("selecione euna ocion:   ");
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
                Console.WriteLine("Saliendo del programa...");
                break;
            case 4:
                Console.WriteLine("Ingrese el nombre del producto que desea buscar:");
                string  Producto = Console.ReadLine();
                int resultadoBusqueda = productoDatos.BuscarProducto(Producto);
                if (resultadoBusqueda > 0)
                {
                    Console.WriteLine($"Producto con nombre {Producto} encontrado.");
                }
                else
                {
                    Console.WriteLine($"Producto con nombre {Producto} no encontrado.");
                }
                break;
            case 5:
                Console.WriteLine("Ingrese el ID del producto que desea buscar:");
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
    
    List<Productos> productos = productoDatos.ListarProductos();
    Console.WriteLine("=====Productos=========");
    foreach (Productos producto in productos)
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
    Productos nuevoProducto = new Productos();
    Console.WriteLine("Ingrese el nombre del producto que desea registrar:");
    nuevoProducto.Nombre = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el precio del producto:");
    nuevoProducto.Precio = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Ingrese el stock del producto:");
    nuevoProducto.Stock = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el id de la categoria del producto:");
    nuevoProducto.IdCategoria = Convert.ToInt32(Console.ReadLine());
    int resultado = productoDatos.registrarProducto(nuevoProducto);
    Console.WriteLine("ingrese el id del producto que desea buscar:");
    int idProducto = Convert.ToInt32(Console.ReadLine());
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
        case -5:
            Console.WriteLine("buscar el producto por id");
            break;
        default:
            Console.WriteLine("Ocurrió un error al registrar el producto.");
            break;
    }
}