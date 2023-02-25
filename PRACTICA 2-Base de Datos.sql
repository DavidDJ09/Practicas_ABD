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
