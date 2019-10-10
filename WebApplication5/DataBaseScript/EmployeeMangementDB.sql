USE [master]
GO
/****** Object:  Database [EmpolyeeMangmentSystem]    Script Date: 10/11/2019 1:23:12 AM ******/
CREATE DATABASE [EmpolyeeMangmentSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpolyeeMangmentSystem', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLSERVER2012\MSSQL\DATA\EmpolyeeMangmentSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmpolyeeMangmentSystem_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLSERVER2012\MSSQL\DATA\EmpolyeeMangmentSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmpolyeeMangmentSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET  MULTI_USER 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EmpolyeeMangmentSystem]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[City] [varchar](20) NULL,
	[Address] [varchar](20) NULL,
	[Gender] [tinyint] NULL,
	[Bdate] [datetime] NULL,
	[freeze] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[City] [varchar](20) NULL,
	[Department] [varchar](20) NULL,
	[Gender] [varchar](6) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployee]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery15.sql|7|0|C:\Users\Abhijeet\AppData\Local\Temp\~vs1B61.sql
CREATE procedure [dbo].[spDeleteEmployee]       
(        
   @EmpId int        
)        
as         
begin        
   Delete from Employee where EmployeeId=@EmpId        
End
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[spGetAllEmployees]    
as    
Begin    
    select *    
    from tblEmployee    
End  
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployee]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spUpdateEmployee]        
(        
   @EmpId INTEGER ,      
   @Name VARCHAR(20),       
   @City VARCHAR(20),      
   @Department VARCHAR(20),      
   @Gender VARCHAR(6)      
)        
as        
begin        
   Update tblEmployee         
   set Name=@Name,        
   City=@City,        
   Department=@Department,      
   Gender=@Gender        
   where EmployeeId=@EmpId        
End
GO
/****** Object:  StoredProcedure [dbo].[usp_AddEmployee]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[usp_AddEmployee](
 @Name as varchar(50) ='',
 @city as varchar(50) ='',
 @Address as varchar(50)='',
 @Gender int =0,
 @Bdate as smalldatetime='',
 @intOpmode as int=0,
 @id as int=0
)
as
Begin
if @intOpmode=1
Begin
insert into Employee (Name,City,Address,Gender,Bdate,freeze)values(@Name,@city,@Address,@Gender,@Bdate,0)
End
else if @intOpmode=2
Begin
update Employee set Name=@Name,City=@City,Address=@Address,Gender=@Gender,Bdate=@Bdate where EmployeeId=@id and freeze=0

End

else if @intOpmode=3
Begin
update Employee set freeze=1 where EmployeeId=@id
--abhijeet25121991    AbhijeetGajananJadhav@25
End
End
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectEmployee]    Script Date: 10/11/2019 1:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE  [dbo].[usp_SelectEmployee](
	@Empid as bigint=0,
	 @intOpmode as int=0)
AS
if @intOpmode=1
Begin
	SELECT * from Employee where employeeid=@Empid and freeze=0

End

if @intOpmode=2
Begin
	SELECT * from Employee where  freeze=0

End
GO
USE [master]
GO
ALTER DATABASE [EmpolyeeMangmentSystem] SET  READ_WRITE 
GO
