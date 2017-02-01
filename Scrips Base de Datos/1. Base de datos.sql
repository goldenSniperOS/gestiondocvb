USE [master]
GO
/****** Object:  Database [BDGestionDocumentaria]    Script Date: 01/02/2017 11:12:25 a.m. ******/
CREATE DATABASE [BDGestionDocumentaria]
GO

USE [BDGestionDocumentaria]
GO
/****** Object:  StoredProcedure [dbo].[pa_GastoMovilidad]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
		SELECT  DISTINCT TOP 15 doc_Numero,doc_Gas_SerieCod,per_Apellidos,per_Nombres,are_Nombre,doc_Codigo FROM tbdocumento TD
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
		with(Gas_doc_Cod VARCHAR(10), Gas_Denegar CHAR(2))
		AS TablaLoca
		WHERE tbdocumento_gastomovilidad.Gas_Codigo = TablaLoca.Gas_doc_Cod

		UPDATE tbdocumento SET doc_ApruebaViat = case TablaLoca.Gas_Denegar when 'SI' then 'NO' else 'SI' end
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Gas_doc_Cod VARCHAR(10), Gas_Denegar CHAR(2))
		AS TablaLoca
		WHERE tbdocumento.doc_Codigo = TablaLoca.Gas_doc_Cod

		select 'GESTIONDOC' as MensajeTitulo, 'Gasto Aprobado' as MensajeProcedure
	 END 
	 if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END


/****** Object:  StoredProcedure [dbo].[pa_MantenimientoVacacion]    Script Date: 11/01/2017 10:55:38 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[pa_MantenimientoDocumento]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[pa_MantenimientoDocumento]
(
	@Tipo char(1),
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
		select doc_Codigo, doc_dpl_Codigo, doc_usu_Codigo, doc_Fecha, doc_Hora, doc_Numero, doc_dan_Codigo, doc_Titulo, doc_Remitente, doc_Destinatario, doc_Asunto, doc_Contenido, doc_Referencia, doc_Estado, doc_Actividad, doc_CodigoPresupues, doc_Meta, doc_DescargaDocumento, doc_ConfirmaFirma, doc_Firma, doc_Gas_SerieCod, doc_ApruebaMov, doc_ApruebaPape, doc_ApruebaViat
		from openXML(@IDXML, '/Dato/Principal',1)
		with(doc_Codigo varchar(10), doc_dpl_Codigo varchar(10), doc_usu_Codigo varchar(10),doc_Fecha date, doc_Hora time, 
			doc_Numero varchar(100), doc_dan_Codigo varchar(10), doc_Titulo varchar(50), doc_Remitente varchar(10), 
			doc_Destinatario varchar(10), doc_Asunto varchar(50), doc_Contenido varchar(8000), doc_Referencia varchar(50), 
			doc_Estado int, doc_Actividad varchar(500), doc_CodigoPresupues varchar(100), doc_Meta varchar(300), 
			doc_DescargaDocumento varchar(2), doc_ConfirmaFirma varchar(2), doc_Firma char(2), doc_Gas_SerieCod varchar(20),
			doc_ApruebaMov char(2), doc_ApruebaPape char(2), doc_ApruebaViat char(2))
			select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
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

/****** Object:  StoredProcedure [dbo].[pa_persona]    Script Date: 11/01/2017 10:56:11 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[pa_MantenimientoNotaContable]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[pa_MantenimientoNotaContable]
(
	@Tipo char(1),
	@InfoXML varchar(max)
)
AS 
BEGIN
	declare @IDXML int
	execute sp_xml_prepareDocument @IDXML output, @InfoXML

	IF (@Tipo = 'R')
	BEGIN
		
		INSERT INTO tbdocumento_notadecontabilidad (Ndcon_doc_Cod, Ndcon_Usuario, Ndcon_Fecha, Ndcon_Motivo, Ndcon_Subtotal, Ndcon_Denegar, Ndcon_Filialuno, Ndcon_Cargouno, Ndcon_Abonouno, Ndcon_Filialdos, Ndcon_Cargodos, Ndcon_Abonodos)
		SELECT Ndcon_doc_Cod, Ndcon_Usuario, Ndcon_Fecha, Ndcon_Motivo, Ndcon_Subtotal, Ndcon_Denegar, Ndcon_Filialuno, Ndcon_Cargouno, Ndcon_Abonouno, Ndcon_Filialdos, Ndcon_Cargodos, Ndcon_Abonodos
		from openXML(@IDXML, '/Dato/Principal',1)
		WITH(Ndcon_doc_Cod VARCHAR(10), Ndcon_Usuario VARCHAR(10), Ndcon_Fecha DATE, Ndcon_Motivo VARCHAR(30), Ndcon_Subtotal DECIMAL(9,2), Ndcon_Denegar char(2), Ndcon_Filialuno VARCHAR(30), Ndcon_Cargouno VARCHAR(30), Ndcon_Abonouno VARCHAR(30), Ndcon_Filialdos VARCHAR(30), Ndcon_Cargodos VARCHAR(30), Ndcon_Abonodos VARCHAR(30))
		
		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Modifico :D!!!...' as MensajeProcedure
	END
	IF(@InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
	
	IF(@Tipo= 'A')
	BEGIN
		UPDATE tbdocumento_notadecontabilidad set Ndcon_doc_Cod= TablaLoca.Ndcon_doc_Cod, Ndcon_Usuario=TablaLoca.Ndcon_Usuario, Ndcon_Fecha= TablaLoca.Ndcon_Fecha, Ndcon_Motivo = TablaLoca.Ndcon_Motivo, Ndcon_Subtotal = TablaLoca.Ndcon_Subtotal, Ndcon_Denegar = TablaLoca.Ndcon_Denegar, Ndcon_Filialuno = TablaLoca.Ndcon_Filialuno, Ndcon_Cargouno = TablaLoca.Ndcon_Cargouno, Ndcon_Abonouno = TablaLoca.Ndcon_Abonouno, Ndcon_Filialdos = TablaLoca.Ndcon_Filialdos, Ndcon_Cargodos = TablaLoca.Ndcon_Cargodos, Ndcon_Abonodos = TablaLoca.Ndcon_Abonodos
		FROM openXML(@IDXML, '/Dato/Principal',1) 
		WITH(Ndcon_Codigo INT, Ndcon_doc_Cod VARCHAR(10), Ndcon_Usuario VARCHAR(10), Ndcon_Fecha DATE, Ndcon_Motivo VARCHAR(30), Ndcon_Subtotal DECIMAL(9,2), Ndcon_Denegar char(2), Ndcon_Filialuno VARCHAR(30), Ndcon_Cargouno VARCHAR(30), Ndcon_Abonouno VARCHAR(30), Ndcon_Filialdos VARCHAR(30), Ndcon_Cargodos VARCHAR(30), Ndcon_Abonodos VARCHAR(30))
		AS TablaLoca
		WHERE tbdocumento_notadecontabilidad.Ndcon_Codigo = TablaLoca.Ndcon_Codigo
		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Modifico :D!!!...' as MensajeProcedure
	END
END


/****** Object:  StoredProcedure [dbo].[pa_TrabajadorPorArea]    Script Date: 11/01/2017 10:56:38 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[pa_MantenimientoPapeleta]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_MantenimientoPapeleta]
(
	@Tipo char(1),
	@InfoXML varchar(max)
)
AS
BEGIN
	declare @IDXML int
	IF (@Tipo = 'R')
	BEGIN
		insert into tbdocumento_papeleta(Pape_Codigo, Pape_doc_Cod, Pape_Motivo, Pape_Lugar, Pape_Justificacion, Pape_Retorno, Pape_Fecha, Pape_HoraSalida, Pape_HoraEntrada, Pape_ApruebaPapeRRHH, Pape_Observacion)
		select Pape_Codigo, Pape_doc_Cod, Pape_Motivo, Pape_Lugar, Pape_Justificacion, Pape_Retorno, Pape_Fecha, Pape_HoraSalida, Pape_HoraEntrada, Pape_ApruebaPapeRRHH, Pape_Observacion
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Pape_Codigo int, Pape_doc_Cod varchar(10), Pape_Motivo char(1), Pape_Lugar varchar(400), Pape_Justificacion varchar(400),
		Pape_Retorno char(2),Pape_Fecha date, Pape_HoraSalida time, Pape_HoraEntrada time , Pape_ApruebaPapeRRHH char(2), Pape_Observacion varchar(400))

			select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
	 END
	IF (@Tipo = 'L')
	BEGIN
	execute sp_xml_prepareDocument @IDXML output, @InfoXML
		SELECT per.per_Codigo, per.per_Nombres, per.per_Apellidos
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Area varchar(10))
		As TablaLoca
		INNER JOIN tbpersona_area par ON par.par_are_Codigo = TablaLoca.Area
		INNER JOIN tbpersona per ON per.per_Codigo = par.par_per_Codigo
	 execute sp_xml_RemoveDocument @IDXML	 
	END
	IF (@Tipo = 'LP')
	BEGIN
	execute sp_xml_prepareDocument @IDXML output, @InfoXML
		SELECT per.per_Nombres As Nombres, per.per_Apellidos As Apellidos, pape.Pape_Motivo As Motivo , 
		pape.Pape_Fecha As Fecha, pape.Pape_ApruebaPapeRRHH As Aprobado
		FROM tbpersona per INNER JOIN tbdocumento doc ON per.per_Codigo = doc.doc_Remitente
		INNER JOIN tbdocumento_papeleta pape ON pape.pape_doc_Cod = doc.doc_Codigo 
	 execute sp_xml_RemoveDocument @IDXML	 
	END
	 IF (@Tipo = 'I')
	 BEGIN
		SELECT TOP 1 (SELECT TOP 1 doc_Codigo FROM tbdocumento ORDER BY doc_Codigo DESC) AS doc_Codigo
		FROM tbdocumento
		WHERE doc_Titulo = 'DTI0000010'
		ORDER BY doc_Codigo DESC
	 END 
END



/****** Object:  StoredProcedure [dbo].[pa_GastoMovilidad]    Script Date: 11/01/2017 10:53:44 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[pa_MantenimientoVacacion]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_MantenimientoVacacion]
(
	@Tipo char(1),
	@InfoXML varchar(max)
)
AS 
BEGIN
	declare @IDXML int
	if( @InfoXML<> '')
	execute sp_xml_prepareDocument @IDXML output, @InfoXML
	IF (@Tipo = 'R')
	BEGIN
		insert into tbdocumento_vacaciones(Vaca_doc_Cod, Vaca_FechaSalida, Vaca_FechaTermino, Vaca_FechaRetorno, Vaca_Dias, Vaca_Pape_ApruebaJefe, Vaca_Pape_ApruebaRRHH, Vaca_Observacion)
		select Vaca_doc_Cod, Vaca_FechaSalida, Vaca_FechaTermino, Vaca_FechaRetorno, Vaca_Dias, Vaca_Pape_ApruebaJefe, Vaca_Pape_ApruebaRRHH, Vaca_Observacion
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Vaca_doc_Cod varchar(10), Vaca_FechaSalida date, Vaca_FechaTermino date, Vaca_FechaRetorno date, Vaca_Dias int,
			 Vaca_Pape_ApruebaJefe char(2), Vaca_Pape_ApruebaRRHH char(2), Vaca_Observacion varchar(200))

			select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
	 END
	 IF (@Tipo = 'A')
	 BEGIN
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

		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se modificio :D!!!...' as MensajeProcedure
	 END

	 IF (@Tipo = '1')
	 BEGIN
		SELECT TBV.Vaca_Codigo, Vaca_doc_Cod, Vaca_FechaSalida, Vaca_FechaTermino, Vaca_FechaRetorno, Vaca_Dias, Vaca_Pape_ApruebaJefe, Vaca_Pape_ApruebaRRHH, Vaca_Observacion
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Vaca_Codigo VARCHAR(10))
		AS TablaLoca
		INNER JOIN tbdocumento_vacaciones TBV ON TablaLoca.Vaca_Codigo = TBV.Vaca_Codigo

		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se modificio :D!!!...' as MensajeProcedure
	 END
	 
	 if(@InfoXML <> '')
	 execute sp_xml_RemoveDocument @IDXML	 
END

/****** Object:  StoredProcedure [dbo].[pa_MantenimientoDocumento]    Script Date: 11/01/2017 10:54:24 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[pa_persona]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
		insert into tbpersona(per_Codigo, per_TipoEmpresa, per_RazonSocial, per_prs_Codigo, per_RUC, per_ppr_Codigo, per_Nombres, per_Apellidos, per_Sexo, per_DNI, per_DNICaducidad, per_Nacimiento, per_pca_Codigo, per_Email, per_Telefono, per_pti_Codigo, per_pdi_Codigo, per_DiasVacaciones, per_CodPeople, per_EstadoCivil, per_Estudios, per_Actualizacion, per_Sede, per_Grupo)
		select per_Codigo, per_TipoEmpresa, per_RazonSocial, per_prs_Codigo, per_RUC, per_ppr_Codigo, per_Nombres, per_Apellidos, per_Sexo, per_DNI, per_DNICaducidad, per_Nacimiento, per_pca_Codigo, per_Email, per_Telefono, per_pti_Codigo, per_pdi_Codigo, per_DiasVacaciones, per_CodPeople, per_EstadoCivil, per_Estudios, per_Actualizacion, per_Sede, per_Grupo
		from openXML(@IDXML, '/Dato/Principal',1)
		with(per_Codigo varchar(10), per_TipoEmpresa varchar(20), per_RazonSocial varchar(50), per_prs_Codigo varchar(6), per_RUC varchar(11),
		 per_ppr_Codigo varchar(6), per_Nombres varchar(30), per_Apellidos varchar(30), per_Sexo char(1), per_DNI varchar(8), 
		 per_DNICaducidad date, per_Nacimiento date, per_pca_Codigo  varchar(6), per_Email varchar(50), per_Telefono int, 
		 per_pti_Codigo varchar(6), per_pdi_Codigo varchar(10), per_DiasVacaciones int, per_CodPeople varchar(10), per_EstadoCivil varchar(10), 
		 per_Estudios varchar(100), per_Actualizacion varchar(2), per_Sede varchar(10), per_Grupo varchar(10))
		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Registro :D!!!...' as MensajeProcedure
		execute sp_xml_RemoveDocument @IDXML
	 END
/*
	 IF (@Tipo = 'A')
	 BEGIN
		execute sp_xml_prepareDocument @IDXML output, @InfoXML
		UPDATE CLIENTE SET Dni = TablaLoca.Dni, Nombre=TablaLoca.Nombre, Apellidos = TablaLoca.Apellidos, Direccion = TablaLoca.Direccion, Telefono = TablaLoca.Telefono, Sexo = TablaLoca.Sexo, Edad =TablaLoca.Edad 
		from openXML(@IDXML, '/Dato/Principal',1)
		with(Id int, Dni char(8), Nombre varchar(20), Apellidos varchar(30),Direccion varchar(30), Telefono varchar(20), Sexo varchar(4), Edad int)
		AS TablaLoca
		WHERE CLIENTE.Id = TablaLoca.Id
		select 'CONECTIVIDAD' as MensajeTitulo, 'Exitosamente se Modifico :D!!!...' as MensajeProcedure
		execute sp_xml_RemoveDocument @IDXML
	 END*/
	 IF (@Tipo = 'L')
	 BEGIN
		SELECT per_Codigo, per_TipoEmpresa, per_RazonSocial, per_prs_Codigo, per_RUC, per_ppr_Codigo, per_Nombres, per_Apellidos, per_Sexo, per_DNI, per_DNICaducidad, per_Nacimiento, per_pca_Codigo, per_Email, per_Telefono, per_pti_Codigo, per_pdi_Codigo, per_DiasVacaciones, per_CodPeople, per_EstadoCivil, per_Estudios, per_Actualizacion, per_Sede, per_Grupo FROM tbpersona
	 END
