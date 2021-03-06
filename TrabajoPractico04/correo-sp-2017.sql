USE [master]
GO
/****** Object:  Database [correo-sp-2017]    Script Date: 23/06/2019 07:37:19 p.m. ******/
CREATE DATABASE [correo-sp-2017]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'correo-sp-2017', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\correo-sp-2017.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'correo-sp-2017_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\correo-sp-2017_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [correo-sp-2017] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [correo-sp-2017].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [correo-sp-2017] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [correo-sp-2017] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [correo-sp-2017] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [correo-sp-2017] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [correo-sp-2017] SET ARITHABORT OFF 
GO
ALTER DATABASE [correo-sp-2017] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [correo-sp-2017] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [correo-sp-2017] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [correo-sp-2017] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [correo-sp-2017] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [correo-sp-2017] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [correo-sp-2017] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [correo-sp-2017] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [correo-sp-2017] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [correo-sp-2017] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [correo-sp-2017] SET  DISABLE_BROKER 
GO
ALTER DATABASE [correo-sp-2017] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [correo-sp-2017] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [correo-sp-2017] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [correo-sp-2017] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [correo-sp-2017] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [correo-sp-2017] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [correo-sp-2017] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [correo-sp-2017] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [correo-sp-2017] SET  MULTI_USER 
GO
ALTER DATABASE [correo-sp-2017] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [correo-sp-2017] SET DB_CHAINING OFF 
GO
ALTER DATABASE [correo-sp-2017] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [correo-sp-2017] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [correo-sp-2017]
GO
/****** Object:  Table [dbo].[Paquetes]    Script Date: 23/06/2019 07:37:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paquetes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[direccionEntrega] [varchar](500) NOT NULL,
	[trackingID] [varchar](50) NOT NULL,
	[alumno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Paquetes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Paquetes] ON 

INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (4, N'Mitre 780', N'123-456-7891', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (5, N'De La Serna 453', N'012-345-6789', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (6, N'Palaa 250', N'987-654-3210', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (7, N'Alsina 35', N'101-010-1010', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (8, N'Sarmiento 70', N'111-111-1111', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (9, N'French 10', N'123-789-4560', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (10, N'San Martin 125', N'789-465-1230', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (11, N'San Martin 250', N'123-789-4568', N'Navarro Nicolas')
INSERT [dbo].[Paquetes] ([id], [direccionEntrega], [trackingID], [alumno]) VALUES (12, N'Suarez 1420', N'123-457-8945', N'Navarro Nicolas')
SET IDENTITY_INSERT [dbo].[Paquetes] OFF
USE [master]
GO
ALTER DATABASE [correo-sp-2017] SET  READ_WRITE 
GO
