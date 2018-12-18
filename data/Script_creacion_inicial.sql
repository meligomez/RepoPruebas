--Me conecto a la base de datos a usar
USE [GD2C2018]
GO
----------------------------------------------------------------------------------------------
								/** CREACION DE SCHEMA **/
----------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'dropeadores')
BEGIN
    EXEC ('CREATE SCHEMA dropeadores AUTHORIZATION gdEspectaculos2018')
END
GO


----------------------------------------------------------------------------------------------
								/** FIN CREACION DE SCHEMA**/
----------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------
								/** VALIDACION DE TABLAS **/
----------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.FuncionalidadXRol'))
    DROP TABLE dropeadores.FuncionalidadXRol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.RolXUsuario'))
    DROP TABLE dropeadores.RolXUsuario
        
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Funcionalidad'))
    DROP TABLE dropeadores.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Rol'))
    DROP TABLE dropeadores.Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.PremioXUsuario'))
    DROP TABLE dropeadores.PremioXUsuario 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.HistorialCliente'))
    DROP TABLE dropeadores.HistorialCliente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Ubicacion'))
    DROP TABLE dropeadores.Ubicacion	
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.TipoUbicacion'))
    DROP TABLE dropeadores.TipoUbicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Premio'))
    DROP TABLE dropeadores.Premio  

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Publicacion'))
    DROP TABLE dropeadores.Publicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Rubro'))
    DROP TABLE dropeadores.Rubro

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Grado'))
    DROP TABLE dropeadores.Grado

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Puntos'))
    DROP TABLE dropeadores.Puntos
    
 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Item_Factura'))
    DROP TABLE dropeadores.Item_Factura       
  
  IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Compra'))
    DROP TABLE dropeadores.Compra
      
  IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Cliente'))
    DROP TABLE dropeadores.Cliente
     
 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Factura'))
    DROP TABLE dropeadores.Factura   
    
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Empresa'))
    DROP TABLE dropeadores.Empresa
    
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Domicilio'))
    DROP TABLE dropeadores.Domicilio 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.TarjetaCredito'))
    DROP TABLE dropeadores.TarjetaCredito

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dropeadores.Usuario'))
    DROP TABLE dropeadores.Usuario


  
----------------------------------------------------------------------------------------------
							/** FIN VALIDACION DE TABLAS **/
----------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------
							/** INICIO CREACION DE TABLAS **/
----------------------------------------------------------------------------------------------

create table [dropeadores].Funcionalidad(
Id_Funcionalidad int primary key identity,
descripcion nvarchar(255) not null,
menu nvarchar(255)
)


create table [dropeadores].Rol(
Id_Rol int primary key identity,
nombre nvarchar(255) not null,
estado bit default 1
)


create table [dropeadores].FuncionalidadXRol(
Id_fxr int primary key identity,
rolId int not null references [dropeadores].Rol,
funcionalidadId int not null references [dropeadores].Funcionalidad ,
)

Create table [dropeadores].Usuario (
Id int primary key identity,
username nvarchar(255) unique not null,
password nvarchar(255) not null,
cambioPsw int default 0,
creadoPor nvarchar(255),
estado  int default 1,
intentos int default 0,
clienteId int,
CuitEmpresa varchar(255),
Baja bit default 1,
Fecha_Password datetime,
)

create table [dropeadores].RolXUsuario(
Id_rxu int primary key identity,
usuarioId int not null references [dropeadores].Usuario,
rolId int not null references [dropeadores].Rol,
)

create table [dropeadores].Empresa (
empresa_Cuit varchar(255) primary key,
empresa_mail nvarchar(255),
empresa_telefono numeric(10,0),
empresa_razon_social  nvarchar(255),
empresa_domicilio int,
empresa_fecha_creacion datetime,
empresa_estado bit default 1
)


Create table [dropeadores].Cliente (
NumeroDocumento numeric(18,0) primary key,
Nombre nvarchar(255),
Apellido nvarchar(255),
TipoDocumento nvarchar(50),
cuil nvarchar(255),
mail nvarchar(255),
fechaNacimiento datetime,
fechaCreacion datetime,
cliente_domicilio int,
telefono int,
estado bit
)

CREATE TABLE [DROPEADORES].[Domicilio] (
    [id] int primary key identity,
    [calle] nvarchar(255)  NULL,
    [numero] numeric(18,0)  NULL,
    [codigoPostal] nvarchar(255)  NULL,
    [departamento] nvarchar(255)  NULL,
    [localidad] nvarchar(255)  NULL,
    [ciudad] nvarchar(255)  NULL,
    [piso] numeric(18,0)  NULL,
  );
GO

Create table [dropeadores].TarjetaCredito (
Id int primary key identity,
clieteId numeric(18, 0),
propietario  nvarchar(255),
numero varchar(19),
fechaVencimiento datetime,
descripcion nvarchar(255)
)

create table [dropeadores].Rubro(
id int primary key identity,
rubro_Descripcion varchar(255) not null,
)


create table dropeadores.Grado(
id int primary key identity,
tipo varchar(255) not null,
porcentaje numeric(10,2) not null,
estado bit DEFAULT 1 not null)


CREATE TABLE [dropeadores].[Publicacion](
    [id]  int primary key identity,
    [empresaId] [varchar](255) ,
    [rubroId] [int] not null references [dropeadores].Rubro,
    [gradoId] [int] not null references [dropeadores].Grado,
    [descripcion] [nvarchar](250) NULL,
    [stock] [int] NULL,
    [fechaPublicacion] [datetime] NULL,
    [fechaEspectaculo] [datetime] NULL,
	fechaVencimiento datetime null,
    [estado] [int] NULL,
    [direccion] [nvarchar](250) NULL,
    FOREIGN KEY (empresaId) REFERENCES [dropeadores].Empresa(empresa_Cuit),
)


CREATE TABLE [dropeadores].[TipoUbicacion](
	[codigo] int primary key identity NOT NULL,
	[descripcion] [nvarchar](255) NULL
)

CREATE TABLE [dropeadores].[Ubicacion](
    [fila] [varchar](3) ,
    [asiento] [numeric](18, 0) ,
    [sinNumerar] [bit] NULL,
    [precio] [decimal](12, 2) NULL,
    [estado] [bit] NULL,
    [publicacionId] int NOT NULL  references [dropeadores].Publicacion,
    [tipoUbicacion] int NOT NULL  references [dropeadores].TipoUbicacion,
     primary key (fila,asiento,publicacionId)
)



create table [dropeadores].Compra(
id int primary key identity,
factura int,
compra_tipo_documento varchar(5),
compra_numero_documento numeric(18,0),
compra_TarjetaId int,
compra_fecha datetime not null,
compra_cantidad numeric(18,0) not null,
compra_precio int not null,
compra_puntosId int,
compra_ubicacionAsiento [numeric](18, 0),
compra_ubicacionFila [varchar](3),
compra_ubicacionPublic int,
compra_rendida bit default 0
FOREIGN KEY (compra_numero_documento) REFERENCES [dropeadores].Cliente(numeroDocumento),
)


create table dropeadores.Puntos(
 Puntos int,
 Descripcion nvarchar(255),
 PuntosVigentes int,
 FechaVencimiento datetime,
 Id_Compra int references dropeadores.Compra,
 Id_Cliente  numeric(18,0)  references dropeadores.Cliente,
 primary key(Id_Compra,Id_Cliente)
 )
-- CREATE TABLE dropeadores.FormaPago(
-- Id int primary key not null identity,
-- Descripcion nvarchar(255),
-- Numero bigint,
-- Mes_Vencimiento int,
-- Anio_Vencimiento int,
-- Cod_Seguridad int)


create table dropeadores.HistorialCliente(
Id_Cliente numeric(18,0) not null references dropeadores.Cliente,
Id_Compra int not null references dropeadores.Compra,
PRIMARY KEY (Id_Cliente,Id_Compra))

create table dropeadores.Premio(
Id int not null primary key identity,
descripcion nvarchar(255),
puntos int)

create table dropeadores.PremioXUsuario(
Id int not null primary key identity,
clienteId numeric(18,0) not null references dropeadores.Cliente,
premioId int not null references dropeadores.Premio)
   

-- HAY QUE LEER BIEN EL ENUNCIADO Y FIJARSE Q ONDA ESTAS TABLAS
Create table dropeadores.Factura(
Numero int primary key not null identity,
Fecha datetime,
TotalComisionCobrada decimal(14,2),
TotalEmpresaPagado decimal(14,2),
FormaDePago nvarchar(255),
Empresa_Id varchar(255) references dropeadores.Empresa
--,Forma_Pago int not null references dropeadores.FormaPago
)

create table dropeadores.Item_Factura(
Id int primary key not null identity,
Cantidad int default 1,
Monto decimal(16,2),
descripcion nvarchar(60),
Compra_Id int  references dropeadores.Compra,
Factura_Id int  references dropeadores.Factura
)




-----------------------------------------------------------------------------------------------------
										/* FIN DE CREACION DE TABLAS*/
-----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------
										/* INICIO DE CARGA DE DATOS */
-----------------------------------------------------------------------------------------------------
					 /*Rol*/
go
insert into [dropeadores].Rol (nombre) values
('Empresa'), 
('Administrativo'),
('Cliente');

					/*Funcionalidad*/
go
insert into dropeadores.Funcionalidad (descripcion,menu) values
('Registro de Usuarios','menuRegistroUsuario'),
('ABM de Rol','aBMRolToolStripMenuItem'),
('ABM de Clientes','menuABMCliente'),
('ABM de Empresas','menuABMEmpresa'),
('ABM de Rubro',''),
('ABM de Grado de Publicacion','ABMGradoToolStripMenuItem'),
('Generar Publicacion','menuPublicacion'),
('Editar Publicacion','menuPublicacion'),
('Comprar','menuComprar'),
('Historial de Cliente',''),
('Canje y Administracion de puntos','menuCliente'),
('Generar rendicion de comisiones','menuPagos'),
('Facturar Publicaciones','menuEstadisticas');


					/*RolXFuncionalidad*/
