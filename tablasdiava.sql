USE MASTER
GO
DROP DATABASE diava;
CREATE DATABASE diava;
USE diava
CREATE TABLE Remito (
	[id] [int] IDENTITY(1,1) NOT NULL,
    nroremito INT NOT NULL,
    linea INT NOT NULL,
    idproducto int,
    cantidad int,
    idvehiculo int,
    primary key (id)
);

INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234567,1,1,11,2);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234567,2,3,23,2);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234568,1,2,52,3);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234568,2,4,62,3);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234569,1,1,70,1);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234569,2,2,15,1);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234569,3,5,22,1);
INSERT INTO dbo.Remito (nroremito, linea, idproducto, cantidad, idvehiculo) values (1234570,1,5,70,2);


CREATE TABLE Producto (
    [id] [int] IDENTITY(1,1) NOT NULL,
    nombre varchar(50),
    codigo int,
    lote varchar(7),
    aniovencimiento int,
    primary key (id)
);

INSERT INTO dbo.Producto (nombre, codigo, lote, aniovencimiento) values ('Producto 11', 123456785, '1000', 2024);
INSERT INTO dbo.Producto (nombre, codigo, lote, aniovencimiento) values ('Producto 12', 123456786, '1005', 2025);
INSERT INTO dbo.Producto (nombre, codigo, lote, aniovencimiento) values ('Producto 13', 123456787, '1000', 2024);
INSERT INTO dbo.Producto (nombre, codigo, lote, aniovencimiento) values ('Producto 14', 123456788, '1005', 2026);
INSERT INTO dbo.Producto (nombre, codigo, lote, aniovencimiento) values ('Producto 15', 123456789, '1000', 2027);


CREATE TABLE Conductor (
    [id] [int] IDENTITY(1,1) NOT NULL,
    nombre varchar(50),
    apellido varchar(50),
    dni int,
    legajo int,
    primary key (id)
);

INSERT INTO dbo.Conductor (nombre, apellido, dni, legajo) values ('Roberto', 'Lopez', 42125325, 1250);
INSERT INTO dbo.Conductor (nombre, apellido, dni, legajo) values ('Raul', 'Flores', 24125125, 1260);
INSERT INTO dbo.Conductor (nombre, apellido, dni, legajo) values ('Privi', 'Mage', 48175125, 1270);

CREATE TABLE Vehiculo (
    [id] [int] IDENTITY(1,1) NOT NULL,
    marca varchar(50),
    patente varchar(10),
    kmrecorridos int,
    idconductor int,
    primary key (id)
);

INSERT INTO dbo.Vehiculo (marca, patente, kmrecorridos, idconductor) values ('Peugeuot', 'AA 125 DC',47580, 1);
INSERT INTO dbo.Vehiculo (marca, patente, kmrecorridos, idconductor) values ('Ford', 'AB 525 EF',78580, 2);
INSERT INTO dbo.Vehiculo (marca, patente, kmrecorridos, idconductor) values ('Citroen', 'BA 410 GH',150580, 3);