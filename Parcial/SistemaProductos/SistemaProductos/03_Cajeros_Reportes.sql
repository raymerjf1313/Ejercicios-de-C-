-- Cajeros, clientes, ITBIS, crédito/contado y cuentas por cobrar.
-- Ejecutar DESPUÉS de 01_CrearBaseDatos_ALMACEN.sql y 02_Facturacion.sql (se puede ejecutar más de una vez).
USE ALMACEN;
GO

-- 1) Usuarios: turno y rol Cajero
IF COL_LENGTH('dbo.usuario', 'turno') IS NULL
    ALTER TABLE dbo.usuario ADD turno VARCHAR(10) NULL;
GO
-- El antiguo "Invitado" pasa a ser Cajero del turno de la mañana
UPDATE dbo.usuario SET estado = 'Cajero', turno = 'Mañana' WHERE estado = 'Invitado';
GO

-- 2) Clientes
IF OBJECT_ID('dbo.Clientes') IS NULL
CREATE TABLE dbo.Clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre     VARCHAR(100) NOT NULL,
    documento  VARCHAR(20)  NULL,
    telefono   VARCHAR(20)  NULL
);
GO

-- 3) Facturas: tipo, turno, cliente, totales y pago
IF COL_LENGTH('dbo.Facturas', 'tipo') IS NULL
    ALTER TABLE dbo.Facturas ADD tipo VARCHAR(10) NOT NULL CONSTRAINT DF_Facturas_tipo DEFAULT 'Contado';
GO
IF COL_LENGTH('dbo.Facturas', 'turno') IS NULL
    ALTER TABLE dbo.Facturas ADD turno VARCHAR(10) NULL;
GO
IF COL_LENGTH('dbo.Facturas', 'id_cliente') IS NULL
    ALTER TABLE dbo.Facturas ADD id_cliente INT NULL CONSTRAINT FK_Facturas_Clientes FOREIGN KEY REFERENCES dbo.Clientes(id_cliente);
GO
IF COL_LENGTH('dbo.Facturas', 'total_bruto') IS NULL
    ALTER TABLE dbo.Facturas ADD total_bruto DECIMAL(12,2) NOT NULL CONSTRAINT DF_Facturas_bruto DEFAULT 0;
GO
IF COL_LENGTH('dbo.Facturas', 'total_itbis') IS NULL
    ALTER TABLE dbo.Facturas ADD total_itbis DECIMAL(12,2) NOT NULL CONSTRAINT DF_Facturas_itbis DEFAULT 0;
GO
IF COL_LENGTH('dbo.Facturas', 'monto_pagado') IS NULL
    ALTER TABLE dbo.Facturas ADD monto_pagado DECIMAL(12,2) NOT NULL CONSTRAINT DF_Facturas_pagado DEFAULT 0;
GO
IF COL_LENGTH('dbo.Facturas', 'devuelta') IS NULL
    ALTER TABLE dbo.Facturas ADD devuelta DECIMAL(12,2) NOT NULL CONSTRAINT DF_Facturas_devuelta DEFAULT 0;
GO
-- Facturas de prueba anteriores (sin ITBIS): se tratan como contado pagado exacto
UPDATE dbo.Facturas SET total_bruto = total, monto_pagado = total WHERE total_bruto = 0;
GO

-- 4) Detalle: ITBIS por línea
IF COL_LENGTH('dbo.DetalleFactura', 'itbis') IS NULL
    ALTER TABLE dbo.DetalleFactura ADD itbis DECIMAL(12,2) NOT NULL CONSTRAINT DF_Detalle_itbis DEFAULT 0;
GO

-- 5) Cuentas por cobrar (ventas a crédito)
IF OBJECT_ID('dbo.CuentasPorCobrar') IS NULL
CREATE TABLE dbo.CuentasPorCobrar (
    id_cxc     INT IDENTITY(1,1) PRIMARY KEY,
    id_factura INT NOT NULL FOREIGN KEY REFERENCES dbo.Facturas(id_factura),
    id_cliente INT NOT NULL FOREIGN KEY REFERENCES dbo.Clientes(id_cliente),
    fecha      DATETIME      NOT NULL,
    monto      DECIMAL(12,2) NOT NULL,
    saldo      DECIMAL(12,2) NOT NULL,
    estado     VARCHAR(10)   NOT NULL DEFAULT 'Pendiente'
);
GO

SELECT usuario, estado, turno FROM dbo.usuario;
GO
