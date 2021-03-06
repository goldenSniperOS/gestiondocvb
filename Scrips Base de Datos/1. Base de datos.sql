CREATE DATABASE [BDGestionDocumentaria]
GO

USE [BDGestionDocumentaria]
GO
/****** Object:  Table [dbo].[tbarea]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbcarpeta_requerimiento]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbcarpeta_tipo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbcarpeta_tipo_requerimiento]    Script Date: 12/02/2017 15:40:45 ******/
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
	[tir_Tipo] [varchar](20) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_tbcarpeta_tipo_requerimiento] PRIMARY KEY CLUSTERED 
(
	[tir_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbcarpeta_tramite]    Script Date: 12/02/2017 15:40:45 ******/
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
	[tra_Observacion] [varchar](400) NOT NULL DEFAULT ('Sin Observacion'),
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
/****** Object:  Table [dbo].[tbdocumento]    Script Date: 12/02/2017 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento](
	[doc_Codigo] [varchar](10) NOT NULL DEFAULT (''),
	[doc_dpl_Codigo] [varchar](10) NULL DEFAULT (NULL),
	[doc_usu_Codigo] [varchar](10) NULL DEFAULT (NULL),
	[doc_Fecha] [date] NULL DEFAULT (NULL),
	[doc_Hora] [time](7) NULL DEFAULT (NULL),
	[doc_Numero] [varchar](100) NULL DEFAULT (NULL),
	[doc_dan_Codigo] [varchar](10) NULL DEFAULT (NULL),
	[doc_Titulo] [varchar](50) NULL DEFAULT (NULL),
	[doc_Remitente] [varchar](10) NULL DEFAULT (NULL),
	[doc_Destinatario] [varchar](10) NULL DEFAULT (NULL),
	[doc_Asunto] [varchar](50) NULL DEFAULT (NULL),
	[doc_Contenido] [varchar](8000) NOT NULL,
	[doc_Referencia] [varchar](50) NULL DEFAULT (NULL),
	[doc_Estado] [int] NULL DEFAULT ('0'),
	[doc_Actividad] [varchar](500) NULL DEFAULT (NULL),
	[doc_CodigoPresupues] [varchar](100) NULL DEFAULT (NULL),
	[doc_Meta] [varchar](300) NULL DEFAULT (NULL),
	[doc_DescargaDocumento] [char](2) NULL DEFAULT ('NO'),
	[doc_ConfirmaFirma] [char](2) NULL DEFAULT ('NO'),
	[doc_Firma] [char](2) NULL DEFAULT ('NO'),
	[doc_Gas_SerieCod] [varchar](20) NULL DEFAULT (NULL),
	[doc_ApruebaMov] [char](2) NULL DEFAULT ('NO'),
	[doc_ApruebaPape] [char](2) NULL DEFAULT ('NO'),
	[doc_ApruebaViat] [char](2) NOT NULL DEFAULT ('NO'),
 CONSTRAINT [PK_tbdocumento] PRIMARY KEY CLUSTERED 
(
	[doc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_ano]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbdocumento_carpeta]    Script Date: 12/02/2017 15:40:45 ******/
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
	[doc_Estado] [varchar](10) NOT NULL CONSTRAINT [DF__tbcarpeta__doc_E__15502E78]  DEFAULT ('NUEVO'),
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
/****** Object:  Table [dbo].[tbdocumento_cc]    Script Date: 12/02/2017 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_cc](
	[dcc_Codigo] [varchar](10) NOT NULL,
	[dcc_dhi_Codigo] [varchar](10) NULL DEFAULT (NULL),
	[dcc_doc_Codigo] [varchar](10) NULL DEFAULT (NULL),
	[dcc_are_Codigo] [varchar](10) NULL DEFAULT (NULL),
 CONSTRAINT [PK_tbdocumento_cc] PRIMARY KEY CLUSTERED 
(
	[dcc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_gastomovilidad]    Script Date: 12/02/2017 15:40:45 ******/
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
	[Gas_Denegar] [char](2) NULL CONSTRAINT [DF__tbdocumen__Gas_D__6FE99F9F]  DEFAULT ('NO'),
 CONSTRAINT [PK_tbdocumento_gastomovilidad] PRIMARY KEY CLUSTERED 
(
	[Gas_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_historial]    Script Date: 12/02/2017 15:40:45 ******/
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
	[dhi_FechaFin] [date] NULL DEFAULT (NULL),
	[dhi_HoraFin] [time](7) NULL DEFAULT (NULL),
	[dhi_Procedimiento] [varchar](12) NOT NULL,
	[dhi_are_Codigo] [varchar](10) NOT NULL,
	[dhi_are_CodigoRemitente] [varchar](10) NULL DEFAULT (NULL),
	[dhi_Mensaje] [varchar](300) NULL DEFAULT (NULL),
 CONSTRAINT [PK_tbdocumento_historial] PRIMARY KEY CLUSTERED 
(
	[dhi_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_papeleta]    Script Date: 12/02/2017 15:40:45 ******/
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
	[Pape_ApruebaPapeRRHH] [char](2) NOT NULL CONSTRAINT [DF__tbdocumen__Pape___787EE5A0]  DEFAULT ('NO'),
	[Pape_Observacion] [varchar](400) NOT NULL,
 CONSTRAINT [PK_tbdocumento_papeleta] PRIMARY KEY CLUSTERED 
(
	[Pape_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbdocumento_plantilla]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbdocumento_tipo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbdocumento_vacaciones]    Script Date: 12/02/2017 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbdocumento_vacaciones](
	[Vaca_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Vaca_doc_Cod] [varchar](10) NOT NULL,
	[Vaca_FechaSalida] [date] NULL CONSTRAINT [DF__tbdocumen__Vaca___797309D9]  DEFAULT (NULL),
	[Vaca_FechaTermino] [date] NULL CONSTRAINT [DF__tbdocumen__Vaca___7A672E12]  DEFAULT (NULL),
	[Vaca_FechaRetorno] [date] NULL CONSTRAINT [DF__tbdocumen__Vaca___7B5B524B]  DEFAULT (NULL),
	[Vaca_Dias] [int] NOT NULL,
	[Vaca_Pape_ApruebaJefe] [char](2) NOT NULL CONSTRAINT [DF__tbdocumen__Vaca___7C4F7684]  DEFAULT ('NO'),
	[Vaca_Pape_ApruebaRRHH] [char](2) NOT NULL CONSTRAINT [DF__tbdocumen__Vaca___7D439ABD]  DEFAULT ('NO'),
	[Vaca_Observacion] [varchar](200) NULL CONSTRAINT [DF__tbdocumen__Vaca___7E37BEF6]  DEFAULT (NULL),
 CONSTRAINT [PK_tbdocumento_vacaciones] PRIMARY KEY CLUSTERED 
(
	[Vaca_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbmodulo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona]    Script Date: 12/02/2017 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbpersona](
	[per_Codigo] [varchar](10) NOT NULL,
	[per_TipoEmpresa] [varchar](20) NOT NULL,
	[per_RazonSocial] [varchar](50) NULL DEFAULT (NULL),
	[per_prs_Codigo] [varchar](6) NULL DEFAULT (NULL),
	[per_RUC] [varchar](11) NULL DEFAULT (NULL),
	[per_ppr_Codigo] [varchar](6) NOT NULL,
	[per_Nombres] [varchar](30) NOT NULL,
	[per_Apellidos] [varchar](30) NOT NULL,
	[per_Sexo] [char](1) NOT NULL,
	[per_DNI] [varchar](8) NOT NULL,
	[per_DNICaducidad] [date] NULL DEFAULT (NULL),
	[per_Nacimiento] [date] NULL DEFAULT (NULL),
	[per_pca_Codigo] [varchar](6) NOT NULL,
	[per_Email] [varchar](50) NULL DEFAULT (NULL),
	[per_Telefono] [int] NULL DEFAULT (NULL),
	[per_pti_Codigo] [varchar](6) NOT NULL,
	[per_pdi_Codigo] [varchar](10) NULL DEFAULT (NULL),
	[per_DiasVacaciones] [int] NOT NULL DEFAULT ('0'),
	[per_CodPeople] [varchar](10) NOT NULL,
	[per_EstadoCivil] [varchar](10) NOT NULL,
	[per_Estudios] [varchar](100) NOT NULL,
	[per_Actualizacion] [varchar](2) NOT NULL DEFAULT ('NO'),
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
/****** Object:  Table [dbo].[tbpersona_area]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_cargo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_departamento]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_direccion]    Script Date: 12/02/2017 15:40:45 ******/
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
	[pdi_NombreZona] [varchar](50) NULL DEFAULT (NULL),
	[pdi_pvi_Codigo] [varchar](6) NULL DEFAULT (NULL),
	[pdi_NombreVia] [varchar](50) NULL DEFAULT (NULL),
	[pdi_Numero] [int] NULL DEFAULT (NULL),
	[pdi_Piso] [int] NULL DEFAULT (NULL),
	[pdi_Interior] [varchar](2) NULL DEFAULT (NULL),
	[pdi_Manzana] [varchar](2) NULL DEFAULT (NULL),
	[pdi_Lote] [int] NULL DEFAULT (NULL),
 CONSTRAINT [PK_tbpersona_direccion] PRIMARY KEY CLUSTERED 
(
	[pdi_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbpersona_distrito]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_prefijo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_provincia]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_razonsocial]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_tipo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_via]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbpersona_zona]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbrol]    Script Date: 12/02/2017 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbrol](
	[rol_Id] [int] IDENTITY(1,1) NOT NULL,
	[rol_Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK__tbrol__CF31E07B066621BB] PRIMARY KEY CLUSTERED 
(
	[rol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbrol_modulo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbusuario]    Script Date: 12/02/2017 15:40:45 ******/
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
	[usu_Estado] [bit] NULL CONSTRAINT [DF_tbusuario_usu_Estado]  DEFAULT ((1)),
	[usu_Digitalizacion] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_D__02084FDA]  DEFAULT ('NO'),
	[usu_Tramite] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_T__02FC7413]  DEFAULT ('SI'),
	[usu_Requisito] [char](2) NULL CONSTRAINT [DF__tbusuario__usu_R__03F0984C]  DEFAULT ('NO'),
	[usu_Persona] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_P__04E4BC85]  DEFAULT ('NO'),
	[usu_Mantenimiento] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_M__05D8E0BE]  DEFAULT ('NO'),
	[usu_Reporte] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_R__06CD04F7]  DEFAULT ('NO'),
	[usu_Papeleta] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_P__07C12930]  DEFAULT ('NO'),
	[usu_Vacaciones] [char](2) NULL CONSTRAINT [DF__tbusuario__usu_V__08B54D69]  DEFAULT ('NO'),
	[usu_Beneficio] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_B__09A971A2]  DEFAULT ('NO'),
	[usu_Marcacion] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_M__0A9D95DB]  DEFAULT ('NO'),
	[usu_NotaContable] [char](2) NOT NULL CONSTRAINT [DF__tbusuario__usu_N__0B91BA14]  DEFAULT ('NO'),
	[usu_Sesion] [char](1) NOT NULL CONSTRAINT [DF__tbusuario__usu_S__0C85DE4D]  DEFAULT ('0'),
 CONSTRAINT [PK_tbusuario] PRIMARY KEY CLUSTERED 
