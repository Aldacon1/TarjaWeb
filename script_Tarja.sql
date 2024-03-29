USE [TarjaAEP]
GO
/****** Object:  Table [dbo].[ut_tar_Bultos_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Bultos_m](
	[cod_bulto] [int] NOT NULL,
	[desc_bulto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ut_tar_Bultos_m] PRIMARY KEY CLUSTERED 
(
	[cod_bulto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Clientes_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Clientes_m](
	[rut_cliente] [int] NOT NULL,
	[gls_nombre_cliente] [varchar](120) NOT NULL,
	[gls_password] [varchar](10) NOT NULL,
	[n_fono] [int] NOT NULL,
	[gls_mail] [varchar](50) NOT NULL,
	[dv_cliente]  AS ([dbo].[RutDigito]([rut_cliente])),
	[num_estado_pass] [int] NOT NULL,
 CONSTRAINT [PK_ut_tar_Clientes_m] PRIMARY KEY CLUSTERED 
(
	[rut_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_DetTarjaDesc_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_DetTarjaDesc_t](
	[corr_planificacion] [varchar](50) NOT NULL,
	[patente_grua] [varchar](30) NOT NULL,
	[observacion] [varchar](500) NOT NULL,
	[nro_tarja] [bigint] NOT NULL,
 CONSTRAINT [PK_ut_tar_DetTarjaDesc_t] PRIMARY KEY CLUSTERED 
(
	[corr_planificacion] ASC,
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_DocumentoConsig_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_DocumentoConsig_t](
	[nro_documento] [varchar](15) NOT NULL,
	[tipo_documento] [int] NOT NULL,
	[nro_tarja] [bigint] NOT NULL,
	[gls_dres] [varchar](30) NULL,
	[gls_consignante] [varchar](30) NULL,
	[gls_consignatario] [varchar](30) NULL,
	[gls_despachante] [varchar](30) NULL,
	[n_estado_doc] [int] NULL,
 CONSTRAINT [PK_ut_tar_DocumentoConsig_t] PRIMARY KEY CLUSTERED 
(
	[nro_documento] ASC,
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_EstadoContenedor_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_EstadoContenedor_m](
	[cod_estado] [char](1) NOT NULL,
	[gls_nombre_estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ut_tar_EstadoContenedor_m] PRIMARY KEY CLUSTERED 
(
	[cod_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_EstadoSincronizacion_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_EstadoSincronizacion_t](
	[cod_estado] [int] NOT NULL,
	[gls_nombre_estado] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ut_tar_EstadoSincronizacion_t] PRIMARY KEY CLUSTERED 
(
	[cod_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_EstadoTarja_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_EstadoTarja_m](
	[cod_estado] [int] NOT NULL,
	[gls_nombre_estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ut_tar_EstadoTarja_m] PRIMARY KEY CLUSTERED 
(
	[cod_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_FotoConsolidado_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_FotoConsolidado_t](
	[nro_tarja] [bigint] NOT NULL,
	[gls_nombreImg] [varchar](50) NOT NULL,
	[n_seqImg] [int] NOT NULL,
	[gls_imagen] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ut_tar_FotoConsolidado_t] PRIMARY KEY CLUSTERED 
(
	[nro_tarja] ASC,
	[gls_nombreImg] ASC,
	[n_seqImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_FotoContDesc_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_FotoContDesc_t](
	[nro_tarja] [bigint] NOT NULL,
	[gls_nombreImg] [varchar](50) NOT NULL,
	[n_seqImg] [int] NOT NULL,
	[gls_imagen] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ut_tar_FotoContDesc_t] PRIMARY KEY CLUSTERED 
(
	[nro_tarja] ASC,
	[gls_nombreImg] ASC,
	[n_seqImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_FotoMercCons_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_FotoMercCons_t](
	[cod_mercancia] [bigint] NOT NULL,
	[gls_nombreImg] [varchar](50) NOT NULL,
	[n_seqImg] [int] NOT NULL,
	[gls_imagen] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ut_tar_FotoMercCons_t] PRIMARY KEY CLUSTERED 
(
	[cod_mercancia] ASC,
	[gls_nombreImg] ASC,
	[n_seqImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_FotoMercDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_FotoMercDesc](
	[cod_mercancia] [bigint] NOT NULL,
	[gls_nombreImg] [varchar](50) NOT NULL,
	[n_seqImg] [int] NOT NULL,
	[gls_imagen] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ut_tar_FotoMercDesc] PRIMARY KEY CLUSTERED 
(
	[cod_mercancia] ASC,
	[gls_nombreImg] ASC,
	[n_seqImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Funciones_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Funciones_m](
	[cod_funcion] [int] NOT NULL,
	[gls_nombre_fun] [varchar](20) NOT NULL,
	[cod_permiso] [int] NOT NULL,
 CONSTRAINT [PK_ut_tar_Funciones_m] PRIMARY KEY CLUSTERED 
(
	[cod_funcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Grua_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Grua_m](
	[gls_patente] [varchar](30) NOT NULL,
	[gls_marca] [varchar](50) NOT NULL,
	[n_terminal] [int] NOT NULL,
 CONSTRAINT [PK_ut_tar_Grua_m] PRIMARY KEY CLUSTERED 
(
	[gls_patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_GruasCons_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_GruasCons_t](
	[nro_tarja] [bigint] NOT NULL,
	[patente] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ut_tar_GruasCons_t] PRIMARY KEY CLUSTERED 
(
	[nro_tarja] ASC,
	[patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_iso_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_iso_m](
	[cod_iso] [varchar](20) NOT NULL,
	[desc_iso] [varchar](50) NOT NULL,
	[tara] [float] NULL,
 CONSTRAINT [PK_ut_tar_iso_m] PRIMARY KEY CLUSTERED 
(
	[cod_iso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_MercanciaCons_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_MercanciaCons_t](
	[cod_mercancia] [bigint] NOT NULL,
	[nro_documento] [varchar](15) NOT NULL,
	[nro_tarja] [bigint] NOT NULL,
	[gls_marca] [varchar](100) NOT NULL,
	[gls_contenido] [varchar](150) NOT NULL,
	[n_bulto] [int] NOT NULL,
	[n_bulto_sec] [int] NOT NULL,
	[f_peso] [float] NOT NULL,
	[f_alto] [float] NOT NULL,
	[f_ancho] [float] NOT NULL,
	[f_largo] [float] NOT NULL,
	[n_cantidad] [int] NOT NULL,
	[gls_observacion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ut_tar_MercanciaCons_t] PRIMARY KEY CLUSTERED 
(
	[cod_mercancia] ASC,
	[nro_documento] ASC,
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_MercanciaDesc_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_MercanciaDesc_t](
	[cod_mercancia] [bigint] NOT NULL,
	[nro_tarja] [bigint] NOT NULL,
	[n_bulto] [int] NOT NULL,
	[gls_marca] [varchar](100) NOT NULL,
	[n_cantidad] [int] NOT NULL,
	[gls_retiro] [varchar](20) NOT NULL,
	[gls_condicion] [varchar](10) NOT NULL,
	[observacion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ut_tar_MercanciaDesc_t] PRIMARY KEY CLUSTERED 
(
	[cod_mercancia] ASC,
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Naves_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Naves_m](
	[cod_nave] [varchar](10) NOT NULL,
	[gls_nombre_nave] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ut_tar_Naves_m] PRIMARY KEY CLUSTERED 
(
	[cod_nave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Permisos_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Permisos_m](
	[cod_permiso] [int] NOT NULL,
	[gls_nombre_perm] [varchar](25) NOT NULL,
	[n_web] [int] NOT NULL,
	[n_movil] [int] NOT NULL,
 CONSTRAINT [PK_ut_tar_Permisos_m] PRIMARY KEY CLUSTERED 
(
	[cod_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Personas_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Personas_m](
	[rut_persona] [int] NOT NULL,
	[gls_nombre_pers] [varchar](90) NOT NULL,
	[gls_password] [varchar](10) NOT NULL,
	[cod_funcion] [int] NOT NULL,
	[cod_terminal] [int] NOT NULL,
	[dv_persona]  AS ([dbo].[RutDigito]([rut_persona])),
 CONSTRAINT [PK_ut_tar_Personas_m] PRIMARY KEY CLUSTERED 
(
	[rut_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_PersonasTarjaCons_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_PersonasTarjaCons_t](
	[rut_persona] [int] NOT NULL,
	[nro_tarja] [bigint] NOT NULL,
 CONSTRAINT [PK_ut_tar_PersonasTarjaCons_t] PRIMARY KEY CLUSTERED 
(
	[rut_persona] ASC,
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_PersonasTarjaDesc_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_PersonasTarjaDesc_t](
	[rut_persona] [int] NOT NULL,
	[nro_tarja] [bigint] NOT NULL,
 CONSTRAINT [PK_ut_tar_PersonasTarjaDesc_t] PRIMARY KEY CLUSTERED 
(
	[rut_persona] ASC,
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_PlanificacionConsolidado_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_PlanificacionConsolidado_t](
	[nro_tarja] [bigint] NOT NULL,
	[rut_cliente] [int] NOT NULL,
	[cod_puerto_or] [varchar](10) NOT NULL,
	[cod_puerto_dest] [varchar](10) NOT NULL,
	[cod_nave] [varchar](10) NOT NULL,
	[n_viaje] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[gls_contenedor] [varchar](20) NOT NULL,
	[cod_iso] [varchar](20) NOT NULL,
	[rut_tarjador] [int] NOT NULL,
	[gls_sello] [varchar](20) NOT NULL,
	[f_capacidad] [float] NOT NULL,
	[gls_reserva] [varchar](50) NOT NULL,
	[cod_estado_tarja] [int] NOT NULL,
	[cod_terminal] [int] NOT NULL,
	[hora_inicio] [sql_variant] NULL,
	[hora_term] [sql_variant] NULL,
	[f_duracion] [float] NULL,
	[gls_observación] [text] NULL,
	[cod_estado_sinc] [int] NULL,
	[fecha_termino] [date] NULL,
	[patente] [varchar](50) NULL,
	[fechaRetiroConsolidado] [date] NULL,
	[horaRetiroConsolidado] [sql_variant] NULL,
	[guia] [varchar](50) NULL,
	[fechaS] [date] NULL,
	[gls_pagina] [varchar](50) NULL,
	[estadoGuia] [int] NULL,
 CONSTRAINT [PK_ut_tar_PlanificacionConsolidado_t] PRIMARY KEY CLUSTERED 
(
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_PlanificacionDesconsolidado_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_PlanificacionDesconsolidado_t](
	[corr_planificacion] [varchar](50) NOT NULL,
	[gls_bl] [varchar](30) NOT NULL,
	[cod_puerto_or] [varchar](10) NOT NULL,
	[cod_puerto_dest] [varchar](10) NOT NULL,
	[gls_contenedor] [varchar](20) NOT NULL,
	[cod_iso] [varchar](20) NOT NULL,
	[gls_sello1] [varchar](20) NOT NULL,
	[gls_sello2] [varchar](20) NULL,
	[gls_sello3] [varchar](20) NULL,
	[rut_cliente] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora_in] [sql_variant] NOT NULL,
	[hora_term] [sql_variant] NOT NULL,
	[gls_mano_trabajo] [varchar](10) NULL,
	[cod_nave] [varchar](10) NOT NULL,
	[n_viaje] [int] NOT NULL,
	[cod_terminal] [int] NOT NULL,
	[n_estado] [int] NOT NULL,
	[gls_desbloqueo_sello] [varchar](20) NOT NULL,
	[rut_tarjador] [int] NOT NULL,
	[hora_inicioR] [sql_variant] NULL,
	[hora_termR] [sql_variant] NULL,
	[tara] [float] NULL,
	[selloFis1] [varchar](20) NULL,
	[selloFis2] [varchar](20) NULL,
	[selloFis3] [varchar](20) NULL,
	[fecha_termino] [date] NULL,
	[duracion] [float] NULL,
	[patente] [varchar](50) NULL,
	[fechaRetiroCont] [date] NULL,
	[horaRetiroCont] [sql_variant] NULL,
	[guia] [varchar](50) NULL,
	[gls_pagina] [varchar](50) NULL,
	[estadoGuia] [int] NULL,
 CONSTRAINT [PK_ut_tar_PlanificacionDesconsolidado_t] PRIMARY KEY CLUSTERED 
(
	[corr_planificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_PlanificacionDespacho_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_PlanificacionDespacho_t](
	[nro_tarja] [bigint] NOT NULL,
	[rut_cliente] [int] NOT NULL,
	[cod_puerto_or] [varchar](10) NOT NULL,
	[cod_puerto_dest] [varchar](10) NOT NULL,
	[cod_transporte] [varchar](10) NOT NULL,
	[n_vuelta] [int] NOT NULL,
	[patente] [varchar](10) NOT NULL,
	[rut_tarjador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[n_estado] [int] NOT NULL,
	[cod_terminal] [int] NOT NULL,
	[hora_inicio] [sql_variant] NULL,
	[hora_term] [sql_variant] NULL,
	[fecha_term] [date] NULL,
	[observacion] [varchar](500) NULL,
	[duracion] [float] NULL,
	[guia] [varchar](50) NULL,
	[pagina] [varchar](50) NULL,
 CONSTRAINT [PK_ut_tar_PlanificacionDespacho_t] PRIMARY KEY CLUSTERED 
(
	[nro_tarja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Puertos_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Puertos_m](
	[cod_puerto] [varchar](10) NOT NULL,
	[gls_nombre_puerto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ut_tar_Puertos_m] PRIMARY KEY CLUSTERED 
(
	[cod_puerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_SectorVector_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_SectorVector_t](
	[nro_tarja] [bigint] NOT NULL,
	[nro_sector] [int] NOT NULL,
	[cod_estado] [char](1) NOT NULL,
 CONSTRAINT [PK_ut_tar_SectorVector_t] PRIMARY KEY CLUSTERED 
(
	[nro_tarja] ASC,
	[nro_sector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_Terminales_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_Terminales_m](
	[cod_terminal] [int] NOT NULL,
	[gls_nombre_terminal] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ut_tar_Terminales_m] PRIMARY KEY CLUSTERED 
(
	[cod_terminal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_TipoDocumento_m]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_TipoDocumento_m](
	[cod_tipo] [int] NOT NULL,
	[gls_desc_tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ut_tar_TipoDocumento_m] PRIMARY KEY CLUSTERED 
(
	[cod_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ut_tar_version_t]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ut_tar_version_t](
	[gls_versionAPK] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_add_bultos]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_bultos]
	@CODIGO INT,
	@NOMBRE VARCHAR(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_Bultos_m(cod_bulto, desc_bulto)
			VALUES (@CODIGO, @NOMBRE)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('bulto') cod_bulto
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_cliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_cliente]
	@RUT INT,
	@RAZON VARCHAR(120),
	@PASSWORD VARCHAR(10),
	@TELEFONO INT,
	@EMAIL VARCHAR(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_Clientes_m WHERE rut_cliente=@RUT))
				BEGIN
					INSERT INTO ut_tar_Clientes_m(rut_cliente, gls_nombre_cliente, gls_password, n_fono,gls_mail, num_estado_pass) 
					VALUES(@RUT, @RAZON, @PASSWORD, @TELEFONO, @EMAIL, 0);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('CLIENTE') rut_cliente
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_detalleTarjaDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_detalleTarjaDesc]
	@nroTarja bigint,
	@corr_plan varchar(50),
	@grua varchar(20),
	@obs varchar(500)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_DetTarjaDesc_t WHERE nro_tarja=@nroTarja))
				BEGIN
					INSERT INTO ut_tar_DetTarjaDesc_t(nro_tarja, corr_planificacion, patente_grua, observacion) 
					VALUES(@nroTarja, @corr_plan, @grua, @obs);
				END
				ELSE
				BEGIN
					UPDATE ut_tar_DetTarjaDesc_t
					SET patente_grua=@grua,
					observacion=@obs
					WHERE nro_tarja=@nroTarja
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('detTarja') nro_tarja
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_documentoConsig]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_documentoConsig]
	@NRO_DOC varchar(15),
	@TIPO_DOC INT,
	@DRES varchar(30),
	@CONSIGNANTE varchar(30),
	@CONSIGNATARIO varchar(30),
	@DESPACHANTE varchar(30),
	@NROTARJA BIGINT

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_DocumentoConsig_t(nro_documento, tipo_documento, nro_tarja, gls_dres, gls_consignante, gls_consignatario, gls_despachante, n_estado_doc)
			VALUES (@NRO_DOC, @TIPO_DOC, @NROTARJA, @DRES, @CONSIGNANTE, @CONSIGNATARIO, @DESPACHANTE, 1)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('documento') nro_documento
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_fotoDesco]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_fotoDesco]
	@NRO_TARJA BIGINT,
	@SEQ_IMG INT,
	@NOMBRE VARCHAR(50),
	@IMAGEN VARCHAR(MAX)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_FotoContDesc_t(nro_tarja, n_seqImg, gls_nombreImg, gls_imagen)
			VALUES (@NRO_TARJA, @SEQ_IMG, @NOMBRE, @IMAGEN)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('imagen') nro_tarja
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_fotoExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_fotoExpo]
	@NRO_TARJA BIGINT,
	@SEQ_IMG INT,
	@NOMBRE VARCHAR(50),
	@IMAGEN VARCHAR(MAX)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_FotoConsolidado_t(nro_tarja, n_seqImg, gls_nombreImg, gls_imagen)
			VALUES (@NRO_TARJA, @SEQ_IMG, @NOMBRE, @IMAGEN)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('imagen') nro_tarja
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_fotoMercDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_fotoMercDesc]
	@COD_MERC BIGINT,
	@SEQ_IMG INT,
	@NOMBRE VARCHAR(50),
	@IMAGEN VARCHAR(MAX)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_FotoMercDesc(cod_mercancia, n_seqImg, gls_nombreImg, gls_imagen)
			VALUES (@COD_MERC, @SEQ_IMG, @NOMBRE, @IMAGEN)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('imagen') cod_merc
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_fotoMercExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_fotoMercExpo]
	@COD_MERC BIGINT,
	@SEQ_IMG INT,
	@NOMBRE VARCHAR(50),
	@IMAGEN VARCHAR(MAX)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_FotoMercCons_t(cod_mercancia, n_seqImg, gls_nombreImg, gls_imagen)
			VALUES (@COD_MERC, @SEQ_IMG, @NOMBRE, @IMAGEN)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('imagen') cod_merc
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_funcion]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_funcion]
	@CODIGO INT,
	@NOMBRE VARCHAR(20),
	@PERMISO INT

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_Funciones_m WHERE cod_funcion=@CODIGO))
				BEGIN
					INSERT INTO ut_tar_Funciones_m(cod_funcion, gls_nombre_fun, cod_permiso) 
					VALUES(@CODIGO, @NOMBRE, @PERMISO);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('funcion') cod_funcion
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_grua]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_grua]
	@PATENTE varchar(20),
	@MARCA varchar(50),
	@TERMINAL INT

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_Grua_m WHERE gls_patente=@PATENTE))
				BEGIN
					INSERT INTO ut_tar_Grua_m(gls_patente, gls_marca, n_terminal) 
					VALUES(@PATENTE, @MARCA, @TERMINAL);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('grua') gls_patente
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_gruaCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_gruaCons]
	@NROTARJA BIGINT,
	@PATENTE varchar(30)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF NOT EXISTS(SELECT * from ut_tar_GruasCons_t where nro_tarja=@NROTARJA and patente=@PATENTE)
			insert into ut_tar_GruasCons_t(nro_tarja, patente) values(@NROTARJA, @PATENTE)

			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('grua_cons') patente
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_iso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_iso]
	@CODIGO varchar(20),
	@NOMBRE varchar(50),
	@TARA INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_iso_m WHERE cod_iso=@CODIGO))
				BEGIN
					INSERT INTO ut_tar_iso_m(cod_iso, desc_iso, tara) 
					VALUES(@CODIGO, @NOMBRE, @TARA);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('iso') cod_iso
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_mercanciaCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_mercanciaCons]
	@cod_mercancia	bigint,
	@nro_documento	varchar(15),
	@nro_tarja	bigint,
	@gls_marca	varchar(100),
	@gls_contenido	varchar(150),
	@n_bulto	int,
	@n_bulto_sec	int,
	@f_peso	float,
	@f_alto	float,
	@f_ancho	float,
	@f_largo	float,
	@n_cantidad	int,
	@gls_observacion	varchar(500)
	
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_MercanciaCons_t WHERE cod_mercancia=@cod_mercancia))
				BEGIN
					INSERT INTO ut_tar_MercanciaCons_t(cod_mercancia, nro_documento, nro_tarja, gls_marca, gls_contenido, n_bulto, n_bulto_sec, f_peso, f_alto, f_ancho, f_largo, n_cantidad, gls_observacion) 
					VALUES(@cod_mercancia, @nro_documento, @nro_tarja, @gls_marca, @gls_contenido, @n_bulto, @n_bulto_sec, @f_peso, @f_alto, @f_ancho, @f_largo, @n_cantidad, @gls_observacion);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('mercanciaCons') cod_mercancia
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_mercanciaCons_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_mercanciaCons_01]
	@cod_mercancia	bigint,
	@nro_documento	varchar(15),
	@nro_tarja bigint,
	@gls_marca	varchar(100),
	@gls_contenido	varchar(150),
	@n_bulto	int,
	@n_bulto_sec	int,
	@f_peso	float,
	@f_alto	float,
	@f_ancho	float,
	@f_largo	float,
	@n_cantidad	int,
	@gls_observacion	varchar(500)
	
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_MercanciaCons_t WHERE cod_mercancia=@cod_mercancia))
				BEGIN
					INSERT INTO ut_tar_MercanciaCons_t(cod_mercancia, nro_documento, nro_tarja, gls_marca, gls_contenido, n_bulto, n_bulto_sec, f_peso, f_alto, f_ancho, f_largo, n_cantidad, gls_observacion) 
					VALUES(@cod_mercancia, @nro_documento, @nro_tarja, @gls_marca, @gls_contenido,  @n_bulto, @n_bulto_sec, @f_peso, @f_alto, @f_ancho, @f_largo, @n_cantidad, @gls_observacion);
				END
			ELSE 
			BEGIN
				UPDATE ut_tar_MercanciaCons_t
				SET gls_marca = @gls_marca,
				n_cantidad = @n_cantidad,
				gls_observacion = @gls_observacion
				WHERE cod_mercancia=@cod_mercancia
				AND nro_documento = @nro_documento
				AND nro_tarja = @nro_tarja 

			END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('mercanciaCons') cod_mercancia
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_mercanciaDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_mercanciaDesc]
	@cod_mercancia	BIGINT,
	@nro_tarja	BIGINT,
	@n_bulto	INT,
	@gls_marca	VARCHAR(100),
	@n_cantidad	INT,
	@gls_retiro	VARCHAR(20),
	@gls_condicion	VARCHAR(10),
	@observacion	VARCHAR(500)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_MercanciaDesc_t WHERE cod_mercancia=@cod_mercancia))
				BEGIN
					INSERT INTO ut_tar_MercanciaDesc_t(cod_mercancia, nro_tarja, n_bulto, gls_marca, n_cantidad, gls_retiro, gls_condicion, observacion) 
					VALUES(@cod_mercancia, @nro_tarja, @n_bulto, @gls_marca, @n_cantidad, @gls_retiro, @gls_condicion, @observacion);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('mercanciaDesc') cod_mercancia
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_naves]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_naves]
	@CODIGO VARCHAR(10),
	@NOMBRE VARCHAR(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_Naves_m(cod_nave, gls_nombre_nave)
			VALUES (@CODIGO, @NOMBRE)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('nave') cod_nave
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_permisos]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_permisos]
	@cod_permiso int,
	@gls_nombre_perm varchar,
	@n_movil int,
	@n_web int
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_Permisos_m(cod_permiso, gls_nombre_perm, n_movil, n_web)
			VALUES (@cod_permiso, @gls_nombre_perm, @n_movil, @n_web)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('permiso') cod_permiso
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_personaCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_personaCons]
	@NROTARJA BIGINT,
	@RUT INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO ut_tar_PersonasTarjaCons_t (nro_tarja, rut_persona) 
			values(@NROTARJA, @RUT)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('personaCons') nro_tarja
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_personaDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_personaDesc]
	@nroTarja bigint,
	@rut int
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			insert into ut_tar_PersonasTarjaDesc_t (nro_tarja, rut_persona) 
			values(@nroTarja, @rut)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('PersonaDesc') nro_tarja
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_personas]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_personas]
	@rut_persona INT,
	@gls_nombre_pers VARCHAR(90),
	@gls_password VARCHAR(10),
	@cod_funcion INT,
	@cod_terminal INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_Personas_m(rut_persona, gls_nombre_pers, gls_password, cod_funcion, cod_terminal)
			VALUES (@rut_persona, @gls_nombre_pers, @gls_password, @cod_funcion, @cod_terminal)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('persona') rut_persona
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_planConso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_planConso]
	@nro_tarja          bigint,
	@rut_cliente        int,
	@fecha              Date,
	@gls_reserva        varchar(50),
	@cod_puerto_or      varchar(10),
	@cod_puerto_dest    varchar(10),
	@n_viaje            int,
	@cod_nave           varchar(10),
	@cod_iso            varchar(20),
	@gls_contenedor     varchar(20),
	@f_capacidad        float,
	@gls_sello          varchar(20),
	@rut_tarjador       int,
	@cod_terminal       int
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_PlanificacionConsolidado_t WHERE nro_tarja=@nro_tarja))
				BEGIN
					INSERT INTO ut_tar_PlanificacionConsolidado_t(nro_tarja, rut_cliente, fecha, gls_reserva, cod_puerto_or, cod_puerto_dest, n_viaje, cod_nave, cod_iso,
																  gls_contenedor, f_capacidad, gls_sello, rut_tarjador, cod_terminal, cod_estado_tarja, cod_estado_sinc, f_duracion) 
					VALUES(@nro_tarja, @rut_cliente, @fecha, @gls_reserva, @cod_puerto_or, @cod_puerto_dest, @n_viaje, @cod_nave, @cod_iso,
																  @gls_contenedor, @f_capacidad, @gls_sello, @rut_tarjador, @cod_terminal, 1, 0, 0);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('planificacionDesc') corr_plan
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_planDesco]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_planDesco]
	@corr_planificacion	varchar(50),
	@gls_bl	varchar(30),
	@cod_puerto_or	varchar(10),
	@cod_puerto_dest	varchar(10),
	@gls_contenedor	varchar(20),
	@cod_iso	varchar(20),
	@gls_sello1	varchar(20),
	@gls_sello2	varchar(20),
	@gls_sello3	varchar(20),
	@rut_cliente	int,
	@fecha	date,
	@hora_in	time(7),
	@hora_term	time(7),
	@gls_mano_trabajo	varchar(10),
	@cod_nave	varchar(10),
	@n_viaje	int,
	@cod_terminal	int,
	@n_estado	int,
	@gls_desbloqueo_sello	varchar(20),
	@rut_tarjador	int	
AS
/*
 exec sp_add_planDesco @corr_planificacion = "333",
	@gls_bl	= "TEST",
	@cod_puerto_or	= "VAP",
	@cod_puerto_dest = "VAP",
	@gls_contenedor	= "TEST1234567",
	@cod_iso	= "4200",
	@gls_sello1	= "",
	@gls_sello2	= "",
	@gls_sello3	= "",
	@rut_cliente = 1,
	@fecha	= "20170824",
	@hora_in	= "00:00",
	@hora_term	= "00:00",
	@gls_mano_trabajo = 1,
	@cod_nave	= "NN",
	@n_viaje	= 1,
	@cod_terminal	= 1,
	@n_estado	= 1,
	@gls_desbloqueo_sello = "III",
	@rut_tarjador	= 1
*/
BEGIN
	BEGIN TRY
    
        IF EXISTS(SELECT 1 
                    FROM ut_tar_PlanificacionDesconsolidado_t 
                   WHERE corr_planificacion = @corr_planificacion)
        
        BEGIN
        
            SELECT @@ERROR AS ERROR_NUMBER, 
                    'YA EXISTE'      AS ERROR_MESSAGE, 
                    IDENT_CURRENT('planificacionDesc') corr_plan
        END        
        ELSE
        BEGIN
        
		    BEGIN TRAN	
							        
                INSERT INTO ut_tar_PlanificacionDesconsolidado_t(corr_planificacion, gls_bl, cod_puerto_or, cod_puerto_dest, gls_contenedor, cod_iso, gls_sello1, gls_sello2, gls_sello3, rut_cliente, fecha, hora_in, hora_term, gls_mano_trabajo, cod_nave, n_viaje, cod_terminal, n_estado, gls_desbloqueo_sello, rut_tarjador, duracion) 
                VALUES(@corr_planificacion, @gls_bl, @cod_puerto_or, @cod_puerto_dest, @gls_contenedor, @cod_iso, @gls_sello1, @gls_sello2, @gls_sello3, @rut_cliente, @fecha, @hora_in, @hora_term, @gls_mano_trabajo, @cod_nave, @n_viaje, @cod_terminal, @n_estado, @gls_desbloqueo_sello, @rut_tarjador, 0);
                
            COMMIT TRAN					
        END
        
        SELECT  @@ERROR AS ERROR_NUMBER, 
                '' AS ERROR_MESSAGE, 
                IDENT_CURRENT('planificacionDesc') corr_plan
        
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[sp_add_planDesp]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_planDesp]
	@nro_tarja          bigint,
	@rut_cliente        int,
	@fecha              Date,
	@cod_puerto_or      varchar(10),
	@cod_puerto_dest    varchar(10),
	@n_vuelta           int,
	@cod_transporte     varchar(10),
	@patente            varchar(10),
	@rut_tarjador       int,
	@cod_terminal       int
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_PlanificacionDespacho_t WHERE nro_tarja=@nro_tarja))
				BEGIN
					INSERT INTO ut_tar_PlanificacionDespacho_t(nro_tarja, rut_cliente, fecha, cod_puerto_or, cod_puerto_dest, n_vuelta, cod_transporte, 
																  patente, rut_tarjador, cod_terminal, n_estado) 
					VALUES(@nro_tarja, @rut_cliente, @fecha, @cod_puerto_or, @cod_puerto_dest, @n_vuelta, @cod_transporte, @patente,
																  @rut_tarjador, @cod_terminal, 1);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('ut_tar_PlanificacionDespacho_t') corr_plan
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_puerto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_puerto]
	@cod_puerto VARCHAR(30),
	@gls_nombre_puerto varchar(30)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_Puertos_m(cod_puerto, gls_nombre_puerto)
			VALUES (@cod_puerto, @gls_nombre_puerto)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('puertp') cod_puerto
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_sectorVector]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_sectorVector]
	@nro_tarja BIGINT,
	@nro_sector int,
	@cod_estado char(1)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			IF(NOT EXISTS(SELECT * FROM ut_tar_SectorVector_t WHERE nro_tarja=@nro_tarja and nro_sector=@nro_sector))
				BEGIN
					INSERT INTO ut_tar_SectorVector_t(nro_tarja, nro_sector, cod_estado) 
					VALUES(@nro_tarja, @nro_sector, @cod_estado);
				END
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('sectorVector') nro_tarja
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_terminal]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_terminal]
	@cod_terminal int,
	@gls_nombre_terminal varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_Terminales_m(cod_terminal, gls_nombre_terminal)
			VALUES (@cod_terminal, @gls_nombre_terminal)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('terminal') cod_terminal
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_add_tipoDoc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_add_tipoDoc]
	@cod_tipo int,
	@gls_desc_tipo varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
				
			INSERT INTO ut_tar_TipoDocumento_m(cod_tipo, gls_desc_tipo)
			VALUES (@cod_tipo, @gls_desc_tipo)
			
			SELECT  @@ERROR AS ERROR_NUMBER, '' AS ERROR_MESSAGE, IDENT_CURRENT('tipoDoc') cod_tipo
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_bulto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_bulto]
	@CODIGO	int
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN						
		
		
					DELETE	FROM ut_tar_Bultos_m
					WHERE	cod_bulto = @CODIGO
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El bulto se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_cliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_cliente]
	@RUT INT		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN						
		
		
					DELETE	FROM ut_tar_Clientes_m
					WHERE	rut_cliente = @RUT						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El cliente se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_desconsolidado_02]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_desconsolidado_02]
	@NROTARJA BIGINT
