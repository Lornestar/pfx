USE [master]
GO
/****** Object:  Database [Peerfx]    Script Date: 02/07/2013 09:55:30 ******/
CREATE DATABASE [Peerfx] ON  PRIMARY 
( NAME = N'Peerfx', FILENAME = N'D:\Websites\DatabaseFiles\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Peerfx.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Peerfx_log', FILENAME = N'D:\Websites\DatabaseFiles\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Peerfx_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Transactions_Internal]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Transactions_External]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Transaction_Status]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Transaction_Fees]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Recipients]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Quotes]    Script Date: 02/07/2013 09:55:31 ******/
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
 CONSTRAINT [PK_Quotes] PRIMARY KEY CLUSTERED 
(
	[quotes_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purpose_Types]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Payments]    Script Date: 02/07/2013 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[payments_key] [int] IDENTITY(1,1) NOT NULL,
	[quote_key] [int] NOT NULL,
	[payment_status] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[requestor_user_key] [int] NULL,
	[payment_object_sender] [bigint] NULL,
	[payment_object_receiver] [bigint] NULL,
	[payment_description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[payments_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Status]    Script Date: 02/07/2013 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Status](
	[payment_status_key] [int] NOT NULL,
	[payment_status_description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment_Status] PRIMARY KEY CLUSTERED 
(
	[payment_status_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Schedule]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Payment_Objects]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Payment_Object_Types]    Script Date: 02/07/2013 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Object_Types](
	[payment_object_type_key] [int] NOT NULL,
	[payment_object_type_description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Payment_Object_Types] PRIMARY KEY CLUSTERED 
(
	[payment_object_type_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Verification_Methods]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Info_Security_Questions]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Info_Phone_Type]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Info_Organizations]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Info_Organization_Type]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Info_Fee_Types]    Script Date: 02/07/2013 09:55:31 ******/
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
 CONSTRAINT [PK_Info_Fee_Types] PRIMARY KEY CLUSTERED 
(
	[info_fee_types] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_CurrencyCloud_Tokens]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Info_Currencies]    Script Date: 02/07/2013 09:55:31 ******/
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
	[info_currency_description] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Country_List]    Script Date: 02/07/2013 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Country_List](
	[info_country_key] [int] NOT NULL,
	[country_value] [nchar](2) NOT NULL,
	[country_text] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Info_Country_List] PRIMARY KEY CLUSTERED 
(
	[info_country_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Country_Code_List]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Users_Verified]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Users_Security_Answers]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Users_Info]    Script Date: 02/07/2013 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
 CONSTRAINT [PK_Users_Info] PRIMARY KEY CLUSTERED 
(
	[user_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/07/2013 09:55:31 ******/
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
	[isadmin] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Statuses]    Script Date: 02/07/2013 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Statuses](
	[user_status_key] [int] NULL,
	[status_description] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Recipients]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  Table [dbo].[Bank_Accounts]    Script Date: 02/07/2013 09:55:31 ******/
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
 CONSTRAINT [PK_Users_Bank_Accounts] PRIMARY KEY CLUSTERED 
