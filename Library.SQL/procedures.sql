
USE [Lib]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Introducer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[Country],
					[City],
					[BirthDate],
					[Position],
					[IsAlive],
					[Mobile],
					[Email],
					[Website],
					[Book_ID],
					[Gender]
				FROM
					[dbo].[Introducer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Introducer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Introducer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[Country], O.[City], O.[BirthDate], O.[Position], O.[IsAlive], O.[Mobile], O.[Email], O.[Website], O.[Book_ID], O.[Gender]
				FROM
				    [dbo].[Introducer] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Introducer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Introducer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_Insert
(

	@ID int    OUTPUT,

	@Name nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@BirthDate date   ,

	@Position nvarchar (50)  ,

	@IsAlive nchar (10)  ,

	@Mobile nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Website nvarchar (50)  ,

	@Book_ID int   ,

	@Gender bit   
)
AS


				
				INSERT INTO [dbo].[Introducer]
					(
					[Name]
					,[Country]
					,[City]
					,[BirthDate]
					,[Position]
					,[IsAlive]
					,[Mobile]
					,[Email]
					,[Website]
					,[Book_ID]
					,[Gender]
					)
				VALUES
					(
					@Name
					,@Country
					,@City
					,@BirthDate
					,@Position
					,@IsAlive
					,@Mobile
					,@Email
					,@Website
					,@Book_ID
					,@Gender
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Introducer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_Update
(

	@ID int   ,

	@Name nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@BirthDate date   ,

	@Position nvarchar (50)  ,

	@IsAlive nchar (10)  ,

	@Mobile nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Website nvarchar (50)  ,

	@Book_ID int   ,

	@Gender bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Introducer]
				SET
					[Name] = @Name
					,[Country] = @Country
					,[City] = @City
					,[BirthDate] = @BirthDate
					,[Position] = @Position
					,[IsAlive] = @IsAlive
					,[Mobile] = @Mobile
					,[Email] = @Email
					,[Website] = @Website
					,[Book_ID] = @Book_ID
					,[Gender] = @Gender
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Introducer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Introducer] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Introducer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[Name],
					[Country],
					[City],
					[BirthDate],
					[Position],
					[IsAlive],
					[Mobile],
					[Email],
					[Website],
					[Book_ID],
					[Gender]
				FROM
					[dbo].[Introducer]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Introducer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Introducer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Introducer_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Introducer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Introducer_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Name nvarchar (50)  = null ,

	@Country nvarchar (50)  = null ,

	@City nvarchar (50)  = null ,

	@BirthDate date   = null ,

	@Position nvarchar (50)  = null ,

	@IsAlive nchar (10)  = null ,

	@Mobile nvarchar (50)  = null ,

	@Email nvarchar (50)  = null ,

	@Website nvarchar (50)  = null ,

	@Book_ID int   = null ,

	@Gender bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Country]
	, [City]
	, [BirthDate]
	, [Position]
	, [IsAlive]
	, [Mobile]
	, [Email]
	, [Website]
	, [Book_ID]
	, [Gender]
    FROM
	[dbo].[Introducer]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([BirthDate] = @BirthDate OR @BirthDate IS NULL)
	AND ([Position] = @Position OR @Position IS NULL)
	AND ([IsAlive] = @IsAlive OR @IsAlive IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Website] = @Website OR @Website IS NULL)
	AND ([Book_ID] = @Book_ID OR @Book_ID IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Country]
	, [City]
	, [BirthDate]
	, [Position]
	, [IsAlive]
	, [Mobile]
	, [Email]
	, [Website]
	, [Book_ID]
	, [Gender]
    FROM
	[dbo].[Introducer]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([City] = @City AND @City is not null)
	OR ([BirthDate] = @BirthDate AND @BirthDate is not null)
	OR ([Position] = @Position AND @Position is not null)
	OR ([IsAlive] = @IsAlive AND @IsAlive is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([Book_ID] = @Book_ID AND @Book_ID is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[Country],
					[City],
					[BirthDate],
					[Position],
					[IsAlive],
					[Mobile],
					[Email],
					[Website],
					[Gender]
				FROM
					[dbo].[Author]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Author table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Author]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[Country], O.[City], O.[BirthDate], O.[Position], O.[IsAlive], O.[Mobile], O.[Email], O.[Website], O.[Gender]
				FROM
				    [dbo].[Author] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Author]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_Insert
(

	@ID int    OUTPUT,

	@Name nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@BirthDate date   ,

	@Position nvarchar (50)  ,

	@IsAlive nchar (10)  ,

	@Mobile nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Website nvarchar (50)  ,

	@Gender bit   
)
AS


				
				INSERT INTO [dbo].[Author]
					(
					[Name]
					,[Country]
					,[City]
					,[BirthDate]
					,[Position]
					,[IsAlive]
					,[Mobile]
					,[Email]
					,[Website]
					,[Gender]
					)
				VALUES
					(
					@Name
					,@Country
					,@City
					,@BirthDate
					,@Position
					,@IsAlive
					,@Mobile
					,@Email
					,@Website
					,@Gender
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_Update
(

	@ID int   ,

	@Name nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@BirthDate date   ,

	@Position nvarchar (50)  ,

	@IsAlive nchar (10)  ,

	@Mobile nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Website nvarchar (50)  ,

	@Gender bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Author]
				SET
					[Name] = @Name
					,[Country] = @Country
					,[City] = @City
					,[BirthDate] = @BirthDate
					,[Position] = @Position
					,[IsAlive] = @IsAlive
					,[Mobile] = @Mobile
					,[Email] = @Email
					,[Website] = @Website
					,[Gender] = @Gender
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Author] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Author table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[Name],
					[Country],
					[City],
					[BirthDate],
					[Position],
					[IsAlive],
					[Mobile],
					[Email],
					[Website],
					[Gender]
				FROM
					[dbo].[Author]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_GetByBook_IDFromBook_Author procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_GetByBook_IDFromBook_Author') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_GetByBook_IDFromBook_Author
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_GetByBook_IDFromBook_Author
(

	@Book_ID int   
)
AS


