exec usp_listarProductos

Create Or alter Procedure usp_listarProductos
as
begin
	set nocount on;

	select  
		p.IdProducto,
		p.Nombre as Producto,
		p.Precio,
		p.Stock,
		c.Nombre as Categoria
	from Producto p
	inner Join Categoria c
	ON p.IdCategoria = c.IdCategoria
	order by p.Nombre;
end;
GO