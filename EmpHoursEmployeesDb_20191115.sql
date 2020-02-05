USE [master]
GO
/****** Object:  Database [EmpHoursEmployeesDb]    Script Date: 15/11/2019 8:00:25 PM ******/
CREATE DATABASE [EmpHoursEmployeesDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpHoursEmployeesDb', FILENAME = N'C:\Users\myounghwan.jeong.AD\EmpHoursEmployeesDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmpHoursEmployeesDb_log', FILENAME = N'C:\Users\myounghwan.jeong.AD\EmpHoursEmployeesDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmpHoursEmployeesDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET  MULTI_USER 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET QUERY_STORE = OFF
GO
USE [EmpHoursEmployeesDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [EmpHoursEmployeesDb]
GO
/****** Object:  Table [dbo].[EmpHour]    Script Date: 15/11/2019 8:00:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpHour](
	[EmpHoursID] [int] NOT NULL,
	[EmpId] [int] NOT NULL,
	[WorkDate] [date] NOT NULL,
	[Hours] [float] NOT NULL,
 CONSTRAINT [PK_EmpHours] PRIMARY KEY CLUSTERED 
(
	[EmpHoursID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[DOB] [date] NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (1, 1, CAST(N'2019-10-06' AS Date), 8)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (2, 1, CAST(N'2019-10-07' AS Date), 9)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (3, 2, CAST(N'2019-10-07' AS Date), 8)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (4, 4, CAST(N'2019-10-07' AS Date), 7)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (5, 1, CAST(N'2019-10-08' AS Date), 8)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (6, 4, CAST(N'2019-10-08' AS Date), 8)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (7, 4, CAST(N'2019-10-09' AS Date), 5)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (8, 3, CAST(N'2019-10-09' AS Date), 4)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (9, 3, CAST(N'2019-10-01' AS Date), 5)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (10, 5, CAST(N'2019-01-01' AS Date), 3)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (11, 4, CAST(N'2019-01-01' AS Date), 3)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (12, 6, CAST(N'2019-11-01' AS Date), 3)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (13, 5, CAST(N'2019-11-15' AS Date), 3)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (14, 7, CAST(N'2019-11-15' AS Date), 7)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (15, 7, CAST(N'2019-11-01' AS Date), 7)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (16, 7, CAST(N'2019-11-01' AS Date), 7)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (17, 8, CAST(N'2019-01-01' AS Date), 24)
INSERT [dbo].[EmpHour] ([EmpHoursID], [EmpId], [WorkDate], [Hours]) VALUES (18, 7, CAST(N'2019-11-15' AS Date), 7.5)
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (1, N'John', N'Smith', N'John.Smith@yahoo.com', CAST(N'1968-02-04' AS Date), N'666 222-2222')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (2, N'Steven', N'Goldfish', N'goldfish@fishhere.net', CAST(N'1974-04-04' AS Date), N'323 455-4545')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (3, N'Paula', N'Brown', N'pb@herowndomain.org', CAST(N'1978-08-24' AS Date), N'416 323-3232')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (4, N'James', N'Smith', N'jim@supergig.co.uk', CAST(N'1980-10-20' AS Date), N'416 323-8888')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (5, N'Zoe', N'Smith', N'Zoe,Smith@gmail.com', CAST(N'1982-08-12' AS Date), N'555 541-2564')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (6, N'Charlie', N'Jeong', N'cj@cj.com', CAST(N'2019-11-13' AS Date), N'04123456789')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (7, N'77', N'77', N'77@77.77', CAST(N'1977-01-01' AS Date), N'777777')
INSERT [dbo].[Employee] ([EmpId], [FirstName], [LastName], [Email], [DOB], [Phone]) VALUES (8, N'bb', N'bb', N'bb@bb.com', CAST(N'1972-01-01' AS Date), N'33333')
ALTER TABLE [dbo].[EmpHour]  WITH CHECK ADD  CONSTRAINT [FK_EmpHours_Employees] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([EmpId])
GO
ALTER TABLE [dbo].[EmpHour] CHECK CONSTRAINT [FK_EmpHours_Employees]
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpHourEmployee_ListOfEmployees]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmpHourEmployee_ListOfEmployees]
	
AS
BEGIN
	SELECT ep.EmpId, ep.FirstName, ep.LastName, ep.Email, ep.Dob, ep.Phone, SUM(eh.Hours) as TotalHours FROM Employee ep left join EmpHour eh 
	on ep.EmpId = eh.EmpId 	
	GROUP BY ep.EmpId, ep.FirstName, ep.LastName, ep.Email, ep.Dob, ep.Phone
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpHourEmployee_ListOfEmployeeTotalHoursForSelectedDates]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmpHourEmployee_ListOfEmployeeTotalHoursForSelectedDates]
	@beginDate date,
	@endDate date
AS
BEGIN
	SELECT ep.EmpId, ep.FirstName, ep.LastName, ep.Email, ep.Dob, ep.Phone, SUM(eh.Hours) as TotalHours FROM Employee ep left join EmpHour eh 
	on ep.EmpId = eh.EmpId 	
	WHERE eh.WorkDate BETWEEN @beginDate AND @endDate
	GROUP BY ep.EmpId, ep.FirstName, ep.LastName, ep.Email, ep.Dob, ep.Phone
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpHours_DisplayWorkdateHoursByEmpId]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmpHours_DisplayWorkdateHoursByEmpId]

	@empId int

AS
BEGIN
	SELECT WorkDate, Hours FROM EmpHour where EmpId = @empId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpHours_insertEmpHours]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmpHours_insertEmpHours] 
	@empId int,	
	@workDate date,
	@hours float
		
AS
BEGIN

	Declare @empHoursId int
	IF EXISTS (SELECT * FROM EmpHour)
		BEGIN
		SELECT @empHoursId = max(empHoursId) from EmpHour
		SELECT @empHoursId = @empHoursId +1
		END
	ELSE 
		BEGIN
		SELECT @empHoursId = 1;
		END	

	INSERT INTO EmpHour (EmpHoursID, EmpId, WorkDate, Hours) Values(@empHoursId, @empId, @workDate, @hours)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpHoursEmployee_CalculateTotalHours]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmpHoursEmployee_CalculateTotalHours]
	
	@startDate date,
	@endDate date
	
AS
BEGIN
	SELECT ep.EmpId, ep.FirstName, ep.LastName, SUM(eh.Hours) as TotalHours FROM Employee ep left join EmpHour eh 
	on ep.EmpId = eh.EmpId 
	WHERE eh.WorkDate BETWEEN @startDate AND @endDate
	GROUP BY ep.EmpId, ep.FirstName, ep.LastName 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpHoursEmployee_DisplayTotalHours]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmpHoursEmployee_DisplayTotalHours]
	
AS
BEGIN
	SELECT ep.EmpId, ep.FirstName, ep.LastName, SUM(eh.Hours) as TotalHours FROM Employee ep left join EmpHour eh 
	on ep.EmpId = eh.EmpId 	
	GROUP BY ep.EmpId, ep.FirstName, ep.LastName 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_DisplayAllEmployee]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_DisplayAllEmployee]

AS
BEGIN
	SELECT * FROM Employee

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_FindByEmail]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_FindByEmail]

	@email varchar(100)

AS
BEGIN
	SELECT * FROM Employee where Email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_FindByEmpId]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_FindByEmpId]

	@empId int

AS
BEGIN
	SELECT * FROM Employee where EmpId = @empId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employees_DeleteByEmpId]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employees_DeleteByEmpId]

	@empId int

AS
BEGIN
	DELETE FROM Employee where EmpId = @empId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employees_insertNewEmployee]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- a. Insert employee
CREATE PROCEDURE [dbo].[sp_Employees_insertNewEmployee] 
	@firstName varchar(50),
	@lastName varchar(50),
	@email varchar(100),
	@dob date,
	@phone varchar(50)
		
AS
BEGIN

	Declare @empId int
	IF EXISTS (SELECT * FROM Employee)
		BEGIN
		SELECT @empId = max(EmpId) from Employee
		SELECT @empId = @empId +1
		END
	else 
		BEGIN
		SELECT @empId = 1;
		END	

	INSERT INTO Employee(EmpId,FirstName, LastName, Email, DOB, Phone) Values(@empId, @firstName, @lastName, @email, @dob, @phone)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employees_updateEmployee]    Script Date: 15/11/2019 8:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employees_updateEmployee] 
	@empId int,
	@firstName varchar(50),
	@lastName varchar(50),
	@email varchar(100),
	@dob date,
	@phone varchar(50)
		
AS
BEGIN

	UPDATE Employee set 
	FirstName=@firstName,
	LastName = @lastName,
	Email=@email,
	DOB=@dob,
	Phone=@phone
	WHERE EmpId=@empId

END
GO
USE [master]
GO
ALTER DATABASE [EmpHoursEmployeesDb] SET  READ_WRITE 
GO
