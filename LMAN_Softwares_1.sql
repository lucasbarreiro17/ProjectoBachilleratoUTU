drop DATABASE if exists LMAN_Softwares;
CREATE DATABASE LMAN_Softwares;
use LMAN_Softwares;

#CREACION DE TABLAS#
create table Usuarios(
Cedula int(8) primary key unique,
Contraseña nvarchar (100) not null,
FirstName nvarchar(100) not null,
LastName nvarchar (100) not null,
Posicion nvarchar (100) not null,
Email nvarchar (150) not null,
Contacto char(12));

create table materiales(
Codigo int primary key,
Nombre nvarchar (25) not null,
Cantidad int );

create table salones(
CodigoSalon int primary key,
NumeroSalon int not null,
Nombre nvarchar(30),
Capacidad int not null);

create table profesores(
CI int primary key,
Nombre nvarchar(25) not null,
Apellido nvarchar(25) not null);


create table reserva_salones(
IdOrden int primary key auto_increment,
IdProfesor int not null,
IdCodigoSalon int not null,
Fecha date not null,
HoraReserva time not null,
HoraFinalizacion time not null,
Validado int not null,
foreign key (IdProfesor) references profesores(CI),
foreign key (IdCodigoSalon) references salones(CodigoSalon)
);

create table reserva_materiales(
IdOrden int primary key auto_increment,
IdProfesor int not null,
IdMaterial int not null,
Fecha date not null,
HoraReserva time not null,
HoraFinalizacion time not null,
Validado int not null,
foreign key (IdProfesor) references profesores(CI),
foreign key (IdMaterial) references materiales(codigo));

create table asistencia (
IdProfesor int not null,
Asistio bool not null,
Fecha varchar(10) not null,
foreign key (IdProfesor) references profesores(CI));

create table asignaturas (
IdAsignatura int primary key auto_increment,
Nombre nvarchar (30) not null);

create table horarios (
Codigo int (33) primary key,
Entrada time not null,
Salida time not null,
Turno nvarchar(50) not null);

create table horarios_asignatura (
IdAsignatura int not null,
CodigoHorario int not null,
Dia nvarchar(10) not null,
foreign key (CodigoHorario) references horarios(Codigo),
foreign key (IdAsignatura) references asignaturas(IdAsignatura));

create table asignatura_profesor (
IdProfesor int not null,
IdAsignatura int not null,
foreign key (IdProfesor) references profesores(CI),
foreign key (IdAsignatura) references asignaturas(IdAsignatura));

create table grupos (
Siglas nvarchar(3) primary key,
Nombre varchar(50) not null);

create table alumnos (
CI int primary key ,
Nombre nvarchar(50) not null,
Apellido nvarchar(50) not null);

create table grupos_asignatura (
IdGrupo nvarchar(3) not null,
IdAsignatura int not null,
foreign key(IdGrupo) references grupos(Siglas),
foreign key(IdAsignatura) references asignaturas(IdAsignatura));


create table profesores_grupos (
IdProfesor int not null,
IdGrupo nvarchar(3) not null,
foreign key (IdProfesor) references profesores(CI),
foreign key (IdGrupo) references grupos(Siglas));

create table salon_grupo (
IdGrupo nvarchar(3) not null,
IdSalon int not null,
foreign key (IdGrupo) references grupos(Siglas),
foreign key (IdSalon) references salones(CodigoSalon));

create table funcionarios (
CI int primary key,
Nombre nvarchar(50) not null,
Apellido nvarchar(50) not null,
Rol nvarchar(25) not null);

create table inasistencia_profesor(
CodigoInasistencia int primary key auto_increment,
Idprofesor int not null,
IdGrupo varchar(3),
Motivo nvarchar(200) not null,
Fecha date not null,
HoraE time not null,
HoraS time not null
);

create table alumnos_grupos(
IdAlumno int not null,
IdGrupo nvarchar(3) not null,
foreign key (IdAlumno) references alumnos(CI),
foreign key (IdGrupo) references grupos(Siglas));

create table validar_registro(
Cedula int(8) primary key unique,
Contraseña nvarchar (100) not null,
FirstName nvarchar(100) not null,
LastName nvarchar (100) not null,
Posicion nvarchar (100) not null,
Email nvarchar (150) not null,
Contacto char(12));

create table avisos(
numero int primary key ,
aviso nvarchar (200),
fecha date not null,
repetir int not null);

create table horarios_grupo(
IdGrupo nvarchar(3) not null,
IdHorario int not null,
IdAsignatura int not null,
Dia nvarchar(11) not null,
foreign key(IdGrupo) references grupos(Siglas),
foreign key(IdHorario) references horarios(Codigo),
foreign key(IdAsignatura) references asignaturas(IdAsignatura));


