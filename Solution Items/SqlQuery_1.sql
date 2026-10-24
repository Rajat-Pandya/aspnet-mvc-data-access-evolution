SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

SET ANSI_PADDING ON;
GO

CREATE TABLE [dbo].[tblStudent] (
    [student_id] [int] IDENTITY(1, 1) NOT NULL,
    [student_name] [varchar](50) NOT NULL,
    [student_age] [int] NOT NULL,  -- Corrected typo
    [student_gender] [varchar](6) NOT NULL,
    CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED (
        [student_id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

GO

SET ANSI_PADDING OFF;
GO