go
insert into dropeadores.FuncionalidadXRol(funcionalidadId,rolId) values
(1,1),(1,2),(1,3),(2,2),(3,2),(4,2),(6,2),(7,1),(8,1),(8,2),(9,3),(10,3),(11,3),(12,2),(13,1),(13,2),(13,3)


					/*Usuarios*/

/*usuarios creados por el grupo*/ 
go		
INSERT [dropeadores].[Usuario] ([username], [password], [cambioPsw], [creadoPor], [estado], [intentos], [clienteId], [CuitEmpresa], [Baja], [Fecha_Password]) VALUES ( N'admin', HASHBYTES('SHA2_256','w23e'), 0, NULL, 1, 0, NULL, NULL, 1, NULL)


insert into dropeadores.Usuario (username,password,cambioPsw,estado,intentos,clienteId,CuitEmpresa,Baja)
select distinct Espec_Empresa_Cuit,HASHBYTES('SHA2_256',Espec_Empresa_Cuit),1,1,0,0,Espec_Empresa_Cuit,1 from gd_esquema.Maestra
insert into dropeadores.RolXUsuario(usuarioId,rolId)
select u.Id,1 from dropeadores.Usuario u  where CuitEmpresa !='0'
insert into dropeadores.Usuario (username,password,cambioPsw,estado,intentos,clienteId,CuitEmpresa,Baja)
select distinct Cli_Dni,HASHBYTES('SHA2_256',Cli_Dni),1,1,0,Cli_Dni,0,1 from gd_esquema.Maestra where Cli_Dni is not null
insert into dropeadores.RolXUsuario(usuarioId,rolId)
select u.Id,3 from dropeadores.Usuario u  where clienteId!=0

				
				/*UsuariosXRoles*/
/*usuariosXRoles*/
  insert into dropeadores.RolXUsuario (usuarioId, rolId) values
	(1,2)



					/*Domicilio de la Empresa*/
insert into [dropeadores].Domicilio (calle,numero,codigoPostal,departamento,piso)
select distinct Espec_Empresa_Dom_Calle,Espec_Empresa_Nro_Calle,Espec_Empresa_Cod_Postal, Espec_Empresa_Depto,Espec_Empresa_Piso
from gd_esquema.Maestra m 
					/*Domicilio del Cliente*/
insert into [dropeadores].Domicilio(calle,numero,codigoPostal,departamento,piso)
select distinct Cli_Dom_Calle, Cli_Nro_Calle, Cli_Cod_Postal, Cli_Depto, Cli_Piso
from gd_esquema.Maestra m 



						/*Empresa*/
insert into [dropeadores].Empresa (empresa_Cuit,empresa_mail,empresa_razon_social)
select distinct Espec_Empresa_Cuit,Espec_Empresa_Mail,Espec_Empresa_Razon_Social
from gd_esquema.Maestra m 
where Espec_Empresa_Cuit is not null
go
update  [dropeadores].Empresa set empresa_estado=1

					/*Cliente*/
insert into [dropeadores].Cliente(NumeroDocumento,Nombre,Apellido,fechaNacimiento,mail,cliente_domicilio,estado)
select distinct Cli_Dni,Cli_Nombre,Cli_Apeliido,Cli_Fecha_Nac,Cli_Mail,d.id,1
from gd_esquema.Maestra m join dropeadores.Domicilio d on (m.Cli_Dom_Calle=d.calle and m.Cli_Nro_Calle=d.numero and m.Cli_Cod_Postal=d.codigoPostal and m.Cli_Depto=d.departamento)
where Cli_Dni is not null 
go
update  [dropeadores].Cliente set estado=1,  TipoDocumento='DNI'

				/*Rubro Espectaculo*/
go
insert into dropeadores.Rubro(rubro_Descripcion)
select distinct Espectaculo_Rubro_Descripcion from gd_esquema.Maestra where Espectaculo_Rubro_Descripcion not like ''
insert into dropeadores.Rubro(rubro_Descripcion) values
('Musical'),
('Infantil'),
('Comedia');

					/*Grado Publicacion*/
go
insert into dropeadores.Grado(tipo,porcentaje) values
('Alta',15),
('Media',10),
('Baja',5);


					/*Premio*/
insert into dropeadores.Premio (descripcion,puntos) values ('Dinero en Efectivo',100)
insert into dropeadores.Premio (descripcion,puntos) values ('Entrada Gratis',500)
insert into dropeadores.Premio (descripcion,puntos) values ('Descuento 5%',75)
insert into dropeadores.Premio (descripcion,puntos) values ('Descuento 10%',190)
insert into dropeadores.Premio (descripcion,puntos) values ('2x1 en Drama',650)
insert into dropeadores.Premio (descripcion,puntos) values ('2x1 en Infantil',3350)
insert into dropeadores.Premio (descripcion,puntos) values ('50% de Descuento en la proxima compra',9889)
insert into dropeadores.Premio (descripcion,puntos) values ('3 Cuotas sin Interés en la proxima compra',8984)
insert into dropeadores.Premio (descripcion,puntos) values ('6 Cuotas sin Interés en la proxima compra',9874)  

				/*Tipo Ubicacion */
SET IDENTITY_INSERT [dropeadores].TipoUBicacion ON
insert into dropeadores.TipoUBicacion (codigo,descripcion)
SELECT distinct Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion from gd_esquema.Maestra
SET IDENTITY_INSERT [dropeadores].TipoUBicacion OFF
							
				/*Publicacion*/
SET IDENTITY_INSERT [dropeadores].Publicacion ON
INSERT INTO dropeadores.Publicacion (id,empresaId,rubroId,gradoId,descripcion,stock,fechaPublicacion,fechaVencimiento,fechaEspectaculo,estado,direccion)
select distinct Espectaculo_Cod, e.empresa_Cuit,
(select top 1 id from dropeadores.Rubro) ,
(select top 1 id from dropeadores.Grado),
Espectaculo_Descripcion,20,DATEADD(DAY,-5,Espectaculo_Fecha),Espectaculo_Fecha_Venc,Espectaculo_Fecha,
CASE		
	WHEN Espectaculo_Estado LIKE 'Publicada' THEN 1
	WHEN Espectaculo_Estado LIKE 'Borrador' THEN 0
	ELSE 2
END
,'Direccion del espectaculo' from gd_esquema.Maestra
m join dropeadores.Empresa e on(e.empresa_Cuit=m.Espec_Empresa_Cuit)
SET IDENTITY_INSERT [dropeadores].Publicacion OFF

 
				/*Ubicacion*/

insert  into dropeadores.Ubicacion (fila,asiento,sinNumerar,estado,publicacionId,tipoUbicacion,precio)
select distinct  Ubicacion_Fila,Ubicacion_Asiento,Ubicacion_Sin_numerar,1
, p.id
,Ubicacion_Tipo_Codigo,ubicacion_precio
from gd_esquema.Maestra m
join dropeadores.Publicacion p on(p.id=m.Espectaculo_Cod)

				/*Tarjeta de Crédito*/			
insert into dropeadores.TarjetaCredito (clieteId,propietario,numero,fechaVencimiento,descripcion)
select distinct Cli_Dni,Cli_Nombre+' '+Cli_Apeliido,0,DATEADD(YEAR,4,GETDATE()),ISNULL(Forma_Pago_Desc,'Sin Definir') from gd_esquema.Maestra	


				/*Compra*/
insert into dropeadores.Compra(factura,compra_tipo_documento,compra_numero_documento,compra_fecha,compra_cantidad,compra_ubicacionAsiento,compra_ubicacionFila,compra_ubicacionPublic,compra_precio,compra_TarjetaId)
select  m.Factura_Nro,'DNI',m.Cli_Dni,m.Compra_Fecha, m.Compra_Cantidad, m.Ubicacion_Asiento,m.Ubicacion_Fila,m.Espectaculo_Cod,u.precio
,(select t.id from dropeadores.TarjetaCredito t where t.descripcion=m.Forma_Pago_Desc and t.clieteId=m.Cli_Dni)
 from gd_esquema.Maestra m
  join dropeadores.Ubicacion u on u.asiento = m.Ubicacion_Asiento and 
  m.Ubicacion_Fila = u.fila and u.publicacionId = m.Espectaculo_Cod
where (m.Compra_Fecha is not null) and (m.Factura_Fecha is not null)


						/*Puntos*/	
-- --Solo agregue el Id de premio 1..... habrá q ver como hacer para insertar todos los premios.
  INSERT INTO dropeadores.Puntos (puntos,PuntosVigentes,FechaVencimiento,Id_Compra,Id_Cliente)
 SELECT distinct  5,0,DATEADD(DAY,5,c.compra_fecha) ,Id,compra_numero_documento
   FROM dropeadores.Compra c
   --Aca le modifico los puntos vigentes como la suma de los puntos de las compras de ese cliente.
 UPDATE dropeadores.Puntos set PuntosVigentes=(select SUM(puntos) from dropeadores.Puntos p2 where p2.Id_Cliente=Puntos.Id_Cliente) 
 alter table dropeadores.Puntos add constraint CK_puntosPositivos check (puntos>=0)


-- 				/*Factura*/
SET IDENTITY_INSERT [dropeadores].Factura ON
 insert into dropeadores.Factura (Numero,Fecha,TotalComisionCobrada,FormaDePago,Empresa_Id)
 SELECT distinct Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc,empresa_Cuit from gd_esquema.Maestra m
 join dropeadores.Empresa e on(e.empresa_Cuit=m.Espec_Empresa_Cuit)
 where Item_Factura_Cantidad is not null
 order by Factura_Nro
 SET IDENTITY_INSERT [dropeadores].Factura OFF



