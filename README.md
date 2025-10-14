
Heladeria Helarte
La heladería HELARTE es un emprendimiento de venta de helados artesanales, sera un POS orientada a la gestión operativa de una heladería moderna. El sistema está diseñado para facilitar el control de ventas y administración de productos.

Entidades del Sistema

producto
id_producto (PK)
nombre
precio

empleado
id_empleado (PK)
nombre
apellido
cargo
fecha_contrataciòn
teléfono
direcciòn
usuario
id_usuario(PK)
id_empleado(FK)
usuario
clave

Presentaciones
id_presentacion (PK)
nombre_presentacion
precio

sabor
id_sabor (PK)
id_producto (FK)
nombre

👤 cliente
id_cliente (PK)
ci
razon_social
teléfono

venta
id_venta (PK)
id_usuario (FK)
id_cliente(FK)
fecha

venta_detalle
id_detalle (PK)
id_venta (FK)
id_producto (FK)
cantidad
precio_unitario
total

pedido
id_pedido (PK)
id_cliente (FK)
id_empleado (FK)
fecha_pedido
tipo_pago

