USE [UsersAndAwards]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](250) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passwords]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passwords](
	[idUser] [uniqueidentifier] NOT NULL,
	[Password] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Name] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[BirthDate] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Awards]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Awards](
	[id_User] [uniqueidentifier] NOT NULL,
	[id_Award] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddAwardToUser]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAwardToUser]
	@id_User uniqueidentifier,
	@id_Award uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.Users_Awards VALUES (@id_User, @id_Award)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateAuthData]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAuthData] 	
	@id_User uniqueidentifier,
	@Password int
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.Passwords VALUES (@id_User, @Password)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateAward]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAward]
	@id uniqueidentifier,
	@Title nvarchar(250)
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO dbo.Awards VALUES (@id, @Title)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateRole]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateRole]
	@Name nvarchar(100),
	@Role nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO dbo.Roles VALUES (@Name, @Role)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUser]
	@id uniqueidentifier,
	@Name nvarchar(100),
	@BirthDate date,
	@Age smallint
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO dbo.Users VALUES (@id, @Name, @BirthDate, @Age)
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByNameFromUsers]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindUserByNameFromUsers] 
	@Name nvarchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT Name FROM dbo.Users WHERE Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAuthData]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAuthData]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM dbo.Passwords
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwards]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM dbo.Awards
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwardsAndUsers]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwardsAndUsers]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM dbo.Users_Awards
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT * FROM dbo.Users
END
GO
/****** Object:  StoredProcedure [dbo].[getRoles]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getRoles]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM dbo.Roles
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAuthData]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAuthData]
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM dbo.Passwords WHERE idUser = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAward]
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM dbo.Awards WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAwardFromUsers_AwardsTable]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAwardFromUsers_AwardsTable]
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM dbo.Users_Awards WHERE id_Award = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveRole]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveRole]
	@Name nvarchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM dbo.roles WHERE Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveUser]
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM dbo.Users WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUserFromUsers_AwardsTable]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveUserFromUsers_AwardsTable]
	@id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM dbo.Users_Awards WHERE id_User = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@id uniqueidentifier,
	@Title nvarchar(250)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE dbo.Awards SET Title = @Title WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 03.07.2021 0:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser] 
	@id uniqueidentifier,
	@Name nvarchar(100),
	@BirthDate date,
	@Age smallint
AS
BEGIN
	SET NOCOUNT OFF;

    UPDATE dbo.Users SET 
		Name = @Name,
		BirthDate = @BirthDate,
		Age = @Age
		WHERE id = @id
END
GO
