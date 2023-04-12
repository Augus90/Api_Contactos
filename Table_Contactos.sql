
CREATE DATABASE ContactosDB;

USE ContactosDB
Create TABLE Contactos(
    id INT PRIMARY KEY NOT NULL,
    Nombre varchar(50) not null,
    Apellido varchar(50),
    Tipo_documento varchar(30),
    Nro_documento int not null
);

CREATE TABLE Telefonos(
    id INT PRIMARY KEY,
    Contactos_id int,
    Tipo_telefono varchar(30),
    Nro_telefono int not null,
    FOREIGN KEY(Contactos_id) REFERENCES Contactos(id)
);

CREATE TABLE Usuario(
    id INT PRIMARY KEY NOT NULL,
    usuario varchar(50) not null,
    password varchar(50) not null
);

INSERT INTO Contactos (id, Nombre, Apellido, tipo_documento, Nro_documento)
VALUES
    (1, 'Mario', 'Santos', 'DNI', 20234553),
    (2, 'Pablo', 'Lampone', 'DNI', 22253455),
    (3, 'Emilio', 'Ravenna', 'DNI', 18542960),
    (4, 'Gabriel', 'Medina', 'DNI', 20002348);

INSERT INTO Telefonos (id, Contactos_id, Tipo_telefono, Nro_telefono)
VALUES
    (1, 1,'Movil', 1545251432),
    (2, 2,'Movil', 1564566775),
    (3, 2,'Casa', 43968933),
    (4, 3,'Movil', 1565443533),
    (5, 3,'Movil', 1163456734),
    (6, 4,'Casa', 473573434);

INSERT INTO Usuario (id, usuario, password)
VALUES (1 , 'Admin', 'Password');


-- SELECT * FROM Contactos;



ALTER LOGIN [sa] WITH PASSWORD='Admin12345', CHECK_POLICY=OFF
GO
ALTER LOGIN [sa] ENABLE
GO