SELECT dbo.[Author].[ID]
       ,dbo.[Author].[Name]
       ,dbo.[Author].[Country]
       ,dbo.[Author].[City]
       ,dbo.[Author].[BirthDate]
       ,dbo.[Author].[Position]
       ,dbo.[Author].[IsAlive]
       ,dbo.[Author].[Mobile]
       ,dbo.[Author].[Email]
       ,dbo.[Author].[Website]
       ,dbo.[Author].[Gender]
  FROM dbo.[Author]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Book_Author] 
                WHERE dbo.[Book_Author].[Book_ID] = @Book_ID
                  AND dbo.[Book_Author].[Author_ID] = dbo.[Author].[ID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Author_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Author_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Author_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Author table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Author_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Name nvarchar (50)  = null ,

	@Country nvarchar (50)  = null ,

	@City nvarchar (50)  = null ,

	@BirthDate date   = null ,

	@Position nvarchar (50)  = null ,

	@IsAlive nchar (10)  = null ,

	@Mobile nvarchar (50)  = null ,

	@Email nvarchar (50)  = null ,

	@Website nvarchar (50)  = null ,

	@Gender bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Country]
	, [City]
	, [BirthDate]
	, [Position]
	, [IsAlive]
	, [Mobile]
	, [Email]
	, [Website]
	, [Gender]
    FROM
	[dbo].[Author]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([BirthDate] = @BirthDate OR @BirthDate IS NULL)
	AND ([Position] = @Position OR @Position IS NULL)
	AND ([IsAlive] = @IsAlive OR @IsAlive IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Website] = @Website OR @Website IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Country]
	, [City]
	, [BirthDate]
	, [Position]
	, [IsAlive]
	, [Mobile]
	, [Email]
	, [Website]
	, [Gender]
    FROM
	[dbo].[Author]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([City] = @City AND @City is not null)
	OR ([BirthDate] = @BirthDate AND @BirthDate is not null)
	OR ([Position] = @Position AND @Position is not null)
	OR ([IsAlive] = @IsAlive AND @IsAlive is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Publisher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[Mobile],
					[Email],
					[Website],
					[FounedOn],
					[Country],
					[City],
					[Address]
				FROM
					[dbo].[Publisher]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Publisher table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Publisher]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[Mobile], O.[Email], O.[Website], O.[FounedOn], O.[Country], O.[City], O.[Address]
				FROM
				    [dbo].[Publisher] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Publisher]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Publisher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_Insert
(

	@ID int    OUTPUT,

	@Name nvarchar (50)  ,

	@Mobile nchar (14)  ,

	@Email nvarchar (50)  ,

	@Website nvarchar (50)  ,

	@FounedOn date   ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@Address nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[Publisher]
					(
					[Name]
					,[Mobile]
					,[Email]
					,[Website]
					,[FounedOn]
					,[Country]
					,[City]
					,[Address]
					)
				VALUES
					(
					@Name
					,@Mobile
					,@Email
					,@Website
					,@FounedOn
					,@Country
					,@City
					,@Address
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Publisher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_Update
(

	@ID int   ,

	@Name nvarchar (50)  ,

	@Mobile nchar (14)  ,

	@Email nvarchar (50)  ,

	@Website nvarchar (50)  ,

	@FounedOn date   ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@Address nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Publisher]
				SET
					[Name] = @Name
					,[Mobile] = @Mobile
					,[Email] = @Email
					,[Website] = @Website
					,[FounedOn] = @FounedOn
					,[Country] = @Country
					,[City] = @City
					,[Address] = @Address
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Publisher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Publisher] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Publisher table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[Name],
					[Mobile],
					[Email],
					[Website],
					[FounedOn],
					[Country],
					[City],
					[Address]
				FROM
					[dbo].[Publisher]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Publisher_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Publisher_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Publisher_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Publisher table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Publisher_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Name nvarchar (50)  = null ,

	@Mobile nchar (14)  = null ,

	@Email nvarchar (50)  = null ,

	@Website nvarchar (50)  = null ,

	@FounedOn date   = null ,

	@Country nvarchar (50)  = null ,

	@City nvarchar (50)  = null ,

	@Address nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Mobile]
	, [Email]
	, [Website]
	, [FounedOn]
	, [Country]
	, [City]
	, [Address]
    FROM
	[dbo].[Publisher]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Website] = @Website OR @Website IS NULL)
	AND ([FounedOn] = @FounedOn OR @FounedOn IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Mobile]
	, [Email]
	, [Website]
	, [FounedOn]
	, [Country]
	, [City]
	, [Address]
    FROM
	[dbo].[Publisher]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([FounedOn] = @FounedOn AND @FounedOn is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([City] = @City AND @City is not null)
	OR ([Address] = @Address AND @Address is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Get_List

AS


				
				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Employee]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Employee table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Employee]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[UserName], O.[Password], O.[Last_Login], O.[Last_Logout], O.[Is_Online], O.[Is_Active], O.[Is_Admin], O.[First_Name], O.[Last_Name], O.[Email], O.[Country], O.[City], O.[Address], O.[Mobile], O.[Phone], O.[Postion], O.[Is_Deleted], O.[CreatedOn], O.[CreatedBy], O.[UpdatedOn], O.[UpdatedBy], O.[DeletedOn], O.[DeletedBy]
				FROM
				    [dbo].[Employee] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Employee]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Insert
