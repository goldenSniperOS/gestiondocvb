-- =============================================
-- Author:		<Author,Grupo2>
-- Create date: <Create Date,07-10-2016>
-- Description:	<Description,Papeletas por Mes>
-- =============================================

USE BDGestionDocumentaria
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnGastosMovilidadXAreaXPeriodo')
	BEGIN
		drop function fnGastosMovilidadXAreaXPeriodo
	END
go

CREATE FUNCTION fnGastosMovilidadXAreaXPeriodo (@area VARCHAR(10),@diaInicio DATE,@diaFin DATE)
RETURNS TABLE 
AS
RETURN 
(
	SELECT        dbo.tbarea.are_Nombre, dbo.tbpersona.per_Nombres, dbo.tbpersona.per_Apellidos, dbo.tbpersona.per_DNI, dbo.tbdocumento_gastomovilidad.Gas_Subtotal, dbo.tbdocumento_gastomovilidad.Gas_Motivo, 
                  dbo.tbdocumento_gastomovilidad.Gas_Fecha, dbo.tbdocumento_gastomovilidad.Gas_Ruta, dbo.tbdocumento.doc_Fecha, dbo.tbusuario.usu_Nombre,TotalVentas =SUM(dbo.tbdocumento_gastomovilidad.Gas_Subtotal)

	FROM            dbo.tbdocumento INNER JOIN
								dbo.tbdocumento_gastomovilidad ON dbo.tbdocumento.doc_Codigo = dbo.tbdocumento_gastomovilidad.Gas_doc_Cod INNER JOIN
								dbo.tbusuario ON dbo.tbdocumento.doc_usu_Codigo = dbo.tbusuario.usu_Codigo INNER JOIN
								dbo.tbarea INNER JOIN
								dbo.tbpersona_area ON dbo.tbarea.are_Codigo = dbo.tbpersona_area.par_are_Codigo INNER JOIN
								dbo.tbpersona ON dbo.tbpersona_area.par_per_Codigo = dbo.tbpersona.per_Codigo ON dbo.tbusuario.usu_per_Codigo = dbo.tbpersona.per_Codigo
	WHERE CONVERT(DATE,dbo.tbdocumento.doc_Fecha) >@diaInicio AND CONVERT(DATE,dbo.tbdocumento.doc_Fecha) < @diaFin AND dbo.tbarea.are_Codigo = @area
	GROUP BY dbo.tbarea.are_Nombre, dbo.tbpersona.per_Nombres, dbo.tbpersona.per_Apellidos, dbo.tbpersona.per_DNI, dbo.tbdocumento_gastomovilidad.Gas_Subtotal, dbo.tbdocumento_gastomovilidad.Gas_Motivo, 
                  dbo.tbdocumento_gastomovilidad.Gas_Fecha, dbo.tbdocumento_gastomovilidad.Gas_Ruta, dbo.tbdocumento.doc_Fecha, dbo.tbusuario.usu_Nombre
)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnGastosMovilidadXPeriodo')
	BEGIN
		drop function fnGastosMovilidadXPeriodo
	END
go

CREATE FUNCTION fnGastosMovilidadXPeriodo (@diaInicio DATE,@diaFin DATE)
RETURNS TABLE 
AS
RETURN 
(
	SELECT        Area = ISNULL(tbarea.are_Nombre,'TOTAL'),Total = SUM(dbo.tbdocumento_gastomovilidad.Gas_Subtotal)
	FROM            dbo.tbpersona_area INNER JOIN
                         dbo.tbarea ON dbo.tbpersona_area.par_are_Codigo = dbo.tbarea.are_Codigo INNER JOIN
                         dbo.tbpersona ON dbo.tbpersona_area.par_per_Codigo = dbo.tbpersona.per_Codigo INNER JOIN
                         dbo.tbdocumento_gastomovilidad INNER JOIN
                         dbo.tbdocumento ON dbo.tbdocumento_gastomovilidad.Gas_doc_Cod = dbo.tbdocumento.doc_Codigo INNER JOIN
                         dbo.tbusuario ON dbo.tbdocumento.doc_usu_Codigo = dbo.tbusuario.usu_Codigo ON dbo.tbpersona.per_Codigo = dbo.tbusuario.usu_per_Codigo
	WHERE CONVERT(DATE,dbo.tbdocumento.doc_Fecha) >@diaInicio AND CONVERT(DATE,dbo.tbdocumento.doc_Fecha) < @diaFin AND dbo.tbdocumento_gastomovilidad.Gas_Subtotal IS NOT NULL 
	GROUP BY ROLLUP(dbo.tbarea.are_Nombre)
)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnNotasContablesXFilialXMesXAnio')
	BEGIN
		drop function fnNotasContablesXFilialXMesXAnio
	END
go

