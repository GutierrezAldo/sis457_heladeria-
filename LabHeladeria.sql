CREATE DATABASE LabHeladeria;
GO
USE [master]
GO
CREATE LOGIN [usrheladeria] WITH PASSWORD = N'123456',
	DEFAULT_DATABASE = [LabHeladeria],
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = ON
GO
USE [LabHeladeria]
GO
CREATE USER [usrheladeria] FOR LOGIN [usrheladeria]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrheladeria]
GO

DROP TABLE Pedido;
DROP TABLE VentaDetalle;
DROP TABLE Venta;
DROP TABLE Cliente;
DROP TABLE Sabor;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Producto;

-- Eliminar el procedimiento almacenado si ya existe
DROP PROC paProductoListar;

CREATE TABLE Producto (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(250) NOT NULL,
  precio DECIMAL NOT NULL CHECK (precio > 0)
);
CREATE TABLE Empleado (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombres VARCHAR(30) NOT NULL,
  primerApellido VARCHAR(30) NULL,
  segundoApellido VARCHAR(30) NULL,
  cargo VARCHAR(50) NOT NULL,
  fechaContratacion DATE NOT NULL DEFAULT GETDATE(),
  telefono BIGINT NOT NULL,
  direccion VARCHAR(250) NOT NULL,
);
CREATE TABLE Usuario (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(20) NOT NULL,
  clave VARCHAR(250) NOT NULL,
  CONSTRAINT fk_Usuario_Empleado FOREIGN KEY(idEmpleado) REFERENCES Empleado(id)
);
CREATE TABLE Sabor (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idProducto INT NOT NULL,
  nombre VARCHAR(250) NULL
  CONSTRAINT fk_Sabor_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
);
CREATE TABLE Cliente (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  ci BIGINT NOT NULL,
  razonSocial VARCHAR(100) NOT NULL,
  telefono VARCHAR(30) NOT NULL
);
CREATE TABLE Venta (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idUsuario INT NOT NULL,
  idCliente INT NOT NULL,
  fecha DATE NOT NULL DEFAULT GETDATE(),
  CONSTRAINT fk_Venta_Usuario FOREIGN KEY(idUsuario) REFERENCES Usuario(id),
  CONSTRAINT fk_Venta_Cliente FOREIGN KEY(idCliente) REFERENCES Cliente(id)
);
CREATE TABLE VentaDetalle (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idVenta INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad DECIMAL NOT NULL CHECK (cantidad > 0),
  precioUnitario DECIMAL NOT NULL,
  total DECIMAL NOT NULL,
  CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY(idVenta) REFERENCES Venta(id),
  CONSTRAINT fk_VentaDetalle_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
);
CREATE TABLE Pedido (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCliente INT NOT NULL,
  idEmpleado INT NOT NULL,
  fechaPedido DATE NOT NULL DEFAULT GETDATE(),
  tipoPago VARCHAR(250) NOT NULL,
  estadoEntrega VARCHAR(250) NOT NULL,
  CONSTRAINT fk_Pedido_Cliente FOREIGN KEY(idCliente) REFERENCES Cliente(id),
  CONSTRAINT fk_Pedido_Empleado FOREIGN KEY(idEmpleado) REFERENCES Empleado(id)
);

ALTER TABLE Producto ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Sabor ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Sabor ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Sabor ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Venta ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Venta ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Venta ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE VentaDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE VentaDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE VentaDetalle ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

-- Insertar
INSERT INTO Producto (nombre, precio) VALUES ('Vaso Pequeño', 1.50),
										   ('Vaso Mediano', 2.50),
										   ('Vaso Grande', 3.50);

-- Leer
SELECT * FROM Producto;
 
-- Procedimiento Almacénado: Listar Productos
GO
CREATE PROC paProductoListar @parametro VARCHAR(100)
AS
BEGIN
	SELECT * FROM Producto
	WHERE estado = 1
	AND (nombre LIKE '%' + @parametro + '%' OR @parametro = '')
	ORDER BY nombre ASC
	END
GO

-- Ejecutar el Procedimiento Almacenado
EXEC paProductoListar @parametro = 'Vaso'









