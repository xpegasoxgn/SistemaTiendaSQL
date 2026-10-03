﻿using Tienda.Datos;
using Tienda.Entidades;

Console.WriteLine("Bienvenido a la clase de capas ");
Console.WriteLine("Esta es una aplicación de ejemplo para demostrar el uso de capas en .NET");


try
{
    ProductoDatos productoDatos = new ProductoDatos();

    List<Productos> productos = productoDatos.ListarProductos();

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


    // buscador de productos
    Console.WriteLine("Ingrese el nombre del producto que desea buscar:");
    string nombreProducto = Console.ReadLine();

    bool productoEncontrado = false;
    foreach (Productos producto in productos)
    {
        if (producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase))
        {
            productoEncontrado = true;
            Console.WriteLine("PRODUCTO econtrado!!!!");
            Console.WriteLine($"Producto encontrado: {producto.Nombre}");
            Console.WriteLine($"Precio: {producto.Precio:0.00} Bs");
            Console.WriteLine($"Stock: {producto.Stock}");
            Console.WriteLine($"Categoría: {producto.NombreCategoria}");
            if (producto.Stock > 0)
            {
                Console.WriteLine("El producto está disponible en stock.");
            }
            else
            {
                Console.WriteLine("El producto no está disponible en stock.");
            }
            break;
        }
    }

    if (!productoEncontrado)
    {
        Console.WriteLine("Producto no encontrado.");
    }
}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine("Ocurrió un error:");
    Console.WriteLine(ex.Message);
}