-- Crear la base de datos
CREATE DATABASE SoluSoftDB;
GO

-- Usar la base de datos
USE SoluSoftDB;
GO

-- Creacion de Tablas

CREATE TABLE Categoria_Producto (
    ID_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion TEXT
);
GO

CREATE TABLE Proveedor (
    ID_Proveedor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    Direccion TEXT
);
GO

CREATE TABLE Producto (
    ID_Producto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT DEFAULT 0,
    ID_Categoria INT,
    ID_Proveedor INT,
    FOREIGN KEY (ID_Categoria) REFERENCES Categoria_Producto(ID_Categoria),
    FOREIGN KEY (ID_Proveedor) REFERENCES Proveedor(ID_Proveedor)
);
GO

CREATE TABLE Inventario (
    ID_Inventario INT IDENTITY(1,1) PRIMARY KEY,
    ID_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Fecha_Ingreso DATETIME NOT NULL,
    Fecha_Caducidad DATE NOT NULL,
    FOREIGN KEY (ID_Producto) REFERENCES Producto(ID_Producto)
);
GO

CREATE TABLE Cliente (
    ID_Cliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    Direccion TEXT
);
GO

CREATE TABLE Empleado (
    ID_Empleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Direccion TEXT,
    Cargo VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Usuario (
    ID_Empleado INT PRIMARY KEY,
    Nombre_Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contraseña VARCHAR(100) NOT NULL,
    Rol VARCHAR(30),
    Estado BIT,
    FOREIGN KEY (ID_Empleado) REFERENCES Empleado(ID_Empleado)
);
GO

CREATE TABLE Metodo_Pago (
    ID_Metodo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Venta (
    ID_Venta INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    ID_Cliente INT,
    ID_Empleado INT,
    ID_Metodo INT,
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID_Cliente),
    FOREIGN KEY (ID_Empleado) REFERENCES Empleado(ID_Empleado),
    FOREIGN KEY (ID_Metodo) REFERENCES Metodo_Pago(ID_Metodo)
);
GO

CREATE TABLE Detalle_Venta (
    ID_Detalle INT IDENTITY(1,1) PRIMARY KEY,
    ID_Venta INT,
    ID_Producto INT,
    Cantidad INT NOT NULL,
    Precio_Unitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Venta) REFERENCES Venta(ID_Venta),
    FOREIGN KEY (ID_Producto) REFERENCES Producto(ID_Producto)
);
GO

-- Inserción de datos

INSERT INTO Categoria_Producto (Nombre, Descripcion)
VALUES ('Lácteos', 'Productos derivados de la leche'),
       ('Granos', 'Frijoles, lentejas, arroz');
GO

INSERT INTO Proveedor (Nombre, Telefono, Correo, Direccion)
VALUES ('Alimentos del Norte', '3214567890', 'proveedor1@email.com', 'Calle 10 #23-45'),
       ('Distribuciones del Sur', '3209876543', 'proveedor2@email.com', 'Cra 12 #56-78');
GO

INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, ID_Categoria, ID_Proveedor)
VALUES ('Leche Entera 1L', 'Leche entera en bolsa', 3500, 100, 1, 1),
       ('Fríjol rojo 500g', 'Frijol seleccionado', 4200, 50, 2, 2);
GO

INSERT INTO Inventario (ID_Producto, Cantidad, Fecha_Ingreso, Fecha_Caducidad)
VALUES (1, 100, '2025-06-01', '2025-07-01'),
       (2, 50, '2025-06-01', NULL);
GO

INSERT INTO Cliente (Nombre, Apellidos, Telefono, Correo, Direccion)
VALUES ('Carlos', 'Ramírez', '3114567890', 'carlos@email.com', 'Av. Principal #5-21');
GO

INSERT INTO Empleado (Nombre, Apellidos, Telefono, Direccion, Cargo)
VALUES ('Laura', 'Martínez', '3129876543', 'Cl. 33 #45-67', 'Cajera');
GO

INSERT INTO Usuario (ID_Empleado, Nombre_Usuario, Contraseña, Rol, Estado)
VALUES (1, 'laura.m', 'contrasena123', 'empleado', 1);
GO

INSERT INTO Metodo_Pago (Descripcion)
VALUES ('Efectivo'), ('Tarjeta Débito'), ('Tarjeta Crédito');
GO

