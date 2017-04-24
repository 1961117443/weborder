/*
此脚本由 Visual Studio 于 2017-04-24 在 18:53 创建。
请对 192.168.31.148.WebOrderT (sa) 运行此脚本，使其与 192.168.31.148.WebOrder (sa) 相同。
此脚本按照以下顺序执行操作:
1. 禁用外键约束。
2. 执行 DELETE 命令。
3. 执行 UPDATE 命令。
4. 执行 INSERT 命令。
5. 重新启用外键约束。
请在运行此脚本之前备份目标数据库。
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO 
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[SysModule] ON
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (1, N'客户交互平台', 0, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (2, N'产品目录', 1, N'', N'', N'', N'', 2, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (3, N'型材型号', 2, N'', N'Admin', N'Login2', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (4, N'表面方式', 2, N'', N'Admin', N'LoginIn', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (5, N'包装方式', 2, N'', N'Admin', N'GetModules', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (6, N'帐号管理', 1, N'', N'', N'', N'', 3, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (7, N'我的订单', 1, N'', N'', N'', N'', 1, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (8, N'快速下单', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (9, N'传统下单', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (10, N'订单管理', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (11, N'库存管理', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (12, N'用户信息', 6, N'', N'Admin', N'ShowUser', N'', 0, 1)
SET IDENTITY_INSERT [dbo].[SysModule] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT INTO [dbo].[UserInfo] ([ID], [UserName], [PassWord], [LoginTime]) VALUES (1, N'admin', N'admin', '20170424 18:38:27.627')
INSERT INTO [dbo].[UserInfo] ([ID], [UserName], [PassWord], [LoginTime]) VALUES (2, N'test01', N'test01', NULL)
INSERT INTO [dbo].[UserInfo] ([ID], [UserName], [PassWord], [LoginTime]) VALUES (3, N'test02', N'test02', NULL)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
COMMIT TRANSACTION
