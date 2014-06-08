CREATE DATABASE [proyecto_diseno] ON  PRIMARY 
( NAME = N'proyecto_diseno', FILENAME = N'C:\BD_TAREA1\Disco_C\datos\proyecto_diseno.mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'proyecto_diseno_log', FILENAME = N'C:\BD_TAREA1\Disco_D\bitacora\proyecto_diseno_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [proyecto_diseno] SET COMPATIBILITY_LEVEL = 100
GO
ALTER DATABASE [proyecto_diseno] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [proyecto_diseno] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [proyecto_diseno] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [proyecto_diseno] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [proyecto_diseno] SET ARITHABORT OFF 
GO
ALTER DATABASE [proyecto_diseno] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [proyecto_diseno] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto_diseno] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [proyecto_diseno] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto_diseno] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [proyecto_diseno] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [proyecto_diseno] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [proyecto_diseno] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [proyecto_diseno] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [proyecto_diseno] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [proyecto_diseno] SET  DISABLE_BROKER 
GO
ALTER DATABASE [proyecto_diseno] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [proyecto_diseno] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [proyecto_diseno] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [proyecto_diseno] SET  READ_WRITE 
GO
ALTER DATABASE [proyecto_diseno] SET RECOVERY FULL 
GO
ALTER DATABASE [proyecto_diseno] SET  MULTI_USER 
GO
ALTER DATABASE [proyecto_diseno] SET PAGE_VERIFY CHECKSUM  
GO
USE [proyecto_diseno]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [proyecto_diseno] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
use proyecto_diseno;
GO
IF OBJECT_ID('BITACORA_COMERCIO', 'U') IS NOT NULL
  drop table BITACORA_COMERCIO;

IF OBJECT_ID('BITACORA_NOTICIAS', 'U') IS NOT NULL
drop table BITACORA_NOTICIAS;

IF OBJECT_ID('BITACORA_PRODUCTOS', 'U') IS NOT NULL
drop table BITACORA_PRODUCTOS;

IF OBJECT_ID('BITACORA_USUARIOS', 'U') IS NOT NULL
drop table BITACORA_USUARIOS;

IF OBJECT_ID('BUSQUEDAS', 'U') IS NOT NULL
drop table BUSQUEDAS;

IF OBJECT_ID('BUSQUEDAXCOMERCIOS', 'U') IS NOT NULL
drop table BUSQUEDAXCOMERCIOS;

IF OBJECT_ID('BUSQUEDAXPRODUCTOS', 'U') IS NOT NULL
drop table BUSQUEDAXPRODUCTOS;

IF OBJECT_ID('PRODUCTOSXCOMERCIO', 'U') IS NOT NULL
drop table PRODUCTOSXCOMERCIO;

IF OBJECT_ID('COMERCIOS', 'U') IS NOT NULL
drop table COMERCIOS;

IF OBJECT_ID('CONDICION', 'U') IS NOT NULL
drop table CONDICION;

IF OBJECT_ID('NOTICIAS', 'U') IS NOT NULL
drop table NOTICIAS;

IF OBJECT_ID('NOTICIASXCONDICION', 'U') IS NOT NULL
drop table NOTICIASXCONDICION;

IF OBJECT_ID('PRODUCTOS', 'U') IS NOT NULL
drop table PRODUCTOS;

IF OBJECT_ID('ROLES', 'U') IS NOT NULL
drop table ROLES;

IF OBJECT_ID('ROLESXUSUARIO', 'U') IS NOT NULL
drop table ROLESXUSUARIO;

IF OBJECT_ID('TIPO_COMERCIO', 'U') IS NOT NULL
drop table TIPO_COMERCIO;

IF OBJECT_ID('TIPO_INFORMACION', 'U') IS NOT NULL
drop table TIPO_INFORMACION;

IF OBJECT_ID('TIPO_PRODUCTO', 'U') IS NOT NULL
drop table TIPO_PRODUCTO;

