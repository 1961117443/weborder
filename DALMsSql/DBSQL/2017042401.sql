/*
WebOrderT 的部署脚本

此代码由工具生成。
如果重新生成此代码，则对此文件的更改可能导致
不正确的行为并将丢失。
*/
 
PRINT N'正在创建 [dbo].[Log]...';


GO
CREATE TABLE [dbo].[Log] (
    [ID]        INT             IDENTITY (1, 1) NOT NULL,
    [LogDate]   DATETIME        NOT NULL,
    [Thread]    VARCHAR (255)   NOT NULL,
    [LogLevel]  VARCHAR (50)    NOT NULL,
    [Logger]    VARCHAR (255)   NOT NULL,
    [Message]   NVARCHAR (4000) NOT NULL,
    [Exception] NVARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'更新完成。';


GO
