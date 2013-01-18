USE [master]
GO
/****** Object:  Database [Peerfx]    Script Date: 01/17/2013 23:00:56 ******/
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
/****** Object:  Table [dbo].[Bank_Accounts]    Script Date: 01/17/2013 23:00:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank_Accounts](
	[bank_account_key] [int] IDENTITY(1,1) NOT NULL,
	[user_key] [int] NOT NULL,
	[currency_key] [int] NOT NULL,
	[bank_key] [nchar](10) NOT NULL,
	[bank_account] [varchar](50) NOT NULL,
	[last_changed] [datetime] NOT NULL,
	[bank_account_description] [nvarchar](100) NULL,
	[is_system_account] [bit] NOT NULL,
	[user_key_updated] [int] NOT NULL,
	[ip_address] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Users_Bank_Accounts] PRIMARY KEY CLUSTERED 
(
	[bank_account_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users_Verified]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Users_Security_Answers]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Users_Info]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[User_Statuses]    Script Date: 01/17/2013 23:00:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Statuses](
	[user_status_key] [int] NULL,
	[status_description] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions_External]    Script Date: 01/17/2013 23:00:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transactions_External](
	[tx_external_key] [bigint] IDENTITY(1,1) NOT NULL,
	[tx_external_type] [int] NOT NULL,
	[tx_external_status] [int] NOT NULL,
	[user_key] [int] NULL,
	[currency] [int] NOT NULL,
	[amount] [money] NOT NULL,
	[sender_bank_account_key] [int] NULL,
	[receiver_bank_account_key] [int] NULL,
	[tx_external_description] [nvarchar](100) NULL,
	[last_changed] [datetime] NOT NULL,
	[ip_address] [nchar](16) NOT NULL,
	[user_key_updated] [int] NULL,
	[bank_reference] [varchar](100) NULL,
	[sender_bank_name] [nvarchar](50) NULL,
	[sender_bank_account] [varchar](50) NULL,
	[receiver_bank_name] [nvarchar](50) NULL,
	[receiver_bank_account] [varchar](50) NULL,
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = user bank to system bank / 2 = system bank to user bank / 3 = bank to bank / 4 = bank to other' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions_External', @level2type=N'COLUMN',@level2name=N'tx_external_type'
GO
/****** Object:  Table [dbo].[Transaction_Fees]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_Verification_Methods]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_Security_Questions]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_Phone_Type]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_Organizations]    Script Date: 01/17/2013 23:00:58 ******/
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
	[isbank] [bit] NULL,
 CONSTRAINT [PK_Info_Banks] PRIMARY KEY CLUSTERED 
(
	[info_organizations_key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Fee_Types]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_CurrencyCloud_Tokens]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_Currencies]    Script Date: 01/17/2013 23:00:58 ******/
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
	[info_currency_canbuy] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Country_List]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  Table [dbo].[Info_Country_Code_List]    Script Date: 01/17/2013 23:00:58 ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_User_Balance]    Script Date: 01/17/2013 23:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_User_Balance]
	(@user_key int,
	@currency int)
