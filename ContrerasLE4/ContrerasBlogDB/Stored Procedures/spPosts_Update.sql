CREATE PROCEDURE [dbo].[spPosts_Update]
    @Id int,
    @Title nvarchar(150),
    @Body text
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Posts
    SET Title = @Title,
        Body = @Body
    WHERE Id = @Id;
END