-- avisos:
insert into avisos(numero,aviso,fecha,repetir) values ('1','','2021/10/08','7');
insert into avisos(numero,aviso,fecha,repetir) values ('2','','2021/10/08','7');
insert into avisos(numero,aviso,fecha,repetir) values ('3','','2021/10/08','7');
insert into avisos(numero,aviso,fecha,repetir) values ('4','','2021/10/08','7');
insert into avisos(numero,aviso,fecha,repetir) values ('5','','2021/10/08','7');
-- personas:

insert into Usuarios (Cedula, Contraseña, Firstname, LastName, Posicion, Email) values ('90000000','admin','Director/a','de los jefes','Administrador','PruebaGmail@gmail.com');
insert into Usuarios (Cedula, Contraseña, Firstname, LastName, Posicion, Email) values ('20000000','ads12345','Juancito','Smith','Adscripto','Juan@gmail.com');
insert into Usuarios (Cedula, Contraseña, Firstname, LastName, Posicion, Email,Contacto) values ('51111122','51111122','Sergio','aguero','Administrativo','messibalondeoro@gmail.com','099843444');


-- Materiales:

insert into materiales (codigo, Nombre, Cantidad) values ('1234', 'Televisor 1', '1');
insert into materiales (codigo, Nombre, Cantidad) values ('2345', 'Televisor 2', '1');
insert into materiales (codigo, Nombre, Cantidad) values ('3456', 'Televisor 3', '1');
insert into materiales (codigo, Nombre, Cantidad) values ('4567', 'Proyector', '1');

-- salones:

insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1002','2','Laboratorio', '20');
insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1007','7','Multimedia', '15');
insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1008','8','Informatica piso 2', '20');
insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1005','5','Informatica piso 1', '15');
insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1006','6','Biblioteca', '15');
insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1009','9','Salon 9','15');
insert into salones (CodigoSalon,NumeroSalon,Nombre,Capacidad) values ('1010','10','Salon 10','20');
-- Horarios: 

