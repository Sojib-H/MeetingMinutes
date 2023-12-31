USE [SinglePageTask]
GO
/****** Object:  Table [dbo].[Corporate_Customer_Tbl]    Script Date: 12/23/2023 7:04:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporate_Customer_Tbl](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Corporate_Customer_Tbl] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Individual_Customer_Tbl]    Script Date: 12/23/2023 7:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individual_Customer_Tbl](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Individual_Customer_Tbl] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_Minutes_Details_Tbl]    Script Date: 12/23/2023 7:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_Minutes_Details_Tbl](
	[MasterDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[MasterTableID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qnty] [int] NOT NULL,
 CONSTRAINT [PK_Meeting_Minutes_Details_Tbl] PRIMARY KEY CLUSTERED 
(
	[MasterDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_Minutes_Master_Tbl]    Script Date: 12/23/2023 7:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_Minutes_Master_Tbl](
	[MasterTableID] [int] IDENTITY(1,1) NOT NULL,
	[CorporateCustomerID] [int] NOT NULL,
	[IndividualCustomerID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Time] [time](7) NOT NULL,
	[MeetingPlace] [nvarchar](150) NOT NULL,
	[AttendsFromClient] [nvarchar](150) NOT NULL,
	[AttendsFromHost] [nvarchar](150) NOT NULL,
	[MeetingAgenda] [nvarchar](150) NOT NULL,
	[MeetingDiscussion] [nvarchar](150) NOT NULL,
	[MeetingDecision] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Meeting_Minutes_Master_Tbl] PRIMARY KEY CLUSTERED 
(
	[MasterTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Service_Tbl]    Script Date: 12/23/2023 7:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Service_Tbl](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product_Service_Tbl] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Corporate_Customer_Tbl] ON 

INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerID], [CustomerName]) VALUES (1, N'Customer 1')
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerID], [CustomerName]) VALUES (2, N'Customer 2')
SET IDENTITY_INSERT [dbo].[Corporate_Customer_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Individual_Customer_Tbl] ON 

INSERT [dbo].[Individual_Customer_Tbl] ([CustomerID], [CustomerName]) VALUES (1, N'Customer 3')
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerID], [CustomerName]) VALUES (2, N'Customer 4')
SET IDENTITY_INSERT [dbo].[Individual_Customer_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Service_Tbl] ON 

INSERT [dbo].[Product_Service_Tbl] ([ProductID], [ProductName], [Unit]) VALUES (1, N'Product 1', N'KG')
INSERT [dbo].[Product_Service_Tbl] ([ProductID], [ProductName], [Unit]) VALUES (2, N'Product 2', N'L')
SET IDENTITY_INSERT [dbo].[Product_Service_Tbl] OFF
GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Details_Save_SP]    Script Date: 12/23/2023 7:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sojib
-- Create date: 23 dec, 2023
-- Description:	meeting minutes details save sp
-- =============================================
CREATE PROCEDURE [dbo].[Meeting_Minutes_Details_Save_SP] 
			@MasterTableID int
           ,@ProductID int
           ,@Qnty int

AS
BEGIN
	INSERT INTO [dbo].[Meeting_Minutes_Details_Tbl]
           ([MasterTableID]
           ,[ProductID]
           ,[Qnty])
     VALUES
           (@MasterTableID
           ,@ProductID
           ,@Qnty)

END
GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Master_Save_SP]    Script Date: 12/23/2023 7:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sojib
-- Create date: 23 dec, 2023
-- Description:	meeting minutes master save sp
-- =============================================
CREATE PROCEDURE [dbo].[Meeting_Minutes_Master_Save_SP] 
@MasterTableID int=0,
	@CorporateCustomerID	  int,				  
	@IndividualCustomerID	  int		  ,
	@Date					  datetime		  ,
	@Time					  time		  ,
	@MeetingPlace			  nvarchar(150)		  ,
	@AttendsFromClient		  nvarchar(150)		  ,
	@AttendsFromHost		  nvarchar(150)		  ,
	@MeetingAgenda			  nvarchar(150)		  ,
	@MeetingDiscussion		  nvarchar(150)		  ,
	@MeetingDecision	  nvarchar(150)		  

AS
BEGIN
	INSERT INTO [dbo].[Meeting_Minutes_Master_Tbl]
           (
		   [CorporateCustomerID]
           ,[IndividualCustomerID]
           ,[Date]
           ,[Time]
           ,[MeetingPlace]
           ,[AttendsFromClient]
           ,[AttendsFromHost]
           ,[MeetingAgenda]
           ,[MeetingDiscussion]
           ,[MeetingDecision])
     VALUES
           (@CorporateCustomerID
           ,@IndividualCustomerID
           ,@Date
           ,@Time
           ,@MeetingPlace
           ,@AttendsFromClient
           ,@AttendsFromHost
           ,@MeetingAgenda
           ,@MeetingDiscussion
           ,@MeetingDecision)



select max (MasterTableID) from Meeting_Minutes_Master_Tbl

END
GO
