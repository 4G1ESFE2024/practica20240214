-- Crear la base de datos
CREATE DATABASE Practica20240214DB;
GO

-- Usar la base de datos recién creada
USE Practica20240214DB;
GO

-- Crear la tabla de tallas
CREATE TABLE Tallas (
    IdTalla INT PRIMARY KEY,
    NombreTalla NVARCHAR(50)
);
GO
-- Crear la tabla de ropas
CREATE TABLE Ropas (
    IdRopa INT PRIMARY KEY,
    NombreRopa NVARCHAR(100),
    TipoRopa NVARCHAR(50),
    IdTalla INT FOREIGN KEY REFERENCES Tallas(IdTalla)
);
GO


