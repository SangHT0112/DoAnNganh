Create database DoAnFinal
go
USE [DoAnFinal]
GO

/* hhahahahha */

	 
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/18/2024 12:17:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 10/18/2024 12:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/18/2024 12:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/18/2024 12:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241017124015_second', N'8.0.10')
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (1, N'Adidas', N'Thời thượng, trẻ trung', N'adidas', 1)
INSERT [dbo].[Brands] ([Id], [Name], [Description], [Slug], [Status]) VALUES (2, N'Nike', N'Phong cách, năng động', N'nike', 1)
	 INSERT [dbo].[Brands] ( [Name], [Description], [Slug], [Status]) VALUES (N'Columbia', N'Columbia là một thương hiệu nổi tiếng của Mỹ, chuyên sản xuất quần áo và thiết bị ngoài trời.', N'columbia', 1)
INSERT [dbo].[Brands] ([Name], [Description], [Slug], [Status]) VALUES (N'Fila', N'Fila là thương hiệu thể thao toàn cầu, nổi tiếng với giày dép và trang phục năng động, kết hợp phong cách thể thao và thời trang đường phố.', N'fila', 1)
INSERT [dbo].[Brands] ([Name], [Description], [Slug], [Status]) VALUES (N'Puma', N'Puma là thương hiệu thể thao hàng đầu của Đức, nổi bật với giày dép và trang phục thể thao hiện đại, kết hợp hiệu suất và phong cách thời trang', N'puma', 1)
INSERT [dbo].[Brands] ([Name], [Description], [Slug], [Status]) VALUES (N'Cros', N'Crocs là thương hiệu giày dép nổi tiếng của Mỹ, đặc trưng với thiết kế dép clog bằng chất liệu nhẹ, thoáng khí và thoải mái, phù hợp cho nhiều hoạt động hàng ngày.', N'cros', 1)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (1, N'Quần áo thể thao', N'Thời trang, phong cách', N'quần áo thể thao', 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Slug], [Status]) VALUES (2, N'Găng tay', N'Chất liệu cao, thoải mái', N'găng tay', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (1, N'Áo bóng đá PS01', N'áo bóng đá', N'Chất vải bền', CAST(160000.00 AS Decimal(18, 2)), 1, 1, N'aobongda1.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Price], [BrandId], [CategoryId], [Image]) VALUES (2, N'Găng tay thủ môn SP01', N'găng tay thủ môn', N'Bắt dính', CAST(100000.00 AS Decimal(18, 2)), 2, 2, N'gangtaythumon1.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
