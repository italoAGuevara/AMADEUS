
USE [AMADEUS]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[BarCode] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StockQuantity] [bigint] NOT NULL,
	[TmStmp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsTransactions]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsTransactions](
	[Id] [uniqueidentifier] NOT NULL,
	[User] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Transaction] [decimal](18, 2) NOT NULL,
	[FinalStockQuantity] [bigint] NOT NULL,
	[TmStmp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProductsTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 5/30/2024 12:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[TmStmp] [datetime2](7) NOT NULL,
	[BodyToken] [nvarchar](max) NOT NULL,
	[ExpirationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5f44ec17-e0d2-4544-bfbd-3772c37f67df', N'User', N'USER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a6eccf3a-256e-4708-80df-ac64baa22ab3', N'Administrator', N'ADMINISTRATOR', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'66b0e4c2-5aab-4a64-9e0f-14db64c96cdb', N'a6eccf3a-256e-4708-80df-ac64baa22ab3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'66b0e4c2-5aab-4a64-9e0f-14db64c96cdb', N'admin1', N'ADMIN1', N'admi1@mail.com', N'ADMN1@MAIL.COM', 0, N'ac9689e2272427085e35b9d3e3e8bed88cb3434828b43b86fc0596cad4c6e270', N'd7eda3fa-961b-4e6f-833a-1cbc5089df94', N'6c0d87c5-ddb8-473b-935d-9406107fc9f2', NULL, 0, 0, NULL, 0, 0)
GO
INSERT INTO [dbo].[Products] (Id, BarCode, Name, Description, Price, StockQuantity, TmStmp)
VALUES
(NEWID(), '123456789012', 'Product 1', 'Description for product 1', 19.99, 100, SYSDATETIME()),
(NEWID(), '123456789013', 'Product 2', 'Description for product 2', 29.99, 150, SYSDATETIME()),
(NEWID(), '123456789014', 'Product 3', 'Description for product 3', 9.99, 200, SYSDATETIME()),
(NEWID(), '123456789015', 'Product 4', 'Description for product 4', 14.99, 120, SYSDATETIME()),
(NEWID(), '123456789016', 'Product 5', 'Description for product 5', 39.99, 80, SYSDATETIME()),
(NEWID(), '123456789017', 'Product 6', 'Description for product 6', 24.99, 60, SYSDATETIME()),
(NEWID(), '123456789018', 'Product 7', 'Description for product 7', 59.99, 30, SYSDATETIME()),
(NEWID(), '123456789019', 'Product 8', 'Description for product 8', 49.99, 90, SYSDATETIME()),
(NEWID(), '123456789020', 'Product 9', 'Description for product 9', 79.99, 40, SYSDATETIME()),
(NEWID(), '123456789021', 'Product 10', 'Description for product 10', 99.99, 20, SYSDATETIME()),
(NEWID(), '123456789022', 'Product 11', 'Description for product 11', 89.99, 50, SYSDATETIME()),
(NEWID(), '123456789023', 'Product 12', 'Description for product 12', 69.99, 60, SYSDATETIME()),
(NEWID(), '123456789024', 'Product 13', 'Description for product 13', 5.99, 300, SYSDATETIME()),
(NEWID(), '123456789025', 'Product 14', 'Description for product 14', 15.99, 250, SYSDATETIME()),
(NEWID(), '123456789026', 'Product 15', 'Description for product 15', 25.99, 100, SYSDATETIME()),
(NEWID(), '123456789027', 'Product 16', 'Description for product 16', 35.99, 70, SYSDATETIME()),
(NEWID(), '123456789028', 'Product 17', 'Description for product 17', 45.99, 30, SYSDATETIME()),
(NEWID(), '123456789029', 'Product 18', 'Description for product 18', 55.99, 40, SYSDATETIME()),
(NEWID(), '123456789030', 'Product 19', 'Description for product 19', 65.99, 90, SYSDATETIME()),
(NEWID(), '123456789031', 'Product 20', 'Description for product 20', 75.99, 10, SYSDATETIME()),
(NEWID(), '123456789032', 'Product 21', 'Description for product 21', 85.99, 20, SYSDATETIME()),
(NEWID(), '123456789033', 'Product 22', 'Description for product 22', 95.99, 30, SYSDATETIME()),
(NEWID(), '123456789034', 'Product 23', 'Description for product 23', 105.99, 50, SYSDATETIME()),
(NEWID(), '123456789035', 'Product 24', 'Description for product 24', 115.99, 60, SYSDATETIME()),
(NEWID(), '123456789036', 'Product 25', 'Description for product 25', 125.99, 70, SYSDATETIME()),
(NEWID(), '123456789037', 'Product 26', 'Description for product 26', 135.99, 80, SYSDATETIME()),
(NEWID(), '123456789038', 'Product 27', 'Description for product 27', 145.99, 90, SYSDATETIME()),
(NEWID(), '123456789039', 'Product 28', 'Description for product 28', 155.99, 100, SYSDATETIME()),
(NEWID(), '123456789040', 'Product 29', 'Description for product 29', 165.99, 110, SYSDATETIME()),
(NEWID(), '123456789041', 'Product 30', 'Description for product 30', 175.99, 120, SYSDATETIME());

GO
INSERT [dbo].[ProductsTransactions] ([Id], [User], [Price], [Transaction], [FinalStockQuantity], [TmStmp]) VALUES (N'66783aca-7ed9-41e3-b996-1e05307e1e35', N'el pepe', CAST(4300.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2024-05-29T22:32:35.0689325' AS DateTime2))
INSERT [dbo].[ProductsTransactions] ([Id], [User], [Price], [Transaction], [FinalStockQuantity], [TmStmp]) VALUES (N'cd275c7d-7e2c-46d8-bf25-b3c187fce903', N'itallo@mail.com', CAST(1100.01 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2024-05-29T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Tokens] ([Id], [UserId], [TmStmp], [BodyToken], [ExpirationTime]) VALUES (N'c0b0e9a2-4263-4e22-a145-c5da5b815910', N'66b0e4c2-5aab-4a64-9e0f-14db64c96cdb', CAST(N'2024-05-29T09:21:53.5400942' AS DateTime2), N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluMSIsImVtYWlsIjoiYWRtaTFAbWFpbC5jb20iLCJuYmYiOjE3MTcwNDI5MjAsImV4cCI6MTcxOTYzNDkyMCwiaWF0IjoxNzE3MDQyOTIwfQ.1l7Jboi4Mm8t6RG02sO57hTcrod9yM-Qu4rqQABN6A4', CAST(N'2024-06-29T04:22:00.7613433' AS DateTime2))
GO
ALTER TABLE [dbo].[Tokens] ADD  DEFAULT ('2024-05-29T09:21:53.5400942Z') FOR [TmStmp]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
