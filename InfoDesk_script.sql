USE [WebAPIDemo_DB]
GO
/****** Object:  Table [dbo].[Paitent_info]    Script Date: 18-05-2021 23:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paitent_info](
	[paitent_id] [int] IDENTITY(1,1) NOT NULL,
	[paitent_name] [varchar](200) NOT NULL,
	[paitent_age] [int] NOT NULL,
	[paitent_visitdate] [date] NOT NULL,
	[paitent_symptoms] [varchar](200) NOT NULL,
	[paitent_medications] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Paitent_info] PRIMARY KEY CLUSTERED 
(
	[paitent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
