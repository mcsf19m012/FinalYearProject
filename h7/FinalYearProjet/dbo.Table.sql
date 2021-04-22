CREATE TABLE [dbo].[RestaurentMenu]
(
	[RestaurentID] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [ MenuID] INT NOT NULL, 
    [NameOfItem] VARCHAR(50) NULL, 
    [Price ] INT NULL, 
    [Quantity ] INT NULL, 
    [Photo2] VARBINARY(MAX) NULL, 
    [PhotoPATH2] VARCHAR(50) NULL
)