-- 				/*Item Factura*/
 INSERT INTO dropeadores.Item_Factura (Compra_Id,Cantidad,Descripcion,Monto,Factura_Id)
 SELECT DISTINCT id, Item_Factura_Cantidad, Item_Factura_Descripcion, Item_Factura_Monto, Factura_Nro
FROM gd_esquema.Maestra m, dropeadores.compra c
WHERE Factura_Nro IS NOT NULL AND c.compra_fecha=m.Compra_Fecha AND compra_numero_documento=m.Cli_Dni
	


-----------------------------------------------------------------------------------------------------
										/* FIN DE CARGA DE DATOS */
-----------------------------------------------------------------------------------------------------




-----------------------------------------------------------------------------------------------------
						        /* INICIO VALIDACION PROCEDURES */
-----------------------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[altaItem]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[altaItem]
GO
/****** Object:  StoredProcedure [dropeadores].[AltaUbicacion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[AltaUbicacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[AltaUbicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[DescontarPuntosPorCompra]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[DescontarPuntosPorCompra]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[DescontarPuntosPorCompra]
GO
/****** Object:  StoredProcedure [dropeadores].[EliminarPublicacion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[EliminarPublicacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[EliminarPublicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[ActualizarPuntaje]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[ActualizarPuntaje]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[ActualizarPuntaje]
GO
/****** Object:  StoredProcedure [dropeadores].[getClientesMasPuntosVencidos]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getClientesMasPuntosVencidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getClientesMasPuntosVencidos]
GO
/****** Object:  StoredProcedure [dropeadores].[GetComprasPorEmpresa]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[GetComprasPorEmpresa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[GetComprasPorEmpresa]
GO
/****** Object:  StoredProcedure [dropeadores].[getLocalidadesNoVendidas]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getLocalidadesNoVendidas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getLocalidadesNoVendidas]
GO
/****** Object:  StoredProcedure [dropeadores].[getPrecioDeUbicacionPorCategoria]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getPrecioDeUbicacionPorCategoria]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getPrecioDeUbicacionPorCategoria]
GO
/****** Object:  StoredProcedure [dropeadores].[UpdatePrecioUbicacion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[UpdatePrecioUbicacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[UpdatePrecioUbicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[altaFactura]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[altaFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[altaFactura]
GO
/****** Object:  StoredProcedure [dropeadores].[getClientesMayorCantCompras]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getClientesMayorCantCompras]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getClientesMayorCantCompras]
GO
/****** Object:  StoredProcedure [dropeadores].[GetFuncionalidades]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[GetFuncionalidades]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[GetFuncionalidades]
GO
/****** Object:  StoredProcedure [dropeadores].[getFuncionalidadPorRol]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getFuncionalidadPorRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getFuncionalidadPorRol]
GO
/****** Object:  StoredProcedure [dropeadores].[altaPublicacion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[altaPublicacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[altaPublicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[AltaRolPorFuncionalidad]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[AltaRolPorFuncionalidad]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[AltaRolPorFuncionalidad]
GO
/****** Object:  StoredProcedure [dropeadores].[altaTipoUbicacion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[altaTipoUbicacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[altaTipoUbicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[buscarCodigoTipoUbicacion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[buscarCodigoTipoUbicacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[buscarCodigoTipoUbicacion]
GO

/****** Object:  StoredProcedure [dropeadores].[getIdByDescripcion]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getIdByDescripcion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getIdByDescripcion]
GO
/****** Object:  StoredProcedure [dropeadores].[getDescripcionCategoriaById]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[getDescripcionCategoriaById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[getDescripcionCategoriaById]
GO
/****** Object:  StoredProcedure [dropeadores].[Alta_Rol]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[Alta_Rol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[Alta_Rol]
GO
/****** Object:  StoredProcedure [dropeadores].[Rol_ObtenerId]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[Rol_ObtenerId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[Rol_ObtenerId]
GO
/****** Object:  StoredProcedure [dropeadores].[obtenerRolByName]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[obtenerRolByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[obtenerRolByName]
GO
/****** Object:  StoredProcedure [dropeadores].[obtenerUsuarioByUsername]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[obtenerUsuarioByUsername]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[obtenerUsuarioByUsername]
GO
/****** Object:  StoredProcedure [dropeadores].[pasarAInhabilitado]    Script Date: 12/16/2018 22:30:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dropeadores].[pasarAInhabilitado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dropeadores].[pasarAInhabilitado]
GO

GO
/****** Object:  StoredProcedure [dropeadores].[Usuario_UpdatePsw]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Usuario_UpdatePsw]
GO
/****** Object:  StoredProcedure [dropeadores].[Usuario_Alta_Empresa]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Usuario_Alta_Empresa]
GO
/****** Object:  StoredProcedure [dropeadores].[Usuario_Alta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Usuario_Alta]
GO
/****** Object:  StoredProcedure [dropeadores].[updateUbicacion]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateUbicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[updateTarjetaCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateTarjetaCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[updatePuntos]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updatePuntos]
GO
/****** Object:  StoredProcedure [dropeadores].[updateGrado]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateGrado]
GO
/****** Object:  StoredProcedure [dropeadores].[updateEmpresa]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateEmpresa]
GO
/****** Object:  StoredProcedure [dropeadores].[updateDomicilioEmpresa]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateDomicilioEmpresa]
GO
/****** Object:  StoredProcedure [dropeadores].[updateDomicilioCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateDomicilioCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[updateCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[updateCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[obtenerIDcompra]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[obtenerIDcompra]
GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerGradoEspecifico]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ObtenerGradoEspecifico]
GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerEmpresaEspecifica]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ObtenerEmpresaEspecifica]
GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerDireccionEmpresaEspecifica]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ObtenerDireccionEmpresaEspecifica]
GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerClienteSinTarjeta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ObtenerClienteSinTarjeta]
GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerClienteEspecifico]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ObtenerClienteEspecifico]
GO
/****** Object:  StoredProcedure [dropeadores].[login]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[login]
GO
/****** Object:  StoredProcedure [dropeadores].[insertTarjetaCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[insertTarjetaCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[insertPuntos]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[insertPuntos]
GO
/****** Object:  StoredProcedure [dropeadores].[insertCompra]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[insertCompra]
GO
/****** Object:  StoredProcedure [dropeadores].[Grado_Alta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Grado_Alta]
GO
/****** Object:  StoredProcedure [dropeadores].[getUbicacion]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getUbicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[getTablaPublicacion]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getTablaPublicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[getPublicacion]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getPublicacion]
GO
/****** Object:  StoredProcedure [dropeadores].[getGradoSeleccionado]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getGradoSeleccionado]
GO
/****** Object:  StoredProcedure [dropeadores].[getGrado]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getGrado]
GO
/****** Object:  StoredProcedure [dropeadores].[getEmpresa]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getEmpresa]
GO
/****** Object:  StoredProcedure [dropeadores].[getClienteEspecifico]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getClienteEspecifico]
GO
/****** Object:  StoredProcedure [dropeadores].[getCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[getCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[ExistTarjetaCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ExistTarjetaCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[ExistEmpresa]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ExistEmpresa]
GO
/****** Object:  StoredProcedure [dropeadores].[ExistCuitandRazonSocial]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ExistCuitandRazonSocial]
GO
/****** Object:  StoredProcedure [dropeadores].[ExistCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[ExistCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[Empresa_Alta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Empresa_Alta]
GO
/****** Object:  StoredProcedure [dropeadores].[Emp_ObtenerId]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Emp_ObtenerId]
GO
/****** Object:  StoredProcedure [dropeadores].[Domicilio_empresa_Alta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Domicilio_empresa_Alta]
GO
/****** Object:  StoredProcedure [dropeadores].[Domicilio_Cli_Alta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Domicilio_Cli_Alta]
GO
/****** Object:  StoredProcedure [dropeadores].[DireEmp_ObtenerId]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[DireEmp_ObtenerId]
GO
/****** Object:  StoredProcedure [dropeadores].[DireCli_ObtenerId]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[DireCli_ObtenerId]
GO
/****** Object:  StoredProcedure [dropeadores].[deleteGrado]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[deleteGrado]
GO
/****** Object:  StoredProcedure [dropeadores].[deleteEmpresa]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[deleteEmpresa]
GO
/****** Object:  StoredProcedure [dropeadores].[deleteCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[deleteCliente]
GO
/****** Object:  StoredProcedure [dropeadores].[Cliente_Alta_Tarjeta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Cliente_Alta_Tarjeta]
GO
/****** Object:  StoredProcedure [dropeadores].[Cli_ObtenerId]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Cli_ObtenerId]
GO
/****** Object:  StoredProcedure [dropeadores].[Cli_Alta]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[Cli_Alta]
GO
/****** Object:  StoredProcedure [dropeadores].[asociarTarjetaCliente]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dropeadores].[asociarTarjetaCliente]
GO
/****** Object:  StoredProcedure [dbo].[obtenerUsuarioByUsername]    Script Date: 17/12/2018 1:44:20 ******/
DROP PROCEDURE [dbo].[obtenerUsuarioByUsername]
GO

-----------------------------------------------------------------------------------------------------
						        /* FIN VALIDACION DE PROCEDURES */
-----------------------------------------------------------------------------------------------------




-----------------------------------------------------------------------------------------------------
						        /* INICIO DE CREACION DE PROCEDURES */
-----------------------------------------------------------------------------------------------------

/*************ALTA ROL*****************/
GO
CREATE procedure [dropeadores].[Alta_Rol]
(@nombrerol nvarchar(255))
as
begin
insert into dropeadores.Rol (nombre) values (@nombreRol)
end
/****************************************/

