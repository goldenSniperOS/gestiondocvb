USE [BDGestionDocumentaria]
GO
/****** Object:  StoredProcedure [dbo].[pa_MantenimientoPapeleta]    Script Date: 11/01/2017 10:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_MantenimientoPapeleta')
	drop procedure pa_MantenimientoPapeleta
go

CREATE PROCEDURE [dbo].[pa_MantenimientoPapeleta]
(
	@Tipo char(2),
	@InfoXML varchar(max)
)
AS
BEGIN
	declare @IDXML int
	IF (@Tipo = 'R')
	BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		insert into tbdocumento_papeleta(Pape_doc_Cod, Pape_Motivo, Pape_Lugar, Pape_Justificacion, Pape_Retorno, Pape_Fecha, Pape_HoraSalida, Pape_HoraEntrada, Pape_ApruebaPapeRRHH, Pape_Observacion)
		select Pape_doc_Cod, Pape_Motivo, Pape_Lugar, Pape_Justificacion, Pape_Retorno, Pape_Fecha, Pape_HoraSalida, Pape_HoraEntrada, Pape_ApruebaPapeRRHH, Pape_Observacion
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Pape_doc_Cod varchar(10), Pape_Motivo char(1), Pape_Lugar varchar(400), Pape_Justificacion varchar(400),
		Pape_Retorno char(2),Pape_Fecha date, Pape_HoraSalida time, Pape_HoraEntrada time , Pape_ApruebaPapeRRHH char(2), Pape_Observacion varchar(400))
		execute sp_xml_RemoveDocument @IDXML
			select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
	 END
	IF (@Tipo = 'L')
	BEGIN
		SELECT per.per_Codigo, per.per_Nombres, per.per_Apellidos FROM
		tbpersona per INNER JOIN tbpersona_area par ON per.per_Codigo = par.par_per_Codigo
		WHERE par.par_are_Codigo = @InfoXML
	END
	IF (@Tipo = 'LP')
	BEGIN
		SELECT per.per_Nombres As Nombres, per.per_Apellidos As Apellidos, 
		(CASE pape.Pape_Motivo 
		WHEN 1 THEN 'Comisi�n de Servicios'
		WHEN 2 THEN 'Consulta M�dica'
		WHEN 3 THEN 'Asuntos Personales'
		WHEN 4 THEN 'Otros' END) As Motivo, 
		pape.Pape_Fecha As Fecha, pape.Pape_ApruebaPapeRRHH As Aprobado
		FROM tbpersona per INNER JOIN tbdocumento doc ON per.per_Codigo = doc.doc_Remitente
		INNER JOIN tbdocumento_papeleta pape ON pape.pape_doc_Cod = doc.doc_Codigo WHERE pape.Pape_Fecha = @InfoXML ORDER BY pape.Pape_Codigo DESC
	END
	 IF (@Tipo = 'I')
	 BEGIN
		SELECT TOP 1 (SELECT TOP 1 doc_Codigo FROM tbdocumento ORDER BY doc_Codigo DESC) AS doc_Codigo
		FROM tbdocumento
		WHERE doc_Titulo = 'DTI0000008'
		ORDER BY doc_Codigo DESC
	 END 
	 IF (@Tipo = '1') --LISTAR LAS ULTIMAS 20 PAPELETAS REGSITRADAS QUE TIENEN RETORNO
	 BEGIN
		select top 20 TBP.Pape_Codigo, TBP.Pape_Fecha, TP.per_Apellidos, TP.per_Nombres, TBP.Pape_Motivo, TBP.Pape_ApruebaPapeRRHH,
		TBP.Pape_HoraSalida, TBP.Pape_HoraEntrada from tbdocumento_papeleta as TBP 
		inner join tbdocumento as TD on TD.doc_Codigo = TBP.Pape_doc_Cod
		inner join tbpersona as TP on TP.per_Codigo = TD.doc_Remitente

		where TBP.Pape_Retorno = 'SI' order by TBP.Pape_Codigo Desc
	 END 

	 IF (@Tipo = '2') -- LISTAR POR DNI BUSCADO
	 BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		select TBP.Pape_Codigo, TBP.Pape_Fecha, TP.per_Apellidos, TP.per_Nombres, TBP.Pape_Motivo, TBP.Pape_ApruebaPapeRRHH,
		TBP.Pape_HoraSalida, TBP.Pape_HoraEntrada
		from openXML(@IDXML, '/Dato/Principal',1)
		with(per_DNI VARCHAR(8))
		AS TablaLoca
		INNER JOIN tbpersona as TP ON TablaLoca.per_DNI = TP.per_DNI
		INNER JOIN tbdocumento as TD on TP.per_Codigo = TD.doc_Remitente
		Inner Join tbdocumento_papeleta as TBP on TD.doc_Codigo = TBP.Pape_doc_Cod
		where TBP.Pape_Retorno = 'SI' order by TBP.Pape_Codigo Desc
		execute sp_xml_RemoveDocument @IDXML
	 END 

	 IF (@Tipo = '3') -- Marcacion Salida
	 BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML

		UPDATE tbdocumento_papeleta SET Pape_HoraSalida = (select convert(time, SYSDATETIME()))
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Pape_Codigo int)
		AS TablaLoca
		WHERE tbdocumento_papeleta.Pape_Codigo = TablaLoca.Pape_Codigo

		select 'Modulo Marcaciones' as MensajeTitulo, 'Marcado Salida Con Exito' as MensajeProcedure
		execute sp_xml_RemoveDocument @IDXML
	 END 
	 IF (@Tipo = '4') -- Marcacion Salida
	 BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML

		UPDATE tbdocumento_papeleta SET Pape_HoraEntrada = (select convert(time, SYSDATETIME()))
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Pape_Codigo int)
		AS TablaLoca
		WHERE tbdocumento_papeleta.Pape_Codigo = TablaLoca.Pape_Codigo

		select 'Modulo Marcaciones' as MensajeTitulo, 'Marcado Entrada Con Exito' as MensajeProcedure
		execute sp_xml_RemoveDocument @IDXML
	 END 
END



GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_GastoMovilidad')
	drop procedure pa_GastoMovilidad
go

CREATE PROCEDURE [dbo].[pa_GastoMovilidad]
(
	@Tipo char(2),
	@InfoXML varchar(max)
)
AS 
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF (@Tipo = 'R')
	BEGIN
		Insert into tbdocumento_gastomovilidad(Gas_doc_Cod,Gas_Usuario,Gas_Fecha,Gas_Motivo,Gas_Ruta,Gas_Subtotal,Gas_Denegar,Gas_Tipo)
		select Gas_doc_Cod,Gas_Usuario,Gas_Fecha,Gas_Motivo,Gas_Ruta,Gas_Subtotal,Gas_Denegar,Gas_Tipo
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Gas_doc_Cod VARCHAR(10), Gas_Usuario VARCHAR(10), Gas_Fecha datetime, Gas_Motivo varchar(400), 
			Gas_Ruta varchar(400), Gas_Subtotal decimal(9,2),Gas_Denegar CHAR(2),Gas_Tipo CHAR(1))

		select 'GESTIONDOC' as MensajeTitulo, 'Se ha registrado el gasto' as MensajeProcedure
	 END

	 IF (@Tipo = 'A')
	 BEGIN
		UPDATE tbdocumento_gastomovilidad SET Gas_doc_Cod = TablaLoca.Gas_doc_Cod, Gas_Usuario=TablaLoca.Gas_Usuario, Gas_Fecha = TablaLoca.Gas_Fecha, 
		Gas_Motivo = TablaLoca.Gas_Motivo, Gas_Ruta = TablaLoca.Gas_Ruta, Gas_SubTotal = TablaLoca.Gas_Subtotal, Gas_Denegar = TablaLoca.Gas_Denegar
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Gas_Codigo INT, Gas_doc_Cod VARCHAR(10), Gas_Usuario VARCHAR(10), Gas_Fecha datetime, Gas_Motivo varchar(400), 
			Gas_Ruta varchar(400), Gas_Subtotal decimal(9,2),Gas_Denegar CHAR(2))
		AS TablaLoca
		WHERE tbdocumento_gastomovilidad.Gas_Codigo = TablaLoca.Gas_Codigo
		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Modifico :D!!!...' as MensajeProcedure
	 END
	 IF (@Tipo = 'L')
	 BEGIN
		SELECT  DISTINCT TOP 15 doc_Numero,doc_Gas_SerieCod,per_Apellidos,per_Nombres,are_Nombre,doc_Codigo,doc_ApruebaViat,Gas_Denegar FROM tbdocumento TD
		INNER JOIN tbdocumento_gastomovilidad as TGM ON TD.doc_Codigo = TGM.Gas_doc_Cod
		INNER JOIN tbusuario as TU ON TU.usu_Codigo = TGM.Gas_Usuario
		INNER JOIN tbpersona AS TP ON TP.per_Codigo = TU.usu_per_Codigo
		INNER JOIN tbpersona_area ON par_per_Codigo = per_Codigo
		INNER JOIN tbarea ON par_are_Codigo = are_Codigo
		ORDER BY doc_Codigo DESC
	 END
	 IF (@Tipo = 'LD')
	 BEGIN
		SELECT Gas_Fecha,Gas_Motivo,Gas_Ruta,Gas_Subtotal 
		from openXML(@IDXML, '/Dato/Principal',1)
		with(doc_Codigo VARCHAR(10))
		AS TablaLoca
		INNER JOIN tbdocumento_gastomovilidad TGM ON TablaLoca.doc_Codigo = TGM.Gas_doc_Cod
	 END
	 IF (@Tipo = 'I')
	 BEGIN
		SELECT TOP 1 (SELECT TOP 1 doc_Codigo FROM tbdocumento ORDER BY doc_Codigo DESC) AS doc_Codigo,doc_Numero,doc_Gas_SerieCod,doc_Codigo As seriador FROM tbdocumento
		WHERE doc_Titulo = 'DTI0000006'
		ORDER BY seriador DESC
	 END
	 IF (@Tipo = 'AP')
	 BEGIN
		UPDATE tbdocumento_gastomovilidad SET Gas_Denegar = TablaLoca.Gas_Denegar 
		from openXML(@IDXML, '/Dato/Principal',1)
		with(doc_Codigo VARCHAR(10), Gas_Denegar CHAR(2))
		AS TablaLoca
		WHERE tbdocumento_gastomovilidad.Gas_doc_Cod = TablaLoca.doc_Codigo

		UPDATE tbdocumento SET doc_ApruebaViat = case TablaLoca.Gas_Denegar when 'SI' then 'NO' else 'SI' end
		from openXML(@IDXML, '/Dato/Principal',1)
		with(doc_Codigo VARCHAR(10), Gas_Denegar CHAR(2))
		AS TablaLoca
		WHERE tbdocumento.doc_Codigo = TablaLoca.doc_Codigo

		select 'GESTIONDOC' as MensajeTitulo, 'Gasto Aprobado' as MensajeProcedure
	 END 
	 if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

go

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_MantenimientoVacacion')
	drop procedure pa_MantenimientoVacacion
go

CREATE PROCEDURE [dbo].[pa_MantenimientoVacacion]
(
	@Tipo char(2),
	@InfoXML varchar(max)
)
AS 
BEGIN
	declare @IDXML int
	IF (@Tipo = 'R')
	BEGIN
		if( @InfoXML<> '')
		DECLARE @table TABLE(Vaca_doc_Cod varchar(10), Vaca_FechaSalida date, Vaca_FechaTermino date, Vaca_FechaRetorno date, Vaca_Dias int,
			 Vaca_Pape_ApruebaJefe char(2), Vaca_Pape_ApruebaRRHH char(2), Vaca_Observacion varchar(200))
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		insert into @table 
		select Vaca_doc_Cod, Vaca_FechaSalida, Vaca_FechaTermino, Vaca_FechaRetorno, Vaca_Dias, Vaca_Pape_ApruebaJefe, Vaca_Pape_ApruebaRRHH, Vaca_Observacion
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Vaca_doc_Cod varchar(10), Vaca_FechaSalida date, Vaca_FechaTermino date, Vaca_FechaRetorno date, Vaca_Dias int,
			 Vaca_Pape_ApruebaJefe char(2), Vaca_Pape_ApruebaRRHH char(2), Vaca_Observacion varchar(200))
		insert into tbdocumento_vacaciones(Vaca_doc_Cod, Vaca_FechaSalida, Vaca_FechaTermino, Vaca_FechaRetorno, Vaca_Dias, Vaca_Pape_ApruebaJefe, Vaca_Pape_ApruebaRRHH, Vaca_Observacion)
		(select * from @table)
		select 'Gestion Documentaria' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
		if(@InfoXML <> '')
		execute sp_xml_RemoveDocument @IDXML
	 END
	 IF (@Tipo = 'A')
	 BEGIN
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		UPDATE tbdocumento_vacaciones SET Vaca_doc_Cod=TablaLoca.Vaca_doc_Cod, 
					Vaca_FechaSalida=TablaLoca.Vaca_FechaSalida, Vaca_FechaTermino=TablaLoca.Vaca_FechaTermino, 
					Vaca_FechaRetorno=TablaLoca.Vaca_FechaRetorno, Vaca_Dias=TablaLoca.Vaca_Dias, 
					Vaca_Pape_ApruebaJefe=TablaLoca.Vaca_Pape_ApruebaJefe, Vaca_Pape_ApruebaRRHH=TablaLoca.Vaca_Pape_ApruebaRRHH,
					Vaca_Observacion=TablaLoca.Vaca_Observacion
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Vaca_Codigo int, Vaca_doc_Cod varchar(10), Vaca_FechaSalida date, Vaca_FechaTermino date, Vaca_FechaRetorno date, Vaca_Dias int,
			 Vaca_Pape_ApruebaJefe char(2), Vaca_Pape_ApruebaRRHH char(2), Vaca_Observacion varchar(200))
		AS TablaLoca
		WHERE tbdocumento_vacaciones.Vaca_Codigo = TablaLoca.Vaca_Codigo

		select 'Gestion Documentaria' as MensajeTitulo, 'Exitosamente se modificio :D!!!...' as MensajeProcedure
			 if(@InfoXML <> '')
			 execute sp_xml_RemoveDocument @IDXML
			
	 END
	 
	 IF (@Tipo = 'I')
	 BEGIN
			if( @InfoXML<> '')
			execute sp_xml_prepareDocument @IDXML output, @InfoXML
			SELECT TOP 1 (SELECT TOP 1 doc_Codigo FROM tbdocumento ORDER BY doc_Codigo DESC) AS doc_Codigo
			FROM tbdocumento
			ORDER BY doc_Codigo DESC
			 if(@InfoXML <> '')
			 execute sp_xml_RemoveDocument @IDXML
	 END 


	 IF (@Tipo = '1') --Listar Para Recursos Humanos -> Lista todos los documentos Vacacion sin excepcion
	 BEGIN
	 
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		Select top 20 DV.Vaca_Codigo ,TD.doc_Fecha , TP.per_Apellidos, TP.per_Nombres, DV.Vaca_FechaSalida, 
		DV.Vaca_FechaRetorno, DV.Vaca_Dias, DV.Vaca_Pape_ApruebaJefe, DV.Vaca_Pape_ApruebaRRHH
		from tbdocumento_vacaciones as DV
		inner join tbdocumento as TD on DV.vaca_doc_Cod = TD.doc_Codigo
		inner join tbusuario as TU on TD.doc_usu_Codigo = TU.usu_Codigo
		inner join tbpersona as TP on TU.usu_per_Codigo = TP.per_Codigo
		 if(@InfoXML <> '')
		 execute sp_xml_RemoveDocument @IDXML

	 END
	  IF (@Tipo = '2') --Listar Por Area del Usuario
		 BEGIN
				if( @InfoXML<> '')
				execute sp_xml_prepareDocument @IDXML output, @InfoXML
				 Select top 20 DV.Vaca_Codigo ,TD.doc_Fecha , TP.per_Apellidos, TP.per_Nombres, DV.Vaca_FechaSalida, 
					DV.Vaca_FechaRetorno, DV.Vaca_Dias, DV.Vaca_Pape_ApruebaJefe, DV.Vaca_Pape_ApruebaRRHH
					from openXML(@IDXML, '/Dato/Principal',1)
					with(are_Codigo varchar(10))
					AS TablaLoca
					inner join tbpersona_area as PA on TablaLoca.are_Codigo = PA.par_are_codigo
					INNER JOIN tbpersona as TP ON TP.per_Codigo = PA.par_per_Codigo
					INNER JOIN tbusuario as TU ON TU.usu_per_Codigo = TP.per_Codigo
					INNER JOIN tbDocumento as TD ON TD.doc_usu_Codigo = TU.usu_Codigo
					INNER JOIN tbdocumento_vacaciones as DV ON DV.vaca_doc_Cod = TD.doc_Codigo
				 if(@InfoXML <> '')
				 execute sp_xml_RemoveDocument @IDXML
		 END

	 IF (@Tipo = '3') -- Buscar por DNI Y filtrar solo el area del usuario
	 BEGIN
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		declare @TablaAux table (per_DNI VARCHAR(8), are_Codigo varchar(10))

		insert into @TablaAux
		select per_DNI, are_Codigo from openXML(@IDXML, '/Dato/Principal',1)
		with(per_DNI VARCHAR(8), are_Codigo varchar(10))
		
		Select DV.Vaca_Codigo ,TD.doc_Fecha , TP.per_Apellidos, TP.per_Nombres, DV.Vaca_FechaSalida, 
		DV.Vaca_FechaRetorno, DV.Vaca_Dias, DV.Vaca_Pape_ApruebaJefe, DV.Vaca_Pape_ApruebaRRHH
		from tbdocumento_vacaciones as DV
		inner join tbdocumento as TD on DV.vaca_doc_Cod = TD.doc_Codigo
		inner join tbusuario as TU on TD.doc_usu_Codigo = TU.usu_Codigo
		inner join tbpersona as TP on TU.usu_per_Codigo = TP.per_Codigo
		inner join tbpersona_area as PA on TP.per_Codigo = PA.par_per_Codigo
		where ((select per_DNI from @TablaAux ) = TP.per_DNI) and ((select are_Codigo from @TablaAux ) = PA.par_are_Codigo)
		 if(@InfoXML <> '')
		 execute sp_xml_RemoveDocument @IDXML
	 END
	 
	 IF (@Tipo = '4') -- Modificar  parueba Jefe
	 BEGIN
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		UPDATE tbdocumento_vacaciones SET Vaca_Pape_ApruebaJefe= 'SI'
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Vaca_Codigo int)
		AS TablaLoca
		WHERE tbdocumento_vacaciones.Vaca_Codigo = TablaLoca.Vaca_Codigo

		select 'Jefe de Area' as MensajeTitulo, 'Vacaciones Otorgadas con Exito!' as MensajeProcedure
		 if(@InfoXML <> '')
		 execute sp_xml_RemoveDocument @IDXML
	 END

	 IF (@Tipo = '5')-- Modificar  parueba RRHH
	 BEGIN
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		UPDATE tbdocumento_vacaciones SET Vaca_Pape_ApruebaRRHH= 'SI'
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Vaca_Codigo int)
		AS TablaLoca
		WHERE tbdocumento_vacaciones.Vaca_Codigo = TablaLoca.Vaca_Codigo

		select 'Recursos Humanos' as MensajeTitulo, 'Vacaciones Otorgadas con Exito!' as MensajeProcedure
		 if(@InfoXML <> '')
		 execute sp_xml_RemoveDocument @IDXML
	 END

	 IF (@Tipo = '6') -- Buscar por DNI solo para RRHH
	 BEGIN
		
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		Select top 20 DV.Vaca_Codigo ,TD.doc_Fecha , TP.per_Apellidos, TP.per_Nombres, DV.Vaca_FechaSalida, 
		DV.Vaca_FechaRetorno, DV.Vaca_Dias, DV.Vaca_Pape_ApruebaJefe, DV.Vaca_Pape_ApruebaRRHH
		from openXML(@IDXML, '/Dato/Principal',1)
		with(per_DNI VARCHAR(8))
		AS TablaLoca
		INNER JOIN tbpersona as TP ON TablaLoca.per_DNI = TP.per_DNI
		INNER JOIN tbusuario as TU ON TU.usu_per_Codigo = TP.per_Codigo
		INNER JOIN tbDocumento as TD ON TD.doc_usu_Codigo = TU.usu_Codigo
		INNER JOIN tbdocumento_vacaciones as DV ON DV.vaca_doc_Cod = TD.doc_Codigo
		 if(@InfoXML <> '')
		 execute sp_xml_RemoveDocument @IDXML
	 END

	IF(@Tipo = 'B')
	BEGIN
		SELECT per_DNI As DNI, CONCAT( per_Nombres ,' ', per_Apellidos) As Persona, per_DiasVacaciones As Vacaciones FROM tbpersona
		WHERE per_Nombres LIKE '%'+@InfoXML+'%'
		OR per_Apellidos LIKE '%'+@InfoXML+'%'
		OR per_DNI LIKE '%'+@InfoXML+'%'
		OR per_CodPeople LIKE '%'+@InfoXML+'%'
		ORDER BY per_Codigo
	END	 
	 IF (@Tipo = 'AS')
	 BEGIN
		if( @InfoXML<> '')
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		UPDATE tbpersona SET per_DiasVacaciones = TablaLoca.Vacaciones
		from openXML(@IDXML, '/Dato/Principal',1)
		with(DNI char(8), Persona varchar(200), Vacaciones int)
		AS TablaLoca
		WHERE tbpersona.per_DNI = TablaLoca.DNI

		select 'Gestion Documentaria' as MensajeTitulo, 'Se han asignado los d�as de vacaciones' as MensajeProcedure
			 if(@InfoXML <> '')
			 execute sp_xml_RemoveDocument @IDXML
			
	 END
END
GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_MantenimientoDocumento')
	drop procedure pa_MantenimientoDocumento
go

CREATE Procedure [dbo].[pa_MantenimientoDocumento]
(
	@Tipo char(2),
	@InfoXML varchar(max)
)
AS
BEGIN
	declare @IDXML int
	if( @InfoXML<> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML
	IF (@Tipo = 'R')
	BEGIN
		insert into tbdocumento(doc_Codigo, doc_dpl_Codigo, doc_usu_Codigo, doc_Fecha, doc_Hora, doc_Numero, doc_dan_Codigo, doc_Titulo, doc_Remitente, doc_Destinatario, doc_Asunto, doc_Contenido, doc_Referencia, doc_Estado, doc_Actividad, doc_CodigoPresupues, doc_Meta, doc_DescargaDocumento, doc_ConfirmaFirma, doc_Firma, doc_Gas_SerieCod, doc_ApruebaMov, doc_ApruebaPape, doc_ApruebaViat)
		select doc_Codigo, doc_dpl_Codigo, doc_usu_Codigo, doc_Fecha, doc_Hora, doc_Numero, doc_dan_Codigo, doc_Titulo, doc_Remitente, doc_Destinatario, doc_Asunto, doc_Contenido, doc_Referencia, doc_Estado, doc_Actividad, doc_CodigoPresupues, doc_Meta, doc_DescargaDocumento, doc_ConfirmaFirma, doc_Firma, NULL, doc_ApruebaMov, doc_ApruebaPape, doc_ApruebaViat
		from openXML(@IDXML, '/Dato/Principal',1)
		with(doc_Codigo varchar(10), doc_dpl_Codigo varchar(10), doc_usu_Codigo varchar(10),doc_Fecha date, doc_Hora time, 
			doc_Numero varchar(100), doc_dan_Codigo varchar(10), doc_Titulo varchar(50), doc_Remitente varchar(10), 
			doc_Destinatario varchar(10), doc_Asunto varchar(50), doc_Contenido varchar(8000), doc_Referencia varchar(50), 
			doc_Estado int, doc_Actividad varchar(500), doc_CodigoPresupues varchar(100), doc_Meta varchar(300), 
			doc_DescargaDocumento varchar(2), doc_ConfirmaFirma varchar(2), doc_Firma char(2), doc_Gas_SerieCod varchar(20),
			doc_ApruebaMov char(2), doc_ApruebaPape char(2), doc_ApruebaViat char(2))
			select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
	 END
	 IF (@Tipo = 'RG')
	BEGIN
		DECLARE @nuevoCodigo TABLE(doc_Codigo VARCHAR(10),doc_Numero varchar(100),doc_Gas_SerieCod VARCHAR(20))
		insert into tbdocumento(doc_Codigo, doc_dpl_Codigo, doc_usu_Codigo, doc_Fecha, doc_Hora, doc_Numero, doc_dan_Codigo, doc_Titulo, doc_Remitente, doc_Destinatario, doc_Asunto, doc_Contenido, doc_Referencia, doc_Estado, doc_Actividad, doc_CodigoPresupues, doc_Meta, doc_DescargaDocumento, doc_ConfirmaFirma, doc_Firma, doc_Gas_SerieCod, doc_ApruebaMov, doc_ApruebaPape, doc_ApruebaViat)
		OUTPUT Inserted.doc_Codigo,Inserted.doc_Numero,Inserted.doc_Gas_SerieCod INTO @nuevoCodigo
		select dbo.nuevoCodigoDocumento(), doc_dpl_Codigo, doc_usu_Codigo, doc_Fecha, doc_Hora, dbo.nuevoNumeroGasto('GASTO',doc_Numero), doc_dan_Codigo, doc_Titulo, doc_Remitente, doc_Destinatario, doc_Asunto, doc_Contenido, doc_Referencia, doc_Estado, doc_Actividad, doc_CodigoPresupues, doc_Meta, doc_DescargaDocumento, doc_ConfirmaFirma, doc_Firma,  dbo.nuevaSerie(), doc_ApruebaMov, doc_ApruebaPape, doc_ApruebaViat
		from openXML(@IDXML, '/Dato/Principal',1)
		with(doc_dpl_Codigo varchar(10), doc_usu_Codigo varchar(10),doc_Fecha date, doc_Hora time, 
			doc_Numero varchar(100), doc_dan_Codigo varchar(10), doc_Titulo varchar(50), doc_Remitente varchar(10), 
			doc_Destinatario varchar(10), doc_Asunto varchar(50), doc_Contenido varchar(8000), doc_Referencia varchar(50), 
			doc_Estado int, doc_Actividad varchar(500), doc_CodigoPresupues varchar(100), doc_Meta varchar(300), 
			doc_DescargaDocumento varchar(2), doc_ConfirmaFirma varchar(2), doc_Firma char(2),
			doc_ApruebaMov char(2), doc_ApruebaPape char(2), doc_ApruebaViat char(2))
		select * FROM @nuevoCodigo
	 END
	 --IF (@Tipo = 'A')
	 --BEGIN
		--UPDATE CLIENTE SET Dni = TablaLoca.Dni, Nombre=TablaLoca.Nombre, Apellidos = TablaLoca.Apellidos, Direccion = TablaLoca.Direccion, Telefono = TablaLoca.Telefono, Sexo = TablaLoca.Sexo, Edad =TablaLoca.Edad 
		--from openXML(@IDXML, '/Dato/Principal',1)
		--with(Id int, Dni char(8), Nombre varchar(20), Apellidos varchar(30),Direccion varchar(30), Telefono varchar(20), Sexo varchar(4), Edad int)
		--AS TablaLoca
		--WHERE CLIENTE.Id = TablaLoca.Id

		--select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se modificio :D!!!...' as MensajeProcedure
	 --END
	 --IF (@Tipo = '1')
	 --BEGIN
		--SELECT * FROM CLIENTE
	 --END
	 
	 if(@InfoXML <> '')
	 execute sp_xml_RemoveDocument @IDXML	 
END

go

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_TrabajadorPorArea')
	drop procedure pa_TrabajadorPorArea
go

CREATE PROCEDURE [dbo].[pa_TrabajadorPorArea]
(
	@Tipo char(1),
	@InfoXML varchar(max)
)
AS
BEGIN
	declare @IDXML int
	IF (@Tipo = 'L')
	BEGIN
		SELECT per.per_Codigo, per.per_Nombres, per.per_Apellidos FROM tbpersona per INNER JOIN tbusuario usu ON per.per_Codigo = usu.usu_per_Codigo
	END
END

/****** Object:  StoredProcedure [dbo].[pa_usuario]    Script Date: 11/01/2017 10:57:29 ******/
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_usuario')
	drop procedure pa_usuario
