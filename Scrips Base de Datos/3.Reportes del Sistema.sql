-- =============================================
-- Author:		<Author,Grupo2>
-- Create date: <Create Date,07-10-2016>
-- Description:	<Description,Funciones>
-- =============================================

USE BDGestionDocumentaria
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnGastosMovilidadXAreaXPeriodo')
	BEGIN
		drop function fnGastosMovilidadXAreaXPeriodo
	END
go

CREATE FUNCTION [dbo].[fnGastosMovilidadXAreaXPeriodo] (@area VARCHAR(10),@diaInicio DATE,@diaFin DATE)
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

CREATE FUNCTION [dbo].[fnGastosMovilidadXPeriodo] (@diaInicio DATE,@diaFin DATE)
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


IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnPapeletasXAreaXMesXAnio')
	BEGIN
		drop function fnPapeletasXAreaXMesXAnio
	END
go

CREATE FUNCTION [dbo].[fnPapeletasXAreaXMesXAnio](@anio int)
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

CREATE FUNCTION [dbo].[fnPapeletasXMes] (@mes INT,@anio INT)
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

CREATE FUNCTION [dbo].[fnVacacionesXArea] (@area VARCHAR(10),@diaInicio DATE,@diaFin DATE)
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

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fnSplitString')
	BEGIN
		drop function fnSplitString
	END
go

CREATE FUNCTION [dbo].[fnSplitString] 
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX) 
) 
BEGIN 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (splitdata)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        
    END 
    RETURN 
END
Go

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevaSerie')
	BEGIN
		drop function nuevaSerie
	END
go

CREATE FUNCTION [dbo].[nuevaSerie]()
RETURNS VARCHAR(10)
BEGIN
	DECLARE @lastCode VARCHAR(10)
	DECLARE @lastNumber VARCHAR(10)

	SELECT TOP 1 @lastCode = doc_Gas_SerieCod  FROM tbdocumento 
	WHERE doc_Titulo = 'DTI0000006'
	ORDER BY doc_Codigo DESC

	SELECT TOP 1 @lastNumber = splitdata FROM(SELECT ROW_NUMBER() OVER (ORDER BY splitdata ASC) AS rownumber,* 
	FROM fnSplitString(@lastCode, '-')) AS foo 
	WHERE rownumber = 2

	RETURN '006-'+REPLACE(STR(CONVERT(INT,@lastNumber)+1, 5), SPACE(1), '0')
END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoCodigo')
	BEGIN
		drop function nuevoCodigo
	END
go

CREATE FUNCTION [dbo].[nuevoCodigo](@tableName VARCHAR(20))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @tablePrefix CHAR(3)
	DECLARE @query nvarchar(max)
	DECLARE @lastCode VARCHAR(10)

	SET @tablePrefix = SUBSTRING(@tableName,3,3)
	SET @query = 'SELECT TOP 1 @lastCode='+@tablePrefix+'_Codigo FROM [' + @tablename + '] ORDER BY '+@tablePrefix+'_Codigo DESC'
	EXEC sp_executesql @query, N'@lastCode VARCHAR(10) out', @lastCode out
	RETURN UPPER(@tablePrefix)+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END
Go

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoCodigoDocumento')
	BEGIN
		drop function nuevoCodigoDocumento
	END
go

CREATE FUNCTION [dbo].[nuevoCodigoDocumento]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @lastCode VARCHAR(10)
	SELECT TOP 1 @lastCode = doc_Codigo from tbdocumento ORDER BY doc_Codigo DESC
	RETURN 'DOC'+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END

GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoNumeroGasto')
	BEGIN
		drop function nuevoNumeroGasto
	END
go

CREATE FUNCTION [dbo].[nuevoNumeroGasto]
( 
    @titulo NVARCHAR(100),
	@area VARCHAR(20)
) 
RETURNS VARCHAR(100)
BEGIN
	DECLARE @lastCode VARCHAR(100)
	DECLARE @lastNumber VARCHAR(10)

	SELECT TOP 1 @lastCode = doc_Numero  FROM tbdocumento 
	WHERE doc_Titulo = 'DTI0000006'
	ORDER BY doc_Codigo DESC

	SELECT TOP 1 @lastNumber = splitdata FROM(SELECT ROW_NUMBER() OVER (ORDER BY splitdata ASC) AS rownumber,* 
	FROM fnSplitString(@lastCode, '-')) AS foo 
	WHERE rownumber = 1
	RETURN @titulo+'-'+REPLACE(STR(CONVERT(INT,@lastNumber)+1, 4), SPACE(1), '0')+'-'+@area+'/UCV-CH-'+ LTRIM(STR( YEAR( GETDATE() ) % 100 ))
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'ultimoCodigo')
	BEGIN
		drop function ultimoCodigo
	END
go

CREATE FUNCTION [dbo].[ultimoCodigo](@tableName VARCHAR(20))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @tablePrefix CHAR(3)
	DECLARE @query nvarchar(max)
	DECLARE @lastCode VARCHAR(10)

	SET @tablePrefix = SUBSTRING(@tableName,3,3)
	SET @query = 'SELECT TOP 1 @lastCode='+@tablePrefix+'_Codigo FROM [' + @tablename + '] ORDER BY '+@tablePrefix+'_Codigo DESC'
	EXEC sp_executesql @query, N'@lastCode VARCHAR(10) out', @lastCode out
	RETURN @lastCode
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoCodigoDireccion')
	BEGIN
		drop function nuevoCodigoDireccion
	END
go

CREATE FUNCTION [dbo].[nuevoCodigoDireccion]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @lastCode VARCHAR(10)
	SELECT TOP 1 @lastCode = pdi_Codigo from tbpersona_direccion ORDER BY pdi_Codigo DESC
	RETURN 'PDI'+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END
Go

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoCodigoPersona')
	BEGIN
		drop function nuevoCodigoPersona
	END
go

CREATE FUNCTION [dbo].[nuevoCodigoPersona]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @lastCode VARCHAR(10)
	SELECT TOP 1 @lastCode = per_Codigo from tbpersona ORDER BY per_Codigo DESC
	RETURN 'PER'+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END
Go

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoCodigoPersonaArea')
	BEGIN
		drop function nuevoCodigoPersonaArea
	END
go

CREATE FUNCTION [dbo].[nuevoCodigoPersonaArea]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @lastCode VARCHAR(10)
	SELECT TOP 1 @lastCode = par_Codigo from tbpersona_area ORDER BY par_Codigo DESC
	RETURN 'PAR'+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END
Go

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'nuevoCodigoUsuario')
	BEGIN
		drop function nuevoCodigoUsuario
	END
go

CREATE FUNCTION [dbo].[nuevoCodigoUsuario]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @lastCode VARCHAR(10)
	SELECT TOP 1 @lastCode = usu_Codigo from tbusuario ORDER BY usu_Codigo DESC
	RETURN 'USU'+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END