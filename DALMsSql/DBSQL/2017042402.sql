/*
�˽ű��� Visual Studio �� 2017-04-24 �� 18:53 ������
��� 192.168.31.148.WebOrderT (sa) ���д˽ű���ʹ���� 192.168.31.148.WebOrder (sa) ��ͬ��
�˽ű���������˳��ִ�в���:
1. �������Լ����
2. ִ�� DELETE ���
3. ִ�� UPDATE ���
4. ִ�� INSERT ���
5. �����������Լ����
�������д˽ű�֮ǰ����Ŀ�����ݿ⡣
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO 
BEGIN TRANSACTION
SET IDENTITY_INSERT [dbo].[SysModule] ON
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (1, N'�ͻ�����ƽ̨', 0, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (2, N'��ƷĿ¼', 1, N'', N'', N'', N'', 2, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (3, N'�Ͳ��ͺ�', 2, N'', N'Admin', N'Login2', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (4, N'���淽ʽ', 2, N'', N'Admin', N'LoginIn', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (5, N'��װ��ʽ', 2, N'', N'Admin', N'GetModules', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (6, N'�ʺŹ���', 1, N'', N'', N'', N'', 3, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (7, N'�ҵĶ���', 1, N'', N'', N'', N'', 1, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (8, N'�����µ�', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (9, N'��ͳ�µ�', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (10, N'��������', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (11, N'������', 7, N'', N'', N'', N'', 0, 1)
INSERT INTO [dbo].[SysModule] ([ID], [Name], [ParentID], [AreaName], [ControlName], [ActionName], [IConName], [OrderID], [State]) VALUES (12, N'�û���Ϣ', 6, N'', N'Admin', N'ShowUser', N'', 0, 1)
SET IDENTITY_INSERT [dbo].[SysModule] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT INTO [dbo].[UserInfo] ([ID], [UserName], [PassWord], [LoginTime]) VALUES (1, N'admin', N'admin', '20170424 18:38:27.627')
INSERT INTO [dbo].[UserInfo] ([ID], [UserName], [PassWord], [LoginTime]) VALUES (2, N'test01', N'test01', NULL)
INSERT INTO [dbo].[UserInfo] ([ID], [UserName], [PassWord], [LoginTime]) VALUES (3, N'test02', N'test02', NULL)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
COMMIT TRANSACTION