(
	[usu_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbusuario_modulo]    Script Date: 12/02/2017 15:40:45 ******/
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
/****** Object:  Table [dbo].[tbusuario_rol]    Script Date: 12/02/2017 15:40:45 ******/
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
ALTER TABLE [dbo].[tbrol_modulo]  WITH CHECK ADD  CONSTRAINT [FK_tbrol_modulo_tbmodulo] FOREIGN KEY([rol_mod_Modulo])
REFERENCES [dbo].[tbmodulo] ([mod_ID])
GO
ALTER TABLE [dbo].[tbrol_modulo] CHECK CONSTRAINT [FK_tbrol_modulo_tbmodulo]
GO
ALTER TABLE [dbo].[tbrol_modulo]  WITH CHECK ADD  CONSTRAINT [FK_tbrol_modulo_tbrol] FOREIGN KEY([rol_mod_Rol])
REFERENCES [dbo].[tbrol] ([rol_Id])
GO
ALTER TABLE [dbo].[tbrol_modulo] CHECK CONSTRAINT [FK_tbrol_modulo_tbrol]
GO
ALTER TABLE [dbo].[tbusuario]  WITH CHECK ADD  CONSTRAINT [FK_per_usu] FOREIGN KEY([usu_per_Codigo])
REFERENCES [dbo].[tbpersona] ([per_Codigo])
GO
ALTER TABLE [dbo].[tbusuario] CHECK CONSTRAINT [FK_per_usu]
GO
ALTER TABLE [dbo].[tbusuario_modulo]  WITH CHECK ADD  CONSTRAINT [FK_tbusuario_modulo_tbmodulo] FOREIGN KEY([usu_mod_Modulo])
REFERENCES [dbo].[tbmodulo] ([mod_ID])
GO
ALTER TABLE [dbo].[tbusuario_modulo] CHECK CONSTRAINT [FK_tbusuario_modulo_tbmodulo]
GO
ALTER TABLE [dbo].[tbusuario_modulo]  WITH CHECK ADD  CONSTRAINT [FK_tbusuario_modulo_tbusuario] FOREIGN KEY([usu_mod_Usuario])
REFERENCES [dbo].[tbusuario] ([usu_Codigo])
GO
ALTER TABLE [dbo].[tbusuario_modulo] CHECK CONSTRAINT [FK_tbusuario_modulo_tbusuario]
GO
ALTER TABLE [dbo].[tbusuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_tbusuario_rol_tbrol] FOREIGN KEY([usu_rol_Rol])
REFERENCES [dbo].[tbrol] ([rol_Id])
GO
ALTER TABLE [dbo].[tbusuario_rol] CHECK CONSTRAINT [FK_tbusuario_rol_tbrol]
GO