RETURNS decimal(20,2)
AS
	BEGIN
	declare @Balance decimal(20,2)
	SELECT @Balance = Case 
					WHEN(SELECT SUM(amount) FROM Transactions_External
						WHERE user_key = @user_key
						AND currency = @currency
						AND amount > 0)
					IS NULL THEN 0					
					ELSE (
						SELECT SUM(amount) FROM Transactions_External
						WHERE user_key = @user_key
						AND currency = @currency
						AND amount > 0
					)
					END
	RETURN @Balance
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_tx_fees_total]    Script Date: 01/17/2013 23:01:00 ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Users_Security_Answers]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Verification_Email]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users_Security_Answers]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users_Info_Signup_Tab3]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users_Info]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Users]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Transactions_External]    Script Date: 01/17/2013 23:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transactions_External]
	
	@tx_external_key int,	
	@tx_external_status int,
	@tx_external_type int,
	@currency int,
	@amount money,
	@sender_bank_account_key int,	
	@receiver_bank_account_key int,
	@ip_address varchar(20),
	@user_key_updated int,
	@tx_external_description nvarchar(100),	
	@sender_bank_name nvarchar(50),
	@sender_bank_account varchar(50),
	@receiver_bank_name nvarchar(50),
	@receiver_bank_account varchar(50),
	@user_key int,
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
	( tx_external_status, tx_external_type, currency, amount, sender_bank_account_key, receiver_bank_account_key, last_changed, ip_address, user_key_updated, tx_external_description,sender_bank_name,sender_bank_account,receiver_bank_name,receiver_bank_account,bank_reference, date_created)
	VALUES
	( @tx_external_status, @tx_external_type, @currency, @amount, @sender_bank_account_key, @receiver_bank_account_key, @CurrentDate, @ip_address, @user_key_updated, @tx_external_description,@sender_bank_name,@sender_bank_account,@receiver_bank_name,@receiver_bank_account,@bank_reference, @CurrentDate)

	SET @tx_external_key_return = (SELECT tx_external_key FROM Transactions_External WHERE last_changed = @CurrentDate)

	END
