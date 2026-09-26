SELECT @@VERSION AS VersionServidor;
select SERVERPROPERTY('ServerName') AS NombreServidor;

Create Database TiendaBD;
GO
USE TiendaBD;
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

insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('Tenis',30.40,4,2);
insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('cartera',60.40,10,3);
insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('chaqueta',100.00,20,1);

insert into Producto (Nombre,Precio,Stock,IdCategoria) values ('Botas',240.00,5,2),('Gorra',90.00,5,1),('Bufanda',50.00,11,3);

select * from Producto

select p.Nombre,p.Precio,c.Nombre as categoria_nombre from Producto p
Inner join Categoria c on p.IdCategoria = c.IdCategoria
-- and or
select * from Producto where Stock >=10 and nombre<>'Tenis'
select * from Producto where Stock >=10 or nombre<>'Tenis'

--order by
-- desc, nos sirve para ordenar desendentemente mayor a menos
-- asc de menor a mayor 
select * from Producto
ORDER BY Nombre asc


select * 
from Producto 
where Precio > 51 
order by Precio desc

-- buscar texto con LIKE el like solo se utiliza para cadenas o textos 
-- 'c%' comienza con "C" busca para adelante 
-- '%a' termina con "a"
--'%ta%' contenga la "ta"

select * 
from Producto
where Nombre like '%eta'
--Between

select * 
from Producto
where Precio between 50 and 70
--=
select * 
from Producto
where Precio >=50 and precio <= 70

--  ejercicio usando el between para stock 
select * 
from Producto
where Stock between 1 and 90

-- modificar 
-- siempre al hacer un UPDATE simpre tenemos que poner un where  sin usar el where  todos los productos se van a cambiar
select * from Producto
where Nombre='Camiseta'

Update Producto
set Precio = 60.50,
	Stock = 20
where Nombre='Camiseta'


select * from Producto
where Nombre='zapatilla'

Update Producto
set IdCategoria=3
	
where Nombre='lentes de sol'

Update Producto
set Stock= Stock - 3
where Nombre='lentes de sol'

select p.IdProducto, p.Nombre,p.Precio, p.Stock,c.Nombre as categoria_nombre from Producto p
Inner join Categoria c on p.IdCategoria = c.IdCategoria

Update Producto
set Nombre = 'Gafas de Sol'
where IdProducto=4

-- DELETE

select * from Producto
Delete from Producto
where Nombre='Pantalon'