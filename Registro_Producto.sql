CREATE DATABASE Registro_productos

use Registro_productos

CREATE TABLE Producto(
id_producto int primary key not null,
nombre_producto varchar(50),
cantidad_producto int,
)

INSERT INTO Producto VALUES ('001','Mouse','100')

SELECT * FROM Producto