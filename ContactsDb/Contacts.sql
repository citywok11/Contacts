CREATE TABLE [dbo].[Contacts]
(
	[ContactId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(255) NOT NULL, 
    [LastName] VARCHAR(255) NOT NULL, 
    [Email] VARCHAR(255) NULL, 
    [PhoneNumber] VARCHAR(255) NULL, 
    [HouseNumber] INT NULL, 
    [HouseName] VARCHAR(128) NULL, 
    [PostCode] VARCHAR(10) NULL
)
