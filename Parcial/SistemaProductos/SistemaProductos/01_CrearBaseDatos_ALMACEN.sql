-- Base de datos ALMACEN (SQL Server / SQL Server Express)
IF DB_ID('ALMACEN') IS NULL
    CREATE DATABASE ALMACEN;
GO
USE ALMACEN;
GO

IF OBJECT_ID('dbo.CuentasPorCobrar') IS NOT NULL DROP TABLE dbo.CuentasPorCobrar;
IF OBJECT_ID('dbo.DetalleFactura') IS NOT NULL DROP TABLE dbo.DetalleFactura;
IF OBJECT_ID('dbo.Facturas')       IS NOT NULL DROP TABLE dbo.Facturas;
IF OBJECT_ID('dbo.Productos') IS NOT NULL DROP TABLE dbo.Productos;
IF OBJECT_ID('dbo.usuario')   IS NOT NULL DROP TABLE dbo.usuario;
GO

CREATE TABLE dbo.Productos (
    CODIGO INT IDENTITY(1,1) PRIMARY KEY,
    NOMBRE VARCHAR(100) NOT NULL,
    PRECIO DECIMAL(10,2) NOT NULL,
    STOCK  INT NOT NULL,
    MARCA  VARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    ci_usuario VARCHAR(20)  NOT NULL,
    nombres    VARCHAR(50)  NOT NULL,
    apellidos  VARCHAR(50)  NOT NULL,
    telefono   VARCHAR(20)  NULL,
    email      VARCHAR(100) NULL,
    usuario    VARCHAR(50)  NOT NULL UNIQUE,
    [contraseña] VARCHAR(50) NOT NULL,
    estado        VARCHAR(20) NOT NULL,
    fecha_ingreso DATE        NOT NULL
);
GO

-- Datos de productos (con los mismos códigos de la captura)
SET IDENTITY_INSERT dbo.Productos ON;
INSERT INTO dbo.Productos (CODIGO, NOMBRE, PRECIO, STOCK, MARCA) VALUES
(4,  'MONITOR',   500,  4,   'SAMSUNG'),
(5,  'PARLANTES', 20,   50,  'APPLE'),
(6,  'AUDIFONOS', 30,   5,   'TENCENT'),
(7,  'MOUSE',     20,   6,   'TOSHIBA'),
(8,  'TECLADO',   60,   10,  'MSI'),
(14, 'LAPTOP',    1000, 200, 'DELL');
SET IDENTITY_INSERT dbo.Productos OFF;
GO

-- Usuarios (el email estaba cortado en la captura; ajústalo si hace falta)
INSERT INTO dbo.usuario (ci_usuario, nombres, apellidos, telefono, email, usuario, [contraseña], estado, fecha_ingreso) VALUES
('15009470', 'Mario',  'Cerda', '0992924110', 'mariolopez12@gmail.com', '@silvio',  '12345', 'Administrador', '2021-10-13'),
('15009521', 'Silvio', 'Cala',  '0992924111', 'mario@gmail.com',        '@usuario', '1234',  'Invitado',      '2021-10-13');
GO

SELECT * FROM dbo.Productos;
SELECT * FROM dbo.usuario;
