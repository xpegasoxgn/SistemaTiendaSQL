use TiendaBD


SELECT DB_NAME() AS BaseActual;
select * from Categoria
select * from Producto

select  
	p.IdProducto,
	p.Nombre as Producto,
	p.Precio,
	p.Stock,
	c.Nombre as Categoria
from Producto p
inner Join Categoria c
ON p.IdCategoria = c.IdCategoria
order by p.Nombre


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

EXEC usp_listarProductos;




select * from Producto
where IdCategoria=1


create or alter procedure usp_BuscarPorCategoria
	@IdCategoria INT
	AS 
	BEGIN
		SET NOCOUNT ON;
		select 
			p.IdProducto,
			p.Nombre AS Producto,
			p.Precio,
			p.Stock,
			c.Nombre As Categoria
		from Producto p
		inner Join Categoria c
		ON p.IdCategoria = c.IdCategoria
		where p.IdCategoria=@IdCategoria
		order by p.Nombre

	end;

go
exec usp_BuscarPorCategoria
	@IdCategoria=2;

	-- hacer un procedimiento  para filtrar productos que cuesten menos de 50.00

	INSERT INTO Producto
    (Nombre, Precio, Stock, IdCategoria)
VALUES
    ('Gorra', 45.50, 20, 3);

	
	create or alter procedure usp_RegistrarProductos 
		@Nombre nvarchar(100),
		@Precio Decimal(10,2),
		@Stock int,
		@IdCategoria int
	as
	begin
		set nocount on;

		-- validar el nombre
		if @Nombre is null or @Nombre=''
		begin
			print 'Debe introducir un nombre valido'
			return;
		end
		-- validar el precio
		if @Precio is null or @Precio<=0
		begin 
			print 'El precio debe ser mayor a 0'
			return;
		end
		-- validar stock


		INSERT INTO Producto
			(Nombre, Precio, Stock, IdCategoria)
		VALUES
			(@Nombre, @Precio, @Stock, @IdCategoria);

		print 'Producto registrado correctamente';

	end
	go

	exec usp_RegistrarProductos
	@Nombre = 'Reloj',
    @Precio = 600.30,
    @Stock = 30,
    @IdCategoria = 3;

	select * from Producto