AS
DECLARE @NRODOC INT,
@CODMERC INT
SET @NRODOC = (SELECT nro_documento FROM ut_tar_DocumentoConsig_t WHERE nro_tarja = @NROTARJA)
SET @CODMERC = (SELECT cod_mercancia FROM ut_tar_MercanciaCons_t WHERE nro_documento=@NRODOC and nro_tarja=@NROTARJA) 

BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF EXISTS(SELECT * FROM ut_tar_FotoMercCons_t WHERE cod_mercancia=@CODMERC)
			BEGIN
				DELETE FROM ut_tar_FotoMercCons_t
				WHERE cod_mercancia=@CODMERC
			END
			IF EXISTS(SELECT * FROM ut_tar_MercanciaCons_t
			WHERE nro_documento = @NRODOC and nro_tarja=@NROTARJA)
			BEGIN
				DELETE FROM ut_tar_MercanciaCons_t 
				WHERE nro_documento = @NRODOC
			END
			IF EXISTS(SELECT * FROM ut_tar_DocumentoConsig_t WHERE nro_tarja=@NROTARJA)
			BEGIN
				DELETE FROM ut_tar_DocumentoConsig_t
				WHERE nro_documento=@NROTARJA
			END
			IF EXISTS(SELECT * FROM ut_tar_FotoConsolidado_t WHERE nro_tarja=@NROTARJA)
			BEGIN
				DELETE FROM ut_tar_FotoConsolidado_t
				WHERE nro_tarja=@NROTARJA
			END
			IF EXISTS(SELECT * FROM ut_tar_PersonasTarjaCons_t WHERE nro_tarja=@NROTARJA)
			BEGIN
				DELETE FROM ut_tar_PersonasTarjaCons_t
				WHERE nro_tarja=@NROTARJA
			END
			IF EXISTS(SELECT * FROM ut_tar_PlanificacionConsolidado_t WHERE nro_tarja=@NROTARJA)
			BEGIN
				DELETE FROM ut_tar_PlanificacionConsolidado_t
				WHERE nro_tarja=@NROTARJA
			END
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_documentoConsig]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_documentoConsig]
	@NRO_DOC	VARCHAR(15),
	@NROTARJA BIGINT
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN						
		
		
					DELETE	FROM ut_tar_DocumentoConsig_t
					WHERE	nro_documento = @NRO_DOC 
					and		nro_tarja = @NROTARJA
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El documento se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_funcion]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_funcion]
	@CODIGO INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN		
			DELETE	FROM ut_tar_Funciones_m
			WHERE	cod_funcion = @CODIGO
										
			SELECT  @@ERROR AS ERROR_NUMBER, 'La funcion se ha eliminado correctamente' AS ERROR_MESSAGE	
		COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_grua]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_grua]
	@PATENTE VARCHAR(20)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN		
			DELETE	FROM ut_tar_Grua_m
			WHERE	gls_patente = @PATENTE
										
			SELECT  @@ERROR AS ERROR_NUMBER, 'La grua se ha eliminado correctamente' AS ERROR_MESSAGE	
		COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_iso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_iso]
	@CODIGO varchar(20)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN		
			DELETE	FROM ut_tar_iso_m
			WHERE	cod_iso = @CODIGO
										
			SELECT  @@ERROR AS ERROR_NUMBER, 'La grua se ha eliminado correctamente' AS ERROR_MESSAGE	
		COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_mercanciaCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_mercanciaCons]
	@cod_mercancia	bigint
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN		
			DELETE	FROM ut_tar_MercanciaCons_t
			WHERE	cod_mercancia = @cod_mercancia
										
			SELECT  @@ERROR AS ERROR_NUMBER, 'La mercancia se ha eliminado correctamente' AS ERROR_MESSAGE	
		COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_nave]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_nave]
	@CODIGO	VARCHAR(10)
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN						
		
		
					DELETE	FROM ut_tar_Naves_m
					WHERE	cod_nave = @CODIGO
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'La nave se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_permiso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_permiso]
	@cod_permiso INT
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
					DELETE	FROM ut_tar_Permisos_m
					WHERE	cod_permiso = @cod_permiso
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El permiso se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_persona]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_persona]
	@rut INT
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
					DELETE	FROM ut_tar_Personas_m
					WHERE	rut_persona = @rut
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'La persona se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_planificacionCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_planificacionCons]
	@NROTARJA BIGINT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(EXISTS(SELECT * FROM ut_tar_PlanificacionConsolidado_t WHERE nro_tarja=@NROTARJA))
				DELETE FROM ut_tar_PlanificacionConsolidado_t WHERE nro_tarja=@NROTARJA
		SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_planificacionDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_planificacionDesc]
	@CORR_PLAN NVARCHAR(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(EXISTS(SELECT * FROM ut_tar_PlanificacionDesconsolidado_t WHERE corr_planificacion=@CORR_PLAN))
				DELETE FROM ut_tar_PlanificacionDesconsolidado_t WHERE corr_planificacion=@CORR_PLAN
		SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_planificacionDesp]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_planificacionDesp]
	@NROTARJA BIGINT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(EXISTS(SELECT * FROM ut_tar_PlanificacionDespacho_t WHERE nro_tarja=@NROTARJA))
				DELETE FROM ut_tar_PlanificacionDespacho_t WHERE nro_tarja=@NROTARJA
		SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_puerto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_puerto]
	@cod_puerto VARCHAR(30)
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
					DELETE	FROM ut_tar_Puertos_m
					WHERE	cod_puerto = @cod_puerto
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El puerto se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_puerto_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_puerto_01]
	@CODIGO	varchar(30)
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
					DELETE	FROM ut_tar_Puertos_m
					WHERE	cod_puerto = @CODIGO
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El puerto se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_terminal]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_terminal]
	@cod_terminal int
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
					DELETE	FROM ut_tar_Terminales_m
					WHERE	cod_terminal = @cod_terminal
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El terminal se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_del_tipoDoc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_del_tipoDoc]
	@cod_tipo int
		
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
					DELETE	FROM ut_tar_TipoDocumento_m
					WHERE	cod_tipo = @cod_tipo
						
										
					SELECT  @@ERROR AS ERROR_NUMBER, 'El tipo de documento se ha eliminado correctamente' AS ERROR_MESSAGE	
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_enProcesoDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_enProcesoDesc]
@corr_plan varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionDesconsolidado_t
			set n_estado=2
			where corr_planificacion = @corr_plan
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login]
@usuario int,
@password varchar(10)

