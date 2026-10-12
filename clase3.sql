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

CREATE OR ALTER PROCEDURE usp_BuscarPorProducto
	@Nombre NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdProducto, Nombre AS Producto, Precio, Stock
	FROM Producto
	WHERE Nombre LIKE '%' + @Nombre + '%'
	ORDER BY Nombre;
END;
GO



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

CREATE OR ALTER PROCEDURE dbo.usp_EliminarProducto
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Producto WHERE IdProducto = @IdProducto)
    BEGIN
        RETURN;
    END

    DELETE FROM Producto
    WHERE IdProducto = @IdProducto;
END;
GO

create or alter procedure dbo.usp_actualizarProducto
	@IdProducto int,
	@nombre Nvarchar(100),
	@Precio Decimal(10,2),
	@Stock int,
	@IdCategoria int
as 
begin 
	set nocount on;
	--verificar si el producto existe 
	if not exists
	(
		select 1
		from Producto
		where IdProducto = @IdProducto
	)
	begin
		return -1
	end;
	--validar nombre
	if LTRIM(rtrim(isnull(@nombre,'')))=''
	begin 
		return -2;
	end;
	--validar el precio
	if @Precio<=0
	begin 
		return -3;
	end;

	--validar stock

	if @Stock <0
	begin 
		return -4
	end
	--verificar si la categoria existe
	if not exists
	(
		select 1
		from Categoria
		where IdCategoria = @IdCategoria
	)
	begin
		return -5;
	end;

	update Producto
	set
		Nombre=@nombre,
		Precio=@Precio,
		Stock=@Stock,
		IdCategoria=@IdCategoria
	where IdProducto=@IdProducto

	return 1;

end;

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