INSERT INTO Venta (Fecha, Total, ID_Cliente, ID_Empleado, ID_Metodo)
VALUES ('2025-06-23', 7700, 1, 1, 1);
GO

INSERT INTO Detalle_Venta (ID_Venta, ID_Producto, Cantidad, Precio_Unitario, Subtotal)
VALUES (1, 1, 1, 3500, 3500),
       (1, 2, 1, 4200, 4200);
GO

-- procedimientos almacenados
-- Registro, actualización, eliminación, consulta y listado 

CREATE PROCEDURE usp_RegistrarCliente
    @Nombre     VARCHAR(100),
    @Apellidos  VARCHAR(100),
    @Telefono   VARCHAR(20),
    @Correo     VARCHAR(100),
    @Direccion  TEXT
AS
BEGIN
    INSERT INTO Cliente (Nombre, Apellidos, Telefono, Correo, Direccion)
    VALUES (@Nombre, @Apellidos, @Telefono, @Correo, @Direccion);
END;
GO

CREATE PROCEDURE usp_ActualizarCliente
    @ID_Cliente INT,
    @Nombre     VARCHAR(100),
    @Apellidos  VARCHAR(100),
    @Telefono   VARCHAR(20),
    @Correo     VARCHAR(100),
    @Direccion  TEXT
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        Apellidos = @Apellidos,
        Telefono = @Telefono,
        Correo = @Correo,
        Direccion = @Direccion
    WHERE ID_Cliente = @ID_Cliente;
END;
GO

CREATE PROCEDURE usp_EliminarCliente
    @ID_Cliente INT
AS
BEGIN
    DELETE FROM Cliente WHERE ID_Cliente = @ID_Cliente;
END;
GO

CREATE PROCEDURE usp_ConsultarCliente
    @ID_Cliente INT
AS
BEGIN
    SELECT * FROM Cliente WHERE ID_Cliente = @ID_Cliente;
END;
GO


CREATE PROCEDURE usp_ListarClientes
AS
BEGIN
    SELECT * FROM Cliente;
END;
GO


 CREATE PROCEDURE usp_RegistrarProducto
    @Nombre       VARCHAR(100),
    @Descripcion  TEXT,
    @Precio       DECIMAL(10,2),
    @Stock        INT,
    @ID_Categoria INT,
    @ID_Proveedor INT
AS
BEGIN
    INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, ID_Categoria, ID_Proveedor)
    VALUES (@Nombre, @Descripcion, @Precio, @Stock, @ID_Categoria, @ID_Proveedor);
END;
GO


CREATE PROCEDURE usp_ActualizarProducto
    @ID_Producto  INT,
    @Nombre       VARCHAR(100),
    @Descripcion  TEXT,
    @Precio       DECIMAL(10,2),
    @Stock        INT,
    @ID_Categoria INT,
    @ID_Proveedor INT
AS
BEGIN
    UPDATE Producto
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
        Stock = @Stock,
        ID_Categoria = @ID_Categoria,
        ID_Proveedor = @ID_Proveedor
    WHERE ID_Producto = @ID_Producto;
END;
GO

CREATE PROCEDURE usp_EliminarProducto
    @ID_Producto INT
AS
BEGIN
    DELETE FROM Producto WHERE ID_Producto = @ID_Producto;
END;
GO

CREATE PROCEDURE usp_ConsultarProducto
    @ID_Producto INT
AS
BEGIN
    SELECT * FROM Producto WHERE ID_Producto = @ID_Producto;
END;
GO

CREATE PROCEDURE usp_ListarProductos
AS
BEGIN
    SELECT * FROM Producto;
END;
GO

CREATE PROCEDURE usp_RegistrarEmpleado
    @Nombre     VARCHAR(100),
    @Apellidos  VARCHAR(100),
    @Telefono   VARCHAR(20),
    @Direccion  TEXT,
    @Cargo      VARCHAR(50)
AS
BEGIN
    INSERT INTO Empleado (Nombre, Apellidos, Telefono, Direccion, Cargo)
    VALUES (@Nombre, @Apellidos, @Telefono, @Direccion, @Cargo);
END;
GO

CREATE PROCEDURE usp_ListarEmpleados
AS
BEGIN
    SELECT * FROM Empleado;
END;
GO
CREATE PROCEDURE usp_ActualizarEmpleado
    @ID_Empleado INT,
    @Nombre      VARCHAR(100),
    @Apellidos   VARCHAR(100),
    @Telefono    VARCHAR(20),
    @Direccion   TEXT,
    @Cargo       VARCHAR(50)