IF OBJECT_ID('USUARIOS', 'U') IS NOT NULL
drop table USUARIOS;

IF OBJECT_ID('USUARIOXCONDICION', 'U') IS NOT NULL
drop table USUARIOXCONDICION;

/*==============================================================*/
/* Table: BITACORA_COMERCIO                                     */
/*==============================================================*/
create table BITACORA_COMERCIO 
(
   ID_BITACORA          int                            not null,
   ID_COMERCIO_IMPLICADO char(10)                       null,
   ID_USR_IMPLICADO     int                            null,
   NOMBRE_ANTERIOR      varchar(100)                   null,
   LATITUD_ANTERIOR     decimal(10,7)                  null,
   LONGUITUD_ANTERIOR   decimal(10,7)                  null,
   CORREO_ANTERIOR      varchar(50)                    null,
   ACCION_REALIZADA     char(10)                       null,
   constraint PK_BITACORA_COMERCIO primary key clustered (ID_BITACORA)
);

/*==============================================================*/
/* Table: BITACORA_NOTICIAS                                     */
/*==============================================================*/
create table BITACORA_NOTICIAS 
(
   ID_BITACORA          int                            not null,
   ID_USR_RESPONSABLE   integer                        null,
   FECHA_MODIFICACION   datetime                       null,
   ACCION_REALIZADA     char(10)                       null,
   constraint PK_BITACORA_NOTICIAS primary key clustered (ID_BITACORA)
);

/*==============================================================*/
/* Table: BITACORA_PRODUCTOS                                    */
/*==============================================================*/
create table BITACORA_PRODUCTOS 
(
   ID_BITACORA          int                            not null,
   ID_USR_RESPOSABLE    int                            null,
   TIPO_PROD_ANTERIOR   numeric(2)                     null,
   FECHA_MODIFICACION   datetime                       null,
   ACCION_REALIZADA     char(10)                       null,
   constraint PK_BITACORA_PRODUCTOS primary key clustered (ID_BITACORA)
);

/*==============================================================*/
/* Table: BITACORA_USUARIOS                                     */
/*==============================================================*/
create table BITACORA_USUARIOS 
(
   ID_BITACORA          int                            not null,
   ID_USR_IMPLICADO     int                            null,
   CORREO_ANTERIOR      varchar(50)                    null,
   NOMBRE_ANTERIOR      varchar(60)                    null,
   APELLIDO_ANTERIOR    varchar(60)                    null,
   ID_ROL_ANTERIOR      numeric(2)                         null,
   FECHA_MODIFICACION   datetime                       null,
   ACCION_REALIZADA     char(10)                       null,
   constraint PK_BITACORA_USUARIOS primary key clustered (ID_BITACORA)
);

/*==============================================================*/
/* Table: BUSQUEDAS                                             */
/*==============================================================*/
create table BUSQUEDAS 
(
   ID_BUSQUEDA          int                            not null,
   ID_USUARIO           int                            null,
   FECHA_HORA           datetime                       null,
   constraint PK_BUSQUEDAS primary key clustered (ID_BUSQUEDA)
);

/*==============================================================*/
/* Table: BUSQUEDAXCOMERCIOS                                    */
/*==============================================================*/
create table BUSQUEDAXCOMERCIOS 
(
   ID_BUSQUEDA          int                            not null,
   ID_COMERCIO          int                            not null,
   constraint PK_BUSQUEDAXCOMERCIOS primary key clustered (ID_BUSQUEDA, ID_COMERCIO)
);

/*==============================================================*/
/* Table: BUSQUEDAXPRODUCTOS                                    */
/*==============================================================*/
create table BUSQUEDAXPRODUCTOS 
(
   ID_BUSQUEDA          int                            not null,
   ID_PRODUCTO          int                            not null,
   constraint PK_BUSQUEDAXPRODUCTOS primary key clustered (ID_BUSQUEDA, ID_PRODUCTO)
);