/*************OBTENER ULTIMO ID INSERTADO DEL ROL*****************/

GO
CREATE PROCEDURE [dropeadores].[login](@user VARCHAR(100), @pass varchar(100), @ret smallint output)
AS 
BEGIN

  IF EXISTS( SELECT 1 FROM dropeadores.Usuario   WHERE username = @user )
  
     BEGIN

	    IF ( SELECT password FROM dropeadores.Usuario WHERE username = @user and estado=1) = HASHBYTES('SHA2_256', @pass)
		    BEGIN
			  UPDATE dropeadores.Usuario
              SET intentos = 0
              WHERE username = @user
				set @ret = 0 -- user + psw correctos
			END
           
		ELSE
			IF((select intentos from dropeadores.Usuario where username=@user and estado=1) < 3)
				BEGIN 

					UPDATE dropeadores.Usuario
					SET intentos =intentos + 1
					WHERE username = @user
					SET @ret = -3 -- suma intentos fallidos
		       END
		   ELSE
			   BEGIN
				   UPDATE dropeadores.Usuario
				   --SET ACTIVO = 0
					set intentos = 3
				   WHERE username = @user
				  -- AND usuario_intentos = 3
		   
				   SET @ret = -2 -- fallo en los intentos de login
		   
			   END
      END

   ELSE
   begin
		SET @ret= -1 -- no esta activo y usuario incorrecto
   end
SELECT @ret as 'ret'
END

   
/**********************FIN LOGIN **********************/


/**********************INICIO ActualizarPuntaje **********************/
GO
CREATE PROCEDURE [dropeadores].[ActualizarPuntaje] (@idCliente int, @idPremio int,@puntosParaCanjear int )
as
begin
INSERT INTO dropeadores.PremioXUsuario (clienteId,premioId) values (@idCliente, @idPremio)
UPDATE dropeadores.Puntos set PuntosVigentes=PuntosVigentes-@puntosParaCanjear where Id_Cliente=@idCliente
end
GO

/**********************FIN ActualizarPuntaje **********************/



/**********************INICIO ALTA PUBLICACION **********************/
GO
CREATE procedure [dropeadores].[altaPublicacion](
@descripcion nvarchar(255), 
@stock int, @fechaPublicacion datetime, @fechaEspectaculo datetime,
 @direccion nvarchar(255), 
@rubroId int, @gradoId int ,@empresaId nvarchar(255), @estado int,@fechaVencimiento datetime)
as
begin

insert into dropeadores.Publicacion (empresaId,rubroId,gradoId,descripcion,stock,
fechaPublicacion,fechaEspectaculo,direccion,estado,fechaVencimiento)
values (@empresaId,@rubroId,@gradoId,@descripcion,@stock,@fechaPublicacion,@fechaEspectaculo,
@direccion,@estado,@fechaVencimiento)

Select Max(id)as'Id' from dropeadores.Publicacion
end
  

/**********************FIN ALTA PUBLICACION **********************/

/**********************INICIO ALTA ROL POR FUNCIONALIDAD **********************/

GO
CREATE procedure [dropeadores].[AltaRolPorFuncionalidad]
(@idRol int,@idFunc int)
as
begin
	insert into dropeadores.FuncionalidadXRol (rolId,funcionalidadId) values (@idRol,@idFunc)
end
/**********************FIN ALTA ROL POR FUNCIONALIDAD  **********************/

/**********************INICIO altaTipoUbicacion **********************/
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[altaTipoUbicacion](@categoria nvarchar(255))
as
begin
INSERT INTO DROPEADORES.TipoUbicacion (descripcion) VALUES (@categoria)
Select Max(codigo)as'Id' from dropeadores.TipoUBicacion
end
GO
/**********************FIN altaTipoUbicacion  **********************/

/**********************INICIO AltaUbicacion **********************/
GO
CREATE procedure [dropeadores].[AltaUbicacion] 
(@asiento int, @fila nvarchar(3), @estado bit,@tipoUbicacionId int,
@idPublicacion int,@precio numeric(18,2))
as
begin
insert into dropeadores.Ubicacion (fila,asiento,estado,publicacionId,tipoUbicacion,precio)
values (@fila,@asiento,@estado,@idPublicacion,@tipoUbicacionId,@precio)
end
GO
/**********************FIN AltaUbicacion  **********************/


/**********************INICIO DescontarPuntosPorCompra  **********************/
GO
CREATE procedure [dropeadores].[DescontarPuntosPorCompra] (@idCliente int, @idCompra int)
as
begin
delete dropeadores.Puntos where Id_Compra = @idCompra and Id_Cliente=@idCliente
End
/**********************FIN DescontarPuntosPorCompra  **********************/


/**********************INICIO getFuncionalidadPorRol  **********************/
GO
CREATE procedure [dropeadores].[getFuncionalidadPorRol] (@rolId int)
 as
 begin
 select funcionalidadId from dropeadores.FuncionalidadXRol fxr where fxr.rolId=@rolId
 end
/**********************FIN getFuncionalidadPorRol  **********************/

/**********************INICIO getIdByDescripcion  **********************/
GO
CREATE procedure [dropeadores].[getIdByDescripcion] (@descripcion nvarchar(255))
as
begin
select codigo as 'Id' from dropeadores.TipoUBicacion where descripcion=@descripcion
end
/**********************FIN getIdByDescripcion  **********************/

/**********************INICIO obtenerRolByName  **********************/
GO
CREATE procedure [dropeadores].[obtenerRolByName]
(@nombrerol nvarchar(255))
as
begin
select * from dropeadores.Rol where nombre=@nombrerol
end
/**********************FIN obtenerRolByName  **********************/



/**********************INICIO obtenerUsuarioByUsername  **********************/
GO
CREATE procedure [dropeadores].[obtenerUsuarioByUsername]
@usname nvarchar(255)
as
select u.id,u.username,u.password,u.estado,u.intentos,cambioPsw,creadoPor,ISNULL(clienteId,0) as clienteId,ISNULL(CuitEmpresa,0) as CuitEmpresa
from Usuario u where u.username=@usname
/**********************FIN obtenerUsuarioByUsername  **********************/

/**************INICIO PASAR USUARIO A INHABILITADO*****************/
GO
CREATE procedure [dropeadores].[pasarAInhabilitado] (@user nvarchar(255))
as
begin
update dropeadores.Usuario set estado=0 where username=@user
end
/**************FIN PASAR USUARIO A INHABILITADO*****************/

/**************INICIO Rol_ObtenerId*****************/
GO
CREATE procedure [dropeadores].[Rol_ObtenerId]
as
begin
	Select Max(Id_Rol)as'Id'from dropeadores.Rol
end
/**************FIN Rol_ObtenerId*****************/


/**************INICIO Usuario_UpdatePsw*****************/

GO
CREATE procedure [dropeadores].[Usuario_UpdatePsw]
(@username nvarchar(255), @passNueva nvarchar(255))
as
begin
update dropeadores.Usuario set password=@passNueva, cambioPsw=1 where username=@username and estado=1
end
/**************FIN Usuario_UpdatePsw*****************/

/**************INICIO GetFuncionalidades*****************/
GO
CREATE procedure [dropeadores].[GetFuncionalidades] (@idCliente int)
as
begin
select menu as 'menu' from dropeadores.Funcionalidad f join dropeadores.FuncionalidadXRol fxr on(fxr.funcionalidadId=f.Id_Funcionalidad)
join dropeadores.RolXUsuario rxu on (rxu.rolId=fxr.rolId) where rxu.usuarioId=@idCliente
end
GO


/**************FIN GetFuncionalidades*****************/

/**************INICIO getClientesMasPuntosVencidos*****************/
GO
CREATE procedure [dropeadores].[getClientesMasPuntosVencidos] (@trimestre nvarchar(255), @anio nvarchar(255))
as
begin
if(@trimestre = 'Primer')
begin
SELECT TOP 5 id_cliente as 'DNI cliente',count(distinct id_compra) as 'Cantidad de compras', sum(PuntosVigentes) as 'Puntos Vencidos' 
from dropeadores.Puntos  where MONTH(	FechaVencimiento) between 1 and 3 and YEAR(FechaVencimiento) LIKE @anio
group by Id_Cliente order by 3 desc
end

if(@trimestre= 'Segundo')
begin
SELECT TOP 5 id_cliente as 'DNI cliente',count(distinct id_compra) as 'Cantidad de compras', sum(PuntosVigentes) as 'Puntos Vencidos' 
from dropeadores.Puntos  where MONTH(	FechaVencimiento) between 3 and 6 and YEAR(FechaVencimiento) LIKE @anio
group by Id_Cliente order by 1 desc
end

if(@trimestre='Tercer')
begin
SELECT TOP 5 id_cliente as 'DNI cliente',count(distinct id_compra) as 'Cantidad de compras', sum(PuntosVigentes) as 'Puntos Vencidos' 
from dropeadores.Puntos  where MONTH(	FechaVencimiento) between 6 and 9 and YEAR(FechaVencimiento) LIKE @anio
group by Id_Cliente order by 3 desc
end

if(@trimestre='Cuarto')
begin
SELECT TOP 5 id_cliente as 'DNI cliente',count(distinct id_compra) as 'Cantidad de compras', sum(PuntosVigentes) as 'Puntos Vencidos' 
from dropeadores.Puntos  where MONTH(	FechaVencimiento) between 9 and 12 and YEAR(FechaVencimiento) LIKE @anio
group by Id_Cliente order by 3 desc
end

end
GO

/**************FIN getClientesMasPuntosVencidos*****************/



/**************INICIO getClientesMayorCantCompras*****************/

GO
CREATE procedure [dropeadores].[getClientesMayorCantCompras] (@trimestre nvarchar(255), @anio nvarchar(255))
as
begin
if(@trimestre = 'Primer')
begin

