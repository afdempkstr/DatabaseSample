USE [efdbfirst]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuisine](
	[CuisineId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cuisine] PRIMARY KEY CLUSTERED 
 (
	[CuisineId] ASC
 )
)
GO

CREATE TABLE [dbo].[Restaurant](
	[RestaurantId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[MinimumOrder] [decimal](5, 2) NOT NULL,
	[IsOpen] [bit] NOT NULL,
	[DeliveryTime] [int] NOT NULL,
	[CuisineId] [int] NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
 (
	[RestaurantId] ASC
 )
)
GO

SET IDENTITY_INSERT [dbo].[Cuisine] ON 
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Description]) VALUES (1, N'Pizza')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Description]) VALUES (2, N'Σουβλάκι')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Description]) VALUES (3, N'Μαγειρευτά')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Description]) VALUES (4, N'Ιταλικό')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Description]) VALUES (5, N'Καφέδες')
GO
SET IDENTITY_INSERT [dbo].[Cuisine] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurant] ON 
GO
INSERT [dbo].[Restaurant] ([RestaurantId], [Name], [Address], [MinimumOrder], [IsOpen], [DeliveryTime], [CuisineId]) VALUES (1, N'Pizza Fan Μπουρνάζι', N'Ελευθερίου Βενιζέλου 19', CAST(3.50 AS Decimal(5, 2)), 0, 30, 1)
GO
INSERT [dbo].[Restaurant] ([RestaurantId], [Name], [Address], [MinimumOrder], [IsOpen], [DeliveryTime], [CuisineId]) VALUES (2, N'Pizza Hut Πεδίον Άρεως', N'Κοδριγκτώνος 39', CAST(6.00 AS Decimal(5, 2)), 1, 45, 1)
GO
INSERT [dbo].[Restaurant] ([RestaurantId], [Name], [Address], [MinimumOrder], [IsOpen], [DeliveryTime], [CuisineId]) VALUES (3, N'Σουβλάκι της γειτονιάς', N'Γειτονιάς', CAST(2.00 AS Decimal(5, 2)), 1, 15, 2)
GO
INSERT [dbo].[Restaurant] ([RestaurantId], [Name], [Address], [MinimumOrder], [IsOpen], [DeliveryTime], [CuisineId]) VALUES (4, N'Μυστήρια στο Πεκίνο', N'Ερμού 12', CAST(5.00 AS Decimal(5, 2)), 0, 35, NULL)
GO
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
GO
ALTER TABLE [dbo].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Cuisine] FOREIGN KEY([CuisineId])
REFERENCES [dbo].[Cuisine] ([CuisineId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Restaurant] CHECK CONSTRAINT [FK_Restaurant_Cuisine]
GO