go

CREATE PROCEDURE [dbo].[pa_Usuario]
(
	@Tipo char(2),
	@InfoXML varchar(max)
)
AS 
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF (@Tipo = 'L')
	BEGIN
		DECLARE @allDataLogin TABLE (usu_Nombre VARCHAR(20),usu_Contrasena VARCHAR(20));

		INSERT INTO @allDataLogin
		SELECT usu_Nombre,usu_Contrasena
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_Nombre VARCHAR(20),usu_Contrasena VARCHAR(20))

		SELECT DISTINCT * FROM tbusuario AS U
		INNER JOIN tbusuario_modulo ON usu_mod_Usuario = usu_Codigo 
		INNER JOIN tbmodulo ON usu_mod_Modulo = mod_ID
		INNER JOIN tbpersona ON per_Codigo = usu_per_Codigo
		INNER JOIN tbpersona_area ON tbpersona.per_Codigo=tbpersona_area.par_per_Codigo
		INNER JOIN tbarea ON tbarea.are_Codigo=tbpersona_area.par_are_Codigo
		INNER JOIN @allDataLogin AS Tabla ON (Tabla.usu_Nombre = U.usu_Nombre AND Tabla.usu_Contrasena = U.usu_Contrasena)
	END

	IF (@Tipo = 'R')
	BEGIN
		DECLARE @allDataRegister TABLE (usu_mod_Id INT,usu_mod_Modulo INT, usu_mod_Usuario VARCHAR(10), Accion VARCHAR(20));
		DECLARE @userRegister TABLE (usu_Codigo VARCHAR(10),usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),usu_Estado BIT);

		INSERT INTO @allDataRegister 
		SELECT usu_mod_Id,usu_mod_Modulo,usu_mod_Usuario,Accion
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_mod_Id INT,usu_mod_Modulo INT, usu_mod_Usuario VARCHAR(10), Accion VARCHAR(20))

		INSERT INTO @userRegister 
		SELECT usu_Codigo,usu_Nombre, usu_Contrasena,usu_Estado
		FROM openXML(@IDXML, '/Dato/Usuario',1)
		WITH(usu_Codigo VARCHAR(10),usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),usu_Estado BIT)

		INSERT INTO tbusuario_modulo
		SELECT  dbo.ultimoCodigo('tbusuario'),usu_mod_Modulo
		FROM @allDataRegister
		WHERE Accion = 'INSERT'

		Select 'GESTIONDOC' as MensajeTitulo, 'Usuario creado correctamente' as MensajeProcedure
	END

	IF (@Tipo = 'A')
	BEGIN
		DECLARE @allData TABLE (usu_mod_Id INT,usu_mod_Modulo INT, usu_mod_Usuario VARCHAR(10), Accion VARCHAR(20));
		DECLARE @user TABLE (usu_Codigo VARCHAR(10),usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),usu_Beneficio CHAR(2),usu_Vacaciones CHAR(2),usu_Marcacion CHAR(2),usu_Papeleta CHAR(2),usu_NotaContable CHAR(2),
		usu_Persona CHAR(2),usu_Estado BIT);

		INSERT INTO @user 
		SELECT usu_Codigo,usu_Nombre, usu_Contrasena,usu_Beneficio,usu_Vacaciones,usu_Marcacion ,usu_Papeleta,usu_NotaContable,
		usu_Persona,usu_Estado
		FROM openXML(@IDXML, '/Dato/Usuario',1)
		WITH(usu_Codigo VARCHAR(10),usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),
		usu_Beneficio CHAR(2),usu_Vacaciones CHAR(2),usu_Marcacion CHAR(2),usu_Papeleta CHAR(2),usu_NotaContable CHAR(2),
		usu_Persona CHAR(2),usu_Estado BIT)

		DELETE UM
		FROM tbusuario_modulo UM
		WHERE UM.usu_mod_Usuario = (SELECT TOP 1 usu_Codigo FROM @user)

		INSERT INTO @allData 
		SELECT usu_mod_Id,usu_mod_Modulo,usu_mod_Usuario,Accion
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_mod_Id INT,usu_mod_Modulo INT, usu_mod_Usuario VARCHAR(10), Accion VARCHAR(20))

		

		UPDATE tbusuario
		SET usu_Nombre = TA.usu_Nombre,
			usu_Contrasena = TA.usu_Contrasena,
			usu_Estado = TA.usu_Estado,
			usu_Persona = TA.usu_Persona,
			usu_Papeleta = TA.usu_Papeleta,
			usu_NotaContable = TA.usu_NotaContable,
			usu_Marcacion = TA.usu_Marcacion,
			usu_Beneficio = TA.usu_Beneficio,
			usu_Vacaciones = TA.usu_Vacaciones
		FROM tbusuario U
		INNER JOIN @user TA on U.usu_Codigo = TA.usu_Codigo

		INSERT INTO tbusuario_modulo
		SELECT  usu_mod_Usuario,usu_mod_Modulo
		FROM @allData
		WHERE Accion = 'INSERT'
			
		--INNER JOIN (SELECT * FROM @allData WHERE Accion = 'DELETE') TA on UM.usu_mod_Id  = TA.usu_mod_Id

		Select 'GESTIONDOC' as MensajeTitulo, 'Usuario Modificado Correctamente' as MensajeProcedure
	END

	IF (@Tipo = 'C')
	BEGIN
		DECLARE @liker TABLE (usu_Nombre VARCHAR(20));
		
		INSERT INTO @liker
		SELECT usu_Nombre
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_Nombre VARCHAR(20))
		
		SELECT U.usu_Codigo,U.usu_Nombre,U.usu_Contrasena,U.usu_Estado FROM tbusuario U
		INNER JOIN @liker As LI ON U.usu_Nombre LIKE '%'+LI.usu_Nombre+'%'
		WHERE U.usu_Estado = 1
	END

	IF (@Tipo = 'P')
	BEGIN
		DECLARE @likerPermissions TABLE (usu_Nombre VARCHAR(20));
		
		INSERT INTO @likerPermissions
		SELECT usu_Nombre
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_Nombre VARCHAR(20))

		SELECT 
			mod_ID,
			mod_Nombre,
			mod_Padre,
			mod_Formulario,
			ISNULL(usu_Codigo,'NOUSERCODE') As usu_Codigo,
			ISNULL(usu_Nombre,'NOUSER') AS usu_Nombre,
			ISNULL(usu_Contrasena,'NOPASS') AS usu_Password,
			ISNULL(usu_mod_Id,0) As usu_mod_Id
		FROM tbmodulo
		LEFT JOIN (
			SELECT U.usu_Codigo,U.usu_Nombre,U.usu_Contrasena,UM.usu_mod_Id,UM.usu_mod_Modulo,UM.usu_mod_Usuario
			FROM tbusuario_modulo UM
			INNER JOIN tbusuario U ON usu_mod_Usuario = U.usu_Codigo
			INNER JOIN @likerPermissions USU ON USU.usu_Nombre = U.usu_Nombre
		) As TablaFinal ON usu_mod_Modulo = mod_ID
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

