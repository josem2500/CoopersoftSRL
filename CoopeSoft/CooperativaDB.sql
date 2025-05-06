use CooperativaDB;
go

-- Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL, -- Recomendable almacenar hash, no texto plano
    Rol NVARCHAR(20) NOT NULL, -- 'admin' o 'socio'
    NombreCompleto NVARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

ALTER TABLE Usuarios
ADD IdSocio INT NULL,
    Email NVARCHAR(100) NULL,
    FOREIGN KEY (IdSocio) REFERENCES Socios(Id);

-- Tabla Socios
CREATE TABLE Socios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DNI NVARCHAR(20) UNIQUE NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(20) DEFAULT 'Activo' -- 'Activo', 'Inactivo', 'Suspendido'
);
GO

-- Tabla TiposPrestamo
CREATE TABLE TiposPrestamo (
    TipoPrestamoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    TasaInteres DECIMAL(5,2) NOT NULL,
    PlazoMaximoMeses INT NOT NULL,
    Descripcion NVARCHAR(255)
);
GO

-- Tabla TiposMovimiento
CREATE TABLE TiposMovimiento (
    TipoMovimientoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    AfectaSaldo BIT DEFAULT 1,
    Signo CHAR(1) CHECK (Signo IN ('+', '-'))
);
GO

-- Tabla Configuraciones
CREATE TABLE Configuraciones (
    ConfigID INT PRIMARY KEY IDENTITY(1,1),
    Clave NVARCHAR(100) UNIQUE NOT NULL,
    Valor NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(255),
    Tipo NVARCHAR(50) CHECK (Tipo IN ('Texto', 'Numero', 'Decimal', 'Fecha', 'Booleano'))
);
GO

-- Tabla Prestamos (depende de Socios y TiposPrestamo)
CREATE TABLE Prestamos (
    PrestamoID INT PRIMARY KEY IDENTITY(1,1),
    SocioID INT NOT NULL FOREIGN KEY REFERENCES Socios(Id),
    TipoPrestamoID INT NOT NULL FOREIGN KEY REFERENCES TiposPrestamo(TipoPrestamoID),
    Monto DECIMAL(18,2) NOT NULL,
    SaldoPendiente DECIMAL(18,2) NOT NULL,
    TasaInteres DECIMAL(5,2) NOT NULL,
    PlazoMeses INT NOT NULL,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    FechaAprobacion DATETIME NULL,
    FechaFinalizacion DATETIME NULL,
    Estado VARCHAR(20) DEFAULT 'Pendiente' CHECK (Estado IN ('Pendiente', 'Aprobado', 'Rechazado', 'Pagado', 'Mora')),
    Observaciones NVARCHAR(500) NULL
);
GO

-- Tabla CuotasPrestamos (depende de Prestamos)
CREATE TABLE CuotasPrestamos (
    CuotaID INT PRIMARY KEY IDENTITY(1,1),
    PrestamoID INT NOT NULL FOREIGN KEY REFERENCES Prestamos(PrestamoID),
    NumeroCuota INT NOT NULL,
    MontoCuota DECIMAL(18,2) NOT NULL,
    FechaVencimiento DATE NOT NULL,
    FechaPago DATE NULL,
    MontoPagado DECIMAL(18,2) DEFAULT 0.00,
    Estado VARCHAR(20) DEFAULT 'Pendiente' CHECK (Estado IN ('Pendiente', 'Pagada', 'Parcial', 'Vencida')),
    Interes DECIMAL(18,2) NOT NULL,
    Capital DECIMAL(18,2) NOT NULL
);
GO

-- Tabla Movimientos (depende de Socios, TiposMovimiento, Usuarios, y Prestamos)
CREATE TABLE Movimientos (
    MovimientoID INT PRIMARY KEY IDENTITY(1,1),
    SocioID INT NOT NULL FOREIGN KEY REFERENCES Socios(Id),
    TipoMovimientoID INT NOT NULL FOREIGN KEY REFERENCES TiposMovimiento(TipoMovimientoID),
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Descripcion NVARCHAR(255),
    Referencia NVARCHAR(100),
    UsuarioID INT NULL FOREIGN KEY REFERENCES Usuarios(Id),
    PrestamoID INT NULL FOREIGN KEY REFERENCES Prestamos(PrestamoID)
);
GO

-- Insertar datos iniciales
-- Usuarios
INSERT INTO Usuarios (Username, Password, Rol, NombreCompleto)
VALUES 
('admin', '1234', 'admin', 'Administrador Principal'),
('socio1', '5678', 'socio', 'Juan Pérez'),
('socio2', '9012', 'socio', 'María García');
GO

