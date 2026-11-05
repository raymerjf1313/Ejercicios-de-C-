-- Tablas de facturación (ejecutar DESPUÉS de 01_CrearBaseDatos_ALMACEN.sql)
USE ALMACEN;
GO

IF OBJECT_ID('dbo.CuentasPorCobrar') IS NOT NULL DROP TABLE dbo.CuentasPorCobrar;
IF OBJECT_ID('dbo.DetalleFactura') IS NOT NULL DROP TABLE dbo.DetalleFactura;
IF OBJECT_ID('dbo.Facturas')       IS NOT NULL DROP TABLE dbo.Facturas;
GO

CREATE TABLE dbo.Facturas (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    fecha      DATETIME     NOT NULL,
    cliente    VARCHAR(100) NOT NULL,
    usuario    VARCHAR(50)  NOT NULL,
    total      DECIMAL(12,2) NOT NULL
);
GO

CREATE TABLE dbo.DetalleFactura (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_factura INT NOT NULL FOREIGN KEY REFERENCES dbo.Facturas(id_factura),
    codigo     INT NOT NULL FOREIGN KEY REFERENCES dbo.Productos(CODIGO),
    nombre     VARCHAR(100)  NOT NULL,
    precio     DECIMAL(10,2) NOT NULL,
    cantidad   INT           NOT NULL,
    subtotal   DECIMAL(12,2) NOT NULL
);
GO