(
	[bank_account_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin_Bank_Accounts]    Script Date: 02/07/2013 09:55:31 ******/
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
/****** Object:  View [dbo].[vw_info_banks]    Script Date: 02/07/2013 09:55:33 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Verified_byCode]    Script Date: 02/07/2013 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Verified_byCode]
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
/****** Object:  StoredProcedure [dbo].[View_Users_Verified]    Script Date: 02/07/2013 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Users_Verified]
	@user_key int,
	@verification_methods_key int

AS
BEGIN

	SELECT *
	FROM Users_Verified
	WHERE user_key = @user_key
	AND verification_methods_key = @verification_methods_key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Security_Answers]    Script Date: 02/07/2013 09:55:34 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Payments_Requestedbyuser]    Script Date: 02/07/2013 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Payments_Requestedbyuser]
	@user_key int
AS
BEGIN
	
	SELECT *,
	payments_info = '#' + convert(varchar,payments_key) + ' - ' + payment_description,
	payment_status_info = (SELECT payment_status_description FROM Payment_Status WHERE payment_status_key = payment_status)
	FROM Payments
	WHERE requestor_user_key = @user_key

END
GO
/****** Object:  StoredProcedure [dbo].[View_Payments_Confirmed]    Script Date: 02/07/2013 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Payments_Confirmed]
	
AS
BEGIN
	
	SELECT *,
	payments_info = '#' + convert(varchar,payments_key) + ' - ' + payment_description
	FROM Payments
	WHERE payment_status = 2 --payment confirmed, awaiting receipt of funds in system bank

END
GO
/****** Object:  View [dbo].[vw_Transactions_All]    Script Date: 02/07/2013 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Transactions_All]
AS
SELECT        tx_key = tx_external_key, tx_status = tx_external_status, purpose_type, purpose_object_key, currency, amount, payment_object_sender, payment_object_receiver, 
                         tx_description = tx_external_description, last_changed, ip_address, user_key_updated, date_created, date_processed, tx_status_text =
                             (SELECT        status_description
                               FROM            Transaction_Status
                               WHERE        transaction_status_key = tx_external_status),
currency_text =                              (SELECT   info_currency_name
                               FROM            dbo.Info_Currencies
                               WHERE        (currency = info_currencies_key)) 
FROM            Transactions_External
UNION
SELECT        tx_key = tx_internal_key, tx_status = tx_internal_status, purpose_type, purpose_object_key, currency, amount, payment_object_sender, payment_object_receiver, 
                         tx_description = tx_internal_description, last_changed, ip_address, user_key_updated, date_created, date_processed, tx_status_text =
                             (SELECT        status_description
                               FROM            Transaction_Status
                               WHERE        transaction_status_key = tx_internal_status),
currency_text =                              (SELECT   info_currency_name
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
/****** Object:  View [dbo].[vw_Users_Info]    Script Date: 02/07/2013 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Users_Info]
AS
SELECT        dbo.Users.user_key, dbo.Users.account_number, dbo.Users.title, dbo.Users.first_name, dbo.Users.middle_name, dbo.Users.last_name, dbo.Users.dob, 
                         dbo.Users.country_residence, dbo.Users.email, dbo.Users.ip_address, dbo.Users.last_changed, dbo.Users.signed_up, dbo.Users.user_status, dbo.Users.isadmin, 
                         dbo.Users_Info.address1, dbo.Users_Info.address2, dbo.Users_Info.city, dbo.Users_Info.state, dbo.Users_Info.country, dbo.Users_Info.postalcode, 
                         dbo.Users_Info.phonecountrycode1, dbo.Users_Info.phonetype1, dbo.Users_Info.phonenumber1, dbo.Users_Info.phonecountrycode2, dbo.Users_Info.phonetype2, 
                         dbo.Users_Info.phonenumber2, dbo.Users_Info.identitynationality, dbo.Users_Info.occupation, dbo.Users_Info.passportnumber, dbo.Users_Info.username, 
                         dbo.Users_Info.password, dbo.Users.first_name + ' ' + dbo.Users.last_name + ' - ' + dbo.Users.account_number AS user_info_full
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
         Top = 0
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
               Bottom = 345
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Users_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Users_Info'
GO
/****** Object:  UserDefinedFunction [dbo].[fn_tx_fees_total]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_Payment_Object_Key]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_Organization_Name]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_Ledger_Payment_Objects]    Script Date: 02/07/2013 09:55:35 ******/
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

	RETURN @Balancefull
	END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Users_Security_Answers]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Verification_Email]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users_Security_Answers]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users_Info_Signup_Tab3]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users_Info]    Script Date: 02/07/2013 09:55:35 ******/
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
	@passportnumber nchar(44)

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
	(user_key, address1, address2, city, state, country, postalcode, phonecountrycode1, phonetype1, phonenumber1, phonecountrycode2, phonetype2, phonenumber2, identitynationality, occupation, passportnumber, last_changed)
	VALUES
	(@user_key, @address1, @address2, @city, @state, @country, @postalcode, @phonecountrycode1, @phonetype1, @phonenumber1, @phonecountrycode2, @phonetype2, @phonenumber2, @identitynationality, @occupation, @passportnumber, getdate())
	

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
				last_changed = getdate()				
			WHERE user_key = @user_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Users]    Script Date: 02/07/2013 09:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Users]
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

	SET @user_key_return = (SELECT user_key FROM Users WHERE signed_up = @CurrentDate)

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
/****** Object:  StoredProcedure [dbo].[Update_Transactions_Internal]    Script Date: 02/07/2013 09:55:35 ******/
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
	@tx_internal_key_return int Output
	
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
	(tx_internal_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_internal_description, date_created)
	VALUES
	( @tx_internal_status, @currency, @amount, @payment_object_sender, @payment_object_receiver, @CurrentDate, @ip_address, @user_key_updated, @tx_internal_description, @CurrentDate)

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
				last_changed = getdate()				
			WHERE tx_internal_key = @tx_internal_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transactions_External]    Script Date: 02/07/2013 09:55:35 ******/
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
	@tx_external_key_return int Output
	
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
	(tx_external_status, currency, amount, payment_object_sender, payment_object_receiver, last_changed, ip_address, user_key_updated, tx_external_description,bank_reference, date_created)
	VALUES
	( @tx_external_status, @currency, @amount, @payment_object_sender, @payment_object_receiver, @CurrentDate, @ip_address, @user_key_updated, @tx_external_description,@bank_reference, @CurrentDate)

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
				last_changed = getdate()				
			WHERE tx_external_key = @tx_external_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transaction_Fees]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Transaction_External_Status]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Transaction_External_Purpose]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Recipients]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Quotes]    Script Date: 02/07/2013 09:55:35 ******/
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

	SET @quotes_key_return = (SELECT quotes_key FROM Quotes WHERE date_created = @CurrentDate)

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
/****** Object:  StoredProcedure [dbo].[View_Payment_Schedule]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Payment_Object_Bank_Account]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Security_Questions]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Phone_Type]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Fee_Types]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_CurrencyCloud_Tokens]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currency_Symbol]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_Specific]    Script Date: 02/07/2013 09:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[View_Info_Currencies_Specific]

@Currency_Key int
	
AS
BEGIN
	
	SELECT *
	FROM Info_Currencies
	WHERE info_currencies_key = @Currency_Key
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanSell]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanBuy]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies]    Script Date: 02/07/2013 09:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Info_Currencies]
	
AS
BEGIN
	
	SELECT *
	FROM Info_Currencies
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Country_List]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Country_Code_List]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Transaction_Fees_txkey]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Transaction_Fees]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Payments]    Script Date: 02/07/2013 09:55:35 ******/
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

	SET @payments_key_return = (SELECT payments_key FROM Payments WHERE date_created = @CurrentDate)

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
/****** Object:  StoredProcedure [dbo].[Update_Payment_Status]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Payment_Objects]    Script Date: 02/07/2013 09:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Update_Payment_Objects]
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

	SET @payment_object_key_return = (SELECT payment_object_key FROM Payment_Objects WHERE date_created = @CurrentDate)

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
/****** Object:  StoredProcedure [dbo].[Update_Info_CurrencyCloud_Tokens]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Bank_Accounts]    Script Date: 02/07/2013 09:55:35 ******/
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
	@bank_account_key_return int Output

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
	(user_key,currency_key,organization_key,bank_account_description,user_key_updated,ip_address,account_number,IBAN,BIC,ABArouting,first_name,last_name,business_name,last_changed,date_created)
	VALUES
	(@user_key,@currency_key,@organization_key,@bank_account_description,@user_key_updated,@ip_address,@account_number,@IBAN,@BIC,@ABArouting,@first_name,@last_name,@business_name,@CurrentDate,@CurrentDate)

	SET @bank_account_key_return = (SELECT bank_account_key FROM Bank_Accounts WHERE date_created = @CurrentDate)

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
				last_changed = getdate()
			WHERE bank_account_key = @bank_account_key
	END

