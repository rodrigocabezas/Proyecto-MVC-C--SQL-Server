USE [master]
GO
/****** Object:  Database [ObligatorioMvc_2]    Script Date: 24/07/2017 16:51:57 ******/
CREATE DATABASE [ObligatorioMvc_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ObligatorioMvc_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SANTY\MSSQL\DATA\ObligatorioMvc_2.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ObligatorioMvc_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SANTY\MSSQL\DATA\ObligatorioMvc_2.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ObligatorioMvc_2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ObligatorioMvc_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ObligatorioMvc_2] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET ANSI_NULLS ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET ANSI_PADDING ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET ARITHABORT ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [ObligatorioMvc_2] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [ObligatorioMvc_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ObligatorioMvc_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ObligatorioMvc_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET RECOVERY FULL 
GO
ALTER DATABASE [ObligatorioMvc_2] SET  MULTI_USER 
GO
ALTER DATABASE [ObligatorioMvc_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ObligatorioMvc_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ObligatorioMvc_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ObligatorioMvc_2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ObligatorioMvc_2', N'ON'
GO
USE [ObligatorioMvc_2]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 24/07/2017 16:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Emprendimientoes]    Script Date: 24/07/2017 16:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Emprendimientoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Costo] [int] NOT NULL,
	[Dias] [int] NOT NULL,
	[PuntajeFinal] [int] NOT NULL,
	[Financiado] [int] NOT NULL,
	[IdFinanciador] [int] NULL,
 CONSTRAINT [PK_dbo.Emprendimientoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Financiadors]    Script Date: 24/07/2017 16:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Financiadors](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[NombreOrganizacion] [varchar](50) NOT NULL,
	[MontoMaximo] [decimal](18, 2) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Financiadors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdFinanciador]    Script Date: 24/07/2017 16:51:57 ******/
CREATE NONCLUSTERED INDEX [IX_IdFinanciador] ON [dbo].[Emprendimientoes]
(
	[IdFinanciador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Financiadors] ADD  CONSTRAINT [DF__Financiad__Nombr__15502E78]  DEFAULT ('') FOR [NombreUsuario]
GO
ALTER TABLE [dbo].[Emprendimientoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Emprendimientoes_dbo.Financiadors_IdFinanciador] FOREIGN KEY([IdFinanciador])
REFERENCES [dbo].[Financiadors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Emprendimientoes] CHECK CONSTRAINT [FK_dbo.Emprendimientoes_dbo.Financiadors_IdFinanciador]
GO
USE [master]
GO
ALTER DATABASE [ObligatorioMvc_2] SET  READ_WRITE 
GO
