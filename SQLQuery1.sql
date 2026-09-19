SELECT @@VERSION AS VersionServidor;
select SERVERPROPERTY('ServerName') AS NombreServidor;

Create Database TiendaBD;
GO



create table Categoria
(
	IdCategoria Int IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(100) not null
);
go
insert into Categoria(Nombre) values ('Ropa')
insert into Categoria(Nombre) values ('Calzados')
insert into Categoria(Nombre) values ('Accesorios')



select * from Categoria

create table Producto
(
	IdProducto Int IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(100) not null,
	Precio DECIMAL (10,2) not null,
	Stock int not null,
	IdCategoria int not null,
	Foreign key(IdCategoria) references Categoria(IdCategoria)
);
GO

insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('Camiseta',50.40,50,1);
insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('Pantalon',50.40,50,1);
insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('zapatilla',50.40,50,3);
insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('lentes de sol',50.40,50,2);

select * from Producto

select p.Nombre,p.Precio,c.Nombre as categoria_nombre from Producto p
Inner join Categoria c on p.IdCategoria = c.IdCategoria