END
GO
/****** Object:  UserDefinedFunction [dbo].[txt_Admin_Bank_Account_CurrencyExchange]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Payment_Status]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Admin_Bank_Account_CurrencyExchange]    Script Date: 02/07/2013 09:55:35 ******/
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
	WHERE payment_object_type = 2 --Admin bank account
	AND receiving_currency = @currency
	AND ((receiving_country = @country) OR (receiving_country = 0))
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_txt_user_balance_currencyspecific]    Script Date: 02/07/2013 09:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_txt_user_balance_currencyspecific]
	(@user_key int,
	@currency int)
		
RETURNS nvarchar(100)
AS
	BEGIN

	declare @txtbalance nvarchar(100)
	
	--payment object key for available account
	declare @paymentobjectkey_available bigint
	SET @paymentobjectkey_available = dbo.fn_Payment_Object_Key(3,@user_key)

	--payment object key for frozen account
	declare @paymentobjectkey_frozen bigint
	SET @paymentobjectkey_frozen = dbo.fn_Payment_Object_key(4,@user_key)

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
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_available,@currency)
			IF @tempbalance <> 0
				BEGIN
					SET @txtavailable = @txtavailable + RTRIM((SELECT info_currency_symbol FROM Info_Currencies WHERE info_currencies_key = @currency)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
				END

			--frozen
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_frozen,@currency)
			IF @tempbalance <> 0
				BEGIN
					SET @txtfrozen = @txtfrozen + RTRIM((SELECT info_currency_symbol FROM Info_Currencies WHERE info_currencies_key = @currency)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
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
/****** Object:  UserDefinedFunction [dbo].[fn_txt_user_balance]    Script Date: 02/07/2013 09:55:35 ******/
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
					SET @txtavailable = @txtavailable + RTRIM((SELECT info_currency_symbol FROM Info_Currencies WHERE info_currencies_key = @i)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
				END

			--frozen
			SET @tempbalance = dbo.fn_Ledger_Payment_Objects(@paymentobjectkey_frozen,@i)
			IF @tempbalance <> 0
				BEGIN
					SET @txtfrozen = @txtfrozen + RTRIM((SELECT info_currency_symbol FROM Info_Currencies WHERE info_currencies_key = @i)) + ' ' +  CONVERT(nvarchar(50),@tempbalance) + ', '
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
/****** Object:  UserDefinedFunction [dbo].[fn_txt_bank_account_info]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Process_Deposit]    Script Date: 02/07/2013 09:55:35 ******/
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
			SET @payment_object_receiver = dbo.fn_Payment_Object_Key(4,(SELECT requestor_user_key FROM Payments WHERE payments_key = @object_key))
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
	IF @purpose_type = 1 --Payment is purpose then internal payment goes to user's frozen account
		BEGIN
			UPDATE Payments SET
				payment_status = 3
			WHERE payments_key = @object_key
		END	

END
GO
/****** Object:  StoredProcedure [dbo].[view_Transaction_External]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Transaction_All_SpecificPayment]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Transaction_All]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Banks]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  View [dbo].[vw_Transactions_External]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Admin]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Info]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Email]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Admin_Deposits]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  View [dbo].[vw_Bank_Accounts_Users]    Script Date: 02/07/2013 09:55:35 ******/
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
                             (SELECT        info_currency_name
                               FROM            dbo.Info_Currencies
                               WHERE        (dbo.Bank_Accounts.currency_key = info_currencies_key)) AS currency_text
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Bank_Accounts"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 271
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
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
/****** Object:  View [dbo].[vw_Bank_Accounts_System]    Script Date: 02/07/2013 09:55:35 ******/
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
                         dbo.Info_Country_List.country_text
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Bank_Accounts"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 286
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
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
/****** Object:  StoredProcedure [dbo].[View_Users_All]    Script Date: 02/07/2013 09:55:35 ******/
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
/****** Object:  StoredProcedure [dbo].[View_User_Currency_List]    Script Date: 02/07/2013 09:55:36 ******/
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
		
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Process_Withdrawl_Payment]    Script Date: 02/07/2013 09:55:36 ******/
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

	--destination bank account, currency of tx & system bank account
	SET @payment_object_receiver = (SELECT payment_object_receiver FROM Payments WHERE payments_key = @payments_key)	
	SET @currency = (SELECT currency_key FROM vw_Bank_Accounts_Users WHERE payment_object_key = @payment_object_receiver)
	SET @payment_object_sender = dbo.txt_Admin_Bank_Account_CurrencyExchange(@currency,0)	
			

	--Send money to user's external account from system account
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
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_Users]    Script Date: 02/07/2013 09:55:36 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_Specific_paymentkey]    Script Date: 02/07/2013 09:55:36 ******/
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
ELSE
	BEGIN
		SELECT *
		FROM vw_Bank_Accounts_System	
		WHERE payment_object_key = @paymentkey
	END		

