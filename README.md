# OnlineDemo
You can see online users of your system live through this code

script :

CREATE DATABASE OnlineDemoDatabase
GO
USE OnlineDemoDatabase
GO
CREATE TABLE [User]
(
	UserId INT IDENTITY PRIMARY KEY,
	Username NVARCHAR(50) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	LastSeen DATETIME NOT NULL DEFAULT GETDATE()
)
GO
INSERT [User](Username,[Password])
VALUES(N'ramezani',N'0000')
GO
INSERT [User](Username,[Password])
VALUES(N'moumivand',N'0000')
GO
INSERT [User](Username,[Password])
VALUES(N'azimi',N'0000')
GO
INSERT [User](Username,[Password])
VALUES(N'abbasi',N'0000')
GO

