CREATE DATABASE TicketManager;


USE [TicketManager]
GO

/****** Object:  Table [dbo].[Tickets]    Script Date: 5/10/2021 5:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tickets](
	[TicketNumber] [char](50) NOT NULL,
	[Description] [char](255) NULL,
	[Status] [char](20) NOT NULL,
	[Comments] [text] NULL,
	[CompletedOn] [date] NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ticket or Request number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tickets', @level2type=N'COLUMN',@level2name=N'TicketNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status of the ticket. eg. Assigned, Waiting, In Progress etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tickets', @level2type=N'COLUMN',@level2name=N'Status'
GO

/****** Object:  Index [IX_CompletedOn]    Script Date: 5/10/2021 5:53:04 PM ******/
CREATE NONCLUSTERED INDEX [IX_CompletedOn] ON [dbo].[Tickets]
(
	[CompletedOn] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

USE [TicketManager]
GO

/****** Object:  Index [IX_CreatedOn]    Script Date: 5/10/2021 5:53:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_CreatedOn] ON [dbo].[Tickets]
(
	[CreatedOn] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

USE [TicketManager]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_Status]    Script Date: 5/10/2021 5:54:00 PM ******/
CREATE NONCLUSTERED INDEX [IX_Status] ON [dbo].[Tickets]
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ticket Status' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tickets', @level2type=N'INDEX',@level2name=N'IX_Status'
GO

USE [TicketManager]
GO

/****** Object:  Index [IX_UpdatedOn]    Script Date: 5/10/2021 5:54:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_UpdatedOn] ON [dbo].[Tickets]
(
	[UpdatedOn] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO



USE [TicketManager]
GO

/****** Object:  Table [dbo].[Objects]    Script Date: 6/25/2021 5:33:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Objects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TicketNumber] [char](50) NOT NULL,
	[ObjectName] [char](75) NOT NULL,
	[Activity] [char](30) NULL,
	[CreatedOn] [date] NOT NULL,
	[Comments] [char](500) NULL,
 CONSTRAINT [PK_Objects1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Objects]  WITH NOCHECK ADD  CONSTRAINT [FK_Objects_Tickets] FOREIGN KEY([TicketNumber])
REFERENCES [dbo].[Tickets] ([TicketNumber])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Objects] CHECK CONSTRAINT [FK_Objects_Tickets]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'One ticket record may contain multiple object records.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Objects', @level2type=N'CONSTRAINT',@level2name=N'FK_Objects_Tickets'
GO