go


IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_persona')
	drop procedure pa_persona
go

CREATE PROCEDURE [dbo].[pa_persona]
(
	@Tipo char(1),
	@InfoXML varchar(max)
)
AS 
BEGIN
	declare @IDXML int
	IF (@Tipo = 'R')
	BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML

		DECLARE @nuevoCodigo VARCHAR (10)
		SET @nuevoCodigo = dbo.nuevoCodigoPersona()

		DECLARE @nuevoCodigoUsuario VARCHAR (10)
		SET @nuevoCodigoUsuario = dbo.nuevoCodigoUsuario()

		DECLARE @nuevoCodigoDir VARCHAR (10)
		SET @nuevoCodigoDir = dbo.nuevoCodigoDireccion()

		DECLARE @nuevoCodigoPersonaArea VARCHAR (10)
		SET @nuevoCodigoPersonaArea = dbo.nuevoCodigoPersonaArea()
		
		DECLARE @user TABLE (usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),
		usu_Beneficio CHAR(2),usu_Vacaciones CHAR(2),usu_Marcacion CHAR(2),usu_Papeleta CHAR(2),usu_NotaContable CHAR(2),
		usu_Persona CHAR(2),usu_Estado BIT);

		DECLARE @area TABLE (are_Codigo VARCHAR(10));
		
		DECLARE @personaRegister TABLE (per_Codigo varchar(10), per_TipoEmpresa varchar(20), per_RazonSocial varchar(50), per_prs_Codigo varchar(6), per_RUC varchar(11),
		 per_ppr_Codigo varchar(6), per_Nombres varchar(30), per_Apellidos varchar(30), per_Sexo char(1), per_DNI varchar(8), 
		 per_DNICaducidad date, per_Nacimiento date, per_pca_Codigo  varchar(6), per_Email varchar(50), per_Telefono int, 
		 per_pti_Codigo varchar(6), per_pdi_Codigo varchar(10), per_DiasVacaciones int, per_CodPeople varchar(10), per_EstadoCivil varchar(10), 
		 per_Estudios varchar(100), per_Actualizacion varchar(2), per_Sede varchar(10), per_Grupo varchar(10));

		DECLARE @datosDireccionReg TABLE (pdi_Codigo varchar(10), pdi_dis_Codigo VARCHAR(7), pdi_pzo_Codigo varchar(6),pdi_NombreZona VARCHAR(50), pdi_pvi_Codigo varchar(6), pdi_NombreVia varchar(50),
		pdi_Numero int);

		insert into @datosDireccionReg
		select pdi_Codigo, pdi_dis_Codigo , pdi_pzo_Codigo ,pdi_NombreZona , pdi_pvi_Codigo , pdi_NombreVia ,pdi_Numero 
		from openXML(@IDXML, '/Dato/Principal',1)
		with(pdi_Codigo varchar(10), pdi_dis_Codigo VARCHAR(7), pdi_pzo_Codigo varchar(6),pdi_NombreZona VARCHAR(50), pdi_pvi_Codigo varchar(6), pdi_NombreVia varchar(50),
		pdi_Numero int)

		INSERT INTO @personaRegister(per_Codigo, per_TipoEmpresa, per_RazonSocial, per_prs_Codigo, per_RUC, per_ppr_Codigo, per_Nombres, per_Apellidos, per_Sexo, per_DNI, per_DNICaducidad, per_Nacimiento, per_pca_Codigo, per_Email, per_Telefono, per_pti_Codigo, per_pdi_Codigo, per_DiasVacaciones, per_CodPeople, per_EstadoCivil, per_Estudios, per_Actualizacion, per_Sede, per_Grupo)
		SELECT per_Codigo, per_TipoEmpresa, per_RazonSocial, per_prs_Codigo, per_RUC, per_ppr_Codigo, per_Nombres, per_Apellidos, per_Sexo, per_DNI, per_DNICaducidad, per_Nacimiento, per_pca_Codigo, per_Email, per_Telefono, per_pti_Codigo, per_pdi_Codigo, per_DiasVacaciones, per_CodPeople, per_EstadoCivil, per_Estudios, per_Actualizacion, per_Sede, per_Grupo
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(per_Codigo varchar(10), per_TipoEmpresa varchar(20), per_RazonSocial varchar(50), per_prs_Codigo varchar(6), per_RUC varchar(11),
		 per_ppr_Codigo varchar(6), per_Nombres varchar(30), per_Apellidos varchar(30), per_Sexo char(1), per_DNI varchar(8), 
		 per_DNICaducidad date, per_Nacimiento date, per_pca_Codigo  varchar(6), per_Email varchar(50), per_Telefono int, 
		 per_pti_Codigo varchar(6), per_pdi_Codigo varchar(10), per_DiasVacaciones int, per_CodPeople varchar(10), per_EstadoCivil varchar(10), 
		 per_Estudios varchar(100), per_Actualizacion varchar(2), per_Sede varchar(10), per_Grupo varchar(10))

		INSERT INTO @user 
		SELECT usu_Nombre, usu_Contrasena,usu_Beneficio,usu_Vacaciones,usu_Marcacion ,usu_Papeleta,usu_NotaContable,
		usu_Persona,usu_Estado
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),
		usu_Beneficio CHAR(2),usu_Vacaciones CHAR(2),usu_Marcacion CHAR(2),usu_Papeleta CHAR(2),usu_NotaContable CHAR(2),
		usu_Persona CHAR(2),usu_Estado BIT)

		INSERT INTO @area
		SELECT are_Codigo
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(are_Codigo VARCHAR(10))

		INSERT INTO tbpersona_direccion
		SELECT
			@nuevoCodigoDir pdi_Codigo,
			pdi_dis_Codigo,
			pdi_pzo_Codigo,
			pdi_NombreZona,
			pdi_pvi_Codigo,
			pdi_NombreVia,
			pdi_Numero,
			0 AS pdi_Piso,
			'' AS pdi_Interior,
			'' As pdi_Manzana,
			0 AS pdi_Lote
		FROM @datosDireccionReg

		INSERT INTO tbpersona
		SELECT 
				@nuevoCodigo AS per_Codigo,
				'PERSONA NATURAL' As per_TipoEmpresa, 
				'' AS per_RazonSocial, 
				NULL AS per_prs_Codigo, 
				'' AS per_RUC, 
				per_ppr_Codigo, 
				per_Nombres, 
				per_Apellidos, 
				per_Sexo, 
				per_DNI, 
				per_DNICaducidad, 
				per_Nacimiento, 
				per_pca_Codigo, 
				per_Email, 
				per_Telefono, 
				'PTI001' As per_pti_Codigo, 
				@nuevoCodigoDir As per_pdi_Codigo, 
				0 As per_DiasVacaciones, 
				per_CodPeople, 
				per_EstadoCivil, 
				'' As per_Estudios, 
				'SI' As per_Actualizacion, 
				'CHICLAYO' As per_Sede, 
				'GEL_ADM' AS per_Grupo 
		FROM @personaRegister

		INSERT INTO tbusuario
		SELECT
			@nuevoCodigoUsuario As usu_Codigo,
			@nuevoCodigo As usu_per_Codigo,
			usu_Nombre,
			usu_Contrasena,
			1 As usu_Estado,
			'NO' As usu_Digitalizaion,
			'SI' AS usu_Tramite,
			'NO' AS usu_Requisito,
			usu_Persona,
			'NO' as usu_Mantenimiento,
			'NO' as usu_Reporte,
			usu_Papeleta,
			usu_Vacaciones,
			usu_Beneficio,
			usu_Marcacion,
			usu_NotaContable,
			1 As usu_Sesion
		From @user

		INSERT INTO tbpersona_area
		SELECT
			@nuevoCodigoPersonaArea AS par_Codigo,
			@nuevoCodigo As par_per_Codigo,
			are_Codigo As par_are_Codigo,
			1 As par_Estado
		FROM @area

		SELECT
			@nuevoCodigoUsuario As usu_Codigo,
			@nuevoCodigo As usu_per_Codigo,
			usu_Nombre,
			usu_Contrasena,
			1 As usu_Estado,
			'NO' As usu_Digitalizaion,
			'SI' AS usu_Tramite,
			'NO' AS usu_Requisito,
			usu_Persona,
			'NO' as usu_Mantenimiento,
			'NO' as usu_Reporte,
			usu_Papeleta,
			usu_Vacaciones,
			usu_Beneficio,
			usu_Marcacion,
			usu_NotaContable,
			1 As usu_Sesion
		From @user

		execute sp_xml_RemoveDocument @IDXML
	 END
	 IF (@Tipo = 'A')
	BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		DECLARE @datosPersona TABLE (per_Codigo varchar(10), per_TipoEmpresa varchar(20), per_RazonSocial varchar(50), per_prs_Codigo varchar(6), per_RUC varchar(11),
		 per_ppr_Codigo varchar(6), per_Nombres varchar(30), per_Apellidos varchar(30), per_Sexo char(1), per_DNI varchar(8), 
		 per_DNICaducidad date, per_Nacimiento date, per_pca_Codigo  varchar(6), per_Email varchar(50), per_Telefono int, 
		 per_pti_Codigo varchar(6), per_pdi_Codigo varchar(10), per_DiasVacaciones int, per_CodPeople varchar(10), per_EstadoCivil varchar(10), 
		 per_Estudios varchar(100), per_Actualizacion varchar(2), per_Sede varchar(10), per_Grupo varchar(10));

		insert into @datosPersona
		select per_Codigo, per_TipoEmpresa, per_RazonSocial, per_prs_Codigo, per_RUC, per_ppr_Codigo, per_Nombres, per_Apellidos, per_Sexo, per_DNI, CONVERT(DATE,per_DNICaducidad,103), CONVERT(DATE,per_Nacimiento,103), per_pca_Codigo, per_Email, per_Telefono, per_pti_Codigo, per_pdi_Codigo, per_DiasVacaciones, per_CodPeople, per_EstadoCivil, per_Estudios, per_Actualizacion, per_Sede, per_Grupo
		from openXML(@IDXML, '/Dato/Principal',1)
		with(per_Codigo varchar(10), per_TipoEmpresa varchar(20), per_RazonSocial varchar(50), per_prs_Codigo varchar(6), per_RUC varchar(11),
		 per_ppr_Codigo varchar(6), per_Nombres varchar(30), per_Apellidos varchar(30), per_Sexo char(1), per_DNI varchar(8), 
		 per_DNICaducidad VARCHAR(100), per_Nacimiento VARCHAR(100), per_pca_Codigo  varchar(6), per_Email varchar(50), per_Telefono int, 
		 per_pti_Codigo varchar(6), per_pdi_Codigo varchar(10), per_DiasVacaciones int, per_CodPeople varchar(10), per_EstadoCivil varchar(10), 
		 per_Estudios varchar(100), per_Actualizacion varchar(2), per_Sede varchar(10), per_Grupo varchar(10))

		DECLARE @datosDireccion TABLE (pdi_Codigo varchar(10), pdi_dis_Codigo VARCHAR(7), pdi_pzo_Codigo varchar(6),pdi_NombreZona VARCHAR(50), pdi_pvi_Codigo varchar(6), pdi_NombreVia varchar(50),
		pdi_Numero int);

		insert into @datosDireccion
		select pdi_Codigo, pdi_dis_Codigo , pdi_pzo_Codigo ,pdi_NombreZona , pdi_pvi_Codigo , pdi_NombreVia ,pdi_Numero 
		from openXML(@IDXML, '/Dato/Principal',1)
		with(pdi_Codigo varchar(10), pdi_dis_Codigo VARCHAR(7), pdi_pzo_Codigo varchar(6),pdi_NombreZona VARCHAR(50), pdi_pvi_Codigo varchar(6), pdi_NombreVia varchar(50),
		pdi_Numero int)


		UPDATE tbpersona_direccion
		SET pdi_dis_Codigo = DI.pdi_dis_Codigo,
			pdi_pzo_Codigo = DI.pdi_pzo_Codigo,
			pdi_NombreZona = DI.pdi_NombreZona,
			pdi_pvi_Codigo = DI.pdi_pvi_Codigo,
			pdi_NombreVia = DI.pdi_NombreVia,
			pdi_Numero = DI.pdi_Numero
		FROM tbpersona_direccion DIR
		INNER JOIN @datosDireccion DI on DIR.pdi_Codigo = DI.pdi_Codigo

		UPDATE tbpersona
		SET per_Nombres = DP.per_Nombres,
			per_Apellidos = DP.per_Apellidos,
			per_TipoEmpresa = 'PERSONA NATURAL',
			per_RazonSocial = '',
			per_prs_Codigo = NULL,
			per_RUC = '',
			per_ppr_Codigo = DP.per_ppr_Codigo,
			per_Sexo = DP.per_Sexo,
			per_DNI = DP.per_DNI,
			per_DNICaducidad = DP.per_DNICaducidad,
			per_Nacimiento = DP.per_Nacimiento,
			per_pca_Codigo = DP.per_pca_Codigo,
			per_Email = DP.per_Email,
			per_Telefono = DP.per_Telefono,
			per_pti_Codigo = 'PTI001',
			per_pdi_Codigo = DP.per_pdi_Codigo,
			per_CodPeople = DP.per_CodPeople,
			per_EstadoCivil = DP.per_EstadoCivil,
			per_Estudios = '',
			per_Actualizacion = 'SI',
			per_Sede = 'CHICLAYO',
			per_Grupo = 'GEL_ADM'
		FROM tbpersona P
		INNER JOIN @datosPersona DP on P.per_Codigo = DP.per_Codigo

		select 'GESTIONDOC' as MensajeTitulo, 'Se actualizaron Datos de PERSONA' as MensajeProcedure
		
		execute sp_xml_RemoveDocument @IDXML
	 END
	 IF (@Tipo = 'L')
	 BEGIN
		SELECT TOP 20 
				per_Codigo,
				per_ppr_Codigo,
				per_Nombres,
				per_Apellidos,
				per_Sexo,
				per_DNI,
				per_CodPeople,
				per_DNICaducidad,
				per_Nacimiento,
				pca_Codigo,
				pca_Nombre,
				per_Email,
				per_Telefono,
				pdi_Codigo,
				pdi_dis_Codigo,
				pro_Codigo,
				dep_Codigo,
				pdi_pzo_Codigo,
				pdi_NombreZona,
				pdi_NombreVia,
				pdi_pvi_Codigo,
				pdi_Numero,
				per_EstadoCivil,
				per_Estudios,
				are_Codigo,
				are_Nombre,
				usu_Codigo,
				usu_Nombre,
				usu_Contrasena,
				usu_Tramite,
				usu_Persona,
				usu_Papeleta,
				usu_Vacaciones,
				usu_Beneficio,
				usu_Marcacion,
				usu_NotaContable,
				usu_Estado
		FROM tbpersona
		INNER JOIN tbpersona_area ON par_per_Codigo = per_Codigo
		INNER JOIN tbpersona_prefijo ON per_ppr_Codigo = ppr_Codigo
		INNER JOIN tbarea ON are_Codigo = par_are_Codigo
		INNER JOIN tbpersona_cargo ON per_pca_Codigo = pca_Codigo
		INNER JOIN tbpersona_direccion ON per_pdi_Codigo = pdi_Codigo
		INNER JOIN tbpersona_distrito ON pdi_dis_Codigo = dis_Codigo
		INNER JOIN tbpersona_provincia ON dis_pro_Codigo = pro_Codigo
		INNER JOIN tbpersona_departamento ON pro_dep_Codigo = dep_Codigo
		INNER JOIN tbusuario ON usu_per_Codigo = per_Codigo
		ORDER BY per_Codigo
	 END
	 IF (@Tipo = 'F')
	 BEGIN
		SELECT TOP 20 
				per_Codigo,
				per_ppr_Codigo,
				per_Nombres,
				per_Apellidos,
				per_Sexo,
				per_DNI,
				per_CodPeople,
				per_DNICaducidad,
				per_Nacimiento,
				pca_Codigo,
				pca_Nombre,
				per_Email,
				per_Telefono,
				pdi_Codigo,
				pdi_dis_Codigo,
				pro_Codigo,
				dep_Codigo,
				pdi_pzo_Codigo,
				pdi_NombreZona,
				pdi_NombreVia,
				pdi_pvi_Codigo,
				pdi_Numero,
				per_EstadoCivil,
				per_Estudios,
				are_Codigo,
				are_Nombre,
				usu_Codigo,
				usu_Nombre,
				usu_Contrasena,
				usu_Tramite,
				usu_Persona,
				usu_Papeleta,
				usu_Vacaciones,
				usu_Beneficio,
				usu_Marcacion,
				usu_NotaContable,
				usu_Estado
		FROM tbpersona
		INNER JOIN tbpersona_area ON par_per_Codigo = per_Codigo
		INNER JOIN tbpersona_prefijo ON per_ppr_Codigo = ppr_Codigo
		INNER JOIN tbarea ON are_Codigo = par_are_Codigo
		INNER JOIN tbpersona_cargo ON per_pca_Codigo = pca_Codigo
		INNER JOIN tbpersona_direccion ON per_pdi_Codigo = pdi_Codigo
		INNER JOIN tbpersona_distrito ON pdi_dis_Codigo = dis_Codigo
		INNER JOIN tbpersona_provincia ON dis_pro_Codigo = pro_Codigo
		INNER JOIN tbpersona_departamento ON pro_dep_Codigo = dep_Codigo
		INNER JOIN tbusuario ON usu_per_Codigo = per_Codigo
		WHERE per_Nombres LIKE '%'+@InfoXML+'%'
		OR per_Apellidos LIKE '%'+@InfoXML+'%'
		OR per_DNI LIKE '%'+@InfoXML+'%'
		OR pca_Nombre LIKE '%'+@InfoXML+'%'
		OR per_CodPeople LIKE '%'+@InfoXML+'%'
		ORDER BY per_Codigo
	 END
