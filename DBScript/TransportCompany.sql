USE [master]
GO
/****** Object:  Database [TransportCompany]    Script Date: 06.06.2021 20:18:48 ******/
CREATE DATABASE [TransportCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TransportCompany', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERDEMO\MSSQL\DATA\TransportCompany.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TransportCompany_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERDEMO\MSSQL\DATA\TransportCompany_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TransportCompany] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransportCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TransportCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TransportCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TransportCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TransportCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TransportCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [TransportCompany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TransportCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TransportCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TransportCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TransportCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TransportCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TransportCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TransportCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TransportCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TransportCompany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TransportCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TransportCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TransportCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TransportCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TransportCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TransportCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TransportCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TransportCompany] SET RECOVERY FULL 
GO
ALTER DATABASE [TransportCompany] SET  MULTI_USER 
GO
ALTER DATABASE [TransportCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TransportCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TransportCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TransportCompany] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TransportCompany] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TransportCompany] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TransportCompany', N'ON'
GO
ALTER DATABASE [TransportCompany] SET QUERY_STORE = OFF
GO
USE [TransportCompany]
GO
/****** Object:  Table [dbo].[AuthHistory]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuthHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarBrand] [nvarchar](50) NOT NULL,
	[CarModel] [nvarchar](50) NOT NULL,
	[LicensePlate] [nvarchar](9) NOT NULL,
	[VIN] [nvarchar](17) NOT NULL,
	[CarPassport] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Phone] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Passport] [nvarchar](10) NOT NULL,
	[DriverLicense] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[DriverId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfRole] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Destination] [nvarchar](50) NOT NULL,
	[Distance] [int] NOT NULL,
	[DeliveryTime] [int] NOT NULL,
	[PriceOfDelivery] [money] NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06.06.2021 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[LastEnter] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthHistory]  WITH CHECK ADD  CONSTRAINT [FK_AuthHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AuthHistory] CHECK CONSTRAINT [FK_AuthHistory_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Car]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Driver] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Driver]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderStatus]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Route]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [TransportCompany] SET  READ_WRITE 
GO