insert into horarios(Codigo,Entrada,Salida,Turno) values ('1','7:00','7:45','Matutino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('2','7:45','8:30','Matutino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('3','8:35','9:20','Matutino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('4','9:25','10:10','Matutino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('5','10:20','11:05','Matutino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('6','11:10','11:55','Matutino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('7','12:00','12:45','Matutino');

insert into horarios(Codigo,Entrada,Salida,Turno) values ('8','13:00','13:45','Vespertino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('9','13:50','14:35','Vespertino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('10','14:40','15:25','Vespertino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('11','15:30','16:15','Vespertino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('12','16:20','17:05','Vespertino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('13','17:10','17:55','Vespertino');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('14','18:00','18:45','Vespertino');

insert into horarios(Codigo,Entrada,Salida,Turno) values ('15','17:10','17:55','Vespertino inter 1');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('16','18:00','18:45','Vespertino inter 1');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('17','18:50','19:35','Vespertino inter 1');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('18','19:40','20:25','Vespertino inter 1');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('19','20:30','21:15','Vespertino inter 1');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('20','21:20','22:05','Vespertino inter 1');

insert into horarios(Codigo,Entrada,Salida,Turno) values ('21','18:15','19:00','Vespertino inter 2');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('22','19:05','19:50','Vespertino inter 2');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('23','19:55','20:40','Vespertino inter 2');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('24','20:45','21:30','Vespertino inter 2');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('25','21:35','22:20','Vespertino inter 2');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('26','22:25','23:10','Vespertino inter 2');

insert into horarios(Codigo,Entrada,Salida,Turno) values ('27','19:15','19:55','Nocturno');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('28','20:00','20:40','Nocturno');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('29','20:45','21:25','Nocturno');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('30','21:30','22:10','Nocturno');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('31','22:15','22:55','Nocturno');
insert into horarios(Codigo,Entrada,Salida,Turno) values ('32','23:00','23:40','Nocturno');

-- Profesores:

insert into profesores(CI,Nombre,Apellido) values ('53895454','Gustavo','Caraballo');
insert into profesores(CI,Nombre,Apellido) values ('58765326','Gustavo','Delgado');
insert into profesores(CI,Nombre,Apellido) values ('52865334','Andres','Delmonte');
insert into profesores(CI,Nombre,Apellido) values ('46732312','Juan Pablo','Pimienta');
insert into profesores(CI,Nombre,Apellido) values ('46832754','Don','Carrasco');
insert into profesores(CI,Nombre,Apellido) values ('35741353','Aledia','Rodriguez');
insert into profesores(CI,Nombre,Apellido) values ('45968403','Victoria','Romano');

-- alumnos:

insert into alumnos(CI,Nombre,Apellido) values ('53138214','Antonio','Rupestre');
insert into alumnos(CI,Nombre,Apellido) values ('51111111','Leonel','Messi');



-- alumnos_grupos:



-- Inasistencia:

insert into inasistencia_profesor(IdProfesor,IdGrupo,Motivo,Fecha,HoraE,HoraS) values ('52865334','3BG','Licencia','2021/09/24','19:15','19:55');


-- reserva_salones:

insert into reserva_salones(Idprofesor,IdCodigoSalon,Fecha,HoraReserva,HoraFinalizacion,Validado) values ('53895454','1007','2021/09/23','19:15','22:10','0');

insert into asignaturas(Nombre) values ('Programacion');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(1,53895454);
insert into asignaturas(Nombre) values ('Sistemas Operativos');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(2,53895454);
insert into asignaturas(Nombre) values ('Matematicas');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(3,58765326);
insert into asignaturas(Nombre) values ('Historia');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(4,45968403);
insert into asignaturas(Nombre) values ('Ingles');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(5,46732312);
insert into asignaturas(Nombre) values ('Taller de redes');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(6,46832754);
insert into asignaturas(Nombre) values ('Filosofia');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(7,52865334);
insert into grupos(Siglas,Nombre) values ('3BG','Tercero de bachillerato de informatica');
insert into salon_grupo(IdGrupo,IdSalon) values ('3BG','1010');
insert into grupos(Siglas,Nombre) values ('3BK','Tercero de bachillerato de deporte');
insert into salon_grupo(IdGrupo,IdSalon) values ('3BK','1009');
insert into grupos(Siglas,Nombre) values ('2BK','Segundo de bachillerato de deporte');
insert into salon_grupo(IdGrupo,IdSalon) values ('2BK','1009');
insert into grupos(Siglas,Nombre) values ('3BI','Tercero de bachillerato de turismo');
insert into salon_grupo(IdGrupo,IdSalon) values ('3BI','1009');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BG','27','3','Lunes');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BG','28','3','Lunes');
insert into grupos_asignatura(IdGrupo,IdAsignatura) values('3BG','3');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('3','27','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('3','28','Lunes');
insert into profesores_grupos(IdProfesor,IdGrupo) values('58765326','3BG');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BG','29','7','Lunes');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BG','30','7','Lunes');
insert into grupos_asignatura(IdGrupo,IdAsignatura) values('3BG','7');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('7','29','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('7','30','Lunes');
insert into profesores_grupos(IdProfesor,IdGrupo) values('52865334','3BG');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BG','31','5','Lunes');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BG','32','5','Lunes');
insert into grupos_asignatura(IdGrupo,IdAsignatura) values('3BG','5');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('5','31','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('5','32','Lunes');
insert into profesores_grupos(IdProfesor,IdGrupo) values('46732312','3BG');
insert into Usuarios  (Cedula, Contraseña, Firstname, LastName, Posicion, Email,Contacto) values ('43736868','43736868','Bernardo','Barcelo','Profesor','BernardoBarcelona@gmail.com','099567845');
insert into profesores (CI,Nombre,Apellido) values ('43736868','Bernardo','Barcelo');
insert into asignaturas(Nombre) values('Contabilidad');
insert into asignatura_profesor(IdAsignatura,IdProfesor) values(8,43736868);
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BI','27','8','Lunes');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BI','28','8','Lunes');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BI','29','8','Lunes');
insert into grupos_asignatura(IdGrupo,IdAsignatura) values('3BI','8');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('8','27','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('8','28','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('8','29','Lunes');
insert into profesores_grupos(IdProfesor,IdGrupo) values('43736868','3BI');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BI','30','3','Lunes');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BI','31','3','Lunes');
insert into grupos_asignatura(IdGrupo,IdAsignatura) values('3BI','3');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('3','30','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('3','31','Lunes');
insert into profesores_grupos(IdProfesor,IdGrupo) values('58765326','3BI');
insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('3BI','32','7','Lunes');
insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('7','32','Lunes');
insert into profesores_grupos(IdProfesor,IdGrupo) values('52865334','3BI');
insert into Usuarios  (Cedula, Contraseña, Firstname, LastName, Posicion, Email,Contacto) values ('53494747','53494747','Lucas','Barreiro','Estudiante','','091519656');
insert into alumnos (CI, Nombre, Apellido) values ('53494747','Lucas','Barreiro');
insert into alumnos_grupos(IdAlumno,IdGrupo) values ('53494747','3BG');