AS
BEGIN
IF EXISTS(SELECT * FROM ut_tar_Personas_m where rut_persona=@usuario and gls_password=@password)
	BEGIN
		select rut_persona, dv_persona, gls_password, gls_nombre_pers, ut_tar_Funciones_m.gls_nombre_fun gls_nombre_fun, ut_tar_Terminales_m.gls_nombre_terminal gls_nombre_terminal, ut_tar_Personas_m.cod_terminal from ut_tar_Personas_m
			join ut_tar_Funciones_m on (ut_tar_Personas_m.cod_funcion = ut_tar_Funciones_m.cod_funcion)
			join ut_tar_Terminales_m on (ut_tar_Personas_m.cod_terminal = ut_tar_Terminales_m.cod_terminal)
			where rut_persona=@usuario and gls_password=@password 
	END
ELSE
	BEGIN
		SELECT 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_login_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login_01]
@usuario int,
@password varchar(10),
@version varchar(50)

AS
BEGIN
	DECLARE
	@versionBase varchar(50),
	@mensajeVersion varchar(50) 

	SELECT @versionBase = gls_versionAPK FROM ut_tar_version_t

	SET @mensajeVersion=''

	IF @versionBase = @version
		SET @mensajeVersion = 'ok'


	SELECT rut_persona, dv_persona, gls_password, gls_nombre_pers, ut_tar_Funciones_m.gls_nombre_fun, @mensajeVersion AS mensaje_version,
	       CASE cod_terminal
		        WHEN 0 THEN 'A68'
				WHEN 1 THEN 'A40'
				WHEN 4 THEN 'A78'
		   END AS location
	
	  FROM ut_tar_Personas_m
	join ut_tar_Funciones_m on (ut_tar_Personas_m.cod_funcion = ut_tar_Funciones_m.cod_funcion)
	where rut_persona=@usuario and gls_password=@password 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_login_cliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login_cliente]
