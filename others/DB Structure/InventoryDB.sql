USE [Inventory]
GO
/****** Object:  User [CCMyBoss]    Script Date: 01/30/2012 12:24:07 ******/
CREATE USER [CCMyBoss] FOR LOGIN [CCMyBoss] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 01/30/2012 12:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [nvarchar](4) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ContactId] [int] NULL,
	[PhoneNumber] [nvarchar](7) NOT NULL,
	[FaxNumber] [nvarchar](7) NOT NULL,
	[HeadId] [int] NULL,
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
/****** Object:  Table [dbo].[Employee]    Script Date: 01/30/2012 12:24:07 ******/
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
	[Designation] [int] NULL,
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
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (1, 1, 1, N'ENGL', N'Mrs Pamela Kow', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (2, 1, 5, N'ENGL', N'Prof Ezra Pound', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (3, 1, 1, N'CPSC', N'Mr Wee Kian Fatt', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (4, 1, 5, N'CPSC', N'Dr. Soh Kian Wee', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (5, 1, 1, N'COMM', N'Mr Mohd. Azman', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (6, 1, 5, N'COMM', N'Dr. Chia Leow Bee', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (7, 1, 1, N'REGR', N'Ms Helen Ho', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (8, 1, 5, N'REGR', N'Mrs Low Kway Boo', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (9, 1, 1, N'ZOOL', N'Mr Peter Tan Ah Meng', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (10, 1, 5, N'ZOOL', N'Prof Tan', NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[Requisition]    Script Date: 01/30/2012 12:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requisition](
	[Id] [nvarchar](15) NOT NULL,
	[DepartmentId] [nvarchar](4) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Remarks] [text] NULL,
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
/****** Object:  Table [dbo].[CollectionPoint]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[RequisitionCollection]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[RequisitionCollectionDetails]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[Item]    Script Date: 01/30/2012 12:24:07 ******/
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
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C001', 1, N'Clips Double 1"', 50, 30, 0.0000, 1, CAST(0x00009FE800CC024E AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C002', 1, N'Clips Double 2"', 50, 30, 0.0000, 1, CAST(0x00009FE800CC02BA AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C003', 1, N'Clips Double 3/4"', 50, 30, 0.0000, 1, CAST(0x00009FE800CC02BA AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C004', 1, N'Clips Paper Large', 50, 30, 0.0000, 2, CAST(0x00009FE800CC02BA AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C005', 1, N'Clips Paper Medium', 50, 30, 0.0000, 2, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C006', 1, N'Clips Paper Small', 50, 30, 0.0000, 2, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'D001', 19, N'Diskettes 3.5 inch(HD)', 400, 200, 0.0000, 2, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E001', 2, N'Envelope Brown(3"x6")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E002', 2, N'Envelope Brown(3"x6") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E003', 2, N'Envelope Brown(5"x7")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E004', 2, N'Envelope Brown(5"x7") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E005', 2, N'Envelope Brown(3"x6")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E006', 2, N'Envelope Brown(3"x6") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E007', 2, N'Envelope Brown(5"x7")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E008', 2, N'Envelope Brown(5"x7") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E020', 3, N'Eraser(hard)', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E021', 3, N'Eraser(soft)', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E030', 4, N'Exercise Book(100 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E031', 4, N'Exercise Book(120 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E032', 4, N'Exercise Book A4 Hardcover(100 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E033', 4, N'Exercise Book A4 Hardcover(120 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E034', 4, N'Exercise Book A4 Hardcover(200 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E035', 4, N'Exercise Book A4 Hardcover(100 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E036', 4, N'Exercise Book A4 Hardcover(120 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F020', 5, N'File Separator', 100, 50, 0.0000, 4, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F021', 5, N'File-Blue Plain', 200, 100, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F022', 5, N'File-Blue with Logo', 200, 100, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F023', 5, N'File-Brown w/o Logo', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F024', 5, N'File-Brown with Logo', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F031', 5, N'Folder Plastic Blue', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F032', 5, N'Folder Plastic Clear', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F033', 5, N'Folder Plastic Green', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F034', 5, N'Folder Plastic Pink', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F035', 5, N'Folder Plastic Yellow', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H011', 6, N'Highlighter Blue', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H012', 6, N'Highlighter Green', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H013', 6, N'Highlighter Pink', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H014', 6, N'Highlighter Yellow', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H031', 7, N'Hole Puncher 2 holes', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H032', 7, N'Hole Puncher 3 holes', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H033', 7, N'Hole Puncher Adjustable', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P010', 8, N'Pad Postit Memo 1"x2"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P011', 8, N'Pad Postit Memo 1/2"x1"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P012', 8, N'Pad Postit Memo 1/2"x2"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P013', 8, N'Pad Postit Memo 2"x3"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P014', 8, N'Pad Postit Memo 2"x4"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P015', 8, N'Pad Postit Memo 2"x4"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P016', 8, N'Pad Postit Memo 3/4"x2"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P020', 9, N'Paper Photostat A3', 500, 500, 0.0000, 2, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P021', 9, N'Paper Photostat A4', 500, 500, 0.0000, 2, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P030', 6, N'Pen Ballpoint Black', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P031', 6, N'Pen Ballpoint Blue', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02CD AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P032', 6, N'Pen Ballpoint Red', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P033', 6, N'Pen Felt Tip Black', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P034', 6, N'Pen Felt Tip Blue', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P035', 6, N'Pen Felt Tip Red', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P036', 6, N'Pen Transparency Permanent', 100, 50, 0.0000, 5, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P037', 6, N'Pen Transparency Soluble', 100, 50, 0.0000, 5, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P038', 6, N'Pen Whiteboard Marker Black', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P039', 6, N'Pen Whiteboard Marker Blue', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P040', 6, N'Pen Whiteboard Marker Green', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P041', 6, N'Pen Whiteboard Marker Red', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P042', 6, N'Pencil 2B', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P043', 6, N'Pencil 2B with Eraser End', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P044', 6, N'Pencil 4H', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P045', 6, N'Pencil B', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P046', 6, N'Pencil B with Eraser End', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R001', 10, N'Ruler 6"', 50, 20, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R002', 10, N'Ruler 12"', 50, 20, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S010', 14, N'Shorthand Book (100 pg)', 100, 80, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S011', 14, N'Shorthand Book (120 pg)', 100, 80, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S012', 14, N'Shorthand Book (80 pg)', 100, 80, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S020', 15, N'Stapler No. 28', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S021', 15, N'Stapler No. 36', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S022', 15, N'Stapler No. 28', 50, 20, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S023', 15, N'Stapler No. 36', 50, 20, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S040', 12, N'Scotch Tape', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S041', 12, N'Scotch Tape Dispenser', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S100', 11, N'Scissors', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S101', 13, N'Sharpener', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T001', 16, N'Thumb Tacks Large', 10, 10, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T002', 16, N'Thumb Tacks Medium', 10, 10, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T003', 16, N'Thumb Tacks Small', 10, 10, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T020', 17, N'Transparency Blue', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T021', 17, N'Transparency Clear', 500, 400, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T022', 17, N'Transparency Green', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T023', 17, N'Transparency Red', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T024', 17, N'Transparency Reverse Blue', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T025', 17, N'Transparency Cover 3M', 500, 400, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T100', 18, N'Trays In/Out', 20, 10, 0.0000, 4, CAST(0x00009FE800CC02E0 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[RequisitionDetails]    Script Date: 01/30/2012 12:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionDetails](
	[Id] [int] NOT NULL,
	[RequisitionId] [nvarchar](15) NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[Qty] [int] NOT NULL,
	[DeliveredQty] [int] NULL,
 CONSTRAINT [PK_requisitiondetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 01/30/2012 12:24:07 ******/
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
	[AcceptedQty] [int] NULL,
 CONSTRAINT [PK_purchaseorderdetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[StockCardDetails]    Script Date: 01/30/2012 12:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockCardDetails](
	[Id] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[Description] [text] NOT NULL,
	[Qty] [int] NOT NULL,
	[Balance] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_stockcarddetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[Retrieval]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[RequisitionCollectionItems]    Script Date: 01/30/2012 12:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionCollectionItems](
	[Id] [int] NOT NULL,
	[RequisitionCollectionId] [int] NOT NULL,
	[ItemId] [nvarchar](4) NOT NULL,
	[Qty] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_requisitioncollectionitems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 01/30/2012 12:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[Id] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Message] [text] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemPrice]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[Discrepancy]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  Table [dbo].[DiscrepancyDetails]    Script Date: 01/30/2012 12:24:07 ******/
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
	[Remarks] [text] NULL,
 CONSTRAINT [PK_discrepancydetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RetrievalDetails]    Script Date: 01/30/2012 12:24:07 ******/
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
	[ActualQty] [int] NULL,
 CONSTRAINT [PK_retrievaldetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectionMissed]    Script Date: 01/30/2012 12:24:07 ******/
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
/****** Object:  ForeignKey [FK_CollectionMissed_Department1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[CollectionMissed]  WITH CHECK ADD  CONSTRAINT [FK_CollectionMissed_Department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CollectionMissed] CHECK CONSTRAINT [FK_CollectionMissed_Department1]
GO
/****** Object:  ForeignKey [FK_CollectionMissed_Employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[CollectionMissed]  WITH CHECK ADD  CONSTRAINT [FK_CollectionMissed_Employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CollectionMissed] CHECK CONSTRAINT [FK_CollectionMissed_Employee1]
GO
/****** Object:  ForeignKey [FK_CollectionPoint_Employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[CollectionPoint]  WITH CHECK ADD  CONSTRAINT [FK_CollectionPoint_Employee1] FOREIGN KEY([ClerkId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CollectionPoint] CHECK CONSTRAINT [FK_CollectionPoint_Employee1]
GO
/****** Object:  ForeignKey [FK_department_collectionpoint1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_collectionpoint1] FOREIGN KEY([CollectionPointId])
REFERENCES [dbo].[CollectionPoint] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_collectionpoint1]
GO
/****** Object:  ForeignKey [FK_department_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee1] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee1]
GO
/****** Object:  ForeignKey [FK_department_employee2]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee2] FOREIGN KEY([HeadId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee2]
GO
/****** Object:  ForeignKey [FK_department_employee3]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee3] FOREIGN KEY([RepresentativeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee3]
GO
/****** Object:  ForeignKey [FK_department_employee4]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee4] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee4]
GO
/****** Object:  ForeignKey [FK_discrepancy_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Discrepancy]  WITH CHECK ADD  CONSTRAINT [FK_discrepancy_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Discrepancy] CHECK CONSTRAINT [FK_discrepancy_employee1]
GO
/****** Object:  ForeignKey [FK_discrepancydetails_discrepancy1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[DiscrepancyDetails]  WITH CHECK ADD  CONSTRAINT [FK_discrepancydetails_discrepancy1] FOREIGN KEY([DiscrepancyId])
REFERENCES [dbo].[Discrepancy] ([Id])
GO
ALTER TABLE [dbo].[DiscrepancyDetails] CHECK CONSTRAINT [FK_discrepancydetails_discrepancy1]
GO
/****** Object:  ForeignKey [FK_discrepancydetails_item1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[DiscrepancyDetails]  WITH CHECK ADD  CONSTRAINT [FK_discrepancydetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[DiscrepancyDetails] CHECK CONSTRAINT [FK_discrepancydetails_item1]
GO
/****** Object:  ForeignKey [FK_employee_department1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_department1]
GO
/****** Object:  ForeignKey [FK_employee_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_employee1]
GO
/****** Object:  ForeignKey [FK_employee_role1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_role1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_role1]
GO
/****** Object:  ForeignKey [FK_employee_user1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_user1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_user1]
GO
/****** Object:  ForeignKey [FK_item_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_item_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_item_employee1]
GO
/****** Object:  ForeignKey [FK_itemprice_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[ItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_itemprice_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ItemPrice] CHECK CONSTRAINT [FK_itemprice_employee1]
GO
/****** Object:  ForeignKey [FK_Notification_Employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Employee1]
GO
/****** Object:  ForeignKey [FK_purchaseorder_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_employee1]
GO
/****** Object:  ForeignKey [FK_purchaseorder_employee2]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_employee2] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_employee2]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_Employee3]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee3] FOREIGN KEY([AcceptedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee3]
GO
/****** Object:  ForeignKey [FK_purchaseorder_supplier1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_supplier1] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_supplier1]
GO
/****** Object:  ForeignKey [FK_purchaseorderdetails_item1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorderdetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_purchaseorderdetails_item1]
GO
/****** Object:  ForeignKey [FK_purchaseorderdetails_purchaseorder1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorderdetails_purchaseorder1] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_purchaseorderdetails_purchaseorder1]
GO
/****** Object:  ForeignKey [FK_requisition_department1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_department1]
GO
/****** Object:  ForeignKey [FK_requisition_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_employee1]
GO
/****** Object:  ForeignKey [FK_requisition_employee2]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_employee2] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_employee2]
GO
/****** Object:  ForeignKey [FK_requisitioncollection_collectionpoint1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollection]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollection_collectionpoint1] FOREIGN KEY([CollectionPointId])
REFERENCES [dbo].[CollectionPoint] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollection] CHECK CONSTRAINT [FK_requisitioncollection_collectionpoint1]
GO
/****** Object:  ForeignKey [FK_requisitioncollection_department1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollection]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollection_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollection] CHECK CONSTRAINT [FK_requisitioncollection_department1]
GO
/****** Object:  ForeignKey [FK_requisitioncollection_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollection]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollection_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollection] CHECK CONSTRAINT [FK_requisitioncollection_employee1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectiondetails_requisition1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollectionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectiondetails_requisition1] FOREIGN KEY([RequisitionId])
REFERENCES [dbo].[Requisition] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionDetails] CHECK CONSTRAINT [FK_requisitioncollectiondetails_requisition1]
GO
/****** Object:  ForeignKey [FK_RequisitionCollectionDetails_RequisitionCollection1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollectionDetails]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionCollectionDetails_RequisitionCollection1] FOREIGN KEY([RequisitionCollectionId])
REFERENCES [dbo].[RequisitionCollection] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionDetails] CHECK CONSTRAINT [FK_RequisitionCollectionDetails_RequisitionCollection1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_employee1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_item1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_item1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_requisitioncollection1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_requisitioncollection1] FOREIGN KEY([RequisitionCollectionId])
REFERENCES [dbo].[RequisitionCollection] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_requisitioncollection1]
GO
/****** Object:  ForeignKey [FK_requisitiondetails_item1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitiondetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RequisitionDetails] CHECK CONSTRAINT [FK_requisitiondetails_item1]
GO
/****** Object:  ForeignKey [FK_requisitiondetails_requisition1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RequisitionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitiondetails_requisition1] FOREIGN KEY([RequisitionId])
REFERENCES [dbo].[Requisition] ([Id])
GO
ALTER TABLE [dbo].[RequisitionDetails] CHECK CONSTRAINT [FK_requisitiondetails_requisition1]
GO
/****** Object:  ForeignKey [FK_retrieval_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Retrieval]  WITH CHECK ADD  CONSTRAINT [FK_retrieval_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Retrieval] CHECK CONSTRAINT [FK_retrieval_employee1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_department1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_department1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_item1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_item1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_retrieval1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_retrieval1] FOREIGN KEY([RetrievalId])
REFERENCES [dbo].[Retrieval] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_retrieval1]
GO
/****** Object:  ForeignKey [FK_role_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_role_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_role_employee1]
GO
/****** Object:  ForeignKey [FK_stockadjustment_discrepancy1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_stockadjustment_discrepancy1] FOREIGN KEY([DiscrepancyId])
REFERENCES [dbo].[Discrepancy] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_stockadjustment_discrepancy1]
GO
/****** Object:  ForeignKey [FK_stockadjustment_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_stockadjustment_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_stockadjustment_employee1]
GO
/****** Object:  ForeignKey [FK_stockcarddetails_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[StockCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_stockcarddetails_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockCardDetails] CHECK CONSTRAINT [FK_stockcarddetails_employee1]
GO
/****** Object:  ForeignKey [FK_StockCardDetails_Item1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[StockCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_StockCardDetails_Item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockCardDetails] CHECK CONSTRAINT [FK_StockCardDetails_Item1]
GO
/****** Object:  ForeignKey [FK_supplier_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_supplier_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_supplier_employee1]
GO
/****** Object:  ForeignKey [FK_user_employee1]    Script Date: 01/30/2012 12:24:07 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_user_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_user_employee1]
GO
