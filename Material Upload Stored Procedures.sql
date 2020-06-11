USE ELearning;
GO

--select material by id 
IF OBJECT_ID('dbo.usp_CourseMaterialModel_Select') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_CourseMaterialModel_Select 
END
GO
CREATE PROC dbo.usp_CourseMaterialModel_Select
    @Id int
AS
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT Id, PathOnServer, CourseId 
    FROM   dbo.CourseMaterialModel
    WHERE  Id = @Id  

    COMMIT
GO

--SELECT MATERIAL BY COURSE ID
IF OBJECT_ID('dbo.usp_CourseMaterialModel_SelectByCourseId') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_CourseMaterialModel_SelectByCourseId 
END
GO

CREATE PROC dbo.usp_CourseMaterialModel_SelectByCourseId
    @CourseId int
AS
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT Id, PathOnServer, CourseId 
    FROM   dbo.CourseMaterialModel
    WHERE  CourseId = @CourseId  

    COMMIT
GO 
-- DELETE ALL MATERIAL BY COURSE ID
IF OBJECT_ID('dbo.usp_CourseMaterialModel_DeleteByCourseId') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_CourseMaterialModel_DeleteByCourseId 
END
GO
CREATE PROC dbo.usp_CourseMaterialModel_DeleteByCourseId
    @CourseId int
AS
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    DELETE
    FROM   dbo.CourseMaterialModel
    WHERE  CourseId = @CourseId  

    COMMIT
GO 

--ADD MATERIAL BY ID

IF OBJECT_ID('dbo.usp_CourseMaterialModel_Insert') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_CourseMaterialModel_Insert 
END 
GO
CREATE PROC dbo.usp_CourseMaterialModel_Insert 
  
    @PathOnServer nvarchar(max),
    @CourseId int
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    INSERT INTO dbo.CourseMaterialModel ( PathOnServer, CourseId)
    SELECT  @PathOnServer, @CourseId

    /*
    -- Begin Return row code block

    SELECT Id, PathOnServer, CourseId
    FROM   dbo.CourseMaterialModel
    WHERE  Id = @Id AND PathOnServer = @PathOnServer AND CourseId = @CourseId

    -- End Return row code block

    */
    COMMIT
GO

    /*
    -- Begin Return row code block

    SELECT PathOnServer, CourseId
    FROM   dbo.CourseMaterialModel
    WHERE  Id = @Id

    -- End Return row code block

    */

GO
-- DELETE MATERIAL BY MATERIAL ID
IF OBJECT_ID('dbo.usp_CourseMaterialModel_DeleteById') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_CourseMaterialModel_DeleteById
END 
GO
CREATE PROC dbo.usp_CourseMaterialModel_DeleteById
@Id int
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    DELETE
    FROM   dbo.CourseMaterialModel
    WHERE  Id = @Id

    COMMIT
GO


--select  material by file path then delete 
IF OBJECT_ID('dbo.usp_CourseMaterialModel_DeletePath') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_CourseMaterialModel_DeletePath
END
GO
CREATE PROC dbo.usp_CourseMaterialModel_DeletePath
    @PathOnServer int
AS
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    DELETE
    FROM   dbo.CourseMaterialModel
    WHERE  PathOnServer = @PathOnServer
    COMMIT
GO