END

go

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Rol')
	drop procedure pa_Rol
go

CREATE PROCEDURE [dbo].[pa_Rol]
(
	@Tipo char(2),
	@InfoXML varchar(max)
)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF (@Tipo = 'L')
	BEGIN
		SELECT * FROM tbrol
	END
	IF (@Tipo = 'LD')
	BEGIN
		DECLARE @liker TABLE (rol_mod_Rol INT);
		
		INSERT INTO @liker
		SELECT rol_mod_Rol
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(rol_mod_Rol INT)

		SELECT 
			M.mod_ID,
			M.mod_Nombre,
			M.mod_Padre,
			M.mod_Formulario,
			ISNULL(TablaFinal.mod_ID,0) As usu_Codigo,
			0 As usu_mod_Id
		FROM tbmodulo M
		LEFT JOIN (
			SELECT mod_Id,mod_Nombre,mod_Padre,mod_Formulario
			FROM tbrol_modulo TA
			INNER JOIN tbmodulo ON mod_ID = rol_mod_Modulo
			INNER JOIN @liker E ON E.rol_mod_Rol = TA.rol_mod_Rol
		) As TablaFinal ON M.mod_Id = TablaFinal.mod_ID
		
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END
go

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Listados')
	drop procedure pa_Listados
go

CREATE PROCEDURE [dbo].[pa_Listados]
	@Listado VARCHAR(50),
	@Foranea VARCHAR(10)