SELECT TOP 5 compra_numero_documento as 'DNI cliente',count(distinct c.id) as 'Cantidad de compras',COUNT(distinct p.id) as 'Cantidad de Publicaciones'
from dropeadores.Compra c
join dropeadores.Publicacion p on(p.id=c.compra_ubicacionPublic)
 where MONTH(	compra_fecha) between 1 and 3 and YEAR(compra_fecha) LIKE @anio
group by compra_numero_documento,empresaId order by 2 desc

end

if(@trimestre= 'Segundo')
begin
SELECT TOP 5 compra_numero_documento as 'DNI cliente',count(distinct c.id) as 'Cantidad de compras',COUNT(distinct p.id) as 'Cantidad de Publicaciones'
from dropeadores.Compra c
join dropeadores.Publicacion p on(p.id=c.compra_ubicacionPublic)
 where MONTH(	compra_fecha) between 3 and 6 and YEAR(compra_fecha) LIKE @anio
group by compra_numero_documento,empresaId order by 2 desc
end

if(@trimestre='Tercer')
begin
SELECT TOP 5 compra_numero_documento as 'DNI cliente',count(distinct c.id) as 'Cantidad de compras',COUNT(p.id) as 'Cantidad de Publicaciones'
from dropeadores.Compra c
join dropeadores.Publicacion p on(p.id=c.compra_ubicacionPublic)
 where MONTH(	compra_fecha) between 6 and 9 and YEAR(compra_fecha) LIKE @anio
group by compra_numero_documento,empresaId order by 2 desc
end

if(@trimestre='Cuarto')
begin
SELECT TOP 5 compra_numero_documento as 'DNI cliente',count(distinct c.id) as 'Cantidad de compras',COUNT(distinct p.id) as 'Cantidad de Publicaciones'
from dropeadores.Compra c
join dropeadores.Publicacion p on(p.id=c.compra_ubicacionPublic)
 where MONTH(	compra_fecha) between 9 and 12 and YEAR(compra_fecha) LIKE @anio
group by compra_numero_documento,empresaId order by 2 desc
end

end
GO
/**************FIN getClientesMayorCantCompras*****************/


/**************FIN GetComprasPorEmpresa*****************/
GO
CREATE procedure [dropeadores].[GetComprasPorEmpresa](@cuit varchar(255))
as
begin
SELECT c.id as idCompra,
	p.id as idPublicacion, 
	p.descripcion as descripcion, 
	g.porcentaje as porcentaje, 
	u.fila as fila, 
	u.asiento as asiento,
	u.precio,
	c.compra_fecha,
	c.compra_cantidad
FROM dropeadores.Compra c
join dropeadores.Publicacion p on(c.compra_ubicacionPublic=p.id)
join dropeadores.Ubicacion u on(u.asiento=c.compra_ubicacionAsiento and u.fila=c.compra_ubicacionFila and u.publicacionId=c.compra_ubicacionPublic)
join dropeadores.Grado g on(g.id=p.gradoId)
WHERE p.empresaId = @cuit
	AND c.compra_rendida != 1
ORDER BY c.id,
	p.id,
	u.asiento,
	u.fila
end
GO

/**************FIN GetComprasPorEmpresa*****************/


/**************INICIO buscarCodigoTipoUbicacion*****************/
GO
CREATE procedure [dropeadores].[buscarCodigoTipoUbicacion] ( @descripcion nvarchar(255))
  as 
  begin
  select * from dropeadores.tipoUbicacion where descripcion like @descripcion
  end
GO
/**************FIN buscarCodigoTipoUbicacion*****************/


/**************INICIO UpdatePrecioUbicacion*****************/
GO
create procedure dropeadores.UpdatePrecioUbicacion (@codigoPublicacion int, @codigoTipoUbicacion int , @precio decimal(12,2))
as
begin
update dropeadores.Ubicacion set precio=@precio where publicacionId= @codigoPublicacion and tipoUbicacion=@codigoTipoUbicacion
end

/**************FIN UpdatePrecioUbicacion*****************/

/**************FIN UpdatePrecioUbicacion*****************/
GO
create procedure [dropeadores].[UpdatePrecioUbicacion] (@codigoPublicacion int, @codigoTipoUbicacion int , @precio decimal(12,2))
	as
	begin
	update dropeadores.Ubicacion set precio=@precio where publicacionId= @codigoPublicacion and tipoUbicacion=@codigoTipoUbicacion
	end
GO

  /**************FIN UpdatePrecioUbicacion*****************/


  /**************INICIO altaFactura*****************/
GO
create procedure [dropeadores].[altaFactura](@fecha datetime, @TotalComisionCobrada decimal(14,2),@TotalEmpresaPagado decimal(14,2),
  @empresaId varchar(255))
  as
  begin
  insert into dropeadores.Factura(Fecha,TotalComisionCobrada,TotalEmpresaPagado,Empresa_Id)
  values (@fecha,@TotalComisionCobrada,@TotalEmpresaPagado,@empresaId)
 
Select Max(Numero)as'Id' from dropeadores.Factura
  end
GO

 /**************FIN altaFactura*****************/


/**************INICIO altaItem*****************/
GO
CREATE procedure [dropeadores].[altaItem](@Cantidad int, @Monto decimal(14,2),@descripcion nvarchar(255),
  @compraId int,@facturaId int )
  as
  begin
  insert into dropeadores.Item_Factura(Cantidad,Monto,descripcion,Compra_Id,Factura_Id)
  values (@Cantidad,@Monto,@descripcion,@compraId,@facturaId)
update dropeadores.Compra set compra_rendida=1 where id=@compraId
  end
GO
  
/**************FIN altaItem*****************/


/**************INICIO eliminarPublicacion*****************/
GO
create procedure [dropeadores].[EliminarPublicacion] (@publicacionId int)
as
begin
delete dropeadores.Ubicacion where publicacionId= @publicacionId 
delete dropeadores.Publicacion	where id=@publicacionId
end
GO
/**************FIN eliminarPublicacion*****************/

/**************INICIO getLocalidadesNoVendidas*****************/
GO
CREATE procedure [dropeadores].[getLocalidadesNoVendidas] (@trimestre nvarchar(255), @anio nvarchar(255), @idGrado int)
as
begin
if(@trimestre ='Primer')
begin 
SELECT
 TOP 5 
				 EM.empresa_Cuit  as 'ID de la Empresa', 
				 EM.Empresa_Razon_Social as 'Razon Social', 
				 COUNT(PU.publicacionId) AS 'Localidades no vendidas', 
				 g.id as 'Grado de Prioridad',
				 month(P.fechaVencimiento) as 'Mes',
				 year(P.fechaVencimiento) as 'Año'
	FROM dropeadores.Ubicacion PU  
	LEFT JOIN dropeadores.Compra c on (c.compra_ubicacionPublic =pu.publicacionId and c.compra_ubicacionAsiento=pu.asiento and c.compra_ubicacionFila=pu.fila)
	JOIN dropeadores.Publicacion P ON PU.publicacionId = P.id
	INNER JOIN dropeadores.Empresa EM ON empresa_Cuit =p.empresaId
	INNER JOIN dropeadores.Grado g on g.id = p.gradoId
	WHERE c.id IS NULL and g.id=@idGrado
	 and  month(P.fechaVencimiento)  between 1 and 3  and  year(P.fechaVencimiento) = @anio
	GROUP BY EM.empresa_Cuit, EM.Empresa_Razon_Social, g.id,
	P.id, month(P.fechaVencimiento), year(P.fechaVencimiento)
	ORDER BY 'Localidades no vendidas' DESC

end
if(@trimestre='Segundo')
begin
SELECT
 TOP 5 
				 EM.empresa_Cuit  as 'ID de la Empresa', 
				 EM.Empresa_Razon_Social as 'Razon Social', 
				 COUNT(PU.publicacionId) AS 'Localidades no vendidas', 
				 g.id as 'Grado de Prioridad',
				 month(P.fechaVencimiento) as 'Mes',
				 year(P.fechaVencimiento) as 'Año'
	FROM dropeadores.Ubicacion PU  
	LEFT JOIN dropeadores.Compra c on (c.compra_ubicacionPublic =pu.publicacionId and c.compra_ubicacionAsiento=pu.asiento and c.compra_ubicacionFila=pu.fila)
	JOIN dropeadores.Publicacion P ON PU.publicacionId = P.id
	INNER JOIN dropeadores.Empresa EM ON empresa_Cuit =p.empresaId
	INNER JOIN dropeadores.Grado g on g.id = p.gradoId
	WHERE c.id IS NULL and g.id=@idGrado
	 and  month(P.fechaVencimiento)  between 3 and 6
	 and  year(P.fechaVencimiento) = @anio
	GROUP BY EM.empresa_Cuit, EM.Empresa_Razon_Social, g.id,
	P.id, month(P.fechaVencimiento), year(P.fechaVencimiento)
	ORDER BY 'Localidades no vendidas' DESC
end
if(@trimestre='Tercero')
begin
SELECT
 TOP 5 
				 EM.empresa_Cuit  as 'ID de la Empresa', 
				 EM.Empresa_Razon_Social as 'Razon Social', 
				 COUNT(PU.publicacionId) AS 'Localidades no vendidas', 
				 g.id as 'Grado de Prioridad',
				 month(P.fechaVencimiento) as 'Mes',
				 year(P.fechaVencimiento) as 'Año'
	FROM dropeadores.Ubicacion PU  
	LEFT JOIN dropeadores.Compra c on (c.compra_ubicacionPublic =pu.publicacionId and c.compra_ubicacionAsiento=pu.asiento and c.compra_ubicacionFila=pu.fila)
	JOIN dropeadores.Publicacion P ON PU.publicacionId = P.id
	INNER JOIN dropeadores.Empresa EM ON empresa_Cuit =p.empresaId
	INNER JOIN dropeadores.Grado g on g.id = p.gradoId
	WHERE c.id IS NULL and g.id=@idGrado
	 and month(P.fechaVencimiento)  between 6 and 9   and  year(P.fechaVencimiento) = @anio
	GROUP BY EM.empresa_Cuit, EM.Empresa_Razon_Social, g.id,
	P.id, month(P.fechaVencimiento), year(P.fechaVencimiento)
	ORDER BY 'Localidades no vendidas' DESC