END

/****** Object:  StoredProcedure [dbo].[pa_MantenimientoNotaContable]    Script Date: 11/01/2017 10:54:46 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[pa_Rol]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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

		SELECT 0 AS usu_mod_Id,0 AS usu_mod_Usuario,rol_mod_Modulo AS usu_mod_Modulo,'INSERT' AS Accion,mod_ID,mod_Nombre,mod_Padre,0 As usu_Codigo 
		FROM tbrol_modulo TA
		INNER JOIN tbmodulo ON mod_ID = rol_mod_Modulo
		INNER JOIN @liker E ON E.rol_mod_Rol = TA.rol_mod_Rol
	END

	if( @InfoXML <> '')
	execute sp_xml_RemoveDocument @IDXML
END

GO
/****** Object:  StoredProcedure [dbo].[pa_TrabajadorPorArea]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  StoredProcedure [dbo].[pa_Usuario]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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

		SELECT * FROM tbusuario AS U
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
		DECLARE @user TABLE (usu_Codigo VARCHAR(10),usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),usu_Estado BIT);

		INSERT INTO @allData 
		SELECT usu_mod_Id,usu_mod_Modulo,usu_mod_Usuario,Accion
		FROM openXML(@IDXML, '/Dato/Principal',1)
		WITH(usu_mod_Id INT,usu_mod_Modulo INT, usu_mod_Usuario VARCHAR(10), Accion VARCHAR(20))

		INSERT INTO @user 
		SELECT usu_Codigo,usu_Nombre, usu_Contrasena,usu_Estado
		FROM openXML(@IDXML, '/Dato/Usuario',1)
		WITH(usu_Codigo VARCHAR(10),usu_Nombre VARCHAR(20), usu_Contrasena VARCHAR(20),usu_Estado BIT)

		UPDATE tbusuario
		SET usu_Nombre = TA.usu_Nombre,
			usu_Contrasena = TA.usu_Contrasena,
			usu_Estado = TA.usu_Estado
		FROM tbusuario U
		INNER JOIN @user TA on U.usu_Codigo = TA.usu_Codigo

		INSERT INTO tbusuario_modulo
		SELECT  usu_mod_Usuario,usu_mod_Modulo
		FROM @allData
		WHERE Accion = 'INSERT'
			
		DELETE UM
		FROM tbusuario_modulo UM
		INNER JOIN (SELECT * FROM @allData WHERE Accion = 'DELETE') TA on UM.usu_mod_Id  = TA.usu_mod_Id

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

GO
/****** Object:  UserDefinedFunction [dbo].[nuevoCodigo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

GO
/****** Object:  UserDefinedFunction [dbo].[ultimoCodigo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[tbarea]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbarea](
	[are_Codigo] [varchar](10) NOT NULL,
	[are_Nombre] [varchar](120) NOT NULL,
	[are_NombreCorto] [varchar](14) NOT NULL,
	[are_Abreviatura] [char](4) NOT NULL,
	[are_Jefe] [varchar](10) NOT NULL,
	[are_Dependencia] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbarea] PRIMARY KEY CLUSTERED 
(
	[are_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbcarpeta_requerimiento]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbcarpeta_requerimiento](
	[req_Codigo] [varchar](10) NOT NULL,
	[req_Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbcarpeta_requerimiento] PRIMARY KEY CLUSTERED 
(
	[req_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbcarpeta_tipo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbcarpeta_tipo](
	[tip_Codigo] [varchar](10) NOT NULL,
	[tip_Documento] [varchar](100) NOT NULL,
	[tip_Programa] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbcarpeta_tipo] PRIMARY KEY CLUSTERED 
(
	[tip_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbcarpeta_tipo_requerimiento]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbcarpeta_tipo_requerimiento](
	[tir_Codigo] [varchar](10) NOT NULL,
	[tir_tip_Codigo] [varchar](10) NOT NULL,
	[tir_req_Codigo] [varchar](10) NOT NULL,
	[tir_Cantidad] [int] NOT NULL,
	[tir_Tipo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tbcarpeta_tipo_requerimiento] PRIMARY KEY CLUSTERED 
(
	[tir_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbcarpeta_tramite]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbcarpeta_tramite](
	[tra_Codigo] [varchar](10) NOT NULL,
	[tra_car_Codigo] [varchar](10) NOT NULL,
	[tra_Usuario] [varchar](10) NOT NULL,
	[tra_Observacion] [varchar](400) NOT NULL,
	[tra_AreaOrigen] [varchar](10) NOT NULL,
	[tra_CreateAt] [datetime] NOT NULL,
	[tra_AreaDestino] [varchar](10) NOT NULL,
	[tra_Motivo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbcarpeta_tramite] PRIMARY KEY CLUSTERED 
(
	[tra_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento](
	[doc_Codigo] [varchar](10) NOT NULL,
	[doc_dpl_Codigo] [varchar](10) NULL,
	[doc_usu_Codigo] [varchar](10) NULL,
	[doc_Fecha] [date] NULL,
	[doc_Hora] [time](7) NULL,
	[doc_Numero] [varchar](100) NULL,
	[doc_dan_Codigo] [varchar](10) NULL,
	[doc_Titulo] [varchar](50) NULL,
	[doc_Remitente] [varchar](10) NULL,
	[doc_Destinatario] [varchar](10) NULL,
	[doc_Asunto] [varchar](50) NULL,
	[doc_Contenido] [varchar](8000) NOT NULL,
	[doc_Referencia] [varchar](50) NULL,
	[doc_Estado] [int] NULL,
	[doc_Actividad] [varchar](500) NULL,
	[doc_CodigoPresupues] [varchar](100) NULL,
	[doc_Meta] [varchar](300) NULL,
	[doc_DescargaDocumento] [char](2) NULL,
	[doc_ConfirmaFirma] [char](2) NULL,
	[doc_Firma] [char](2) NULL,
	[doc_Gas_SerieCod] [varchar](20) NULL,
	[doc_ApruebaMov] [char](2) NULL,
	[doc_ApruebaPape] [char](2) NULL,
	[doc_ApruebaViat] [char](2) NOT NULL,
 CONSTRAINT [PK_tbdocumento] PRIMARY KEY CLUSTERED 
(
	[doc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_ano]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_ano](
	[dan_Codigo] [varchar](10) NOT NULL,
	[dan_Nombre] [varchar](150) NOT NULL,
	[dan_Numero] [int] NOT NULL,
 CONSTRAINT [PK_tbdocumento_ano] PRIMARY KEY CLUSTERED 
(
	[dan_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_carpeta]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_carpeta](
	[car_Codigo] [varchar](10) NOT NULL,
	[car_doc_Codigo] [varchar](10) NULL,
	[doc_alu_Codigo] [varchar](10) NOT NULL,
	[doc_FechaSustentacion] [date] NOT NULL,
	[doc_Sede] [varchar](100) NOT NULL,
	[doc_Estado] [varchar](10) NOT NULL,
	[doc_tip_Codigo] [varchar](10) NOT NULL,
	[doc_AreaActual] [varchar](10) NOT NULL,
	[doc_UltimoMotivoTramite] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbcarpeta_documento] PRIMARY KEY CLUSTERED 
(
	[car_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_cc]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_cc](
	[dcc_Codigo] [varchar](10) NOT NULL,
	[dcc_dhi_Codigo] [varchar](10) NULL,
	[dcc_doc_Codigo] [varchar](10) NULL,
	[dcc_are_Codigo] [varchar](10) NULL,
 CONSTRAINT [PK_tbdocumento_cc] PRIMARY KEY CLUSTERED 
(
	[dcc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_gastomovilidad]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_gastomovilidad](
	[Gas_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Gas_doc_Cod] [varchar](10) NOT NULL,
	[Gas_Usuario] [varchar](10) NOT NULL,
	[Gas_Fecha] [date] NOT NULL,
	[Gas_Motivo] [varchar](400) NOT NULL,
	[Gas_Ruta] [varchar](400) NOT NULL,
	[Gas_Subtotal] [decimal](9, 2) NOT NULL,
	[Gas_Tipo] [char](1) NOT NULL,
	[Gas_Denegar] [char](2) NULL,
 CONSTRAINT [PK_tbdocumento_gastomovilidad] PRIMARY KEY CLUSTERED 
(
	[Gas_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_historial]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_historial](
	[dhi_Codigo] [varchar](10) NOT NULL,
	[dhi_usu_Codigo] [varchar](10) NOT NULL,
	[dhi_doc_Codigo] [varchar](10) NOT NULL,
	[dhi_Fecha] [date] NOT NULL,
	[dhi_Hora] [time](7) NOT NULL,
	[dhi_FechaFin] [date] NULL,
	[dhi_HoraFin] [time](7) NULL,
	[dhi_Procedimiento] [varchar](12) NOT NULL,
	[dhi_are_Codigo] [varchar](10) NOT NULL,
	[dhi_are_CodigoRemitente] [varchar](10) NULL,
	[dhi_Mensaje] [varchar](300) NULL,
 CONSTRAINT [PK_tbdocumento_historial] PRIMARY KEY CLUSTERED 
(
	[dhi_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_notadecontabilidad]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_notadecontabilidad](
	[Ndcon_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Ndcon_doc_Cod] [varchar](10) NOT NULL,
	[Ndcon_Usuario] [varchar](10) NOT NULL,
	[Ndcon_Fecha] [date] NOT NULL,
	[Ndcon_Motivo] [varchar](150) NOT NULL,
	[Ndcon_Subtotal] [decimal](9, 2) NOT NULL,
	[Ndcon_Denegar] [char](2) NULL,
	[Ndcon_Filialuno] [varchar](30) NOT NULL,
	[Ndcon_Cargouno] [varchar](30) NOT NULL,
	[Ndcon_Abonouno] [varchar](30) NOT NULL,
	[Ndcon_Filialdos] [varchar](30) NULL,
	[Ndcon_Cargodos] [varchar](30) NULL,
	[Ndcon_Abonodos] [varchar](30) NULL,
 CONSTRAINT [PK_tbdocumento_notadecontabilidad] PRIMARY KEY CLUSTERED 
(
	[Ndcon_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_papeleta]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_papeleta](
	[Pape_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Pape_doc_Cod] [varchar](10) NOT NULL,
	[Pape_Motivo] [char](1) NOT NULL,
	[Pape_Lugar] [varchar](400) NOT NULL,
	[Pape_Justificacion] [varchar](400) NOT NULL,
	[Pape_Retorno] [char](2) NOT NULL,
	[Pape_Fecha] [date] NOT NULL,
	[Pape_HoraSalida] [time](7) NOT NULL,
	[Pape_HoraEntrada] [time](7) NOT NULL,
	[Pape_ApruebaPapeRRHH] [char](2) NOT NULL,
	[Pape_Observacion] [varchar](400) NOT NULL,
 CONSTRAINT [PK_tbdocumento_papeleta] PRIMARY KEY CLUSTERED 
(
	[Pape_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_plantilla]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_plantilla](
	[dpl_Codigo] [varchar](10) NOT NULL,
	[dpl_Nombre] [varchar](50) NOT NULL,
	[dpl_Interno] [char](2) NOT NULL,
	[dpl_Externo] [char](2) NOT NULL,
	[dpl_Ano] [char](2) NOT NULL,
	[dpl_Titulo] [char](2) NOT NULL,
	[dpl_Destinatario] [char](2) NOT NULL,
	[dpl_Remitente] [char](2) NOT NULL,
	[dpl_Asunto] [char](2) NOT NULL,
	[dpl_Fecha] [char](2) NOT NULL,
	[dpl_Contenido] [char](2) NOT NULL,
	[dpl_Adjunto] [char](2) NOT NULL,
 CONSTRAINT [PK_tbdocumento_plantilla] PRIMARY KEY CLUSTERED 
(
	[dpl_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_tipo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_tipo](
	[dti_Codigo] [varchar](10) NOT NULL,
	[dti_dpl_Codigo] [varchar](10) NOT NULL,
	[dti_Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbdocumento_tipo] PRIMARY KEY CLUSTERED 
(
	[dti_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_vacaciones]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_vacaciones](
	[Vaca_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Vaca_doc_Cod] [varchar](10) NOT NULL,
	[Vaca_FechaSalida] [date] NULL,
	[Vaca_FechaTermino] [date] NULL,
	[Vaca_FechaRetorno] [date] NULL,
	[Vaca_Dias] [int] NOT NULL,
	[Vaca_Pape_ApruebaJefe] [char](2) NOT NULL,
	[Vaca_Pape_ApruebaRRHH] [char](2) NOT NULL,
	[Vaca_Observacion] [varchar](200) NULL,
 CONSTRAINT [PK_tbdocumento_vacaciones] PRIMARY KEY CLUSTERED 
(
	[Vaca_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbmodulo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbmodulo](
	[mod_ID] [int] IDENTITY(1,1) NOT NULL,
	[mod_Nombre] [varchar](50) NULL,
	[mod_Padre] [int] NULL,
	[mod_Formulario] [varchar](50) NULL,
 CONSTRAINT [PK__tbmodulo__656687B6406B63B4] PRIMARY KEY CLUSTERED 
(
	[mod_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona](
	[per_Codigo] [varchar](10) NOT NULL,
	[per_TipoEmpresa] [varchar](20) NOT NULL,
	[per_RazonSocial] [varchar](50) NULL,
	[per_prs_Codigo] [varchar](6) NULL,
	[per_RUC] [varchar](11) NULL,
	[per_ppr_Codigo] [varchar](6) NOT NULL,
	[per_Nombres] [varchar](30) NOT NULL,
	[per_Apellidos] [varchar](30) NOT NULL,
	[per_Sexo] [char](1) NOT NULL,
	[per_DNI] [varchar](8) NOT NULL,
	[per_DNICaducidad] [date] NULL,
	[per_Nacimiento] [date] NULL,
	[per_pca_Codigo] [varchar](6) NOT NULL,
	[per_Email] [varchar](50) NULL,
	[per_Telefono] [int] NULL,
	[per_pti_Codigo] [varchar](6) NOT NULL,
	[per_pdi_Codigo] [varchar](10) NULL,
	[per_DiasVacaciones] [int] NOT NULL,
	[per_CodPeople] [varchar](10) NOT NULL,
	[per_EstadoCivil] [varchar](10) NOT NULL,
	[per_Estudios] [varchar](100) NOT NULL,
	[per_Actualizacion] [varchar](2) NOT NULL,
	[per_Sede] [varchar](10) NOT NULL,
	[per_Grupo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbpersona] PRIMARY KEY CLUSTERED 
(
	[per_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_area]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_area](
	[par_Codigo] [varchar](10) NOT NULL,
	[par_per_Codigo] [varchar](10) NOT NULL,
	[par_are_Codigo] [varchar](10) NOT NULL,
	[par_Estado] [int] NOT NULL,
 CONSTRAINT [PK_tbpersona_area] PRIMARY KEY CLUSTERED 
(
	[par_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_cargo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_cargo](
	[pca_Codigo] [varchar](6) NOT NULL,
	[pca_Nombre] [varchar](25) NOT NULL,
 CONSTRAINT [PK_tbpersona_cargo] PRIMARY KEY CLUSTERED 
(
	[pca_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_departamento]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_departamento](
	[dep_Codigo] [varchar](6) NOT NULL,
	[dep_CodigoCiudad] [varchar](3) NOT NULL,
	[dep_Nombre] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tbpersona_departamento] PRIMARY KEY CLUSTERED 
(
	[dep_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_direccion]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_direccion](
	[pdi_Codigo] [varchar](10) NOT NULL,
	[pdi_dis_Codigo] [varchar](7) NOT NULL,
	[pdi_pzo_Codigo] [varchar](6) NOT NULL,
	[pdi_NombreZona] [varchar](50) NULL,
	[pdi_pvi_Codigo] [varchar](6) NULL,
	[pdi_NombreVia] [varchar](50) NULL,
	[pdi_Numero] [int] NULL,
	[pdi_Piso] [int] NULL,
	[pdi_Interior] [varchar](2) NULL,
	[pdi_Manzana] [varchar](2) NULL,
	[pdi_Lote] [int] NULL,
 CONSTRAINT [PK_tbpersona_direccion] PRIMARY KEY CLUSTERED 
(
	[pdi_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_distrito]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_distrito](
	[dis_Codigo] [varchar](7) NOT NULL,
	[dis_pro_Codigo] [varchar](6) NOT NULL,
	[dis_Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbpersona_distrito] PRIMARY KEY CLUSTERED 
(
	[dis_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_prefijo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_prefijo](
	[ppr_Codigo] [varchar](6) NOT NULL,
	[ppr_Nombre] [varchar](20) NOT NULL,
	[ppr_Abreviatura] [varchar](6) NOT NULL,
 CONSTRAINT [PK_tbpersona_prefijo] PRIMARY KEY CLUSTERED 
(
	[ppr_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_provincia]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_provincia](
	[pro_Codigo] [varchar](6) NOT NULL,
	[pro_dep_Codigo] [varchar](6) NOT NULL,
	[pro_Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbpersona_provincia] PRIMARY KEY CLUSTERED 
(
	[pro_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_razonsocial]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_razonsocial](
	[prs_Codigo] [varchar](6) NOT NULL,
	[prs_Nombre] [varchar](30) NOT NULL,
	[prs_Abreviatura] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbpersona_razonsocial] PRIMARY KEY CLUSTERED 
(
	[prs_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_tipo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_tipo](
	[pti_Codigo] [varchar](6) NOT NULL,
	[pti_Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tbpersona_tipo] PRIMARY KEY CLUSTERED 
(
	[pti_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_via]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_via](
	[pvi_Codigo] [varchar](6) NOT NULL,
	[pvi_Nombre] [varchar](15) NOT NULL,
	[pvi_Abreviatura] [varchar](5) NOT NULL,
 CONSTRAINT [PK_tbpersona_via] PRIMARY KEY CLUSTERED 
(
	[pvi_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_zona]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona_zona](
	[pzo_Codigo] [varchar](6) NOT NULL,
	[pzo_Nombre] [varchar](30) NOT NULL,
	[pzo_Abreviatura] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbpersona_zona] PRIMARY KEY CLUSTERED 
(
	[pzo_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbrol]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbrol](
	[rol_Id] [int] IDENTITY(1,1) NOT NULL,
	[rol_Descripcion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[rol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbrol_modulo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbrol_modulo](
	[rol_mod_Id] [int] IDENTITY(1,1) NOT NULL,
	[rol_mod_Rol] [int] NULL,
	[rol_mod_Modulo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[rol_mod_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbusuario]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbusuario](
	[usu_Codigo] [varchar](10) NOT NULL,
	[usu_per_Codigo] [varchar](10) NOT NULL,
	[usu_Nombre] [varchar](20) NOT NULL,
	[usu_Contrasena] [varchar](20) NOT NULL,
	[usu_Estado] [bit] NULL,
	[usu_Digitalizacion] [char](2) NOT NULL,
	[usu_Tramite] [char](2) NOT NULL,
	[usu_Requisito] [char](2) NULL,
	[usu_Persona] [char](2) NOT NULL,
	[usu_Mantenimiento] [char](2) NOT NULL,
	[usu_Reporte] [char](2) NOT NULL,
	[usu_Papeleta] [char](2) NOT NULL,
	[usu_Vacaciones] [char](2) NULL,
	[usu_Beneficio] [char](2) NOT NULL,
	[usu_Marcacion] [char](2) NOT NULL,
	[usu_NotaContable] [char](2) NOT NULL,
	[usu_Sesion] [char](1) NOT NULL,
 CONSTRAINT [PK_tbusuario] PRIMARY KEY CLUSTERED 
(
	[usu_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbusuario_modulo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbusuario_modulo](
	[usu_mod_Id] [int] IDENTITY(1,1) NOT NULL,
	[usu_mod_Usuario] [varchar](10) NULL,
	[usu_mod_Modulo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[usu_mod_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbusuario_rol]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbusuario_rol](
	[usu_rol_Id] [int] IDENTITY(1,1) NOT NULL,
	[usu_rol_Rol] [int] NULL,
	[usu_rol_Usuario] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[usu_rol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[fnGastosMovilidadXAreaXPeriodo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  UserDefinedFunction [dbo].[fnGastosMovilidadXPeriodo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  UserDefinedFunction [dbo].[fnNotasContablesXFilialXMesXAnio]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnNotasContablesXFilialXMesXAnio](@anio int)
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
/****** Object:  UserDefinedFunction [dbo].[fnNotasXFilialesXPeriodo]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnNotasXFilialesXPeriodo] (@diaInicio DATE,@diaFin DATE)
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
/****** Object:  UserDefinedFunction [dbo].[fnPapeletasXAreaXMesXAnio]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  UserDefinedFunction [dbo].[fnPapeletasXMes]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  UserDefinedFunction [dbo].[fnVacacionesXArea]    Script Date: 01/02/2017 11:12:28 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
ALTER TABLE [dbo].[tbcarpeta_tipo_requerimiento] ADD  DEFAULT ('') FOR [tir_Tipo]
GO
ALTER TABLE [dbo].[tbcarpeta_tramite] ADD  DEFAULT ('Sin Observacion') FOR [tra_Observacion]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('') FOR [doc_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_dpl_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_usu_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Fecha]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Hora]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Numero]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_dan_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Titulo]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Remitente]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Destinatario]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Asunto]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Referencia]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('0') FOR [doc_Estado]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Actividad]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_CodigoPresupues]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Meta]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('NO') FOR [doc_DescargaDocumento]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('NO') FOR [doc_ConfirmaFirma]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('NO') FOR [doc_Firma]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT (NULL) FOR [doc_Gas_SerieCod]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('NO') FOR [doc_ApruebaMov]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('NO') FOR [doc_ApruebaPape]
GO
ALTER TABLE [dbo].[tbdocumento] ADD  DEFAULT ('NO') FOR [doc_ApruebaViat]
GO
ALTER TABLE [dbo].[tbdocumento_carpeta] ADD  CONSTRAINT [DF__tbcarpeta__doc_E__15502E78]  DEFAULT ('NUEVO') FOR [doc_Estado]
GO
ALTER TABLE [dbo].[tbdocumento_cc] ADD  DEFAULT (NULL) FOR [dcc_dhi_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento_cc] ADD  DEFAULT (NULL) FOR [dcc_doc_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento_cc] ADD  DEFAULT (NULL) FOR [dcc_are_Codigo]
GO
ALTER TABLE [dbo].[tbdocumento_gastomovilidad] ADD  CONSTRAINT [DF__tbdocumen__Gas_D__6FE99F9F]  DEFAULT ('NO') FOR [Gas_Denegar]
GO
ALTER TABLE [dbo].[tbdocumento_historial] ADD  DEFAULT (NULL) FOR [dhi_FechaFin]
GO
ALTER TABLE [dbo].[tbdocumento_historial] ADD  DEFAULT (NULL) FOR [dhi_HoraFin]
GO
ALTER TABLE [dbo].[tbdocumento_historial] ADD  DEFAULT (NULL) FOR [dhi_are_CodigoRemitente]
GO
ALTER TABLE [dbo].[tbdocumento_historial] ADD  DEFAULT (NULL) FOR [dhi_Mensaje]
GO
ALTER TABLE [dbo].[tbdocumento_notadecontabilidad] ADD  CONSTRAINT [DF__tbdocumen__Ndcon__74AE54BC]  DEFAULT ('NO') FOR [Ndcon_Denegar]
GO
ALTER TABLE [dbo].[tbdocumento_notadecontabilidad] ADD  CONSTRAINT [DF__tbdocumen__Ndcon__75A278F5]  DEFAULT (NULL) FOR [Ndcon_Filialdos]
GO
ALTER TABLE [dbo].[tbdocumento_notadecontabilidad] ADD  CONSTRAINT [DF__tbdocumen__Ndcon__76969D2E]  DEFAULT (NULL) FOR [Ndcon_Cargodos]
GO
ALTER TABLE [dbo].[tbdocumento_notadecontabilidad] ADD  CONSTRAINT [DF__tbdocumen__Ndcon__778AC167]  DEFAULT (NULL) FOR [Ndcon_Abonodos]
GO
ALTER TABLE [dbo].[tbdocumento_papeleta] ADD  CONSTRAINT [DF__tbdocumen__Pape___787EE5A0]  DEFAULT ('NO') FOR [Pape_ApruebaPapeRRHH]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] ADD  CONSTRAINT [DF__tbdocumen__Vaca___797309D9]  DEFAULT (NULL) FOR [Vaca_FechaSalida]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] ADD  CONSTRAINT [DF__tbdocumen__Vaca___7A672E12]  DEFAULT (NULL) FOR [Vaca_FechaTermino]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] ADD  CONSTRAINT [DF__tbdocumen__Vaca___7B5B524B]  DEFAULT (NULL) FOR [Vaca_FechaRetorno]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] ADD  CONSTRAINT [DF__tbdocumen__Vaca___7C4F7684]  DEFAULT ('NO') FOR [Vaca_Pape_ApruebaJefe]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] ADD  CONSTRAINT [DF__tbdocumen__Vaca___7D439ABD]  DEFAULT ('NO') FOR [Vaca_Pape_ApruebaRRHH]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] ADD  CONSTRAINT [DF__tbdocumen__Vaca___7E37BEF6]  DEFAULT (NULL) FOR [Vaca_Observacion]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_RazonSocial]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_prs_Codigo]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_RUC]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_DNICaducidad]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_Nacimiento]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_Email]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_Telefono]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT (NULL) FOR [per_pdi_Codigo]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT ('0') FOR [per_DiasVacaciones]
GO
ALTER TABLE [dbo].[tbpersona] ADD  DEFAULT ('NO') FOR [per_Actualizacion]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_NombreZona]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_pvi_Codigo]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_NombreVia]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_Numero]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_Piso]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_Interior]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_Manzana]
GO
ALTER TABLE [dbo].[tbpersona_direccion] ADD  DEFAULT (NULL) FOR [pdi_Lote]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF_tbusuario_usu_Estado]  DEFAULT ((1)) FOR [usu_Estado]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_D__02084FDA]  DEFAULT ('NO') FOR [usu_Digitalizacion]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_T__02FC7413]  DEFAULT ('SI') FOR [usu_Tramite]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_R__03F0984C]  DEFAULT ('NO') FOR [usu_Requisito]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_P__04E4BC85]  DEFAULT ('NO') FOR [usu_Persona]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_M__05D8E0BE]  DEFAULT ('NO') FOR [usu_Mantenimiento]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_R__06CD04F7]  DEFAULT ('NO') FOR [usu_Reporte]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_P__07C12930]  DEFAULT ('NO') FOR [usu_Papeleta]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_V__08B54D69]  DEFAULT ('NO') FOR [usu_Vacaciones]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_B__09A971A2]  DEFAULT ('NO') FOR [usu_Beneficio]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_M__0A9D95DB]  DEFAULT ('NO') FOR [usu_Marcacion]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_N__0B91BA14]  DEFAULT ('NO') FOR [usu_NotaContable]
GO
ALTER TABLE [dbo].[tbusuario] ADD  CONSTRAINT [DF__tbusuario__usu_S__0C85DE4D]  DEFAULT ('0') FOR [usu_Sesion]
GO
ALTER TABLE [dbo].[tbcarpeta_tipo_requerimiento]  WITH CHECK ADD  CONSTRAINT [FK_tip_tbtip_req_req] FOREIGN KEY([tir_req_Codigo])
REFERENCES [dbo].[tbcarpeta_requerimiento] ([req_Codigo])
GO
ALTER TABLE [dbo].[tbcarpeta_tipo_requerimiento] CHECK CONSTRAINT [FK_tip_tbtip_req_req]
GO
ALTER TABLE [dbo].[tbcarpeta_tipo_requerimiento]  WITH CHECK ADD  CONSTRAINT [FK_tip_tbtip_req_tip] FOREIGN KEY([tir_tip_Codigo])
REFERENCES [dbo].[tbcarpeta_tipo] ([tip_Codigo])
GO
ALTER TABLE [dbo].[tbcarpeta_tipo_requerimiento] CHECK CONSTRAINT [FK_tip_tbtip_req_tip]
GO
ALTER TABLE [dbo].[tbcarpeta_tramite]  WITH CHECK ADD  CONSTRAINT [FK_doc_tbtra] FOREIGN KEY([tra_car_Codigo])
REFERENCES [dbo].[tbdocumento_carpeta] ([car_Codigo])
GO
ALTER TABLE [dbo].[tbcarpeta_tramite] CHECK CONSTRAINT [FK_doc_tbtra]
GO
ALTER TABLE [dbo].[tbdocumento]  WITH CHECK ADD  CONSTRAINT [FK_dan_doc] FOREIGN KEY([doc_dan_Codigo])
REFERENCES [dbo].[tbdocumento_ano] ([dan_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento] CHECK CONSTRAINT [FK_dan_doc]
GO
ALTER TABLE [dbo].[tbdocumento]  WITH CHECK ADD  CONSTRAINT [FK_dpl_doc] FOREIGN KEY([doc_dpl_Codigo])
REFERENCES [dbo].[tbdocumento_plantilla] ([dpl_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento] CHECK CONSTRAINT [FK_dpl_doc]
GO
ALTER TABLE [dbo].[tbdocumento]  WITH CHECK ADD  CONSTRAINT [FK_usu_doc] FOREIGN KEY([doc_usu_Codigo])
REFERENCES [dbo].[tbusuario] ([usu_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento] CHECK CONSTRAINT [FK_usu_doc]
GO
ALTER TABLE [dbo].[tbdocumento_carpeta]  WITH CHECK ADD  CONSTRAINT [FK_tbdocumento_carpeta_tbcarpeta_tipo] FOREIGN KEY([doc_tip_Codigo])
REFERENCES [dbo].[tbcarpeta_tipo] ([tip_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_carpeta] CHECK CONSTRAINT [FK_tbdocumento_carpeta_tbcarpeta_tipo]
GO
ALTER TABLE [dbo].[tbdocumento_carpeta]  WITH CHECK ADD  CONSTRAINT [FK_tbdocumento_carpeta_tbdocumento] FOREIGN KEY([car_doc_Codigo])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_carpeta] CHECK CONSTRAINT [FK_tbdocumento_carpeta_tbdocumento]
GO
ALTER TABLE [dbo].[tbdocumento_carpeta]  WITH CHECK ADD  CONSTRAINT [FK_tbdocumento_carpeta_tbpersona] FOREIGN KEY([doc_alu_Codigo])
REFERENCES [dbo].[tbpersona] ([per_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_carpeta] CHECK CONSTRAINT [FK_tbdocumento_carpeta_tbpersona]
GO
ALTER TABLE [dbo].[tbdocumento_cc]  WITH CHECK ADD  CONSTRAINT [FK_are_dcc] FOREIGN KEY([dcc_are_Codigo])
REFERENCES [dbo].[tbarea] ([are_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_cc] CHECK CONSTRAINT [FK_are_dcc]
GO
ALTER TABLE [dbo].[tbdocumento_cc]  WITH CHECK ADD  CONSTRAINT [FK_dhi_dcc] FOREIGN KEY([dcc_dhi_Codigo])
REFERENCES [dbo].[tbdocumento_historial] ([dhi_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_cc] CHECK CONSTRAINT [FK_dhi_dcc]
GO
ALTER TABLE [dbo].[tbdocumento_cc]  WITH CHECK ADD  CONSTRAINT [FK_doc_dcc] FOREIGN KEY([dcc_doc_Codigo])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_cc] CHECK CONSTRAINT [FK_doc_dcc]
GO
ALTER TABLE [dbo].[tbdocumento_gastomovilidad]  WITH CHECK ADD  CONSTRAINT [FK_tbdocumento_gastomovilidad_tbdocumento] FOREIGN KEY([Gas_doc_Cod])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_gastomovilidad] CHECK CONSTRAINT [FK_tbdocumento_gastomovilidad_tbdocumento]
GO
ALTER TABLE [dbo].[tbdocumento_historial]  WITH CHECK ADD  CONSTRAINT [FK_are_dhi] FOREIGN KEY([dhi_are_Codigo])
REFERENCES [dbo].[tbarea] ([are_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_historial] CHECK CONSTRAINT [FK_are_dhi]
GO
ALTER TABLE [dbo].[tbdocumento_historial]  WITH CHECK ADD  CONSTRAINT [FK_doc_dhi] FOREIGN KEY([dhi_doc_Codigo])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_historial] CHECK CONSTRAINT [FK_doc_dhi]
GO
ALTER TABLE [dbo].[tbdocumento_historial]  WITH CHECK ADD  CONSTRAINT [FK_usu_dhi] FOREIGN KEY([dhi_usu_Codigo])
REFERENCES [dbo].[tbusuario] ([usu_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_historial] CHECK CONSTRAINT [FK_usu_dhi]
GO
ALTER TABLE [dbo].[tbdocumento_notadecontabilidad]  WITH CHECK ADD  CONSTRAINT [FK_doc_Ndcon] FOREIGN KEY([Ndcon_doc_Cod])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_notadecontabilidad] CHECK CONSTRAINT [FK_doc_Ndcon]
GO
ALTER TABLE [dbo].[tbdocumento_papeleta]  WITH CHECK ADD  CONSTRAINT [FK_doc_Pape] FOREIGN KEY([Pape_doc_Cod])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_papeleta] CHECK CONSTRAINT [FK_doc_Pape]
GO
ALTER TABLE [dbo].[tbdocumento_tipo]  WITH CHECK ADD  CONSTRAINT [FK_dpl_dti] FOREIGN KEY([dti_dpl_Codigo])
REFERENCES [dbo].[tbdocumento_plantilla] ([dpl_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_tipo] CHECK CONSTRAINT [FK_dpl_dti]
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_Vaca] FOREIGN KEY([Vaca_doc_Cod])
REFERENCES [dbo].[tbdocumento] ([doc_Codigo])
GO
ALTER TABLE [dbo].[tbdocumento_vacaciones] CHECK CONSTRAINT [FK_doc_Vaca]
GO
ALTER TABLE [dbo].[tbpersona]  WITH CHECK ADD  CONSTRAINT [FK_pca_per] FOREIGN KEY([per_pca_Codigo])
REFERENCES [dbo].[tbpersona_cargo] ([pca_Codigo])
GO
ALTER TABLE [dbo].[tbpersona] CHECK CONSTRAINT [FK_pca_per]
GO
ALTER TABLE [dbo].[tbpersona]  WITH CHECK ADD  CONSTRAINT [FK_pdi_per] FOREIGN KEY([per_pdi_Codigo])
REFERENCES [dbo].[tbpersona_direccion] ([pdi_Codigo])
GO
ALTER TABLE [dbo].[tbpersona] CHECK CONSTRAINT [FK_pdi_per]
GO
ALTER TABLE [dbo].[tbpersona]  WITH CHECK ADD  CONSTRAINT [FK_ppr_per] FOREIGN KEY([per_ppr_Codigo])
REFERENCES [dbo].[tbpersona_prefijo] ([ppr_Codigo])
GO
ALTER TABLE [dbo].[tbpersona] CHECK CONSTRAINT [FK_ppr_per]
GO
ALTER TABLE [dbo].[tbpersona]  WITH CHECK ADD  CONSTRAINT [FK_prs_per] FOREIGN KEY([per_prs_Codigo])
REFERENCES [dbo].[tbpersona_razonsocial] ([prs_Codigo])
GO
ALTER TABLE [dbo].[tbpersona] CHECK CONSTRAINT [FK_prs_per]
GO
ALTER TABLE [dbo].[tbpersona]  WITH CHECK ADD  CONSTRAINT [FK_pti_per] FOREIGN KEY([per_pti_Codigo])
REFERENCES [dbo].[tbpersona_tipo] ([pti_Codigo])
GO
ALTER TABLE [dbo].[tbpersona] CHECK CONSTRAINT [FK_pti_per]
GO
ALTER TABLE [dbo].[tbpersona_area]  WITH CHECK ADD  CONSTRAINT [FK_are_par] FOREIGN KEY([par_are_Codigo])
REFERENCES [dbo].[tbarea] ([are_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_area] CHECK CONSTRAINT [FK_are_par]
GO
ALTER TABLE [dbo].[tbpersona_area]  WITH CHECK ADD  CONSTRAINT [FK_per_par] FOREIGN KEY([par_per_Codigo])
REFERENCES [dbo].[tbpersona] ([per_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_area] CHECK CONSTRAINT [FK_per_par]
GO
ALTER TABLE [dbo].[tbpersona_direccion]  WITH CHECK ADD  CONSTRAINT [FK_dis_pdi] FOREIGN KEY([pdi_dis_Codigo])
REFERENCES [dbo].[tbpersona_distrito] ([dis_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_direccion] CHECK CONSTRAINT [FK_dis_pdi]
GO
ALTER TABLE [dbo].[tbpersona_direccion]  WITH CHECK ADD  CONSTRAINT [FK_pvi_pdi] FOREIGN KEY([pdi_pvi_Codigo])
REFERENCES [dbo].[tbpersona_via] ([pvi_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_direccion] CHECK CONSTRAINT [FK_pvi_pdi]
GO
ALTER TABLE [dbo].[tbpersona_direccion]  WITH CHECK ADD  CONSTRAINT [FK_pzo_pdi] FOREIGN KEY([pdi_pzo_Codigo])
REFERENCES [dbo].[tbpersona_zona] ([pzo_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_direccion] CHECK CONSTRAINT [FK_pzo_pdi]
GO
ALTER TABLE [dbo].[tbpersona_distrito]  WITH CHECK ADD  CONSTRAINT [FK_pro_dis] FOREIGN KEY([dis_pro_Codigo])
REFERENCES [dbo].[tbpersona_provincia] ([pro_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_distrito] CHECK CONSTRAINT [FK_pro_dis]
GO
ALTER TABLE [dbo].[tbpersona_provincia]  WITH CHECK ADD  CONSTRAINT [FK_dep_pro] FOREIGN KEY([pro_dep_Codigo])
REFERENCES [dbo].[tbpersona_departamento] ([dep_Codigo])
GO
ALTER TABLE [dbo].[tbpersona_provincia] CHECK CONSTRAINT [FK_dep_pro]
GO
ALTER TABLE [dbo].[tbusuario]  WITH CHECK ADD  CONSTRAINT [FK_per_usu] FOREIGN KEY([usu_per_Codigo])
REFERENCES [dbo].[tbpersona] ([per_Codigo])
GO
ALTER TABLE [dbo].[tbusuario] CHECK CONSTRAINT [FK_per_usu]
GO
USE [master]
GO
ALTER DATABASE [BDGestionDocumentaria] SET  READ_WRITE 
GO