AS
BEGIN
	IF (@Listado = 'Areas')
	BEGIN
		SELECT * FROM tbarea
	END
	IF (@Listado = 'Cargos')
	BEGIN
		SELECT * FROM tbpersona_cargo
	END

	IF (@Listado = 'Prefijos')
	BEGIN
		SELECT * FROM tbpersona_prefijo
	END

	IF (@Listado = 'Tipos')
	BEGIN
		SELECT * FROM tbpersona_tipo
	END
	
	IF (@Listado = 'Departamentos')
	BEGIN
		SELECT * FROM tbpersona_departamento
	END
	
	IF (@Listado = 'Provincias')
	BEGIN
		SELECT * FROM tbpersona_provincia
		WHERE pro_dep_Codigo = @Foranea
	END

	IF (@Listado = 'Distritos')
	BEGIN
		SELECT * FROM tbpersona_distrito
		WHERE dis_pro_Codigo = @Foranea
	END

	IF (@Listado = 'Vias')
	BEGIN
		SELECT * FROM tbpersona_via
	END

	IF (@Listado = 'Zonas')
	BEGIN
		SELECT * FROM tbpersona_zona
	END

	IF (@Listado = 'Roles')
	BEGIN
		SELECT * FROM tbrol
	END
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='p_ReporteVacacion')
	drop procedure p_ReporteVacacion