end
if(@trimestre='Cuarto')
begin
SELECT
 TOP 5 
				 EM.empresa_Cuit  as 'ID de la Empresa', 
				 EM.Empresa_Razon_Social as 'Razon Social', 
				 COUNT(PU.publicacionId) AS 'Localidades no vendidas', 
				 g.id as 'Grado de Prioridad',
				 month(P.fechaVencimiento) as 'Mes',
				 year(P.fechaVencimiento) as 'Año'
	FROM dropeadores.Ubicacion PU  
	LEFT JOIN dropeadores.Compra c on (c.compra_ubicacionPublic =pu.publicacionId and c.compra_ubicacionAsiento=pu.asiento and c.compra_ubicacionFila=pu.fila)
	JOIN dropeadores.Publicacion P ON PU.publicacionId = P.id
	INNER JOIN dropeadores.Empresa EM ON empresa_Cuit =p.empresaId
	INNER JOIN dropeadores.Grado g on g.id = p.gradoId
	WHERE c.id IS NULL and g.id=@idGrado 
	and  month(P.fechaVencimiento)  between 9 and 12   and  year(P.fechaVencimiento) = @anio
	GROUP BY EM.empresa_Cuit, EM.Empresa_Razon_Social, g.id,
	P.id, month(P.fechaVencimiento), year(P.fechaVencimiento)
	ORDER BY 'Localidades no vendidas' DESC
end

end
GO
/**************FIN getLocalidadesNoVendidas*****************/



/**************INICIO getDescripcionCategoriaById*****************/
GO
create procedure [dropeadores].[getDescripcionCategoriaById] (@codigo int)
as
begin
select descripcion from dropeadores.TipoUbicacion where codigo=@codigo
end
GO
/**************FIN getDescripcionCategoriaById*****************/
GO
/****** Object:  StoredProcedure [dropeadores].[Domicilio_Cli_Alta]    Script Date: 07/12/2018 19:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dropeadores].[Cli_Alta] 
(@nombre nvarchar(255),@apellido nvarchar(255),@tipoDoc nvarchar(50),@dni numeric(18,0), @mail varchar(255),@fechaNacimiento datetime,@cuil varchar(255),@telefono numeric(10,0),@cliente_domicilio int,@fechaCreacion datetime)
as
begin
insert into  GD2C2018.[dropeadores].Cliente (numeroDocumento,nombre,apellido,tipoDocumento,cuil,mail,fechaNacimiento,cliente_domicilio,telefono,estado,fechaCreacion)
 values (@dni,@nombre,@apellido,@tipoDoc,@cuil, @mail,@fechaNacimiento,@cliente_domicilio,@telefono,1,@fechaCreacion)
end


--------------------

GO
/****** Object:  StoredProcedure [dropeadores].[DireCli_ObtenerId]    Script Date: 07/12/2018 19:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[DireCli_ObtenerId]
as
begin
	
	Select Max(id)as'Id'from dropeadores.Domicilio
end

------------------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[ObtenerClienteSinTarjeta]
	@tipoDoc nvarchar(50),
	@nroDoc numeric(18, 0)
AS
	--SI RECIBE -1, MUESTRA TODOS LOS Clientes
	IF (@nroDoc = 0)
		SELECT * FROM dropeadores.Cliente c join dropeadores.Domicilio D on(C.cliente_domicilio=D.id)									
	ELSE
		SELECT * FROM dropeadores.Cliente c join dropeadores.Domicilio D on(C.cliente_domicilio=D.id)	
		WHERE c.tipoDocumento = @tipoDoc and c.numeroDocumento= @nroDoc


----------------------------------

GO
Create procedure [dropeadores].[ExistTarjetaCliente]
@dni numeric(18, 0)
as
select count(T.Id)
from dropeadores.TarjetaCredito T 
join dropeadores.Cliente C on (C.NumeroDocumento=T.clieteId) 
where T.clieteId=@dni

--------------------------------------------


GO
/****** Object:  StoredProcedure [dropeadores].[Cli_Alta]    Script Date: 07/12/2018 19:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dropeadores].[Cli_Alta] 
(@nombre nvarchar(255),@apellido nvarchar(255),@tipoDoc nvarchar(50),@dni numeric(18,0), @mail varchar(255),@fechaNacimiento datetime,@cuil varchar(255),@telefono numeric(10,0),@cliente_domicilio int,@fechaCreacion datetime)
as
begin
insert into  GD2C2018.[dropeadores].Cliente (numeroDocumento,nombre,apellido,tipoDocumento,cuil,mail,fechaNacimiento,cliente_domicilio,telefono,estado,fechaCreacion)
 values (@dni,@nombre,@apellido,@tipoDoc,@cuil, @mail,@fechaNacimiento,@cliente_domicilio,@telefono,1,@fechaCreacion)
end


---------------

GO
/****** Object:  StoredProcedure [dropeadores].[Cli_ObtenerId]    Script Date: 07/12/2018 20:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Cli_ObtenerId]
		@idInsertado int
as
begin
	
	Select  e.numeroDocumento  as 'Id' from dropeadores.Cliente e 
	join dropeadores.Domicilio d on (d.id=e.cliente_domicilio)
	where d.id=@idInsertado
end


----------

USE [GD2C2018]
GO
/****** Object:  StoredProcedure [dropeadores].[Cliente_Alta_Tarjeta]    Script Date: 17/12/2018 1:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dropeadores].[Cliente_Alta_Tarjeta] (@propietario nvarchar(255), @numero numeric(28, 0),@fechaVencimiento datetime,@clienteId numeric(18, 0),@desc nvarchar(255))
as
begin
insert into dropeadores.TarjetaCredito(clieteId,propietario,numero,fechaVencimiento,descripcion)
values (@clienteId,@propietario,@numero,@fechaVencimiento,@desc)
end

---------------

USE [GD2C2018]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Usuario_Alta] (@idCliente int, @user nvarchar(255),@password nvarchar(255),@fechaCreacion datetime,@creadoPor nvarchar(255))
as
begin
insert into dropeadores.Usuario(username,password,clienteId,Fecha_Password,creadoPor)values
(@user,@password,@idCliente,@fechaCreacion,@creadoPor)
Select Max(id)as'Id'from [dropeadores].Usuario
end

-----------

GO
/****** Object:  StoredProcedure [dropeadores].[Domicilio_empresa_Alta]    Script Date: 07/12/2018 20:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Domicilio_empresa_Alta] (@calle nvarchar(255), @numero numeric(18,0),@piso numeric(18,0),@depto nvarchar(255),@localidad nvarchar(255),@cp nvarchar(255),@ciudad nvarchar(255))
as
begin
insert into [dropeadores].Domicilio(calle,numero,piso,departamento,localidad,codigoPostal,ciudad)
values (@calle,@numero,@piso,@depto,@localidad,@cp,@ciudad)
end
/*
*********************Busca el ID de tal empresa *********************
*/


------------------