@rut int,
@pass varchar(10)

AS
BEGIN
IF EXISTS(SELECT * FROM ut_tar_Clientes_m where rut_cliente=@rut and gls_password=@pass)
	BEGIN
		select rut_cliente, dv_cliente, gls_password, gls_nombre_cliente from ut_tar_Clientes_m
			where rut_cliente=@rut and gls_password=@pass 
	END
ELSE
	BEGIN
		SELECT 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_pausarTarjaCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_pausarTarjaCons]
@nroTarja bigint
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionConsolidado_t
			set cod_estado_tarja=2
			where nro_tarja = @nroTarja
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_pausarTarjaDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_pausarTarjaDesc]
@corr_plan varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionDesconsolidado_t
			set n_estado=4
			where corr_planificacion = @corr_plan
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_pausarTarjaDesp]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_pausarTarjaDesp]
@nro_tarja BIGINT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionDespacho_t
			set n_estado=2
			where nro_tarja = @nro_tarja
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_bulto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_bulto]
AS
BEGIN
	SELECT cod_bulto as CODIGO, desc_bulto AS NOMBRE FROM ut_tar_Bultos_m 
	ORDER BY desc_bulto asc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_bulto_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_bulto_01]
	@CODIGO INT
AS
BEGIN
	SELECT cod_bulto as CODIGO, desc_bulto AS NOMBRE FROM ut_tar_Bultos_m where cod_bulto=@CODIGO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_cliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_cliente]
AS
BEGIN
	SELECT * FROM ut_tar_Clientes_m order by gls_nombre_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_cliente_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_cliente_01]
@RUT INT
AS
BEGIN
	SELECT rut_cliente, gls_nombre_cliente as nombre_cliente, dv_cliente, gls_mail as email_cliente, 
	gls_password as pass_cliente, n_fono as fono_cliente FROM ut_tar_Clientes_m
	WHERE rut_cliente=@RUT
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_documentoConsig]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_documentoConsig]
AS
BEGIN
	SELECT * FROM ut_tar_DocumentoConsig_t
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_documentoConsig_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_documentoConsig_01]
	@NROTARJA bigint
AS
BEGIN
	SELECT nro_documento, doc.gls_desc_tipo as nombre, gls_dres as dres, CAST(nro_tarja as varchar) as nro_tarja, n_estado_doc as estado_doc, gls_consignante, gls_consignatario, gls_despachante from ut_tar_DocumentoConsig_t
	join ut_tar_TipoDocumento_m doc on(ut_tar_DocumentoConsig_t.tipo_documento=doc.cod_tipo)
	where nro_tarja=@NROTARJA
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_estadoCont]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_estadoCont]
AS
BEGIN
	SELECT cod_estado AS CODIGO, gls_nombre_estado AS DESCRIPCION FROM ut_tar_EstadoContenedor_m
	ORDER BY cod_estado DESC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_fotoConso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_fotoConso]
@nro_tarja BIGINT
as
begin
	select nro_tarja, gls_nombreImg, n_seqImg, gls_imagen
	from ut_tar_FotoConsolidado_t
	where nro_tarja=@nro_tarja
	order by gls_nombreImg, n_seqImg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_fotoContDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_fotoContDesc]
@nro_tarja BIGINT
as
begin
	select nro_tarja, gls_nombreImg, n_seqImg, gls_imagen
	from ut_tar_FotoContDesc_t
	where nro_tarja=@nro_tarja and gls_nombreImg not like '%final%'
	order by gls_nombreImg, n_seqImg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_fotoFinDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_fotoFinDesc]
@nro_tarja BIGINT
as
begin
	select nro_tarja, gls_nombreImg, n_seqImg, gls_imagen
	from ut_tar_FotoContDesc_t
	where nro_tarja=@nro_tarja and gls_nombreImg like '%final%'
	order by gls_nombreImg, n_seqImg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_fotoMercDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_fotoMercDesc]
@cod_mercancia BIGINT
as
begin
	select cod_mercancia, gls_nombreImg, n_seqImg, gls_imagen
	from ut_tar_FotoMercDesc
	where cod_mercancia=@cod_mercancia
	order by gls_nombreImg, n_seqImg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_fotoMercExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_fotoMercExpo]
@cod_mercancia BIGINT
as
begin
	select cod_mercancia, gls_nombreImg, n_seqImg, gls_imagen
	from ut_tar_FotoMercCons_t
	where cod_mercancia=@cod_mercancia
	order by gls_nombreImg, n_seqImg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_funcion]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_funcion]
AS
BEGIN
	SELECT * FROM ut_tar_Funciones_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_funcion_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_funcion_01]
@CODIGO INT
AS
BEGIN
	SELECT * FROM ut_tar_Funciones_m
	WHERE cod_funcion=@CODIGO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_grua]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_grua]
AS
BEGIN
	SELECT * FROM ut_tar_Grua_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_grua_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_grua_01]
AS
BEGIN
	SELECT gls_patente as CODIGO, gls_patente AS PATENTE, gls_marca as MARCA FROM ut_tar_Grua_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_gruaExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_gruaExpo]
@nro_tarja BIGINT
AS
BEGIN
	SELECT patente from ut_tar_GruasCons_t
	WHERE nro_tarja=@nro_tarja
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_iso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_iso]
AS
BEGIN
	SELECT cod_iso as codigo, desc_iso as nombre FROM ut_tar_iso_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_iso_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_iso_01]
@CODIGO VARCHAR(20)
AS
BEGIN
	SELECT * FROM ut_tar_iso_m WHERE cod_iso=@CODIGO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mantConsolidadoTrans1]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mantConsolidadoTrans1]
	
AS
BEGIN
	select  fechaS,guia,patente,fechaRetiroConsolidado,horaRetiroConsolidado,nro_tarja as NROTARJA, gls_contenedor AS CONTENEDOR, f.gls_nombre_cliente AS CLIENTE, 
	fecha as FECHA, eT.cod_estado as ESTADO, ter.gls_nombre_terminal as TERMINAL
	from ut_tar_PlanificacionConsolidado_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_EstadoTarja_m eT on(p.cod_estado_tarja = eT.cod_estado)
	join ut_tar_Terminales_m ter on(p.cod_terminal=ter.cod_terminal)
	WHERE eT.gls_nombre_estado = 'Cerradas'
	AND ter.gls_nombre_terminal = 'PLACILLA'
	order by fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mantConsolidadoTrans2]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mantConsolidadoTrans2]
	
AS
BEGIN
	select  fechaS,guia,patente,fechaRetiroConsolidado,horaRetiroConsolidado,nro_tarja as NROTARJA, gls_contenedor AS CONTENEDOR, f.gls_nombre_cliente AS CLIENTE, 
	fecha as FECHA, eT.gls_nombre_estado as ESTADO, ter.gls_nombre_terminal as TERMINAL
	from ut_tar_PlanificacionConsolidado_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_EstadoTarja_m eT on(p.cod_estado_tarja = eT.cod_estado)
	join ut_tar_Terminales_m ter on(p.cod_terminal=ter.cod_terminal)
	WHERE eT.gls_nombre_estado = 'Cerradas'
	AND ter.gls_nombre_terminal = 'SAN ANTONIO'
	order by fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mantDesconsolidadoTrans1]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mantDesconsolidadoTrans1]
	
AS
BEGIN
	select guia,corr_planificacion AS MANIFIESTO,patente,fechaRetiroCont,horaRetiroCont, gls_bl AS BL, corr_planificacion as CORRELATIVO, fw.gls_nombre_cliente as CLIENTE, n.gls_nombre_nave as NAVE, gls_contenedor as CONTENEDOR, fecha as FECHA, eT.gls_nombre_estado as estado,
	ter.gls_nombre_terminal as terminal, gls_desbloqueo_sello as desbloqueo, pl.cod_terminal
	from ut_tar_PlanificacionDesconsolidado_t pl
	join ut_tar_EstadoTarja_m eT
	on(eT.cod_estado = pl.n_estado)
	join ut_tar_Clientes_m fw 
	on(pl.rut_cliente=fw.rut_cliente)
	join ut_tar_Naves_m n
	on(pl.cod_nave=n.cod_nave)
	join ut_tar_Terminales_m ter
	on(pl.cod_terminal = ter.cod_terminal)
	WHERE eT.gls_nombre_estado = 'Cerradas'
	AND ter.gls_nombre_terminal = 'PLACILLA'
	order by fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mantDesconsolidadoTrans2]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mantDesconsolidadoTrans2]
	
AS
BEGIN
	select guia,corr_planificacion AS MANIFIESTO,patente,fechaRetiroCont,horaRetiroCont, gls_bl AS BL, corr_planificacion as CORRELATIVO, fw.gls_nombre_cliente as CLIENTE, n.gls_nombre_nave as NAVE, gls_contenedor as CONTENEDOR, fecha as FECHA, eT.gls_nombre_estado as estado,
	ter.gls_nombre_terminal as terminal, gls_desbloqueo_sello as desbloqueo, pl.cod_terminal
	from ut_tar_PlanificacionDesconsolidado_t pl
	join ut_tar_EstadoTarja_m eT
	on(eT.cod_estado = pl.n_estado)
	join ut_tar_Clientes_m fw 
	on(pl.rut_cliente=fw.rut_cliente)
	join ut_tar_Naves_m n
	on(pl.cod_nave=n.cod_nave)
	join ut_tar_Terminales_m ter
	on(pl.cod_terminal = ter.cod_terminal)
	WHERE eT.gls_nombre_estado = 'Cerradas'
	AND ter.gls_nombre_terminal = 'SAN ANTONIO'
	order by fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_marcaMerc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_marcaMerc]
