-- Crear la base de datos
CREATE DATABASE Practica20240214DB;
GO

-- Usar la base de datos recién creada
USE Practica20240214DB;
GO

-- Crear la tabla de tallas
CREATE TABLE Tallas (
    IdTalla INT PRIMARY KEY IDENTITY(1,1),
    NombreTalla NVARCHAR(50) NOT NULL
);
GO
-- Crear la tabla de ropas
CREATE TABLE Ropas (
    IdRopa INT PRIMARY KEY IDENTITY(1,1),
    NombreRopa NVARCHAR(100) NOT NULL,
    TipoRopa NVARCHAR(50),
    IdTalla INT FOREIGN KEY REFERENCES Tallas(IdTalla)
);
GO


