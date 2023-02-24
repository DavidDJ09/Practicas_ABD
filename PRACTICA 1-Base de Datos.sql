create database practica1;
use practica1;

create table AREAS
(
id				int				primary key,
Nombre			varchar(45)		not null,
Ubicacion		varchar(45)		not null
);

create table Inventario
(
id					int				primary key,
NombreCorto			varchar(45)		not null,
Descripcion			varchar(45)		not null,
Serie				varchar(45)		not null,
Color				varchar(45)		not null,
FechaAdquisicion	datetime		not null,
TipoAdquisicion		varchar(45)		not null,
Observaciones		varchar(45)		not null,
AREAS_id			int				not null,
constraint fk_areas foreign key (AREAS_id) references AREAS (id)
);
