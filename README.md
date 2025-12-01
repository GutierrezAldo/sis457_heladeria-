# 🍨 Esquema de Base de Datos - Sistema POS Heladería

Este documento describe la estructura de la base de datos (DDL) utilizada para el Sistema de Punto de Venta (POS) de la heladería. El esquema está diseñado para gestionar el inventario, el personal y las transacciones de venta.

---

## 🔑 Convenciones de Auditoría

Todas las tablas incluyen las siguientes columnas para trazabilidad (auditoría/soft-delete):

| Columna | Tipo | Descripción | Valores Estándar de `estado` |
| :--- | :--- | :--- | :--- |
| `usuarioRegistro` | `VARCHAR(50)` | Usuario que insertó o modificó el registro. | **1:** Activo / **0:** Inactivo / **-1:** Eliminado |
| `fechaRegistro` | `DATETIME` | Fecha y hora de la creación del registro. | *(Ver excepción en VentaDetalle)* |
| `estado` | `SMALLINT` | Estado lógico del registro. | |

---

## 📦 Tablas de Inventario y Productos

### 1. Sabor

Catálogo de los sabores de helado.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **nombre** | `VARCHAR(100)` | `UNIQUE`, `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 2. Proveedor

Información de los proveedores de materias primas.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **razonSocial** | `VARCHAR(100)` | `NOT NULL`, `UNIQUE` |
| **nit** | `VARCHAR(20)` | `NOT NULL`, `UNIQUE` |
| **telefono** | `VARCHAR(15)` | `NOT NULL` |
| direccion | `VARCHAR(250)` | |
| tipoProducto | `VARCHAR(100)` | `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 3. Presentacion

Catálogo de tipos de envases o formatos (ej. Cono, Vaso, Torta).

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **descripcion** | `VARCHAR(100)` | `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 4. Producto

Define el producto final que se ofrece para la venta.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **nombre** | `VARCHAR(100)` | `NOT NULL` |
| **idSabor** | `INT` | `FK` a `Sabor(id)` |
| **idProveedor** | `INT` | `FK` a `Proveedor(id)` |
| **idPresentacion** | `INT` | `FK` a `Presentacion(id)` |
| **precio** | `DECIMAL(10,2)` | `NOT NULL`, `CHECK (precio > 0)` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

---

## 👥 Tablas de Personal y Acceso

### 5. Cargo

Define los roles dentro de la heladería.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **descripcion** | `VARCHAR(50)` | `NOT NULL`, `UNIQUE` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 6. Empleado

Información personal del equipo de trabajo.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **nombres** | `VARCHAR(100)` | `NOT NULL` |
| **primerApellido** | `VARCHAR(80)` | `NOT NULL` |
| **segundoApellido** | `VARCHAR(80)` | `NOT NULL` |
| **telefono** | `VARCHAR(15)` | `NOT NULL` |
| **direccion** | `VARCHAR(250)` | `NOT NULL` |
| **idCargo** | `INT` | `FK` a `Cargo(id)` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 7. Usuario

Credenciales utilizadas para ingresar al sistema POS.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **idEmpleado** | `INT` | `NOT NULL`, `FK` a `Empleado(id)` |
| **usuario** | `VARCHAR(20)` | `NOT NULL`, `UNIQUE` |
| **clave** | `VARCHAR(250)` | `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

---

## 💳 Tablas de Transacciones y Clientes

### 8. Cliente

Información de los clientes que realizan compras.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **nombre** | `VARCHAR(100)` | `NOT NULL` |
| **nit** | `VARCHAR(20)` | `NOT NULL`, `UNIQUE` |
| **celular** | `VARCHAR(15)` | `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 9. TipoPago

Tipos de modalidades de pago aceptadas.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **descripcion** | `VARCHAR(50)` | `NOT NULL`, `UNIQUE` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 10. Venta

Cabecera de la transacción de venta.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **idUsuario** | `INT` | `FK` a `Usuario(id)` |
| **idCliente** | `INT` | `FK` a `Cliente(id)` |
| **idTipoPago** | `INT` | `FK` a `TipoPago(id)` |
| **montoTotal** | `DECIMAL(10,2)` | `NOT NULL` |
| **montoPago** | `DECIMAL(10,2)` | `NOT NULL` |
| **montoCambio** | `DECIMAL(10,2)` | `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | |

### 11. VentaDetalle

Detalle de los productos vendidos en una transacción.

| Columna | Tipo | Restricciones |
| :--- | :--- | :--- |
| **id** | `INT` | `PK`, `IDENTITY(1,1)` |
| **idVenta** | `INT` | `FK` a `Venta(id)` |
| **idProducto** | `INT` | `FK` a `Producto(id)` |
| **cantidad** | `INT` | `NOT NULL`, `CHECK (cantidad > 0)` |
| **precioUnitario** | `DECIMAL(10,2)` | `NOT NULL` |
| **total** | `DECIMAL(10,2)` | `NOT NULL` |
| usuarioRegistro | `VARCHAR(50)` | |
| fechaRegistro | `DATETIME` | |
| estado | `SMALLINT` | **-1:** No Entregado / **0:** Entregado / **1:** Pendiente |