USE [F:\DEV\SEASONALPRODUCE\SP.WEBAPI\SEASONAL_PRODUCE_DB.MDF]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14.4.2018 г. 12:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategories]    Script Date: 14.4.2018 г. 12:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_FoodCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodDataItems]    Script Date: 14.4.2018 г. 12:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodDataItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[InSeasonFromMonth] [int] NOT NULL,
	[InSeasonToMonth] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_FoodDataItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180316204704_InitialCreate', N'2.0.2-rtm-10011')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180316210325_AddImageUrlColumn', N'2.0.2-rtm-10011')
SET IDENTITY_INSERT [dbo].[FoodCategories] ON 

INSERT [dbo].[FoodCategories] ([Id], [Name]) VALUES (1, N'Fruits')
INSERT [dbo].[FoodCategories] ([Id], [Name]) VALUES (2, N'Vegetables')
SET IDENTITY_INSERT [dbo].[FoodCategories] OFF
SET IDENTITY_INSERT [dbo].[FoodDataItems] ON 

INSERT [dbo].[FoodDataItems] ([Id], [CategoryId], [InSeasonFromMonth], [InSeasonToMonth], [Name], [ImageUrl]) VALUES (1, 1, 1, 12, N'Apples', NULL)
INSERT [dbo].[FoodDataItems] ([Id], [CategoryId], [InSeasonFromMonth], [InSeasonToMonth], [Name], [ImageUrl]) VALUES (2, 2, 1, 12, N'Potatoes', NULL)
SET IDENTITY_INSERT [dbo].[FoodDataItems] OFF
ALTER TABLE [dbo].[FoodDataItems]  WITH CHECK ADD  CONSTRAINT [FK_FoodDataItems_FoodCategories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[FoodCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodDataItems] CHECK CONSTRAINT [FK_FoodDataItems_FoodCategories_CategoryId]
GO