ELSE
	BEGIN
		UPDATE Transactions_External
			SET
				tx_external_status = @tx_external_status,
				tx_external_type = @tx_external_type,
				currency = @currency,
				amount = @amount,
				sender_bank_account_key = @sender_bank_account_key,
				receiver_bank_account_key = @receiver_bank_account_key,
				user_key_updated = @user_key_updated,
				ip_address = @ip_address,
				sender_bank_name = @sender_bank_name,
				sender_bank_account = @sender_bank_account,
				receiver_bank_name = @receiver_bank_name,
				receiver_bank_account = @receiver_bank_account,
				bank_reference = @bank_reference,
				last_changed = getdate()				
			WHERE tx_external_key = @tx_external_key
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Transaction_Fees]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Transaction_External_Status]    Script Date: 01/17/2013 23:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Transaction_External_Status]
	
	@tx_external_key int,	
	@tx_external_status int,
	@ip_address varchar(20),
	@user_key int,
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
				user_key = @user_key,
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
/****** Object:  StoredProcedure [dbo].[Update_Info_CurrencyCloud_Tokens]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Security_Questions]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Phone_Type]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Fee_Types]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_CurrencyCloud_Tokens]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_Specific]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanSell]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies_CanBuy]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Currencies]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Country_List]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Info_Country_Code_List]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Transaction_Fees_txkey]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Transaction_Fees]    Script Date: 01/17/2013 23:01:02 ******/
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
/****** Object:  View [dbo].[vw_info_banks]    Script Date: 01/17/2013 23:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_info_banks]
AS
SELECT        info_organizations_key, organization_name, user_key_updated, last_changed, organization_description, isbank
FROM            dbo.Info_Organizations
WHERE        (isbank = 1)
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
/****** Object:  StoredProcedure [dbo].[View_Users_Verified_byCode]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Verified]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Security_Answers]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  View [dbo].[vw_Users_Info]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  View [dbo].[vw_Transactions_External]    Script Date: 01/17/2013 23:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Transactions_External]
AS
SELECT        dbo.Transactions_External.tx_external_key, dbo.Transactions_External.tx_external_type, dbo.Transactions_External.tx_external_status, 
                         dbo.Transactions_External.user_key, dbo.Transactions_External.currency, dbo.Transactions_External.amount, 
                         dbo.Transactions_External.sender_bank_account_key, dbo.Transactions_External.receiver_bank_account_key, dbo.Transactions_External.tx_external_description, 
                         dbo.Transactions_External.last_changed, dbo.Transactions_External.ip_address, dbo.Transactions_External.user_key_updated, 
                         dbo.Transactions_External.bank_reference, dbo.Transactions_External.sender_bank_name, dbo.Transactions_External.sender_bank_account, 
                         dbo.Transactions_External.receiver_bank_name, dbo.Transactions_External.receiver_bank_account, dbo.Transactions_External.date_created, 
                         dbo.Transactions_External.date_processed, dbo.Info_Currencies.info_currencies_key, dbo.Info_Currencies.info_currency_code, 
                         dbo.Info_Currencies.info_currency_name, dbo.Info_Currencies.info_currency_country, CASE WHEN Transactions_External.sender_bank_account_key IS NULL 
                         THEN dbo.Transactions_External.sender_bank_name ELSE
                             (SELECT        organization_name
                               FROM            Bank_Accounts INNER JOIN
                                                         vw_info_banks ON Bank_Accounts.bank_key = vw_info_banks.info_organizations_key
                               WHERE        Transactions_External.sender_bank_account_key = Bank_Accounts.bank_account_key) END AS vw_sender_bank_name, 
                         CASE WHEN Transactions_External.sender_bank_account_key IS NULL THEN dbo.Transactions_External.sender_bank_account ELSE
                             (SELECT        bank_account
                               FROM            Bank_Accounts
                               WHERE        Transactions_External.sender_bank_account_key = Bank_Accounts.bank_account_key) END AS vw_sender_bank_account, 
                         CASE WHEN Transactions_External.receiver_bank_account_key IS NULL THEN dbo.Transactions_External.receiver_bank_name ELSE
                             (SELECT        organization_name
                               FROM            Bank_Accounts INNER JOIN
                                                         vw_info_banks ON Bank_Accounts.bank_key = vw_info_banks.info_organizations_key
                               WHERE        Transactions_External.receiver_bank_account_key = Bank_Accounts.bank_account_key) END AS vw_receiver_bank_name, 
                         CASE WHEN Transactions_External.receiver_bank_account_key IS NULL THEN dbo.Transactions_External.receiver_bank_account ELSE
                             (SELECT        bank_account
                               FROM            Bank_Accounts
                               WHERE        Transactions_External.receiver_bank_account_key = Bank_Accounts.bank_account_key) END AS vw_receiver_bank_account, 
                         dbo.Transactions_External.amount - dbo.fn_tx_fees_total(dbo.Transactions_External.tx_external_key) AS proceeds
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
/****** Object:  StoredProcedure [dbo].[View_Users_Info]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_Email]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Users_All]    Script Date: 01/17/2013 23:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Users_All]	

AS
BEGIN
	
	SELECT *,
	user_balance = dbo.fn_User_Balance(user_key,1)
	FROM vw_Users_Info
		
END
GO
/****** Object:  StoredProcedure [dbo].[View_Users_Admin]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[view_Transaction_External]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[View_System_Bank_Accounts]    Script Date: 01/17/2013 23:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_System_Bank_Accounts]	

AS
BEGIN
	SELECT *,
	organization_name = (SELECT organization_name FROM vw_info_banks WHERE vw_info_banks.info_organizations_key = Bank_Accounts.bank_key),
	organization_name_full = (SELECT organization_name FROM vw_info_banks WHERE vw_info_banks.info_organizations_key = Bank_Accounts.bank_key) + ' - ' + bank_account
	FROM Bank_Accounts
	WHERE is_system_account = 1
	
END
GO
/****** Object:  StoredProcedure [dbo].[View_Info_Banks]    Script Date: 01/17/2013 23:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[View_Admin_Deposits]    Script Date: 01/17/2013 23:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[View_Admin_Deposits]
	@tx_external_status int
AS
BEGIN


	SELECT *,
	user_account_number = (SELECT account_number FROM Users WHERE Users.user_key = Transactions_External.user_key),
	proceeds = vw_Transactions_External.amount - dbo.fn_tx_fees_total(vw_Transactions_External.tx_external_key)
	FROM Transactions_External	
	LEFT JOIN vw_Transactions_External
	ON Transactions_External.tx_external_key = vw_Transactions_External.tx_external_key
	WHERE Transactions_External.tx_external_type = 1 --bank to user tx / Deposits
	AND Transactions_External.tx_external_status = @tx_external_status
	
END
GO