(

	@ID int    OUTPUT,

	@UserName nvarchar (50)  ,

	@Password nvarchar (50)  ,

	@Last_Login datetime   ,

	@Last_Logout datetime   ,

	@Is_Online bit   ,

	@Is_Active bit   ,

	@Is_Admin bit   ,

	@First_Name nvarchar (50)  ,

	@Last_Name nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@Address nvarchar (50)  ,

	@Mobile nvarchar (50)  ,

	@Phone nvarchar (50)  ,

	@Postion nvarchar (50)  ,

	@Is_Deleted bit   ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				INSERT INTO [dbo].[Employee]
					(
					[UserName]
					,[Password]
					,[Last_Login]
					,[Last_Logout]
					,[Is_Online]
					,[Is_Active]
					,[Is_Admin]
					,[First_Name]
					,[Last_Name]
					,[Email]
					,[Country]
					,[City]
					,[Address]
					,[Mobile]
					,[Phone]
					,[Postion]
					,[Is_Deleted]
					,[CreatedOn]
					,[CreatedBy]
					,[UpdatedOn]
					,[UpdatedBy]
					,[DeletedOn]
					,[DeletedBy]
					)
				VALUES
					(
					@UserName
					,@Password
					,@Last_Login
					,@Last_Logout
					,@Is_Online
					,@Is_Active
					,@Is_Admin
					,@First_Name
					,@Last_Name
					,@Email
					,@Country
					,@City
					,@Address
					,@Mobile
					,@Phone
					,@Postion
					,@Is_Deleted
					,@CreatedOn
					,@CreatedBy
					,@UpdatedOn
					,@UpdatedBy
					,@DeletedOn
					,@DeletedBy
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Update
(

	@ID int   ,

	@UserName nvarchar (50)  ,

	@Password nvarchar (50)  ,

	@Last_Login datetime   ,

	@Last_Logout datetime   ,

	@Is_Online bit   ,

	@Is_Active bit   ,

	@Is_Admin bit   ,

	@First_Name nvarchar (50)  ,

	@Last_Name nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@Address nvarchar (50)  ,

	@Mobile nvarchar (50)  ,

	@Phone nvarchar (50)  ,

	@Postion nvarchar (50)  ,

	@Is_Deleted bit   ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Employee]
				SET
					[UserName] = @UserName
					,[Password] = @Password
					,[Last_Login] = @Last_Login
					,[Last_Logout] = @Last_Logout
					,[Is_Online] = @Is_Online
					,[Is_Active] = @Is_Active
					,[Is_Admin] = @Is_Admin
					,[First_Name] = @First_Name
					,[Last_Name] = @Last_Name
					,[Email] = @Email
					,[Country] = @Country
					,[City] = @City
					,[Address] = @Address
					,[Mobile] = @Mobile
					,[Phone] = @Phone
					,[Postion] = @Postion
					,[Is_Deleted] = @Is_Deleted
					,[CreatedOn] = @CreatedOn
					,[CreatedBy] = @CreatedBy
					,[UpdatedOn] = @UpdatedOn
					,[UpdatedBy] = @UpdatedBy
					,[DeletedOn] = @DeletedOn
					,[DeletedBy] = @DeletedBy
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Employee] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_GetByUserName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_GetByUserName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_GetByUserName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Employee table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_GetByUserName
(

	@UserName nvarchar (50)  
)
AS


				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Employee]
				WHERE
					[UserName] = @UserName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Employee table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Employee]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Employee table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@UserName nvarchar (50)  = null ,

	@Password nvarchar (50)  = null ,

	@Last_Login datetime   = null ,

	@Last_Logout datetime   = null ,

	@Is_Online bit   = null ,

	@Is_Active bit   = null ,

	@Is_Admin bit   = null ,

	@First_Name nvarchar (50)  = null ,

	@Last_Name nvarchar (50)  = null ,

	@Email nvarchar (50)  = null ,

	@Country nvarchar (50)  = null ,

	@City nvarchar (50)  = null ,

	@Address nvarchar (50)  = null ,

	@Mobile nvarchar (50)  = null ,

	@Phone nvarchar (50)  = null ,

	@Postion nvarchar (50)  = null ,

	@Is_Deleted bit   = null ,

	@CreatedOn datetime   = null ,

	@CreatedBy int   = null ,

	@UpdatedOn datetime   = null ,

	@UpdatedBy int   = null ,

	@DeletedOn datetime   = null ,

	@DeletedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [UserName]
	, [Password]
	, [Last_Login]
	, [Last_Logout]
	, [Is_Online]
	, [Is_Active]
	, [Is_Admin]
	, [First_Name]
	, [Last_Name]
	, [Email]
	, [Country]
	, [City]
	, [Address]
	, [Mobile]
	, [Phone]
	, [Postion]
	, [Is_Deleted]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Employee]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([Last_Login] = @Last_Login OR @Last_Login IS NULL)
	AND ([Last_Logout] = @Last_Logout OR @Last_Logout IS NULL)
	AND ([Is_Online] = @Is_Online OR @Is_Online IS NULL)
	AND ([Is_Active] = @Is_Active OR @Is_Active IS NULL)
	AND ([Is_Admin] = @Is_Admin OR @Is_Admin IS NULL)
	AND ([First_Name] = @First_Name OR @First_Name IS NULL)
	AND ([Last_Name] = @Last_Name OR @Last_Name IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Postion] = @Postion OR @Postion IS NULL)
	AND ([Is_Deleted] = @Is_Deleted OR @Is_Deleted IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
	AND ([CreatedBy] = @CreatedBy OR @CreatedBy IS NULL)
	AND ([UpdatedOn] = @UpdatedOn OR @UpdatedOn IS NULL)
	AND ([UpdatedBy] = @UpdatedBy OR @UpdatedBy IS NULL)
	AND ([DeletedOn] = @DeletedOn OR @DeletedOn IS NULL)
	AND ([DeletedBy] = @DeletedBy OR @DeletedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [UserName]
	, [Password]
	, [Last_Login]
	, [Last_Logout]
	, [Is_Online]
	, [Is_Active]
	, [Is_Admin]
	, [First_Name]
	, [Last_Name]
	, [Email]
	, [Country]
	, [City]
	, [Address]
	, [Mobile]
	, [Phone]
	, [Postion]
	, [Is_Deleted]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Employee]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([Last_Login] = @Last_Login AND @Last_Login is not null)
	OR ([Last_Logout] = @Last_Logout AND @Last_Logout is not null)
	OR ([Is_Online] = @Is_Online AND @Is_Online is not null)
	OR ([Is_Active] = @Is_Active AND @Is_Active is not null)
	OR ([Is_Admin] = @Is_Admin AND @Is_Admin is not null)
	OR ([First_Name] = @First_Name AND @First_Name is not null)
	OR ([Last_Name] = @Last_Name AND @Last_Name is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([City] = @City AND @City is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Postion] = @Postion AND @Postion is not null)
	OR ([Is_Deleted] = @Is_Deleted AND @Is_Deleted is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	OR ([CreatedBy] = @CreatedBy AND @CreatedBy is not null)
	OR ([UpdatedOn] = @UpdatedOn AND @UpdatedOn is not null)
	OR ([UpdatedBy] = @UpdatedBy AND @UpdatedBy is not null)
	OR ([DeletedOn] = @DeletedOn AND @DeletedOn is not null)
	OR ([DeletedBy] = @DeletedBy AND @DeletedBy is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Get_List

AS


				
				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[UserType_ID],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Users]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Users table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[UserName], O.[Password], O.[Last_Login], O.[Last_Logout], O.[Is_Online], O.[Is_Active], O.[Is_Admin], O.[UserType_ID], O.[First_Name], O.[Last_Name], O.[Email], O.[Country], O.[City], O.[Address], O.[Mobile], O.[Phone], O.[Postion], O.[Is_Deleted], O.[CreatedOn], O.[CreatedBy], O.[UpdatedOn], O.[UpdatedBy], O.[DeletedOn], O.[DeletedBy]
				FROM
				    [dbo].[Users] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Insert
(

	@ID int    OUTPUT,

	@UserName nvarchar (50)  ,

	@Password nvarchar (50)  ,

	@Last_Login datetime   ,

	@Last_Logout datetime   ,

	@Is_Online bit   ,

	@Is_Active bit   ,

	@Is_Admin bit   ,

	@UserType_ID int   ,

	@First_Name nvarchar (50)  ,

	@Last_Name nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@Address nvarchar (50)  ,

	@Mobile nvarchar (50)  ,

	@Phone nvarchar (50)  ,

	@Postion nvarchar (50)  ,

	@Is_Deleted bit   ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				INSERT INTO [dbo].[Users]
					(
					[UserName]
					,[Password]
					,[Last_Login]
					,[Last_Logout]
					,[Is_Online]
					,[Is_Active]
					,[Is_Admin]
					,[UserType_ID]
					,[First_Name]
					,[Last_Name]
					,[Email]
					,[Country]
					,[City]
					,[Address]
					,[Mobile]
					,[Phone]
					,[Postion]
					,[Is_Deleted]
					,[CreatedOn]
					,[CreatedBy]
					,[UpdatedOn]
					,[UpdatedBy]
					,[DeletedOn]
					,[DeletedBy]
					)
				VALUES
					(
					@UserName
					,@Password
					,@Last_Login
					,@Last_Logout
					,@Is_Online
					,@Is_Active
					,@Is_Admin
					,@UserType_ID
					,@First_Name
					,@Last_Name
					,@Email
					,@Country
					,@City
					,@Address
					,@Mobile
					,@Phone
					,@Postion
					,@Is_Deleted
					,@CreatedOn
					,@CreatedBy
					,@UpdatedOn
					,@UpdatedBy
					,@DeletedOn
					,@DeletedBy
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Update
(

	@ID int   ,

	@UserName nvarchar (50)  ,

	@Password nvarchar (50)  ,

	@Last_Login datetime   ,

	@Last_Logout datetime   ,

	@Is_Online bit   ,

	@Is_Active bit   ,

	@Is_Admin bit   ,

	@UserType_ID int   ,

	@First_Name nvarchar (50)  ,

	@Last_Name nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@Country nvarchar (50)  ,

	@City nvarchar (50)  ,

	@Address nvarchar (50)  ,

	@Mobile nvarchar (50)  ,

	@Phone nvarchar (50)  ,

	@Postion nvarchar (50)  ,

	@Is_Deleted bit   ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Users]
				SET
					[UserName] = @UserName
					,[Password] = @Password
					,[Last_Login] = @Last_Login
					,[Last_Logout] = @Last_Logout
					,[Is_Online] = @Is_Online
					,[Is_Active] = @Is_Active
					,[Is_Admin] = @Is_Admin
					,[UserType_ID] = @UserType_ID
					,[First_Name] = @First_Name
					,[Last_Name] = @Last_Name
					,[Email] = @Email
					,[Country] = @Country
					,[City] = @City
					,[Address] = @Address
					,[Mobile] = @Mobile
					,[Phone] = @Phone
					,[Postion] = @Postion
					,[Is_Deleted] = @Is_Deleted
					,[CreatedOn] = @CreatedOn
					,[CreatedBy] = @CreatedBy
					,[UpdatedOn] = @UpdatedOn
					,[UpdatedBy] = @UpdatedBy
					,[DeletedOn] = @DeletedOn
					,[DeletedBy] = @DeletedBy
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Users] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_GetByUserType_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_GetByUserType_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_GetByUserType_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Users table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_GetByUserType_ID
(

	@UserType_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[UserType_ID],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Users]
				WHERE
					[UserType_ID] = @UserType_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_GetByUserName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_GetByUserName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_GetByUserName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Users table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_GetByUserName
(

	@UserName nvarchar (50)  
)
AS


				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[UserType_ID],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Users]
				WHERE
					[UserName] = @UserName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Users table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[UserName],
					[Password],
					[Last_Login],
					[Last_Logout],
					[Is_Online],
					[Is_Active],
					[Is_Admin],
					[UserType_ID],
					[First_Name],
					[Last_Name],
					[Email],
					[Country],
					[City],
					[Address],
					[Mobile],
					[Phone],
					[Postion],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Users]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Users table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@UserName nvarchar (50)  = null ,

	@Password nvarchar (50)  = null ,

	@Last_Login datetime   = null ,

	@Last_Logout datetime   = null ,

	@Is_Online bit   = null ,

	@Is_Active bit   = null ,

	@Is_Admin bit   = null ,

	@UserType_ID int   = null ,

	@First_Name nvarchar (50)  = null ,

	@Last_Name nvarchar (50)  = null ,

	@Email nvarchar (50)  = null ,

	@Country nvarchar (50)  = null ,

	@City nvarchar (50)  = null ,

	@Address nvarchar (50)  = null ,

	@Mobile nvarchar (50)  = null ,

	@Phone nvarchar (50)  = null ,

	@Postion nvarchar (50)  = null ,

	@Is_Deleted bit   = null ,

	@CreatedOn datetime   = null ,

	@CreatedBy int   = null ,

	@UpdatedOn datetime   = null ,

	@UpdatedBy int   = null ,

	@DeletedOn datetime   = null ,

	@DeletedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [UserName]
	, [Password]
	, [Last_Login]
	, [Last_Logout]
	, [Is_Online]
	, [Is_Active]
	, [Is_Admin]
	, [UserType_ID]
	, [First_Name]
	, [Last_Name]
	, [Email]
	, [Country]
	, [City]
	, [Address]
	, [Mobile]
	, [Phone]
	, [Postion]
	, [Is_Deleted]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Users]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([Last_Login] = @Last_Login OR @Last_Login IS NULL)
	AND ([Last_Logout] = @Last_Logout OR @Last_Logout IS NULL)
	AND ([Is_Online] = @Is_Online OR @Is_Online IS NULL)
	AND ([Is_Active] = @Is_Active OR @Is_Active IS NULL)
	AND ([Is_Admin] = @Is_Admin OR @Is_Admin IS NULL)
	AND ([UserType_ID] = @UserType_ID OR @UserType_ID IS NULL)
	AND ([First_Name] = @First_Name OR @First_Name IS NULL)
	AND ([Last_Name] = @Last_Name OR @Last_Name IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Postion] = @Postion OR @Postion IS NULL)
	AND ([Is_Deleted] = @Is_Deleted OR @Is_Deleted IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
	AND ([CreatedBy] = @CreatedBy OR @CreatedBy IS NULL)
	AND ([UpdatedOn] = @UpdatedOn OR @UpdatedOn IS NULL)
	AND ([UpdatedBy] = @UpdatedBy OR @UpdatedBy IS NULL)
	AND ([DeletedOn] = @DeletedOn OR @DeletedOn IS NULL)
	AND ([DeletedBy] = @DeletedBy OR @DeletedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [UserName]
	, [Password]
	, [Last_Login]
	, [Last_Logout]
	, [Is_Online]
	, [Is_Active]
	, [Is_Admin]
	, [UserType_ID]
	, [First_Name]
	, [Last_Name]
	, [Email]
	, [Country]
	, [City]
	, [Address]
	, [Mobile]
	, [Phone]
	, [Postion]
	, [Is_Deleted]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Users]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([Last_Login] = @Last_Login AND @Last_Login is not null)
	OR ([Last_Logout] = @Last_Logout AND @Last_Logout is not null)
	OR ([Is_Online] = @Is_Online AND @Is_Online is not null)
	OR ([Is_Active] = @Is_Active AND @Is_Active is not null)
	OR ([Is_Admin] = @Is_Admin AND @Is_Admin is not null)
	OR ([UserType_ID] = @UserType_ID AND @UserType_ID is not null)
	OR ([First_Name] = @First_Name AND @First_Name is not null)
	OR ([Last_Name] = @Last_Name AND @Last_Name is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([City] = @City AND @City is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Postion] = @Postion AND @Postion is not null)
	OR ([Is_Deleted] = @Is_Deleted AND @Is_Deleted is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	OR ([CreatedBy] = @CreatedBy AND @CreatedBy is not null)
	OR ([UpdatedOn] = @UpdatedOn AND @UpdatedOn is not null)
	OR ([UpdatedBy] = @UpdatedBy AND @UpdatedBy is not null)
	OR ([DeletedOn] = @DeletedOn AND @DeletedOn is not null)
	OR ([DeletedBy] = @DeletedBy AND @DeletedBy is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Course table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_Get_List

AS


				
				SELECT
					[ID],
					[Course_Name],
					[Course_Scope],
					[Duration],
					[DurationType_ID],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Course]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Course table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Course]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Course_Name], O.[Course_Scope], O.[Duration], O.[DurationType_ID], O.[Is_Deleted], O.[CreatedOn], O.[CreatedBy], O.[UpdatedOn], O.[UpdatedBy], O.[DeletedOn], O.[DeletedBy]
				FROM
				    [dbo].[Course] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Course]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Course table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_Insert