@cod_mercancia BIGINT
as
begin
	select gls_marca
	from ut_tar_MercanciaDesc_t
	where cod_mercancia=@cod_mercancia
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_marcaMercExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_marcaMercExpo]
@cod_mercancia BIGINT
as
begin
	select gls_marca
	from ut_tar_MercanciaCons_t
	where cod_mercancia=@cod_mercancia
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mercDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mercDesc]
@nro_tarja BIGINT
as
begin
	select nro_tarja, cod_mercancia, gls_marca, gls_condicion, gls_retiro, ut_tar_Bultos_m.desc_bulto, n_cantidad, observacion
	from ut_tar_MercanciaDesc_t
	join ut_tar_Bultos_m on (ut_tar_MercanciaDesc_t.n_bulto = ut_tar_Bultos_m.cod_bulto)
	where nro_tarja=@nro_tarja
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mercDesc_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mercDesc_01]
@nro_tarja BIGINT
as
begin
	select nro_tarja, cod_mercancia, gls_marca, gls_condicion, gls_retiro, n_bulto, n_cantidad, observacion
	from ut_tar_MercanciaDesc_t
	where nro_tarja=@nro_tarja
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mercExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mercExpo]
	@nro_doc VARCHAR(15),
	@nro_tarja BIGINT
AS
BEGIN
	SELECT gls_marca, gls_contenido, n_bulto, n_bulto_sec,
	nro_documento, CAST(nro_tarja as varchar) as nro_tarja, f_peso, f_alto, f_largo, f_ancho, n_cantidad, cod_mercancia
	FROM ut_tar_MercanciaCons_t
	WHERE nro_documento=@nro_doc
	AND nro_tarja=@nro_tarja
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_mercExpo_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_mercExpo_01]
	@cod_mercancia BIGINT
AS
BEGIN
	SELECT *
	FROM ut_tar_MercanciaCons_t
	WHERE cod_mercancia=@cod_mercancia
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_nave]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_nave]
AS
BEGIN
	SELECT * FROM ut_tar_Naves_m order by gls_nombre_nave
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_nave_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_nave_01]
@CODIGO VARCHAR(10)
AS
BEGIN
	SELECT cod_nave AS nav_cod, gls_nombre_nave as nav_nom FROM ut_tar_Naves_m
	WHERE cod_nave=@CODIGO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_permiso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_permiso]
AS
BEGIN
	SELECT cod_permiso as codigo, gls_nombre_perm as nombre from ut_tar_Permisos_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_permiso_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_permiso_01]
@CODIGO int
AS
BEGIN
	SELECT cod_permiso as codigo, gls_nombre_perm as nombre from ut_tar_Permisos_m
	WHERE cod_permiso=@CODIGO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_persona]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_persona]
@TERMINAL varchar(50)
AS
BEGIN
	SELECT rut_persona, dv_persona, gls_nombre_pers, fun.gls_nombre_fun funcion, term.gls_nombre_terminal terminal FROM ut_tar_Personas_m pers
	join ut_tar_Funciones_m fun on (pers.cod_funcion = fun.cod_funcion)
	join ut_tar_Terminales_m term on (pers.cod_terminal = term.cod_terminal)
	where term.gls_nombre_terminal = @TERMINAL
	order by pers.gls_nombre_pers
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_persona_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_persona_01]
	@RUT INT
AS
BEGIN
	SELECT rut_persona, cod_funcion as fun_cod, cod_terminal as age_cod, gls_password as pass_persona, gls_nombre_pers as nom_persona, dv_persona 
	FROM ut_tar_Personas_m
	WHERE rut_persona=@RUT
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_persona_02]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_persona_02]
@RUT INT
AS
BEGIN
	DECLARE
	@codTerminal INT

	SELECT @codTerminal = cod_terminal FROM ut_tar_Personas_m WHERE rut_persona = @RUT

	SELECT rut_persona, gls_nombre_pers AS nom_persona, fun.gls_nombre_fun AS FUNCION, term.gls_nombre_terminal AS TERMINAL FROM ut_tar_Personas_m pers
	join ut_tar_Funciones_m fun on (pers.cod_funcion = fun.cod_funcion)
	join ut_tar_Terminales_m term on (pers.cod_terminal = term.cod_terminal)
	WHERE pers.cod_terminal = @codTerminal
	ORDER BY pers.gls_nombre_pers
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_personasTarja]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_personasTarja]
@nro_tarja BIGINT
AS
BEGIN
	SELECT p.rut_persona, gls_nombre_pers AS nom_persona, fun.gls_nombre_fun AS FUNCION, term.gls_nombre_terminal AS TERMINAL FROM ut_tar_PersonasTarjaDesc_t pers
	JOIN ut_tar_Personas_m p on (pers.rut_persona = p.rut_persona)
	join ut_tar_Funciones_m fun on (p.cod_funcion = fun.cod_funcion)
	join ut_tar_Terminales_m term on (p.cod_terminal = term.cod_terminal)
	where pers.nro_tarja = @nro_tarja
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_personasTarjaExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_personasTarjaExpo]
@nro_tarja BIGINT
AS
BEGIN
	SELECT p.rut_persona, gls_nombre_pers AS nom_persona, fun.gls_nombre_fun AS FUNCION, term.gls_nombre_terminal AS TERMINAL FROM ut_tar_PersonasTarjaCons_t pers
	JOIN ut_tar_Personas_m p on (pers.rut_persona = p.rut_persona)
	join ut_tar_Funciones_m fun on (p.cod_funcion = fun.cod_funcion)
	join ut_tar_Terminales_m term on (p.cod_terminal = term.cod_terminal)
	where pers.nro_tarja = @nro_tarja
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planDespacho]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_planDespacho] 
@TARJADOR INT
AS
BEGIN
	SELECT CAST(nro_tarja as varchar) AS nro_tarja_despacho, f.gls_nombre_cliente AS nombre_cliente, cod_puerto_dest AS puerto_destino, patente AS patente_camion, rut_tarjador AS tarjador, n_estado AS estado_tarja, fecha, hora_inicio, hora_term, pagina as gls_pagina from ut_tar_PlanificacionDespacho_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	WHERE rut_tarjador=@TARJADOR and (n_estado = 1 or n_estado = 2 or n_estado = 4)
	ORDER BY p.fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planDespacho_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_planDespacho_01]
@cod_terminal int
AS
BEGIN
	SELECT CAST(p.nro_tarja as varchar) as nro_tarja, f.gls_nombre_cliente AS nombre_cliente, patente, CONVERT(varchar(11),p.fecha,103) as fecha, t.gls_nombre_terminal as terminal, et.gls_nombre_estado AS estado_tarja 
	from ut_tar_PlanificacionDespacho_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_Terminales_m t on(p.cod_terminal = t.cod_terminal)
	join ut_tar_EstadoTarja_m et on(p.n_estado = et.cod_estado)
	where p.cod_terminal=@cod_terminal
	order by p.fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planDespacho_02]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_planDespacho_02] 
@nro_tarja BIGINT
AS
BEGIN
	SELECT nro_tarja, patente, cod_terminal, cod_transporte, n_vuelta, cod_puerto_or, cod_puerto_dest, rut_cliente, rut_tarjador, observacion, fecha, fecha_term as fecha_termino, hora_inicio, hora_term as hora_termino
	from ut_tar_PlanificacionDespacho_t 
	WHERE nro_tarja=@nro_tarja
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_PlanificacionCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_PlanificacionCons]
@cod_terminal int
as
begin
	select p.guia ,p.patente,p.fechaRetiroConsolidado,p.horaRetiroConsolidado, CAST(p.nro_tarja as varchar) as NROTARJA, p.gls_contenedor AS CONTENEDOR, f.gls_nombre_cliente AS CLIENTE, 
	CONVERT(varchar(11),p.fecha,103) as FECHA, eT.gls_nombre_estado as ESTADO, ter.gls_nombre_terminal as TERMINAL
	from ut_tar_PlanificacionConsolidado_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_EstadoTarja_m eT on(p.cod_estado_tarja = eT.cod_estado)
	join ut_tar_Terminales_m ter on(p.cod_terminal=ter.cod_terminal)
	where p.cod_terminal=@cod_terminal
	and p.fecha > DATEADD(MONTH,-3, GETDATE())
	order by p.fecha desc
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_PlanificacionCons_02]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_PlanificacionCons_02]
@TARJADOR INT
as
begin
	select CAST(p.nro_tarja as varchar) AS nro_tarja_cons, f.gls_nombre_cliente AS nombre_cliente, p.cod_puerto_dest AS puerto_d, n.gls_nombre_nave AS nav_nom, p.gls_contenedor AS contenedor, p.cod_iso, p.rut_tarjador AS tarjador, p.gls_sello AS sello, p.f_capacidad AS capacidad, p.cod_estado_tarja AS estado_tarja, p.fecha, p.hora_inicio, p.hora_term, p.gls_pagina from ut_tar_PlanificacionConsolidado_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_Naves_m n on(p.cod_nave = n.cod_nave)
	WHERE rut_tarjador=@TARJADOR AND (cod_estado_tarja = 1 OR cod_estado_tarja = 2 or cod_estado_tarja = 4)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planificacionConsCliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_planificacionConsCliente]
@rut_cliente INT
as
begin
	select guia, patente, fechaRetiroConsolidado, horaRetiroConsolidado, CAST(nro_tarja as varchar) as NROTARJA, gls_contenedor AS CONTENEDOR, f.gls_nombre_cliente AS CLIENTE, 
	fecha as FECHA, eT.gls_nombre_estado as ESTADO, ter.gls_nombre_terminal as TERMINAL
	from ut_tar_PlanificacionConsolidado_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_EstadoTarja_m eT on(p.cod_estado_tarja = eT.cod_estado)
	join ut_tar_Terminales_m ter on(p.cod_terminal=ter.cod_terminal)
	WHERE p.rut_cliente = @rut_cliente
	  AND p.nro_tarja <> 2017723111410493
	order by p.fecha desc
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planificacionConso_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_planificacionConso_01]
@nro_tarja BIGINT
as
begin
	select nro_tarja, rut_cliente, n_viaje, rut_tarjador, cod_estado_tarja, cod_puerto_or, cod_puerto_dest, cod_nave, gls_contenedor, cod_iso, gls_sello, gls_reserva, gls_observación as observacion, f_capacidad, f_duracion as duracion, fecha, fecha_termino, hora_inicio, hora_term as hora_termino  from ut_tar_PlanificacionConsolidado_t where nro_tarja = @nro_tarja
end

GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planificacionDespCliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_planificacionDespCliente] 
@rut_cliente Int
AS
BEGIN
	SELECT nro_tarja, f.gls_nombre_cliente AS nombre_cliente, patente, CONVERT(varchar(11),p.fecha,103) as fecha, t.gls_nombre_terminal as terminal, et.gls_nombre_estado AS estado_tarja 
	from ut_tar_PlanificacionDespacho_t p
	join ut_tar_Clientes_m f on(p.rut_cliente = f.rut_cliente)
	join ut_tar_Terminales_m t on(p.cod_terminal = t.cod_terminal)
	join ut_tar_EstadoTarja_m et on(p.n_estado = et.cod_estado)
	where p.rut_cliente=@rut_cliente
	order by p.fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planTarjaDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_sel_planTarjaDesc]
