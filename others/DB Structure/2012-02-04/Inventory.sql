USE [Inventory]
GO
/****** Object:  User [CCMyBoss]    Script Date: 02/04/2012 20:42:50 ******/
CREATE USER [CCMyBoss] FOR LOGIN [CCMyBoss] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02/04/2012 20:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NOT NULL,
	[DepartmentId] [nvarchar](4) NULL,
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
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (1, 1, 3, N'ENGL', N'Mrs Pamela Kow', 3, N'pamelakow@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (2, 2, 5, N'ENGL', N'Prof Ezra Pound', 2, N'ezrapound@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (3, 3, 3, N'CPSC', N'Mr Wee Kian Fatt', 1, N'weekianfatt@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (4, 4, 5, N'CPSC', N'Dr. Soh Kian Wee', 2, N'sohkianwee@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (5, 5, 3, N'COMM', N'Mr Mohd. Azman', 1, N'mohdazman@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (6, 6, 5, N'COMM', N'Dr. Chia Leow Bee', 2, N'chialeowbee@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (7, 7, 3, N'REGR', N'Ms Helen Ho', 1, N'helenho@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (8, 8, 5, N'REGR', N'Mrs Low Kway Boo', 2, N'lowkwayboo@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (9, 9, 3, N'ZOOL', N'Mr Peter Tan Ah Meng', 1, N'petertanahmeng@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (10, 10, 5, N'ZOOL', N'Prof Tan', 2, N'tan@LogicUniversity.com', CAST(0x00009FDD00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (11, 11, 2, N'ENGL', N'Mr Taufin', 4, N'taufin@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (12, 12, 2, N'CPSC', N'Mr Shekhar', 3, N'shekhar@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (13, 13, 2, N'COMM', N'Ms CC', 3, N'cc@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (14, 14, 2, N'CPSC', N'Mr San La', 4, N'sanlan@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (15, 15, 2, N'REGR', N'Mr KoKo', 3, N'koko@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (16, 16, 2, N'ZOOL', N'Ms Thazin', 3, N'thazin@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (17, 17, 3, N'ENGL', N'Ms Su Lai', 1, N'sulai@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (18, 18, 2, N'COMM', N'Ms Chen', 4, N'chen@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (19, 19, 2, N'REGR', N'Ms Priya', 4, N'priya@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (20, 20, 2, N'ZOOL', N'Mr Ji', 4, N'ji@LogicUniversity.com', CAST(0x00009FE900000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (21, 21, 7, N'STR', N'Ms Esther', 4, N'esther@LogicUniversity.com', CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (22, 22, 8, N'STR', N'Ms Natasha', 3, N'natasha@LogicUniversity.com', CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (23, 23, 9, N'STR', N'Mr Raja', 3, N'raja@LogicUniversity.com', CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (24, 24, 7, N'STR', N'Ms Shafina', 1, N'shafina@LogicUniversity.com', CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (25, 25, 7, N'STR', N'Mr Azman', 1, N'azman@LogicUniversity.com', CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[Employee] ([Id], [UserId], [RoleId], [DepartmentId], [Name], [Designation], [Email], [CreatedDate], [CreatedBy], [Status]) VALUES (26, 26, 1, N'STR', N'Venkat', 2, N'venkat@LogicUniversity.com', CAST(0x00009FED00000000 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[Notification]    Script Date: 02/04/2012 20:42:50 ******/
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
/****** Object:  Table [dbo].[ItemPrice]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C001', N'ALPA', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C001', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C001', N'CHEP', 1.4500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C002', N'BANE', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C002', N'CHEP', 1.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C002', N'OMEG', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C003', N'ALPA', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C003', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C003', N'CHEP', 1.4500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C004', N'BANE', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C004', N'CHEP', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C004', N'OMEG', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C005', N'ALPA', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C005', N'BANE', 2.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C005', N'CHEP', 2.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C006', N'BANE', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C006', N'CHEP', 3.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'C006', N'OMEG', 3.6500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'D001', N'ALPA', 10.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'D001', N'BANE', 11.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'D001', N'CHEP', 10.5500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E001', N'BANE', 0.0600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E001', N'CHEP', 0.0500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E001', N'OMEG', 0.0800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E002', N'ALPA', 0.0500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E002', N'BANE', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E002', N'CHEP', 0.1300, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E003', N'BANE', 0.0500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E003', N'CHEP', 0.0600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E003', N'OMEG', 0.0800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E004', N'ALPA', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E004', N'BANE', 0.1200, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E004', N'CHEP', 0.1500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E005', N'BANE', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E005', N'CHEP', 0.1100, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E005', N'OMEG', 0.1500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E006', N'ALPA', 0.0500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E006', N'BANE', 0.0400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E006', N'CHEP', 0.0500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E007', N'BANE', 0.0500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E007', N'CHEP', 0.0700, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E007', N'OMEG', 0.0900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E008', N'ALPA', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E008', N'BANE', 0.0900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E008', N'CHEP', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E020', N'BANE', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E020', N'CHEP', 0.1200, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E020', N'OMEG', 0.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E021', N'ALPA', 0.4800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E021', N'BANE', 0.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E021', N'CHEP', 0.5500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E030', N'BANE', 0.4800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E030', N'CHEP', 0.5200, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E030', N'OMEG', 0.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E031', N'ALPA', 0.2400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E031', N'BANE', 0.2500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E031', N'CHEP', 0.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E032', N'BANE', 0.2400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E032', N'CHEP', 0.2500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E032', N'OMEG', 0.2700, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E033', N'ALPA', 0.5400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E033', N'BANE', 0.5600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E033', N'CHEP', 0.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E034', N'BANE', 0.5400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E034', N'CHEP', 0.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E034', N'OMEG', 0.5500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E035', N'ALPA', 0.3200, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E035', N'BANE', 0.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E035', N'CHEP', 0.3500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E036', N'BANE', 0.3200, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E036', N'CHEP', 0.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'E036', N'OMEG', 0.3400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F020', N'ALPA', 12.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F020', N'BANE', 12.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F020', N'CHEP', 11.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F021', N'BANE', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F021', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F021', N'OMEG', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F022', N'ALPA', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F022', N'BANE', 1.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F022', N'CHEP', 1.2800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F023', N'BANE', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F023', N'CHEP', 1.2500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F023', N'OMEG', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F024', N'ALPA', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F024', N'BANE', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F024', N'CHEP', 1.2500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F031', N'BANE', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F031', N'CHEP', 1.2500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F031', N'OMEG', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F032', N'ALPA', 0.9900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F032', N'BANE', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F032', N'CHEP', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F033', N'BANE', 0.9900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F033', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F033', N'OMEG', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F034', N'ALPA', 0.9900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F034', N'BANE', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F034', N'CHEP', 1.2000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F035', N'BANE', 0.9900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F035', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
GO
print 'Processed 100 total records'
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'F035', N'OMEG', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H011', N'ALPA', 10.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H011', N'BANE', 9.9000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H011', N'CHEP', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H012', N'BANE', 10.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H012', N'CHEP', 9.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H012', N'OMEG', 9.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H013', N'ALPA', 12.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H013', N'BANE', 11.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H013', N'CHEP', 11.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H014', N'BANE', 12.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H014', N'CHEP', 12.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H014', N'OMEG', 11.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H031', N'ALPA', 14.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H031', N'BANE', 13.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H031', N'CHEP', 14.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H032', N'BANE', 14.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H032', N'CHEP', 14.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H032', N'OMEG', 13.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H033', N'ALPA', 16.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H033', N'BANE', 15.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'H033', N'CHEP', 15.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P010', N'ALPA', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P010', N'BANE', 1.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P010', N'CHEP', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P011', N'BANE', 0.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P011', N'CHEP', 0.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P011', N'OMEG', 0.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P012', N'ALPA', 0.8800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P012', N'BANE', 0.7500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P012', N'OMEG', 0.7600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P013', N'ALPA', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P013', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P013', N'CHEP', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P014', N'BANE', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P014', N'CHEP', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P014', N'OMEG', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P015', N'ALPA', 2.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P015', N'BANE', 2.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P015', N'OMEG', 2.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P016', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P016', N'BANE', 1.9000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P016', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P020', N'BANE', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P020', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P020', N'OMEG', 0.9800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P021', N'ALPA', 1.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P021', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P021', N'OMEG', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P030', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P030', N'BANE', 1.9800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P030', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P031', N'BANE', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P031', N'CHEP', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P031', N'OMEG', 2.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P032', N'ALPA', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P032', N'BANE', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P032', N'OMEG', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P033', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P033', N'BANE', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P033', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P034', N'BANE', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P034', N'CHEP', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P034', N'OMEG', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P035', N'ALPA', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P035', N'BANE', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P035', N'OMEG', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P036', N'ALPA', 2.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P036', N'BANE', 2.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P036', N'CHEP', 2.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P037', N'BANE', 2.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P037', N'CHEP', 2.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P037', N'OMEG', 2.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P038', N'ALPA', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P038', N'BANE', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P038', N'OMEG', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P039', N'ALPA', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P039', N'BANE', 3.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P039', N'CHEP', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P040', N'BANE', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P040', N'CHEP', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P040', N'OMEG', 2.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P041', N'ALPA', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P041', N'BANE', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P041', N'OMEG', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P042', N'ALPA', 0.9800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P042', N'BANE', 0.9900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P042', N'CHEP', 0.9900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P043', N'BANE', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P043', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P043', N'OMEG', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P044', N'ALPA', 0.8900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P044', N'BANE', 0.8800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P044', N'OMEG', 0.8900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P045', N'ALPA', 0.9000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P045', N'BANE', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P045', N'CHEP', 0.9100, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P046', N'BANE', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P046', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'P046', N'OMEG', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R001', N'ALPA', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
GO
print 'Processed 200 total records'
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R001', N'BANE', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R001', N'CHEP', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R002', N'ALPA', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R002', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'R002', N'OMEG', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S010', N'ALPA', 1.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S010', N'BANE', 0.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S010', N'OMEG', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S011', N'ALPA', 0.5500, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S011', N'BANE', 0.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S011', N'CHEP', 0.5600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S012', N'BANE', 0.4100, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S012', N'CHEP', 0.4000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S012', N'OMEG', 0.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S020', N'ALPA', 1.4000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S020', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S020', N'OMEG', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S021', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S021', N'BANE', 1.9000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S021', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S022', N'BANE', 3.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S022', N'CHEP', 3.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S022', N'OMEG', 2.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S023', N'ALPA', 4.3000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S023', N'BANE', 4.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S023', N'OMEG', 4.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S040', N'ALPA', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S040', N'BANE', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S040', N'OMEG', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S041', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S041', N'BANE', 1.9000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S041', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S100', N'BANE', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S100', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S100', N'OMEG', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S101', N'BANE', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S101', N'CHEP', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'S101', N'OMEG', 1.4000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T001', N'ALPA', 1.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T001', N'BANE', 1.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T001', N'CHEP', 1.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T002', N'BANE', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T002', N'CHEP', 1.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T002', N'OMEG', 0.9800, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T003', N'ALPA', 1.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T003', N'BANE', 0.8000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T003', N'OMEG', 0.9000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T020', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T020', N'BANE', 1.8900, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T020', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T021', N'BANE', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T021', N'CHEP', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T021', N'OMEG', 2.2100, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T022', N'ALPA', 1.8400, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T022', N'BANE', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T022', N'OMEG', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T023', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T023', N'BANE', 2.3600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T023', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T024', N'BANE', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T024', N'CHEP', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T024', N'OMEG', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T025', N'ALPA', 2.4600, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T025', N'BANE', 2.5000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T025', N'OMEG', 2.6000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T100', N'ALPA', 2.0000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T100', N'BANE', 1.8700, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
INSERT [dbo].[ItemPrice] ([ItemId], [SupplierId], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (N'T100', N'CHEP', 2.1000, CAST(0x00009FEA00000000 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[Item]    Script Date: 02/04/2012 20:42:50 ******/
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
	[Bin] [nvarchar](4) NULL,
 CONSTRAINT [PK_item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'C001', 1, N'Clips Double 1"', 50, 30, 0.0000, 1, CAST(0x00009FE800CC024E AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'C002', 1, N'Clips Double 2"', 50, 30, 100.0000, 1, CAST(0x00009FE800CC02BA AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'C003', 1, N'Clips Double 3/4"', 50, 30, 0.0000, 1, CAST(0x00009FE800CC02BA AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'C004', 1, N'Clips Paper Large', 50, 30, 0.0000, 2, CAST(0x00009FE800CC02BA AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'C005', 1, N'Clips Paper Medium', 50, 30, 0.0000, 2, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'C006', 1, N'Clips Paper Small', 50, 30, 0.0000, 2, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'D001', 19, N'Diskettes 3.5 inch(HD)', 400, 200, 0.0000, 2, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E001', 2, N'Envelope Brown(3"x6")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E002', 2, N'Envelope Brown(3"x6") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E003', 2, N'Envelope Brown(5"x7")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E004', 2, N'Envelope Brown(5"x7") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E005', 2, N'Envelope White(3"x6")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E006', 2, N'Envelope White(3"x6") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E007', 2, N'Envelope White(5"x7")', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E008', 2, N'Envelope White(5"x7") w/Window', 600, 400, 0.0000, 3, CAST(0x00009FE800CC02BF AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E020', 3, N'Eraser(hard)', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E021', 3, N'Eraser(soft)', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E030', 4, N'Exercise Book(100 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E031', 4, N'Exercise Book(120 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E032', 4, N'Exercise Book A4 Hardcover(100 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E033', 4, N'Exercise Book A4 Hardcover(120 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E034', 4, N'Exercise Book A4 Hardcover(200 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E035', 4, N'Exercise Book A4 Hardcover(100 pg)', 100, 50, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'E036', 4, N'Exercise Book A4 Hardcover(120 pg)', 100, 50, 300.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F020', 5, N'File Separator', 100, 50, 0.0000, 4, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F021', 5, N'File-Blue Plain', 200, 100, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F022', 5, N'File-Blue with Logo', 200, 100, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F023', 5, N'File-Brown w/o Logo', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F024', 5, N'File-Brown with Logo', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F031', 5, N'Folder Plastic Blue', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F032', 5, N'Folder Plastic Clear', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F033', 5, N'Folder Plastic Green', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F034', 5, N'Folder Plastic Pink', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'F035', 5, N'Folder Plastic Yellow', 200, 150, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H011', 6, N'Highlighter Blue', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H012', 6, N'Highlighter Green', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H013', 6, N'Highlighter Pink', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H014', 6, N'Highlighter Yellow', 100, 80, 0.0000, 2, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H031', 7, N'Hole Puncher 2 holes', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H032', 7, N'Hole Puncher 3 holes', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02C9 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'H033', 7, N'Hole Puncher Adjustable', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P010', 8, N'Pad Postit Memo 1"x2"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P011', 8, N'Pad Postit Memo 1/2"x1"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P012', 8, N'Pad Postit Memo 1/2"x2"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P013', 8, N'Pad Postit Memo 2"x3"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P014', 8, N'Pad Postit Memo 2"x4"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P015', 8, N'Pad Postit Memo 2"x5"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P016', 8, N'Pad Postit Memo 3/4"x2"', 100, 60, 0.0000, 5, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P020', 9, N'Paper Photostat A3', 500, 500, 0.0000, 2, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P021', 9, N'Paper Photostat A4', 500, 500, 0.0000, 2, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P030', 6, N'Pen Ballpoint Black', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P031', 6, N'Pen Ballpoint Blue', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02CD AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P032', 6, N'Pen Ballpoint Red', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P033', 6, N'Pen Felt Tip Black', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P034', 6, N'Pen Felt Tip Blue', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P035', 6, N'Pen Felt Tip Red', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P036', 6, N'Pen Transparency Permanent', 100, 50, 0.0000, 5, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P037', 6, N'Pen Transparency Soluble', 100, 50, 0.0000, 5, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P038', 6, N'Pen Whiteboard Marker Black', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P039', 6, N'Pen Whiteboard Marker Blue', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P040', 6, N'Pen Whiteboard Marker Green', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P041', 6, N'Pen Whiteboard Marker Red', 100, 50, 0.0000, 2, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P042', 6, N'Pencil 2B', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D2 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P043', 6, N'Pencil 2B with Eraser End', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P044', 6, N'Pencil 4H', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P045', 6, N'Pencil B', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'P046', 6, N'Pencil B with Eraser End', 100, 50, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'R001', 10, N'Ruler 6"', 50, 20, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'R002', 10, N'Ruler 12"', 50, 20, 0.0000, 1, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S010', 14, N'Shorthand Book (100 pg)', 100, 80, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S011', 14, N'Shorthand Book (120 pg)', 100, 80, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S012', 14, N'Shorthand Book (80 pg)', 100, 80, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S020', 15, N'Stapler No. 28', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S021', 15, N'Stapler No. 36', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S022', 15, N'Stapler No. 28', 50, 20, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S023', 15, N'Stapler No. 36', 50, 20, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S040', 12, N'Scotch Tape', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S041', 12, N'Scotch Tape Dispenser', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S100', 11, N'Scissors', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'S101', 13, N'Sharpener', 50, 20, 0.0000, 3, CAST(0x00009FE800CC02D7 AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T001', 16, N'Thumb Tacks Large', 10, 10, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T002', 16, N'Thumb Tacks Medium', 10, 10, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T003', 16, N'Thumb Tacks Small', 10, 10, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T020', 17, N'Transparency Blue', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T021', 17, N'Transparency Clear', 500, 400, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T022', 17, N'Transparency Green', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T023', 17, N'Transparency Red', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T024', 17, N'Transparency Reverse Blue', 100, 200, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T025', 17, N'Transparency Cover 3M', 500, 400, 0.0000, 2, CAST(0x00009FE800CC02DB AS DateTime), 1, 1, NULL)
INSERT [dbo].[Item] ([Id], [ItemCategoryId], [Description], [ReorderLevel], [ReorderQty], [Cost], [UnitOfMeasureId], [CreatedDate], [CreatedBy], [Status], [Bin]) VALUES (N'T100', 18, N'Trays In/Out', 20, 10, 0.0000, 4, CAST(0x00009FE800CC02E0 AS DateTime), 1, 1, NULL)
/****** Object:  Table [dbo].[Discrepancy]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[Discrepancy] ([Id], [CreatedDate], [CreatedBy], [Status]) VALUES (1, CAST(0x00009D1100000000 AS DateTime), 1, 1)
INSERT [dbo].[Discrepancy] ([Id], [CreatedDate], [CreatedBy], [Status]) VALUES (2, CAST(0x00009FEC00000000 AS DateTime), 2, 1)
INSERT [dbo].[Discrepancy] ([Id], [CreatedDate], [CreatedBy], [Status]) VALUES (3, CAST(0x00009FED00000000 AS DateTime), 3, 1)
/****** Object:  Table [dbo].[DiscrepancyDetails]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[DiscrepancyDetails] ([Id], [DiscrepancyId], [ItemId], [DiscrepancyType], [Qty], [Remarks]) VALUES (1, 1, N'C001', 1, 10, N'Testing')
INSERT [dbo].[DiscrepancyDetails] ([Id], [DiscrepancyId], [ItemId], [DiscrepancyType], [Qty], [Remarks]) VALUES (2, 1, N'C002', 1, 20, N'Testing')
INSERT [dbo].[DiscrepancyDetails] ([Id], [DiscrepancyId], [ItemId], [DiscrepancyType], [Qty], [Remarks]) VALUES (3, 2, N'C003', 2, 11, N'Tesing')
INSERT [dbo].[DiscrepancyDetails] ([Id], [DiscrepancyId], [ItemId], [DiscrepancyType], [Qty], [Remarks]) VALUES (4, 2, N'C004', 2, 21, N'Testing')
INSERT [dbo].[DiscrepancyDetails] ([Id], [DiscrepancyId], [ItemId], [DiscrepancyType], [Qty], [Remarks]) VALUES (5, 3, N'C005', 1, 12, N'Testing')
INSERT [dbo].[DiscrepancyDetails] ([Id], [DiscrepancyId], [ItemId], [DiscrepancyType], [Qty], [Remarks]) VALUES (6, 3, N'C006', 1, 22, N'Testing')
/****** Object:  Table [dbo].[CollectionPoint]    Script Date: 02/04/2012 20:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionPoint](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Time] [time](0) NOT NULL,
	[ClerkId] [int] NULL,
 CONSTRAINT [PK_collectionpoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CollectionPoint] ([Id], [Name], [Time], [ClerkId]) VALUES (1, N'Administration Building', CAST(0x0098850000000000 AS Time), 21)
INSERT [dbo].[CollectionPoint] ([Id], [Name], [Time], [ClerkId]) VALUES (2, N'Management School', CAST(0x00B09A0000000000 AS Time), 21)
INSERT [dbo].[CollectionPoint] ([Id], [Name], [Time], [ClerkId]) VALUES (3, N'Medical School', CAST(0x0098850000000000 AS Time), 22)
INSERT [dbo].[CollectionPoint] ([Id], [Name], [Time], [ClerkId]) VALUES (4, N'Engineering School', CAST(0x00B09A0000000000 AS Time), 22)
INSERT [dbo].[CollectionPoint] ([Id], [Name], [Time], [ClerkId]) VALUES (5, N'Science School', CAST(0x0098850000000000 AS Time), 23)
INSERT [dbo].[CollectionPoint] ([Id], [Name], [Time], [ClerkId]) VALUES (6, N'University Hospital', CAST(0x00B09A0000000000 AS Time), 23)
/****** Object:  Table [dbo].[Department]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'COMM', N'Commerce Dept', 5, N'8741284', N'8921256', 6, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 3)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'CPSC', N'Computer Science', 3, N'8901235', N'8921457', 4, 4, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 3)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'ENGL', N'English Dept', 1, N'8742234', N'8921456', 2, 2, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 3)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'REGR', N'Registrar Dept', 7, N'8901266', N'8921465', 8, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 4)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'STR', N'Store Dept', 25, N'8506681', N'8506618', 8, NULL, NULL, CAST(0x00009FEA00000000 AS DateTime), 1, 3)
INSERT [dbo].[Department] ([Id], [Name], [ContactId], [PhoneNumber], [FaxNumber], [HeadId], [CollectionPointId], [RepresentativeId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'ZOOL', N'Zoology Dept', 9, N'8901266', N'8921465', 10, NULL, NULL, CAST(0x00009FDD00000000 AS DateTime), 1, 2)
/****** Object:  Table [dbo].[CollectionMissed]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (1, N'ENGL', 1, CAST(0x00009FCC00000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (2, N'COMM', 2, CAST(0x00009FCD00000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (3, N'COMM', 2, CAST(0x00009FCD00000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (4, N'COMM', 2, CAST(0x00009FCE00000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (5, N'CPSC', 3, CAST(0x00009FF200000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (6, N'COMM', 1, CAST(0x00009FEC00000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (7, N'COMM', 1, CAST(0x00009FEC00000000 AS DateTime), 2)
INSERT [dbo].[CollectionMissed] ([Id], [DepartmentId], [CreatedBy], [CreatedDate], [Status]) VALUES (8, N'COMM', 1, CAST(0x00009FEC00000000 AS DateTime), 2)
/****** Object:  Table [dbo].[Supplier]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[Supplier] ([Id], [Name], [Priority], [ContactName], [PhoneNumber], [FaxNumber], [Address], [GstRegistrationNumber], [CreatedDate], [CreatedBy], [Status]) VALUES (N'CHEP', N'CHEAP Stationer', 2, N'Mr Soh Kway Koh', N'3543234', N'4742434', N'Blk 34, Climenti Road #07-02 Ban Ban Soh Buildding Singapore 110525', N'null', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
INSERT [dbo].[Supplier] ([Id], [Name], [Priority], [ContactName], [PhoneNumber], [FaxNumber], [Address], [GstRegistrationNumber], [CreatedDate], [CreatedBy], [Status]) VALUES (N'OMEG', N'OMEGA Stationery Supplier', 4, N'Mr Ronnie Ho', N'7671233', N'7671234', N'Blk 11, Hillview Avenue #03-04, Singapore 679036', N'MR-8555330-1', CAST(0x00009FDD00000000 AS DateTime), NULL, 1)
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 02/04/2012 20:42:50 ******/
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
	[Remarks] [text] NULL,
 CONSTRAINT [PK_purchaseorder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [DeliverAddress], [Attn], [ExpectedDate], [CreatedDate], [CreatedBy], [ApprovedDate], [ApprovedBy], [Status], [DeliveryOrderNumber], [DeliveryDate], [AcceptedBy], [Remarks]) VALUES (200000068, N'ALPA', N'Clementi', N'Thazin', CAST(0x00009FF200000000 AS DateTime), CAST(0x00009FEC00000000 AS DateTime), 1, CAST(0x00009FEE00000000 AS DateTime), 1, 1, N'333333', CAST(0x00009FED01175315 AS DateTime), 26, NULL)
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [DeliverAddress], [Attn], [ExpectedDate], [CreatedDate], [CreatedBy], [ApprovedDate], [ApprovedBy], [Status], [DeliveryOrderNumber], [DeliveryDate], [AcceptedBy], [Remarks]) VALUES (200000069, N'ALPA', N'Commonwealth', N'Sanla', CAST(0x0000A0C600000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), 1, CAST(0x00009FED00000000 AS DateTime), 1, 1, N'1111', CAST(0x00009FED01272229 AS DateTime), 26, NULL)
/****** Object:  Table [dbo].[StockCardDetails]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (1, N'C001', N'Supplier-ALPA', 100, 100, CAST(0x00009FEC00000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (2, N'C001', N'Supplier-BANE', 150, 250, CAST(0x00009FED00000000 AS DateTime), 2, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (3, N'C001', N'English Department', -50, 200, CAST(0x00009FEE00000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (4, N'C001', N'Stock Adjustment SSS/1/12', -30, 170, CAST(0x00009FF000000000 AS DateTime), 2, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (5, N'C001', N'Supplier-CHEP', 200, 370, CAST(0x0000A00900000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (6, N'C002', N'Supplier-BANE', 200, 200, CAST(0x00009FED00000000 AS DateTime), 2, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (7, N'C002', N'Administration Department', -90, 110, CAST(0x00009FFE00000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (8, N'C002', N'Supplier-CHEP', 200, 310, CAST(0x0000A00C00000000 AS DateTime), 2, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (9, N'C002', N'Stock Adjustment SSS/2/12', 300, 10, CAST(0x0000A01A00000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (10, N'F021', N'Supplier-BANE', 100, 100, CAST(0x00009FF300000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (11, N'F021', N'Stock Adjustment SSS/3/12', 50, 150, CAST(0x0000A00700000000 AS DateTime), 2, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (12, N'E036', N'Supplier-BANE', 20, 20, CAST(0x0000A01800000000 AS DateTime), 2, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (13, N'E036', N'Supplier-OMEG', 20, 40, CAST(0x0000A02300000000 AS DateTime), 1, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (14, N'E036', N'Supplier-ALPA', 2, 42, CAST(0x00009FED01133CA9 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (15, N'C002', N'Supplier-ALPA', 1, 11, CAST(0x00009FED01133D65 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (16, N'E036', N'Supplier-ALPA', 2, 44, CAST(0x00009FED0116394C AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (17, N'C002', N'Supplier-ALPA', 1, 12, CAST(0x00009FED01163962 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (18, N'E036', N'Supplier-ALPA', 1, 45, CAST(0x00009FED0117149A AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (19, N'C002', N'Supplier-ALPA', 1, 13, CAST(0x00009FED0117153C AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (20, N'C004', N'Supplier-ALPA', 5, 5, CAST(0x00009FED01171550 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (21, N'C005', N'Supplier-ALPA', 6, 6, CAST(0x00009FED01171561 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (22, N'C006', N'Supplier-ALPA', 9, 9, CAST(0x00009FED01171574 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (23, N'E036', N'Supplier-ALPA', 1, 46, CAST(0x00009FED0117531C AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (24, N'C002', N'Supplier-ALPA', 1, 14, CAST(0x00009FED01175332 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (25, N'C004', N'Supplier-ALPA', 5, 10, CAST(0x00009FED01175348 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (26, N'C005', N'Supplier-ALPA', 6, 12, CAST(0x00009FED0117535F AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (27, N'C006', N'Supplier-ALPA', 9, 18, CAST(0x00009FED01175378 AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (28, N'E036', N'Supplier-ALPA', 3, 49, CAST(0x00009FED012722EC AS DateTime), 26, 1)
INSERT [dbo].[StockCardDetails] ([Id], [ItemId], [Description], [Qty], [Balance], [CreatedDate], [CreatedBy], [Status]) VALUES (29, N'C002', N'Supplier-ALPA', 5, 19, CAST(0x00009FED01272312 AS DateTime), 26, 1)
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 02/04/2012 20:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment](
	[Id] [nvarchar](15) NOT NULL,
	[DiscrepancyId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_stockadjustment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[StockAdjustment] ([Id], [DiscrepancyId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'002/1/12', 1, CAST(0x00009FEA00000000 AS DateTime), 2, 1)
INSERT [dbo].[StockAdjustment] ([Id], [DiscrepancyId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'002/2/12', 2, CAST(0x00009FEB00000000 AS DateTime), 3, 1)
INSERT [dbo].[StockAdjustment] ([Id], [DiscrepancyId], [CreatedDate], [CreatedBy], [Status]) VALUES (N'002/3/12', 3, CAST(0x00009FEE00000000 AS DateTime), 4, 1)
/****** Object:  Table [dbo].[Role]    Script Date: 02/04/2012 20:42:50 ******/
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
/****** Object:  Table [dbo].[Retrieval]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[Retrieval] ([Id], [CreatedDate], [CreatedBy], [Status]) VALUES (1, CAST(0x00009FED00000000 AS DateTime), 2, 1)
INSERT [dbo].[Retrieval] ([Id], [CreatedDate], [CreatedBy], [Status]) VALUES (2, CAST(0x00009FEE00000000 AS DateTime), 3, 1)
/****** Object:  Table [dbo].[RetrievalDetails]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[RetrievalDetails] ([Id], [RetrievalId], [ItemId], [DepartmentId], [NeededQty], [ActualQty]) VALUES (1, 1, N'C001', N'COMM', 30, 25)
INSERT [dbo].[RetrievalDetails] ([Id], [RetrievalId], [ItemId], [DepartmentId], [NeededQty], [ActualQty]) VALUES (2, 1, N'C002', N'CPSC', 20, 12)
/****** Object:  Table [dbo].[Requisition]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/1/12', N'COMM', 5, N'', 6, CAST(0x00009EDB00000000 AS DateTime), CAST(0x00009ED700000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/10/12', N'COMM', 5, N'', 6, CAST(0x00009FEC00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/11/12', N'COMM', 13, N'', NULL, NULL, CAST(0x00009FED01528735 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/2/12', N'COMM', 13, N'', 6, CAST(0x00009EF700000000 AS DateTime), CAST(0x00009EF600000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/3/12', N'COMM', 18, N'', 6, CAST(0x00009F1A00000000 AS DateTime), CAST(0x00009F1600000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/4/12', N'COMM', 5, N'', 6, CAST(0x00009F3600000000 AS DateTime), CAST(0x00009F3500000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/5/12', N'COMM', 13, N'test', 6, CAST(0x00009F5900000000 AS DateTime), CAST(0x00009F5500000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/6/12', N'COMM', 18, N'', 6, CAST(0x00009F7500000000 AS DateTime), CAST(0x00009F7400000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/7/12', N'COMM', 5, N'', 6, CAST(0x00009F9800000000 AS DateTime), CAST(0x00009F9400000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/8/12', N'COMM', 13, N'', 6, CAST(0x00009FB400000000 AS DateTime), CAST(0x00009FB300000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'COMM/9/12', N'COMM', 18, N'haha', 1, CAST(0x00009FEB011EEA91 AS DateTime), CAST(0x00009FD300000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/1/12', N'CPSC', 3, N'', 4, CAST(0x00009EE200000000 AS DateTime), CAST(0x00009EE000000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/10/12', N'CPSC', 3, N'', 4, CAST(0x00009FEC00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/2/12', N'CPSC', 12, N'', 1, CAST(0x00009FEB012197DC AS DateTime), CAST(0x00009F0100000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/3/12', N'CPSC', 14, N'test', 4, CAST(0x00009F2100000000 AS DateTime), CAST(0x00009F1F00000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/4/12', N'CPSC', 3, N'hihi', 1, CAST(0x00009FEB011EEAFD AS DateTime), CAST(0x00009F4000000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/5/12', N'CPSC', 12, N'haha', 1, CAST(0x00009FEB0121ABE4 AS DateTime), CAST(0x00009F5F00000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/6/12', N'CPSC', 14, N'', 1, CAST(0x00009FEB01219848 AS DateTime), CAST(0x00009F7E00000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/7/12', N'CPSC', 3, N'boss', 1, CAST(0x00009FEC0110F278 AS DateTime), CAST(0x00009F9E00000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/8/12', N'CPSC', 12, N'', 1, CAST(0x00009FEC0110FACE AS DateTime), CAST(0x00009FBE00000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'CPSC/9/12', N'CPSC', 14, N'', 1, CAST(0x00009FEC013F9F65 AS DateTime), CAST(0x00009FDD00000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/1/12', N'ENGL', 1, N'', 1, CAST(0x00009FEC013FC212 AS DateTime), CAST(0x00009EE900000000 AS DateTime), 4)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/10/12', N'ENGL', 1, N'', 1, CAST(0x00009FED00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/11/12', N'ENGL', 11, N'', NULL, NULL, CAST(0x00009FED0126411E AS DateTime), 0)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/2/12', N'ENGL', 11, N'', 1, CAST(0x00009FED00DAF928 AS DateTime), CAST(0x00009F0A00000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/3/12', N'ENGL', 17, N'', 1, CAST(0x00009FED00DA46B3 AS DateTime), CAST(0x00009F2800000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/4/12', N'ENGL', 1, N'', 1, CAST(0x00009FED00DB9D84 AS DateTime), CAST(0x00009F4900000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/5/12', N'ENGL', 11, N'', 1, CAST(0x00009FED00DA46BA AS DateTime), CAST(0x00009F6A00000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/6/12', N'ENGL', 17, N'', 1, CAST(0x00009FED00DAF92D AS DateTime), CAST(0x00009F8800000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/7/12', N'ENGL', 1, N'', 2, CAST(0x00009FED0154C9F8 AS DateTime), CAST(0x00009FA900000000 AS DateTime), 2)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/8/12', N'ENGL', 11, N'', 1, CAST(0x00009FED00DBBE62 AS DateTime), CAST(0x00009FC700000000 AS DateTime), 3)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ENGL/9/12', N'ENGL', 17, NULL, 2, CAST(0x00009FEC00000000 AS DateTime), CAST(0x00009FE800000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/1/12', N'REGR', 7, N'', 2, CAST(0x00009FED0154C9FA AS DateTime), CAST(0x00009ED700000000 AS DateTime), 2)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/10/12', N'REGR', 7, NULL, 8, CAST(0x00009FEC00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/2/12', N'REGR', 15, NULL, 8, CAST(0x00009EF700000000 AS DateTime), CAST(0x00009EF600000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/3/12', N'REGR', 19, NULL, 8, CAST(0x00009F1A00000000 AS DateTime), CAST(0x00009F1600000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/4/12', N'REGR', 7, NULL, 8, CAST(0x00009F3600000000 AS DateTime), CAST(0x00009F3500000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/5/12', N'REGR', 15, NULL, 8, CAST(0x00009F5900000000 AS DateTime), CAST(0x00009F5500000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/6/12', N'REGR', 19, NULL, 8, CAST(0x00009F7500000000 AS DateTime), CAST(0x00009F7400000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/7/12', N'REGR', 7, NULL, 8, CAST(0x00009F9800000000 AS DateTime), CAST(0x00009F9400000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/8/12', N'REGR', 15, NULL, 8, CAST(0x00009FB400000000 AS DateTime), CAST(0x00009FB300000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'REGR/9/12', N'REGR', 19, NULL, 8, CAST(0x00009FD700000000 AS DateTime), CAST(0x00009FD300000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/1/12', N'ZOOL', 9, NULL, 10, CAST(0x00009EE200000000 AS DateTime), CAST(0x00009EE000000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/10/12', N'ZOOL', 9, NULL, 10, CAST(0x00009FEC00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/2/12', N'ZOOL', 16, NULL, 10, CAST(0x00009F0500000000 AS DateTime), CAST(0x00009F0100000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/3/12', N'ZOOL', 20, NULL, 10, CAST(0x00009F2100000000 AS DateTime), CAST(0x00009F1F00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/4/12', N'ZOOL', 9, NULL, 10, CAST(0x00009F4400000000 AS DateTime), CAST(0x00009F4000000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/5/12', N'ZOOL', 16, NULL, 10, CAST(0x00009F6000000000 AS DateTime), CAST(0x00009F5F00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/6/12', N'ZOOL', 20, NULL, 10, CAST(0x00009F8300000000 AS DateTime), CAST(0x00009F7F00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/7/12', N'ZOOL', 9, NULL, 10, CAST(0x00009F9F00000000 AS DateTime), CAST(0x00009F9E00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/8/12', N'ZOOL', 16, NULL, 10, CAST(0x00009FC200000000 AS DateTime), CAST(0x00009FBE00000000 AS DateTime), 1)
INSERT [dbo].[Requisition] ([Id], [DepartmentId], [EmployeeId], [Remarks], [ApprovedBy], [ApprovedDate], [CreatedDate], [Status]) VALUES (N'ZOOL/9/12', N'ZOOL', 20, NULL, 10, CAST(0x00009FDE00000000 AS DateTime), CAST(0x00009FDD00000000 AS DateTime), 1)
/****** Object:  Table [dbo].[RequisitionDetails]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (1, N'COMM/1/12', N'C001', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (2, N'COMM/1/12', N'C002', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (3, N'COMM/1/12', N'C003', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (4, N'COMM/1/12', N'C004', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (5, N'COMM/1/12', N'C005', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (6, N'COMM/2/12', N'C006', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (7, N'COMM/2/12', N'D001', 40, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (8, N'COMM/2/12', N'E001', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (9, N'COMM/2/12', N'E002', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (10, N'COMM/2/12', N'E003', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (11, N'COMM/3/12', N'E004', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (12, N'COMM/3/12', N'E005', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (13, N'COMM/3/12', N'E006', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (14, N'COMM/3/12', N'E007', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (15, N'COMM/3/12', N'E008', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (16, N'COMM/4/12', N'E020', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (17, N'COMM/4/12', N'E021', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (18, N'COMM/4/12', N'E030', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (19, N'COMM/4/12', N'E031', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (20, N'COMM/4/12', N'E032', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (21, N'COMM/5/12', N'E033', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (22, N'COMM/5/12', N'E034', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (23, N'COMM/5/12', N'E035', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (24, N'COMM/5/12', N'E036', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (25, N'COMM/5/12', N'F020', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (26, N'COMM/6/12', N'F021', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (27, N'COMM/6/12', N'F022', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (28, N'COMM/6/12', N'F023', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (29, N'COMM/6/12', N'F024', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (30, N'COMM/6/12', N'F031', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (31, N'COMM/7/12', N'F032', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (32, N'COMM/7/12', N'F033', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (33, N'COMM/7/12', N'F034', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (34, N'COMM/7/12', N'F035', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (35, N'COMM/7/12', N'H011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (36, N'COMM/8/12', N'H012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (37, N'COMM/8/12', N'H013', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (38, N'COMM/8/12', N'H014', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (39, N'COMM/8/12', N'H031', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (40, N'COMM/8/12', N'H032', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (41, N'COMM/9/12', N'H033', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (42, N'COMM/9/12', N'P010', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (43, N'COMM/9/12', N'P011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (44, N'COMM/9/12', N'P012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (45, N'COMM/9/12', N'P013', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (46, N'COMM/10/12', N'P014', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (47, N'COMM/10/12', N'P015', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (48, N'COMM/10/12', N'P016', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (49, N'COMM/10/12', N'P020', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (50, N'COMM/10/12', N'P021', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (51, N'CPSC/1/12', N'P030', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (52, N'CPSC/1/12', N'P031', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (53, N'CPSC/1/12', N'P032', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (54, N'CPSC/1/12', N'P033', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (55, N'CPSC/1/12', N'P034', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (56, N'CPSC/2/12', N'P035', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (57, N'CPSC/2/12', N'P036', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (58, N'CPSC/2/12', N'P037', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (59, N'CPSC/2/12', N'P038', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (60, N'CPSC/2/12', N'P039', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (61, N'CPSC/3/12', N'P040', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (62, N'CPSC/3/12', N'P041', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (63, N'CPSC/3/12', N'P042', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (64, N'CPSC/3/12', N'P043', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (65, N'CPSC/3/12', N'P044', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (66, N'CPSC/4/12', N'P045', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (67, N'CPSC/4/12', N'P046', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (68, N'CPSC/4/12', N'R002', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (69, N'CPSC/4/12', N'R001', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (70, N'CPSC/4/12', N'S100', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (71, N'CPSC/5/12', N'S040', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (72, N'CPSC/5/12', N'S041', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (73, N'CPSC/5/12', N'S101', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (74, N'CPSC/5/12', N'S010', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (75, N'CPSC/5/12', N'S011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (76, N'CPSC/6/12', N'S012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (77, N'CPSC/6/12', N'S020', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (78, N'CPSC/6/12', N'S021', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (79, N'CPSC/6/12', N'S022', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (80, N'CPSC/6/12', N'S023', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (81, N'CPSC/7/12', N'T001', 1, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (82, N'CPSC/7/12', N'T002', 1, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (83, N'CPSC/7/12', N'T003', 1, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (84, N'CPSC/7/12', N'T020', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (85, N'CPSC/7/12', N'T021', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (86, N'CPSC/8/12', N'T022', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (87, N'CPSC/8/12', N'T023', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (88, N'CPSC/8/12', N'T024', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (89, N'CPSC/8/12', N'T025', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (90, N'CPSC/8/12', N'T100', 2, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (91, N'CPSC/9/12', N'C001', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (92, N'CPSC/9/12', N'C002', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (93, N'CPSC/9/12', N'C003', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (94, N'CPSC/9/12', N'C004', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (95, N'CPSC/9/12', N'C005', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (96, N'CPSC/10/12', N'C006', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (97, N'CPSC/10/12', N'D001', 40, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (98, N'CPSC/10/12', N'E001', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (99, N'CPSC/10/12', N'E002', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (100, N'CPSC/10/12', N'E003', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (101, N'ENGL/1/12', N'C001', 5, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (102, N'ENGL/1/12', N'C002', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (103, N'ENGL/1/12', N'C003', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (104, N'ENGL/1/12', N'C004', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (105, N'ENGL/1/12', N'C005', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (106, N'ENGL/2/12', N'C006', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (107, N'ENGL/2/12', N'D001', 40, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (108, N'ENGL/2/12', N'E001', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (109, N'ENGL/2/12', N'E002', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (110, N'ENGL/2/12', N'E003', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (111, N'ENGL/3/12', N'E004', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (112, N'ENGL/3/12', N'E005', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (113, N'ENGL/3/12', N'E006', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (114, N'ENGL/3/12', N'E007', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (115, N'ENGL/3/12', N'E008', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (116, N'ENGL/4/12', N'E020', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (117, N'ENGL/4/12', N'E021', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (118, N'ENGL/4/12', N'E030', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (119, N'ENGL/4/12', N'E031', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (120, N'ENGL/4/12', N'E032', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (121, N'ENGL/5/12', N'E033', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (122, N'ENGL/5/12', N'E034', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (123, N'ENGL/5/12', N'E035', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (124, N'ENGL/5/12', N'E036', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (125, N'ENGL/5/12', N'F020', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (126, N'ENGL/6/12', N'F021', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (127, N'ENGL/6/12', N'F022', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (128, N'ENGL/6/12', N'F023', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (129, N'ENGL/6/12', N'F024', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (130, N'ENGL/6/12', N'F031', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (131, N'ENGL/7/12', N'F032', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (132, N'ENGL/7/12', N'F033', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (133, N'ENGL/7/12', N'F034', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (134, N'ENGL/7/12', N'F035', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (135, N'ENGL/7/12', N'H011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (136, N'ENGL/8/12', N'H012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (137, N'ENGL/8/12', N'H013', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (138, N'ENGL/8/12', N'H014', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (139, N'ENGL/8/12', N'H031', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (140, N'ENGL/8/12', N'H032', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (141, N'ENGL/9/12', N'H033', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (142, N'ENGL/9/12', N'P010', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (143, N'ENGL/9/12', N'P011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (144, N'ENGL/9/12', N'P012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (145, N'ENGL/9/12', N'P013', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (146, N'ENGL/10/12', N'P014', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (147, N'ENGL/10/12', N'P015', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (148, N'ENGL/10/12', N'P016', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (149, N'ENGL/10/12', N'P020', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (150, N'ENGL/10/12', N'P021', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (151, N'REGR/1/12', N'P030', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (152, N'REGR/1/12', N'P031', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (153, N'REGR/1/12', N'P032', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (154, N'REGR/1/12', N'P033', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (155, N'REGR/1/12', N'P034', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (156, N'REGR/2/12', N'P035', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (157, N'REGR/2/12', N'P036', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (158, N'REGR/2/12', N'P037', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (159, N'REGR/2/12', N'P038', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (160, N'REGR/2/12', N'P039', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (161, N'REGR/3/12', N'P040', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (162, N'REGR/3/12', N'P041', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (163, N'REGR/3/12', N'P042', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (164, N'REGR/3/12', N'P043', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (165, N'REGR/3/12', N'P044', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (166, N'REGR/4/12', N'P045', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (167, N'REGR/4/12', N'P046', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (168, N'REGR/4/12', N'R002', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (169, N'REGR/4/12', N'R001', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (170, N'REGR/4/12', N'S100', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (171, N'REGR/5/12', N'S040', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (172, N'REGR/5/12', N'S041', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (173, N'REGR/5/12', N'S101', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (174, N'REGR/5/12', N'S010', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (175, N'REGR/5/12', N'S011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (176, N'REGR/6/12', N'S012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (177, N'REGR/6/12', N'S020', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (178, N'REGR/6/12', N'S021', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (179, N'REGR/6/12', N'S022', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (180, N'REGR/6/12', N'S023', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (181, N'REGR/7/12', N'T001', 1, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (182, N'REGR/7/12', N'T002', 1, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (183, N'REGR/7/12', N'T003', 1, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (184, N'REGR/7/12', N'T020', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (185, N'REGR/7/12', N'T021', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (186, N'REGR/8/12', N'T022', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (187, N'REGR/8/12', N'T023', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (188, N'REGR/8/12', N'T024', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (189, N'REGR/8/12', N'T025', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (190, N'REGR/8/12', N'T100', 2, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (191, N'REGR/9/12', N'C001', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (192, N'REGR/9/12', N'C002', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (193, N'REGR/9/12', N'C003', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (194, N'REGR/9/12', N'C004', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (195, N'REGR/9/12', N'C005', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (196, N'REGR/10/12', N'C006', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (197, N'REGR/10/12', N'D001', 40, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (198, N'REGR/10/12', N'E001', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (199, N'REGR/10/12', N'E002', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (200, N'REGR/10/12', N'E003', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (201, N'ZOOL/1/12', N'E004', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (202, N'ZOOL/1/12', N'E005', 60, NULL)
GO
print 'Processed 200 total records'
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (203, N'ZOOL/1/12', N'E006', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (204, N'ZOOL/1/12', N'E007', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (205, N'ZOOL/1/12', N'E008', 60, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (206, N'ZOOL/2/12', N'E020', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (207, N'ZOOL/2/12', N'E021', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (208, N'ZOOL/2/12', N'E030', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (209, N'ZOOL/2/12', N'E031', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (210, N'ZOOL/2/12', N'E032', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (211, N'ZOOL/3/12', N'E033', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (212, N'ZOOL/3/12', N'E034', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (213, N'ZOOL/3/12', N'E035', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (214, N'ZOOL/3/12', N'E036', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (215, N'ZOOL/3/12', N'F020', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (216, N'ZOOL/4/12', N'F021', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (217, N'ZOOL/4/12', N'F022', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (218, N'ZOOL/4/12', N'F023', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (219, N'ZOOL/4/12', N'F024', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (220, N'ZOOL/4/12', N'F031', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (221, N'ZOOL/5/12', N'F032', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (222, N'ZOOL/5/12', N'F033', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (223, N'ZOOL/5/12', N'F034', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (224, N'ZOOL/5/12', N'F035', 20, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (225, N'ZOOL/5/12', N'H011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (226, N'ZOOL/6/12', N'H012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (227, N'ZOOL/6/12', N'H013', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (228, N'ZOOL/6/12', N'H014', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (229, N'ZOOL/6/12', N'H031', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (230, N'ZOOL/6/12', N'H032', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (231, N'ZOOL/7/12', N'H033', 5, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (232, N'ZOOL/7/12', N'P010', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (233, N'ZOOL/7/12', N'P011', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (234, N'ZOOL/7/12', N'P012', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (235, N'ZOOL/7/12', N'P013', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (236, N'ZOOL/8/12', N'P014', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (237, N'ZOOL/8/12', N'P015', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (238, N'ZOOL/8/12', N'P016', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (239, N'ZOOL/8/12', N'P020', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (240, N'ZOOL/8/12', N'P021', 50, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (241, N'ZOOL/9/12', N'P030', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (242, N'ZOOL/9/12', N'P031', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (243, N'ZOOL/9/12', N'P032', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (244, N'ZOOL/9/12', N'P033', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (245, N'ZOOL/9/12', N'P034', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (246, N'ZOOL/10/12', N'P035', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (247, N'ZOOL/10/12', N'P036', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (248, N'ZOOL/10/12', N'P037', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (249, N'ZOOL/10/12', N'P038', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (250, N'ZOOL/10/12', N'P039', 10, NULL)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (251, N'ENGL/11/12', N'C001', 5, 0)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (252, N'ENGL/11/12', N'C005', 5, 0)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (253, N'COMM/11/12', N'E003', 20, 0)
INSERT [dbo].[RequisitionDetails] ([Id], [RequisitionId], [ItemId], [Qty], [DeliveredQty]) VALUES (254, N'COMM/11/12', N'F020', 30, 0)
/****** Object:  Table [dbo].[User]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (1, N'pamelakow', N'pamelakow', CAST(0x00009FDD00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (2, N'ezrapound', N'ezrapound', CAST(0x00009FE400000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (3, N'weekianfatt', N'weekianfatt', CAST(0x00009FE400000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (4, N'sohkianwee', N'sohkianwee', CAST(0x00009FE400000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (5, N'mohdazman', N'mohdazman', CAST(0x00009FE400000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (6, N'chialeowbee', N'chialeowbee', CAST(0x00009FEA00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (7, N'helenho', N'helenho', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (8, N'lowkwayboo', N'lowkwayboo', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (9, N'petertanahmeng', N'petertanahmeng', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (10, N'tan', N'tan', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (11, N'taufin', N'taufin', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (12, N'shekhar', N'shekhar', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (13, N'cc1988', N'cc1988', CAST(0x00009FED00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (14, N'sanla', N'sanla', CAST(0x00009FEE00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (15, N'koko', N'kokoko', CAST(0x00009FEE00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (16, N'thazin', N'thazin', CAST(0x00009FEE00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (17, N'sulai', N'sulai', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (18, N'chen', N'chen', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (19, N'priya', N'priya', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (20, N'jijiapeng', N'jijiapeng', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (21, N'esther', N'esther', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (22, N'natasha', N'natasha', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (23, N'raja', N'raja', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (24, N'shafina', N'shafina', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (25, N'azman', N'azman', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [CreatedDate], [CreatedBy], [Status]) VALUES (26, N'admin', N'admin', CAST(0x00009FEF00000000 AS DateTime), 26, 1)
/****** Object:  Table [dbo].[UnitOfMeasure]    Script Date: 02/04/2012 20:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitOfMeasure](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[UnitOfMeasure] ([Id], [Name]) VALUES (1, N'Dozen')
INSERT [dbo].[UnitOfMeasure] ([Id], [Name]) VALUES (2, N'Box')
INSERT [dbo].[UnitOfMeasure] ([Id], [Name]) VALUES (3, N'Each')
INSERT [dbo].[UnitOfMeasure] ([Id], [Name]) VALUES (4, N'Set')
INSERT [dbo].[UnitOfMeasure] ([Id], [Name]) VALUES (5, N'Packet')
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 02/04/2012 20:42:50 ******/
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
	[Remarks] [text] NULL,
 CONSTRAINT [PK_purchaseorderdetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (1, 200000068, N'E036', 200.0000, 2, 1, NULL)
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (2, 200000068, N'C002', 300.0000, 1, 1, NULL)
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (3, 200000068, N'C004', 100.0000, 5, 5, NULL)
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (4, 200000068, N'C005', 89.0000, 6, 6, NULL)
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (5, 200000068, N'C006', 344.0000, 9, 9, NULL)
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (6, 200000069, N'E036', 300.0000, 3, 3, NULL)
INSERT [dbo].[PurchaseOrderDetails] ([Id], [PurchaseOrderId], [ItemId], [Price], [Qty], [AcceptedQty], [Remarks]) VALUES (7, 200000069, N'C002', 100.0000, 5, 5, NULL)
/****** Object:  Table [dbo].[RequisitionCollection]    Script Date: 02/04/2012 20:42:50 ******/
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
	[DeliveryDate] [date] NULL,
	[DeliveryBy] [int] NULL,
 CONSTRAINT [PK_requisitioncollection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[RequisitionCollection] ([Id], [DepartmentId], [CollectionPointId], [CreatedDate], [CreatedBy], [Status], [DeliveryDate], [DeliveryBy]) VALUES (1, N'ENGL', 4, CAST(0x00009FEA015D96B2 AS DateTime), 1, 1, NULL, NULL)
INSERT [dbo].[RequisitionCollection] ([Id], [DepartmentId], [CollectionPointId], [CreatedDate], [CreatedBy], [Status], [DeliveryDate], [DeliveryBy]) VALUES (2, N'ENGL', 4, CAST(0x00009FEB0091418B AS DateTime), 1, 1, NULL, NULL)
INSERT [dbo].[RequisitionCollection] ([Id], [DepartmentId], [CollectionPointId], [CreatedDate], [CreatedBy], [Status], [DeliveryDate], [DeliveryBy]) VALUES (3, N'ENGL', 4, CAST(0x00009FEB0094E38F AS DateTime), 1, 1, NULL, NULL)
INSERT [dbo].[RequisitionCollection] ([Id], [DepartmentId], [CollectionPointId], [CreatedDate], [CreatedBy], [Status], [DeliveryDate], [DeliveryBy]) VALUES (4, N'ENGL', 1, CAST(0x00009FEB0124A527 AS DateTime), 1, 1, NULL, NULL)
INSERT [dbo].[RequisitionCollection] ([Id], [DepartmentId], [CollectionPointId], [CreatedDate], [CreatedBy], [Status], [DeliveryDate], [DeliveryBy]) VALUES (5, N'ENGL', 1, CAST(0x00009FED00EF140E AS DateTime), 1, 1, NULL, NULL)
/****** Object:  Table [dbo].[RequisitionCollectionItems]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (1, 2, N'C006', 5, CAST(0x00009FEC00F66F21 AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (2, 2, N'D001', 36, CAST(0x00009FEC00F66F26 AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (3, 2, N'E001', 54, CAST(0x00009FEC00F66F2B AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (4, 2, N'E002', 54, CAST(0x00009FEC00F66F2F AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (5, 2, N'E003', 54, CAST(0x00009FEC00F66F2F AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (6, 2, N'E020', 4, CAST(0x00009FEC00F66F34 AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (7, 2, N'E021', 4, CAST(0x00009FEC00F66F38 AS DateTime), 1, 1)
INSERT [dbo].[RequisitionCollectionItems] ([Id], [RequisitionCollectionId], [ItemId], [Qty], [CreatedDate], [CreatedBy], [Status]) VALUES (8, 2, N'E030', 9, CAST(0x00009FEC00F66F38 AS DateTime), 1, 1)
/****** Object:  Table [dbo].[RequisitionCollectionDetails]    Script Date: 02/04/2012 20:42:50 ******/
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
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (1, N'COMM/1/12', 1)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (2, N'COMM/10/12', 1)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (3, N'COMM/2/12', 2)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (4, N'COMM/4/12', 2)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (5, N'COMM/6/12', 2)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (6, N'COMM/8/12', 2)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (7, N'CPSC/1/12', 2)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (8, N'COMM/3/12', 3)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (9, N'COMM/7/12', 3)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (10, N'CPSC/10/12', 3)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (11, N'COMM/5/12', 4)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (12, N'COMM/9/12', 4)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (13, N'CPSC/2/12', 4)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (14, N'CPSC/3/12', 4)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (15, N'CPSC/4/12', 4)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (16, N'CPSC/6/12', 4)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (17, N'CPSC/7/12', 5)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (18, N'CPSC/8/12', 5)
INSERT [dbo].[RequisitionCollectionDetails] ([Id], [RequisitionId], [RequisitionCollectionId]) VALUES (19, N'ENGL/1/12', 5)
/****** Object:  Table [dbo].[Category]    Script Date: 02/04/2012 20:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Clip')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Envelope')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Eraser')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Exercise')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'File')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Pen')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'Puncher')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Pad')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'Paper')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Ruler')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (11, N'Scissors')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (12, N'Tape')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (13, N'Sharpener')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (14, N'Shorthand')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (15, N'Stapler')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (16, N'Tacks')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (17, N'Tparency')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (18, N'Tray')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (19, N'Disk')
/****** Object:  ForeignKey [FK_CollectionMissed_Department1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[CollectionMissed]  WITH CHECK ADD  CONSTRAINT [FK_CollectionMissed_Department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CollectionMissed] CHECK CONSTRAINT [FK_CollectionMissed_Department1]
GO
/****** Object:  ForeignKey [FK_CollectionMissed_Employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[CollectionMissed]  WITH CHECK ADD  CONSTRAINT [FK_CollectionMissed_Employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CollectionMissed] CHECK CONSTRAINT [FK_CollectionMissed_Employee1]
GO
/****** Object:  ForeignKey [FK_CollectionPoint_Employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[CollectionPoint]  WITH CHECK ADD  CONSTRAINT [FK_CollectionPoint_Employee1] FOREIGN KEY([ClerkId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CollectionPoint] CHECK CONSTRAINT [FK_CollectionPoint_Employee1]
GO
/****** Object:  ForeignKey [FK_department_collectionpoint1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_collectionpoint1] FOREIGN KEY([CollectionPointId])
REFERENCES [dbo].[CollectionPoint] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_collectionpoint1]
GO
/****** Object:  ForeignKey [FK_department_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee1] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee1]
GO
/****** Object:  ForeignKey [FK_department_employee2]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee2] FOREIGN KEY([HeadId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee2]
GO
/****** Object:  ForeignKey [FK_department_employee3]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee3] FOREIGN KEY([RepresentativeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee3]
GO
/****** Object:  ForeignKey [FK_department_employee4]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_department_employee4] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_department_employee4]
GO
/****** Object:  ForeignKey [FK_discrepancy_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Discrepancy]  WITH CHECK ADD  CONSTRAINT [FK_discrepancy_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Discrepancy] CHECK CONSTRAINT [FK_discrepancy_employee1]
GO
/****** Object:  ForeignKey [FK_discrepancydetails_discrepancy1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[DiscrepancyDetails]  WITH CHECK ADD  CONSTRAINT [FK_discrepancydetails_discrepancy1] FOREIGN KEY([DiscrepancyId])
REFERENCES [dbo].[Discrepancy] ([Id])
GO
ALTER TABLE [dbo].[DiscrepancyDetails] CHECK CONSTRAINT [FK_discrepancydetails_discrepancy1]
GO
/****** Object:  ForeignKey [FK_discrepancydetails_item1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[DiscrepancyDetails]  WITH CHECK ADD  CONSTRAINT [FK_discrepancydetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[DiscrepancyDetails] CHECK CONSTRAINT [FK_discrepancydetails_item1]
GO
/****** Object:  ForeignKey [FK_employee_department1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_department1]
GO
/****** Object:  ForeignKey [FK_employee_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_employee1]
GO
/****** Object:  ForeignKey [FK_employee_role1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_role1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_role1]
GO
/****** Object:  ForeignKey [FK_employee_user1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_user1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_user1]
GO
/****** Object:  ForeignKey [FK_item_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_item_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_item_employee1]
GO
/****** Object:  ForeignKey [FK_itemprice_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[ItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_itemprice_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ItemPrice] CHECK CONSTRAINT [FK_itemprice_employee1]
GO
/****** Object:  ForeignKey [FK_Notification_Employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Employee1]
GO
/****** Object:  ForeignKey [FK_purchaseorder_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_employee1]
GO
/****** Object:  ForeignKey [FK_purchaseorder_employee2]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_employee2] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_employee2]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_Employee3]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee3] FOREIGN KEY([AcceptedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee3]
GO
/****** Object:  ForeignKey [FK_purchaseorder_supplier1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseorder_supplier1] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_purchaseorder_supplier1]
GO
/****** Object:  ForeignKey [FK_requisition_department1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_department1]
GO
/****** Object:  ForeignKey [FK_requisition_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_employee1]
GO
/****** Object:  ForeignKey [FK_requisition_employee2]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Requisition]  WITH CHECK ADD  CONSTRAINT [FK_requisition_employee2] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Requisition] CHECK CONSTRAINT [FK_requisition_employee2]
GO
/****** Object:  ForeignKey [FK_requisitioncollectiondetails_requisition1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionCollectionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectiondetails_requisition1] FOREIGN KEY([RequisitionId])
REFERENCES [dbo].[Requisition] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionDetails] CHECK CONSTRAINT [FK_requisitioncollectiondetails_requisition1]
GO
/****** Object:  ForeignKey [FK_RequisitionCollectionDetails_RequisitionCollection1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionCollectionDetails]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionCollectionDetails_RequisitionCollection1] FOREIGN KEY([RequisitionCollectionId])
REFERENCES [dbo].[RequisitionCollection] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionDetails] CHECK CONSTRAINT [FK_RequisitionCollectionDetails_RequisitionCollection1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_employee1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_item1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_item1]
GO
/****** Object:  ForeignKey [FK_requisitioncollectionitems_requisitioncollection1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_requisitioncollectionitems_requisitioncollection1] FOREIGN KEY([RequisitionCollectionId])
REFERENCES [dbo].[RequisitionCollection] ([Id])
GO
ALTER TABLE [dbo].[RequisitionCollectionItems] CHECK CONSTRAINT [FK_requisitioncollectionitems_requisitioncollection1]
GO
/****** Object:  ForeignKey [FK_requisitiondetails_item1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitiondetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RequisitionDetails] CHECK CONSTRAINT [FK_requisitiondetails_item1]
GO
/****** Object:  ForeignKey [FK_requisitiondetails_requisition1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RequisitionDetails]  WITH CHECK ADD  CONSTRAINT [FK_requisitiondetails_requisition1] FOREIGN KEY([RequisitionId])
REFERENCES [dbo].[Requisition] ([Id])
GO
ALTER TABLE [dbo].[RequisitionDetails] CHECK CONSTRAINT [FK_requisitiondetails_requisition1]
GO
/****** Object:  ForeignKey [FK_retrieval_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Retrieval]  WITH CHECK ADD  CONSTRAINT [FK_retrieval_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Retrieval] CHECK CONSTRAINT [FK_retrieval_employee1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_department1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_department1] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_department1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_item1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_item1]
GO
/****** Object:  ForeignKey [FK_retrievaldetails_retrieval1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[RetrievalDetails]  WITH CHECK ADD  CONSTRAINT [FK_retrievaldetails_retrieval1] FOREIGN KEY([RetrievalId])
REFERENCES [dbo].[Retrieval] ([Id])
GO
ALTER TABLE [dbo].[RetrievalDetails] CHECK CONSTRAINT [FK_retrievaldetails_retrieval1]
GO
/****** Object:  ForeignKey [FK_role_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_role_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_role_employee1]
GO
/****** Object:  ForeignKey [FK_stockadjustment_discrepancy1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_stockadjustment_discrepancy1] FOREIGN KEY([DiscrepancyId])
REFERENCES [dbo].[Discrepancy] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_stockadjustment_discrepancy1]
GO
/****** Object:  ForeignKey [FK_stockadjustment_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_stockadjustment_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_stockadjustment_employee1]
GO
/****** Object:  ForeignKey [FK_stockcarddetails_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[StockCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_stockcarddetails_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[StockCardDetails] CHECK CONSTRAINT [FK_stockcarddetails_employee1]
GO
/****** Object:  ForeignKey [FK_StockCardDetails_Item1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[StockCardDetails]  WITH CHECK ADD  CONSTRAINT [FK_StockCardDetails_Item1] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockCardDetails] CHECK CONSTRAINT [FK_StockCardDetails_Item1]
GO
/****** Object:  ForeignKey [FK_supplier_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_supplier_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_supplier_employee1]
GO
/****** Object:  ForeignKey [FK_user_employee1]    Script Date: 02/04/2012 20:42:50 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_user_employee1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_user_employee1]
GO
