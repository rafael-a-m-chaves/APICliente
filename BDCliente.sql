USE [BDCliente]
GO
/****** Object:  User [root]    Script Date: 16/03/2022 09:20:02 ******/
CREATE USER [root] FOR LOGIN [root] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Despesas]    Script Date: 16/03/2022 09:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Despesas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Motivo] [varchar](max) NOT NULL,
	[DataDespesa] [datetime] NOT NULL,
 CONSTRAINT [PK_Despezas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/03/2022 09:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendasCliente]    Script Date: 16/03/2022 09:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendasCliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCliente] [int] NOT NULL,
	[DataVenda] [datetime] NOT NULL,
	[ValorDaVenda] [decimal](18, 2) NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_VendasCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Despesas] ON 

INSERT [dbo].[Despesas] ([Id], [Valor], [Motivo], [DataDespesa]) VALUES (1, CAST(10.00 AS Decimal(18, 2)), N'cafe', CAST(N'2022-03-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Despesas] ([Id], [Valor], [Motivo], [DataDespesa]) VALUES (2, CAST(100.00 AS Decimal(18, 2)), N'internete', CAST(N'2022-03-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Despesas] ([Id], [Valor], [Motivo], [DataDespesa]) VALUES (3, CAST(1000.00 AS Decimal(18, 2)), N'aluguel', CAST(N'2022-03-16T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Despesas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Tipo], [Nome], [IsActive]) VALUES (1, N'Administrador', N'Rafael', 1)
INSERT [dbo].[Usuario] ([Id], [Tipo], [Nome], [IsActive]) VALUES (2, N'Financeiro', N'Lucas', 1)
INSERT [dbo].[Usuario] ([Id], [Tipo], [Nome], [IsActive]) VALUES (3, N'Vendedor', N'Fabricio', 1)
INSERT [dbo].[Usuario] ([Id], [Tipo], [Nome], [IsActive]) VALUES (4, N'Vendedor', N'Laura', 1)
INSERT [dbo].[Usuario] ([Id], [Tipo], [Nome], [IsActive]) VALUES (5, N'Vendedor', N'Fernanda', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[VendasCliente] ON 

INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (1, 1, CAST(N'2022-03-12T23:55:00.000' AS DateTime), CAST(100.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (2, 2, CAST(N'2022-03-12T23:55:00.000' AS DateTime), CAST(50.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (3, 3, CAST(N'2022-03-12T23:55:00.000' AS DateTime), CAST(12.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (4, 4, CAST(N'2022-03-12T23:55:00.000' AS DateTime), CAST(89.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (5, 4, CAST(N'2022-03-12T23:55:00.000' AS DateTime), CAST(100.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (6, 1, CAST(N'2022-03-16T08:56:11.803' AS DateTime), CAST(50.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (10, 10, CAST(N'2022-03-16T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (11, 8, CAST(N'2022-03-16T00:00:00.000' AS DateTime), CAST(100.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (12, 11, CAST(N'2022-03-16T00:00:00.000' AS DateTime), CAST(5.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[VendasCliente] ([Id], [CodigoCliente], [DataVenda], [ValorDaVenda], [IdUsuario]) VALUES (14, 7, CAST(N'2022-03-16T00:00:00.000' AS DateTime), CAST(15.00 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[VendasCliente] OFF
GO

