USE [DataBase]
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 
GO
INSERT [dbo].[Unit] ([Id], [Description]) VALUES (1, N'Lb        ')
GO
INSERT [dbo].[Unit] ([Id], [Description]) VALUES (2, N'Each      ')
GO
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([Id], [Description]) VALUES (1, N'Produce   ')
GO
INSERT [dbo].[Department] ([Id], [Description]) VALUES (2, N'Grocery   ')
GO
INSERT [dbo].[Department] ([Id], [Description]) VALUES (3, N'Pharmacy  ')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (113, N'brea', CAST(N'2017-09-12T00:00:00.000' AS DateTime), 14, 2, 1.5, 2, 1, 0.12)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (1111, N'cheese slices', CAST(N'2017-09-15T00:00:00.000' AS DateTime), 20, 2, 2.68, 2, 1, 0.4)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (1189, N'hamburger buns', CAST(N'2017-09-13T00:00:00.000' AS DateTime), 14, 2, 1.75, 2, 1, 0.14)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (11122, N'grapes', CAST(N'2017-09-10T00:00:00.000' AS DateTime), 7, 1, 4, 1, 1, 1.2)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (12221, N'pasta sauce', CAST(N'2017-09-14T00:00:00.000' AS DateTime), 23, 2, 3.75, 2, 1, 1)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (18939, N'sliced turkey', CAST(N'2017-09-16T00:00:00.000' AS DateTime), 20, 2, 3.29, 2, 1, 0.67)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (90879, N'tortilla chips', CAST(N'2017-09-17T00:00:00.000' AS DateTime), 45, 2, 1.99, 2, 1, 0.14)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (95175, N'Strawberry', CAST(N'2017-09-07T00:00:00.000' AS DateTime), 3, 1, 2.49, 1, 1, 0.1)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (119290, N'cereal', CAST(N'2017-09-18T00:00:00.000' AS DateTime), 40, 2, 3.19, 2, 1, 0.19)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (124872, N'Lettuce', CAST(N'2017-09-11T00:00:00.000' AS DateTime), 5, 1, 0.79, 1, 1, 0.1)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (321654, N'apples', CAST(N'2017-09-06T00:00:00.000' AS DateTime), 7, 1, 1.49, 1, 1, 0.2)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (321753, N'onion', CAST(N'2017-09-08T00:00:00.000' AS DateTime), 9, 1, 1, 2, 1, 0.05)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (753542, N'banana', CAST(N'2017-09-05T00:00:00.000' AS DateTime), 4, 1, 2.99, 1, 1, 0.44)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (987654, N'Tomato', CAST(N'2017-09-09T00:00:00.000' AS DateTime), 4, 1, 2.35, 1, 1, 0.2)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (4629464, N'canned vegtables', CAST(N'2017-09-19T00:00:00.000' AS DateTime), 200, 2, 1.89, 2, 1, 0.19)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (9000001, N'headache medicine', CAST(N'2017-09-20T00:00:00.000' AS DateTime), 365, 3, 4.89, 2, 1, 1.9)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (9000002, N'Migraine Medicine', CAST(N'2017-09-21T00:00:00.000' AS DateTime), 365, 3, 5.89, 2, 1, 1.9)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (9000003, N'Cold and Flu', CAST(N'2017-09-22T00:00:00.000' AS DateTime), 365, 3, 3.29, 2, 1, 1.9)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (9000004, N'Allegry Medicine', CAST(N'2017-09-23T00:00:00.000' AS DateTime), 365, 3, 3, 2, 1, 1.25)
GO
INSERT [dbo].[Product] ([Id], [Description], [LastSold], [ShelfLife], [DepartmentId], [Price], [UnitId], [xFor], [Cost]) VALUES (9000005, N'Pain', CAST(N'2017-09-24T00:00:00.000' AS DateTime), 365, 3, 2.89, 2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