AS
BEGIN
    UPDATE Empleado
    SET Nombre = @Nombre,
        Apellidos = @Apellidos,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Cargo = @Cargo
    WHERE ID_Empleado = @ID_Empleado;
END;
GO

CREATE PROCEDURE usp_EliminarEmpleado
    @ID_Empleado INT
AS
BEGIN
    DELETE FROM Empleado
    WHERE ID_Empleado = @ID_Empleado;
END;
GO

CREATE PROCEDURE usp_ConsultarEmpleado
    @ID_Empleado INT
AS
BEGIN
    SELECT * FROM Empleado
    WHERE ID_Empleado = @ID_Empleado;
END;
GO

CREATE PROCEDURE usp_RegistrarInventario
    @ID_Producto     INT,
    @Cantidad        INT,
    @Fecha_Ingreso   DATE,
    @Fecha_Caducidad DATE
AS
BEGIN
    INSERT INTO Inventario (ID_Producto, Cantidad, Fecha_Ingreso, Fecha_Caducidad)
    VALUES (@ID_Producto, @Cantidad, @Fecha_Ingreso, @Fecha_Caducidad);
END;
GO


CREATE PROCEDURE usp_ListarInventario
AS
BEGIN
    SELECT I.*, P.Nombre AS NombreProducto
    FROM Inventario I
    INNER JOIN Producto P ON I.ID_Producto = P.ID_Producto;
END;
GO

CREATE PROCEDURE usp_ActualizarInventario
    @ID_Inventario   INT,
    @ID_Producto     INT,
    @Cantidad        INT,
    @Fecha_Ingreso   DATE,
    @Fecha_Caducidad DATE
AS
BEGIN
    UPDATE Inventario
    SET ID_Producto     = @ID_Producto,
        Cantidad        = @Cantidad,
        Fecha_Ingreso   = @Fecha_Ingreso,
        Fecha_Caducidad = @Fecha_Caducidad
    WHERE ID_Inventario = @ID_Inventario;
END;
GO

CREATE PROCEDURE usp_EliminarInventario
    @ID_Inventario INT
AS
BEGIN
    DELETE FROM Inventario
    WHERE ID_Inventario = @ID_Inventario;
END;
GO


CREATE PROCEDURE usp_ConsultarInventario
    @ID_Inventario INT
AS
BEGIN
    SELECT I.*, P.Nombre AS NombreProducto
    FROM Inventario I
    INNER JOIN Producto P ON I.ID_Producto = P.ID_Producto
    WHERE I.ID_Inventario = @ID_Inventario;
END;
GO

CREATE PROCEDURE usp_RegistrarProveedor
    @Nombre    VARCHAR(100),
    @Telefono  VARCHAR(20),
    @Correo    VARCHAR(100),
    @Direccion TEXT
AS
BEGIN
    INSERT INTO Proveedor (Nombre, Telefono, Correo, Direccion)
    VALUES (@Nombre, @Telefono, @Correo, @Direccion);
END;
GO

CREATE PROCEDURE usp_ActualizarProveedor
    @ID_Proveedor INT,
    @Nombre       VARCHAR(100),
    @Telefono     VARCHAR(20),
    @Correo       VARCHAR(100),
    @Direccion    TEXT
AS
BEGIN
    UPDATE Proveedor
    SET Nombre = @Nombre,
        Telefono = @Telefono,
        Correo = @Correo,
        Direccion = @Direccion
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO


CREATE PROCEDURE usp_EliminarProveedor
    @ID_Proveedor INT
AS
BEGIN
    DELETE FROM Proveedor
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO

CREATE PROCEDURE usp_ConsultarProveedor
    @ID_Proveedor INT
AS
BEGIN
    SELECT * FROM Proveedor
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO

CREATE PROCEDURE usp_ListarProveedores
AS
BEGIN
    SELECT * FROM Proveedor;
END;
GO

CREATE PROCEDURE usp_RegistrarCategoria
    @Nombre      VARCHAR(50),
    @Descripcion TEXT
AS
BEGIN
    INSERT INTO Categoria_Producto (Nombre, Descripcion)
    VALUES (@Nombre, @Descripcion);
END;
GO

CREATE PROCEDURE usp_ActualizarCategoria
    @ID_Categoria INT,
    @Nombre       VARCHAR(50),
    @Descripcion  TEXT