go

create proc [dbo].[p_ReporteVacacion]
@Codigo as integer
as
select TDA.dan_Nombre, TP.per_Apellidos,TP.per_Nombres, TD.doc_Numero,TP.per_DNI, TBV.Vaca_FechaSalida, TBV.Vaca_FechaTermino,
		TBV.Vaca_Dias
from tbdocumento_vacaciones as TBV 
inner join tbdocumento as TD on TBV.Vaca_doc_Cod = TD.doc_Codigo
inner join tbdocumento_ano as TDA on TDA.dan_Codigo = TD.doc_dan_Codigo
inner join tbusuario as TU on TD.doc_usu_Codigo = TU.usu_Codigo
inner join tbpersona as TP on TU.usu_per_Codigo = TP.per_Codigo
where TBV.Vaca_Codigo = @Codigo

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Area')
	drop procedure pa_Area
go

CREATE PROCEDURE [dbo].[pa_Area]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbarea
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

Go

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Cargo')
	drop procedure pa_Cargo
go

CREATE PROCEDURE [dbo].[pa_Cargo]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_cargo
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Departamento')
	drop procedure pa_Departamento
go

CREATE PROCEDURE [dbo].[pa_Departamento]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_departamento
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Distrito')
	drop procedure pa_Distrito
go

CREATE PROCEDURE [dbo].[pa_Distrito]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX),
	@Foranea VARCHAR(10)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_distrito
		WHERE dis_pro_Codigo = @Foranea
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