CREATE FUNCTION fnNotasContablesXFilialXMesXAnio(@anio int)
RETURNS TABLE 
AS
RETURN 
(
select  FILIAL = isnull(tbdocumento_notadecontabilidad.Ndcon_Filialdos, 'TOTAL'),
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 1 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Enero,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 2 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Febrero,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 3 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Marzo,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 4 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Abril,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 5 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Mayo,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 6 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Junnio,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 7 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Julio,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 8 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Agosto,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 9 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Septiembre,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 10 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Octubre,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 11 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Noviembre,
		isnull(SUM(case when month(tbdocumento_notadecontabilidad.Ndcon_Fecha) = 12 then tbdocumento_notadecontabilidad.Ndcon_Subtotal end), 0) Diciembre,
		total = SUM( dbo.tbdocumento_notadecontabilidad.Ndcon_Subtotal )
FROM            dbo.tbdocumento_notadecontabilidad
where datepart(YYYY,dbo.tbdocumento_notadecontabilidad.Ndcon_Fecha) = @anio and tbdocumento_notadecontabilidad.Ndcon_Denegar = 'NO'
GROUP BY ROLLUP(dbo.tbdocumento_notadecontabilidad.Ndcon_Filialdos)
)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnNotasXFilialesXPeriodo')
	BEGIN
		drop function fnNotasXFilialesXPeriodo
	END
go

CREATE FUNCTION fnNotasXFilialesXPeriodo (@diaInicio DATE,@diaFin DATE)
RETURNS TABLE 
AS
RETURN 
(
	SELECT        dbo.tbpersona.per_Nombres, dbo.tbpersona.per_Apellidos, dbo.tbpersona.per_DNI, dbo.tbusuario.usu_Nombre, dbo.tbdocumento.doc_Codigo, dbo.tbdocumento.doc_Fecha, 
                         dbo.tbdocumento_notadecontabilidad.Ndcon_Motivo, dbo.tbdocumento_notadecontabilidad.Ndcon_Subtotal, dbo.tbdocumento_notadecontabilidad.Ndcon_Filialuno, 
                         dbo.tbdocumento_notadecontabilidad.Ndcon_Filialdos
	FROM            dbo.tbdocumento_notadecontabilidad INNER JOIN
                         dbo.tbdocumento ON dbo.tbdocumento_notadecontabilidad.Ndcon_doc_Cod = dbo.tbdocumento.doc_Codigo INNER JOIN
                         dbo.tbusuario ON dbo.tbdocumento.doc_usu_Codigo = dbo.tbusuario.usu_Codigo INNER JOIN
                         dbo.tbpersona ON dbo.tbusuario.usu_per_Codigo = dbo.tbpersona.per_Codigo
	WHERE CONVERT(DATE,dbo.tbdocumento.doc_Fecha) >@diaInicio AND CONVERT(DATE,dbo.tbdocumento.doc_Fecha) < @diaFin AND dbo.tbdocumento_notadecontabilidad.Ndcon_Filialdos IS NOT NULL
)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnPapeletasXAreaXMesXAnio')
	BEGIN
		drop function fnPapeletasXAreaXMesXAnio
	END
go

CREATE FUNCTION fnPapeletasXAreaXMesXAnio(@anio int)
RETURNS TABLE 
AS
RETURN 
(
select  Area = ISNULL(tbarea.are_Nombre, 'TOTAL'),
		Enero = isnull(count(case when month(tbdocumento.doc_Fecha) = 1 then tbdocumento_papeleta.Pape_Codigo end), 0),
		isnull(count(case when month(tbdocumento.doc_Fecha) = 2 then tbdocumento_papeleta.Pape_Codigo end), 0) Febrero,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 3 then tbdocumento_papeleta.Pape_Codigo end), 0) Marzo,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 4 then tbdocumento_papeleta.Pape_Codigo end), 0) Abril,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 5 then tbdocumento_papeleta.Pape_Codigo end), 0) Mayo,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 6 then tbdocumento_papeleta.Pape_Codigo end), 0) Junnio,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 7 then tbdocumento_papeleta.Pape_Codigo end), 0) Julio,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 8 then tbdocumento_papeleta.Pape_Codigo end), 0) Agosto,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 9 then tbdocumento_papeleta.Pape_Codigo end), 0) Septiembre,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 10 then tbdocumento_papeleta.Pape_Codigo end), 0) Octubre,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 11 then tbdocumento_papeleta.Pape_Codigo end), 0) Noviembre,
		isnull(count(case when month(tbdocumento.doc_Fecha) = 12 then tbdocumento_papeleta.Pape_Codigo end), 0) Diciembre,
		total = count( dbo.tbdocumento_papeleta.Pape_Codigo )