(

	@ID int    OUTPUT,

	@Course_Name nvarchar (200)  ,

	@Course_Scope int   ,

	@Duration int   ,

	@DurationType_ID int   ,

	@Is_Deleted bit   ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				INSERT INTO [dbo].[Course]
					(
					[Course_Name]
					,[Course_Scope]
					,[Duration]
					,[DurationType_ID]
					,[Is_Deleted]
					,[CreatedOn]
					,[CreatedBy]
					,[UpdatedOn]
					,[UpdatedBy]
					,[DeletedOn]
					,[DeletedBy]
					)
				VALUES
					(
					@Course_Name
					,@Course_Scope
					,@Duration
					,@DurationType_ID
					,@Is_Deleted
					,@CreatedOn
					,@CreatedBy
					,@UpdatedOn
					,@UpdatedBy
					,@DeletedOn
					,@DeletedBy
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Course table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_Update
(

	@ID int   ,

	@Course_Name nvarchar (200)  ,

	@Course_Scope int   ,

	@Duration int   ,

	@DurationType_ID int   ,

	@Is_Deleted bit   ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Course]
				SET
					[Course_Name] = @Course_Name
					,[Course_Scope] = @Course_Scope
					,[Duration] = @Duration
					,[DurationType_ID] = @DurationType_ID
					,[Is_Deleted] = @Is_Deleted
					,[CreatedOn] = @CreatedOn
					,[CreatedBy] = @CreatedBy
					,[UpdatedOn] = @UpdatedOn
					,[UpdatedBy] = @UpdatedBy
					,[DeletedOn] = @DeletedOn
					,[DeletedBy] = @DeletedBy
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Course table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Course] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Course table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[Course_Name],
					[Course_Scope],
					[Duration],
					[DurationType_ID],
					[Is_Deleted],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Course]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Course_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Course_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Course_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Course table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Course_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Course_Name nvarchar (200)  = null ,

	@Course_Scope int   = null ,

	@Duration int   = null ,

	@DurationType_ID int   = null ,

	@Is_Deleted bit   = null ,

	@CreatedOn datetime   = null ,

	@CreatedBy int   = null ,

	@UpdatedOn datetime   = null ,

	@UpdatedBy int   = null ,

	@DeletedOn datetime   = null ,

	@DeletedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Course_Name]
	, [Course_Scope]
	, [Duration]
	, [DurationType_ID]
	, [Is_Deleted]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Course]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Course_Name] = @Course_Name OR @Course_Name IS NULL)
	AND ([Course_Scope] = @Course_Scope OR @Course_Scope IS NULL)
	AND ([Duration] = @Duration OR @Duration IS NULL)
	AND ([DurationType_ID] = @DurationType_ID OR @DurationType_ID IS NULL)
	AND ([Is_Deleted] = @Is_Deleted OR @Is_Deleted IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
	AND ([CreatedBy] = @CreatedBy OR @CreatedBy IS NULL)
	AND ([UpdatedOn] = @UpdatedOn OR @UpdatedOn IS NULL)
	AND ([UpdatedBy] = @UpdatedBy OR @UpdatedBy IS NULL)
	AND ([DeletedOn] = @DeletedOn OR @DeletedOn IS NULL)
	AND ([DeletedBy] = @DeletedBy OR @DeletedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Course_Name]
	, [Course_Scope]
	, [Duration]
	, [DurationType_ID]
	, [Is_Deleted]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Course]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Course_Name] = @Course_Name AND @Course_Name is not null)
	OR ([Course_Scope] = @Course_Scope AND @Course_Scope is not null)
	OR ([Duration] = @Duration AND @Duration is not null)
	OR ([DurationType_ID] = @DurationType_ID AND @DurationType_ID is not null)
	OR ([Is_Deleted] = @Is_Deleted AND @Is_Deleted is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	OR ([CreatedBy] = @CreatedBy AND @CreatedBy is not null)
	OR ([UpdatedOn] = @UpdatedOn AND @UpdatedOn is not null)
	OR ([UpdatedBy] = @UpdatedBy AND @UpdatedBy is not null)
	OR ([DeletedOn] = @DeletedOn AND @DeletedOn is not null)
	OR ([DeletedBy] = @DeletedBy AND @DeletedBy is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the BookType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_Get_List

AS


				
				SELECT
					[ID],
					[TypeName]
				FROM
					[dbo].[BookType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the BookType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[BookType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[TypeName]
				FROM
				    [dbo].[BookType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[BookType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the BookType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_Insert
(

	@ID int    OUTPUT,

	@TypeName nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[BookType]
					(
					[TypeName]
					)
				VALUES
					(
					@TypeName
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the BookType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_Update
(

	@ID int   ,

	@TypeName nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[BookType]
				SET
					[TypeName] = @TypeName
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the BookType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[BookType] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the BookType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[TypeName]
				FROM
					[dbo].[BookType]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the BookType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookType_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@TypeName nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [TypeName]
    FROM
	[dbo].[BookType]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([TypeName] = @TypeName OR @TypeName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [TypeName]
    FROM
	[dbo].[BookType]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([TypeName] = @TypeName AND @TypeName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the BookImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[Format],
					[Size],
					[Link],
					[IsAvailable]
				FROM
					[dbo].[BookImage]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the BookImage table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[BookImage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[Format], O.[Size], O.[Link], O.[IsAvailable]
				FROM
				    [dbo].[BookImage] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[BookImage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the BookImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_Insert
(

	@ID int    OUTPUT,

	@Name nvarchar (50)  ,

	@Format nvarchar (50)  ,

	@Size nvarchar (50)  ,

	@Link nvarchar (50)  ,

	@IsAvailable nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[BookImage]
					(
					[Name]
					,[Format]
					,[Size]
					,[Link]
					,[IsAvailable]
					)
				VALUES
					(
					@Name
					,@Format
					,@Size
					,@Link
					,@IsAvailable
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the BookImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_Update
(

	@ID int   ,

	@Name nvarchar (50)  ,

	@Format nvarchar (50)  ,

	@Size nvarchar (50)  ,

	@Link nvarchar (50)  ,

	@IsAvailable nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[BookImage]
				SET
					[Name] = @Name
					,[Format] = @Format
					,[Size] = @Size
					,[Link] = @Link
					,[IsAvailable] = @IsAvailable
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the BookImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[BookImage] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the BookImage table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[Name],
					[Format],
					[Size],
					[Link],
					[IsAvailable]
				FROM
					[dbo].[BookImage]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BookImage_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BookImage_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BookImage_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the BookImage table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BookImage_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Name nvarchar (50)  = null ,

	@Format nvarchar (50)  = null ,

	@Size nvarchar (50)  = null ,

	@Link nvarchar (50)  = null ,

	@IsAvailable nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Format]
	, [Size]
	, [Link]
	, [IsAvailable]
    FROM
	[dbo].[BookImage]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Format] = @Format OR @Format IS NULL)
	AND ([Size] = @Size OR @Size IS NULL)
	AND ([Link] = @Link OR @Link IS NULL)
	AND ([IsAvailable] = @IsAvailable OR @IsAvailable IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Format]
	, [Size]
	, [Link]
	, [IsAvailable]
    FROM
	[dbo].[BookImage]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Format] = @Format AND @Format is not null)
	OR ([Size] = @Size AND @Size is not null)
	OR ([Link] = @Link AND @Link is not null)
	OR ([IsAvailable] = @IsAvailable AND @IsAvailable is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Get_List

AS


				
				SELECT
					[ID],
					[TypeName]
				FROM
					[dbo].[UserType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the UserType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[UserType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[TypeName]
				FROM
				    [dbo].[UserType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[UserType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Insert
(

	@ID int    OUTPUT,

	@TypeName nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[UserType]
					(
					[TypeName]
					)
				VALUES
					(
					@TypeName
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Update
(

	@ID int   ,

	@TypeName nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[UserType]
				SET
					[TypeName] = @TypeName
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[UserType] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the UserType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[TypeName]
				FROM
					[dbo].[UserType]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the UserType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@TypeName nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [TypeName]
    FROM
	[dbo].[UserType]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([TypeName] = @TypeName OR @TypeName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [TypeName]
    FROM
	[dbo].[UserType]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([TypeName] = @TypeName AND @TypeName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Book table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Book table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Book]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[Publisher], O.[Publish_Date], O.[IsAvailablePdf], O.[IsAvailablePaper], O.[IsBorrowed], O.[User_ID], O.[BorrowDate], O.[Borrow_Times], O.[IsLost], O.[Type_ID], O.[Publisher_ID], O.[Papers_no], O.[Introducer_ID], O.[EmployeeI_D], O.[Size], O.[Price], O.[Pdf_Link], O.[Image_ID], O.[ISBN], O.[CreatedOn], O.[CreatedBy], O.[UpdatedOn], O.[UpdatedBy], O.[DeletedOn], O.[DeletedBy]
				FROM
				    [dbo].[Book] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Book]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Book table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Insert
(

	@ID int    OUTPUT,

	@Name nvarchar (100)  ,

	@Publisher nvarchar (50)  ,

	@Publish_Date date   ,

	@IsAvailablePdf bit   ,

	@IsAvailablePaper bit   ,

	@IsBorrowed bit   ,

	@User_ID int   ,

	@BorrowDate date   ,

	@Borrow_Times int   ,

	@IsLost bit   ,

	@Type_ID int   ,

	@Publisher_ID int   ,

	@Papers_no int   ,

	@Introducer_ID int   ,

	@EmployeeI_D int   ,

	@Size float   ,

	@Price int   ,

	@Pdf_Link nvarchar (250)  ,

	@Image_ID int   ,

	@ISBN nvarchar (50)  ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				INSERT INTO [dbo].[Book]
					(
					[Name]
					,[Publisher]
					,[Publish_Date]
					,[IsAvailablePdf]
					,[IsAvailablePaper]
					,[IsBorrowed]
					,[User_ID]
					,[BorrowDate]
					,[Borrow_Times]
					,[IsLost]
					,[Type_ID]
					,[Publisher_ID]
					,[Papers_no]
					,[Introducer_ID]
					,[EmployeeI_D]
					,[Size]
					,[Price]
					,[Pdf_Link]
					,[Image_ID]
					,[ISBN]
					,[CreatedOn]
					,[CreatedBy]
					,[UpdatedOn]
					,[UpdatedBy]
					,[DeletedOn]
					,[DeletedBy]
					)
				VALUES
					(
					@Name
					,@Publisher
					,@Publish_Date
					,@IsAvailablePdf
					,@IsAvailablePaper
					,@IsBorrowed
					,@User_ID
					,@BorrowDate
					,@Borrow_Times
					,@IsLost
					,@Type_ID
					,@Publisher_ID
					,@Papers_no
					,@Introducer_ID
					,@EmployeeI_D
					,@Size
					,@Price
					,@Pdf_Link
					,@Image_ID
					,@ISBN
					,@CreatedOn
					,@CreatedBy
					,@UpdatedOn
					,@UpdatedBy
					,@DeletedOn
					,@DeletedBy
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Book table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Update
(

	@ID int   ,

	@Name nvarchar (100)  ,

	@Publisher nvarchar (50)  ,

	@Publish_Date date   ,

	@IsAvailablePdf bit   ,

	@IsAvailablePaper bit   ,

	@IsBorrowed bit   ,

	@User_ID int   ,

	@BorrowDate date   ,

	@Borrow_Times int   ,

	@IsLost bit   ,

	@Type_ID int   ,

	@Publisher_ID int   ,

	@Papers_no int   ,

	@Introducer_ID int   ,

	@EmployeeI_D int   ,

	@Size float   ,

	@Price int   ,

	@Pdf_Link nvarchar (250)  ,

	@Image_ID int   ,

	@ISBN nvarchar (50)  ,

	@CreatedOn datetime   ,

	@CreatedBy int   ,

	@UpdatedOn datetime   ,

	@UpdatedBy int   ,

	@DeletedOn datetime   ,

	@DeletedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Book]
				SET
					[Name] = @Name
					,[Publisher] = @Publisher
					,[Publish_Date] = @Publish_Date
					,[IsAvailablePdf] = @IsAvailablePdf
					,[IsAvailablePaper] = @IsAvailablePaper
					,[IsBorrowed] = @IsBorrowed
					,[User_ID] = @User_ID
					,[BorrowDate] = @BorrowDate
					,[Borrow_Times] = @Borrow_Times
					,[IsLost] = @IsLost
					,[Type_ID] = @Type_ID
					,[Publisher_ID] = @Publisher_ID
					,[Papers_no] = @Papers_no
					,[Introducer_ID] = @Introducer_ID
					,[EmployeeI_D] = @EmployeeI_D
					,[Size] = @Size
					,[Price] = @Price
					,[Pdf_Link] = @Pdf_Link
					,[Image_ID] = @Image_ID
					,[ISBN] = @ISBN
					,[CreatedOn] = @CreatedOn
					,[CreatedBy] = @CreatedBy
					,[UpdatedOn] = @UpdatedOn
					,[UpdatedBy] = @UpdatedBy
					,[DeletedOn] = @DeletedOn
					,[DeletedBy] = @DeletedBy
				WHERE
[ID] = @ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Book table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Delete
(

	@ID int   
)
AS


				DELETE FROM [dbo].[Book] WITH (ROWLOCK) 
				WHERE
					[ID] = @ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByType_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByType_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByType_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByType_ID
(

	@Type_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
				WHERE
					[Type_ID] = @Type_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByEmployeeI_D procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByEmployeeI_D') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByEmployeeI_D
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByEmployeeI_D
(

	@EmployeeI_D int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
				WHERE
					[EmployeeI_D] = @EmployeeI_D
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByImage_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByImage_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByImage_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByImage_ID
(

	@Image_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
				WHERE
					[Image_ID] = @Image_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByIntroducer_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByIntroducer_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByIntroducer_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByIntroducer_ID
(

	@Introducer_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
				WHERE
					[Introducer_ID] = @Introducer_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByPublisher_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByPublisher_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByPublisher_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByPublisher_ID
(

	@Publisher_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
				WHERE
					[Publisher_ID] = @Publisher_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByID
(

	@ID int   
)
AS


				SELECT
					[ID],
					[Name],
					[Publisher],
					[Publish_Date],
					[IsAvailablePdf],
					[IsAvailablePaper],
					[IsBorrowed],
					[User_ID],
					[BorrowDate],
					[Borrow_Times],
					[IsLost],
					[Type_ID],
					[Publisher_ID],
					[Papers_no],
					[Introducer_ID],
					[EmployeeI_D],
					[Size],
					[Price],
					[Pdf_Link],
					[Image_ID],
					[ISBN],
					[CreatedOn],
					[CreatedBy],
					[UpdatedOn],
					[UpdatedBy],
					[DeletedOn],
					[DeletedBy]
				FROM
					[dbo].[Book]
				WHERE
					[ID] = @ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_GetByAuthor_IDFromBook_Author procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_GetByAuthor_IDFromBook_Author') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_GetByAuthor_IDFromBook_Author
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_GetByAuthor_IDFromBook_Author
(

	@Author_ID int   
)
AS


SELECT dbo.[Book].[ID]
       ,dbo.[Book].[Name]
       ,dbo.[Book].[Publisher]
       ,dbo.[Book].[Publish_Date]
       ,dbo.[Book].[IsAvailablePdf]
       ,dbo.[Book].[IsAvailablePaper]
       ,dbo.[Book].[IsBorrowed]
       ,dbo.[Book].[User_ID]
       ,dbo.[Book].[BorrowDate]
       ,dbo.[Book].[Borrow_Times]
       ,dbo.[Book].[IsLost]
       ,dbo.[Book].[Type_ID]
       ,dbo.[Book].[Publisher_ID]
       ,dbo.[Book].[Papers_no]
       ,dbo.[Book].[Introducer_ID]
       ,dbo.[Book].[EmployeeI_D]
       ,dbo.[Book].[Size]
       ,dbo.[Book].[Price]
       ,dbo.[Book].[Pdf_Link]
       ,dbo.[Book].[Image_ID]
       ,dbo.[Book].[ISBN]
       ,dbo.[Book].[CreatedOn]
       ,dbo.[Book].[CreatedBy]
       ,dbo.[Book].[UpdatedOn]
       ,dbo.[Book].[UpdatedBy]
       ,dbo.[Book].[DeletedOn]
       ,dbo.[Book].[DeletedBy]
  FROM dbo.[Book]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Book_Author] 
                WHERE dbo.[Book_Author].[Author_ID] = @Author_ID
                  AND dbo.[Book_Author].[Book_ID] = dbo.[Book].[ID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Book table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Name nvarchar (100)  = null ,

	@Publisher nvarchar (50)  = null ,

	@Publish_Date date   = null ,

	@IsAvailablePdf bit   = null ,

	@IsAvailablePaper bit   = null ,

	@IsBorrowed bit   = null ,

	@User_ID int   = null ,

	@BorrowDate date   = null ,

	@Borrow_Times int   = null ,

	@IsLost bit   = null ,

	@Type_ID int   = null ,

	@Publisher_ID int   = null ,

	@Papers_no int   = null ,

	@Introducer_ID int   = null ,

	@EmployeeI_D int   = null ,

	@Size float   = null ,

	@Price int   = null ,

	@Pdf_Link nvarchar (250)  = null ,

	@Image_ID int   = null ,

	@ISBN nvarchar (50)  = null ,

	@CreatedOn datetime   = null ,

	@CreatedBy int   = null ,

	@UpdatedOn datetime   = null ,

	@UpdatedBy int   = null ,

	@DeletedOn datetime   = null ,

	@DeletedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Publisher]
	, [Publish_Date]
	, [IsAvailablePdf]
	, [IsAvailablePaper]
	, [IsBorrowed]
	, [User_ID]
	, [BorrowDate]
	, [Borrow_Times]
	, [IsLost]
	, [Type_ID]
	, [Publisher_ID]
	, [Papers_no]
	, [Introducer_ID]
	, [EmployeeI_D]
	, [Size]
	, [Price]
	, [Pdf_Link]
	, [Image_ID]
	, [ISBN]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Book]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Publisher] = @Publisher OR @Publisher IS NULL)
	AND ([Publish_Date] = @Publish_Date OR @Publish_Date IS NULL)
	AND ([IsAvailablePdf] = @IsAvailablePdf OR @IsAvailablePdf IS NULL)
	AND ([IsAvailablePaper] = @IsAvailablePaper OR @IsAvailablePaper IS NULL)
	AND ([IsBorrowed] = @IsBorrowed OR @IsBorrowed IS NULL)
	AND ([User_ID] = @User_ID OR @User_ID IS NULL)
	AND ([BorrowDate] = @BorrowDate OR @BorrowDate IS NULL)
	AND ([Borrow_Times] = @Borrow_Times OR @Borrow_Times IS NULL)
	AND ([IsLost] = @IsLost OR @IsLost IS NULL)
	AND ([Type_ID] = @Type_ID OR @Type_ID IS NULL)
	AND ([Publisher_ID] = @Publisher_ID OR @Publisher_ID IS NULL)
	AND ([Papers_no] = @Papers_no OR @Papers_no IS NULL)
	AND ([Introducer_ID] = @Introducer_ID OR @Introducer_ID IS NULL)
	AND ([EmployeeI_D] = @EmployeeI_D OR @EmployeeI_D IS NULL)
	AND ([Size] = @Size OR @Size IS NULL)
	AND ([Price] = @Price OR @Price IS NULL)
	AND ([Pdf_Link] = @Pdf_Link OR @Pdf_Link IS NULL)
	AND ([Image_ID] = @Image_ID OR @Image_ID IS NULL)
	AND ([ISBN] = @ISBN OR @ISBN IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
	AND ([CreatedBy] = @CreatedBy OR @CreatedBy IS NULL)
	AND ([UpdatedOn] = @UpdatedOn OR @UpdatedOn IS NULL)
	AND ([UpdatedBy] = @UpdatedBy OR @UpdatedBy IS NULL)
	AND ([DeletedOn] = @DeletedOn OR @DeletedOn IS NULL)
	AND ([DeletedBy] = @DeletedBy OR @DeletedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Publisher]
	, [Publish_Date]
	, [IsAvailablePdf]
	, [IsAvailablePaper]
	, [IsBorrowed]
	, [User_ID]
	, [BorrowDate]
	, [Borrow_Times]
	, [IsLost]
	, [Type_ID]
	, [Publisher_ID]
	, [Papers_no]
	, [Introducer_ID]
	, [EmployeeI_D]
	, [Size]
	, [Price]
	, [Pdf_Link]
	, [Image_ID]
	, [ISBN]
	, [CreatedOn]
	, [CreatedBy]
	, [UpdatedOn]
	, [UpdatedBy]
	, [DeletedOn]
	, [DeletedBy]
    FROM
	[dbo].[Book]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Publisher] = @Publisher AND @Publisher is not null)
	OR ([Publish_Date] = @Publish_Date AND @Publish_Date is not null)
	OR ([IsAvailablePdf] = @IsAvailablePdf AND @IsAvailablePdf is not null)
	OR ([IsAvailablePaper] = @IsAvailablePaper AND @IsAvailablePaper is not null)
	OR ([IsBorrowed] = @IsBorrowed AND @IsBorrowed is not null)
	OR ([User_ID] = @User_ID AND @User_ID is not null)
	OR ([BorrowDate] = @BorrowDate AND @BorrowDate is not null)
	OR ([Borrow_Times] = @Borrow_Times AND @Borrow_Times is not null)
	OR ([IsLost] = @IsLost AND @IsLost is not null)
	OR ([Type_ID] = @Type_ID AND @Type_ID is not null)
	OR ([Publisher_ID] = @Publisher_ID AND @Publisher_ID is not null)
	OR ([Papers_no] = @Papers_no AND @Papers_no is not null)
	OR ([Introducer_ID] = @Introducer_ID AND @Introducer_ID is not null)
	OR ([EmployeeI_D] = @EmployeeI_D AND @EmployeeI_D is not null)
	OR ([Size] = @Size AND @Size is not null)
	OR ([Price] = @Price AND @Price is not null)
	OR ([Pdf_Link] = @Pdf_Link AND @Pdf_Link is not null)
	OR ([Image_ID] = @Image_ID AND @Image_ID is not null)
	OR ([ISBN] = @ISBN AND @ISBN is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	OR ([CreatedBy] = @CreatedBy AND @CreatedBy is not null)
	OR ([UpdatedOn] = @UpdatedOn AND @UpdatedOn is not null)
	OR ([UpdatedBy] = @UpdatedBy AND @UpdatedBy is not null)
	OR ([DeletedOn] = @DeletedOn AND @DeletedOn is not null)
	OR ([DeletedBy] = @DeletedBy AND @DeletedBy is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Book_Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_Get_List

AS


				
				SELECT
					[ID],
					[Book_ID],
					[Author_ID]
				FROM
					[dbo].[Book_Author]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Book_Author table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Book_ID] int, [Author_ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([Book_ID], [Author_ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [Book_ID], [Author_ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Book_Author]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Book_ID], O.[Author_ID]
				FROM
				    [dbo].[Book_Author] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[Book_ID] = PageIndex.[Book_ID]
					AND O.[Author_ID] = PageIndex.[Author_ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Book_Author]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Book_Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_Insert
(

	@ID int    OUTPUT,

	@Book_ID int   ,

	@Author_ID int   
)
AS


				
				INSERT INTO [dbo].[Book_Author]
					(
					[Book_ID]
					,[Author_ID]
					)
				VALUES
					(
					@Book_ID
					,@Author_ID
					)
				-- Get the identity value
				SET @ID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Book_Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_Update
(

	@ID int   ,

	@Book_ID int   ,

	@OriginalBook_ID int   ,

	@Author_ID int   ,

	@OriginalAuthor_ID int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Book_Author]
				SET
					[Book_ID] = @Book_ID
					,[Author_ID] = @Author_ID
				WHERE
[Book_ID] = @OriginalBook_ID 
AND [Author_ID] = @OriginalAuthor_ID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Book_Author table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_Delete
(

	@Book_ID int   ,

	@Author_ID int   
)
AS


				DELETE FROM [dbo].[Book_Author] WITH (ROWLOCK) 
				WHERE
					[Book_ID] = @Book_ID
					AND [Author_ID] = @Author_ID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_GetByAuthor_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_GetByAuthor_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_GetByAuthor_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book_Author table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_GetByAuthor_ID
(

	@Author_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Book_ID],
					[Author_ID]
				FROM
					[dbo].[Book_Author]
				WHERE
					[Author_ID] = @Author_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_GetByBook_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_GetByBook_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_GetByBook_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book_Author table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_GetByBook_ID
(

	@Book_ID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Book_ID],
					[Author_ID]
				FROM
					[dbo].[Book_Author]
				WHERE
					[Book_ID] = @Book_ID
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_GetByBook_IDAuthor_ID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_GetByBook_IDAuthor_ID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_GetByBook_IDAuthor_ID
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Book_Author table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_GetByBook_IDAuthor_ID
(

	@Book_ID int   ,

	@Author_ID int   
)
AS


				SELECT
					[ID],
					[Book_ID],
					[Author_ID]
				FROM
					[dbo].[Book_Author]
				WHERE
					[Book_ID] = @Book_ID
					AND [Author_ID] = @Author_ID
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Book_Author_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Book_Author_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Book_Author_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Book_Author table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Book_Author_Find
(

	@SearchUsingOR bit   = null ,

	@ID int   = null ,

	@Book_ID int   = null ,

	@Author_ID int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Book_ID]
	, [Author_ID]
    FROM
	[dbo].[Book_Author]
    WHERE 
	 ([ID] = @ID OR @ID IS NULL)
	AND ([Book_ID] = @Book_ID OR @Book_ID IS NULL)
	AND ([Author_ID] = @Author_ID OR @Author_ID IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Book_ID]
	, [Author_ID]
    FROM
	[dbo].[Book_Author]
    WHERE 
	 ([ID] = @ID AND @ID is not null)
	OR ([Book_ID] = @Book_ID AND @Book_ID is not null)
	OR ([Author_ID] = @Author_ID AND @Author_ID is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

