use CooperativaDB;
go

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL, -- Recomendable almacenar hash, no texto plano
    Rol NVARCHAR(20) NOT NULL, -- 'admin' o 'socio'
    NombreCompleto NVARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Insertar usuarios de ejemplo
INSERT INTO Usuarios (Username, Password, Rol, NombreCompleto)
VALUES 
('admin', '1234', 'admin', 'Administrador Principal'),
('socio1', '5678', 'socio', 'Juan Pérez'),
('socio2', '9012', 'socio', 'María García');

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

CREATE TABLE TiposPrestamo (
    TipoPrestamoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    TasaInteres DECIMAL(5,2) NOT NULL,
    PlazoMaximoMeses INT NOT NULL,
    Descripcion NVARCHAR(255)
);
GO

-- Tabla de Préstamos
CREATE TABLE Prestamos (
    PrestamoID INT PRIMARY KEY IDENTITY(1,1),
    SocioID INT NOT NULL FOREIGN KEY REFERENCES Socios(SocioID),
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

-- Tabla de Cuotas de Préstamos
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

-- Tabla de Tipos de Movimiento
CREATE TABLE TiposMovimiento (
    TipoMovimientoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    AfectaSaldo BIT DEFAULT 1,
    Signo CHAR(1) CHECK (Signo IN ('+', '-'))
);
GO

-- Tabla de Movimientos
CREATE TABLE Movimientos (
    MovimientoID INT PRIMARY KEY IDENTITY(1,1),
    SocioID INT NOT NULL FOREIGN KEY REFERENCES Socios(SocioID),
    TipoMovimientoID INT NOT NULL FOREIGN KEY REFERENCES TiposMovimiento(TipoMovimientoID),
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Descripcion NVARCHAR(255),
    Referencia NVARCHAR(100),
    UsuarioID INT NULL FOREIGN KEY REFERENCES Usuarios(UsuarioID),
    PrestamoID INT NULL FOREIGN KEY REFERENCES Prestamos(PrestamoID)
);
GO

-- Tabla de Configuraciones
CREATE TABLE Configuraciones (
    ConfigID INT PRIMARY KEY IDENTITY(1,1),
    Clave NVARCHAR(100) UNIQUE NOT NULL,
    Valor NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(255),
    Tipo NVARCHAR(50) CHECK (Tipo IN ('Texto', 'Numero', 'Decimal', 'Fecha', 'Booleano'))
);
GO

-- Insertar datos iniciales
INSERT INTO TiposMovimiento (Nombre, Descripcion, AfectaSaldo, Signo)
VALUES 
('Ahorro', 'Depósito de ahorro regular', 1, '+'),
('Retiro', 'Retiro de fondos', 1, '-'),
('Pago Préstamo', 'Pago de cuota de préstamo', 0, '-'),
('Interés', 'Interés generado por ahorros', 1, '+'),
('Multa', 'Multa por mora', 1, '-');

INSERT INTO TiposPrestamo (Nombre, TasaInteres, PlazoMaximoMeses, Descripcion)
VALUES 
('Préstamo Personal', 12.00, 36, 'Préstamo para necesidades personales'),
('Préstamo Vivienda', 8.50, 120, 'Préstamo para mejoras de vivienda'),
('Préstamo Emergencia', 15.00, 12, 'Préstamo para emergencias');

INSERT INTO Configuraciones (Clave, Valor, Descripcion, Tipo)
VALUES
('MONEDA', 'RD$', 'Símbolo de moneda', 'Texto'),
('TASA_AHORRO', '5.00', 'Tasa de interés para ahorros anual', 'Decimal'),
('DIAS_GRACIA', '5', 'Días de gracia para pagos', 'Numero');
GO

-- Crear usuario admin inicial
INSERT INTO Socios (DNI, Nombre, Apellido, Estado)
VALUES ('00000000001', 'Admin', 'Sistema', 'Activo');



SELECT * FROM Socios;
SELECT * FROM Usuarios;