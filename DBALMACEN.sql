Create database DB_Super

use DB_Super

create table Almacen
(
ID int identity(1,1) primary key,
NOMBRE varchar(50),
PRECIO Numeric,
CANTIDAD INT,
)

INSERT INTO Almacen (NOMBRE, PRECIO, CANTIDAD)
VALUES 
('Arroz Blanco', 75, 100),
('Habichuela Negra', 55, 50),
('Lata de Maiz', 35, 30);

select* from Almacen