FROM            dbo.tbdocumento INNER JOIN
                         dbo.tbdocumento_papeleta ON dbo.tbdocumento.doc_Codigo = dbo.tbdocumento_papeleta.Pape_doc_Cod INNER JOIN
                         dbo.tbusuario ON dbo.tbdocumento.doc_usu_Codigo = dbo.tbusuario.usu_Codigo INNER JOIN
                         dbo.tbpersona ON dbo.tbusuario.usu_per_Codigo = dbo.tbpersona.per_Codigo INNER JOIN
						 dbo.tbpersona_area ON dbo.tbpersona.per_Codigo = dbo.tbpersona_area.par_per_Codigo INNER JOIN
						 dbo.tbarea ON dbo.tbpersona_area.par_are_Codigo = dbo.tbarea.are_Codigo
where datepart(YYYY,dbo.tbdocumento.doc_Fecha) = @anio
GROUP BY ROLLUP(dbo.tbarea.are_Nombre)
)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnPapeletasXMes')
	BEGIN
		drop function fnPapeletasXMes
	END
go

CREATE FUNCTION fnPapeletasXMes (@mes INT,@anio INT)
RETURNS TABLE 
AS
RETURN 
(
	SELECT        dbo.tbdocumento_papeleta.Pape_Codigo, dbo.tbdocumento.doc_Codigo, dbo.tbdocumento_papeleta.Pape_Fecha, dbo.tbdocumento_papeleta.Pape_HoraSalida, dbo.tbdocumento_papeleta.Pape_Retorno, 
                         dbo.tbdocumento_papeleta.Pape_HoraEntrada, dbo.tbdocumento_papeleta.Pape_ApruebaPapeRRHH, dbo.tbdocumento_papeleta.Pape_Observacion, dbo.tbdocumento_papeleta.Pape_Lugar, 
                         dbo.tbdocumento_papeleta.Pape_Justificacion, dbo.tbdocumento_papeleta.Pape_Motivo, dbo.tbpersona.per_DNI, dbo.tbpersona.per_Nombres, dbo.tbpersona.per_Apellidos
	FROM            dbo.tbdocumento INNER JOIN
                         dbo.tbdocumento_papeleta ON dbo.tbdocumento.doc_Codigo = dbo.tbdocumento_papeleta.Pape_doc_Cod INNER JOIN
                         dbo.tbusuario ON dbo.tbdocumento.doc_usu_Codigo = dbo.tbusuario.usu_Codigo INNER JOIN
                         dbo.tbpersona ON dbo.tbusuario.usu_per_Codigo = dbo.tbpersona.per_Codigo
	WHERE datepart(mm,dbo.tbdocumento.doc_Fecha) = @mes AND datepart(YYYY,dbo.tbdocumento.doc_Fecha) = @anio
)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnVacacionesXArea')
	BEGIN
		drop function fnVacacionesXArea
	END
go

CREATE FUNCTION fnVacacionesXArea (@area VARCHAR(10),@diaInicio DATE,@diaFin DATE)
RETURNS TABLE 
AS
RETURN 
(
	SELECT        dbo.tbarea.are_Nombre, dbo.tbdocumento.doc_Fecha, dbo.tbdocumento.doc_Codigo, dbo.tbpersona.per_Nombres, dbo.tbpersona.per_Apellidos, dbo.tbpersona.per_DNI, 
							 dbo.tbdocumento_vacaciones.Vaca_FechaSalida, dbo.tbdocumento_vacaciones.Vaca_FechaTermino, dbo.tbdocumento_vacaciones.Vaca_Pape_ApruebaJefe, 
							 dbo.tbdocumento_vacaciones.Vaca_Pape_ApruebaRRHH, dbo.tbdocumento_vacaciones.Vaca_Observacion, dbo.tbdocumento_vacaciones.Vaca_Dias, dbo.tbdocumento_vacaciones.Vaca_FechaRetorno, 
							 dbo.tbusuario.usu_Nombre
	FROM            dbo.tbarea INNER JOIN
								 dbo.tbpersona_area ON dbo.tbarea.are_Codigo = dbo.tbpersona_area.par_are_Codigo INNER JOIN
								 dbo.tbdocumento INNER JOIN
								 dbo.tbusuario ON dbo.tbdocumento.doc_usu_Codigo = dbo.tbusuario.usu_Codigo INNER JOIN
								 dbo.tbpersona ON dbo.tbusuario.usu_per_Codigo = dbo.tbpersona.per_Codigo ON dbo.tbpersona_area.par_per_Codigo = dbo.tbpersona.per_Codigo INNER JOIN
								 dbo.tbdocumento_vacaciones ON dbo.tbdocumento.doc_Codigo = dbo.tbdocumento_vacaciones.Vaca_doc_Cod
	WHERE CONVERT(DATE,dbo.tbdocumento.doc_Fecha) >@diaInicio AND CONVERT(DATE,dbo.tbdocumento.doc_Fecha) < @diaFin AND dbo.tbarea.are_Codigo = @area
)
GO