END
GO
/****** Object:  StoredProcedure [dbo].[View_Bank_Accounts_Specific]    Script Date: 02/07/2013 09:55:36 ******/
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
/****** Object:  StoredProcedure [dbo].[View_System_Bank_Accounts]    Script Date: 02/07/2013 09:55:36 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Recipients_byuser_andcurrency]    Script Date: 02/07/2013 09:55:36 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Recipients_byuser]    Script Date: 02/07/2013 09:55:36 ******/
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
/****** Object:  View [dbo].[vw_Payments]    Script Date: 02/07/2013 09:55:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Payments]
AS
SELECT        dbo.Payments.payments_key, dbo.Payments.quote_key, dbo.Payments.payment_status, dbo.Payments.date_created, dbo.Payments.requestor_user_key, 
                         dbo.Payments.payment_object_sender, dbo.Payments.payment_object_receiver, dbo.Payments.payment_description, dbo.Quotes.sell_amount, 
                         dbo.Quotes.sell_currency, dbo.Quotes.buy_amount, dbo.Quotes.buy_currency, dbo.Quotes.rate, dbo.Quotes.service_fee, dbo.Quotes.promised_delivery_date, 
                         dbo.Quotes.actual_delivery_date,
                             (SELECT        first_name + ' ' + last_name AS Expr1
                               FROM            dbo.vw_Bank_Accounts_Users
                               WHERE        (payment_object_key = dbo.Payments.payment_object_receiver)) AS receiver_name,
                             (SELECT        first_name + ' ' + last_name AS Expr1
                               FROM            dbo.Users
                               WHERE        (user_key = dbo.Payments.requestor_user_key)) AS sender_name,
                             (SELECT        info_currency_name
                               FROM            dbo.Info_Currencies
                               WHERE        (dbo.Quotes.sell_currency = info_currencies_key)) AS sell_currency_text,
                             (SELECT        info_currency_name
                               FROM            dbo.Info_Currencies AS Info_Currencies_1
                               WHERE        (dbo.Quotes.buy_currency = info_currencies_key)) AS buy_currency_text,
                             (SELECT        payment_status_description
                               FROM            dbo.Payment_Status AS Payment_Status_1
                               WHERE        (payment_status_key = dbo.Payments.payment_status)) AS payment_status_text
FROM            dbo.Payments INNER JOIN
                         dbo.Quotes ON dbo.Payments.quote_key = dbo.Quotes.quotes_key
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
         Begin Table = "Payments"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 219
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Quotes"
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
      Begin ColumnWidths = 19
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Payments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Payments'
GO
/****** Object:  StoredProcedure [dbo].[View_Payments]    Script Date: 02/07/2013 09:55:36 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Payment_Specific]    Script Date: 02/07/2013 09:55:36 ******/
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
