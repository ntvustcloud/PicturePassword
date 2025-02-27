CREATE TABLE [dbo].[tbl_Picturelogin]
(
	[username] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [image] IMAGE NOT NULL, 
    [salt] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL
)
