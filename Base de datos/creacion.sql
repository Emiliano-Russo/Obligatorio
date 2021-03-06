USE [master]
GO
/****** Object:  Database [prueba]    Script Date: 20/11/2020 17:36:38 ******/
CREATE DATABASE [prueba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prueba', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\prueba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prueba_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\prueba_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [prueba] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prueba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prueba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prueba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prueba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prueba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prueba] SET ARITHABORT OFF 
GO
ALTER DATABASE [prueba] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [prueba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prueba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prueba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prueba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prueba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prueba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prueba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prueba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prueba] SET  ENABLE_BROKER 
GO
ALTER DATABASE [prueba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prueba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prueba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prueba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prueba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prueba] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [prueba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prueba] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [prueba] SET  MULTI_USER 
GO
ALTER DATABASE [prueba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prueba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prueba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prueba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prueba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prueba] SET QUERY_STORE = OFF
GO
USE [prueba]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20/11/2020 17:36:38 ******/
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
/****** Object:  Table [dbo].[Admin]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[email] [nvarchar](450) NOT NULL,
	[contrasenia] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alojamiento]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alojamiento](
	[Nombre] [nvarchar](450) NOT NULL,
	[Estrellas] [real] NOT NULL,
	[PuntoTuristicoNombre] [nvarchar](450) NULL,
	[Direccion] [nvarchar](max) NULL,
	[PrecioNoche] [real] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[SinCapacidad] [bit] NOT NULL,
	[NroTelefono] [nvarchar](max) NULL,
	[InfoDeContacto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Alojamiento] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estadia]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estadia](
	[Key] [int] IDENTITY(1,1) NOT NULL,
	[Entrada] [datetime2](7) NOT NULL,
	[Salida] [datetime2](7) NOT NULL,
	[RangoEdadInterno_no_usar] [nvarchar](max) NULL,
 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoReserva]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoReserva](
	[Key] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[EstadiaKey] [int] NULL,
	[HotelNombre] [nvarchar](450) NULL,
 CONSTRAINT [PK_InfoReserva] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntosTuristicos]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntosTuristicos](
	[Nombre] [nvarchar](450) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Region] [int] NOT NULL,
	[CategoriasInterno_no_usar] [nvarchar](max) NULL,
	[ImgNameInterno_no_usar] [nvarchar](max) NULL,
 CONSTRAINT [PK_PuntosTuristicos] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puntuacion]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puntuacion](
	[Key] [int] IDENTITY(1,1) NOT NULL,
	[Puntos] [int] NOT NULL,
	[Comentario] [nvarchar](max) NULL,
	[ReservaCodigo] [nvarchar](450) NULL,
 CONSTRAINT [PK_Puntuacion] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 20/11/2020 17:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Codigo] [nvarchar](450) NOT NULL,
	[InfoReservaKey] [int] NULL,
	[EstadoReserva] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Alojamiento_PuntoTuristicoNombre]    Script Date: 20/11/2020 17:36:38 ******/
CREATE NONCLUSTERED INDEX [IX_Alojamiento_PuntoTuristicoNombre] ON [dbo].[Alojamiento]
(
	[PuntoTuristicoNombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InfoReserva_EstadiaKey]    Script Date: 20/11/2020 17:36:38 ******/
CREATE NONCLUSTERED INDEX [IX_InfoReserva_EstadiaKey] ON [dbo].[InfoReserva]
(
	[EstadiaKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_InfoReserva_HotelNombre]    Script Date: 20/11/2020 17:36:38 ******/
CREATE NONCLUSTERED INDEX [IX_InfoReserva_HotelNombre] ON [dbo].[InfoReserva]
(
	[HotelNombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Puntuacion_ReservaCodigo]    Script Date: 20/11/2020 17:36:38 ******/
CREATE NONCLUSTERED INDEX [IX_Puntuacion_ReservaCodigo] ON [dbo].[Puntuacion]
(
	[ReservaCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reserva_InfoReservaKey]    Script Date: 20/11/2020 17:36:38 ******/
CREATE NONCLUSTERED INDEX [IX_Reserva_InfoReservaKey] ON [dbo].[Reserva]
(
	[InfoReservaKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alojamiento]  WITH CHECK ADD  CONSTRAINT [FK_Alojamiento_PuntosTuristicos_PuntoTuristicoNombre] FOREIGN KEY([PuntoTuristicoNombre])
REFERENCES [dbo].[PuntosTuristicos] ([Nombre])
GO
ALTER TABLE [dbo].[Alojamiento] CHECK CONSTRAINT [FK_Alojamiento_PuntosTuristicos_PuntoTuristicoNombre]
GO
ALTER TABLE [dbo].[InfoReserva]  WITH CHECK ADD  CONSTRAINT [FK_InfoReserva_Alojamiento_HotelNombre] FOREIGN KEY([HotelNombre])
REFERENCES [dbo].[Alojamiento] ([Nombre])
GO
ALTER TABLE [dbo].[InfoReserva] CHECK CONSTRAINT [FK_InfoReserva_Alojamiento_HotelNombre]
GO
ALTER TABLE [dbo].[InfoReserva]  WITH CHECK ADD  CONSTRAINT [FK_InfoReserva_Estadia_EstadiaKey] FOREIGN KEY([EstadiaKey])
REFERENCES [dbo].[Estadia] ([Key])
GO
ALTER TABLE [dbo].[InfoReserva] CHECK CONSTRAINT [FK_InfoReserva_Estadia_EstadiaKey]
GO
ALTER TABLE [dbo].[Puntuacion]  WITH CHECK ADD  CONSTRAINT [FK_Puntuacion_Reserva_ReservaCodigo] FOREIGN KEY([ReservaCodigo])
REFERENCES [dbo].[Reserva] ([Codigo])
GO
ALTER TABLE [dbo].[Puntuacion] CHECK CONSTRAINT [FK_Puntuacion_Reserva_ReservaCodigo]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_InfoReserva_InfoReservaKey] FOREIGN KEY([InfoReservaKey])
REFERENCES [dbo].[InfoReserva] ([Key])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_InfoReserva_InfoReservaKey]
GO
USE [master]
GO
ALTER DATABASE [prueba] SET  READ_WRITE 
GO
