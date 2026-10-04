USE [cursoDotNet]
GO
/****** Object:  StoredProcedure [dbo].[usp_RegistrarProductos]    Script Date: 10/4/2026 8:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   procedure [dbo].[usp_RegistrarProductos] 
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
			
			return -1;
		end
		-- validar el precio
		if @Precio is null or @Precio<=0
		begin 
			
			return -2;
		end
		-- validar stock
		if @Stock is null or @Precio<=0
		begin 
			
			return -3;
		end
		 -- Código -4: categoría inexistente
		IF NOT EXISTS
		(
			SELECT 1
			FROM dbo.Categoria
			WHERE IdCategoria = @IdCategoria
		)
		BEGIN
			RETURN -4;
		END;


		INSERT INTO Producto
			(Nombre, Precio, Stock, IdCategoria)
		VALUES
			(@Nombre, @Precio, @Stock, @IdCategoria);

		return 1;

	end