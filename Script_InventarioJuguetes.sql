USE [master]
GO
/****** Object:  Database [Jugueteria]    Script Date: 13/10/2022 08:28:27 a. m. ******/
CREATE DATABASE [Jugueteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jugueteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Jugueteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jugueteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Jugueteria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Jugueteria] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jugueteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jugueteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Jugueteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Jugueteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Jugueteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Jugueteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Jugueteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Jugueteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Jugueteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Jugueteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Jugueteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Jugueteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Jugueteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Jugueteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Jugueteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Jugueteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Jugueteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Jugueteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Jugueteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Jugueteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Jugueteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Jugueteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Jugueteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Jugueteria] SET RECOVERY FULL 
GO
ALTER DATABASE [Jugueteria] SET  MULTI_USER 
GO
ALTER DATABASE [Jugueteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Jugueteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Jugueteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Jugueteria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Jugueteria] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Jugueteria', N'ON'
GO
ALTER DATABASE [Jugueteria] SET QUERY_STORE = OFF
GO
USE [Jugueteria]
GO
/****** Object:  User [UserJuguetes]    Script Date: 13/10/2022 08:28:27 a. m. ******/
CREATE USER [UserJuguetes] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [UserJugueteria]    Script Date: 13/10/2022 08:28:27 a. m. ******/
CREATE USER [UserJugueteria] FOR LOGIN [UserJugueteria] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [UserJuguetes]
GO
ALTER ROLE [db_owner] ADD MEMBER [UserJugueteria]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/10/2022 08:28:27 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[RestriccionEdad] [int] NULL,
	[Compania] [nvarchar](50) NOT NULL,
	[Precio] [decimal](6, 2) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (2, N'Barbie', N'Muñeca', 3, N'Mattel', CAST(130.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (3, N'Carro', N'Carrito de bateria', 6, N'Mattel', CAST(147.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (4, N'Hulk', N'Muñeco', 7, N'Mattel', CAST(201.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (5, N'Poli pocket', N'Muñeca', 4, N'Mattel', CAST(451.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (6, N'Legos', N'Legos', 8, N'Mattel', CAST(453.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (7, N'jenga', N'juego de mesa', 9, N'Mattel', CAST(147.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (8, N'LOL', N'muñecas', 5, N'mattel', CAST(522.36 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (9, N'O.M.G.', N'muñeca', 10, N'matel', CAST(1000.32 AS Decimal(6, 2)))
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio]) VALUES (10, N'Pinipong', N'muñecos', 5, N'matel', CAST(200.00 AS Decimal(6, 2)))
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
USE [master]
GO
ALTER DATABASE [Jugueteria] SET  READ_WRITE 
GO