@cod_terminal int
as
begin
	select guia,corr_planificacion,patente,fechaRetiroCont,horaRetiroCont, gls_bl, fw.gls_nombre_cliente as CLIENTE, n.gls_nombre_nave as NAVE, gls_contenedor as CONTENEDOR, CONVERT(varchar(11),pl.fecha,103) as FECHA, eT.gls_nombre_estado as estado,
	ter.gls_nombre_terminal as terminal, gls_desbloqueo_sello as desbloqueo, pl.cod_terminal
	from ut_tar_PlanificacionDesconsolidado_t pl
	join ut_tar_EstadoTarja_m eT
	on(eT.cod_estado = pl.n_estado)
	join ut_tar_Clientes_m fw 
	on(pl.rut_cliente=fw.rut_cliente)
	join ut_tar_Naves_m n
	on(pl.cod_nave=n.cod_nave)
	join ut_tar_Terminales_m ter
	on(pl.cod_terminal = ter.cod_terminal)
	where pl.cod_terminal = @cod_terminal
	and pl.fecha > DATEADD(MONTH,-3, GETDATE())
	order by pl.fecha desc
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planTarjaDesc_cliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_sel_planTarjaDesc_cliente]
@rut_cliente INT
as
begin
	select guia,corr_planificacion,patente,fechaRetiroCont,horaRetiroCont, gls_bl, fw.gls_nombre_cliente as CLIENTE, n.gls_nombre_nave as NAVE, gls_contenedor as CONTENEDOR, CONVERT(varchar(11),fecha,103) as FECHA, eT.gls_nombre_estado as estado,
	ter.gls_nombre_terminal as terminal, gls_desbloqueo_sello as desbloqueo, pl.cod_terminal
	from ut_tar_PlanificacionDesconsolidado_t pl
	join ut_tar_EstadoTarja_m eT
	on(eT.cod_estado = pl.n_estado)
	join ut_tar_Clientes_m fw 
	on(pl.rut_cliente=fw.rut_cliente)
	join ut_tar_Naves_m n
	on(pl.cod_nave=n.cod_nave)
	join ut_tar_Terminales_m ter
	on(pl.cod_terminal = ter.cod_terminal)
	where pl.rut_cliente=@rut_cliente
	order by pl.fecha desc
	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_planTarjaDescID]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_sel_planTarjaDescID]
@corr_plan varchar(50)
as
begin
	select gls_bl as bl, cod_puerto_or as pue_codO, gls_contenedor as cod_contenedor, cod_iso, gls_sello1 as sello1, gls_sello2 as sello2, gls_sello3 as sello3, gls_mano_trabajo as mddt, cod_nave, cod_puerto_dest as pue_codD, corr_planificacion as cod_manifiesto, gls_desbloqueo_sello as desbloqueo_sello, rut_cliente, n_viaje as cod_viaje, cod_terminal as cod_agencia, n_estado as estado_tarja, rut_tarjador, duracion, fecha, fecha_termino as fechaT, hora_in as horaI, hora_term as horaT, hora_inicioR as horaIR, hora_termR as horaTR, selloFis1, selloFis2, selloFis3, tara from ut_tar_PlanificacionDesconsolidado_t where corr_planificacion = @corr_plan
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_puerto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_puerto]
AS
BEGIN
	SELECT cod_puerto as CODIGO, gls_nombre_puerto as NOMBRE from ut_tar_Puertos_m order by gls_nombre_puerto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_puerto_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_puerto_01]
@cod_puerto varchar(30)
AS
BEGIN
	SELECT cod_puerto, gls_nombre_puerto from ut_tar_Puertos_m
	where (cod_puerto = @cod_puerto)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_sectorVector_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_sectorVector_01]
@nro_tarja bigint
AS
BEGIN
	SELECT nro_tarja, ut_tar_SectorVector_t.nro_sector, ut_tar_EstadoContenedor_m.gls_nombre_estado, ut_tar_SectorVector_t.cod_estado from ut_tar_SectorVector_t
	join ut_tar_EstadoContenedor_m on (ut_tar_SectorVector_t.cod_estado = ut_tar_EstadoContenedor_m.cod_estado)
	where nro_tarja=@nro_tarja
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_tarjaDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_tarjaDesc]
@RUT INT
AS
BEGIN
	SELECT gls_bl AS BL, corr_planificacion AS cod_manifiesto, te.gls_nombre_terminal AS terminal, n.gls_nombre_nave AS nave, n_viaje AS cod_viaje, cod_puerto_or AS pue_codO, cod_puerto_dest AS pue_codD, f.gls_nombre_cliente AS cliente, cod_iso, n_estado AS estado_tarja, gls_contenedor AS cod_contenedor, gls_sello1 AS sello1, 
	gls_sello2 AS sello2, gls_sello3 AS sello3,	fecha, rut_tarjador, gls_mano_trabajo AS MDDT, gls_desbloqueo_sello AS desbloqueo_sello, duracion, gls_pagina, hora_inicioR, hora_termR, tara
	FROM ut_tar_PlanificacionDesconsolidado_t pl
	JOIN ut_tar_Terminales_m te ON(pl.cod_terminal=te.cod_terminal)
	JOIN ut_tar_Naves_m n ON(pl.cod_nave=n.cod_nave)
	JOIN ut_tar_Clientes_m f ON(pl.rut_cliente=f.rut_cliente)
	
	WHERE rut_tarjador = @RUT and (n_estado = 1 or n_estado = 2 or n_estado = 4)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_tarjaDescDet]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_tarjaDescDet]
@corr_plan varchar(50)
as
begin
	select nro_tarja, patente_grua, observacion, corr_planificacion
	from ut_tar_DetTarjaDesc_t
	where corr_planificacion=@corr_plan
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_tarjador]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_tarjador]
@TERMINAL varchar(50)
AS
BEGIN
	SELECT rut_persona, gls_nombre_pers FROM ut_tar_Personas_m per
	join ut_tar_Terminales_m term
	on(per.cod_terminal=term.cod_terminal)
	where cod_funcion=2 and term.gls_nombre_terminal=@TERMINAL
	order by gls_nombre_pers
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_terminal]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_terminal]
AS
BEGIN
	SELECT cod_terminal as CODIGO, gls_nombre_terminal as TERMINAL from ut_tar_Terminales_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_terminal_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_terminal_01]
	@cod_terminal int
AS
BEGIN
	SELECT cod_terminal as CODIGO, gls_nombre_terminal as TERMINAL from ut_tar_Terminales_m where cod_terminal=@cod_terminal
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_tipoDoc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_tipoDoc]
AS
BEGIN
	SELECT * from ut_tar_TipoDocumento_m
