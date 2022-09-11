

CREATE DATABASE APIBD

USE APIBD

CREATE TABLE PROFESORES(
Idempleado int primary key identity(1,1),
NombreCompleto varchar(50),
Genero varchar(50),
FechaNacimiento varchar(50),
LugarDeNacimiento varchar(50),
Nacionalidad varchar(50),
Cedula varchar(50),
EstadoCivil varchar(50),
DepartamentoEnseñar varchar(50),
Telefono varchar(50),
Activo varchar(50),
Email varchar(50),
CONSTRAINT FK_IDPROFESORES FOREIGN KEY (Idempleado) REFERENCES PROFESORES (Idempleado)
)

CREATE TABLE ALUMNO(
Idalumnos int primary key identity(1,1),
ApellidoPaterno varchar(50),
ApellidoMaterno varchar(50),
Nombre varchar(50),
Genero varchar(50),
FechaNacimiento varchar(50),
LugarDeNacimiento varchar(50),
Nacionalidad varchar(50),
Calle varchar(50),
NumeroDeCalle varchar(50),
NumeroDeTelefono varchar(50),
Email varchar(50),
CONSTRAINT FK_IDALUMNO FOREIGN KEY (Idalumnos) REFERENCES ALUMNO (Idalumnos)
)

CREATE TABLE AULA(
Idaulas int primary key identity(1,1),
Profesor varchar(50),
Alumnos varchar(50)
CONSTRAINT FK_IDAULA FOREIGN KEY (Idaulas) REFERENCES AULA (Idaulas)
)

insert into PROFESORES(NombreCompleto,Genero,FechaNacimiento,LugarDeNacimiento,Nacionalidad,Cedula,EstadoCivil,DepartamentoEnseñar,Telefono,Activo,Email) values
('Luis', 'Masculino','1990','Clinia del niño','Dominicano','4-4785-89745-1','Soltero','Maestro de Ciencias Sociales', '809-854-9856','SI', 'juano@gmail.com'),
('Luisa', 'Femenino','1980','Clinia de Leon','Dominicano','3-0895-84269-1','Casada','Maestro de Ciencias Naturalez', '849-960-8547','NO', 'luisa@gmail.com')

insert into ALUMNO(ApellidoPaterno,ApellidoMaterno,Nombre,Genero,FechaNacimiento,LugarDeNacimiento,Nacionalidad,Calle,NumeroDeCalle,NumeroDeTelefono,Email) values
('Perez','Sanchez','Julian','Masculino','2005','Clinica de Macoris','Dominicano','Miramar','12','829-845-7845', 'julia45@gmail.com'),
('Lopez','Martinez','Julio','Masculino','2001','Clinica Franklin','Dominicano','La 20','56','849-125-9845', 'julio45@gmail.com')

insert into AULA(Profesor,Alumnos) values
('Luis', 'Juan')


SELECT * FROM PROFESORES

SELECT * FROM ALUMNO

SELECT * FROM AULA