USE [PHOTO_BOOM]
GO
/****** Object:  Table [dbo].[PHOTO]    Script Date: 15.03.2021 23:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHOTO](
	[PHOTO_ID] [int] IDENTITY(1,1) NOT NULL,
	[PHOTO_NAME] [nvarchar](50) NOT NULL,
	[TITLE] [nvarchar](50) NOT NULL,
	[TAGS] [nvarchar](50) NOT NULL,
	[INSERT_DATE] [date] NOT NULL,
 CONSTRAINT [PK_PHOTO] PRIMARY KEY CLUSTERED 
(
	[PHOTO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PHOTO] ON 

INSERT [dbo].[PHOTO] ([PHOTO_ID], [PHOTO_NAME], [TITLE], [TAGS], [INSERT_DATE]) VALUES (1, N'ef7cf581-365a-467f-9900-1e3e3937b5cc=maldives.jpg', N'When I was in The Maldives', N'#fun, #ocean, #shark', CAST(N'2021-03-15' AS Date))
INSERT [dbo].[PHOTO] ([PHOTO_ID], [PHOTO_NAME], [TITLE], [TAGS], [INSERT_DATE]) VALUES (2, N'ee4efd2b-380c-42a1-b790-12be0d98ccbc=Pyramids.jpg', N'When I was in The Pyramids', N'#tag1 #tag2 #tag3', CAST(N'2021-03-15' AS Date))
SET IDENTITY_INSERT [dbo].[PHOTO] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_PHOTO]    Script Date: 15.03.2021 23:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DELETE_PHOTO]
	@PHOTO_ID	INT
AS
DECLARE @RETURN_VALUE INT

BEGIN
	BEGIN TRY
		DELETE FROM [dbo].[PHOTO]
		WHERE PHOTO_ID = @PHOTO_ID;

		SET @RETURN_VALUE = 1; --If photo delete is successful, the return value is 1
	END TRY
	BEGIN CATCH
		SET @RETURN_VALUE = 0; --If the photo could not be deleted, the return value is 0
	END CATCH

	RETURN @RETURN_VALUE;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_ALL_PHOTOS]    Script Date: 15.03.2021 23:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GET_ALL_PHOTOS]
AS
BEGIN
	SELECT [PHOTO_ID]
		  ,[PHOTO_NAME]
		  ,[TITLE]
		  ,[TAGS]
		  ,[INSERT_DATE]
	  FROM [PHOTO_BOOM].[dbo].[PHOTO] WITH(NOLOCK);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PHOTO]    Script Date: 15.03.2021 23:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GET_PHOTO]
	@PHOTO_ID	INT
AS
BEGIN
	SELECT [PHOTO_ID]
		  ,[PHOTO_NAME]
		  ,[TITLE]
		  ,[TAGS]
	  FROM [PHOTO_BOOM].[dbo].[PHOTO] WITH(NOLOCK)
	 WHERE [PHOTO_ID] = @PHOTO_ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_PHOTO]    Script Date: 15.03.2021 23:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERT_PHOTO]
	@PHOTO_NAME	NVARCHAR(50),
	@TITLE		NVARCHAR(50),
	@TAGS		NVARCHAR(50)
AS
DECLARE @RETURN_VALUE INT

BEGIN
	BEGIN TRY
		INSERT INTO [dbo].[PHOTO]
           ([PHOTO_NAME]
           ,[TITLE]
           ,[TAGS]
           ,[INSERT_DATE])
		VALUES
           (@PHOTO_NAME
           ,@TITLE
           ,@TAGS
           ,GETDATE())

		SET @RETURN_VALUE = 1; --If photo registration is successful, the return value is 1
	END TRY
	BEGIN CATCH
		SET @RETURN_VALUE = 0; --If the photo could not be registered, the return value is 0
	END CATCH

	RETURN @RETURN_VALUE;
END;
GO