/*==============================================================*/
/* Table: COMERCIOS                                             */
/*==============================================================*/
create table COMERCIOS 
(
   ID_COMERCIO          int                            not null,
   ID_TIPO              numeric(2)                     null,
   ID_USUARIO           int                            null,
   NOMBRE               varchar(100)                   null,
   LATITUD              decimal(10,7)                  null,
   LONGUITUD            decimal(10,7)                  null,
   TELEFONO             numeric(8)                     null,
   CORREO               varchar(50)                    null,
   constraint PK_COMERCIOS primary key clustered (ID_COMERCIO)
);

/*==============================================================*/
/* Table: CONDICION                                             */
/*==============================================================*/
create table CONDICION 
(
   ID_CONDICION         numeric(1)                         not null,
   NOMBRE               varchar(60)                    null,
   INFORMACION_CONDICION varchar(1000)                  null,
   constraint PK_CONDICION primary key clustered (ID_CONDICION)
);

/*==============================================================*/
/* Table: NOTICIAS                                              */
/*==============================================================*/
create table NOTICIAS 
(
   ID_NOTICIA           int                            not null,
   ID_USUARIO_CREADOR   int                            null,
   ID_TIPO_INFORMACION  numeric(3)                         null,
   TITULO               varchar(200)                   null,
   CUERPO_NOTICIA       varchar(max)                   null,
   constraint PK_NOTICIAS primary key clustered (ID_NOTICIA)
);

/*==============================================================*/
/* Table: NOTICIASXCONDICION                                    */
/*==============================================================*/
create table NOTICIASXCONDICION 
(
   ID_CONDICION         numeric(1)                         not null,
   ID_NOTICIA           int                            not null,
   constraint PK_NOTICIASXCONDICION primary key clustered (ID_NOTICIA, ID_CONDICION)
);

/*==============================================================*/
/* Table: PRODUCTOS                                             */
/*==============================================================*/
create table PRODUCTOS 
(
   ID_PRODUCTO          int                            not null,
   ID_TIPO              numeric(2)                     null,
   TIPO                 numeric(2)                     null,
   NOMBRE               varchar(100)                   null,
   INFORMACION_ADICIONAL varchar(1000)                  null,
   constraint PK_PRODUCTOS primary key clustered (ID_PRODUCTO)
);

/*==============================================================*/
/* Table: PRODUCTOSXCOMERCIO                                    */
/*==============================================================*/
create table PRODUCTOSXCOMERCIO 
(
   ID_COMERCIO          int                            not null,
   ID_PRODUCTO          int                            not null,
   constraint PK_PRODUCTOSXCOMERCIO primary key clustered (ID_COMERCIO, ID_PRODUCTO)
);

/*==============================================================*/
/* Table: ROLES                                                 */
/*==============================================================*/
create table ROLES 
(
   ID_ROL               numeric(2)                         not null,
   NOMBRE               varchar(60)                    null,
   constraint PK_ROLES primary key clustered (ID_ROL)
);

/*==============================================================*/
/* Table: ROLESXUSUARIO                                         */
/*==============================================================*/
create table ROLESXUSUARIO 
(
   ID_USUARIO           int                            not null,
   ID_ROL               numeric(2)                         not null,
   constraint PK_ROLESXUSUARIO primary key clustered (ID_USUARIO, ID_ROL)
);

/*==============================================================*/
/* Table: TIPO_COMERCIO                                         */
/*==============================================================*/
create table TIPO_COMERCIO 
(
   ID_TIPO              numeric(2)                     not null,
   NOMBRE               varchar(100)                   null,
   constraint PK_TIPO_COMERCIO primary key clustered (ID_TIPO)
);

/*==============================================================*/
/* Table: TIPO_INFORMACION                                      */
/*==============================================================*/
create table TIPO_INFORMACION 
(
   ID_TIPO              numeric(3)                         not null,
   NOMBRE               varchar(50)                    null,
   constraint PK_TIPO_INFORMACION primary key clustered (ID_TIPO)
);

