USE Clinica_PI 

CREATE TABLE Sexo
(
	idSexo int,
	genero varchar(50) not null,
	CONSTRAINT pk_sexo PRIMARY KEY(idSexo)
)

CREATE TABLE ObrasSociales
(
	idObraSocial int,
	nombreObraSocial varchar(100) not null,
	CONSTRAINT pk_ObraSocial PRIMARY KEY(idObraSocial)
);

CREATE TABLE Pacientes
(
	numeroHC int,
	nombre varchar(50) not null,
	obraSocial int,
	sexo int not null,
	fechaNacimiento date not null,
	CONSTRAINT PK_numeroHC PRIMARY KEY(numeroHC),
	CONSTRAINT FK_obraSocial FOREIGN KEY(obraSocial)
					REFERENCES ObrasSociales(idObraSocial)
);

ALTER TABLE Pacientes
ADD CONSTRAINT FK_sexo FOREIGN KEY(sexo)
				REFERENCES Sexo(idSexo);

INSERT INTO Sexo(idSexo, genero)
			VALUES(1,'Femenino'),(2,'Masculino');

INSERT INTO ObrasSociales(idObraSocial, nombreObraSocial)
				VALUES(1,'APROSS'),(2,'MET'),(3,'OSDE'),(4,'DASUTEN'),(5,'DASPU'),(6,'PAMI');

INSERT INTO Pacientes(numeroHC,nombre,obraSocial,sexo,fechaNacimiento)
				VALUES(1,'Hugo',6,2,'1942/07/29'),(2,'Nicolás',2,2,'1990/04/20'),(3,'Patricia',3,1,'1982/08/20');

SELECT P.numeroHC, P.nombre 'Pacientes', O.nombreObraSocial 'Obra Social', 
		S.genero 'Sexo',P.fechaNacimiento 'Fecha de Nacimiento'
FROM Pacientes P
JOIN ObrasSociales O ON P.obraSocial=O.idObraSocial
JOIN Sexo S ON P.sexo=S.idSexo