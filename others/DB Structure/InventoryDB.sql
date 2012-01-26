USE [Inventory]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [nvarchar](4) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ContactId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](7) NOT NULL,
	[FaxNumber] [nvarchar](7) NOT NULL,
	[HeadId] [int] NOT NULL,
	[CollectionPointId] [int] NULL,
	[RepresentativeId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'COMM', N'Commerce Dept', 5, N'8741284', N'8921256', 6, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'CPSC', N'Computer Science', 3, N'8901235', N'8921457', 4, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'ENGL', N'English Dept', 1, N'8742234', N'8921456', 2, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'REGR', N'Registrar Dept', 7, N'8901266', N'8921465', 8, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'ZOOL', N'Zoology Dept', 9, N'8901266', N'8921465', 10, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[Employee]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[DepartmentId] [nvarchar](4) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (1, 1, 1, N'ENGL', N'Mrs Pamela Kow', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (2, 1, 5, N'ENGL', N'Prof Ezra Pound', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (3, 1, 1, N'CPSC', N'Mr Wee Kian Fatt', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (4, 1, 5, N'CPSC', N'Dr. Soh Kian Wee', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (5, 1, 1, N'COMM', N'Mr Mohd. Azman', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (6, 1, 5, N'COMM', N'Dr. Chia Leow Bee', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (7, 1, 1, N'REGR', N'Ms Helen Ho', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (8, 1, 5, N'REGR', N'Mrs Low Kway Boo', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (9, 1, 1, N'ZOOL', N'Mr Peter Tan Ah Meng', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (10, 1, 5, N'ZOOL', N'Prof Tan', NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[Requisition]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requisition](
	[Id] [nvarchar](15) NOT NULL,
	[DepartmentId] [nvarchar](4) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Remarks] [text] NOT NULL,
	[ApprovedBy] [int] NULL,
	[ApprovedDate] [datetime] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_requisition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectionPoint]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionPoint](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Time] [time](7) NOT NULL,
	[ClerkId] [int] NOT NULL,
 CONSTRAINT [PK_collectionpoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionCollection]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionCollection](
	[Id] [int] NOT NULL,
	[DepartmentId] [nvarchar](4) NOT NULL,
	[CollectionPointId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_requisitioncollection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionCollectionDetails]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionCollectionDetails](
	[Id] [int] NOT NULL,
	[RequisitionId] [nvarchar](15) NOT NULL,
	[RequisitionCollectionId] [int] NOT NULL,
 CONSTRAINT [PK_requisitioncollectiondetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [nvarchar](4) NOT NULL,
	[ItemCategoryId] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[ReorderQty] [int] NOT NULL,
	[Cost] [money] NOT NULL,
	[UnitOfMeasureId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionDetails]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionDetails](
	[Id] [int] NOT NULL,
	[RequisitionId] [nvarchar](15) NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[Qty] [int] NOT NULL,
	[DeliveredQty] [int] NOT NULL,
 CONSTRAINT [PK_requisitiondetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [nvarchar](4) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Priority] [int] NOT NULL,
	[ContactName] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](7) NOT NULL,
	[FaxNumber] [nvarchar](7) NOT NULL,
	[Address] [text] NOT NULL,
	[GstRegistrationNumber] [nvarchar](12) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Supplier] ([Id], [Name], [Priority], [ContactName], [PhoneNumber], [FaxNumber], [Address], [GstRegistrationNumber], [CreatedDate], [CreatedBy], [Status]) VALUES (N'ALPA', N'ALPHA Iffice Supplies', 3, N'Ms Irene Tan', N'4619928', N'4612238', N'Blk 1128, Ang Mo Kio Industrial Park #02-1108 Ang Mo Kio Street 62 Singapore 622262', N'MR-8500440-2', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Supplier] ([Id], [Name], [Priority], [ContactName], [PhoneNumber], [FaxNumber], [Address], [GstRegistrationNumber], [CreatedDate], [CreatedBy], [Status]) VALUES (N'BANE', N'BANES Shop', 1, N'Mr Loh Ah Pek', N'4781234', N'4792434', N'Blk 124, Alexandra Road #03-04 Banes Building Singapore 550315', N'MR-8200420-2', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Supplier] ([Id], [Name], [Priority], [ContactName], [PhoneNumber], [FaxNumber], [Address], [GstRegistrationNumber], [CreatedDate], [CreatedBy], [Status]) VALUES (N'CHEP', N'Cheap Stationer', 2, N'Mr Soh Kway Koh', N'3543234', N'4742434', N'Blk 34, Climenti Road #07-02 Ban Ban Soh Buildding Singapore 110525', N'null', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Supplier] ([Id], [Name], [Priority], [ContactName], [PhoneNumber], [FaxNumber], [Address], [GstRegistrationNumber], [CreatedDate], [CreatedBy], [Status]) VALUES (N'OMEG', N'OMEGA Stationery Supplier', 4, N'Mr Ronnie Ho', N'7671233', N'7671234', N'Blk 11, Hillview Avenue #03-04, Singapore 679036', N'MR-8555330-1', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[Id] [int] NOT NULL,
	[SupplierId] [nvarchar](4) NOT NULL,
	[DeliverAddress] [text] NOT NULL,
	[Attn] [nvarchar](30) NOT NULL,
	[ExpectedDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ApprovedDate] [datetime] NULL,
	[ApprovedBy] [int] NULL,
	[Status] [int] NOT NULL,
	[DeliveryOrderNumber] [nvarchar](15) NULL,
	[DeliveryDate] [datetime] NULL,
	[AcceptedBy] [int] NULL,
 CONSTRAINT [PK_purchaseorder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetails](
	[Id] [int] NOT NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[Price] [money] NOT NULL,
	[Qty] [int] NOT NULL,
	[AcceptedByQty] [int] NOT NULL,
 CONSTRAINT [PK_purchaseorderdetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (1, N'Admin', N'password', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (2, N'TR', N'password', CAST(0x00009FE400000000 AS DateTime), 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (3, N'SK', N'password', CAST(0x00009FE400000000 AS DateTime), 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (4, N'SL', N'password', CAST(0x00009FE400000000 AS DateTime), 1, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (5, N'TZ', N'password', CAST(0x00009FE400000000 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[StockCard]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockCard](
	[Id] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_stockcard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockCardDetails]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockCardDetails](
	[Id] [int] NOT NULL,
	[StockCardId] [int] NOT NULL,
	[InputFrom] [int] NOT NULL,
	[InputFromId] [nvarchar](15) NOT NULL,
	[Qty] [int] NOT NULL,
	[Balance] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_stockcarddetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (1, N'Admin', CAST(0x00009FDD00E6B680 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (2, N'Employee', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (3, N'Department Representative', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (4, N'Temporary Department Representative', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (5, N'Department Head', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (6, N'Temporart Department Head', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (7, N'Store Clerk', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (8, N'Store Manager', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Role] ([Id], [Name], [CreatedDate], [CreatedBy], [Status]) VALUES (9, N'Store Supervisor', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
/****** Object:  Table [dbo].[Retrieval]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Retrieval](
	[Id] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_retrieval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionCollectionItems]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionCollectionItems](
	[Id] [int] NOT NULL,
	[RequisitionCollectionId] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[Qty] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_requisitioncollectionitems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemPrice]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemPrice](
	[ItemId] [nvarchar](4) NOT NULL,
	[SupplierId] [nvarchar](4) NOT NULL,
	[Price] [money] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_itemprice] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC,
	[SupplierId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discrepancy]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discrepancy](
	[Id] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_discrepancy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment](
	[Id] [nvarchar](15) NOT NULL,
	[DiscrepancyId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_stockadjustment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscrepancyDetails]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscrepancyDetails](
	[Id] [int] NOT NULL,
	[DiscrepancyId] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[DiscrepancyType] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Remarks] [text] NOT NULL,
 CONSTRAINT [PK_discrepancydetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RetrievalDetails]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RetrievalDetails](
	[Id] [int] NOT NULL,
	[RetrievalId] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[DepartmentId] [nvarchar](4) NOT NULL,
	[NeededQty] [int] NOT NULL,
	[ActualQty] [int] NOT NULL,
 CONSTRAINT [PK_retrievaldetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectionMissed]    Script Date: 01/26/2012 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionMissed](
	[Id] [int] NOT NULL,
	[DepartmentId] [nvarchar](4) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_CollectionMissed] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_CollectionMissed_Department1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[CollectionMissed]  WITH CHECK ADD  CONSTRAINT [FK_CollectionMissed_Department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CollectionMissed] CHECK CONSTRAINT [FK_CollectionMissed_Department1]
GO
/****** Object:  ForeignKey [FK_CollectionMissed_Employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[CollectionMissed]  WITH CHECK ADD  CONSTRAINT [FK_CollectionMissed_Employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CollectionMissed] CHECK CONSTRAINT [FK_CollectionMissed_Employee1]
GO
/****** Object:  ForeignKey [FK_CollectionPoint_Employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[CollectionPoint]  WITH CHECK ADD  CONSTRAINT [FK_CollectionPoint_Employee1] FOREIGN KEY([ClerkId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CollectionPoint] CHECK CONSTRAINT [FK_CollectionPoint_Employee1]
GO
/****** Object:  ForeignKey [FK_department_collectionpoint1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_collectionpoint1] FOREIGN KEY([CollectionPointId])
REFERENCES [dbo].[CollectionPoint] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_collectionpoint1]
GO
/****** Object:  ForeignKey [FK_department_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee1] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee1]
GO
/****** Object:  ForeignKey [FK_department_employee2]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee2] FOREIGN KEY([HeadId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee2]
GO
/****** Object:  ForeignKey [FK_department_employee3]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee3] FOREIGN KEY([RepresentativeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee3]
GO
/****** Object:  ForeignKey [FK_department_employee4]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee4] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee4]
GO
/****** Object:  ForeignKey [FK_discrepancy_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Discrepancy]  WITH CHECK ADD  CONSTRAINT [FK_discrepancy_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Discrepancy] CHECK CONSTRAINT [FK_discrepancy_employee1]
GO
/****** Object:  ForeignKey [FK_discrepancydetails_discrepancy1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[DiscrepancyDetails]  WITH CHECK ADD  CONSTRAINT [FK_discrepancydetails_discrepancy1] FOREIGN KEY([DiscrepancyId])
REFERENCES [dbo].[Discrepancy] ([Id])
GO
ALTER TABLE [dbo].[DiscrepancyDetails] CHECK CONSTRAINT [FK_discrepancydetails_discrepancy1]
GO
/****** Object:  ForeignKey [FK_discrepancydetails_item1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[DiscrepancyDetails]  WITH CHECK ADD  CONSTRAINT [FK_discrepancydetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[DiscrepancyDetails] CHECK CONSTRAINT [FK_discrepancydetails_item1]
GO
/****** Object:  ForeignKey [FK_employee_department1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_department1]
GO
/****** Object:  ForeignKey [FK_employee_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_employee1]
GO
/****** Object:  ForeignKey [FK_employee_role1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_role1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_role1]
GO
/****** Object:  ForeignKey [FK_employee_user1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_user1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_user1]
GO
/****** Object:  ForeignKey [FK_item_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_item_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_item_employee1]
GO
/****** Object:  ForeignKey [FK_itemprice_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[ItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_itemprice_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ItemPrice] CHECK CONSTRAINT [FK_itemprice_employee1]
GO
/****** Object:  ForeignKey [FK_purchaseorder_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_employee1]
GO
/****** Object:  ForeignKey [FK_purchaseorder_employee2]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_employee2] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_employee2]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_Employee3]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee3] FOREIGN KEY([AcceptedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee3]
GO
/****** Object:  ForeignKey [FK_purchaseorder_supplier1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_supplier1] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_supplier1]
GO
/****** Object:  ForeignKey [FK_purchaseorderdetails_item1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorderdetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_purchaseorderdetails_item1]
GO
/****** Object:  ForeignKey [FK_purchaseorderdetails_purchaseorder1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorderdetails_purchaseorder1] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_purchaseorderdetails_purchaseorder1]
GO
/****** Object:  ForeignKey [FK_requisition_department1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_department1]
GO
/****** Object:  ForeignKey [FK_requisition_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_employee1]
GO
/****** Object:  ForeignKey [FK_requisition_employee2]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_employee2] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_employee2]
GO
/****** Object:  ForeignKey [FK_requisitioncollection_collectionpoint1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollection]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollection_collectionpoint1] FOREIGN KEY([CollectionPointId])
REFERENCES [dbo].[CollectionPoint] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollection] CHECK CONSTRAINT [FK_requisitioncollection_collectionpoint1]
GO
/****** Object:  ForeignKey [FK_requisitioncollection_department1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollection]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollection_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollection] CHECK CONSTRAINT [FK_requisitioncollection_department1]
GO
/****** Object:  ForeignKey [FK_requisitioncollection_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollection]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollection_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollection] CHECK CONSTRAINT [FK_requisitioncollection_employee1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectiondetails_requisition1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollectionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectiondetails_requisition1] FOREIGN KEY([RequisitionId])
REFERENCES [dbo].[Requisition] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionDetails] CHECK CONSTRAINT [FK_requisitioncollectiondetails_requisition1]
GO
/****** Object:  ForeignKey [FK_RequisitionCollectionDetails_RequisitionCollection1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollectionDetails]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionCollectionDetails_RequisitionCollection1] FOREIGN KEY([RequisitionCollectionId])
REFERENCES [dbo].[RequisitionCollection] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionDetails] CHECK CONSTRAINT [FK_RequisitionCollectionDetails_RequisitionCollection1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_employee1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_item1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_item1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_requisitioncollection1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_requisitioncollection1] FOREIGN KEY([RequisitionCollectionId])
REFERENCES [dbo].[RequisitionCollection] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_requisitioncollection1]
GO
/****** Object:  ForeignKey [FK_requisitiondetails_item1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitiondetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RequisitionDetails] CHECK CONSTRAINT [FK_requisitiondetails_item1]
GO
/****** Object:  ForeignKey [FK_requisitiondetails_requisition1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RequisitionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitiondetails_requisition1] FOREIGN KEY([RequisitionId])
REFERENCES [dbo].[Requisition] ([Id])
GO
ALTER TABLE [dbo].[RequisitionDetails] CHECK CONSTRAINT [FK_requisitiondetails_requisition1]
GO
/****** Object:  ForeignKey [FK_retrieval_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Retrieval]  WITH CHECK ADD  CONSTRAINT [FK_retrieval_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Retrieval] CHECK CONSTRAINT [FK_retrieval_employee1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_department1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_department1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_item1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_item1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_retrieval1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_retrieval1] FOREIGN KEY([RetrievalId])
REFERENCES [dbo].[Retrieval] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_retrieval1]
GO
/****** Object:  ForeignKey [FK_role_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_role_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_role_employee1]
GO
/****** Object:  ForeignKey [FK_stockadjustment_discrepancy1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_stockadjustment_discrepancy1] FOREIGN KEY([DiscrepancyId])
REFERENCES [dbo].[Discrepancy] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_stockadjustment_discrepancy1]
GO
/****** Object:  ForeignKey [FK_stockadjustment_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_stockadjustment_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_stockadjustment_employee1]
GO
/****** Object:  ForeignKey [FK_stockcard_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[StockCard]  WITH CHECK ADD  CONSTRAINT [FK_stockcard_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockCard] CHECK CONSTRAINT [FK_stockcard_employee1]
GO
/****** Object:  ForeignKey [FK_stockcard_item1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[StockCard]  WITH CHECK ADD  CONSTRAINT [FK_stockcard_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockCard] CHECK CONSTRAINT [FK_stockcard_item1]
GO
/****** Object:  ForeignKey [FK_stockcarddetails_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[StockCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_stockcarddetails_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockCardDetails] CHECK CONSTRAINT [FK_stockcarddetails_employee1]
GO
/****** Object:  ForeignKey [FK_stockcarddetails_stockcard1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[StockCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_stockcarddetails_stockcard1] FOREIGN KEY([StockCardId])
REFERENCES [dbo].[StockCard] ([Id])
GO
ALTER TABLE [dbo].[StockCardDetails] CHECK CONSTRAINT [FK_stockcarddetails_stockcard1]
GO
/****** Object:  ForeignKey [FK_supplier_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_supplier_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_supplier_employee1]
GO
/****** Object:  ForeignKey [FK_user_employee1]    Script Date: 01/26/2012 20:39:11 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_user_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_user_employee1]
GO
