/*
WebOrderT �Ĳ���ű�

�˴����ɹ������ɡ�
����������ɴ˴��룬��Դ��ļ��ĸ��Ŀ��ܵ���
����ȷ����Ϊ������ʧ��
*/
 
PRINT N'���ڴ��� [dbo].[Log]...';


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
PRINT N'������ɡ�';


GO
