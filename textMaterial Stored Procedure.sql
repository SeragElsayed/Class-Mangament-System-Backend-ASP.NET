USE ELearning;
GO

IF OBJECT_ID('dbo.usp_TextMaterials_Select') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_TextMaterials_Select 
END
GO
CREATE PROC dbo.usp_TextMaterials_Select
    @TextMaterialId int
AS
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT TextMaterialId, TextMaterialName, URL, CourseId, isActive 
    FROM   dbo.TextMaterials
    WHERE  TextMaterialId = @TextMaterialId  

    COMMIT
GO

IF OBJECT_ID('dbo.usp_TextMaterials_Insert') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_TextMaterials_Insert 
END 
GO
CREATE PROC dbo.usp_TextMaterials_Insert 
    @TextMaterialId int,
    @TextMaterialName nvarchar(max),
    @URL nvarchar(max),
    @CourseId int,
    @isActive bit
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    INSERT INTO dbo.TextMaterials (TextMaterialId, TextMaterialName, URL, CourseId, isActive)
    SELECT @TextMaterialId, @TextMaterialName, @URL, @CourseId, @isActive

    /*
    -- Begin Return row code block

    SELECT TextMaterialId, TextMaterialName, URL, CourseId, isActive
    FROM   dbo.TextMaterials
    WHERE  TextMaterialId = @TextMaterialId AND TextMaterialName = @TextMaterialName AND URL = @URL AND 
           CourseId = @CourseId AND isActive = @isActive

    -- End Return row code block

    */
    COMMIT
GO

IF OBJECT_ID('dbo.usp_TextMaterials_Update') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_TextMaterials_Update
END 
GO
CREATE PROC dbo.usp_TextMaterials_Update
@TextMaterialId int,
@TextMaterialName nvarchar(max),
@URL nvarchar(max),
@CourseId int,
@isActive bit
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    UPDATE dbo.TextMaterials
    SET    TextMaterialName = @TextMaterialName, URL = @URL, CourseId = @CourseId, isActive = @isActive
    WHERE  TextMaterialId = @TextMaterialId

    /*
    -- Begin Return row code block

    SELECT TextMaterialName, URL, CourseId, isActive
    FROM   dbo.TextMaterials
    WHERE  TextMaterialId = @TextMaterialId

    -- End Return row code block

    */
    COMMIT
GO

IF OBJECT_ID('dbo.usp_TextMaterials_Delete') IS NOT NULL
BEGIN 
    DROP PROC dbo.usp_TextMaterials_Delete
END 
GO
CREATE PROC dbo.usp_TextMaterials_Delete 
@TextMaterialId int
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN
	UPDATE dbo.TextMaterials
	SET isActive = 'TRUE'
	WHERE  TextMaterialId = @TextMaterialId

    --DELETE
    --FROM   dbo.TextMaterials
    --WHERE  TextMaterialId = @TextMaterialId

    COMMIT
GO