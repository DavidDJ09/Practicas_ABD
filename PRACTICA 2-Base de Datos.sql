create database practica2;
use practica2;

create table libros
(
id					int				primary key,
isbn				varchar(13)		not null,
titulo				varchar(40)		not null,
numeroDeEdicion		int				not null,
anioPublicacion		varchar(4)		not null,
autores				varchar(150)	not null,
paisDePublicacion	varchar(40)		not null,
sinopsis			text			not null,
carrera				varchar(50)		not null,
materia				varchar(40)		not null
);

insert into libros
values (1,'1458988542100','njhbhb',8,'2012','bbhbjhbhbjkl','mexico','ssbhdvbkdfvldskmvcdlsknvfbhdndsh','sistemas comp','automatas');

insert into libros
values (2,'7484856320012','hbjkj',4,'2020','kkjnjn','brasil','kbhb','gastro','m');

select * from libros;