AS
BEGIN
    UPDATE Categoria_Producto
    SET Nombre = @Nombre,
        Descripcion = @Descripcion
    WHERE ID_Categoria = @ID_Categoria;
END;
GO

CREATE PROCEDURE usp_EliminarCategoria
    @ID_Categoria INT
AS
BEGIN
    DELETE FROM Categoria_Producto
    WHERE ID_Categoria = @ID_Categoria;
END;
GO


CREATE PROCEDURE usp_ConsultarCategoria
    @ID_Categoria INT
AS
BEGIN
    SELECT * FROM Categoria_Producto
    WHERE ID_Categoria = @ID_Categoria;
END;
GO

CREATE PROCEDURE usp_ListarCategorias
AS
BEGIN
    SELECT * FROM Categoria_Producto;
END;
GO

CREATE PROCEDURE usp_RegistrarMetodoPago
    @Descripcion VARCHAR(50)
AS
BEGIN
    INSERT INTO Metodo_Pago (Descripcion)
    VALUES (@Descripcion);
END;
GO

CREATE PROCEDURE usp_ActualizarMetodoPago
    @ID_Metodo   INT,
    @Descripcion VARCHAR(50)
AS
BEGIN
    UPDATE Metodo_Pago
    SET Descripcion = @Descripcion
    WHERE ID_Metodo = @ID_Metodo;
END;
GO


CREATE PROCEDURE usp_EliminarMetodoPago
    @ID_Metodo INT
AS
BEGIN
    DELETE FROM Metodo_Pago
    WHERE ID_Metodo = @ID_Metodo;
END;
GO

CREATE PROCEDURE usp_ConsultarMetodoPago
    @ID_Metodo INT
AS
BEGIN
    SELECT * FROM Metodo_Pago
    WHERE ID_Metodo = @ID_Metodo;
END;
GO

CREATE PROCEDURE usp_ListarMetodosPago
AS
BEGIN
    SELECT * FROM Metodo_Pago;
END;
GO

CREATE PROCEDURE usp_RegistrarUsuario
    @ID_Empleado     INT,
    @Nombre_Usuario  VARCHAR(50),
    @Contraseña      VARCHAR(100),
    @Rol             VARCHAR(30),
    @Estado          BIT
AS
BEGIN
    INSERT INTO Usuario (ID_Empleado, Nombre_Usuario, Contraseña, Rol, Estado)
    VALUES (@ID_Empleado, @Nombre_Usuario, @Contraseña, @Rol, @Estado);
END;
GO

CREATE PROCEDURE usp_ActualizarUsuario
    @ID_Empleado     INT,
    @Nombre_Usuario  VARCHAR(50),
    @Contraseña      VARCHAR(100),
    @Rol             VARCHAR(30),
    @Estado          BIT
AS
BEGIN
    UPDATE Usuario
    SET Nombre_Usuario = @Nombre_Usuario,
        Contraseña     = @Contraseña,
        Rol            = @Rol,
        Estado         = @Estado
    WHERE ID_Empleado = @ID_Empleado;
END;
GO

CREATE PROCEDURE usp_EliminarUsuario
    @ID_Empleado INT
AS
BEGIN
    DELETE FROM Usuario WHERE ID_Empleado = @ID_Empleado;
END;
GO

CREATE PROCEDURE usp_ConsultarUsuario
    @ID_Empleado INT
AS
BEGIN
    SELECT * FROM Usuario
    WHERE ID_Empleado = @ID_Empleado;
END;
GO

CREATE PROCEDURE usp_ListarUsuarios
AS
BEGIN
    SELECT U.*, E.Nombre, E.Apellidos
    FROM Usuario U
    INNER JOIN Empleado E ON U.ID_Empleado = E.ID_Empleado;
END;
GO


CREATE PROCEDURE usp_RegistrarVenta
    @Fecha      DATE,
    @Total      DECIMAL(10,2),
    @ID_Cliente INT,
    @ID_Empleado INT,
    @ID_Metodo  INT
AS
BEGIN
    INSERT INTO Venta (Fecha, Total, ID_Cliente, ID_Empleado, ID_Metodo)
    VALUES (@Fecha, @Total, @ID_Cliente, @ID_Empleado, @ID_Metodo);
    
    SELECT SCOPE_IDENTITY() AS ID_Venta;
END;
GO

