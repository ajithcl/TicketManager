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


/******** Object database   *************/
CREATE TABLE [dbo].[Objects](
	[TicketNumber] [char](50) NOT NULL,
	[ObjectName] [char](75) NOT NULL,
	[Activity] [char](30) NULL,
	[CreatedOn] [date] NOT NULL,
	[Comments] [char](500) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Objects]  WITH NOCHECK ADD  CONSTRAINT [FK_Objects_Tickets] FOREIGN KEY([TicketNumber])
REFERENCES [dbo].[Tickets] ([TicketNumber])
GO

ALTER TABLE [dbo].[Objects] CHECK CONSTRAINT [FK_Objects_Tickets]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'One ticket record may contain multiple object records.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Objects', @level2type=N'CONSTRAINT',@level2name=N'FK_Objects_Tickets'
GO

