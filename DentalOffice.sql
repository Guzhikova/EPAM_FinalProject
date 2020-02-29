USE [master]
GO
/****** Object:  Database [DentalOffice]    Script Date: 01.03.2020 2:09:36 ******/
CREATE DATABASE [DentalOffice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DentalOffice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DentalOffice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DentalOffice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DentalOffice_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DentalOffice] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DentalOffice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DentalOffice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DentalOffice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DentalOffice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DentalOffice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DentalOffice] SET ARITHABORT OFF 
GO
ALTER DATABASE [DentalOffice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DentalOffice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DentalOffice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DentalOffice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DentalOffice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DentalOffice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DentalOffice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DentalOffice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DentalOffice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DentalOffice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DentalOffice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DentalOffice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DentalOffice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DentalOffice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DentalOffice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DentalOffice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DentalOffice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DentalOffice] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DentalOffice] SET  MULTI_USER 
GO
ALTER DATABASE [DentalOffice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DentalOffice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DentalOffice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DentalOffice] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DentalOffice] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DentalOffice] SET QUERY_STORE = OFF
GO
USE [DentalOffice]
GO
/****** Object:  Table [dbo].[employee_file]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_file](
	[employeeID] [int] NOT NULL,
	[fileID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[MiddleName] [nvarchar](200) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[DateOfEmployment] [datetime2](7) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[PostID] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Content] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Author] [int] NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[news_file]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news_file](
	[newsID] [int] NOT NULL,
	[fileID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[page_file]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[page_file](
	[pageID] [int] NOT NULL,
	[fileID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[MiddleName] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[userID] [int] NOT NULL,
	[roleID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.03.2020 2:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[EmployeeID] [int] NULL,
	[PatientID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[employee_file]  WITH CHECK ADD  CONSTRAINT [FK_employee_file_Employees] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employees] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[employee_file] CHECK CONSTRAINT [FK_employee_file_Employees]
GO
ALTER TABLE [dbo].[employee_file]  WITH CHECK ADD  CONSTRAINT [FK_employee_file_Files] FOREIGN KEY([fileID])
REFERENCES [dbo].[Files] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[employee_file] CHECK CONSTRAINT [FK_employee_file_Files]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Posts] FOREIGN KEY([PostID])
REFERENCES [dbo].[Posts] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Posts]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Users] FOREIGN KEY([Author])
REFERENCES [dbo].[Users] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Users]
GO
ALTER TABLE [dbo].[news_file]  WITH CHECK ADD  CONSTRAINT [FK_news_file_Files] FOREIGN KEY([fileID])
REFERENCES [dbo].[Files] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[news_file] CHECK CONSTRAINT [FK_news_file_Files]
GO
ALTER TABLE [dbo].[news_file]  WITH CHECK ADD  CONSTRAINT [FK_news_file_News] FOREIGN KEY([newsID])
REFERENCES [dbo].[News] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[news_file] CHECK CONSTRAINT [FK_news_file_News]
GO
ALTER TABLE [dbo].[page_file]  WITH CHECK ADD  CONSTRAINT [FK_page_file_Files] FOREIGN KEY([fileID])
REFERENCES [dbo].[Files] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[page_file] CHECK CONSTRAINT [FK_page_file_Files]
GO
ALTER TABLE [dbo].[page_file]  WITH CHECK ADD  CONSTRAINT [FK_page_file_Pages] FOREIGN KEY([pageID])
REFERENCES [dbo].[Pages] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[page_file] CHECK CONSTRAINT [FK_page_file_Pages]
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FK_user_role_Roles] FOREIGN KEY([roleID])
REFERENCES [dbo].[Roles] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FK_user_role_Roles]
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FK_user_role_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FK_user_role_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Employees]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Patients1] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patients] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Patients1]
GO
USE [master]
GO
ALTER DATABASE [DentalOffice] SET  READ_WRITE 
GO