END
GO
/****** Object:  StoredProcedure [dbo].[sp_sel_tipoDoc_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_sel_tipoDoc_01]
@cod_tipo int
AS
BEGIN
	SELECT * from ut_tar_TipoDocumento_m
	where cod_tipo=@cod_tipo
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_bulto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_bulto]
	@CODIGO int,
	@NOMBRE varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Bultos_m
			
			SET		desc_bulto = @NOMBRE
			WHERE	cod_bulto = @CODIGO
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El bulto se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_cliente]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_cliente]
	@RUT INT,
	@RAZON VARCHAR(120),
	@PASSWORD VARCHAR(10),
	@TELEFONO INT,
	@EMAIL VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Clientes_m
			
			SET		gls_nombre_cliente = @RAZON,
					gls_password = @PASSWORD,
					gls_mail = @EMAIL,
					n_fono = @TELEFONO
			WHERE	rut_cliente=@RUT
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El cliente se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_cliente_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_cliente_01]
	@PASS varchar(10),
	@RUT int
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Clientes_m
			
			SET		gls_password = @PASS
			WHERE	rut_cliente = @RUT
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El cliente se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosCons]

	@NROTARJA				bigint,
	@CLIENTE				varchar(50),
	@CONTENEDOR				varchar(50), 
	@horaRetiroConsolidado 	time,
	@fechaRetiroConsolidado	datetime,
	@patente				varchar(50),
	@guia					varchar(50),
	@fechaS				    date

	
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionConsolidado_t	
			SET		horaRetiroConsolidado = @horaRetiroConsolidado,
					fechaRetiroConsolidado = @fechaRetiroConsolidado,
					patente	= @patente,
					guia = @guia,
					fechaS = @fechaS	
					
					
			WHERE	nro_tarja	     = @NROTARJA
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El consolidado se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosCons_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosCons_01]
@NROTARJA bigint,
@SELLO nvarchar(30),
@ESTADOTARJA INT,
@OBSERVACION text,
@HORAI TIME(7),
@HORAT TIME(7),
@FECHAI DATE,
@FECHAT DATE,
@DURACION DECIMAL(5,3)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionConsolidado_t
			set gls_sello=@SELLO,
			cod_estado_tarja=@ESTADOTARJA,
			gls_observación = @OBSERVACION,
			hora_inicio = @HORAI,
			hora_term = @HORAT,
			fecha = @FECHAI,
			fecha_termino = @FECHAT,
			f_duracion = @DURACION
			where nro_tarja = @NROTARJA
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El consolidado se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosCons2]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosCons2]

	@NROTARJA				bigint,
	@CLIENTE				varchar(50),
	@CONTENEDOR				varchar(50), 
	@horaRetiroConsolidado 	time,
	@fechaRetiroConsolidado	datetime,
	@patente				varchar(50),
	@guia					varchar(50),
	@fechaS				    date

	
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionConsolidado_t	
			SET		horaRetiroConsolidado = @horaRetiroConsolidado,
					fechaRetiroConsolidado = @fechaRetiroConsolidado,
					patente	= @patente,
					guia = @guia,
					fechaS = @fechaS,
					estadoGuia = 1	
					
					
			WHERE	nro_tarja	     = @NROTARJA
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El consolidado se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosDesc]

	
	@cod_manifiesto			varchar(50),
	@BL						varchar(50),
	@fechaRetiroCont		datetime, 
	@horaRetiroCont			time,
	@patente				varchar(50),
	@guia					varchar(50)

	
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionDesconsolidado_t
			SET		gls_bl		 = @BL,		
					fechaRetiroCont = @fechaRetiroCont,
					horaRetiroCont = @horaRetiroCont,
					patente	= @patente,
					guia	= @guia	
					
					
			WHERE	corr_planificacion	     = @cod_manifiesto
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El desconsolidado se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosDesc_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosDesc_01]
@manifiesto varchar(50),
@bl varchar(30),
@terminal nvarchar(25),
@nave nvarchar(50),
@viaje int,
@puertoO nvarchar(10),
@puertoD nvarchar(10),
@cliente nvarchar(50),
@iso nvarchar(20),
@estadoTarja int,
@contenedor nvarchar(20),
@sello1 nvarchar(20),
@sello2 nvarchar(20),
@sello3 nvarchar(20),
@tarjador int,
@mddt varchar(10),
@fecha date,
@fechatermino date,
@horaI time(4),
@horaT time(4),
@tara int,
@duracion decimal(5,3)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionDesconsolidado_t
			set gls_bl = @bl,
			cod_terminal = (select cod_terminal from ut_tar_Terminales_m where gls_nombre_terminal = @terminal),
			cod_nave = (select cod_nave from ut_tar_Naves_m where gls_nombre_nave = @nave),
			n_viaje = @viaje,
			rut_cliente = (select rut_cliente from ut_tar_Clientes_m where gls_nombre_cliente = @cliente),
			cod_iso = @iso,
			n_estado = @estadoTarja,
			gls_contenedor = @contenedor,
			sellofis1 = @sello1,
			sellofis2 = @sello2,
			sellofis3 = @sello3,
			rut_tarjador = @tarjador,
			gls_mano_trabajo = @mddt,
			fecha = @fecha,
			fecha_termino = @fechatermino,
			hora_inicioR = @horaI,
			hora_termR = @horaT,
			tara = @tara,
			duracion = @duracion
			where corr_planificacion = @manifiesto;
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El Desconsolidado se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosDesc2]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosDesc2]

	--@cod_manifiesto			varchar(50),
	@cod_manifiesto			varchar(50),
	@BL						varchar(50),
	@fechaRetiroCont		datetime, 
	@horaRetiroCont			time,
	@patente				varchar(50),
	@guia					varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionDesconsolidado_t
			SET		gls_bl		 = @BL,		
					fechaRetiroCont = @fechaRetiroCont,
					horaRetiroCont = @horaRetiroCont,
					patente	= @patente,
					guia	= @guia,
					estadoGuia	= 1	
					
					
			WHERE	corr_planificacion	     = @cod_manifiesto
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El desconsolidado se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_datosDesp]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_datosDesp]
@NROTARJA BIGINT,
@ESTADOTARJA INT,
@OBSERVACION NVARCHAR(50),
@HORAI TIME(7),
@HORAT TIME(7),
@FECHAI DATE,
@FECHAT DATE,
@DURACION DECIMAL(5,3)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			update ut_tar_PlanificacionDespacho_t
			set n_estado=@ESTADOTARJA,
			observacion = @OBSERVACION,
			hora_inicio = @HORAI,
			hora_term = @HORAT,
			fecha = @FECHAI,
			fecha_term = @FECHAT,
			duracion = @DURACION
			where nro_tarja = @NROTARJA
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El Despacho se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_documentoConsig]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_documentoConsig]
	@NRO_DOC varchar(15),
	@TIPO_DOC INT,
	@DRES varchar(30),
	@CONSIGNANTE varchar(30),
	@CONSIGNATARIO varchar(30),
	@DESPACHANTE varchar(30),
	@NROTARJA BIGINT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_DocumentoConsig_t
			
			SET		tipo_documento = @TIPO_DOC,
					gls_dres = @DRES,
					gls_consignante = @CONSIGNANTE,
					gls_consignatario = @CONSIGNATARIO,
					gls_despachante = @DESPACHANTE
			WHERE	nro_documento = @NRO_DOC
			and		nro_tarja = @NROTARJA
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El documento se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_funcion]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_funcion]
	@CODIGO INT,
	@NOMBRE VARCHAR(20),
	@PERMISO INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Funciones_m
			
			SET		gls_nombre_fun = @NOMBRE,
					cod_permiso = @PERMISO
			WHERE	cod_funcion=@CODIGO
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La funcion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_grua]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_grua]
	@PATENTE varchar(20),
	@MARCA varchar(50),
	@TERMINAL INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Grua_m
			
			SET		gls_marca = @MARCA,
					n_terminal = @TERMINAL
			WHERE	gls_patente = @PATENTE
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La grua se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_iso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_iso]
	@CODIGO varchar(20),
	@NOMBRE varchar(50),
	@TARA INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_iso_m
			
			SET		desc_iso = @NOMBRE,
					tara = @TARA
			WHERE	cod_iso = @CODIGO
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El codigo iso se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_mercanciaExpo]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_mercanciaExpo]
	@cod_mercancia	bigint,
	@nro_documento	varchar(15),
	@nro_tarja	bigint,
	@gls_marca	varchar(100),
	@gls_contenido	varchar(150),
	@n_bulto	int,
	@n_bulto_sec	int,
	@f_peso	float,
	@f_alto	float,
	@f_ancho	float,
	@f_largo	float,
	@n_cantidad	int,
	@gls_observacion	varchar(500)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_MercanciaCons_t
			
			SET		gls_marca = @gls_marca,
					gls_contenido = @gls_contenido,
					n_bulto = @n_bulto,
					n_bulto_sec = @n_bulto_sec,
					f_peso = @f_peso,
					f_alto = @f_alto,
					f_ancho = @f_ancho,
					f_largo = @f_largo,
					n_cantidad = @n_cantidad,
					gls_observacion = @gls_observacion
			WHERE	nro_tarja = @nro_tarja
			and		nro_documento = @nro_documento
			and     cod_mercancia = @cod_mercancia
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El documento se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_nave]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_nave]
	@CODIGO VARCHAR(10),
	@NOMBRE varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Naves_m
			
			SET		gls_nombre_nave = @NOMBRE
			WHERE	cod_nave = @CODIGO
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La nave se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_permiso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_permiso]
	@cod_permiso int,
	@gls_nombre_perm varchar,
	@n_movil int,
	@n_web int

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Permisos_m
			
			SET		gls_nombre_perm = @gls_nombre_perm,
			        n_movil = @n_movil,
			        n_web = @n_web
			where   cod_permiso = @cod_permiso
					
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El permiso se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_persona]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_persona]
	@rut_persona INT,
	@gls_nombre_pers VARCHAR(90),
	@gls_password VARCHAR(10),
	@cod_funcion INT,
	@cod_terminal INT

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Personas_m
			
			SET		gls_nombre_pers = @gls_nombre_pers,
					gls_password = @gls_password,
					cod_funcion  = @cod_funcion,
					cod_terminal = @cod_terminal
			WHERE   rut_persona  = @rut_persona 
					
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La persona se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_planDesp]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_planDesp]
	@nro_tarja          bigint,
	@rut_cliente        int,
	@fecha              Date,
	@cod_puerto_or      varchar(10),
	@cod_puerto_dest    varchar(10),
	@n_vuelta            int,
	@cod_transporte           varchar(10),
	@patente     varchar(10),
	@rut_tarjador       int,
	@cod_terminal       int	

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionDespacho_t
			
			SET		rut_cliente     = @rut_cliente, 
			        fecha_term   = @fecha,
			        cod_puerto_dest = cod_puerto_dest,  
			        cod_transporte        = @cod_transporte, 
					patente  = @patente, 
					rut_tarjador    = @rut_tarjador,
					n_vuelta         = @n_vuelta
			WHERE	nro_tarja       = @nro_tarja
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_planificacionConso]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_planificacionConso]
	@nro_tarja          bigint,
	@rut_cliente        int,
	@fecha              Date,
	@gls_reserva        varchar(50),
	@cod_puerto_or      varchar(10),
	@cod_puerto_dest    varchar(10),
	@n_viaje            int,
	@cod_nave           varchar(10),
	@cod_iso            varchar(20),
	@gls_contenedor     varchar(20),
	@f_capacidad        float,
	@gls_sello          varchar(20),
	@rut_tarjador       int,
	@cod_terminal       int	

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionConsolidado_t
			
			SET		rut_cliente     = @rut_cliente, 
			        fecha           = @fecha,
			        gls_reserva     = @gls_reserva, 
			        cod_puerto_or   = @cod_puerto_or, 
			        cod_puerto_dest = cod_puerto_dest, 
			        n_viaje         = @n_viaje, 
			        cod_nave        = @cod_nave, 
			        cod_iso         = @cod_iso,
					gls_contenedor  = @gls_contenedor, 
					f_capacidad     = @f_capacidad, 
					gls_sello       = @gls_sello, 
					rut_tarjador    = @rut_tarjador, 
					cod_terminal    = @cod_terminal	
			WHERE	nro_tarja       = @nro_tarja
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_planificacionConso_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_planificacionConso_01]
	@nro_tarja          bigint,
	@sello  varchar(20),
	@observacion  text,
	@horaI time(7),
	@horaT time(7),
	@estadoTarja int,
	@fechaI date,
	@fechat date,
	@duracion float,
	@pagina varchar(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionConsolidado_t
			
			SET	gls_sello =	@sello,
				gls_observación = @observacion,
				hora_inicio = @horaI,
				hora_term =	@horaT,
				cod_estado_tarja =	@estadoTarja,
				fecha =	@fechaI,
				fecha_termino =	@fechat,
				f_duracion = @duracion,
				gls_pagina = @pagina
			WHERE	nro_tarja       = @nro_tarja
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_planificacionDesco]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_planificacionDesco]
	@corr_planificacion	varchar(50),
	@gls_bl	varchar(30),
	@cod_puerto_or	varchar(10),
	@cod_puerto_dest	varchar(10),
	@gls_contenedor	varchar(20),
	@cod_iso	varchar(20),
	@gls_sello1	varchar(20),
	@gls_sello2	varchar(20),
	@gls_sello3	varchar(20),
	@rut_cliente	int,
	@fecha	date,
	@hora_in	time(7),
	@hora_term	time(7),
	@gls_mano_trabajo	varchar(10),
	@cod_nave	varchar(10),
	@n_viaje	int,
	@cod_terminal	int,
	@n_estado	int,
	@gls_desbloqueo_sello	varchar(20),
	@rut_tarjador	int	

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionDesconsolidado_t
			
			SET		gls_bl = @gls_bl,
					cod_puerto_or = @cod_puerto_or,
					cod_puerto_dest = @cod_puerto_dest,
					gls_contenedor = @gls_contenedor,
					cod_iso = @cod_iso,
					gls_sello1 = @gls_sello1,
					gls_sello2 = @gls_sello2,
					gls_sello3 = @gls_sello3,
					rut_cliente = @rut_cliente,
					fecha = @fecha,
					hora_in = @hora_in,
					hora_term = @hora_term,
					gls_mano_trabajo = @gls_mano_trabajo,
					cod_nave = @cod_nave,
				 	n_viaje = @n_viaje,
					cod_terminal = @cod_terminal,
					n_estado = @n_estado,
					gls_desbloqueo_sello = @gls_desbloqueo_sello,
					rut_tarjador = @rut_tarjador	
			WHERE	corr_planificacion = @corr_planificacion
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_planificacionDesco_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_planificacionDesco_01]
	@corr_planificacion	varchar(50),
	@gls_bl	varchar(30),
	@cod_puerto_or	varchar(10),
	@cod_puerto_dest	varchar(10),
	@gls_contenedor	varchar(20),
	@cod_iso	varchar(20),
	@gls_sello1	varchar(20),
	@gls_sello2	varchar(20),
	@gls_sello3	varchar(20),
	@fecha	date,
	@hora_in	time(7),
	@hora_term	time(7),
	@gls_mano_trabajo	varchar(10),
	@cod_nave	varchar(10),
	@n_viaje	int,
	@n_estado	int,
	@duracion	float,
	@rut_tarjador	int,
	@tara float,
	@pagina varchar(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionDesconsolidado_t
			
			SET		gls_bl = @gls_bl,
					cod_puerto_or = @cod_puerto_or,
					cod_puerto_dest = @cod_puerto_dest,
					gls_contenedor = @gls_contenedor,
					cod_iso = @cod_iso,
					selloFis1 = @gls_sello1,
					selloFis2 = @gls_sello2,
					selloFis3 = @gls_sello3,
					fecha_termino = @fecha,
					hora_inicioR = @hora_in,
					hora_termR = @hora_term,
					gls_mano_trabajo = @gls_mano_trabajo,
				 	n_viaje = @n_viaje,
					n_estado = @n_estado,
					duracion = @duracion,
					rut_tarjador = @rut_tarjador,
					tara = @tara,
					gls_pagina = @pagina
			WHERE	corr_planificacion = @corr_planificacion
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_planificacionDesp_01]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_planificacionDesp_01]
	@nro_tarja          bigint,
	@observacion  text,
	@horaI time(7),
	@horaT time(7),
	@estadoTarja int,
	@fechaI date,
	@fechat date,
	@duracion float,
	@pagina varchar(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_PlanificacionDespacho_t
			
			SET	observacion = @observacion,
				hora_inicio = @horaI,
				hora_term =	@horaT,
				n_estado =	@estadoTarja,
				fecha =	@fechaI,
				fecha_term =	@fechat,
				duracion = @duracion,
				pagina = @pagina
			WHERE	nro_tarja       = @nro_tarja
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'La planificacion se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_puerto]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_puerto]
	@cod_puerto varchar(30),
	@gls_nombre_puerto varchar(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Puertos_m
			
			SET		gls_nombre_puerto = @gls_nombre_puerto
			where   cod_puerto = @cod_puerto
					
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El puerto se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_terminal]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_terminal]
	@cod_terminal int,
	@gls_nombre_terminal varchar(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_Terminales_m
			
			SET		gls_nombre_terminal = @gls_nombre_terminal
			where   cod_terminal = @cod_terminal
					
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El terminal se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upd_tipoDoc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upd_tipoDoc]
	@cod_tipo int,
	@gls_desc_tipo varchar(50)

AS
BEGIN
	BEGIN TRY
		BEGIN TRAN								
			
			UPDATE	ut_tar_TipoDocumento_m
			
			SET		gls_desc_tipo = @gls_desc_tipo
			where   cod_tipo = @cod_tipo
					
			
			SELECT  @@ERROR AS ERROR_NUMBER, 'El tipo de documento se modificó correctamente' AS ERROR_MESSAGE
			
			COMMIT TRAN					
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT  ERROR_NUMBER() AS ERROR_NUMBER, ERROR_MESSAGE() AS ERROR_MESSAGE
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SPSelectTarjaDescPantalla]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPSelectTarjaDescPantalla]
AS
BEGIN
	select gls_contenedor as cod_contenedor, eT.gls_nombre_estado as estado, ter.gls_nombre_terminal as terminal, pl.n_estado as estado_tarja
	from ut_tar_PlanificacionDesconsolidado_t pl
	join ut_tar_EstadoTarja_m eT
	on(eT.cod_estado = pl.n_estado)
	join ut_tar_Terminales_m ter
	on(pl.cod_terminal = ter.cod_terminal)
	WHERE CONVERT(DATE, fecha) = CONVERT(DATE, GETDATE())
	AND ter.gls_nombre_terminal = 'PLACILLA'
	AND pl.n_estado=3
	ORDER BY fecha DESC
END
GO
/****** Object:  StoredProcedure [dbo].[SPSelectTarjaDescPantallaSAI]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPSelectTarjaDescPantallaSAI]
AS
BEGIN
	select gls_contenedor as cod_contenedor, eT.gls_nombre_estado as estado, ter.gls_nombre_terminal as terminal, pl.n_estado as estado_tarja
	from ut_tar_PlanificacionDesconsolidado_t pl
	join ut_tar_EstadoTarja_m eT
	on(eT.cod_estado = pl.n_estado)
	join ut_tar_Terminales_m ter
	on(pl.cod_terminal = ter.cod_terminal)
	WHERE CONVERT(DATE, fecha) = CONVERT(DATE, GETDATE())
	AND ter.gls_nombre_terminal = 'SAN ANTONIO'
	AND pl.n_estado=3
	ORDER BY fecha DESC
END
GO
/****** Object:  StoredProcedure [dbo].[SPUploadFotoCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPUploadFotoCons]
	@NRO_TARJA BIGINT,
	@SEQ_IMG INT,
	@NOMBRE VARCHAR(50),
	@IMAGEN varchar(max)
AS
BEGIN
	begin tran
	insert into ut_tar_FotoConsolidado_t(nro_tarja, n_seqImg, gls_nombreImg, gls_imagen) values(@NRO_TARJA, @SEQ_IMG, @NOMBRE, @IMAGEN)
	commit
END
GO
/****** Object:  StoredProcedure [dbo].[SPUploadFotoMercCons]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPUploadFotoMercCons]
	@COD_MERC BIGINT,
	@SEQ_IMG INT,
	@NOMBRE VARCHAR(50),
	@IMAGEN varchar(max)
AS
BEGIN
	begin tran
	insert into ut_tar_FotoMercCons_t(cod_mercancia, gls_nombreImg, n_seqImg, gls_imagen) 
	values(@COD_MERC, @NOMBRE, @SEQ_IMG, @IMAGEN)
	commit
END
GO
/****** Object:  StoredProcedure [dbo].[SPUploadFotoMercDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPUploadFotoMercDesc]
	@COD_MERC bigint,
	@SEQ_IMG int,
	@NOMBRE varchar(50),
	@IMAGEN varchar(max)
AS
BEGIN
	insert into ut_tar_FotoMercDesc(cod_mercancia, n_seqImg, gls_nombreImg, gls_imagen)
	values(@COD_MERC, @SEQ_IMG, @NOMBRE, @IMAGEN)
END
GO
/****** Object:  StoredProcedure [dbo].[SPUploadFotosDesc]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPUploadFotosDesc]
	@NRO_TARJA bigint,
	@SEQ_IMG int,
	@NOMBRE varchar(50),
	@IMAGEN varchar(max)
AS
BEGIN
	insert into ut_tar_FotoContDesc_t(nro_tarja, n_seqImg, gls_nombreImg, gls_imagen)
	values(@NRO_TARJA, @SEQ_IMG, @NOMBRE, @IMAGEN)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Sizing]    Script Date: 23-07-2019 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Sizing] @Granularity VARCHAR(10) = NULL, @Database_Name sysname = NULL AS   
DECLARE @SQL VARCHAR(5000)   

IF EXISTS (SELECT NAME FROM tempdb..sysobjects WHERE NAME = '##Results')    
   BEGIN    
       DROP TABLE ##Results    
   END   
      
CREATE TABLE ##Results ([Database Name] sysname, 
[File Name] sysname, 
[Physical Name] NVARCHAR(260),
[File Type] VARCHAR(4), 
[Total Size in Mb] INT, 
[Available Space in Mb] INT, 
[Growth Units] VARCHAR(15), 
[Max File Size in Mb] INT)   

SELECT @SQL =    
'USE [?] INSERT INTO ##Results([Database Name], [File Name], [Physical Name],    
[File Type], [Total Size in Mb], [Available Space in Mb],    
[Growth Units], [Max File Size in Mb])    
SELECT DB_NAME(),   
[name] AS [File Name],    
physical_name AS [Physical Name],    
[File Type] =    
CASE type   
WHEN 0 THEN ''Data'''    
+   
           'WHEN 1 THEN ''Log'''   
+   
       'END,   
[Total Size in Mb] =   
CASE ceiling([size]/128)    
WHEN 0 THEN 1   
ELSE ceiling([size]/128)   
END,   
[Available Space in Mb] =    
CASE ceiling([size]/128)   
WHEN 0 THEN (1 - CAST(FILEPROPERTY([name], ''SpaceUsed''' + ') as int) /128)   
ELSE (([size]/128) - CAST(FILEPROPERTY([name], ''SpaceUsed''' + ') as int) /128)   
END,   
[Growth Units]  =    
CASE [is_percent_growth]    
WHEN 1 THEN CAST(growth AS varchar(20)) + ''%'''   
+   
           'ELSE CAST(growth*8/1024 AS varchar(20)) + ''Mb'''   
+   
       'END,   
[Max File Size in Mb] =    
CASE [max_size]   
WHEN -1 THEN NULL   
WHEN 268435456 THEN NULL   
ELSE [max_size]   
END   
FROM sys.database_files   
ORDER BY [File Type], [file_id]'   

--Print the command to be issued against all databases   
PRINT @SQL   

--Run the command against each database   
EXEC sp_MSforeachdb @SQL   

--UPDATE ##Results SET [Free Space %] = [Available Space in Mb]/[Total Size in Mb] * 100   

--Return the Results   
--If @Database_Name is NULL:   
IF @Database_Name IS NULL   
   BEGIN   
       IF @Granularity = 'Database'   
           BEGIN   
               SELECT    
               T.[Database Name],   
               T.[Total Size in Mb] AS [DB Size (Mb)],   
               T.[Available Space in Mb] AS [DB Free (Mb)],   
               T.[Consumed Space in Mb] AS [DB Used (Mb)],   
               D.[Total Size in Mb] AS [Data Size (Mb)],   
               D.[Available Space in Mb] AS [Data Free (Mb)],   
               D.[Consumed Space in Mb] AS [Data Used (Mb)],   
               CEILING(CAST(D.[Available Space in Mb] AS decimal(10,1))/D.[Total Size in Mb]*100) AS [Data Free %],   
               L.[Total Size in Mb] AS [Log Size (Mb)],   
               L.[Available Space in Mb] AS [Log Free (Mb)],   
               L.[Consumed Space in Mb] AS [Log Used (Mb)],   
               CEILING(CAST(L.[Available Space in Mb] AS decimal(10,1))/L.[Total Size in Mb]*100) AS [Log Free %]   
               FROM    
                   (   
                   SELECT [Database Name],   
                       SUM([Total Size in Mb]) AS [Total Size in Mb],   
                       SUM([Available Space in Mb]) AS [Available Space in Mb],   
                       SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
                   FROM ##Results   
                   GROUP BY [Database Name]   
                   ) AS T   
                   INNER JOIN    
                   (   
                   SELECT [Database Name],   
                       SUM([Total Size in Mb]) AS [Total Size in Mb],   
                       SUM([Available Space in Mb]) AS [Available Space in Mb],   
                       SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
                   FROM ##Results   
                   WHERE ##Results.[File Type] = 'Data'   
                   GROUP BY [Database Name]   
                   ) AS D ON T.[Database Name] = D.[Database Name]   
                   INNER JOIN   
                   (   
                   SELECT [Database Name],   
                       SUM([Total Size in Mb]) AS [Total Size in Mb],   
                       SUM([Available Space in Mb]) AS [Available Space in Mb],   
                       SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
                   FROM ##Results   
                   WHERE ##Results.[File Type] = 'Log'   
                   GROUP BY [Database Name]   
                   ) AS L ON T.[Database Name] = L.[Database Name]   
               ORDER BY D.[Database Name]   
           END   
   ELSE   
       BEGIN   
           SELECT [Database Name],   
               [File Name],   
               [Physical Name],   
               [File Type],   
               [Total Size in Mb] AS [DB Size (Mb)],   
               [Available Space in Mb] AS [DB Free (Mb)],   
               CEILING(CAST([Available Space in Mb] AS decimal(10,1)) / [Total Size in Mb]*100) AS [Free Space %],   
               [Growth Units],   
               [Max File Size in Mb] AS [Grow Max Size (Mb)]    
           FROM ##Results    
       END   
   END   

--Return the Results   
--If @Database_Name is provided   
ELSE   
   BEGIN   
       IF @Granularity = 'Database'   
           BEGIN   
               SELECT    
               T.[Database Name],   
               T.[Total Size in Mb] AS [DB Size (Mb)],   
               T.[Available Space in Mb] AS [DB Free (Mb)],   
               T.[Consumed Space in Mb] AS [DB Used (Mb)],   
               D.[Total Size in Mb] AS [Data Size (Mb)],   
               D.[Available Space in Mb] AS [Data Free (Mb)],   
               D.[Consumed Space in Mb] AS [Data Used (Mb)],   
               CEILING(CAST(D.[Available Space in Mb] AS decimal(10,1))/D.[Total Size in Mb]*100) AS [Data Free %],   
               L.[Total Size in Mb] AS [Log Size (Mb)],   
               L.[Available Space in Mb] AS [Log Free (Mb)],   
               L.[Consumed Space in Mb] AS [Log Used (Mb)],   
               CEILING(CAST(L.[Available Space in Mb] AS decimal(10,1))/L.[Total Size in Mb]*100) AS [Log Free %]   
               FROM    
                   (   
                   SELECT [Database Name],   
                       SUM([Total Size in Mb]) AS [Total Size in Mb],   
                       SUM([Available Space in Mb]) AS [Available Space in Mb],   
                       SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
                   FROM ##Results   
                   WHERE [Database Name] = @Database_Name   
                   GROUP BY [Database Name]   
                   ) AS T   
                   INNER JOIN    
                   (   
                   SELECT [Database Name],   
                       SUM([Total Size in Mb]) AS [Total Size in Mb],   
                       SUM([Available Space in Mb]) AS [Available Space in Mb],   
                       SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
                   FROM ##Results   
                   WHERE ##Results.[File Type] = 'Data'   
                       AND [Database Name] = @Database_Name   
                   GROUP BY [Database Name]   
                   ) AS D ON T.[Database Name] = D.[Database Name]   
                   INNER JOIN   
                   (   
                   SELECT [Database Name],   
                       SUM([Total Size in Mb]) AS [Total Size in Mb],   
                       SUM([Available Space in Mb]) AS [Available Space in Mb],   
                       SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
                   FROM ##Results   
                   WHERE ##Results.[File Type] = 'Log'   
                       AND [Database Name] = @Database_Name   
                   GROUP BY [Database Name]   
                   ) AS L ON T.[Database Name] = L.[Database Name]   
               ORDER BY D.[Database Name]   
           END   
       ELSE   
           BEGIN   
               SELECT [Database Name],   
               [File Name],   
               [Physical Name],   
               [File Type],   
               [Total Size in Mb] AS [DB Size (Mb)],   
               [Available Space in Mb] AS [DB Free (Mb)],   
               CEILING(CAST([Available Space in Mb] AS decimal(10,1))/[Total Size in Mb]*100) AS [Free Space %],   
               [Growth Units],   
               [Max File Size in Mb] AS [Grow Max Size (Mb)]    
               FROM ##Results    
               WHERE [Database Name] = @Database_Name   
           END   
   END   
DROP TABLE ##Results   
GO
EXEC sys.sp_addextendedproperty @name=N'11436793-1', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Clientes_m', @level2type=N'COLUMN',@level2name=N'rut_cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'Alejandro Adam', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Clientes_m', @level2type=N'COLUMN',@level2name=N'gls_nombre_cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'12345678', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Clientes_m', @level2type=N'COLUMN',@level2name=N'gls_password'
GO
EXEC sys.sp_addextendedproperty @name=N'975082620', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Clientes_m', @level2type=N'COLUMN',@level2name=N'n_fono'
GO
EXEC sys.sp_addextendedproperty @name=N'11436793-1', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'rut_persona'
GO
EXEC sys.sp_addextendedproperty @name=N'Alejandro Adam', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'gls_nombre_pers'
GO
EXEC sys.sp_addextendedproperty @name=N'12345678', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'gls_password'
GO
EXEC sys.sp_addextendedproperty @name=N'001', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'cod_funcion'
GO
EXEC sys.sp_addextendedproperty @name=N'01', @value=N'Placilla' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'cod_terminal'
GO
EXEC sys.sp_addextendedproperty @name=N'02', @value=N'San Antonio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'cod_terminal'
GO
EXEC sys.sp_addextendedproperty @name=N'03', @value=N'Iquique' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ut_tar_Personas_m', @level2type=N'COLUMN',@level2name=N'cod_terminal'
GO
