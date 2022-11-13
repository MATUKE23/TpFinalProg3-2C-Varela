create database ECOMMERCE
GO
use ECOMMERCE
GO
create table CATEGORIAS
(
ID int identity(1,1) primary key,
CODIGO VARCHAR(8) NOT NULL UNIQUE,
DESCRIPCION VARCHAR(50) NOT NULL,
OBS VARCHAR(200),
ESTADO BIT NOT NULL
)
GO
create table ARTICULOS
(
ID int identity(1,1) primary key,
CODIGO VARCHAR(10) NOT NULL UNIQUE,
DESCRIPCION VARCHAR(50) NOT NULL,
PRECIO float NOT NULL,
TIPO varchar(3) NOT NULL check(tipo = 'ART' OR tipo = 'CON'),
OBS VARCHAR(200),
ESTADO BIT NOT NULL,
ID_CATEGORIA INT FOREIGN KEY REFERENCES CATEGORIAS(ID) 
)


use ECOMMERCE
--Insert de Categorias
insert into CATEGORIAS(CODIGO,DESCRIPCION,OBS,ESTADO) values('1','Biombo','Madera','1')
insert into CATEGORIAS(CODIGO,DESCRIPCION,OBS,ESTADO) values('2','Sillas','Madera','1')

select * from CATEGORIAS

--Insert de Articulos
insert into ARTICULOS (CODIGO, DESCRIPCION, PRECIO,TIPO, OBS, ESTADO, ID_CATEGORIA) values('1','Biombo Soshi','2300','ART','OK','1','1')
insert into ARTICULOS (CODIGO, DESCRIPCION, PRECIO,TIPO, OBS, ESTADO, ID_CATEGORIA) values('2','Silla Bebe1','1200','ART','OK','1','2')
insert into ARTICULOS (CODIGO, DESCRIPCION, PRECIO,TIPO, OBS, ESTADO, ID_CATEGORIA) values('3','Biombo Standard','1500','ART','OK','1','2')
select * from ARTICULOS

--SELECT a.Id as id, Codigo, Nombre, a.Descripcion dart, c.descripcion  id_categoria , m.descripcion  Marca, ImagenUrl, Precio, c.Id IdCategoria, m.Id IdMarca from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdCategoria = c.Id and a.IdMarca = m.Id";

SELECT a.Id as id, A.CODIGO,  a.Descripcion dart,  A.PRECIO, A.TIPO, a.OBS, A.ESTADO, a.ID_CATEGORIA IdCategoria from ARTICULOS a

