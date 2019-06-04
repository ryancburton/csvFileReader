USE [Contacts]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 4/15/2017 11:21:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContactDetails](
	[ContactDetailId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[Email] [varchar](30) NULL,
	[Phone] [varchar](10) NULL,
	[ContactSummaryId] [int] NOT NULL,
 CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[ContactDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ContactSummary](
	[ContactSummaryId] [int] IDENTITY(1,1) NOT NULL,
	[ImportFileName] [varchar](150) NOT NULL,
	[ImportDate] [varchar](10) NOT NULL,
	[ImportDuration] [varchar](10) NOT NULL,
	[ContactsImported] [int] NOT NULL,
	[CompaniesImported] [int] NOT NULL,
	[LackedEmail] [int] NOT NULL,
	[LackedPhone] [int]NOT NULL,
 CONSTRAINT [PK_ContactSummary] PRIMARY KEY CLUSTERED 
(
	[ContactSummaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_ContactSummary] FOREIGN KEY([ContactSummaryId])
REFERENCES [dbo].[ContactSummary] ([ContactSummaryId])
GO

ALTER TABLE [dbo].[ContactDetails] CHECK CONSTRAINT [FK_ContactDetails_ContactSummary]
GO

SET ANSI_PADDING OFF
GO