GO
/****** Object:  StoredProcedure [dropeadores].[DireEmp_ObtenerId]    Script Date: 07/12/2018 20:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[DireEmp_ObtenerId]
as
begin
Select Max(id)as'Id'from [dropeadores].Domicilio
end


--------------


GO
/****** Object:  StoredProcedure [dropeadores].[Empresa_Alta]    Script Date: 07/12/2018 20:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Empresa_Alta] 
(@Cuit nvarchar(255), @mail varchar(255),@telefono numeric(10,0),@Razon_social varchar(255),@id_Domicilio int)
as
begin
insert into  GD2C2018.[dropeadores].Empresa (empresa_Cuit, empresa_mail,empresa_telefono,empresa_razon_social,empresa_domicilio,empresa_estado)
 values (@Cuit, @mail,@telefono,@Razon_social,@id_Domicilio,1)
end





---------------

GO
/****** Object:  StoredProcedure [dropeadores].[Emp_ObtenerId]    Script Date: 07/12/2018 20:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Emp_ObtenerId]
	@idInsertado int
as
begin
	
	Select e.empresa_Cuit as 'cuit' from dropeadores.Empresa e 
	join dropeadores.Domicilio d on (d.id=e.empresa_domicilio )
	where d.id=@idInsertado
end


--------------

GO
/****** Object:  StoredProcedure [dropeadores].[Usuario_Alta_Empresa]    Script Date: 07/12/2018 20:02:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Usuario_Alta_Empresa] (@CuitEmpresa nvarchar(255), @user nvarchar(255),@fecha datetime,@password nvarchar(255),@creadoPor nvarchar(255))
as
begin
insert into dropeadores.Usuario(username,password,Fecha_Password,CuitEmpresa,creadoPor)
values (@user,@password,@fecha,@CuitEmpresa,@creadoPor)
Select Max(id)as'idUsuario'from [dropeadores].Usuario
end




------------
Go
CREATE procedure [dropeadores].[ExistCuitandRazonSocial]
@cuit nvarchar(255),
@razonSocial nvarchar(255)
as
select count(e.empresa_Cuit)
from dropeadores.Empresa e where e.empresa_Cuit LIKE @cuit or e.empresa_razon_social LIKE @razonSocial


--------------

GO
/****** Object:  StoredProcedure [dropeadores].[deleteEmpresa]    Script Date: 07/12/2018 20:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[deleteEmpresa]
	@cuitEmpresa nvarchar(255)	
AS
	UPDATE dropeadores.Empresa
	SET empresa_estado = 0
	WHERE empresa_Cuit = @cuitEmpresa
------------------

GO
/****** Object:  StoredProcedure [dropeadores].[getEmpresa]    Script Date: 07/12/2018 20:05:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dropeadores].[getEmpresa]
	
AS
		SELECT empresa_Cuit as 'CUIT', empresa_razon_social as 'RAZONSOCIAL', empresa_mail as 'MAIL',empresa_estado FROM dropeadores.Empresa E	
		

------------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateTarjetaCliente]    Script Date: 10/12/2018 23:56:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateTarjetaCliente]
			@idCliente numeric(18, 0),
			@propietario nvarchar(255),
            @numero varchar(19),
            @fechaVencimiento datetime
AS
	BEGIN
		IF(@propietario != '')
			UPDATE dropeadores.TarjetaCredito
				SET propietario=UPPER(@propietario)
				where clieteId= @idCliente
					
		IF(@numero != -1)
			UPDATE dropeadores.TarjetaCredito
				SET numero = UPPER(@numero)
				where clieteId= @idCliente

		IF(@fechaVencimiento IS NOT NULL)
			UPDATE dropeadores.TarjetaCredito
				SET fechaVencimiento = @fechaVencimiento
				where clieteId= @idCliente
	END


----------------------------


GO
/****** Object:  StoredProcedure [dropeadores].[deleteCliente]    Script Date: 07/12/2018 20:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[deleteCliente]
	@tipoDoc nvarchar(255),	
	@nroDoc numeric(18, 0)
AS
	UPDATE dropeadores.Cliente
	SET estado = 0
	WHERE numeroDocumento = @nroDoc AND tipoDocumento=@tipoDoc


---------------

GO
/****** Object:  StoredProcedure [dropeadores].[deleteGrado]    Script Date: 07/12/2018 20:05:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[deleteGrado]
	@id int
AS
	UPDATE dropeadores.Grado
	SET estado = 0
	WHERE id = @id

    ----------------------

GO
/****** Object:  StoredProcedure [dropeadores].[ExistCliente]    Script Date: 07/12/2018 20:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[ExistCliente]
@cuil nvarchar(255),
@dni numeric(18, 0)
as
select count(c.numeroDocumento)
from dropeadores.Cliente c where c.estado=1 and ( c.cuil LIKE @cuil or c.numeroDocumento= @dni)


-----
GO
/****** Object:  StoredProcedure [dropeadores].[ExistEmpresa]    Script Date: 07/12/2018 20:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[ExistEmpresa]
@cuit nvarchar(255),
@razonSocial nvarchar(255)
as
select count(e.empresa_Cuit)
from dropeadores.Empresa e where e.empresa_estado=1 and ( e.empresa_Cuit LIKE @cuit or e.empresa_razon_social LIKE @razonSocial)


----------------
USE [GD2C2018]
GO
/****** Object:  StoredProcedure [dropeadores].[getCliente]    Script Date: 17/12/2018 1:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dropeadores].[getCliente]
AS
begin
		SELECT nombre as 'nombre',apellido as 'apellido',tipoDocumento as 'tipoDocumento',numeroDocumento as 'numeroDocumento',mail as 'mail',estado as 'ESTADO' FROM dropeadores.Cliente c
END
-----------------
GO
/****** Object:  StoredProcedure [dropeadores].[getClienteEspecifico]    Script Date: 07/12/2018 20:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[getClienteEspecifico]
	@tipoDocu varchar(50),
	@numDocu numeric(18)	
AS
	SELECT *
	FROM dropeadores.cliente C
	JOIN dropeadores.Domicilio D ON (C.cliente_domicilio=D.id)
	JOIN dropeadores.TarjetaCredito T ON(C.numeroDocumento=T.clieteId)
	WHERE tipoDocumento = @tipoDocu AND numeroDocumento= @numDocu



-------------------
USE [GD2C2018]
GO
/****** Object:  StoredProcedure [dropeadores].[insertPuntos]    Script Date: 17/12/2018 2:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dropeadores].[insertPuntos] 
(@puntos int,@Id_Compra int,@Id_Cliente numeric(18, 0),@FechaVencimiento datetime)
as
begin
insert into  GD2C2018.[dropeadores].Puntos(puntos,Id_Compra,Id_Cliente,FechaVencimiento)
 values (@puntos,@Id_Compra,@Id_Cliente,DATEADD(DAY,5,@FechaVencimiento))
end
-----------------

GO
/****** Object:  StoredProcedure [dropeadores].[getGrado]    Script Date: 07/12/2018 20:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[getGrado]
	@tipo varchar(255)
AS
	--SI RECIBE VACIO"", MUESTRA TODOS LOS GRADOS
	IF (@tipo = '')
		select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO'  FROM dropeadores.Grado G
		where estado =1			
	ELSE
		select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO'  FROM dropeadores.Grado G	
		WHERE G.tipo = @tipo and estado = 1


-----------------------

GO
/****** Object:  StoredProcedure [dropeadores].[getGradoSeleccionado]    Script Date: 07/12/2018 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[getGradoSeleccionado]
	@tipo varchar(255)
AS
	--SI RECIBE VACIO"", MUESTRA TODOS LOS GRADOS
	IF (@tipo = '')
		select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO'  FROM dropeadores.Grado G
				
	ELSE
		select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO'  FROM dropeadores.Grado G	
		WHERE G.tipo = @tipo 


------------------------

GO
/****** Object:  StoredProcedure [dropeadores].[Grado_Alta]    Script Date: 07/12/2018 20:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dropeadores].[Grado_Alta] 
(@tipo varchar(255),@porcentaje numeric(10, 2))
as
begin
insert into  GD2C2018.[dropeadores].Grado(tipo,porcentaje)
 values (@tipo,@porcentaje)
end
---------------------

GO
/****** Object:  StoredProcedure [dropeadores].[insertCompra]    Script Date: 16/12/2018 15:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[insertCompra]
            @tipoDoc varchar(5),
			@nroDoc numeric(18, 0),
            @fecha datetime,
			@tarjetaID int,
			@cant numeric(18, 0),
			@precio int,
			@fila varchar(3),
			@asiento numeric(18, 0),
			@publicID int
AS
BEGIN
INSERT INTO dropeadores.Compra (compra_tipo_documento,compra_numero_documento,compra_fecha,compra_TarjetaId,compra_cantidad,compra_precio,compra_ubicacionFila,compra_ubicacionAsiento,compra_ubicacionPublic) 
VALUES (@tipoDoc,@nroDoc, @fecha,@tarjetaID,@cant,@precio,@fila,@asiento,@publicID)
END



------------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updatePuntos]    Script Date: 15/12/2018 16:21:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dropeadores].[updatePuntos] 
(@Id_Cliente numeric(18, 0))
as
begin
 

UPDATE  GD2C2018.[dropeadores].Puntos  SET PuntosVigentes = (select SUM(Puntos) from dropeadores.Puntos p2 where p2.Id_Cliente=@Id_Cliente)
WHERE id_Cliente=@Id_Cliente

end



-----------------------

GO
/****** Object:  StoredProcedure [dropeadores].[obtenerIDcompra]    Script Date: 16/12/2018 15:56:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[obtenerIDcompra]
		AS
     	SELECT MAX(id) AS 'Id' FROM dropeadores.Compra 

-----------------------
GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerClienteEspecifico]    Script Date: 11/12/2018 23:06:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[ObtenerClienteEspecifico]
	@tipoDoc nvarchar(50),
	@nroDoc numeric(18, 0)
AS

	IF ((select count(T.Id)
		from dropeadores.TarjetaCredito T 
		join dropeadores.Cliente C on (C.NumeroDocumento=T.clieteId) 
		where T.clieteId=@nroDoc) = 0)
		SELECT * FROM dropeadores.Cliente c join dropeadores.Domicilio D on(C.cliente_domicilio=D.id)	
			where c.numeroDocumento= @nroDoc
	ELSE
		SELECT * FROM dropeadores.Cliente c join dropeadores.Domicilio D on(C.cliente_domicilio=D.id)	
											join dropeadores.TarjetaCredito T on (T.clieteId=C.numeroDocumento)		
		WHERE c.tipoDocumento = @tipoDoc and c.numeroDocumento= @nroDoc
-----------------------------

GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerDireccionEmpresaEspecifica]    Script Date: 07/12/2018 20:09:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[ObtenerDireccionEmpresaEspecifica]
	@cuit nvarchar(255)
AS
	
		SELECT empresa_domicilio FROM dropeadores.Empresa
		WHERE empresa_Cuit like @cuit

-----------------

GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerEmpresaEspecifica]    Script Date: 07/12/2018 20:09:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[ObtenerEmpresaEspecifica]
	@cuit nvarchar(255)
AS
	--SI RECIBE -1, MUESTRA TODOS LOS HUESPEDES
	IF (@cuit = '00-00000000-00')
		SELECT * FROM dropeadores.Empresa E join dropeadores.Domicilio D on(E.empresa_domicilio=d.id)			
	ELSE
		SELECT * FROM dropeadores.Empresa E	join dropeadores.Domicilio D on(E.empresa_domicilio=d.id)
		WHERE E.empresa_Cuit = @cuit

----------------

GO
/****** Object:  StoredProcedure [dropeadores].[ObtenerGradoEspecifico]    Script Date: 07/12/2018 20:10:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[ObtenerGradoEspecifico]
	@id int
AS
	select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO'  FROM dropeadores.Grado G
	where g.id=@id
				


---------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateCliente]    Script Date: 07/12/2018 20:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateCliente]
            @nroDoc numeric(18, 0),
            @nombre nvarchar(255),
			@apellido nvarchar(255),
			@tipoDoc nvarchar(50),
			@cuil nvarchar(255),
			@mail nvarchar(255),
			@fechaNacimiento datetime,
			@clienteDom int,
            @telefono int,
            @campoBaja bit
AS
	BEGIN
		IF(@nombre  != '')
			UPDATE dropeadores.Cliente
				SET nombre = UPPER(@nombre)
					WHERE numeroDocumento = @nroDoc
		IF(@apellido  != '')
			UPDATE dropeadores.Cliente
				SET apellido = UPPER(@apellido)
					WHERE numeroDocumento = @nroDoc
		IF(@tipoDoc  != '')
			UPDATE dropeadores.Cliente
				SET tipoDocumento = @tipoDoc
					WHERE numeroDocumento = @nroDoc
		IF(@cuil  != '')
			UPDATE dropeadores.Cliente
				SET cuil = UPPER(@cuil)
					WHERE numeroDocumento = @nroDoc
		IF(@mail  != '')
			UPDATE dropeadores.Cliente
				SET mail = LOWER(@mail)
					WHERE numeroDocumento = @nroDoc

		IF(@fechaNacimiento IS NOT NULL)
			UPDATE dropeadores.Cliente
				SET fechaNacimiento = @fechaNacimiento
					WHERE numeroDocumento = @nroDoc
		IF(@clienteDom != -1)
			UPDATE dropeadores.Cliente
				SET cliente_domicilio = @clienteDom
					WHERE numeroDocumento = @nroDoc
		IF(@telefono != -1)
			UPDATE dropeadores.Cliente
				SET telefono = @telefono
					WHERE numeroDocumento = @nroDoc
		IF(@campoBaja IS NOT NULL)
			UPDATE dropeadores.Cliente
				SET estado = @campoBaja
					WHERE numeroDocumento = @nroDoc
	
	END

-----------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateDomicilioCliente]    Script Date: 07/12/2018 20:10:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateDomicilioCliente]
			@idCliente int,
			@calle nvarchar(50),
            @numero numeric(18, 0),
            @piso numeric(18, 0),
            @depto nvarchar(50),
            @localidad nvarchar(50),
            @ciudad nvarchar(50),
            @cp nvarchar(50)

AS
	BEGIN
		IF(@calle != '')
			UPDATE dropeadores.Domicilio
				SET calle = upper(@calle)
				where id = @idCliente
					
		IF(@numero != -1)
			UPDATE dropeadores.Domicilio
				SET numero = @numero
				where id = @idCliente

		IF(@cp != '')
			UPDATE dropeadores.Domicilio
				SET codigoPostal = UPPER(@cp)
				where id = @idCliente

		IF(@piso != -1)
			UPDATE dropeadores.Domicilio
				SET piso = @piso
				where id = @idCliente
	
		IF(@depto != '')
			UPDATE dropeadores.Domicilio
				SET departamento = UPPER(@depto)
				where id = @idCliente
	
		IF(@localidad != '')
			UPDATE dropeadores.Domicilio
				SET localidad = UPPER(@localidad)
				where id = @idCliente

		IF(@ciudad != '')
			UPDATE dropeadores.Domicilio
				SET ciudad = UPPER(@ciudad)
				where id = @idCliente
	
	END

    ---------------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateDomicilioEmpresa]    Script Date: 07/12/2018 20:10:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateDomicilioEmpresa]
			@idDomicilio int,
			@calle nvarchar(50),
            @numero numeric(18, 0),
            @piso numeric(18, 0),
            @depto nvarchar(50),
            @localidad nvarchar(50),
            @ciudad nvarchar(50),
            @cp nvarchar(50)

AS
	BEGIN
		IF(@calle != '')
			UPDATE dropeadores.Domicilio
				SET Calle = upper(@calle)
				where id = @idDomicilio
					
		IF(@numero != -1)
			UPDATE dropeadores.Domicilio
				SET numero = @numero
				where id = @idDomicilio

		IF(@cp != '')
			UPDATE dropeadores.Domicilio
				SET codigoPostal = UPPER(@cp)
				where id = @idDomicilio

		IF(@piso != -1)
			UPDATE dropeadores.Domicilio
				SET piso = @piso
				where id = @idDomicilio
	
		IF(@depto != '')
			UPDATE dropeadores.Domicilio
				SET departamento = UPPER(@depto)
				where id = @idDomicilio
	
		IF(@localidad != '')
			UPDATE dropeadores.Domicilio
				SET localidad = UPPER(@localidad)
				where id = @idDomicilio

		IF(@ciudad != '')
			UPDATE dropeadores.Domicilio
				SET ciudad = UPPER(@ciudad)
				where id = @idDomicilio
	END
--------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateEmpresa]    Script Date: 07/12/2018 20:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateEmpresa]
            @cuit varchar(255),
            @razonSocial nvarchar(255),
			@email nvarchar(255),
            @telefono numeric(10, 0),
            @campoBaja bit
AS
	BEGIN
		IF(@cuit  != '')
			UPDATE dropeadores.Empresa
				SET empresa_Cuit = UPPER(@cuit)
					WHERE empresa_Cuit = @cuit
		IF(@razonSocial != '')
			UPDATE dropeadores.Empresa
				SET empresa_razon_social = UPPER(@razonSocial)   	
					WHERE empresa_Cuit = @cuit
		IF(@email != '')
			UPDATE dropeadores.Empresa
				SET empresa_mail = LOWER(@email)
					WHERE empresa_Cuit = @cuit
		IF(@telefono != -1)
			UPDATE dropeadores.Empresa
				SET empresa_telefono = @telefono
					WHERE empresa_Cuit = @cuit
		IF(@campoBaja IS NOT NULL)
			UPDATE dropeadores.Empresa
				SET empresa_estado = @campoBaja
					WHERE empresa_Cuit = @cuit
	
	END
------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateGrado]    Script Date: 07/12/2018 20:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateGrado]
			@id int,
			@tipo varchar(255),
			@porc numeric(10, 2),
            @estado bit
AS
	BEGIN
			UPDATE dropeadores.Grado
				SET tipo = LOWER(@tipo) , porcentaje = @porc , estado = @estado
				where id = @id
	
	END


--------------------------
GO 
CREATE PROCEDURE [dropeadores].[getTablaPublicacion]
	 @fechaSistema datetime
	 
AS
	BEGIN
	 
 		select p.id as 'CODIGO', p.descripcion as 'DESCRIPCION', p.fechaEspectaculo, p.direccion as 'DIRECCION', u.fila as 'FILA', u.asiento as 'ASIENTO',rubro_Descripcion as 'RUBRO_DESCRIPCION',u.precio as 'PRECIO' FROM dropeadores.Publicacion p 
		join dropeadores.Ubicacion u on (u.publicacionId = p.id)
		join dropeadores.TipoUbicacion ti on (ti.codigo=u.tipoUbicacion)
		join dropeadores.Grado g on(g.id=p.gradoId)
		join dropeadores.Rubro r on (r.id=p.rubroId)
		where p.fechaPublicacion >= @fechaSistema and u.estado=1 and p.estado=1 and fechaEspectaculo > @fechaSistema
		order by g.porcentaje desc

	END
GO
CREATE PROCEDURE [dropeadores].[getPublicacion]
	 @fechaSistema datetime,
	 @fechaDesde datetime,
	 @fechaHasta datetime
AS
	BEGIN
	 
 		SELECT p.id as 'CODIGO', p.descripcion as 'DESCRIPCION', p.fechaEspectaculo, p.direccion as 'DIRECCION', u.fila as 'FILA', u.asiento as 'ASIENTO',rubro_Descripcion as 'RUBRO_DESCRIPCION'  FROM dropeadores.Publicacion p 
		join dropeadores.Ubicacion u on (u.publicacionId = p.id)
		join dropeadores.Grado g on(g.id=p.gradoId)
		join dropeadores.Rubro r on (r.id=p.rubroId)
		where p.fechaPublicacion >=@fechaSistema and year(fechaPublicacion) between year(@fechaDesde) and year(@fechaHasta)
		and MONTH(fechaPublicacion) between month(@fechaDesde) and month(@fechaHasta)
		and DAY(fechaPublicacion) between day(@fechaDesde) and day(@fechaHasta)
		order by g.porcentaje desc
	END
GO
CREATE PROCEDURE [dropeadores].[asociarTarjetaCliente]
			@idCliente numeric(18, 0),
			@propietario varchar(19),
            @numero nvarchar(50),
            @fechaVencimiento datetime,
			@desc nvarchar(255)
AS
	BEGIN
		IF(@propietario != '')
			UPDATE dropeadores.TarjetaCredito
				SET propietario=UPPER(@propietario)
				where clieteId= @idCliente
					
		IF(@numero != ' ')
			UPDATE dropeadores.TarjetaCredito
				SET numero = @numero
				where clieteId= @idCliente

		IF(@fechaVencimiento IS NOT NULL)
			UPDATE dropeadores.TarjetaCredito
				SET fechaVencimiento = @fechaVencimiento
				where clieteId= @idCliente
		IF (@desc!='')
			UPDATE dropeadores.TarjetaCredito
				SET descripcion=@desc
				where clieteId= @idCliente
	END


--------------------------

GO
/****** Object:  StoredProcedure [dropeadores].[updateUbicacion]    Script Date: 16/12/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dropeadores].[updateUbicacion]
            @fila varchar(3),
            @asiento numeric(18, 0),
			@publicID int	
AS
	BEGIN
	
			UPDATE dropeadores.Ubicacion
				SET estado = 0
					WHERE fila LIKE @fila and asiento = @asiento and publicacionId = @publicID
		
	END

-----------------------------------------------------------------------------------------------------
										/* FIN DE CREACION DE PROCEDURES */
-----------------------------------------------------------------------------------------------------