USE [Contacts]
GO

select * from [ContactSummary]

INSERT INTO [dbo].[ContactSummary] ([ImportFileName], [ImportDate], [ImportDuration], [ContactsImported],[CompaniesImported],[LackedEmail],[LackedPhone])
VALUES('some_import.csv' ,'07/08/15' ,'12h37' ,455, 400 , 25, 28)
GO

INSERT INTO [dbo].[ContactSummary] ([ImportFileName], [ImportDate], [ImportDuration], [ContactsImported],[CompaniesImported],[LackedEmail],[LackedPhone])
VALUES('importing_again.csv' ,'15/11/16' ,'12h37' ,120, 300 , 50, 5)
GO

INSERT INTO [dbo].[ContactSummary] ([ImportFileName], [ImportDate], [ImportDuration], [ContactsImported],[CompaniesImported],[LackedEmail],[LackedPhone])
VALUES('running_import.csv' ,'07/08/17' ,'12h37' ,330, 100 , 66, 88)
GO

INSERT INTO [dbo].[ContactSummary] ([ImportFileName], [ImportDate], [ImportDuration], [ContactsImported],[CompaniesImported],[LackedEmail],[LackedPhone])
VALUES('ABC_miners_import.csv' ,'01/12/17' ,'1h20' ,200, 1 , 20, 30)
GO

select * from ContactDetails

INSERT INTO [dbo].[ContactDetails] ([Name], [Company], [Email], [Phone], ContactSummaryId)
VALUES('John Doe', 'Abc Corp', 'john.joe@abc.com' ,'021555789', 1)
GO

INSERT INTO [dbo].[ContactDetails] ([Name], [Company], [Email], [Phone], ContactSummaryId)
VALUES('John Doe', 'Abc Corp', 'john.joe@abc.com' ,'021555789', 2)
GO

INSERT INTO [dbo].[ContactDetails] ([Name], [Company], [Email], [Phone], ContactSummaryId)
VALUES('John Doe', 'Abc Corp', 'john.joe@abc.com' ,'021555789', 3)
GO

INSERT INTO [dbo].[ContactDetails] ([Name], [Company], [Email], [Phone], ContactSummaryId)
VALUES('John Doe', 'Abc Corp', 'john.joe@abc.com' ,'021555789', 4)
GO


