CREATE DATABASE LabHeladeria;
GO
USE [master]
GO
CREATE LOGIN [usrheladeria] WITH PASSWORD = N'123456',
	DEFAULT_DATABASE = [LabHeladeria],
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = ON
--GO
USE [LabHeladeria]
GO
CREATE USER [usrheladeria] FOR LOGIN [usrheladeria]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrheladeria]
GO

DROP TABLE VentaDetalle;
DROP TABLE Venta;
DROP TABLE Cliente;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Producto;

-- Eliminar el procedimiento almacenado si ya existe
DROP PROC paProductoListar;

CREATE TABLE Producto (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(80) NOT NULL,
  unidaMedida VARCHAR(20) NOT NULL,
  sabor VARCHAR(20) NOT NULL,
  precio DECIMAL NOT NULL CHECK (precio > 0),
  stock INT NOT NULL DEFAULT 0
);
CREATE TABLE Empleado (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombres VARCHAR(30) NOT NULL,
  primerApellido VARCHAR(30) NULL,
  segundoApellido VARCHAR(30) NULL,
  fechaContratacion DATE NOT NULL,
  telefono BIGINT NOT NULL,
  direccion VARCHAR(250) NOT NULL,
);
CREATE TABLE Usuario (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(20) NOT NULL,
  clave VARCHAR(250) NOT NULL,
  role VARCHAR(20) NOT NULL DEFAULT 'Usuario',
  CONSTRAINT fk_Usuario_Empleado FOREIGN KEY(idEmpleado) REFERENCES Empleado(id)
);

CREATE TABLE Cliente (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  ci BIGINT NULL,
  razonSocial VARCHAR(100) NOT NULL,
  telefono VARCHAR(30) NULL
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
  tipoPago VARCHAR(20) NOT NULL DEFAULT 'EFECTIVO',
  CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY(idVenta) REFERENCES Venta(id),
  CONSTRAINT fk_VentaDetalle_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
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
INSERT INTO Producto (nombre, unidaMedida, sabor, precio, stock) VALUES ('naranja', 'Vaso Pequeño', 'manzana', 1.50, 5),
										   ('naranja', 'Vaso Mediano', 'manzana', 2.50, 5),
										   ('naranja', 'Vaso Grande', 'manzana', 3.50, 5);

INSERT INTO Empleado (nombres, primerApellido, segundoApellido, telefono, fechaContratacion, direccion) VALUES
('Elizabeth', 'Diaz', 'Canchi', 67345679, '2025-01-01', 'Calle 25 de Mayo');

INSERT INTO Usuario (idEmpleado, usuario, clave, role) VALUES
(1, 'eli', 'i0hcoO/nssY6WOs9pOp5Xw==', 'ADMINISTRADOR');

INSERT INTO Cliente (nombre, ci, razonSocial, telefono) VALUES
('Cliente Uno', 1234567, 'Razon Social Uno', '987654321');

INSERT INTO Venta (idUsuario, idCliente) VALUES
(1, 1); 

INSERT INTO VentaDetalle (idVenta, idProducto, cantidad, precioUnitario, total, tipoPago) VALUES
(1, 1, 2, 1.50, 3.00, 'Efectivo');


-- Leer
SELECT * FROM Producto;
SELECT * FROM Empleado;
SELECT * FROM Usuario;
SELECT * FROM Cliente;
SELECT * FROM Venta;
SELECT * FROM VentaDetalle;
 
-- Procedimiento Almacénado: Listar Productos
GO
CREATE OR ALTER PROC paProductoListar
    @parametro VARCHAR(50) = '' -- Parámetro de búsqueda, opcional
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        id,
        nombre,
        unidaMedida,
        sabor,
        precio,
        stock,
        usuarioRegistro,
        fechaRegistro,
        estado
    FROM
        Producto
    WHERE estado = 1 AND ( nombre LIKE '%' + @parametro + '%' OR (@parametro IS NULL OR @parametro = '')) ORDER BY nombre ASC;
END
GO


DROP PROC paVentaListarRango;
GO
--- Procedimiento Almacenado: Listar Ventas
CREATE PROCEDURE paVentaListarRango
(
    @fechaInicio DATE,
    @fechaFin DATE
)
AS
BEGIN
    SET NOCOUNT ON;

    -- LISTA DE VENTAS EN EL RANGO, DETALLANDO EL MONTO POR TIPO DE PAGO
    SELECT
        v.id AS idVenta,
        v.fechaRegistro,
        c.nombre AS Cliente,
        d.tipoPago, -- Columna incluida en el SELECT
        SUM(d.total) AS MontoVenta
    FROM Venta v
    INNER JOIN Cliente c ON c.id = v.idCliente
    INNER JOIN VentaDetalle d ON d.idVenta = v.id
    WHERE v.estado = 1
      AND d.estado = 1
      AND CAST(v.fechaRegistro AS DATE) BETWEEN @fechaInicio AND @fechaFin
    GROUP BY
        v.id, v.fechaRegistro, c.nombre, d.tipoPago -- <--- ¡AQUÍ ESTÁ LA CORRECCIÓN!
    ORDER BY v.fechaRegistro DESC, d.tipoPago;

    ---

    -- MONTO TOTAL GANADO EN EL RANGO (Total de todos los pagos)
    SELECT
        SUM(d.total) AS MontoTotalGanado
    FROM Venta v
    INNER JOIN VentaDetalle d ON d.idVenta = v.id
    WHERE v.estado = 1
      AND d.estado = 1
      AND CAST(v.fechaRegistro AS DATE) BETWEEN @fechaInicio AND @fechaFin;
END
GO

-- Ejemplo de ejecución del procedimiento almacenado paVentaListarRango
EXEC paVentaListarRango '2024-01-01', '2024-12-31';
GO

CREATE OR ALTER PROC paClienteListar
    @parametro VARCHAR(50) = '' 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        id,
        nombre,
        ci,
        razonSocial,
        telefono,
        usuarioRegistro,
        fechaRegistro,
        estado
    FROM
        Cliente
    WHERE
        estado = 1
        AND
        (
            (@parametro IS NULL OR @parametro = '')
            OR
            (
                nombre LIKE '%' + @parametro + '%'
                OR razonSocial LIKE '%' + @parametro + '%'
                OR CONVERT(VARCHAR(20), ci) LIKE '%' + @parametro + '%'
            )
        )
    ORDER BY
        nombre ASC;
END
GO

CREATE OR ALTER PROC paUsuarioEmpleadoListar
    @parametro VARCHAR(100) = '' 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.id AS idUsuario,
        U.usuario,
        U.role,
        E.id AS idEmpleado,
        E.nombres,
        E.primerApellido,
        E.segundoApellido,
        E.telefono,
        E.direccion,
        E.fechaContratacion,
        E.usuarioRegistro,
        E.fechaRegistro,
        E.estado
    FROM
        Usuario U
    INNER JOIN
        Empleado E ON U.idEmpleado = E.id
    WHERE
        E.estado = 1
        AND
        (
            (@parametro IS NULL OR @parametro = '')
            OR
            (
                E.nombres LIKE '%' + @parametro + '%'
                OR E.primerApellido LIKE '%' + @parametro + '%'
                OR E.segundoApellido LIKE '%' + @parametro + '%'
                OR U.usuario LIKE '%' + @parametro + '%'
            )
        )
    ORDER BY
        E.primerApellido, E.nombres ASC;
END
GO