/*==============================================================*/
/* Table: TIPO_PRODUCTO                                         */
/*==============================================================*/
create table TIPO_PRODUCTO 
(
   ID_TIPO              numeric(2)                     not null,
   NOMBRE               varchar(100)                   null,
   constraint PK_TIPO_PRODUCTO primary key clustered (ID_TIPO)
);

/*==============================================================*/
/* Table: USUARIOS                                              */
/*==============================================================*/
create table USUARIOS 
(
   ID_USUARIO           int                            not null,
   NOMBRE               varchar(60)                    null,
   APELLIDO             varchar(60)                    null,
   CORREO               varchar(50)                    null,
   CONTRASENA           varchar(32)                    null,
   constraint PK_USUARIOS primary key clustered (ID_USUARIO)
);

/*==============================================================*/
/* Table: USUARIOXCONDICION                                     */
/*==============================================================*/
create table USUARIOXCONDICION 
(
   ID_USUARIO           int                            not null,
   ID_CONDICION         numeric(1)                         not null,
   constraint PK_USUARIOXCONDICION primary key clustered (ID_USUARIO, ID_CONDICION)
);

alter table BUSQUEDAS
   add constraint FK_BUSQUEDA_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO);

alter table BUSQUEDAXCOMERCIOS
   add constraint FK_BUSQUEDAXCOMERCIOS foreign key (ID_BUSQUEDA)
      references BUSQUEDAS (ID_BUSQUEDA);

alter table BUSQUEDAXCOMERCIOS
   add constraint FK_BUSQUEDA_COMERCIO foreign key (ID_COMERCIO)
      references COMERCIOS (ID_COMERCIO);

alter table BUSQUEDAXPRODUCTOS
   add constraint FK_BUSQUEDAXPRODUCTOS foreign key (ID_BUSQUEDA)
      references BUSQUEDAS (ID_BUSQUEDA);

alter table BUSQUEDAXPRODUCTOS
   add constraint FK_BUSQUEDA_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTOS (ID_PRODUCTO);

alter table COMERCIOS
   add constraint FK_TIPO_COMERCIO foreign key (ID_TIPO)
      references TIPO_COMERCIO (ID_TIPO);

alter table NOTICIAS
   add constraint FK_NOTICIAS_USUARIO foreign key (ID_USUARIO_CREADOR)
      references USUARIOS (ID_USUARIO);

alter table NOTICIAS
   add constraint FK_TIPO_INF foreign key (ID_TIPO_INFORMACION)
      references TIPO_INFORMACION (ID_TIPO);

alter table NOTICIASXCONDICION
   add constraint FK_NOTXCON_CONDICION foreign key (ID_CONDICION)
      references CONDICION (ID_CONDICION);

alter table NOTICIASXCONDICION
   add constraint FK_NOTXCON_NOTICIAS foreign key (ID_NOTICIA)
      references NOTICIAS (ID_NOTICIA);

alter table PRODUCTOS
   add constraint FK_TIPO_PRODUCTO foreign key (ID_TIPO)
      references TIPO_PRODUCTO (ID_TIPO);

alter table PRODUCTOSXCOMERCIO
   add constraint FK_PRODXCOM_COM foreign key (ID_COMERCIO)
      references COMERCIOS (ID_COMERCIO);

alter table PRODUCTOSXCOMERCIO
   add constraint FK_PRODXCOM_PROD foreign key (ID_PRODUCTO)
      references PRODUCTOS (ID_PRODUCTO);

alter table ROLESXUSUARIO
   add constraint FK_ROLES_ROL foreign key (ID_ROL)
      references ROLES (ID_ROL);

alter table ROLESXUSUARIO
   add constraint FK_ROLES_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO);

alter table USUARIOXCONDICION
   add constraint FK_USRXCON_USR foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO);

alter table USUARIOXCONDICION
   add constraint FK_USRXCON_CONDICION foreign key (ID_CONDICION)
      references CONDICION (ID_CONDICION);
      