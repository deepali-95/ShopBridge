CREATE DATABASE [ShopBridge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopBridge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ShopBridge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopBridge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ShopBridge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ShopBridge] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopBridge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopBridge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopBridge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopBridge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopBridge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopBridge] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopBridge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopBridge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopBridge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopBridge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopBridge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopBridge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopBridge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopBridge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopBridge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopBridge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopBridge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopBridge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopBridge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopBridge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopBridge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopBridge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopBridge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopBridge] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopBridge] SET  MULTI_USER 
GO
ALTER DATABASE [ShopBridge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopBridge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopBridge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopBridge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopBridge] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopBridge', N'ON'
GO
ALTER DATABASE [ShopBridge] SET QUERY_STORE = OFF
GO
USE [ShopBridge]
GO
/****** Object:  Schema [Product]    Script Date: 2021-08-08 1:45:21 AM ******/
CREATE SCHEMA [Product]
GO
/****** Object:  Table [Product].[ProductBrand]    Script Date: 2021-08-08 1:45:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Product].[ProductBrand](
	[ProductBrandId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [varchar](100) NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedBy] [varchar](127) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [varchar](127) NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductBrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Product].[ProductCategory]    Script Date: 2021-08-08 1:45:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Product].[ProductCategory](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [varchar](100) NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedBy] [varchar](127) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [varchar](127) NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Product].[ProductMaster]    Script Date: 2021-08-08 1:45:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Product].[ProductMaster](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[ProductBrandId] [int] NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [varchar](100) NULL,
	[Color] [varchar](100) NOT NULL,
	[Currency] [varchar](10) NOT NULL,
	[Price] [money] NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedBy] [varchar](127) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [varchar](127) NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Product].[ProductBrand] ON 
GO
INSERT [Product].[ProductBrand] ([ProductBrandId], [Identifier], [Name], [Description], [Status], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (2, N'21d68ba7-1a05-491b-8c50-e33cb4019ccc', N'TestBrand1', N'This is test brand 1', 1, N'TestUser', CAST(N'2021-08-07T17:55:00.323' AS DateTime), N'TestUser', CAST(N'2021-08-07T17:55:00.323' AS DateTime))
GO
SET IDENTITY_INSERT [Product].[ProductBrand] OFF
GO
SET IDENTITY_INSERT [Product].[ProductCategory] ON 
GO
INSERT [Product].[ProductCategory] ([ProductCategoryId], [Identifier], [Name], [Description], [Status], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, N'5fd8140d-3099-49b2-89d7-20ad7bccc226', N'TestCategory1', N'This is test category 1', 1, N'TestUser', CAST(N'2021-08-07T17:55:32.483' AS DateTime), N'TestUser', CAST(N'2021-08-07T17:55:32.483' AS DateTime))
GO
SET IDENTITY_INSERT [Product].[ProductCategory] OFF
GO
ALTER TABLE [Product].[ProductBrand] ADD  DEFAULT (newid()) FOR [Identifier]
GO
ALTER TABLE [Product].[ProductBrand] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [Product].[ProductBrand] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [Product].[ProductBrand] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [Product].[ProductCategory] ADD  DEFAULT (newid()) FOR [Identifier]
GO
ALTER TABLE [Product].[ProductCategory] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [Product].[ProductCategory] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [Product].[ProductCategory] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [Product].[ProductMaster] ADD  DEFAULT (newid()) FOR [Identifier]
GO
ALTER TABLE [Product].[ProductMaster] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [Product].[ProductMaster] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [Product].[ProductMaster] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [Product].[ProductMaster]  WITH CHECK ADD FOREIGN KEY([ProductCategoryId])
REFERENCES [Product].[ProductCategory] ([ProductCategoryId])
GO
ALTER TABLE [Product].[ProductMaster]  WITH CHECK ADD FOREIGN KEY([ProductBrandId])
REFERENCES [Product].[ProductBrand] ([ProductBrandId])
GO
USE [master]
GO
ALTER DATABASE [ShopBridge] SET  READ_WRITE 
GO
