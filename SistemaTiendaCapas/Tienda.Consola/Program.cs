﻿using Tienda.Datos;
using Tienda.Entidades;

Console.WriteLine("Bienvenido a la clase de capas");
Console.WriteLine("Esta es una aplicación de ejemplo para demostrar el uso de capas en .NET");

try
{
    ProductoDatos productoDatos = new ProductoDatos();
    int opcion;

    do
    {
        Console.WriteLine();
        Console.WriteLine("============MENU DE OPCIONES============");
        Console.WriteLine("1. Listar productos");
        Console.WriteLine("2. Registrar producto");
        Console.WriteLine("3. Salir");
        Console.WriteLine("4. Buscar producto por nombre");
        Console.WriteLine("5. Eliminar producto");
        Console.WriteLine("6. Actualizar producto");
        Console.Write("Seleccione una opción: ");

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
                Console.WriteLine("Saliendo del programa...");
                break;
            case 4:
                Console.WriteLine("Ingrese el nombre del producto que desea buscar:");
                string nombreProducto = Console.ReadLine() ?? string.Empty;
                List<Productos> productosEncontrados = productoDatos.BuscarProducto(nombreProducto);

                if (productosEncontrados.Count > 0)
                {
                    foreach (Productos producto in productosEncontrados)
                    {
                        Console.WriteLine($"ID del producto: {producto.IdProducto}");
                        Console.WriteLine($"Nombre del producto: {producto.Nombre}");
                        Console.WriteLine($"Precio del producto: {producto.Precio:0.00} Bs");
                        Console.WriteLine($"Stock del producto: {producto.Stock}");
                        Console.WriteLine("----------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontraron productos con el nombre \"{nombreProducto}\".");
                }
                break;
            case 5:
                EliminarProducto(productoDatos);
                break;
            case 6:
                ActualizarProducto(productoDatos);
                break;
            default:
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                break;
        }
    } while (opcion != 3);
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
        Console.WriteLine($"Código: {producto.IdProducto}");
        Console.WriteLine($"Producto: {producto.Nombre}");
        Console.WriteLine($"Precio: {producto.Precio:0.00} Bs");
        Console.WriteLine($"Stock: {producto.Stock}");
        Console.WriteLine($"Categoría: {producto.NombreCategoria}");
        Console.WriteLine("----------------------------------");
    }

    Console.WriteLine($"Total de productos: {productos.Count}");
}

static void RegistrarProducto(ProductoDatos productoDatos)
{
    Productos nuevoProducto = new Productos();
    Console.WriteLine("Ingrese el nombre del producto que desea registrar:");
    nuevoProducto.Nombre = Console.ReadLine() ?? string.Empty;
    Console.WriteLine("Ingrese el precio del producto:");
    nuevoProducto.Precio = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Ingrese el stock del producto:");
    nuevoProducto.Stock = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el id de la categoria del producto:");
    nuevoProducto.IdCategoria = Convert.ToInt32(Console.ReadLine());

    int resultado = productoDatos.registrarProducto(nuevoProducto);

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

static void EliminarProducto(ProductoDatos productoDatos)
{
    Console.WriteLine();
    Console.WriteLine("=====Eliminar producto=====");
    Console.WriteLine("Ingrese el ID del producto que desea eliminar:");

    string entrada = Console.ReadLine() ?? string.Empty;
    bool esNumero = int.TryParse(entrada, out int idProducto);
    if (!esNumero || idProducto <= 0)
    {
        Console.WriteLine("Debe introducir un ID válido.");
        return;
    }

    Console.Write("¿Está seguro de eliminar el producto? (S/N): ");
    string respuesta = Console.ReadLine() ?? string.Empty;
    if (!respuesta.Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Eliminación cancelada.");
        return;
    }

    bool eliminado = productoDatos.EliminarProducto(idProducto);
    if (eliminado)
    {
        Console.WriteLine("Producto eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("No se pudo eliminar el producto. Verifique que exista.");
    }
}

static void ActualizarProducto(ProductoDatos productoDatos)
{
    Productos productosActualizados = new Productos();
    Console.WriteLine("Ingrese el ID del producto que desea actualizar:");
    productosActualizados.IdProducto = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Ingrese el nuevo nombre del producto:");
    productosActualizados.Nombre = Console.ReadLine() ?? string.Empty;

    Console.WriteLine("Ingrese el nuevo precio del producto:");
    productosActualizados.Precio = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Ingrese el nuevo stock del producto:");
    productosActualizados.Stock = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Ingrese el Id de la categoria del producto:");
    productosActualizados.IdCategoria = Convert.ToInt32(Console.ReadLine());

    int resultado = productoDatos.ActualizarProducto(productosActualizados);
    switch (resultado)
    {
        case 1:
            Console.WriteLine("Producto actualizado exitosamente.");
            break;
        case -1:
            Console.WriteLine("Producto indicado no existe.");
            break;
        case -2:
            Console.WriteLine("Debe introducir un nombre válido.");
            break;
        case -3:
            Console.WriteLine("Debe introducir un precio válido.");
            break;
        case -4:
            Console.WriteLine("Debe introducir un stock válido.");
            break;
        case -5:
            Console.WriteLine("Debe introducir un id de categoria válido.");
            break;
        default:
            Console.WriteLine("Ocurrió un error al actualizar el producto.");
            break;
    }
}