-- Socios
INSERT INTO Socios (DNI, Nombre, Apellido, Estado)
VALUES 
('00000000001', 'Admin', 'Sistema', 'Activo'),
('12345678901', 'Juan', 'Pérez', 'Activo'),
('98765432101', 'María', 'García', 'Activo');
GO

-- TiposPrestamo
INSERT INTO TiposPrestamo (Nombre, TasaInteres, PlazoMaximoMeses, Descripcion)
VALUES 
('Préstamo Personal', 12.00, 36, 'Préstamo para necesidades personales'),
('Préstamo Vivienda', 8.50, 120, 'Préstamo para mejoras de vivienda'),
('Préstamo Emergencia', 15.00, 12, 'Préstamo para emergencias');
GO

-- TiposMovimiento
INSERT INTO TiposMovimiento (Nombre, Descripcion, AfectaSaldo, Signo)
VALUES 
('Ahorro', 'Depósito de ahorro regular', 1, '+'),
('Retiro', 'Retiro de fondos', 1, '-'),
('Pago Préstamo', 'Pago de cuota de préstamo', 0, '-'),
('Interés', 'Interés generado por ahorros', 1, '+'),
('Multa', 'Multa por mora', 1, '-');
GO

-- Configuraciones
INSERT INTO Configuraciones (Clave, Valor, Descripcion, Tipo)
VALUES
('MONEDA', 'RD$', 'Símbolo de moneda', 'Texto'),
('TASA_AHORRO', '5.00', 'Tasa de interés para ahorros anual', 'Decimal'),
('DIAS_GRACIA', '5', 'Días de gracia para pagos', 'Numero');
GO


INSERT INTO Prestamos (SocioID, TipoPrestamoID, Monto, SaldoPendiente, TasaInteres, PlazoMeses, FechaSolicitud, FechaAprobacion, FechaFinalizacion, Estado, Observaciones)
VALUES 
(1, 1, 50000.00, 50000.00, 12.00, 24, '2025-05-01', '2025-05-02', NULL, 'Aprobado', 'Préstamo para equipo de oficina'),
(2, 2, 200000.00, 200000.00, 8.50, 60, '2025-05-03', NULL, NULL, 'Pendiente', 'Solicitud en revisión'),
(3, 3, 10000.00, 10000.00, 15.00, 12, '2025-05-04', '2025-05-04', NULL, 'Aprobado', 'Préstamo para emergencia médica');
GO

INSERT INTO CuotasPrestamos (PrestamoID, NumeroCuota, MontoCuota, FechaVencimiento, FechaPago, MontoPagado, Estado, Interes, Capital)
VALUES 
(1, 1, 2300.00, '2025-06-01', NULL, 0.00, 'Pendiente', 500.00, 1800.00),
(1, 2, 2300.00, '2025-07-01', NULL, 0.00, 'Pendiente', 480.00, 1820.00),
(1, 3, 2300.00, '2025-08-01', '2025-05-04', 2300.00, 'Pagada', 460.00, 1840.00);
GO

INSERT INTO Movimientos (SocioID, TipoMovimientoID, Monto, Fecha, Descripcion, Referencia, UsuarioID, PrestamoID)
VALUES 
(1, 1, 10000.00, '2025-05-01', 'Depósito inicial de ahorros', 'AH001', 1, NULL),
(2, 2, 5000.00, '2025-05-02', 'Retiro de fondos', 'RT001', 2, NULL),
(3, 3, 2300.00, '2025-05-04', 'Pago de cuota 3', 'CUOTA003', 3, 1),
(3, 4, 200.00, '2025-05-04', 'Interés por ahorros', 'INT001', 1, NULL),
(2, 5, 500.00, '2025-05-05', 'Multa por retraso', 'MULTA001', 1, NULL);
GO

SELECT * FROM Socios;
SELECT * FROM Usuarios;
SELECT * FROM TiposPrestamo;
SELECT * FROM TiposMovimiento;
SELECT * FROM Configuraciones;

SELECT * FROM Prestamos;
SELECT * FROM CuotasPrestamos;
SELECT * FROM Movimientos;

SELECT TipoMovimientoID, Nombre FROM TiposMovimiento;

INSERT INTO Usuarios (Username, Password, Rol, NombreCompleto)
VALUES 
('admin', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEg8K2p9nog=', 'admin', 'Administrador Principal'),
('socio1', 'p3C8vL9xQ2rT5uY7zA1bM4nK6=', 'socio', 'Juan Pérez'),
('socio2', 'kW2xN7pQ9rT3vY5zB8cM1nL4=', 'socio', 'María García');

UPDATE Usuarios SET IdSocio = 2, Email = 'juan@example.com' WHERE Username = 'socio1';
UPDATE Usuarios SET IdSocio = 3, Email = 'maria@example.com' WHERE Username = 'socio2';
UPDATE Usuarios SET Email = 'admin@example.com' WHERE Username = 'admin';