USE [master]
GO
/****** Object:  Database [Peerfx]    Script Date: 04/28/2013 18:18:09 ******/
CREATE DATABASE [Peerfx] ON  PRIMARY 
( NAME = N'Peerfx', FILENAME = N'D:\Websites\DatabaseFiles\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Peerfx.mdf' , SIZE = 53248KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Peerfx_log', FILENAME = N'D:\Websites\DatabaseFiles\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Peerfx_log.ldf' , SIZE = 7616KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Peerfx] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Peerfx].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Peerfx] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Peerfx] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Peerfx] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Peerfx] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Peerfx] SET ARITHABORT OFF
GO
ALTER DATABASE [Peerfx] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Peerfx] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Peerfx] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Peerfx] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Peerfx] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Peerfx] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Peerfx] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Peerfx] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Peerfx] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Peerfx] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Peerfx] SET  DISABLE_BROKER
GO
ALTER DATABASE [Peerfx] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Peerfx] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Peerfx] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Peerfx] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Peerfx] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Peerfx] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Peerfx] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Peerfx] SET  READ_WRITE
GO
ALTER DATABASE [Peerfx] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Peerfx] SET  MULTI_USER
GO
ALTER DATABASE [Peerfx] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Peerfx] SET DB_CHAINING OFF
GO
USE [Peerfx]
GO
/****** Object:  Role [aspnet_WebEvent_FullAccess]    Script Date: 04/28/2013 18:18:09 ******/
CREATE ROLE [aspnet_WebEvent_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_WebEvent_FullAccess]    Script Date: 04/28/2013 18:18:09 ******/
CREATE SCHEMA [aspnet_WebEvent_FullAccess] AUTHORIZATION [aspnet_WebEvent_FullAccess]
GO
/****** Object:  Table [dbo].[Scheduled_Task_Types]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduled_Task_Types](
	[scheduled_task_type_key] [int] NOT NULL,
	[scheduled_task_type_description] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scheduled_Task]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduled_Task](
	[scheduled_task_key] [int] IDENTITY(1,1) NOT NULL,
	[scheduled_task_type] [int] NOT NULL,
	[date_changed] [datetime] NOT NULL,
 CONSTRAINT [PK_Updates] PRIMARY KEY CLUSTERED 
(
	[scheduled_task_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipients]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipients](
	[recipients_key] [int] IDENTITY(1,1) NOT NULL,
	[user_key] [int] NOT NULL,
	[payment_object_key] [bigint] NOT NULL,
 CONSTRAINT [PK_Recipients] PRIMARY KEY CLUSTERED 
(
	[recipients_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotes]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotes](
	[quotes_key] [int] IDENTITY(1,1) NOT NULL,
	[sell_amount] [money] NULL,
	[sell_currency] [int] NULL,
	[buy_amount] [money] NULL,
	[buy_currency] [int] NULL,
	[rate] [decimal](10, 4) NULL,
	[service_fee] [money] NULL,
	[promised_delivery_date] [datetime] NULL,
	[actual_delivery_date] [datetime] NULL,
	[date_created] [datetime] NOT NULL,
	[timing] [int] NULL,
 CONSTRAINT [PK_Quotes] PRIMARY KEY CLUSTERED 
(
	[quotes_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purpose_Types]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purpose_Types](
	[purpose_types_key] [int] NOT NULL,
	[purpose_description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Purpose_Types] PRIMARY KEY CLUSTERED 
(
	[purpose_types_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[payments_key] [int] IDENTITY(1,1) NOT NULL,
	[quote_key] [int] NOT NULL,
	[quote_key_actual] [int] NULL,
	[payment_status] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[requestor_user_key] [int] NULL,
	[payment_object_sender] [bigint] NULL,
	[payment_object_receiver] [bigint] NULL,
	[payment_description] [nvarchar](100) NULL,
	[treasury_type] [int] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[payments_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Timing_Types]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Timing_Types](
	[payment_timing_type] [int] NOT NULL,
	[payment_timing_description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment_Timing_Types] PRIMARY KEY CLUSTERED 
(
	[payment_timing_type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Status]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Status](
	[payment_status_key] [int] NOT NULL,
	[payment_status_description] [nvarchar](50) NOT NULL,
	[payment_status_admindescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Payment_Status] PRIMARY KEY CLUSTERED 
(
	[payment_status_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Schedule]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Schedule](
	[payment_schedule_key] [int] IDENTITY(1,1) NOT NULL,
	[currency_sender] [int] NOT NULL,
	[currency_receiver] [int] NOT NULL,
	[time_to_delivery] [datetime] NOT NULL,
 CONSTRAINT [PK_Payment_Schedule] PRIMARY KEY CLUSTERED 
(
	[payment_schedule_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Objects]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Objects](
	[payment_object_key] [bigint] IDENTITY(1,1) NOT NULL,
	[payment_object_type] [int] NOT NULL,
	[object_account_key] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
 CONSTRAINT [PK_Payment_Objects] PRIMARY KEY CLUSTERED 
(
	[payment_object_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Object_Types]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Object_Types](
	[payment_object_type_key] [int] NOT NULL,
	[payment_object_type_description] [nvarchar](50) NULL,
	[payment_object_type_isexternal] [bit] NULL,
	[payment_object_type_requiresmanualexport] [bit] NULL,
 CONSTRAINT [PK_Payment_Object_Types] PRIMARY KEY CLUSTERED 
(
	[payment_object_type_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Internal / 1 = Externals' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Payment_Object_Types', @level2type=N'COLUMN',@level2name=N'payment_object_type_isexternal'
GO
/****** Object:  Table [dbo].[Info_Verification_Methods]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Verification_Methods](
	[info_verification_methods_key] [int] NOT NULL,
	[verification_name] [nvarchar](50) NOT NULL,
	[verification_description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Info_Verification_Methods] PRIMARY KEY CLUSTERED 
(
	[info_verification_methods_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Timezones]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Info_Timezones](
	[info_timezone_key] [int] IDENTITY(1,1) NOT NULL,
	[info_timezone_name] [varchar](200) NULL,
	[info_timezone_id] [varchar](50) NULL,
 CONSTRAINT [PK_Info_Timezones] PRIMARY KEY CLUSTERED 
(
	[info_timezone_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Info_Security_Questions]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Security_Questions](
	[info_security_questions_key] [int] NOT NULL,
	[question] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Info_Security_Questions] PRIMARY KEY CLUSTERED 
(
	[info_security_questions_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Phone_Type]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Phone_Type](
	[info_phone_type_key] [int] NOT NULL,
	[Phone_Type_Text] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Info_Phone_Type] PRIMARY KEY CLUSTERED 
(
	[info_phone_type_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Organizations]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Organizations](
	[info_organizations_key] [int] IDENTITY(1,1) NOT NULL,
	[organization_name] [nvarchar](50) NOT NULL,
	[user_key_updated] [int] NULL,
	[last_changed] [datetime] NULL,
	[organization_description] [nvarchar](50) NULL,
	[organization_type] [int] NULL,
 CONSTRAINT [PK_Info_Banks] PRIMARY KEY CLUSTERED 
(
	[info_organizations_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Organization_Type]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Organization_Type](
	[info_organization_type_key] [int] NOT NULL,
	[info_organization_type_description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Info_Organization_Type] PRIMARY KEY CLUSTERED 
(
	[info_organization_type_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Fee_Types]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Fee_Types](
	[info_fee_types] [int] IDENTITY(1,1) NOT NULL,
	[organization_name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](100) NULL,
	[fee_base] [money] NULL,
	[fee_percentage] [money] NULL,
	[fee_addon] [money] NULL,
	[fee_min] [money] NULL,
	[fee_max] [money] NULL,
	[currency1] [int] NULL,
	[currency2] [int] NULL,
	[Exchange_Rate] [decimal](10, 4) NULL,
	[Exchange_Rate_Updated] [datetime] NULL,
	[Treasury_Type] [int] NULL,
	[standard_timing] [int] NULL,
	[premium_timing] [int] NULL,
	[premium_fee_percentage] [money] NULL,
	[premium_fee_addon] [money] NULL,
	[premium_fee_min] [money] NULL,
	[premium_fee_max] [money] NULL,
 CONSTRAINT [PK_Info_Fee_Types] PRIMARY KEY CLUSTERED 
(
	[info_fee_types] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_CurrencyCloud_Tokens]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Info_CurrencyCloud_Tokens](
	[Info_CurrencyCloud_Tokens_Key] [int] NOT NULL,
	[Info_CurrencyCloud_Token] [varchar](50) NULL,
	[lastchanged] [datetime] NULL,
 CONSTRAINT [PK_Info_CurrencyCloud_Tokens] PRIMARY KEY CLUSTERED 
(
	[Info_CurrencyCloud_Tokens_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Info_Currencies]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Currencies](
	[info_currencies_key] [int] NOT NULL,
	[info_currency_code] [nchar](3) NOT NULL,
	[info_currency_name] [nvarchar](50) NOT NULL,
	[info_currency_country] [nvarchar](50) NOT NULL,
	[info_currency_cansell] [bit] NULL,
	[info_currency_canbuy] [bit] NULL,
	[info_currency_symbol] [nchar](3) NULL,
	[info_currency_description] [nvarchar](50) NULL,
	[info_currency_countrykey] [int] NULL,
	[allow_local_bankaccount] [bit] NULL,
	[verify_bank_account] [bit] NULL,
	[info_currency_canhold] [bit] NULL,
	[currencycloud_cutoff] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Country_List]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Info_Country_List](
	[info_country_key] [int] NOT NULL,
	[country_value] [nchar](2) NOT NULL,
	[country_text] [nchar](50) NOT NULL,
	[country_code] [varchar](3) NULL,
	[phone_code] [nchar](10) NULL,
 CONSTRAINT [PK_Info_Country_List] PRIMARY KEY CLUSTERED 
(
	[info_country_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Info_Country_Code_List]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Country_Code_List](
	[info_country_key] [int] IDENTITY(1,1) NOT NULL,
	[Country_Code] [nchar](50) NULL,
	[Country_Text] [nchar](50) NULL,
	[Country_Time_Zone] [nchar](10) NULL,
 CONSTRAINT [PK_Info_Country_Code_List] PRIMARY KEY CLUSTERED 
(
	[info_country_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 04/28/2013 18:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RestorePermissions]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RestorePermissions]
    @name   sysname
AS
BEGIN
    DECLARE @object sysname
    DECLARE @protectType char(10)
    DECLARE @action varchar(60)
    DECLARE @grantee sysname
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT Object, ProtectType, [Action], Grantee FROM #aspnet_Permissions where Object = @name

    OPEN c1

    FETCH c1 INTO @object, @protectType, @action, @grantee
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = @protectType + ' ' + @action + ' on ' + @object + ' TO [' + @grantee + ']'
        EXEC (@cmd)
        FETCH c1 INTO @object, @protectType, @action, @grantee
    END

    CLOSE c1
    DEALLOCATE c1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RemoveAllRoleMembers]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RemoveAllRoleMembers]
    @name   sysname
AS
BEGIN
    CREATE TABLE #aspnet_RoleMembers
    (
        Group_name      sysname,
        Group_id        smallint,
        Users_in_group  sysname,
        User_id         smallint
    )

    INSERT INTO #aspnet_RoleMembers
    EXEC sp_helpuser @name

    DECLARE @user_id smallint
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT User_id FROM #aspnet_RoleMembers

    OPEN c1

    FETCH c1 INTO @user_id
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = 'EXEC sp_droprolemember ' + '''' + @name + ''', ''' + USER_NAME(@user_id) + ''''
        EXEC (@cmd)
        FETCH c1 INTO @user_id
    END

    CLOSE c1
    DEALLOCATE c1
END
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[API_Errors_Types]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[API_Errors_Types](
	[api_errors_type] [int] NOT NULL,
	[api_errors_type_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_API_Errors_Types] PRIMARY KEY CLUSTERED 
(
	[api_errors_type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[API_Errors]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[API_Errors](
	[API_Errors_Key] [bigint] IDENTITY(1,1) NOT NULL,
	[api_type] [int] NOT NULL,
	[request] [text] NULL,
	[response] [text] NULL,
	[url] [text] NULL,
	[dateoccured] [datetime] NULL,
 CONSTRAINT [PK_API_Errors] PRIMARY KEY CLUSTERED 
(
	[API_Errors_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin_Bank_Accounts]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_Bank_Accounts](
	[admin_bank_account_key] [int] IDENTITY(1,1) NOT NULL,
	[payment_object_key] [bigint] NOT NULL,
	[receiving_currency] [int] NULL,
	[receiving_country] [int] NULL,
 CONSTRAINT [PK_Admin_Bank_Accounts] PRIMARY KEY CLUSTERED 
(
	[admin_bank_account_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 04/28/2013 18:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LoweredApplicationName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ApplicationName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [aspnet_Applications_Index] ON [dbo].[aspnet_Applications] 
(
	[LoweredApplicationName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyCloud_Trades_Errors]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyCloud_Trades_Errors](
	[payments_key] [int] NOT NULL,
	[request] [text] NOT NULL,
	[response] [varchar](200) NOT NULL,
	[dateoccured] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CurrencyCloud_Trades]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyCloud_Trades](
	[currencycloud_trade_key] [bigint] IDENTITY(1,1) NOT NULL,
	[payments_key] [int] NOT NULL,
	[settlement_key] [bigint] NULL,
	[initiated_date] [datetime] NOT NULL,
	[cc_tradeid] [varchar](50) NULL,
	[settlement_date] [datetime] NULL,
	[fundsreceived_date] [datetime] NULL,
	[withdrawlsent_date] [datetime] NULL,
	[cc_paymentid] [varchar](50) NULL,
 CONSTRAINT [PK_CurrencyCloud_Trades] PRIMARY KEY CLUSTERED 
(
	[currencycloud_trade_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CurrencyCloud_Settlements]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyCloud_Settlements](
	[currencycloud_settlement_key] [bigint] IDENTITY(1,1) NOT NULL,
	[cc_settlementid] [varchar](50) NULL,
	[releasedate] [datetime] NULL,
	[initiated_date] [datetime] NULL,
	[fundsreceived_date] [datetime] NULL,
	[withdrawlsent_date] [datetime] NULL,
 CONSTRAINT [PK_CurrencyCloud_Settlements] PRIMARY KEY CLUSTERED 
(
	[currencycloud_settlement_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank_Accounts]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank_Accounts](
	[bank_account_key] [int] IDENTITY(1,1) NOT NULL,
	[user_key] [int] NULL,
	[currency_key] [int] NOT NULL,
	[country_key] [int] NULL,
	[organization_key] [int] NULL,
	[bank_account_description] [nvarchar](100) NULL,
	[user_key_updated] [int] NOT NULL,
	[ip_address] [varchar](20) NOT NULL,
	[account_number] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[BIC] [varchar](50) NULL,
	[ABArouting] [varchar](50) NULL,
	[first_name] [nvarchar](100) NULL,
	[last_name] [nvarchar](100) NULL,
	[business_name] [nvarchar](100) NULL,
	[last_changed] [datetime] NOT NULL,
	[date_created] [datetime] NULL,
	[SortCode] [varchar](50) NULL,
	[BSB] [varchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[bank_name] [nvarchar](100) NULL,
	[branch_code] [varchar](50) NULL,
	[institution_number] [varchar](4) NULL,
 CONSTRAINT [PK_Users_Bank_Accounts] PRIMARY KEY CLUSTERED 
(
	[bank_account_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank_Account_Local_Required_Fields]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_Account_Local_Required_Fields](
	[bank_account_required_field_type] [int] NOT NULL,
	[currency_key] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank_Account_Field_Type]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank_Account_Field_Type](
	[bank_account_field_type] [int] NOT NULL,
	[bank_account_field_name] [nvarchar](50) NULL,
	[currencycloud_field] [varchar](50) NULL,
 CONSTRAINT [PK_Bank_Account_Field_Type] PRIMARY KEY CLUSTERED 
(
	[bank_account_field_type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Error_Log]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Error_Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmbeeCatalog]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmbeeCatalog](
	[country] [int] NULL,
	[carrier] [nvarchar](100) NULL,
	[product_id] [int] NULL,
	[product_name] [nvarchar](100) NULL,
	[price_in_dollars] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Embee_Objects]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Embee_Objects](
	[embee_object_key] [int] IDENTITY(1,1) NOT NULL,
	[country] [int] NULL,
	[carrier] [nvarchar](100) NULL,
	[product_id] [int] NULL,
	[product_name] [nvarchar](100) NULL,
	[price_in_dollars] [money] NULL,
	[transstatus] [int] NULL,
	[transid] [int] NULL,
	[date_created] [datetime] NULL,
	[phonenumber] [varchar](20) NULL,
	[message] [nvarchar](100) NULL,
	[date_processed] [datetime] NULL,
 CONSTRAINT [PK_Embee_Objects] PRIMARY KEY CLUSTERED 
(
	[embee_object_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Treasury_Type]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treasury_Type](
	[treasury_type_key] [int] NOT NULL,
	[treasury_name] [nvarchar](50) NOT NULL,
	[user_key] [int] NULL,
 CONSTRAINT [PK_Treasury_Type] PRIMARY KEY CLUSTERED 
(
	[treasury_type_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions_Internal]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions_Internal](
	[tx_internal_key] [bigint] IDENTITY(1,1) NOT NULL,
	[tx_internal_status] [int] NOT NULL,
	[purpose_type] [int] NULL,
	[purpose_object_key] [int] NULL,
	[currency] [int] NOT NULL,
	[amount] [money] NOT NULL,
	[payment_object_sender] [bigint] NULL,
	[payment_object_receiver] [bigint] NULL,
	[tx_internal_description] [nvarchar](100) NULL,
	[last_changed] [datetime] NOT NULL,
	[ip_address] [nchar](16) NULL,
	[user_key_updated] [int] NULL,
	[date_created] [datetime] NULL,
	[date_processed] [datetime] NULL,
 CONSTRAINT [PK_Transactions_Internal] PRIMARY KEY CLUSTERED 
(
	[tx_internal_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions_External]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transactions_External](
	[tx_external_key] [bigint] IDENTITY(1,1) NOT NULL,
	[tx_external_status] [int] NOT NULL,
	[purpose_type] [int] NULL,
	[purpose_object_key] [int] NULL,
	[currency] [int] NOT NULL,
	[amount] [money] NOT NULL,
	[payment_object_sender] [bigint] NULL,
	[payment_object_receiver] [bigint] NULL,
	[tx_external_description] [nvarchar](100) NULL,
	[last_changed] [datetime] NOT NULL,
	[ip_address] [nchar](16) NOT NULL,
	[user_key_updated] [int] NULL,
	[bank_reference] [varchar](100) NULL,
	[date_created] [datetime] NULL,
	[date_processed] [datetime] NULL,
 CONSTRAINT [PK_Transactions_External] PRIMARY KEY CLUSTERED 
(
	[tx_external_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transaction_Status]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction_Status](
	[transaction_status_key] [int] NOT NULL,
	[status_description] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Transaction_Status] PRIMARY KEY CLUSTERED 
(
	[transaction_status_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction_Fees]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction_Fees](
	[tx_fees_key] [int] IDENTITY(1,1) NOT NULL,
	[tx_type] [int] NOT NULL,
	[tx_key] [bigint] NOT NULL,
	[amount] [money] NOT NULL,
	[currency] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[description] [nvarchar](100) NULL,
	[fee_type] [int] NULL,
 CONSTRAINT [PK_Transaction_Fees] PRIMARY KEY CLUSTERED 
(
	[tx_fees_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Transactions_External / 1 = Transactions_Internal' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction_Fees', @level2type=N'COLUMN',@level2name=N'tx_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'tx_key of either Transactions_External or Transactions_Internal table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction_Fees', @level2type=N'COLUMN',@level2name=N'tx_key'
GO
/****** Object:  Table [dbo].[Verification_Methods]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Verification_Methods](
	[verification_method_key] [int] NOT NULL,
	[verification_method_name] [varchar](50) NOT NULL,
	[points] [int] NOT NULL,
	[ismandatory] [bit] NULL,
	[requiresmanualapproval] [bit] NULL,
 CONSTRAINT [PK_Verification_Methods] PRIMARY KEY CLUSTERED 
(
	[verification_method_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users_Verified]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Verified](
	[users_verified_key] [int] IDENTITY(1,1) NOT NULL,
	[user_key] [int] NOT NULL,
	[verification_methods_key] [int] NOT NULL,
	[isverified] [bit] NOT NULL,
	[last_changed] [datetime] NOT NULL,
	[ip_address] [nchar](16) NOT NULL,
	[unique_key] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users_Verified_Key] PRIMARY KEY CLUSTERED 
(
	[users_verified_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Security_Answers]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Security_Answers](
	[users_security_answers_key] [int] IDENTITY(1,1) NOT NULL,
	[user_key] [int] NOT NULL,
	[question] [int] NOT NULL,
	[answer] [nvarchar](50) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[last_changed] [datetime] NOT NULL,
 CONSTRAINT [PK_Users_Security_Questions] PRIMARY KEY CLUSTERED 
(
	[users_security_answers_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Info]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users_Info](
	[user_key] [int] NOT NULL,
	[address1] [nvarchar](100) NULL,
	[address2] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[state] [nvarchar](100) NULL,
	[country] [int] NULL,
	[postalcode] [nvarchar](20) NULL,
	[phonecountrycode1] [int] NULL,
	[phonetype1] [int] NULL,
	[phonenumber1] [nvarchar](20) NULL,
	[phonecountrycode2] [int] NULL,
	[phonetype2] [int] NULL,
	[phonenumber2] [nvarchar](20) NULL,
	[identitynationality] [int] NULL,
	[occupation] [nvarchar](50) NULL,
	[passportnumber] [nchar](44) NULL,
	[last_changed] [datetime] NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[ssn] [char](9) NULL,
	[Image_URL] [nvarchar](200) NULL,
	[default_currency] [int] NULL,
	[timezone] [int] NULL,
	[referral] [text] NULL,
 CONSTRAINT [PK_Users_Info] PRIMARY KEY CLUSTERED 
(
	[user_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users_Bancbox]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users_Bancbox](
	[user_key] [int] NOT NULL,
	[client_id] [int] NULL,
	[client_status] [varchar](50) NULL,
	[cip_status] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[user_key] [int] IDENTITY(1,1) NOT NULL,
	[account_number] [varchar](10) NULL,
	[title] [nchar](10) NULL,
	[first_name] [nvarchar](100) NULL,
	[middle_name] [nvarchar](100) NULL,
	[last_name] [nvarchar](100) NULL,
	[dob] [date] NULL,
	[country_residence] [int] NULL,
	[email] [nvarchar](100) NULL,
	[ip_address] [nchar](20) NULL,
	[last_changed] [datetime] NOT NULL,
	[signed_up] [datetime] NOT NULL,
	[user_status] [int] NULL,
	[user_type] [int] NULL,
	[last_online] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Types]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Types](
	[user_types_key] [int] NOT NULL,
	[user_type_description] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Statuses]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Statuses](
	[user_status_key] [int] NULL,
	[status_description] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Recipients]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Recipients](
	[user_recipients_key] [int] NOT NULL,
	[user_key] [int] NULL,
	[payment_object_key] [bigint] NULL,
 CONSTRAINT [PK_User_Recipients] PRIMARY KEY CLUSTERED 
(
	[user_recipients_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Facebook]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Facebook](
	[fb_uid] [bigint] NULL,
	[user_key] [int] NOT NULL,
	[fb_location] [nvarchar](100) NULL,
	[fb_email] [nvarchar](100) NULL,
	[fb_friends_count] [int] NULL,
	[fb_access_token] [text] NULL,
	[date_created] [datetime] NULL,
	[last_changed] [datetime] NULL,
	[fb_ismale] [bit] NULL,
	[fb_first_name] [nvarchar](50) NULL,
	[fb_last_name] [nvarchar](50) NULL,
	[fb_isverified] [bit] NULL,
 CONSTRAINT [PK_User_Facebook] PRIMARY KEY CLUSTERED 
(
	[user_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Update_Payments_Actual_Quote]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Payments_Actual_Quote]
	
	@payments_key int,		
	@quote_key int
	
AS
BEGIN
			
		UPDATE Payments
			SET
				quote_key_actual = @quote_key			
			WHERE payments_key = @payments_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Payments]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Payments]
	@payments_key int,
	@quote_key int,
	@payment_status int,	
	@payments_key_return int Output,
	@requestor_user_key int,
	@payment_description nvarchar(100),
	@payment_object_sender bigint,
	@payment_object_receiver bigint

AS
BEGIN

DECLARE @Check_payments_key int

if @payments_key > 0
	BEGIN
	SET @Check_payments_key = (SELECT payments_key FROM Payments WHERE payments_key = @payments_key)
	END

If @Check_payments_key is null --Create new record
	BEGIN
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Payments
	(quote_key, payment_status,date_created,requestor_user_key,payment_description,payment_object_sender,payment_object_receiver)
	VALUES
	(@quote_key,1,getdate(),@requestor_user_key,@payment_description,@payment_object_sender,@payment_object_receiver)

	--SET @payments_key_return = (SELECT payments_key FROM Payments WHERE date_created = @CurrentDate)
	SET @payments_key_return = SCOPE_IDENTITY()

	--Create payment object for payment
	INSERT INTO Payment_Objects
	(payment_object_type,object_account_key,date_created)
	VALUES
	(6,@payments_key_return,getdate())

	END
ELSE
	BEGIN
		UPDATE Payments
			SET
				quote_key = @quote_key,
				payment_status = @payment_status,
				requestor_user_key = @requestor_user_key,
				payment_description = @payment_description,
				payment_object_sender = @payment_object_sender,
				payment_object_receiver = @payment_object_receiver
			WHERE payments_key = @payments_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Payment_Treasury]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Payment_Treasury]
	@payments_key int,
	@treasurytype int

AS
BEGIN

		UPDATE Payments
			SET	
				treasury_type = @treasurytype
			WHERE payments_key = @payments_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Payment_Status]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Payment_Status]
	@payments_key int,
	@payment_status int

AS
BEGIN

		UPDATE Payments
			SET	
				payment_status = @payment_status
			WHERE payments_key = @payments_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Payment_Objects]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Payment_Objects]
	@payment_object_key bigint,
	@payment_object_type int,
	@object_account_key int,
	@payment_object_key_return int Output

AS
BEGIN

DECLARE @Check_payment_object_key bigint

if @payment_object_key > 0
	BEGIN
	SET @Check_payment_object_key = (SELECT payment_object_key FROM Payment_Objects WHERE payment_object_key = @payment_object_key)
	END

If @Check_payment_object_key is null --Create new record
	BEGIN
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Payment_Objects
	(payment_object_type,object_account_key,date_created)
	VALUES
	(@payment_object_type,@object_account_key,@CurrentDate)

	SET @payment_object_key_return = SCOPE_IDENTITY()--(SELECT payment_object_key FROM Payment_Objects WHERE date_created = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Payment_Objects
			SET
				payment_object_type = @payment_object_type,
				object_account_key = @object_account_key
			WHERE payment_object_key = @payment_object_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_InfoTimezones]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_InfoTimezones]
	@timezoneid varchar(50),
	@timezonename varchar(200)

AS
BEGIN


	INSERT INTO Info_Timezones
	(info_timezone_id,info_timezone_name)
	VALUES
	(@timezoneid, @timezonename)	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Info_Fee_Types_ExchangeRate]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Info_Fee_Types_ExchangeRate]
	@currency1 int,
	@currency2 int,
	@rate decimal(10,4)
AS
BEGIN
	
	UPDATE Info_Fee_Types
	SET 
		exchange_rate = @rate,
		exchange_rate_updated = getdate()
	WHERE 
	currency1 = @currency1
	AND currency2 = @currency2
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Info_CurrencyCloud_Tokens]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Info_CurrencyCloud_Tokens]

	@cctokenkey int,		
	@cctoken varchar(50)
	
AS
BEGIN

		UPDATE Info_CurrencyCloud_Tokens
			SET				
				Info_CurrencyCloud_Token = @cctoken,
				lastchanged = getdate()
			WHERE Info_CurrencyCloud_Tokens_Key = 1

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Facebook_User_Info]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Facebook_User_Info]
	@userkey int,	
	@uid bigint,
	@location nvarchar(100),
	@email nvarchar(100),
	@friendscount int,
	@ismale bit,
	@firstname nvarchar(100),
	@lastname nvarchar(100),
	@isverified bit

AS
BEGIN


	UPDATE User_Facebook
	SET
		fb_uid = @uid,
		fb_location = @location,
		fb_email = @email,
		fb_friends_count = @friendscount,		
		fb_ismale = @ismale,
		fb_first_name = @firstname,
		fb_last_name = @lastname,
		fb_isverified = @isverified
	WHERE user_key = @userkey

	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Facebook_Access_Token]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Facebook_Access_Token]
	@userkey int,
	@accesstoken text

AS
BEGIN

DECLARE @Check_fb int
SET @Check_fb = (SELECT user_key FROM User_Facebook WHERE user_key = @userkey)
	

If @Check_fb is null --Create new record
	BEGIN

	INSERT INTO User_Facebook
	(user_key, fb_access_token, date_created, last_changed)
	VALUES
	(@userkey, @accesstoken, getdate(), getdate())	

	END

ELSE
	BEGIN

	UPDATE User_Facebook
	SET
		fb_access_token = @accesstoken
	WHERE user_key = @userkey

	END	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_EmbeeObjects_IPN]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_EmbeeObjects_IPN]
	@transid int,
	@message nvarchar(100),
	@transstatus int

AS
BEGIN

UPDATE Embee_Objects
SET
message = @message,
transstatus = @transstatus,
date_processed = getdate()
WHERE transid = @transid
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_EmbeeCatalog_recordpaymentobject]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_EmbeeCatalog_recordpaymentobject]	
	@product_id int,
	@phone varchar(20),
	@embee_payment_object_return bigint Output
AS
BEGIN

	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Embee_Objects
	(country, carrier, product_id, product_name, price_in_dollars, date_created, phonenumber)
	VALUES
	((SELECT country FROM EmbeeCatalog WHERE product_id = @product_id),
	(SELECT carrier FROM EmbeeCatalog WHERE product_id = @product_id),
	@product_id,
	(SELECT product_name FROM EmbeeCatalog WHERE product_id = @product_id),
	(SELECT price_in_dollars FROM EmbeeCatalog WHERE product_id = @product_id),
	@CurrentDate,
	@phone)
	
	DECLARE @embee_object_key int
	SET @embee_object_key = SCOPE_IDENTITY()--(SELECT embee_object_key FROM Embee_Objects WHERE date_created = @CurrentDate)

	SET @CurrentDate = getdate()
	INSERT INTO Payment_Objects
	(payment_object_type,object_account_key,date_created)
	VALUES
	(7,@embee_object_key,@CurrentDate)

	SET @embee_payment_object_return = (SELECT payment_object_key FROM Payment_Objects WHERE date_created = @CurrentDate)
	

END
GO
/****** Object:  StoredProcedure [dbo].[Update_EmbeeCatalog]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_EmbeeCatalog]
	@country int,
	@company_name nvarchar(100),
	@product_id int,
	@product_name nvarchar(100),
	@price_in_dollars money

AS
BEGIN


	INSERT INTO EmbeeCatalog
	(country,carrier,product_id,product_name,price_in_dollars)
	VALUES
	(@country,@company_name,@product_id,@product_name,@price_in_dollars)	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Embee_Newtransid]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Embee_Newtransid]
	@transid int,
	@embee_object_key int
AS
BEGIN


	UPDATE Embee_Objects
			SET
			transid = @transid
			WHERE @embee_object_key = embee_object_key
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Trades_withdrawlsent]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Trades_withdrawlsent]
	
	@currencycloud_trade_key bigint

AS
BEGIN

UPDATE CurrencyCloud_Trades
SET
	withdrawlsent_date = getdate()
WHERE currencycloud_trade_key = @currencycloud_trade_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Trades_fundsreceived]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Trades_fundsreceived]
	
	@currencycloud_trade_key bigint

AS
BEGIN

UPDATE CurrencyCloud_Trades
SET
	fundsreceived_date = getdate()
WHERE currencycloud_trade_key = @currencycloud_trade_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Trades_Errors]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_CurrencyCloud_Trades_Errors]
	
	@payments_key int,
	@request text,
	@response varchar(200)	

AS
BEGIN

DECLARE @Check_payments_key int
if @payments_key > 0
	BEGIN
	SET @Check_payments_key = (SELECT payments_key FROM CurrencyCloud_Trades_Errors WHERE payments_key = @payments_key)
	END

If @Check_payments_key is null --Create new record
	BEGIN
	INSERT INTO CurrencyCloud_Trades_Errors
	(payments_key, request, response, dateoccured)
	VALUES
	(@payments_key, @request, @response, getdate())
	END
ELSE
	BEGIN
	UPDATE CurrencyCloud_Trades_Errors
	SET
		request = @request,
		response = @response,
		dateoccured = getdate()
	WHERE payments_key = @payments_key
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Trades_AddedtoSettlement]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Trades_AddedtoSettlement]
	@settlementkey bigint,
	@currencycloud_trade_key bigint

AS
BEGIN

UPDATE CurrencyCloud_Trades
SET
	settlement_key = @settlementkey,
	settlement_date = getdate()
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Trades]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_CurrencyCloud_Trades]
	@paymentkey int,
	@cc_tradeid varchar(50),
	@ccpaymentid varchar(50)

AS
BEGIN

INSERT INTO CurrencyCloud_Trades
(payments_key, cc_tradeid, initiated_date,cc_paymentid)
VALUES
(@paymentkey, @cc_tradeid, getdate(), @ccpaymentid)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Settlements_withdrawlsent]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Settlements_withdrawlsent]
	
	@currencycloud_settlement_key bigint

AS
BEGIN

UPDATE CurrencyCloud_Settlements
SET
	withdrawlsent_date = getdate()
WHERE currencycloud_settlement_key = @currencycloud_settlement_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Settlements_Released]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Settlements_Released]
	
	@currencycloud_settlement_key bigint

AS
BEGIN

UPDATE CurrencyCloud_Settlements
SET
	releasedate = getdate()
WHERE currencycloud_settlement_key = @currencycloud_settlement_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Settlements_fundsreceived]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Settlements_fundsreceived]
	
	@currencycloud_settlement_key bigint

AS
BEGIN

UPDATE CurrencyCloud_Settlements
SET
	fundsreceived_date = getdate()
WHERE currencycloud_settlement_key = @currencycloud_settlement_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_CurrencyCloud_Settlements]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_CurrencyCloud_Settlements]
	
	@cc_settlementid varchar(50)

AS
BEGIN

INSERT INTO CurrencyCloud_Settlements
(cc_settlementid, initiated_date)
VALUES
(@cc_settlementid, getdate())
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_RequiredFields]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Bank_Accounts_RequiredFields]
	@currency int
AS
BEGIN

SELECT *
FROM Bank_Account_Local_Required_Fields
INNER JOIN Bank_Account_Field_Type
ON Bank_Account_Local_Required_Fields.bank_account_required_field_type = Bank_Account_Field_Type.bank_account_field_type
WHERE currency_key = @currency

END
GO
/****** Object:  StoredProcedure [dbo].[View_Admin_Bank_Account_CurrencyExchange]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Admin_Bank_Account_CurrencyExchange]
	@currency int,
	@country int
AS
BEGIN

	SELECT *
	FROM Payment_Objects
	INNER JOIN Admin_Bank_Accounts
	ON Admin_Bank_Accounts.payment_object_key = Payment_Objects.payment_object_key
	WHERE 
	(payment_object_type = 2 --Admin bank account
	OR payment_object_type = 8) --BancBox account
	AND receiving_currency = @currency
	AND ((receiving_country = @country) OR (receiving_country = 0))
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Scheduled_Task]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Scheduled_Task]
	@scheduled_task_type int

AS
BEGIN


	SELECT *
	FROM Scheduled_Task
	WHERE scheduled_task_type = @scheduled_task_type
	ORDER BY date_changed DESC
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Object_Bank_Account]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payment_Object_Bank_Account]
	@Bank_Account_key int
AS
BEGIN
	
	SELECT *
	FROM Payment_Objects
	WHERE ((payment_object_type = 1) OR (payment_object_type = 2))
	AND object_account_key = @Bank_Account_Key
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Timezones]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Timezones]
	
AS
BEGIN
	SELECT *
	FROM Info_Timezones
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Security_Questions]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Security_Questions]
	
AS
BEGIN
	SELECT *
	FROM Info_Security_Questions
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Phone_Type]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Phone_Type]
	
AS
BEGIN
	SELECT *
	FROM Info_Phone_Type
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Organizations_byname]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Organizations_byname]
	@name nvarchar(50)
AS
BEGIN
	SELECT *
	FROM Info_Organizations
	WHERE @name = organization_name
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Organizations]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Organizations]
	
AS
BEGIN
	SELECT *
	FROM Info_Organizations
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Fee_Types_All]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Fee_Types_All]
	
AS
BEGIN
	
	SELECT *
	FROM Info_Fee_Types
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Fee_Types]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Info_Fee_Types]
	@currency1 int,
	@currency2 int
AS
BEGIN
	
	SELECT *
	FROM Info_Fee_Types
	WHERE @currency1 = currency1
	AND @currency2 = currency2
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_CurrencyCloud_Tokens]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_CurrencyCloud_Tokens]	

AS
BEGIN
	
	SELECT *
	FROM Info_CurrencyCloud_Tokens
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currency_Symbol]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Currency_Symbol]
	@currencycode nchar(3)
AS
BEGIN
	
	SELECT info_currency_symbol
	FROM Info_Currencies
	WHERE info_currency_code = @currencycode
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Errors_Lastone]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Errors_Lastone]
	
AS
BEGIN
	SELECT top 1 *
	FROM aspnet_webevent_events
	WHERE Details LIKE '%Exception message%'
	ORDER BY EventTime Desc
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Embee_Objects_Currently_Processing]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Embee_Objects_Currently_Processing]
	
AS
BEGIN
	
	SELECT *
	FROM Embee_Objects
	WHERE (transstatus = 1
	OR transstatus is null)
	AND transid is not null
END
GO
/****** Object:  StoredProcedure [dbo].[View_Embee_Objects_bypaymentkey]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Embee_Objects_bypaymentkey]
	@paymentkey int
AS
BEGIN
	
	DECLARE @receiverpaymentobject bigint 
	SET @receiverpaymentobject = (SELECT payment_object_receiver FROM Payments WHERE payments_key = @paymentkey)
	DECLARE @embee_object_key int 
	SET @embee_object_key = (SELECT object_account_key FROM Payment_Objects WHERE payment_object_key = @receiverpaymentobject)

	
	SELECT *				
	FROM Embee_Objects
	WHERE @embee_object_key = embee_object_key
END
GO
/****** Object:  StoredProcedure [dbo].[View_Embee_Countries]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Embee_Countries]
	
AS
BEGIN
	
	SELECT 
		DISTINCT country,
		country_text = (SELECT country_text FROM Info_Country_List WHERE info_country_key = country)
	FROM EmbeeCatalog
	ORDER BY country_text ASC
END
GO
/****** Object:  StoredProcedure [dbo].[View_Embee_Catalog_byproductid]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Embee_Catalog_byproductid]
	@productid int
AS
BEGIN
	
	SELECT *				
	FROM EmbeeCatalog
	WHERE product_id = @productid
END
GO
/****** Object:  StoredProcedure [dbo].[View_Embee_Catalog_bycountry]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Embee_Catalog_bycountry]
	@country int
AS
BEGIN
	
	SELECT *				
	FROM EmbeeCatalog
	WHERE country = @country
	ORDER BY product_name ASC
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_Specific_cctradeid]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_CurrencyCloud_Trades_Specific_cctradeid]
	@cctradeid varchar(50)
AS
BEGIN
	SELECT *
	FROM CurrencyCloud_Trades
	WHERE cc_tradeid = @cctradeid
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Country_Specific]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Country_Specific]
	@country_key int
AS
BEGIN
	SELECT *
	FROM Info_Country_List
	WHERE @country_key = info_country_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Country_List]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Info_Country_List]
	
AS
BEGIN
	SELECT *,
	CountryCodeText = RTRIM(Country_Code) + '(' + Country_Text + ')'
	FROM Info_Country_Code_List
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Country_Code_List]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Country_Code_List]
	
AS
BEGIN
	SELECT *
	FROM Info_Country_Code_List
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Countries]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Countries]
	
AS
BEGIN
	SELECT *
	FROM Info_Country_List
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanSell]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Currencies_CanSell]
	
AS
BEGIN
		
	SELECT *
	FROM Info_Currencies
	WHERE info_currency_cansell = 1
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanHold]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Currencies_CanHold]
	
AS
BEGIN
		
	SELECT *
	FROM Info_Currencies
	WHERE info_currency_canhold = 1
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanBuy]    Script Date: 04/28/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Currencies_CanBuy]
	
AS
BEGIN
		
	SELECT *
	FROM Info_Currencies
	WHERE info_currency_canbuy = 1
END
GO
/****** Object:  View [dbo].[vw_CurrencyCloud_Settlements]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_CurrencyCloud_Settlements]
AS
SELECT        initiated_date, releasedate, cc_settlementid, currencycloud_settlement_key,
                             (SELECT        COUNT(*) AS Expr1
                               FROM            dbo.CurrencyCloud_Trades
                               WHERE        (settlement_key = dbo.CurrencyCloud_Settlements.currencycloud_settlement_key)) AS number_of_trades, CASE WHEN (initiated_date IS NOT NULL 
                         AND releasedate IS NOT NULL AND withdrawlsent_date IS NULL AND fundsreceived_date IS NULL) THEN 2 WHEN (initiated_date IS NOT NULL AND 
                         releasedate IS NOT NULL AND withdrawlsent_date IS NOT NULL AND fundsreceived_date IS NULL) THEN 3 WHEN (initiated_date IS NOT NULL AND 
                         releasedate IS NOT NULL AND withdrawlsent_date IS NOT NULL AND fundsreceived_date IS NOT NULL) THEN 4 ELSE 1 END AS status, fundsreceived_date, 
                         withdrawlsent_date
FROM            dbo.CurrencyCloud_Settlements
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CurrencyCloud_Settlements"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 170
               Right = 287
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CurrencyCloud_Settlements'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CurrencyCloud_Settlements'
GO
/****** Object:  View [dbo].[vw_currency_pairings]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_currency_pairings]
AS
SELECT        info_fee_types, description, fee_base, fee_percentage, fee_addon, fee_min, fee_max, currency1, currency2, Exchange_Rate_Updated, Exchange_Rate, 
                         Treasury_Type,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies
                               WHERE        (info_currencies_key = dbo.Info_Fee_Types.currency1)) AS currency1_code,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies AS Info_Currencies_1
                               WHERE        (info_currencies_key = dbo.Info_Fee_Types.currency2)) AS currency2_code
FROM            dbo.Info_Fee_Types
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Info_Fee_Types"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 299
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_currency_pairings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_currency_pairings'
GO
/****** Object:  View [dbo].[vw_currencies]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_currencies]
AS
SELECT        dbo.Info_Country_List.country_value, dbo.Info_Country_List.info_country_key, dbo.Info_Country_List.country_text, dbo.Info_Country_List.phone_code, 
                         dbo.Info_Country_List.country_code, dbo.Info_Currencies.info_currencies_key, dbo.Info_Currencies.info_currency_code, dbo.Info_Currencies.info_currency_name, 
                         dbo.Info_Currencies.info_currency_country, dbo.Info_Currencies.info_currency_cansell, dbo.Info_Currencies.info_currency_canbuy, 
                         dbo.Info_Currencies.info_currency_symbol, dbo.Info_Currencies.info_currency_description, dbo.Info_Currencies.allow_local_bankaccount, 
                         dbo.Info_Currencies.info_currency_countrykey, dbo.Info_Currencies.verify_bank_account, dbo.Info_Currencies.info_currency_canhold, 
                         dbo.Info_Currencies.currencycloud_cutoff
FROM            dbo.Info_Country_List INNER JOIN
                         dbo.Info_Currencies ON dbo.Info_Country_List.info_country_key = dbo.Info_Currencies.info_currency_countrykey
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Info_Country_List"
            Begin Extent = 
               Top = 15
               Left = 310
               Bottom = 189
               Right = 489
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Info_Currencies"
            Begin Extent = 
               Top = 10
               Left = 16
               Bottom = 315
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2235
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_currencies'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_currencies'
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Timing_Types_Specific]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payment_Timing_Types_Specific]
	@typeid int
AS
BEGIN
	
	SELECT *
	FROM Payment_Timing_Types
	WHERE @typeid = payment_timing_type
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Timing_Types]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payment_Timing_Types]
	
AS
BEGIN
	
	SELECT *
	FROM Payment_Timing_Types
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Status]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payment_Status]
	
AS
BEGIN
	
	SELECT *
	FROM Payment_Status
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Transaction_Fees_txkey]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Transaction_Fees_txkey]
	@tx_type int,
	@tx_key int
AS
	SELECT *
	FROM Transaction_Fees
	INNER JOIN Info_Currencies 
	ON Transaction_Fees.currency = Info_Currencies.info_currencies_key
	WHERE tx_type = @tx_type	
	AND tx_key = @tx_key
GO
/****** Object:  StoredProcedure [dbo].[View_Transaction_Fees]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Transaction_Fees]
	@tx_type int
AS
	SELECT *

	FROM Transaction_Fees
	INNER JOIN Info_Currencies 
	ON Transaction_Fees.currency = Info_Currencies.info_currencies_key
	WHERE tx_type = @tx_type
GO
/****** Object:  StoredProcedure [dbo].[View_User_Facebook]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_User_Facebook]
	@userkey int
AS
BEGIN
	
	SELECT *
	FROM User_Facebook
	WHERE user_key = @userkey
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Schedule]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payment_Schedule]
	
AS
BEGIN
	
	SELECT *,
	currency_code_sender = (SELECT info_currency_code FROM Info_Currencies WHERE currency_sender = info_currencies_key),
	currency_code_receiver = (SELECT info_currency_code FROM Info_Currencies WHERE currency_receiver = info_currencies_key)
	FROM Payment_Schedule
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Object_type_objectkey]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payment_Object_type_objectkey]
	@type_key int,
	@object_key int
AS
BEGIN
	
	SELECT *
	FROM Payment_Objects
	WHERE (payment_object_type = @type_key)
	AND object_account_key = @object_key
END
GO
/****** Object:  View [dbo].[vw_Transactions_All]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Transactions_All]
AS
SELECT        tx_key = CONVERT(int, '1' + CONVERT(varchar(20), tx_external_key)), tx_status = tx_external_status, purpose_type, purpose_object_key, currency, amount, 
                         payment_object_sender, payment_object_receiver, tx_description = tx_external_description, last_changed, ip_address, user_key_updated, date_created, 
                         date_processed, tx_status_text =
                             (SELECT        status_description
                               FROM            Transaction_Status
                               WHERE        transaction_status_key = tx_external_status), currency_text =
                             (SELECT        info_currency_name
                               FROM            dbo.Info_Currencies
                               WHERE        (currency = info_currencies_key))
FROM            Transactions_External
UNION
SELECT        tx_key = CONVERT(int, '2' + CONVERT(varchar(20), tx_internal_key)), tx_status = tx_internal_status, purpose_type, purpose_object_key, currency, amount, 
                         payment_object_sender, payment_object_receiver, tx_description = tx_internal_description, last_changed, ip_address, user_key_updated, date_created, 
                         date_processed, tx_status_text =
                             (SELECT        status_description
                               FROM            Transaction_Status
                               WHERE        transaction_status_key = tx_internal_status), currency_text =
                             (SELECT        info_currency_name
                               FROM            dbo.Info_Currencies
                               WHERE        (currency = info_currencies_key))
FROM            Transactions_Internal
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions_All'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions_All'
GO
/****** Object:  View [dbo].[vw_info_banks]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_info_banks]
AS
SELECT        info_organizations_key, organization_name, user_key_updated, last_changed, organization_description
FROM            dbo.Info_Organizations
WHERE        (organization_type = 1)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Info_Organizations"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 235
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_info_banks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_info_banks'
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Security_Answers]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Security_Answers]
	@user_key int

AS
BEGIN
	SELECT *
	FROM Users_Security_Answers
	WHERE user_key = @user_key
	
END
GO
/****** Object:  View [dbo].[vw_aspnet_Applications]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Applications]
  AS SELECT [dbo].[aspnet_Applications].[ApplicationName], [dbo].[aspnet_Applications].[LoweredApplicationName], [dbo].[aspnet_Applications].[ApplicationId], [dbo].[aspnet_Applications].[Description]
  FROM [dbo].[aspnet_Applications]
GO
/****** Object:  StoredProcedure [dbo].[View_Verification_Methods]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Verification_Methods]
	
AS
BEGIN

	SELECT *
	FROM Verification_Methods
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Verified_byCode_nouserkey]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Verified_byCode_nouserkey]
	@unique_key nvarchar(50),
	@verification_methods_key int

AS
BEGIN

	SELECT *
	FROM Users_Verified
	WHERE unique_key = @unique_key
	AND verification_methods_key = @verification_methods_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Verified_byCode]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Users_Verified_byCode]
	@unique_key nvarchar(50),
	@verification_methods_key int,
	@user_key int

AS
BEGIN

	SELECT *
	FROM Users_Verified
	WHERE unique_key = @unique_key
	AND verification_methods_key = @verification_methods_key
	AND user_key = @user_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Verification_Email]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Verification_Email]
	@user_key int,
	@isverified bit,
	@ip_address nchar(20),
	@unique_key nvarchar(50)

AS
BEGIN

DECLARE @Check_verification_key int

if @user_key > 0
	BEGIN
	SET @Check_verification_key = (SELECT user_key FROM Users_Verified WHERE user_key = @user_key AND verification_methods_key = 1)
	END

If @Check_verification_key is null --Create new record
	BEGIN
	
	INSERT INTO Users_Verified
	(user_key, verification_methods_key, isverified, last_changed, ip_address, unique_key)
	VALUES
	(@user_key, 1, 0, getdate(), @ip_address, @unique_key)

	END
ELSE
	BEGIN
		UPDATE Users_Verified
			SET
				user_key = @user_key,
				unique_key = @unique_key,
				isverified = @isverified,
				ip_address = @ip_address,
				last_changed = getdate()				
			WHERE user_key = @user_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Verification]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Verification]
	@user_key int,
	@verification_method int,
	@isverified bit,
	@ip_address nchar(20),
	@unique_key nvarchar(50)

AS
BEGIN

DECLARE @Check_verification_key int

if @user_key > 0
	BEGIN
	SET @Check_verification_key = (SELECT user_key FROM Users_Verified WHERE user_key = @user_key AND verification_methods_key = @verification_method)
	END

If @Check_verification_key is null --Create new record
	BEGIN
	
	INSERT INTO Users_Verified
	(user_key, verification_methods_key, isverified, last_changed, ip_address, unique_key)
	VALUES
	(@user_key, @verification_method, @isverified, getdate(), @ip_address, @unique_key)

	END
ELSE
	BEGIN
		UPDATE Users_Verified
			SET
				user_key = @user_key,
				unique_key = @unique_key,
				isverified = @isverified,
				ip_address = @ip_address,
				last_changed = getdate()				
			WHERE user_key = @user_key
			AND verification_methods_key = @verification_method
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Timezone]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_Timezone]
	@user_key int,
	@timezone int

AS
BEGIN

		UPDATE Users_Info
			SET
				timezone = @timezone,
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Status]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_Status]
	@user_key int,
	@status int

AS
BEGIN

		UPDATE Users
			SET
				user_status = @status,				
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Security_Answers]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Users_Security_Answers]
	@user_key int,
	@question int,
	@answer nvarchar(50)	

AS
BEGIN

DECLARE @Check_answersamount int

if @user_key > 0
	BEGIN
	SET @Check_answersamount = (SELECT Count(user_key) FROM Users_Security_Answers WHERE user_key = @user_key)
	

	If @Check_answersamount < 3 --Create new record
		BEGIN	

		INSERT INTO Users_Security_Answers
		(user_key, question, answer, date_created, last_changed)
		VALUES
		(@user_key, @question, @answer, getdate(), getdate())	

		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Referral]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_Referral]
	@user_key int,
	@referral text

AS
BEGIN

		UPDATE Users_Info
			SET
				referral = @referral,	
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_PhoneNumber]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_PhoneNumber]
	@user_key int,
	@phonenumber nvarchar(20)

AS
BEGIN

		UPDATE Users_Info
			SET
				phonenumber1 = @phonenumber,
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Passport]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_Passport]
	@user_key int,
	@passportnumber nchar(44)

AS
BEGIN

		UPDATE Users_Info
			SET
				passportnumber = @passportnumber,
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_LastOnline]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_LastOnline]
	@user_key int

AS
BEGIN

		UPDATE Users
			SET				
				last_online = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Info_Signup_Tab3]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Users_Info_Signup_Tab3]
	@user_key int,
	@username nvarchar(50),
	@password nvarchar(50)	

AS
BEGIN

		UPDATE Users_Info
			SET
				username = @username,
				password = @password,				
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Info]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Users_Info]
	@user_key int,
	@address1 nvarchar(100),
	@address2 nvarchar(100),
	@city nvarchar(100),
	@state nvarchar(100),
	@country int,
	@postalcode nvarchar(20),
	@phonecountrycode1 int,
	@phonetype1 int,
	@phonenumber1 nvarchar(20),
	@phonecountrycode2 int,
	@phonetype2 int,
	@phonenumber2 nvarchar(20),
	@identitynationality int,
	@occupation nvarchar(50),
	@passportnumber nchar(44),
	@ssn char(9)

AS
BEGIN

DECLARE @Check_user_key int

if @user_key > 0
	BEGIN
	SET @Check_user_key = (SELECT user_key FROM Users_Info WHERE user_key = @user_key)
	END

If @Check_user_key is null --Create new record
	BEGIN	

	INSERT INTO Users_Info
	(user_key, address1, address2, city, state, country, postalcode, phonecountrycode1, phonetype1, phonenumber1, phonecountrycode2, phonetype2, phonenumber2, identitynationality, occupation, passportnumber, last_changed, ssn)
	VALUES
	(@user_key, @address1, @address2, @city, @state, @country, @postalcode, @phonecountrycode1, @phonetype1, @phonenumber1, @phonecountrycode2, @phonetype2, @phonenumber2, @identitynationality, @occupation, @passportnumber, getdate(),@ssn)
	

	END
ELSE
	BEGIN
		UPDATE Users_Info
			SET
				user_key = @user_key, 
				address1 = @address1, 
				address2 = @address2, 
				city = @city, 
				state = @state, 
				country = @country, 
				postalcode = @postalcode, 
				phonecountrycode1 = @phonecountrycode1, 
				phonetype1 = @phonetype1, 
				phonenumber1 = @phonenumber1, 
				phonecountrycode2 = @phonecountrycode2, 
				phonetype2 = @phonetype2, 
				phonenumber2 = @phonenumber2, 
				identitynationality = @identitynationality, 
				occupation = @occupation, 
				passportnumber = @passportnumber, 				
				ssn = @ssn,
				last_changed = getdate()				
			WHERE user_key = @user_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_DefaultCurrency]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_DefaultCurrency]
	@user_key int,
	@defaultcurrency int

AS
BEGIN

		UPDATE Users_Info
			SET
				default_currency = @defaultcurrency,
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users_Address]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users_Address]
	@user_key int,
	@address1 nvarchar(100),
	@address2 nvarchar(100),
	@city nvarchar(100),
	@state nvarchar(100),
	@country int,
	@postalcode nvarchar(20)	

AS
BEGIN

		UPDATE Users_Info
			SET				
				address1 = @address1, 
				address2 = @address2, 
				city = @city, 
				state = @state, 
				country = @country, 
				postalcode = @postalcode,
				last_changed = getdate()				
			WHERE user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Users]
	@user_key int,
	@title nchar(10),
	@first_name nvarchar(100),
	@middle_name nvarchar (100),
	@last_name nvarchar (100),
	@dob datetime,
	@country_residence int,
	@email nvarchar (100),
	@ip_address nchar(20),
	@user_key_return int Output

AS
BEGIN

DECLARE @Check_user_key int

if @user_key > 0
	BEGIN
	SET @Check_user_key = (SELECT user_key FROM Users WHERE user_key = @user_key)
	END

If @Check_user_key is null --Create new record
	BEGIN
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Users
	(title,first_name,middle_name,last_name,dob,country_residence,email,ip_address,last_changed,signed_up, user_status)
	VALUES
	(@title,@first_name,@middle_name,@last_name,@dob,@country_residence,@email,@ip_address, @CurrentDate,@CurrentDate, 1)

	SET @user_key_return = SCOPE_IDENTITY()--(SELECT user_key FROM Users WHERE signed_up = @CurrentDate)

	--Assign unique account number
	DECLARE @accountnumber varchar(10)
	SET @accountnumber = CONVERT(varchar(6),CAST(RAND() * 10000 AS INT)) + CONVERT(varchar(5),@user_key_return)

	UPDATE Users SET
		account_number = @accountnumber
	WHERE user_key = @user_key_return

	--Give user payment object for balance & payment object for frozen balance
	INSERT INTO Payment_Objects
	(payment_object_type, object_account_key, date_created)
	VALUES
	(3, @user_key_return, getdate())

	INSERT INTO Payment_Objects
	(payment_object_type, object_account_key, date_created)
	VALUES
	(4, @user_key_return, getdate())

	END
ELSE
	BEGIN
		UPDATE Users
			SET
				title = @title,
				first_name = @first_name,
				middle_name = @middle_name,
				last_name = @last_name,
				dob = @dob,
				country_residence = @country_residence,
				email = @email,
				ip_address = @ip_address,
				last_changed = getdate()				
			WHERE user_key = @user_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transactions_Internal]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transactions_Internal]
	
	@tx_internal_key int,	
	@tx_internal_status int,	
	@currency int,
	@amount money,
	@payment_object_sender bigint,	
	@payment_object_receiver bigint,
	@ip_address varchar(20),
	@user_key_updated int,
	@tx_internal_description nvarchar(100),				
	@tx_internal_key_return int Output,
	@purpose_type int,
	@purpose_object_key int
	
AS
BEGIN

DECLARE @check_tx_internal int

if @tx_internal_key > 0
	BEGIN
	SET @check_tx_internal = (SELECT tx_internal_key FROM Transactions_Internal WHERE tx_internal_key = @tx_internal_key)
	END

If @check_tx_internal is null --Create new record
	BEGIN
	
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Transactions_Internal
	(tx_internal_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_internal_description, date_created, purpose_type, purpose_object_key)
	VALUES
	( @tx_internal_status, @currency, @amount, @payment_object_sender, @payment_object_receiver, @CurrentDate, @ip_address, @user_key_updated, @tx_internal_description, @CurrentDate, @purpose_type, @purpose_object_key)

	SET @tx_internal_key_return = (SELECT tx_internal_key FROM Transactions_Internal WHERE last_changed = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Transactions_Internal
			SET
				tx_internal_status = @tx_internal_status,
				currency = @currency,
				amount = @amount,
				payment_object_sender = @payment_object_sender,
				payment_object_receiver = @payment_object_receiver,
				user_key_updated = @user_key_updated,
				ip_address = @ip_address,								
				last_changed = getdate(),
				purpose_type = @purpose_type,
				purpose_object_key = @purpose_object_key
			WHERE tx_internal_key = @tx_internal_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transactions_External]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transactions_External]
	
	@tx_external_key int,	
	@tx_external_status int,	
	@currency int,
	@amount money,
	@payment_object_sender bigint,	
	@payment_object_receiver bigint,
	@ip_address varchar(20),
	@user_key_updated int,
	@tx_external_description nvarchar(100),			
	@bank_reference varchar(100),
	@tx_external_key_return int Output,
	@purpose_type int,
	@purpose_object_key int
	
AS
BEGIN

DECLARE @check_tx_external int

if @tx_external_key > 0
	BEGIN
	SET @check_tx_external = (SELECT tx_external_key FROM Transactions_External WHERE tx_external_key = @tx_external_key)
	END

If @check_tx_external is null --Create new record
	BEGIN
	
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Transactions_External
	(tx_external_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_external_description,bank_reference, date_created, purpose_type, purpose_object_key)
	VALUES
	( @tx_external_status, @currency, @amount, @payment_object_sender, @payment_object_receiver, @CurrentDate, @ip_address, @user_key_updated, @tx_external_description,@bank_reference, @CurrentDate, @purpose_type, @purpose_object_key)

	SET @tx_external_key_return = (SELECT tx_external_key FROM Transactions_External WHERE last_changed = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Transactions_External
			SET
				tx_external_status = @tx_external_status,
				currency = @currency,
				amount = @amount,
				payment_object_sender = @payment_object_sender,
				payment_object_receiver = @payment_object_receiver,
				user_key_updated = @user_key_updated,
				ip_address = @ip_address,				
				bank_reference = @bank_reference,
				last_changed = getdate(),
				purpose_type = @purpose_type,
				purpose_object_key = @purpose_object_key
			WHERE tx_external_key = @tx_external_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transaction_Fees]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transaction_Fees]

	@tx_fees_key int,		
	@tx_type int,
	@tx_key int,
	@amount money,
	@currency int,
	@description nvarchar(100),
	@fee_type int,
	@tx_fees_key_return int Output
	
AS
BEGIN

DECLARE @check_tx_fees int

if @tx_fees_key > 0
	BEGIN
	SET @check_tx_fees = (SELECT tx_fees_key FROM Transaction_Fees WHERE tx_fees_key = @tx_fees_key)
	END

If @check_tx_fees is null --Create new record
	BEGIN
	
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Transaction_Fees
	( tx_type, tx_key, currency, amount, description, date_created, fee_type)
	VALUES
	( @tx_type, @tx_key, @currency, @amount, @description, @CurrentDate, @fee_type)

	SET @tx_fees_key_return = (SELECT tx_fees_key FROM Transaction_Fees WHERE date_created = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Transaction_Fees
			SET				
				tx_type = @tx_type,				
				currency = @currency,
				amount = @amount,
				description = @description,
				fee_type = @fee_type			
			WHERE tx_fees_key = @tx_fees_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transaction_External_Status]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transaction_External_Status]
	
	@tx_external_key int,	
	@tx_external_status int,
	@ip_address varchar(20),
	@user_key_updated int
	
AS
BEGIN

			--tx statuses 
            --1 = pending
            --2 = processed
            --3 = removed
		UPDATE Transactions_External
			SET
				tx_external_status = @tx_external_status,				
				user_key_updated = @user_key_updated,
				ip_address = @ip_address,								
				last_changed = getdate()				
			WHERE tx_external_key = @tx_external_key

		IF @tx_external_status = 2
			BEGIN

				UPDATE Transactions_External
				SET
					date_processed = getdate()
				WHERE tx_external_key = @tx_external_key

			END
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transaction_External_Purpose]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transaction_External_Purpose]
	
	@tx_external_key int,		
	@purpose_type int,
	@object_key int
	
AS
BEGIN
			
		UPDATE Transactions_External
			SET
				purpose_type = @purpose_type,
				purpose_object_key = @object_key,
				last_changed = getdate()				
			WHERE tx_external_key = @tx_external_key

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Scheduled_Task]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Scheduled_Task]
	@scheduled_task_type int

AS
BEGIN


	INSERT INTO Scheduled_Task
	(scheduled_task_type, date_changed)
	VALUES
	(@scheduled_task_type, getdate())	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Recipients]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Recipients]
	@recipients_key int,
	@user_key int,
	@payment_object_key bigint

AS
BEGIN

DECLARE @Check_recipients_key int

if @recipients_key > 0
	BEGIN
	SET @Check_recipients_key = (SELECT recipients_key FROM Recipients WHERE recipients_key = @recipients_key)
	END

If @Check_recipients_key is null --Create new record
	BEGIN	

	INSERT INTO Recipients
	(user_key, payment_object_key)
	VALUES
	(@user_key,@payment_object_key)	

	END
ELSE
	BEGIN
		UPDATE Recipients
			SET
				user_key = @user_key,
				payment_object_key = @payment_object_key
			WHERE recipients_key = @recipients_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Quotes]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Quotes]
	@quotes_key int,
	@sell_amount money,
	@sell_currency int,
	@buy_amount money,
	@buy_currency int,
	@rate decimal(10,4),
	@service_fee money,
	@promised_delivery_date datetime,
	@actual_delivery_date datetime,
	@quotes_key_return int Output

AS
BEGIN

DECLARE @Check_quotes_key int

if @quotes_key > 0
	BEGIN
	SET @Check_quotes_key = (SELECT quotes_key FROM Quotes WHERE quotes_key = @quotes_key)
	END

If @Check_quotes_key is null --Create new record
	BEGIN
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Quotes
	(sell_amount,sell_currency,buy_amount,buy_currency,rate,service_fee,promised_delivery_date,actual_delivery_date,date_created)
	VALUES
	(@sell_amount,@sell_currency,@buy_amount,@buy_currency,@rate,@service_fee,@promised_delivery_date,@actual_delivery_date,getdate())

	SET @quotes_key_return = SCOPE_IDENTITY()--(SELECT quotes_key FROM Quotes WHERE date_created = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Quotes
			SET
				sell_amount = @sell_amount,
				sell_currency = @sell_currency,
				buy_amount = @buy_amount,
				buy_currency = @buy_currency,
				rate = @rate,
				service_fee = @service_fee,
				promised_delivery_date = @promised_delivery_date,
				actual_delivery_date = @actual_delivery_date
			WHERE quotes_key = @quotes_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Bank_Accounts]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Bank_Accounts]
	@bank_account_key int,
	@user_key int,
	@currency_key int,
	@organization_key int,
	@bank_account_description nvarchar(100),
	@user_key_updated int,
	@ip_address varchar(20),
	@account_number varchar(50),
	@IBAN varchar(50),
	@BIC varchar(50),
	@ABArouting varchar(50),
	@first_name nvarchar(100),
	@last_name nvarchar(100),
	@business_name nvarchar(100),
	@bank_account_key_return int Output,
	@sortcode varchar(50),
	@bsb varchar(50),
	@email nvarchar(100),
	@bankname nvarchar(100),
	@branchcode varchar(50),
	@institutionnumber varchar(4)

AS
BEGIN

DECLARE @Check_bank_account_key int

if @bank_account_key > 0
	BEGIN
	SET @Check_bank_account_key = (SELECT bank_account_key FROM Bank_Accounts WHERE bank_account_key = @bank_account_key)
	END

If @Check_bank_account_key is null --Create new record
	BEGIN
	DECLARE @CurrentDate datetime
	SET @CurrentDate = getdate()

	INSERT INTO Bank_Accounts
	(user_key,currency_key,organization_key,bank_account_description,user_key_updated,ip_address,account_number,IBAN,BIC,ABArouting,first_name,last_name,business_name,last_changed,date_created,SortCode,BSB,email,bank_name,branch_code,institution_number)
	VALUES
	(@user_key,@currency_key,@organization_key,@bank_account_description,@user_key_updated,@ip_address,@account_number,@IBAN,@BIC,@ABArouting,@first_name,@last_name,@business_name,@CurrentDate,@CurrentDate,@sortcode,@bsb,@email,@bankname,@branchcode,@institutionnumber)

	SET @bank_account_key_return = SCOPE_IDENTITY()--(SELECT bank_account_key FROM Bank_Accounts WHERE date_created = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Bank_Accounts
			SET
				user_key = @user_key,
				currency_key = @currency_key,
				organization_key = @organization_key,				
				bank_account_description = @bank_account_description,
				user_key_updated = @user_key_updated,
				ip_address = @ip_address,
				account_number = @account_number,
				IBAN = @IBAN,
				BIC = @BIC,
				ABArouting = @ABArouting,
				first_name = @first_name,
				last_name = @last_name,
				business_name = @business_name,
				last_changed = getdate(),
				SortCode = @sortcode,
				BSB = @bsb,
				email = @email,
				bank_name = @bankname,
				branch_code = @branchcode,
				institution_number = @institutionnumber
			WHERE bank_account_key = @bank_account_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_BancBox_Clientstatus]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_BancBox_Clientstatus]
	@client_id int,
	@clientstatus varchar(50)

AS
BEGIN

	UPDATE Users_Bancbox 
		SET
		client_status = @clientstatus
	WHERE client_id = @client_id
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_BancBox_Clientid]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_BancBox_Clientid]
	@user_key int,
	@client_id int

AS
BEGIN

DECLARE @Check_bancbox_client_id int
SET @Check_bancbox_client_id = (SELECT client_id FROM Users_Bancbox WHERE @user_key = user_key)

If @Check_bancbox_client_id is null 
	BEGIN
	INSERT INTO Users_Bancbox
	(user_key, client_id)
	VALUES
	(@user_key, @client_id)
	END
ELSE
	BEGIN
	UPDATE Users_Bancbox 
		SET
		client_id = @client_id
	WHERE @user_key = user_key
	END	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_BancBox_Cipstatus]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_BancBox_Cipstatus]
	@client_id int,
	@cipstatus varchar(50)

AS
BEGIN

	UPDATE Users_Bancbox 
		SET
		cip_status = @cipstatus
	WHERE client_id = @client_id
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_API_Errors]    Script Date: 04/28/2013 18:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_API_Errors]	

	@api_type int,
	@request text,	
	@response text,
	@url text

AS
BEGIN

INSERT INTO API_Errors
(api_type,request,response, url, dateoccured)
VALUES
(@api_type,@request,@response, @url, getdate())
	
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[txt_Admin_Bank_Account_CurrencyExchange]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[txt_Admin_Bank_Account_CurrencyExchange]
	(@currency int,
	@country int)

RETURNS bigint
AS
BEGIN

	DECLARE @system_payment_object_key bigint
	SET @system_payment_object_key = (SELECT Payment_Objects.payment_object_key FROM Payment_Objects
									INNER JOIN Admin_Bank_Accounts
									ON Admin_Bank_Accounts.payment_object_key = Payment_Objects.payment_object_key
									WHERE payment_object_type = 2 --Admin bank account
									AND receiving_currency = @currency
									AND ((receiving_country = @country) OR (receiving_country = 0))
									)
	RETURN @system_payment_object_key
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_is_Admin_Bank_Account_Payment_Object]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_is_Admin_Bank_Account_Payment_Object]
	(@payment_object_key bigint)
RETURNS bit
AS
	BEGIN
	DECLARE @isadminbankaccount bit
	DECLARE @paymentobjectscount int
	SET @paymentobjectscount = (SELECT Count(*) FROM Payment_Objects WHERE payment_object_key = @payment_object_key AND payment_object_type = 2)
	
	IF @paymentobjectscount > 0
		BEGIN
		SET @isadminbankaccount = 1
		END
	ELSE
		BEGIN
		SET @isadminbankaccount = 0
		END
	

	RETURN @isadminbankaccount
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CurrencyCloud_Trade_Releasedate]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_CurrencyCloud_Trade_Releasedate]
	(@settlementkey bigint)
RETURNS datetime
AS
	BEGIN
		
	RETURN (SELECT releasedate FROM CurrencyCloud_Settlements WHERE currencycloud_settlement_key = @settlementkey)
	
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_currency_symbol]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_txt_currency_symbol]
	(@currency int)
RETURNS nchar(3)
AS
	BEGIN
	declare @currencysymbol nchar(3)
	SET @currencysymbol = (SELECT info_currency_symbol FROM Info_Currencies WHERE info_currencies_key = @currency)
	RETURN @currencysymbol
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_currency_code]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_txt_currency_code]
	(@currency int)
RETURNS nchar(3)
AS
	BEGIN
	declare @currencycode nchar(3)
	SET @currencycode = (SELECT info_currency_code FROM Info_Currencies WHERE info_currencies_key = @currency)
	RETURN @currencycode
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Payment_Object_Key]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_Payment_Object_Key]
	(@payment_object_type int,
	@object_account_key int)
RETURNS bigint
AS
	BEGIN
	declare @payment_object_key bigint
	SELECT @payment_object_key = (SELECT payment_object_key FROM Payment_Objects WHERE @payment_object_type = payment_object_type AND @object_account_key = object_account_key)
	RETURN @payment_object_key
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_payment_object_isexternal]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_payment_object_isexternal]
	(@payment_object_key int)
RETURNS bit
AS
	BEGIN
	declare @isexternal bit
	SELECT @isexternal = (SELECT payment_object_type_isexternal FROM Payment_Object_Types WHERE (SELECT payment_object_type FROM Payment_Objects WHERE payment_object_key = @payment_object_key) = payment_object_type_key)
	RETURN @isexternal
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Payment_Object_Account_Key]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_Payment_Object_Account_Key]
	(@payment_object_key bigint)
RETURNS int
AS
	BEGIN
	declare @object_account_key int
	SELECT @object_account_key = (SELECT object_account_key FROM Payment_Objects WHERE @payment_object_key = payment_object_key)
	RETURN @object_account_key
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Organization_Name]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Organization_Name]
	(@organization_key int)
RETURNS nvarchar(50)
AS
	BEGIN
	declare @orgname nvarchar(50)	
	SELECT @orgname = CASE WHEN (SELECT organization_name FROM Info_Organizations WHERE @organization_key = info_organizations_key) IS NULL 
		THEN ''
		ELSE
		(SELECT organization_name FROM Info_Organizations WHERE @organization_key = info_organizations_key)
		END
	RETURN @orgname
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Ledger_Payment_Objects_External_Transactions_Only]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_Ledger_Payment_Objects_External_Transactions_Only]
	(@payment_object_key bigint,
	@currency int)
RETURNS money
AS
	BEGIN
	declare @Balancefull money
	declare @Balancesendexternal money
	declare @Balancereceiveexternal money
	declare @Balancesendinternal money
	declare @Balancereceiveinternal money

	--tx external money being sent from payment object
	SELECT @Balancesendexternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_sender = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_sender = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2
					)
					END

	--tx external money being given to payment object
					SELECT @Balancereceiveexternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_receiver = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_receiver = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2
					)
					END

	SET @Balancefull = @Balancereceiveexternal - @Balancesendexternal 

	RETURN @Balancefull
	END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Users_Security_Answers]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Delete_Users_Security_Answers]
	@user_key int

AS
BEGIN
	DELETE 
	FROM Users_Security_Answers
	WHERE user_key = @user_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_EmbeeCatalog]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Delete_EmbeeCatalog]
	
AS
BEGIN

DELETE
FROM EmbeeCatalog
	
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_CurrencyCloud_Trades_Errors]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Delete_CurrencyCloud_Trades_Errors]
	@paymentkey int

AS
BEGIN

DELETE FROM CurrencyCloud_Trades_Errors
WHERE payments_key = @paymentkey
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_tx_fees_total]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_tx_fees_total]
	(@tx_key int)
RETURNS decimal(20,2)
AS
	BEGIN
	declare @fees decimal(20,2)
	SELECT @fees = Case 
					WHEN (SELECT SUM(amount) FROM Transaction_Fees WHERE tx_key = @tx_key)
					IS NULL THEN 0
					ELSE
					(SELECT SUM(amount) FROM Transaction_Fees WHERE tx_key = @tx_key)
					END
	RETURN @fees
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Treasury_Payment_Object]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Treasury_Payment_Object]
	()
RETURNS bigint
AS
	BEGIN
	
	DECLARE @user_key int
	SET @user_key = (SELECT user_key FROM Treasury_Type WHERE treasury_type_key = 1) -- Treasury key

	declare @payment_object_key bigint
	SELECT @payment_object_key = (SELECT payment_object_key FROM Payment_Objects WHERE 3 = payment_object_type AND @user_key = object_account_key)
	RETURN @payment_object_key
	
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_system_account_specific_currency]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_system_account_specific_currency]
	(@currency int,
	@country int)
RETURNS bigint --return payment object key
AS
	BEGIN
	declare @payment_object_key bigint
	SET @payment_object_key = (SELECT Payment_Objects.payment_object_key
								FROM Payment_Objects
								INNER JOIN Admin_Bank_Accounts
								ON Admin_Bank_Accounts.payment_object_key = Payment_Objects.payment_object_key
								WHERE payment_object_type = 2 --Admin bank account
								AND receiving_currency = @currency
								AND ((receiving_country = @country) OR (receiving_country = 0)))

	RETURN @payment_object_key
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Payment_Object_Type]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_Payment_Object_Type]
	(@payment_object_key bigint)
RETURNS int
AS
	BEGIN
	declare @payment_object_type int
	SELECT @payment_object_type = (SELECT payment_object_type FROM Payment_Objects WHERE @payment_object_key = payment_object_key)
	RETURN @payment_object_type
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_payment_object_requiresmanualexport]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_payment_object_requiresmanualexport]
	(@payment_object_key int)
RETURNS bit
AS
	BEGIN
	declare @isexternal bit
	SELECT @isexternal = (SELECT payment_object_type_requiresmanualexport FROM Payment_Object_Types WHERE (SELECT payment_object_type FROM Payment_Objects WHERE payment_object_key = @payment_object_key) = payment_object_type_key)
	RETURN @isexternal
	END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_WebEvent_LogEvent]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_WebEvent_LogEvent]
        @EventId         char(32),
        @EventTimeUtc    datetime,
        @EventTime       datetime,
        @EventType       nvarchar(256),
        @EventSequence   decimal(19,0),
        @EventOccurrence decimal(19,0),
        @EventCode       int,
        @EventDetailCode int,
        @Message         nvarchar(1024),
        @ApplicationPath nvarchar(256),
        @ApplicationVirtualPath nvarchar(256),
        @MachineName    nvarchar(256),
        @RequestUrl      nvarchar(1024),
        @ExceptionType   nvarchar(256),
        @Details         ntext
AS
BEGIN
    INSERT
        dbo.aspnet_WebEvent_Events
        (
            EventId,
            EventTimeUtc,
            EventTime,
            EventType,
            EventSequence,
            EventOccurrence,
            EventCode,
            EventDetailCode,
            Message,
            ApplicationPath,
            ApplicationVirtualPath,
            MachineName,
            RequestUrl,
            ExceptionType,
            Details
        )
    VALUES
    (
        @EventId,
        @EventTimeUtc,
        @EventTime,
        @EventType,
        @EventSequence,
        @EventOccurrence,
        @EventCode,
        @EventDetailCode,
        @Message,
        @ApplicationPath,
        @ApplicationVirtualPath,
        @MachineName,
        @RequestUrl,
        @ExceptionType,
        @Details
    )
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_CheckSchemaVersion]    Script Date: 04/28/2013 18:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    IF (EXISTS( SELECT  *
                FROM    dbo.aspnet_SchemaVersions
                WHERE   Feature = LOWER( @Feature ) AND
                        CompatibleSchemaVersion = @CompatibleSchemaVersion ))
        RETURN 0

    RETURN 1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Applications_CreateApplication]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Applications_CreateApplication]
    @ApplicationName      nvarchar(256),
    @ApplicationId        uniqueidentifier OUTPUT
AS
BEGIN
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName

    IF(@ApplicationId IS NULL)
    BEGIN
        DECLARE @TranStarted   bit
        SET @TranStarted = 0

        IF( @@TRANCOUNT = 0 )
        BEGIN
	        BEGIN TRANSACTION
	        SET @TranStarted = 1
        END
        ELSE
    	    SET @TranStarted = 0

        SELECT  @ApplicationId = ApplicationId
        FROM dbo.aspnet_Applications WITH (UPDLOCK, HOLDLOCK)
        WHERE LOWER(@ApplicationName) = LoweredApplicationName

        IF(@ApplicationId IS NULL)
        BEGIN
            SELECT  @ApplicationId = NEWID()
            INSERT  dbo.aspnet_Applications (ApplicationId, ApplicationName, LoweredApplicationName)
            VALUES  (@ApplicationId, @ApplicationName, LOWER(@ApplicationName))
        END


        IF( @TranStarted = 1 )
        BEGIN
            IF(@@ERROR = 0)
            BEGIN
	        SET @TranStarted = 0
	        COMMIT TRANSACTION
            END
            ELSE
            BEGIN
                SET @TranStarted = 0
                ROLLBACK TRANSACTION
            END
        END
    END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_RegisterSchemaVersion]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_RegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128),
    @IsCurrentVersion          bit,
    @RemoveIncompatibleSchema  bit
AS
BEGIN
    IF( @RemoveIncompatibleSchema = 1 )
    BEGIN
        DELETE FROM dbo.aspnet_SchemaVersions WHERE Feature = LOWER( @Feature )
    END
    ELSE
    BEGIN
        IF( @IsCurrentVersion = 1 )
        BEGIN
            UPDATE dbo.aspnet_SchemaVersions
            SET IsCurrentVersion = 0
            WHERE Feature = LOWER( @Feature )
        END
    END

    INSERT  dbo.aspnet_SchemaVersions( Feature, CompatibleSchemaVersion, IsCurrentVersion )
    VALUES( LOWER( @Feature ), @CompatibleSchemaVersion, @IsCurrentVersion )
END
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_Users_Index] ON [dbo].[aspnet_Users] 
(
	[ApplicationId] ASC,
	[LoweredUserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [aspnet_Users_Index2] ON [dbo].[aspnet_Users] 
(
	[ApplicationId] ASC,
	[LastActivityDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UnRegisterSchemaVersion]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UnRegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    DELETE FROM dbo.aspnet_SchemaVersions
        WHERE   Feature = LOWER(@Feature) AND @CompatibleSchemaVersion = CompatibleSchemaVersion
END
GO
/****** Object:  View [dbo].[vw_Verification]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Verification]
AS
SELECT        dbo.Users_Verified.users_verified_key, dbo.Users_Verified.user_key, dbo.Users_Verified.verification_methods_key, dbo.Users_Verified.isverified, 
                         dbo.Users_Verified.last_changed, dbo.Users_Verified.unique_key, dbo.Users_Verified.ip_address, dbo.Verification_Methods.verification_method_name, 
                         dbo.Verification_Methods.points, dbo.Verification_Methods.ismandatory
FROM            dbo.Users_Verified INNER JOIN
                         dbo.Verification_Methods ON dbo.Users_Verified.verification_methods_key = dbo.Verification_Methods.verification_method_key
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users_Verified"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 186
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Verification_Methods"
            Begin Extent = 
               Top = 6
               Left = 299
               Bottom = 135
               Right = 529
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Verification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Verification'
GO
/****** Object:  View [dbo].[vw_aspnet_Users]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Users]
  AS SELECT [dbo].[aspnet_Users].[ApplicationId], [dbo].[aspnet_Users].[UserId], [dbo].[aspnet_Users].[UserName], [dbo].[aspnet_Users].[LoweredUserName], [dbo].[aspnet_Users].[MobileAlias], [dbo].[aspnet_Users].[IsAnonymous], [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Users]
GO
/****** Object:  View [dbo].[vw_Transactions_External]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Transactions_External]
AS
SELECT        dbo.Transactions_External.tx_external_key, dbo.Transactions_External.tx_external_status, dbo.Transactions_External.currency, dbo.Transactions_External.amount, 
                         dbo.Transactions_External.tx_external_description, dbo.Transactions_External.last_changed, dbo.Transactions_External.ip_address, 
                         dbo.Transactions_External.user_key_updated, dbo.Transactions_External.bank_reference, dbo.Transactions_External.date_created, 
                         dbo.Transactions_External.date_processed, dbo.Info_Currencies.info_currencies_key, dbo.Info_Currencies.info_currency_code, 
                         dbo.Info_Currencies.info_currency_name, dbo.Info_Currencies.info_currency_country, 
                         dbo.Transactions_External.amount - dbo.fn_tx_fees_total(dbo.Transactions_External.tx_external_key) AS proceeds, 
                         CASE WHEN Transactions_External.payment_object_sender IS NULL THEN NULL ELSE
                             (SELECT        organization_name
                               FROM            Bank_Accounts INNER JOIN
                                                         vw_info_banks ON Bank_Accounts.organization_key = vw_info_banks.info_organizations_key
                               WHERE        (SELECT        object_account_key
                                                         FROM            Payment_Objects
                                                         WHERE        payment_object_key = Transactions_External.payment_object_sender) = Bank_Accounts.bank_account_key) END AS sender_bank_name, 
                         CASE WHEN Transactions_External.payment_object_receiver IS NULL THEN NULL ELSE
                             (SELECT        organization_name
                               FROM            Bank_Accounts INNER JOIN
                                                         vw_info_banks ON Bank_Accounts.organization_key = vw_info_banks.info_organizations_key
                               WHERE        (SELECT        object_account_key
                                                         FROM            Payment_Objects
                                                         WHERE        payment_object_key = Transactions_External.payment_object_receiver) = Bank_Accounts.bank_account_key) 
                         END AS receiver_bank_name, CASE WHEN Transactions_External.payment_object_sender IS NULL THEN NULL ELSE
                             (SELECT        account_number
                               FROM            Bank_Accounts
                               WHERE        (SELECT        object_account_key
                                                         FROM            Payment_Objects
                                                         WHERE        payment_object_key = Transactions_External.payment_object_sender) = Bank_Accounts.bank_account_key) 
                         END AS sender_bank_account, CASE WHEN Transactions_External.payment_object_receiver IS NULL THEN NULL ELSE
                             (SELECT        account_number
                               FROM            Bank_Accounts
                               WHERE        (SELECT        object_account_key
                                                         FROM            Payment_Objects
                                                         WHERE        payment_object_key = Transactions_External.payment_object_receiver) = Bank_Accounts.bank_account_key) 
                         END AS receiver_bank_account, dbo.Transactions_External.payment_object_sender, dbo.Transactions_External.payment_object_receiver
FROM            dbo.Transactions_External INNER JOIN
                         dbo.Info_Currencies ON dbo.Transactions_External.currency = dbo.Info_Currencies.info_currencies_key
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Transactions_External"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 247
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "Info_Currencies"
            Begin Extent = 
               Top = 66
               Left = 949
               Bottom = 195
               Right = 1156
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 18
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 10755
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions_External'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Transactions_External'
GO
/****** Object:  UserDefinedFunction [dbo].[fn_user_verification_points]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_user_verification_points]
	(@user_key int)
RETURNS int
AS
	BEGIN
	declare @points int
	SELECT @points = Case 
					WHEN (SELECT SUM(points) FROM vw_Verification WHERE user_key = @user_key AND isverified = 1)
					IS NULL THEN 0
					ELSE
					(SELECT SUM(points) FROM vw_Verification WHERE user_key = @user_key AND isverified = 1)
					END
	RETURN @points
	END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_DeleteUser]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_DeleteUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @TablesToDeleteFrom int,
    @NumTablesDeletedFrom int OUTPUT
AS
BEGIN
    DECLARE @UserId               uniqueidentifier
    SELECT  @UserId               = NULL
    SELECT  @NumTablesDeletedFrom = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
	SET @TranStarted = 0

    DECLARE @ErrorCode   int
    DECLARE @RowCount    int

    SET @ErrorCode = 0
    SET @RowCount  = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   u.LoweredUserName       = LOWER(@UserName)
        AND u.ApplicationId         = a.ApplicationId
        AND LOWER(@ApplicationName) = a.LoweredApplicationName

    IF (@UserId IS NULL)
    BEGIN
        GOTO Cleanup
    END

    -- Delete from Membership table if (@TablesToDeleteFrom & 1) is set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        DELETE FROM dbo.aspnet_Membership WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
               @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_UsersInRoles table if (@TablesToDeleteFrom & 2) is set
    IF ((@TablesToDeleteFrom & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_UsersInRoles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_UsersInRoles WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Profile table if (@TablesToDeleteFrom & 4) is set
    IF ((@TablesToDeleteFrom & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_Profile WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_PersonalizationPerUser table if (@TablesToDeleteFrom & 8) is set
    IF ((@TablesToDeleteFrom & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationPerUser WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Users table if (@TablesToDeleteFrom & 1,2,4 & 8) are all set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (@TablesToDeleteFrom & 2) <> 0 AND
        (@TablesToDeleteFrom & 4) <> 0 AND
        (@TablesToDeleteFrom & 8) <> 0 AND
        (EXISTS (SELECT UserId FROM dbo.aspnet_Users WHERE @UserId = UserId)))
    BEGIN
        DELETE FROM dbo.aspnet_Users WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    IF( @TranStarted = 1 )
    BEGIN
	    SET @TranStarted = 0
	    COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:
    SET @NumTablesDeletedFrom = 0

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
	    ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_CreateUser]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_CreateUser]
    @ApplicationId    uniqueidentifier,
    @UserName         nvarchar(256),
    @IsUserAnonymous  bit,
    @LastActivityDate DATETIME,
    @UserId           uniqueidentifier OUTPUT
AS
BEGIN
    IF( @UserId IS NULL )
        SELECT @UserId = NEWID()
    ELSE
    BEGIN
        IF( EXISTS( SELECT UserId FROM dbo.aspnet_Users
                    WHERE @UserId = UserId ) )
            RETURN -1
    END

    INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
    VALUES (@ApplicationId, @UserId, @UserName, LOWER(@UserName), @IsUserAnonymous, @LastActivityDate)

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_AnyDataInTables]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_AnyDataInTables]
    @TablesToCheck int
AS
BEGIN
    -- Check Membership table if (@TablesToCheck & 1) is set
    IF ((@TablesToCheck & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Membership))
        BEGIN
            SELECT N'aspnet_Membership'
            RETURN
        END
    END

    -- Check aspnet_Roles table if (@TablesToCheck & 2) is set
    IF ((@TablesToCheck & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Roles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 RoleId FROM dbo.aspnet_Roles))
        BEGIN
            SELECT N'aspnet_Roles'
            RETURN
        END
    END

    -- Check aspnet_Profile table if (@TablesToCheck & 4) is set
    IF ((@TablesToCheck & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Profile))
        BEGIN
            SELECT N'aspnet_Profile'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 8) is set
    IF ((@TablesToCheck & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_PersonalizationPerUser))
        BEGIN
            SELECT N'aspnet_PersonalizationPerUser'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 16) is set
    IF ((@TablesToCheck & 16) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'aspnet_WebEvent_LogEvent') AND (type = 'P'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 * FROM dbo.aspnet_WebEvent_Events))
        BEGIN
            SELECT N'aspnet_WebEvent_Events'
            RETURN
        END
    END

    -- Check aspnet_Users table if (@TablesToCheck & 1,2,4 & 8) are all set
    IF ((@TablesToCheck & 1) <> 0 AND
        (@TablesToCheck & 2) <> 0 AND
        (@TablesToCheck & 4) <> 0 AND
        (@TablesToCheck & 8) <> 0 AND
        (@TablesToCheck & 32) <> 0 AND
        (@TablesToCheck & 128) <> 0 AND
        (@TablesToCheck & 256) <> 0 AND
        (@TablesToCheck & 512) <> 0 AND
        (@TablesToCheck & 1024) <> 0)
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Users))
        BEGIN
            SELECT N'aspnet_Users'
            RETURN
        END
        IF (EXISTS(SELECT TOP 1 ApplicationId FROM dbo.aspnet_Applications))
        BEGIN
            SELECT N'aspnet_Applications'
            RETURN
        END
    END
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_bank_account_info]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_txt_bank_account_info]
	(@payment_object_key int)
	--@organization_key int,
	--@account_number varchar(50))
RETURNS nvarchar(100)
AS
	BEGIN

	declare @bankaccountkey int
	SET @bankaccountkey = (SELECT object_account_key FROM Payment_Objects WHERE (payment_object_type = 1 OR payment_object_type = 2) AND payment_object_key = @payment_object_key)

	declare @orgkey int
	SET @orgkey = (SELECT organization_key FROM Bank_Accounts WHERE @bankaccountkey = bank_account_key)

	declare @account_number varchar(50)
	SET @account_number = (SELECT account_number FROM Bank_Accounts WHERE @bankaccountkey = bank_account_key)

	declare @currencykey int
	SET @currencykey = (SELECT currency_key FROM Bank_Accounts WHERE @bankaccountkey = bank_account_key)

	declare @currencycode char(3)
	SET @currencycode = (SELECT info_currency_code FROM Info_Currencies WHERE info_currencies_key = @currencykey)

	declare @txtbankaccountinfo nvarchar(100)
	SET @txtbankaccountinfo = CONVERT(varchar(20), @payment_object_key) + ' - ' + dbo.fn_Organization_Name(@orgkey) + ' - ' + @currencycode + ' - ' + @account_number
	RETURN @txtbankaccountinfo
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CurrencyCloud_Payment_Object]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_CurrencyCloud_Payment_Object]
	()
RETURNS bigint
AS
	BEGIN
	
	DECLARE @user_key int
	SET @user_key = (SELECT user_key FROM Treasury_Type WHERE treasury_type_key = 2) -- CurrencyCloud userkey

	declare @payment_object_key bigint
	SELECT @payment_object_key = dbo.fn_Payment_Object_Key(3, @user_key)
	RETURN @payment_object_key
	
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Ledger_Overall_System]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Ledger_Overall_System]
	(@currency int) --Only takes into account money coming in & out of the system
RETURNS money
AS
	BEGIN
	declare @Balancefull money
	declare @Balancesendexternal money
	declare @Balancereceiveexternal money
	declare @Balancesendinternal money
	declare @Balancereceiveinternal money

	--tx external money being sent from payment object
	SELECT @Balancesendexternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE dbo.fn_is_Admin_Bank_Account_Payment_Object(payment_object_sender) = 1
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE dbo.fn_is_Admin_Bank_Account_Payment_Object(payment_object_sender) = 1
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2
					)
					END

	--tx external money being given to payment object
	SELECT @Balancereceiveexternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE dbo.fn_is_Admin_Bank_Account_Payment_Object(payment_object_receiver) = 1
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE dbo.fn_is_Admin_Bank_Account_Payment_Object(payment_object_receiver) = 1
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2
					)
					END

	SET @Balancefull = @Balancereceiveexternal - @Balancesendexternal

	RETURN @Balancefull
	END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Verified]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Users_Verified]
	@user_key int,
	@verification_methods_key int

AS
BEGIN

	SELECT *
	FROM vw_Verification
	WHERE user_key = @user_key
	AND verification_methods_key = @verification_methods_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Object_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payment_Object_Specific]
	@payment_object_key bigint
AS
BEGIN
	
	SELECT *,
	isexternal = dbo.fn_payment_object_isexternal(payment_object_key)
	FROM Payment_Objects
	WHERE payment_object_key = @payment_object_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[view_Transaction_External]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[view_Transaction_External]
	
AS
	SELECT        
		*,

		vw_sender_bank_name = CASE WHEN Transactions_External.sender_bank_account_key IS NULL 
							 THEN dbo.Transactions_External.sender_bank_name 
							 ELSE (SELECT organization_name FROM Bank_Accounts
								 INNER JOIN vw_info_banks
								 ON Bank_Accounts.bank_key = vw_info_banks.info_organizations_key
								  WHERE Transactions_External.sender_bank_account_key = Bank_Accounts.bank_account_key)
							 END,
		vw_sender_bank_account = CASE WHEN Transactions_External.sender_bank_account_key IS NULL 
							 THEN dbo.Transactions_External.sender_bank_account 
							 ELSE (SELECT bank_account FROM Bank_Accounts WHERE Transactions_External.sender_bank_account_key = Bank_Accounts.bank_account_key)
							 END,
		vw_receiver_bank_name = CASE WHEN Transactions_External.receiver_bank_account_key IS NULL 
							 THEN dbo.Transactions_External.receiver_bank_name 
							 ELSE (SELECT organization_name FROM Bank_Accounts
								 INNER JOIN vw_info_banks
								 ON Bank_Accounts.bank_key = vw_info_banks.info_organizations_key
								  WHERE Transactions_External.receiver_bank_account_key = Bank_Accounts.bank_account_key)
							 END,
		vw_receiver_bank_account = CASE WHEN Transactions_External.receiver_bank_account_key IS NULL 
							 THEN dbo.Transactions_External.receiver_bank_account 
							 ELSE (SELECT bank_account FROM Bank_Accounts WHERE Transactions_External.receiver_bank_account_key = Bank_Accounts.bank_account_key)
							 END,
		proceeds = amount - dbo.fn_tx_fees_total(tx_external_key)
	FROM Transactions_External 
	INNER JOIN Info_Currencies 
	ON Transactions_External.currency = Info_Currencies.info_currencies_key
GO
/****** Object:  StoredProcedure [dbo].[View_Transaction_All_SpecificPayment]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Transaction_All_SpecificPayment]

@payment_key int

AS
	
	SELECT *
	FROM vw_Transactions_All
	WHERE purpose_type = 1
	AND purpose_object_key = @payment_key

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[View_Transaction_All]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Transaction_All]

AS
	
	SELECT *
	FROM vw_Transactions_All

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Info_Currencies]
	
AS
BEGIN
	
	SELECT *
	FROM vw_currencies
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Banks]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Info_Banks]
	
AS
BEGIN
	SELECT *
	FROM vw_info_banks
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Info_Currencies_Specific]

@Currency_Key int
	
AS
BEGIN
	
	SELECT *
	FROM vw_currencies
	WHERE info_currencies_key = @Currency_Key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Settlement_Specific_ccsettlementid]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Settlement_Specific_ccsettlementid]
	@ccsettlementid varchar(50)
AS
BEGIN
	SELECT *
	FROM vw_CurrencyCloud_Settlements
	WHERE cc_settlementid = @ccsettlementid
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Settlement_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Settlement_Specific]
	@currencycloud_settlement_key bigint
AS
BEGIN
	SELECT *
	FROM vw_CurrencyCloud_Settlements
	WHERE currencycloud_settlement_key = @currencycloud_settlement_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Settlement_bystatus]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_CurrencyCloud_Settlement_bystatus]
	@status int
AS
BEGIN

		SELECT *
		FROM vw_CurrencyCloud_Settlements
		WHERE status = @status

END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Settlement]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_CurrencyCloud_Settlement]
	
AS
BEGIN
	SELECT *
	FROM vw_CurrencyCloud_Settlements
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Currency_Pairings_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Currency_Pairings_Specific]
	@currency1 int,
	@currency2 int
AS
BEGIN
	SELECT *
	FROM vw_currency_pairings
	WHERE @currency1 = currency1
	AND @currency2 = currency2
END
GO
/****** Object:  StoredProcedure [dbo].[View_Currency_Pairings]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Currency_Pairings]
	
AS
BEGIN
	SELECT *
	FROM vw_currency_pairings
	
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Process_Deposit]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Process_Deposit]
	
	@tx_external_key int,
	@purpose_type int,
	@object_key int 
	
AS
BEGIN
			
			--update tx_external with new purpose
		UPDATE Transactions_External
			SET
				purpose_type = @purpose_type,
				purpose_object_key = @object_key,
				tx_external_status = 2,
				last_changed = getdate(),
				date_processed = getdate()	
			WHERE tx_external_key = @tx_external_key

			--forward money to user's account with internal tx
	DECLARE @currency int
	DECLARE @amount money
	DECLARE @payment_object_sender bigint
	DECLARE @payment_object_receiver bigint

	SET @currency = (SELECT currency FROM Transactions_External WHERE tx_external_key = @tx_external_key)
	SET @amount = (SELECT amount FROM Transactions_External WHERE tx_external_key = @tx_external_key)
	SET @payment_object_sender = (SELECT payment_object_receiver FROM Transactions_External WHERE tx_external_key = @tx_external_key)	

		IF @purpose_type = 1 --Payment is purpose then internal payment goes to user's frozen account
			BEGIN
			SET @payment_object_receiver = dbo.fn_Payment_Object_Key(6,@object_key)
			END
		ELSE
			BEGIN			
			SET @payment_object_receiver = dbo.fn_Payment_Object_Key(3,@object_key) --objectkey is same as user key
			END
	

	--Shift money to user's frozen account
	INSERT INTO Transactions_Internal
	(tx_internal_status, currency, amount,purpose_type, purpose_object_key, payment_object_sender, payment_object_receiver, last_changed, date_processed, date_created)
	VALUES
	(2, @currency, @amount, @purpose_type, @object_key, @payment_object_sender, @payment_object_receiver, getdate(),getdate(),getdate())

	--If Payment Change payment status to 3, Bank Transfer Received
	IF @purpose_type = 1 
		BEGIN
			UPDATE Payments SET
				payment_status = 3
			WHERE payments_key = @object_key
		END	

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Convert_Currency]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Convert_Currency]

	@paymentobjectkey bigint,	
	@quotes_key int,
	@ip_address varchar(20),
	@user_key_updated int,
	@paymentkey int
	
AS
BEGIN

DECLARE @sellcurrency int
SET @sellcurrency = (SELECT sell_currency FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @sellamount money
SET @sellamount = (SELECT sell_amount FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @buycurrency int
SET @buycurrency = (SELECT buy_currency FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @buyamount money
SET @buyamount = (SELECT buy_amount FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @treasurykey int
SET @treasurykey = dbo.fn_Treasury_Payment_Object()

--Converts Currency by swapping currencies with Treasury & payment object key
INSERT INTO Transactions_Internal
	(tx_internal_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_internal_description, date_created, purpose_type, purpose_object_key)
	VALUES
	( 2, @sellcurrency, @sellamount, @paymentobjectkey, @treasurykey, getdate(), @ip_address, @user_key_updated, 'currency conversion', getdate(), 1, @paymentkey)

	INSERT INTO Transactions_Internal
	(tx_internal_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_internal_description, date_created, purpose_type, purpose_object_key)
	VALUES
	( 2, @buycurrency, @buyamount, @treasurykey, @paymentobjectkey, getdate(), @ip_address, @user_key_updated, 'currency conversion', getdate(), 1, @paymentkey)
		

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Convert_Currency_CurrencyCloud_SendtoCC]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Convert_Currency_CurrencyCloud_SendtoCC]

	@paymentkey int,
	@ip_address varchar(20),
	@user_key_updated int
		
AS
BEGIN

DECLARE @quotes_key int
SET @quotes_key = (SELECT quote_key_actual FROM Payments WHERE payments_key = @paymentkey)

DECLARE @sellcurrency int
SET @sellcurrency = (SELECT sell_currency FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @sellamount money
SET @sellamount = (SELECT sell_amount FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @buycurrency int
SET @buycurrency = (SELECT buy_currency FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @buyamount money
SET @buyamount = (SELECT buy_amount FROM Quotes WHERE quotes_key = @quotes_key)

DECLARE @currencycloudkey int
SET @currencycloudkey = dbo.fn_CurrencyCloud_Payment_Object()

DECLARE @paymentobjectkey int
SET @paymentobjectkey = dbo.fn_Payment_Object_Key(6,@paymentkey)

--Converts Currency by swapping currencies with Treasury & payment object key
INSERT INTO Transactions_Internal
	(tx_internal_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_internal_description, date_created, purpose_type, purpose_object_key)
	VALUES
	( 2, @sellcurrency, @sellamount, @paymentobjectkey, @currencycloudkey, getdate(), @ip_address, @user_key_updated, 'send to CurrencyCloud', getdate(), 1, @paymentkey)
		

END
GO
/****** Object:  StoredProcedure [dbo].[View_Admin_Deposits]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Admin_Deposits]
	@isprocessed bit
AS
BEGIN

IF @isprocessed = 0 --Still in pending
	BEGIN
		SELECT *,
		proceeds = vw_Transactions_External.amount - dbo.fn_tx_fees_total(vw_Transactions_External.tx_external_key)
		FROM Transactions_External	
		LEFT JOIN vw_Transactions_External
		ON Transactions_External.tx_external_key = vw_Transactions_External.tx_external_key
		WHERE Transactions_External.purpose_type IS NULL 
		AND Transactions_External.tx_external_status = 1
	END
ELSE
	BEGIN
		SELECT *,
		proceeds = vw_Transactions_External.amount - dbo.fn_tx_fees_total(vw_Transactions_External.tx_external_key)
		FROM Transactions_External	
		LEFT JOIN vw_Transactions_External
		ON Transactions_External.tx_external_key = vw_Transactions_External.tx_external_key
		WHERE Transactions_External.purpose_type IS NOT NULL 
		AND Transactions_External.tx_external_status = 2
	END
	
	
END
GO
/****** Object:  View [dbo].[vw_Bank_Accounts_Users]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Bank_Accounts_Users]
AS
SELECT        dbo.Payment_Objects.payment_object_key, dbo.Payment_Objects.payment_object_type, dbo.Payment_Objects.object_account_key, 
                         dbo.Payment_Objects.date_created, dbo.Bank_Accounts.bank_account_key, dbo.Bank_Accounts.user_key, dbo.Bank_Accounts.currency_key, 
                         dbo.Bank_Accounts.organization_key, dbo.Bank_Accounts.bank_account_description, dbo.Bank_Accounts.user_key_updated, dbo.Bank_Accounts.ip_address, 
                         dbo.Bank_Accounts.account_number, dbo.Bank_Accounts.IBAN, dbo.Bank_Accounts.BIC, dbo.Bank_Accounts.ABArouting, dbo.Bank_Accounts.first_name, 
                         dbo.Bank_Accounts.last_name, dbo.Bank_Accounts.business_name, dbo.Bank_Accounts.last_changed, dbo.Bank_Accounts.date_created AS Expr1, 
                         dbo.fn_txt_bank_account_info(dbo.Payment_Objects.payment_object_key) AS bank_account_info,
                             (SELECT        organization_name
                               FROM            dbo.Info_Organizations
                               WHERE        (dbo.Bank_Accounts.organization_key = info_organizations_key)) AS organization_name,
                             (SELECT        country_text
                               FROM            dbo.Info_Country_List
                               WHERE        (dbo.Bank_Accounts.country_key = info_country_key)) AS country_text,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies
                               WHERE        (dbo.Bank_Accounts.currency_key = info_currencies_key)) AS currency_text, dbo.Bank_Accounts.BSB, dbo.Bank_Accounts.SortCode, 
                         dbo.Bank_Accounts.email, dbo.Bank_Accounts.institution_number, dbo.Bank_Accounts.branch_code, dbo.Bank_Accounts.bank_name
FROM            dbo.Bank_Accounts INNER JOIN
                         dbo.Payment_Objects ON dbo.Bank_Accounts.bank_account_key = dbo.Payment_Objects.object_account_key
WHERE        (dbo.Payment_Objects.payment_object_type = 1)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Bank_Accounts"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 387
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Payment_Objects"
            Begin Extent = 
               Top = 6
               Left = 303
               Bottom = 135
               Right = 505
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 24
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Bank_Accounts_Users'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Bank_Accounts_Users'
GO
/****** Object:  View [dbo].[vw_Bank_Accounts_System]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Bank_Accounts_System]
AS
SELECT        dbo.Payment_Objects.payment_object_key, dbo.Payment_Objects.payment_object_type, dbo.Payment_Objects.object_account_key, 
                         dbo.Payment_Objects.date_created, dbo.Bank_Accounts.bank_account_key, dbo.Bank_Accounts.user_key, dbo.Bank_Accounts.currency_key, 
                         dbo.Bank_Accounts.organization_key, dbo.Bank_Accounts.bank_account_description, dbo.Bank_Accounts.user_key_updated, dbo.Bank_Accounts.ip_address, 
                         dbo.Bank_Accounts.account_number, dbo.Bank_Accounts.IBAN, dbo.Bank_Accounts.BIC, dbo.Bank_Accounts.ABArouting, dbo.Bank_Accounts.first_name, 
                         dbo.Bank_Accounts.last_name, dbo.Bank_Accounts.business_name, dbo.Bank_Accounts.last_changed, dbo.Bank_Accounts.date_created AS Expr1, 
                         dbo.fn_txt_bank_account_info(dbo.Payment_Objects.payment_object_key) AS bank_account_info, dbo.Info_Organizations.organization_name, 
                         dbo.Info_Country_List.country_text, dbo.Bank_Accounts.SortCode, dbo.Bank_Accounts.BSB, dbo.Bank_Accounts.email,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies
                               WHERE        (dbo.Bank_Accounts.currency_key = info_currencies_key)) AS currency_text, dbo.Bank_Accounts.institution_number, dbo.Bank_Accounts.branch_code, 
                         dbo.Bank_Accounts.bank_name
FROM            dbo.Bank_Accounts INNER JOIN
                         dbo.Payment_Objects ON dbo.Bank_Accounts.bank_account_key = dbo.Payment_Objects.object_account_key INNER JOIN
                         dbo.Info_Organizations ON dbo.Bank_Accounts.organization_key = dbo.Info_Organizations.info_organizations_key INNER JOIN
                         dbo.Info_Country_List ON dbo.Bank_Accounts.country_key = dbo.Info_Country_List.info_country_key
WHERE        (dbo.Payment_Objects.payment_object_type = 2)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Bank_Accounts"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 396
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Payment_Objects"
            Begin Extent = 
               Top = 6
               Left = 303
               Bottom = 135
               Right = 505
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Info_Organizations"
            Begin Extent = 
               Top = 141
               Left = 535
               Bottom = 270
               Right = 754
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Info_Country_List"
            Begin Extent = 
               Top = 6
               Left = 543
               Bottom = 118
               Right = 722
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Bank_Accounts_System'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Bank_Accounts_System'
GO
/****** Object:  View [dbo].[vw_Bank_Accounts_Bancbox]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Bank_Accounts_Bancbox]
AS
SELECT        dbo.Payment_Objects.payment_object_key, dbo.Payment_Objects.payment_object_type, dbo.Payment_Objects.object_account_key, 
                         dbo.Payment_Objects.date_created, dbo.Bank_Accounts.bank_account_key, dbo.Bank_Accounts.user_key, dbo.Bank_Accounts.currency_key, 
                         dbo.Bank_Accounts.organization_key, dbo.Bank_Accounts.bank_account_description, dbo.Bank_Accounts.user_key_updated, dbo.Bank_Accounts.ip_address, 
                         dbo.Bank_Accounts.account_number, dbo.Bank_Accounts.IBAN, dbo.Bank_Accounts.BIC, dbo.Bank_Accounts.ABArouting, dbo.Bank_Accounts.first_name, 
                         dbo.Bank_Accounts.last_name, dbo.Bank_Accounts.business_name, dbo.Bank_Accounts.last_changed, dbo.Bank_Accounts.date_created AS Expr1, 
                         dbo.fn_txt_bank_account_info(dbo.Payment_Objects.payment_object_key) AS bank_account_info,
                             (SELECT        organization_name
                               FROM            dbo.Info_Organizations
                               WHERE        (dbo.Bank_Accounts.organization_key = info_organizations_key)) AS organization_name,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies
                               WHERE        (dbo.Bank_Accounts.currency_key = info_currencies_key)) AS currency_text,
                             (SELECT        info_currency_name
                               FROM            dbo.Info_Currencies AS Info_Currencies_1
                               WHERE        (dbo.Bank_Accounts.currency_key = info_currencies_key)) AS Expr2, dbo.Bank_Accounts.BSB, dbo.Bank_Accounts.SortCode, 
                         dbo.Bank_Accounts.email, dbo.Bank_Accounts.institution_number, dbo.Bank_Accounts.branch_code, dbo.Bank_Accounts.bank_name,
                             (SELECT        country_text
                               FROM            dbo.Info_Country_List
                               WHERE        (dbo.Bank_Accounts.country_key = info_country_key)) AS country_text
FROM            dbo.Bank_Accounts INNER JOIN
                         dbo.Payment_Objects ON dbo.Bank_Accounts.bank_account_key = dbo.Payment_Objects.object_account_key
WHERE        (dbo.Payment_Objects.payment_object_type = 8)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Bank_Accounts"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 256
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "Payment_Objects"
            Begin Extent = 
               Top = 6
               Left = 303
               Bottom = 135
               Right = 505
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Bank_Accounts_Bancbox'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Bank_Accounts_Bancbox'
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_overall_balance_currencyspecific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_txt_overall_balance_currencyspecific]
	(@currency int)
		
RETURNS nvarchar(100)
AS
	BEGIN

	declare @txtbalance nvarchar(100)	

	--amount of currencies available
	declare @currencycount int
	SET @currencycount = (SELECT count(*) FROM Info_Currencies)

	declare @tempbalance money
	SET @tempbalance = 0

	declare @txtavailable nvarchar(100)
	SET @txtavailable = ''

	declare @txtfrozen nvarchar(100)
	SET @txtfrozen = ''

	
			
			--available
			SET @tempbalance = dbo.fn_Ledger_Overall_System(@currency)
			IF @tempbalance <> 0
				BEGIN
					SET @txtavailable = @txtavailable + RTRIM((SELECT info_currency_symbol FROM Info_Currencies WHERE info_currencies_key = @currency)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
				END
			
		
	IF @txtavailable = ''
		BEGIN
			SET @txtavailable = '0.00,'
		END	

	SET @txtbalance = LEFT(@txtavailable, LEN(RTRIM(@txtavailable)) - 1)


	RETURN @txtbalance
	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Process_Withdrawl_Payment]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Process_Withdrawl_Payment]

	@amount money,		
	@payments_key int,
	@ipaddress nchar(16),
	@user_key_updated int
	
AS
BEGIN
				
			--forward money to user's account with internal tx
	DECLARE @currency int	
	DECLARE @payment_object_sender bigint
	DECLARE @payment_object_receiver bigint
	DECLARE @paymentspaymentobject bigint

	--destination bank account, currency of tx & system bank account
	SET @payment_object_receiver = (SELECT payment_object_receiver FROM Payments WHERE payments_key = @payments_key)	
	SET @currency = (SELECT currency_key FROM vw_Bank_Accounts_Users WHERE payment_object_key = @payment_object_receiver)
	SET @payment_object_sender = dbo.txt_Admin_Bank_Account_CurrencyExchange(@currency,0)		
	SET @paymentspaymentobject = dbo.fn_Payment_Object_Key(6,@payments_key)
			
	--Send money from payment's balance to system account
	INSERT INTO Transactions_Internal
	(tx_internal_status, currency, amount,purpose_type, purpose_object_key, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_internal_description, date_created)
	VALUES
	( 2, @currency, @amount, 1, @payments_key,@paymentspaymentobject, @payment_object_sender , getdate(), @ipaddress, @user_key_updated, 'withdraw money', getdate())

	--Send money from system account to user's external bank account
	INSERT INTO Transactions_External
	(tx_external_status, currency, amount,purpose_type, purpose_object_key, payment_object_sender, payment_object_receiver, last_changed, date_processed, date_created, ip_address, user_key_updated)
	VALUES
	(2, @currency, @amount, 1, @payments_key, @payment_object_sender, @payment_object_receiver, getdate(),getdate(),getdate(), @ipaddress,@user_key_updated)

	--Change payment status to 5, Payment Delivered
	
			UPDATE Payments SET
				payment_status = 5
			WHERE payments_key = @payments_key
		

END
GO
/****** Object:  StoredProcedure [dbo].[View_System_Bank_Accounts]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_System_Bank_Accounts]	

AS
BEGIN
	SELECT *
	FROM vw_Bank_Accounts_System
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Recipients_byuser_andcurrency]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Recipients_byuser_andcurrency]
	@user_key int,
	@currency int
AS
BEGIN
	SELECT *,
	ddltext = first_name + ' ' + last_name + ' - ' + currency_text
	FROM Recipients
	INNER JOIN vw_Bank_Accounts_Users
	ON Recipients.payment_object_key = vw_Bank_Accounts_Users.payment_object_key
	WHERE Recipients.user_key = @user_key
	AND currency_key = @currency
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Recipients_byuser]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Recipients_byuser]
	@user_key int
AS
BEGIN
	SELECT *,
	ddltext = first_name + ' ' + last_name + ' - ' + currency_text
	FROM Recipients
	INNER JOIN vw_Bank_Accounts_Users
	ON Recipients.payment_object_key = vw_Bank_Accounts_Users.payment_object_key
	WHERE Recipients.user_key = @user_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_Users]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Bank_Accounts_Users]	

AS
BEGIN
	
	SELECT *
	FROM vw_Bank_Accounts_Users
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_Specific_paymentkey]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Bank_Accounts_Specific_paymentkey]	
	@paymentkey bigint
AS
BEGIN

IF (SELECT Count(*) FROM vw_Bank_Accounts_Users WHERE payment_object_key = @paymentkey) > 0 
	BEGIN
		SELECT *
		FROM vw_Bank_Accounts_Users	
		WHERE payment_object_key = @paymentkey
	END	
ELSE IF (SELECT Count(*) FROM vw_Bank_Accounts_Bancbox WHERE payment_object_key = @paymentkey) > 0 
	BEGIN
		SELECT *
		FROM vw_Bank_Accounts_Bancbox
		WHERE payment_object_key = @paymentkey
	END
ELSE
	BEGIN
		SELECT *
		FROM vw_Bank_Accounts_System	
		WHERE payment_object_key = @paymentkey
	END		

END
GO
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Bank_Accounts_Specific]	
	@bankaccountkey int
AS
BEGIN

IF (SELECT Count(*) FROM vw_Bank_Accounts_Users WHERE bank_account_key = @bankaccountkey) > 0 
	BEGIN
		SELECT *
		FROM vw_Bank_Accounts_Users	
		WHERE bank_account_key = @bankaccountkey
	END	
ELSE
	BEGIN
		SELECT *
		FROM vw_Bank_Accounts_System	
		WHERE bank_account_key = @bankaccountkey	
	END		
END
GO
/****** Object:  StoredProcedure [dbo].[View_BancBox_Accounts]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_BancBox_Accounts]
	
AS
BEGIN
	SELECT *
	FROM vw_Bank_Accounts_Bancbox
	WHERE account_number is not null
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Payment_Object_Key_BancBox]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Payment_Object_Key_BancBox]
	(@user_key int)
RETURNS bigint
AS
	BEGIN
	
	DECLARE @bancboxpaymentobject bigint
	SELECT @bancboxpaymentobject = (SELECT        TOP (1) payment_object_key
                               FROM            dbo.vw_Bank_Accounts_Bancbox
                               WHERE        (@user_key = user_key))
	
	
	RETURN @bancboxpaymentobject
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Ledger_Payment_Objects]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Ledger_Payment_Objects]
	(@payment_object_key bigint,
	@currency int)
RETURNS money
AS
	BEGIN
	declare @Balancefull money
	declare @Balancesendexternal money
	declare @Balancereceiveexternal money
	declare @Balancesendinternal money
	declare @Balancereceiveinternal money

	--tx external money being sent from payment object
	SELECT @Balancesendexternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_sender = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_sender = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2
					)
					END

	--tx external money being given to payment object
					SELECT @Balancereceiveexternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_receiver = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE payment_object_receiver = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_external_status = 2
					)
					END

--tx internal money being sent from payment object
	SELECT @Balancesendinternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_Internal
						WHERE payment_object_sender = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_internal_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_Internal
						WHERE payment_object_sender = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_internal_status = 2
					)
					END

	--tx internal money being given to payment object
					SELECT @Balancereceiveinternal = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_Internal
						WHERE payment_object_receiver = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_internal_status = 2)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_Internal
						WHERE payment_object_receiver = @payment_object_key
						AND currency = @currency
						AND amount > 0
						AND tx_internal_status = 2
					)
					END

	SET @Balancefull = @Balancereceiveexternal - @Balancesendexternal + @Balancereceiveinternal - @Balancesendinternal

	--BancBox account is considered part of user Balance
	IF (dbo.fn_Payment_Object_Type(@payment_object_key) = 3) AND (@currency = 3)
		BEGIN
			declare @paymentobjectkey_available_bancbox bigint
			SET @paymentobjectkey_available_bancbox = dbo.fn_Payment_Object_Key_BancBox(dbo.fn_Payment_Object_Account_Key(@payment_object_key))
			IF @paymentobjectkey_available_bancbox IS NOT NULL
				BEGIN
					SET @Balancefull += dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available_bancbox,3)
				END			
		END	

	RETURN @Balancefull
	END
GO
/****** Object:  View [dbo].[vw_Users_Info]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Users_Info]
AS
SELECT        dbo.Users.user_key, dbo.Users.account_number, dbo.Users.title, dbo.Users.first_name, dbo.Users.middle_name, dbo.Users.last_name, dbo.Users.dob, 
                         dbo.Users.country_residence, dbo.Users.email, dbo.Users.ip_address, dbo.Users.last_changed, dbo.Users.signed_up, dbo.Users.user_status, 
                         dbo.Users.user_type, dbo.Users_Info.address1, dbo.Users_Info.address2, dbo.Users_Info.city, dbo.Users_Info.state, dbo.Users_Info.country, 
                         dbo.Users_Info.postalcode, dbo.Users_Info.phonecountrycode1, dbo.Users_Info.phonetype1, dbo.Users_Info.phonenumber1, dbo.Users_Info.phonecountrycode2, 
                         dbo.Users_Info.phonetype2, dbo.Users_Info.phonenumber2, dbo.Users_Info.identitynationality, dbo.Users_Info.occupation, dbo.Users_Info.passportnumber, 
                         dbo.Users_Info.username, dbo.Users_Info.password, dbo.Users.first_name + ' ' + dbo.Users.last_name + ' - ' + dbo.Users.account_number AS user_info_full,
                             (SELECT        status_description
                               FROM            dbo.User_Statuses
                               WHERE        (user_status_key = dbo.Users.user_status)) AS user_status_text, CASE Users.user_type WHEN 2 THEN 'True' ELSE NULL END AS isadmin,
                             (SELECT        client_id
                               FROM            dbo.Users_Bancbox
                               WHERE        (user_key = dbo.Users.user_key)) AS bancbox_client_id,
                             (SELECT        client_status
                               FROM            dbo.Users_Bancbox AS Users_Bancbox_2
                               WHERE        (user_key = dbo.Users.user_key)) AS bancbox_client_status,
                             (SELECT        cip_status
                               FROM            dbo.Users_Bancbox AS Users_Bancbox_1
                               WHERE        (user_key = dbo.Users.user_key)) AS bancbox_cip_status, dbo.fn_Payment_Object_Key_BancBox(dbo.Users.user_key) 
                         AS bancbox_payment_object_key, dbo.Users_Info.ssn, dbo.Users_Info.Image_URL, dbo.fn_user_verification_points(dbo.Users.user_key) AS verification_points, 
                         dbo.Users.last_online, dbo.Users_Info.default_currency,
                             (SELECT        info_timezone_id
                               FROM            dbo.Info_Timezones
                               WHERE        (info_timezone_key = dbo.Users_Info.timezone)) AS timezoneid, dbo.Users_Info.timezone, dbo.Users_Info.referral
FROM            dbo.Users INNER JOIN
                         dbo.Users_Info ON dbo.Users.user_key = dbo.Users_Info.user_key
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 324
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users_Info"
            Begin Extent = 
               Top = 6
               Left = 257
               Bottom = 497
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 39
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Users_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Users_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Users_Info'
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Admin]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Admin]	

AS
BEGIN
	SELECT *
	FROM vw_Users_Info
	WHERE isadmin = 1
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_user_balance]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_txt_user_balance]
	(@user_key int)
		
RETURNS nvarchar(100)
AS
	BEGIN

	declare @txtbalance nvarchar(100)
	
	--payment object key for available account
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(3,@user_key)

	--payment object key for available bancbox account
	declare @paymentobjectkey_available_bancbox bigint
	SET @paymentobjectkey_available_bancbox = dbo.fn_Payment_Object_Key_BancBox(@user_key)

	--payment object key for frozen account
	declare @paymentobjectkey_frozen bigint
	SET @paymentobjectkey_frozen = dbo.fn_Payment_Object_key(4,@user_key)

	--amount of currencies available
	declare @currencycount int
	SET @currencycount = (SELECT count(*) FROM Info_Currencies)

	declare @i int
	SET @i = 1

	declare @tempbalance money
	SET @tempbalance = 0

	declare @txtavailable nvarchar(100)
	SET @txtavailable = ''

	declare @txtfrozen nvarchar(100)
	SET @txtfrozen = ''

	WHILE (@i <= @currencycount)
		BEGIN
			
			--available
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@i)
			IF @tempbalance <> 0
				BEGIN
					SET @txtavailable = @txtavailable + RTRIM(dbo.fn_txt_currency_symbol(@i)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ' '  + dbo.fn_txt_currency_code(@i) + ', '
				END

			--frozen
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_frozen,@i)
			IF @tempbalance <> 0
				BEGIN
					SET @txtfrozen = @txtfrozen + RTRIM(dbo.fn_txt_currency_symbol(@i)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ' '  + dbo.fn_txt_currency_code(@i) + ', '
				END

			SET @i = @i + 1
		END
		
	IF @txtavailable = ''
		BEGIN
			SET @txtavailable = '0.00,'
		END	

	SET @txtbalance = LEFT(@txtavailable, LEN(RTRIM(@txtavailable)) - 1)

	IF @txtfrozen <> ''
		BEGIN
			SET @txtbalance = @txtbalance + ', Frozen - ' + LEFT(@txtfrozen, LEN(RTRIM(@txtfrozen)) - 1)
		END

	RETURN @txtbalance
	END
GO
/****** Object:  StoredProcedure [dbo].[View_Possible_Funding_Sources]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Possible_Funding_Sources]
	@user_key int,
	@currency int,
	@amount money
AS
BEGIN
	
	--Get users payment object key for balance
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(3,@user_key)
	
	SELECT 
	info_currency_description,
	payment_object_key = @paymentobjectkey_available,
	user_balance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency),
	user_balance_text = info_currency_code + ' Balance = ' + dbo.fn_txt_currency_symbol(@currency) + ' ' + CONVERT(varchar(10), dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency))
	FROM Info_Currencies
	WHERE 
	info_currencies_key = @currency
	AND dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency) >= @amount
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_User_Balance_Specific_Currency]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_User_Balance_Specific_Currency]	
	@user_key int,
	@currency int
AS
BEGIN

	--Get users payment object key for balance
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(3,@user_key)
	
	SELECT 
	info_currency_description,
	payment_object_key = @paymentobjectkey_available,
	user_balance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency),
	user_balance_text = 'My ' + info_currency_code + ' Balance = ' + dbo.fn_txt_currency_symbol(@currency) + ' ' + CONVERT(varchar(10), dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency))
	FROM Info_Currencies
	WHERE 
	info_currencies_key = @currency
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Treasury_Account]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Treasury_Account]
	@treasury_type int
AS

DECLARE @user_key int
SET @user_key = (SELECT user_key FROM Treasury_Type WHERE treasury_type_key = @treasury_type) -- Treasury key

	
	SELECT *
	FROM vw_Users_Info
	WHERE user_key = @user_key


	RETURN
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Login]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Users_Login]	
	@Email nvarchar(100),
	@password nvarchar(50)
AS
BEGIN
	
	SELECT *	
	FROM vw_Users_Info
	WHERE @Email = Email
	AND @password = password
	ORDER BY user_key ASC
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Info_UserBalance_Paymentobjectkey]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Info_UserBalance_Paymentobjectkey]
	@payment_object_key bigint

AS
BEGIN

	DECLARE @user_key int
	SET @user_key = (SELECT object_account_key FROM Payment_Objects WHERE payment_object_key = @payment_object_key)

	SELECT *
	FROM vw_Users_Info
	WHERE user_key = @user_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Info]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Info]
	@user_key int

AS
BEGIN
	SELECT *
	FROM vw_Users_Info
	WHERE user_key = @user_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Email]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Email]	
	@Email nvarchar(100)
AS
BEGIN
	
	SELECT *	
	FROM vw_Users_Info
	WHERE @Email = Email
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_DropDown]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Users_DropDown]
	@text nvarchar(20)
AS
BEGIN
	
	SELECT *,
	user_dropdown_text = email + ' (' + first_name + ' ' + last_name + ')',
	payment_object_key = dbo.fn_Payment_Object_Key(3,user_key)
	FROM vw_Users_Info
	WHERE user_info_full LIKE '%'+@text+'%'	
	OR email LIKE '%'+@text+'%'
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Has_BancBox]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_Has_BancBox]
	(@user_key int)
RETURNS bit
AS
	BEGIN
	DECLARE @hasbancbox bit
	DECLARE @bancboxpaymentobject bigint
	SELECT @bancboxpaymentobject = (SELECT bancbox_payment_object_key FROM vw_Users_Info WHERE @user_key = user_key)
	
	IF @bancboxpaymentobject IS NOT NULL
		BEGIN
			SET @hasbancbox = 1
		END
	ELSE
		BEGIN
			SET @hasbancbox = 0
		END

	RETURN @hasbancbox
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_user_paymentpending_specificcurrency]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_user_paymentpending_specificcurrency]
	(@user_key int,
	@currency int)
RETURNS money
AS
	BEGIN
	
	declare @tempbalance money
	SET @tempbalance = 0

	SET @tempbalance = (SELECT SUM( dbo.fn_Ledger_Payment_Objects(dbo.fn_Payment_Object_key(6,Payments.payments_key),@currency)) FROM Payments WHERE requestor_user_key = @user_key
				AND dbo.fn_Payment_Object_key(6,Payments.payments_key) is not null)

	--take into account funds sitting with currencycloud
	DECLARE @ccpaymentobjectkey bigint
	SET @ccpaymentobjectkey = dbo.fn_CurrencyCloud_Payment_Object()
	SET @tempbalance = @tempbalance + dbo.fn_Ledger_Payment_Objects(@ccpaymentobjectkey,@currency)

	RETURN @tempbalance
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_user_net_balance_onecurrency]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_user_net_balance_onecurrency]
	(@user_key int,
	@returncurrency int,
	@paymentobjecttype int) --balance type, 3 = user balance, 4 = frozen balance, 6 = payment
RETURNS money
AS
	BEGIN
	
	--payment object key for available account
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(@paymentobjecttype,@user_key)
	
	declare @tempbalance money
	SET @tempbalance = 0

	declare @netbalance money
	SET @netbalance = 0
	
	--amount of currencies available
	declare @currencycount int
	SET @currencycount = (SELECT count(*) FROM Info_Currencies)

	declare @rate decimal(10,4)
	SET @rate = 0

	declare @i int
	SET @i = 1

	WHILE (@i <= @currencycount)
	BEGIN	
		IF (@i = @returncurrency)
			BEGIN
			--no need to find exchange rate
			IF (@paymentobjecttype = 6) --payment pending
				BEGIN
					SET @tempbalance = dbo.fn_user_paymentpending_specificcurrency(@user_key,@i)
				END
			ELSE --user balance or frozen balance
				BEGIN 
					SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@i)			
				END			
			END	
		ELSE 
			BEGIN
			SET @rate = (SELECT Top 1 Exchange_Rate FROM Info_Fee_Types WHERE currency1 = @i AND currency2 = @returncurrency)

			IF (@paymentobjecttype = 6)--payment pending
				BEGIN
					SET @tempbalance = (@rate * dbo.fn_user_paymentpending_specificcurrency(@user_key,@i))
				END
			ELSE --user balance or frozen balance
				BEGIN 
				SET @tempbalance = (@rate * dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@i))
				END
			END

		SET @netbalance += @tempbalance
		SET @i = @i + 1
	END
	
	return @netbalance

	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_user_balance_currencyspecific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_txt_user_balance_currencyspecific]
	(@user_key int,
	@currency int)
		
RETURNS nvarchar(100)
AS
	BEGIN

	declare @txtbalance nvarchar(100)
	
	--payment object key for available account
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(3,@user_key)

	--payment object key for available bancbox account
	declare @paymentobjectkey_available_bancbox bigint
	SET @paymentobjectkey_available_bancbox = dbo.fn_Payment_Object_Key_BancBox(@user_key)

	--payment object key for frozen account
	declare @paymentobjectkey_frozen bigint
	SET @paymentobjectkey_frozen = dbo.fn_Payment_Object_key(4,@user_key)

	--payment object key for payments related to user
	declare @paymentobjectkey_payment bigint	

	--amount of currencies available
	declare @currencycount int
	SET @currencycount = (SELECT count(*) FROM Info_Currencies)

	declare @tempbalance money
	SET @tempbalance = 0

	declare @txtavailable nvarchar(100)
	SET @txtavailable = ''

	declare @txtfrozen nvarchar(100)
	SET @txtfrozen = ''

	declare @txtpayment nvarchar(100)
	SET @txtpayment = ''
	
			
			--available
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency)
			IF @tempbalance <> 0
				BEGIN
					SET @txtavailable = @txtavailable + RTRIM(dbo.fn_txt_currency_symbol(@currency)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
				END

			--frozen
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_frozen,@currency)
			IF @tempbalance <> 0
				BEGIN
					SET @txtfrozen = @txtfrozen + RTRIM(dbo.fn_txt_currency_symbol(@currency)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
				END

			--payment
			SET @tempbalance = dbo.fn_user_paymentpending_specificcurrency(@user_key,@currency)
			IF @tempbalance <> 0
				BEGIN
					SET @txtpayment = @txtpayment + RTRIM(dbo.fn_txt_currency_symbol(@currency)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '					
				END

	IF @txtavailable = ''
		BEGIN
			SET @txtavailable = RTRIM(dbo.fn_txt_currency_symbol(@currency)) + ' ' + '0.00,'
		END	

	SET @txtbalance = LEFT(@txtavailable, LEN(RTRIM(@txtavailable)) - 1)

	IF @txtfrozen <> ''
		BEGIN
			SET @txtbalance = @txtbalance + '<br/> Frozen =' + LEFT(@txtfrozen, LEN(RTRIM(@txtfrozen)) - 1)
		END

	IF @txtpayment <> ''
		BEGIN			
			SET @txtbalance = @txtbalance + '<br/> Pending Transaction = ' + LEFT(@txtpayment, LEN(RTRIM(@txtpayment)) - 1)			
		END

	RETURN @txtbalance
	END
GO
/****** Object:  StoredProcedure [dbo].[testusernetbalance]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[testusernetbalance]
(@user_key int,
	@returncurrency int,
	@paymentobjecttype int) --balance type, 3 = user balance, 4 = frozen balance, 6 = payment
AS
	
	--payment object key for available account
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(@paymentobjecttype,@user_key)
	
	declare @tempbalance money
	SET @tempbalance = 0

	declare @netbalance money
	SET @netbalance = 0
	
	--amount of currencies available
	declare @currencycount int
	SET @currencycount = (SELECT count(*) FROM Info_Currencies)

	declare @rate decimal(10,4)
	SET @rate = 0

	declare @i int
	SET @i = 1

	WHILE (@i <= @currencycount)
	BEGIN	
		IF (@i = @returncurrency)
			BEGIN
			--no need to find exchange rate
			IF (@paymentobjecttype = 6) --payment pending
				BEGIN
					SET @tempbalance = dbo.fn_user_paymentpending_specificcurrency(@user_key,@i)
				END
			ELSE --user balance or frozen balance
				BEGIN 
					SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@i)			
				END			
			END	
		ELSE 
			BEGIN
			SET @rate = (SELECT Top 1 Exchange_Rate FROM Info_Fee_Types WHERE currency1 = @i AND currency2 = @returncurrency)

			IF (@paymentobjecttype = 6)--payment pending
				BEGIN
					SET @tempbalance = (@rate * dbo.fn_user_paymentpending_specificcurrency(@user_key,@i))
				END
			ELSE --user balance or frozen balance
				BEGIN 
				SET @tempbalance = (@rate * dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@i))
				END
			END

		SET @netbalance += @tempbalance
		print 'i=' + convert(varchar(1), @i) + ' & tempbalance=' + convert(varchar(10), @tempbalance) + ' & netbalance=' + convert(varchar(10),@netbalance)
		SET @i = @i + 1
	END


	RETURN
GO
/****** Object:  View [dbo].[vw_Payments]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Payments]
AS
SELECT        dbo.Payments.payments_key, dbo.Payments.quote_key, dbo.Payments.payment_status, dbo.Payments.date_created, dbo.Payments.requestor_user_key, 
                         dbo.Payments.payment_object_sender, dbo.Payments.payment_object_receiver, dbo.Payments.payment_description, Quotes_1.sell_amount, 
                         Quotes_1.sell_currency, Quotes_1.buy_amount, Quotes_1.buy_currency, Quotes_1.rate, Quotes_1.service_fee, Quotes_1.promised_delivery_date, 
                         Quotes_1.actual_delivery_date,
                             (SELECT        first_name + ' ' + last_name AS Expr1
                               FROM            dbo.vw_Bank_Accounts_Users
                               WHERE        (payment_object_key = dbo.Payments.payment_object_receiver)) AS receiver_name,
                             (SELECT        first_name + ' ' + last_name AS Expr1
                               FROM            dbo.Users
                               WHERE        (user_key = dbo.Payments.requestor_user_key)) AS sender_name,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies
                               WHERE        (Quotes_1.sell_currency = info_currencies_key)) AS sell_currency_text,
                             (SELECT        info_currency_code
                               FROM            dbo.Info_Currencies AS Info_Currencies_1
                               WHERE        (Quotes_1.buy_currency = info_currencies_key)) AS buy_currency_text,
                             (SELECT        payment_status_description
                               FROM            dbo.Payment_Status AS Payment_Status_1
                               WHERE        (payment_status_key = dbo.Payments.payment_status)) AS payment_status_text, 
                         CASE WHEN (dbo.fn_payment_object_isexternal(Payments.payment_object_sender) = 0) AND 
                         (dbo.fn_payment_object_isexternal(Payments.payment_object_receiver) = 0) THEN 1 ELSE 0 END AS internal_only, 
                         CASE WHEN (dbo.fn_payment_object_requiresmanualexport(Payments.payment_object_receiver) = 1) AND ((buy_currency <> 3) OR
                         (dbo.fn_Has_BancBox(Payments.requestor_user_key) = 0)) THEN 1 ELSE 0 END AS requiresmanualexport, 
                         dbo.fn_Payment_Object_Type(dbo.Payments.payment_object_receiver) AS payment_object_receiver_type, dbo.fn_txt_currency_symbol(Quotes_1.sell_currency) 
                         + ' ' + CONVERT(nvarchar(10), ROUND(Quotes_1.sell_amount, 2)) + ' ' + dbo.fn_txt_currency_code(Quotes_1.sell_currency) AS txt_Sell_full, 
                         dbo.fn_txt_currency_symbol(Quotes_1.buy_currency) + ' ' + CONVERT(nvarchar(10), ROUND(Quotes_1.buy_amount, 2)) 
                         + ' ' + dbo.fn_txt_currency_code(Quotes_1.buy_currency) AS txt_Buy_full,
                             (SELECT        rate
                               FROM            dbo.Quotes
                               WHERE        (quotes_key = dbo.Payments.quote_key_actual)) AS actual_rate, dbo.fn_txt_currency_symbol(Quotes_1.sell_currency) + ' ' + CONVERT(nvarchar(10), 
                         ROUND
                             ((SELECT        sell_amount
                                 FROM            dbo.Quotes AS Quotes_4
                                 WHERE        (quotes_key = dbo.Payments.quote_key_actual)), 2)) + ' ' + dbo.fn_txt_currency_code(Quotes_1.sell_currency) AS actual_txt_Sell_full, 
                         dbo.fn_txt_currency_symbol(Quotes_1.buy_currency) + ' ' + CONVERT(nvarchar(10), ROUND
                             ((SELECT        buy_amount
                                 FROM            dbo.Quotes AS Quotes_3
                                 WHERE        (quotes_key = dbo.Payments.quote_key_actual)), 2)) + ' ' + dbo.fn_txt_currency_code(Quotes_1.buy_currency) AS actual_txt_Buy_full,
                             (SELECT        service_fee
                               FROM            dbo.Quotes AS Quotes_2
                               WHERE        (quotes_key = dbo.Payments.quote_key_actual)) AS actual_service_fee, dbo.Payments.quote_key_actual, dbo.Payments.treasury_type, 
                         CASE WHEN (dbo.fn_Payment_Object_Type(dbo.Payments.payment_object_receiver) = 1) AND
                             (SELECT        TOP 1 Treasury_Type
                               FROM            Info_Fee_Types
                               WHERE        currency1 = Quotes_1.sell_currency AND currency2 = Quotes_1.buy_currency) <> 1 THEN 1 ELSE 0 END AS directlyfromcurrencycloud,
                             (SELECT        TOP (1) cc_tradeid
                               FROM            dbo.CurrencyCloud_Trades
                               WHERE        (payments_key = dbo.Payments.payments_key)) AS cc_tradeid,
                             (SELECT        TOP (1) cc_paymentid
                               FROM            dbo.CurrencyCloud_Trades AS CurrencyCloud_Trades_1
                               WHERE        (payments_key = dbo.Payments.payments_key)) AS cc_paymentid
FROM            dbo.Payments INNER JOIN
                         dbo.Quotes AS Quotes_1 ON dbo.Payments.quote_key = Quotes_1.quotes_key
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[13] 2[27] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Payments"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 299
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Quotes_1"
            Begin Extent = 
               Top = 6
               Left = 296
               Bottom = 264
               Right = 509
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 34
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2160
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Payments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Payments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Payments'
GO
/****** Object:  StoredProcedure [dbo].[View_Users_All]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Users_All]	

AS
BEGIN
	
	SELECT *,
	user_balance = dbo.fn_txt_user_balance(user_key)
	FROM vw_Users_Info
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_User_NetBalance]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_User_NetBalance]
	@userkey int,
	@currency int
AS
BEGIN
	
	SELECT *,
		userbalance = dbo.fn_user_net_balance_onecurrency(@userkey,@currency,3),
		userbalancefrozen = dbo.fn_user_net_balance_onecurrency(@userkey,@currency,4),
		userpaymentpending = dbo.fn_user_net_balance_onecurrency(@userkey,@currency,6)
	FROM Users
	WHERE @userkey = user_key	
END
GO
/****** Object:  View [dbo].[vw_CurrencyCloud_Trades_Errors]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_CurrencyCloud_Trades_Errors]
AS
SELECT        dbo.CurrencyCloud_Trades_Errors.request, dbo.CurrencyCloud_Trades_Errors.response, dbo.CurrencyCloud_Trades_Errors.dateoccured, dbo.vw_Payments.*
FROM            dbo.CurrencyCloud_Trades_Errors INNER JOIN
                         dbo.vw_Payments ON dbo.CurrencyCloud_Trades_Errors.payments_key = dbo.vw_Payments.payments_key
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CurrencyCloud_Trades_Errors"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vw_Payments"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CurrencyCloud_Trades_Errors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CurrencyCloud_Trades_Errors'
GO
/****** Object:  View [dbo].[vw_CurrencyCloud_Trades]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_CurrencyCloud_Trades]
AS
SELECT        dbo.CurrencyCloud_Trades.currencycloud_trade_key, dbo.CurrencyCloud_Trades.settlement_key, dbo.CurrencyCloud_Trades.initiated_date, 
                         dbo.CurrencyCloud_Trades.cc_tradeid, dbo.CurrencyCloud_Trades.settlement_date, dbo.CurrencyCloud_Trades.fundsreceived_date, 
                         dbo.CurrencyCloud_Trades.withdrawlsent_date, vw_Payments_1.payments_key, vw_Payments_1.quote_key, vw_Payments_1.payment_status, 
                         vw_Payments_1.date_created, vw_Payments_1.requestor_user_key, vw_Payments_1.payment_object_sender, vw_Payments_1.payment_object_receiver, 
                         vw_Payments_1.payment_description, vw_Payments_1.sell_amount, vw_Payments_1.sell_currency, vw_Payments_1.buy_amount, vw_Payments_1.buy_currency, 
                         vw_Payments_1.rate, vw_Payments_1.service_fee, vw_Payments_1.promised_delivery_date, vw_Payments_1.actual_delivery_date, 
                         vw_Payments_1.receiver_name, vw_Payments_1.sender_name, vw_Payments_1.sell_currency_text, vw_Payments_1.buy_currency_text, 
                         vw_Payments_1.payment_status_text, vw_Payments_1.internal_only, vw_Payments_1.requiresmanualexport, vw_Payments_1.payment_object_receiver_type, 
                         vw_Payments_1.txt_Sell_full, vw_Payments_1.txt_Buy_full, vw_Payments_1.actual_rate, vw_Payments_1.actual_txt_Sell_full, vw_Payments_1.actual_txt_Buy_full, 
                         vw_Payments_1.actual_service_fee, vw_Payments_1.quote_key_actual, vw_Payments_1.treasury_type, vw_Payments_1.directlyfromcurrencycloud,
                             (SELECT        currencycloud_cutoff
                               FROM            dbo.Info_Currencies
                               WHERE        (info_currencies_key = vw_Payments_1.buy_currency)) AS cc_cutoff, dbo.CurrencyCloud_Trades.cc_paymentid, 
                         CASE WHEN (initiated_date IS NOT NULL AND dbo.fn_CurrencyCloud_Trade_Releasedate(settlement_key) IS NOT NULL AND withdrawlsent_date IS NULL AND 
                         fundsreceived_date IS NULL) THEN 2 WHEN (initiated_date IS NOT NULL AND dbo.fn_CurrencyCloud_Trade_Releasedate(settlement_key) IS NOT NULL AND 
                         withdrawlsent_date IS NOT NULL AND fundsreceived_date IS NULL) THEN 3 WHEN (initiated_date IS NOT NULL AND 
                         dbo.fn_CurrencyCloud_Trade_Releasedate(settlement_key) IS NOT NULL AND withdrawlsent_date IS NOT NULL AND fundsreceived_date IS NOT NULL) 
                         THEN 4 ELSE 1 END AS cctrade_status
FROM            dbo.CurrencyCloud_Trades INNER JOIN
                         dbo.vw_Payments AS vw_Payments_1 ON dbo.CurrencyCloud_Trades.payments_key = vw_Payments_1.payments_key
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CurrencyCloud_Trades"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 240
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vw_Payments_1"
            Begin Extent = 
               Top = 6
               Left = 296
               Bottom = 135
               Right = 544
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CurrencyCloud_Trades'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CurrencyCloud_Trades'
GO
/****** Object:  StoredProcedure [dbo].[View_User_Currency_List_Treasury]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_User_Currency_List_Treasury]
	
AS
BEGIN
	
	DECLARE @user_key int
	SET @user_key = (SELECT TOP 1 user_key FROM Users WHERE user_type = 3) -- First treasury entry

	SELECT 
	info_currency_description,
	user_balance = dbo.fn_txt_user_balance_currencyspecific(@user_key,info_currencies_key),
	overall_balance = dbo.fn_txt_overall_balance_currencyspecific(info_currencies_key),
	system_account_info_text = CASE WHEN dbo.fn_system_account_specific_currency(info_currencies_key,0) IS NOT NULL
								THEN dbo.fn_txt_bank_account_info(dbo.fn_system_account_specific_currency(info_currencies_key,0)) + ' = ' + dbo.fn_txt_currency_symbol(info_currencies_key) + ' ' + CONVERT(varchar, dbo.fn_Ledger_Payment_Objects_External_Transactions_Only(dbo.fn_system_account_specific_currency(info_currencies_key,0),info_currencies_key))
								ELSE ''
								END
	FROM Info_Currencies
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_User_Currency_List]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_User_Currency_List]	
	@user_key int
AS
BEGIN
	
	SELECT 
	info_currency_description,
	user_balance = dbo.fn_txt_user_balance_currencyspecific(@user_key,info_currencies_key)
	FROM Info_Currencies
	WHERE 
	info_currency_canhold = 1
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_User_Currencies_hasBalancein]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_User_Currencies_hasBalancein]	
	@user_key int
AS
BEGIN
	
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(3,@user_key)

	

	SELECT 
	info_currencies_key,
	info_currency_description,
	user_balance = dbo.fn_txt_user_balance_currencyspecific(@user_key,info_currencies_key),
	user_balance_text = info_currency_code + ' (' + CONVERT(nvarchar(30), dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,info_currencies_key)) + ')',
	user_balance_money = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,info_currencies_key)
	FROM Info_Currencies
	WHERE 	
	dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,info_currencies_key) > 0
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Specific_byembeetransid]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payment_Specific_byembeetransid]
	@transid int
AS
BEGIN
	
	DECLARE @embeeobjectkey int
	SET @embeeobjectkey = (SELECT embee_object_key FROM Embee_Objects WHERE transid = @transid)

	SELECT *
	FROM vw_Payments
	WHERE payment_object_receiver = dbo.fn_Payment_Object_key(7,@embeeobjectkey)
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Specific_byembeeobjectkey]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payment_Specific_byembeeobjectkey]
	@embee_object_key int
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE payment_object_receiver = @embee_object_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payment_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payment_Specific]
	@paymentkey int
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE @paymentkey = payments_key
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_Requestedbyuser]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payments_Requestedbyuser]
	@user_key int
AS
BEGIN
	
	SELECT *,
	payments_info = '#' + convert(varchar,payments_key) + ' - ' + payment_description,
	payment_status_info = (SELECT payment_status_description FROM Payment_Status WHERE payment_status_key = payment_status),
	txt_withdrawl = CASE WHEN requestor_user_key = @user_key 
					THEN (CASE WHEN actual_txt_Sell_full is not null
							THEN actual_txt_Sell_full
							ELSE txt_Sell_full
							END)
					ELSE ''
					END,
	txt_deposit = CASE WHEN payment_object_receiver = dbo.fn_Payment_Object_Key(3,@user_key)
							OR payment_object_receiver = dbo.fn_Payment_Object_Key(4,@user_key) 
					THEN (CASE WHEN actual_txt_Buy_full is not null
							THEN actual_txt_Buy_full
							ELSE txt_Buy_full
							END)
					ELSE ''
					END,
	sender_payment_type = CASE WHEN dbo.fn_Payment_Object_Type(payment_object_sender) = 1
						THEN 'Bank Account'
						WHEN dbo.fn_Payment_Object_Type(payment_object_sender) = 3
						THEN 'User Balance'
						WHEN dbo.fn_Payment_Object_Type(payment_object_sender) = 7
						THEN 'Top Up'
						END,
	receiver_payment_type = CASE WHEN payment_object_receiver_type = 1
						THEN 'Bank Account'
						WHEN payment_object_receiver_type = 3
						THEN 'User Balance'
						WHEN payment_object_receiver_type = 7
						THEN 'Top Up'
						END
	FROM vw_Payments
	WHERE requestor_user_key = @user_key
	OR payment_object_receiver = dbo.fn_Payment_Object_Key(3,@user_key)
	OR payment_object_receiver = dbo.fn_Payment_Object_Key(4,@user_key)
	ORDER BY date_created DESC
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_Processed_Withdrawls]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_Processed_Withdrawls]
	
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE directlyfromcurrencycloud = 0
	AND payment_status = 5
	AND requiresmanualexport = 1

END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_InternalOnly]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_InternalOnly]
	
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE internal_only = 1
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_DoNot_requiremanualexport]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_DoNot_requiremanualexport]
	
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE requiresmanualexport = 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_Confirmed]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payments_Confirmed]
	
AS
BEGIN
	
	SELECT *,
	payments_info = '#' + convert(varchar,payments_key) + ' - ' + dbo.fn_txt_currency_symbol(sell_currency) + CONVERT(varchar, sell_amount) + dbo.fn_txt_currency_code(sell_currency) + ' - ' + payment_description
	FROM vw_Payments
	WHERE payment_status = 2 --payment confirmed, awaiting receipt of funds in system bank

END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_byStatus_requiresmanualexport]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_byStatus_requiresmanualexport]
	@status_key int
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE payment_status = @status_key
	AND requiresmanualexport = 1
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_byStatus_Externalobjects]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_byStatus_Externalobjects]
	@status_key int
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE payment_status = @status_key
	AND internal_only = 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_byStatus]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_byStatus]
	@status_key int
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	WHERE payment_status = @status_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments]
	
AS
BEGIN
	
	SELECT *
	FROM vw_Payments
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_Specific]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Trades_Specific]
	@currencycloud_trade_key bigint
AS
BEGIN
	SELECT *
	FROM vw_CurrencyCloud_Trades
	WHERE currencycloud_trade_key = @currencycloud_trade_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_Errors]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_CurrencyCloud_Trades_Errors]
	
AS
BEGIN

	SELECT *
	
	FROM vw_CurrencyCloud_Trades_Errors	
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_bysettlementkey_bydirectlyfromcurrencycloud]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_CurrencyCloud_Trades_bysettlementkey_bydirectlyfromcurrencycloud]
	@settlementkey bigint,
	@directlyfromcurrencycloud int
AS
BEGIN

	SELECT *
	FROM vw_CurrencyCloud_Trades
	WHERE settlement_key = @settlementkey
	AND directlyfromcurrencycloud = @directlyfromcurrencycloud
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_bysettlementkey]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Trades_bysettlementkey]
	@settlementkey bigint
AS
BEGIN
	SELECT *
	FROM vw_CurrencyCloud_Trades
	WHERE settlement_key = @settlementkey
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_AwaitingSettlement_All]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_CurrencyCloud_Trades_AwaitingSettlement_All]
	
AS
BEGIN

	SELECT *
	FROM vw_CurrencyCloud_Trades
	WHERE settlement_key is null	
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_AwaitingSettlement]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Trades_AwaitingSettlement]
	@cc_cutoff int
AS
BEGIN

	SELECT *
	FROM vw_CurrencyCloud_Trades
	WHERE settlement_key is null
	AND @cc_cutoff = cc_cutoff
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trades_AwaitingFundsReturned]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Trades_AwaitingFundsReturned]
	
AS
BEGIN

	SELECT *,
	payments_info = '#' + convert(varchar,payments_key) + ' - ' + dbo.fn_txt_currency_symbol(buy_currency) + CONVERT(varchar, buy_amount) + dbo.fn_txt_currency_code(buy_currency) + ' - ' + payment_description
	FROM vw_CurrencyCloud_Trades	
	WHERE fundsreceived_date is null	
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_CurrencyCloud_Trade_bystatus]    Script Date: 04/28/2013 18:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_CurrencyCloud_Trade_bystatus]
	@status int
AS
BEGIN

IF @status = 3
	BEGIN
		SELECT *,
		cc_settlementid = (SELECT cc_settlementid FROM CurrencyCloud_Settlements WHERE CurrencyCloud_Settlements.currencycloud_settlement_key = settlement_key)
		FROM vw_CurrencyCloud_Trades
		WHERE cctrade_status = @status
		AND directlyfromcurrencycloud = 0
	END
ELSE IF @status = 5
	BEGIN
		SELECT *,
		cc_settlementid = (SELECT cc_settlementid FROM CurrencyCloud_Settlements WHERE CurrencyCloud_Settlements.currencycloud_settlement_key = settlement_key)
		FROM vw_CurrencyCloud_Trades
		WHERE cctrade_status = 3
		AND directlyfromcurrencycloud = 1
	END
ELSE
	BEGIN
		SELECT *,
		cc_settlementid = (SELECT cc_settlementid FROM CurrencyCloud_Settlements WHERE CurrencyCloud_Settlements.currencycloud_settlement_key = settlement_key)
		FROM vw_CurrencyCloud_Trades
		WHERE cctrade_status = @status
	END	

END
GO
/****** Object:  Default [DF__aspnet_Ap__Appli__2334397B]    Script Date: 04/28/2013 18:18:12 ******/
ALTER TABLE [dbo].[aspnet_Applications] ADD  DEFAULT (newid()) FOR [ApplicationId]
GO
/****** Object:  Default [DF__aspnet_Us__UserI__28ED12D1]    Script Date: 04/28/2013 18:18:16 ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  DEFAULT (newid()) FOR [UserId]
GO
/****** Object:  Default [DF__aspnet_Us__Mobil__29E1370A]    Script Date: 04/28/2013 18:18:16 ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  DEFAULT (NULL) FOR [MobileAlias]
GO
/****** Object:  Default [DF__aspnet_Us__IsAno__2AD55B43]    Script Date: 04/28/2013 18:18:16 ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  DEFAULT ((0)) FOR [IsAnonymous]
GO
/****** Object:  ForeignKey [FK__aspnet_Us__Appli__27F8EE98]    Script Date: 04/28/2013 18:18:16 ******/
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