Go

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Grado')
	drop procedure pa_Grado
go

CREATE PROCEDURE [dbo].[pa_Grado]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_prefijo
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Provincia')
	drop procedure pa_Provincia
go

CREATE PROCEDURE [dbo].[pa_Provincia]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX),
	@Foranea VARCHAR(10)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_provincia
		WHERE pro_dep_Codigo = @Foranea
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Via')
	drop procedure pa_Via
go

CREATE PROCEDURE [dbo].[pa_Via]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_via
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='pa_Zona')
	drop procedure pa_Zona
go

CREATE PROCEDURE [dbo].[pa_Zona]
	@Tipo CHAR(2),
	@InfoXML VARCHAR(MAX)
AS
BEGIN
	declare @IDXML int
	
	if( @InfoXML <> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF( @Tipo = 'L')
	BEGIN
		SELECT * FROM tbpersona_zona
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='p_ReporteGastoMovilidadAreaPeriodo')
	drop procedure p_ReporteGastoMovilidadAreaPeriodo
go

create proc [dbo].[p_ReporteGastoMovilidadAreaPeriodo]
(
	@Area varchar(10),
	@FechaIni date,
	@FechaFin date
)
as
	SELECT * FROM fnGastosMovilidadXAreaXPeriodo(@Area,@FechaIni,@FechaFin)
GO

IF EXISTS(select * from SYS.PROCEDURES where NAME='p_ReporteGastosMovilidadXPeriodo')
	drop procedure p_ReporteGastosMovilidadXPeriodo
go

CREATE proc [dbo].[p_ReporteGastosMovilidadXPeriodo]
(
	@FechaIni date,
	@FechaFin date
)
as
	SELECT * FROM fnGastosMovilidadXPeriodo(@FechaIni,@FechaFin)
Go

IF EXISTS(select * from SYS.PROCEDURES where NAME='p_ReportePapeletasXAreaXMesXAnio')
	drop procedure p_ReportePapeletasXAreaXMesXAnio
go

create proc [dbo].[p_ReportePapeletasXAreaXMesXAnio]
(
	@A�o int
)
as
	select * from fnPapeletasXAreaXMesXAnio(2016)