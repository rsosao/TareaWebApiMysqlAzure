CREATE DATABASE IF NOT EXISTS api_azure_tarea2
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE api_azure_tarea2;

CREATE TABLE IF NOT EXISTS libros (
  libro_id INT NOT NULL AUTO_INCREMENT,
  Isbn VARCHAR(20) NOT NULL,
  Titulo VARCHAR(200) NOT NULL,
  Autor VARCHAR(150) NOT NULL,
  Precio DECIMAL(12,2) NOT NULL,
  FechaPublicacion DATETIME NOT NULL,
  EjemplaresDisponibles INT NOT NULL,
  CONSTRAINT PK_libros PRIMARY KEY (libro_id),
  CONSTRAINT IX_libros_Isbn UNIQUE (Isbn)
) CHARACTER SET utf8mb4;