CREATE PROCEDURE usp_ActualizarVenta
    @ID_Venta    INT,
    @Fecha       DATE,
    @Total       DECIMAL(10,2),
    @ID_Cliente  INT,
    @ID_Empleado INT,
    @ID_Metodo   INT
AS
BEGIN
    UPDATE Venta
    SET Fecha = @Fecha,
        Total = @Total,
        ID_Cliente = @ID_Cliente,
        ID_Empleado = @ID_Empleado,
        ID_Metodo = @ID_Metodo
    WHERE ID_Venta = @ID_Venta;
END;
GO

CREATE PROCEDURE usp_EliminarVenta
    @ID_Venta INT
AS
BEGIN
    DELETE FROM Venta WHERE ID_Venta = @ID_Venta;
END;
GO

CREATE PROCEDURE usp_ConsultarVenta
    @ID_Venta INT
AS
BEGIN
    SELECT V.*, 
           C.Nombre AS Cliente, 
           E.Nombre + ' ' + E.Apellidos AS Empleado, 
           M.Descripcion AS MetodoPago
    FROM Venta V
    LEFT JOIN Cliente C ON V.ID_Cliente = C.ID_Cliente
    LEFT JOIN Empleado E ON V.ID_Empleado = E.ID_Empleado
    LEFT JOIN Metodo_Pago M ON V.ID_Metodo = M.ID_Metodo
    WHERE V.ID_Venta = @ID_Venta;
END;
GO

CREATE PROCEDURE usp_ListarVentas
AS
BEGIN
    SELECT V.ID_Venta, V.Fecha, V.Total,
           C.Nombre AS Cliente,
           E.Nombre + ' ' + E.Apellidos AS Empleado,
           M.Descripcion AS MetodoPago
    FROM Venta V
    LEFT JOIN Cliente C ON V.ID_Cliente = C.ID_Cliente
    LEFT JOIN Empleado E ON V.ID_Empleado = E.ID_Empleado
    LEFT JOIN Metodo_Pago M ON V.ID_Metodo = M.ID_Metodo;
END;
GO

CREATE PROCEDURE usp_RegistrarDetalleVenta
    @ID_Venta        INT,
    @ID_Producto     INT,
    @Cantidad        INT,
    @Precio_Unitario DECIMAL(10,2),
    @Subtotal        DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Detalle_Venta (ID_Venta, ID_Producto, Cantidad, Precio_Unitario, Subtotal)
    VALUES (@ID_Venta, @ID_Producto, @Cantidad, @Precio_Unitario, @Subtotal);
END;
GO

CREATE PROCEDURE usp_ActualizarDetalleVenta
    @ID_Detalle      INT,
    @ID_Venta        INT,
    @ID_Producto     INT,
    @Cantidad        INT,
    @Precio_Unitario DECIMAL(10,2),
    @Subtotal        DECIMAL(10,2)
AS
BEGIN
    UPDATE Detalle_Venta
    SET ID_Venta        = @ID_Venta,
        ID_Producto     = @ID_Producto,
        Cantidad        = @Cantidad,
        Precio_Unitario = @Precio_Unitario,
        Subtotal        = @Subtotal
    WHERE ID_Detalle = @ID_Detalle;
END;
GO

CREATE PROCEDURE usp_EliminarDetalleVenta
    @ID_Detalle INT
AS
BEGIN
    DELETE FROM Detalle_Venta
    WHERE ID_Detalle = @ID_Detalle;
END;
GO

CREATE PROCEDURE usp_ConsultarDetalleVenta
    @ID_Detalle INT
AS
BEGIN
    SELECT D.*, P.Nombre AS Producto
    FROM Detalle_Venta D
    INNER JOIN Producto P ON D.ID_Producto = P.ID_Producto
    WHERE ID_Detalle = @ID_Detalle;
END;
GO


CREATE PROCEDURE usp_ListarDetallesPorVenta
    @ID_Venta INT
AS
BEGIN
    SELECT D.ID_Detalle, P.Nombre AS Producto, D.Cantidad, D.Precio_Unitario, D.Subtotal
    FROM Detalle_Venta D
    INNER JOIN Producto P ON D.ID_Producto = P.ID_Producto
    WHERE D.ID_Venta = @ID_Venta;
END;
GO



 EXEC usp_ListarClientes;
  EXEC usp_EliminarCliente  
       @ID_Cliente = 2;

