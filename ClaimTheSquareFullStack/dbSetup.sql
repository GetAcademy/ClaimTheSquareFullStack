
CREATE TABLE [dbo].[Color](
	[Id] [int] NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextObject]    Script Date: 04.01.2024 14:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextObject](
	[Index] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ForeColor] [int] NOT NULL,
	[BackColor] [int] NOT NULL,
 CONSTRAINT [PK_TextObject_1] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextObjectV1]    Script Date: 04.01.2024 14:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextObjectV1](
	[Index] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ForeColor] [nvarchar](max) NOT NULL,
	[BackColor] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TextObject] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Color] ([Id], [Color]) VALUES (0, N'black')
GO
INSERT [dbo].[Color] ([Id], [Color]) VALUES (1, N'white')
GO
INSERT [dbo].[Color] ([Id], [Color]) VALUES (2, N'gray')
GO
INSERT [dbo].[Color] ([Id], [Color]) VALUES (3, N'silver')
GO
INSERT [dbo].[Color] ([Id], [Color]) VALUES (4, N'maroon')
GO
INSERT [dbo].[Color] ([Id], [Color]) VALUES (5, N'red')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(6, N'purple')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(7, N'fushsia')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(8, N'green')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(9, N'lime')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(10, N'olive')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(11, N'yellow')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(12, N'navy')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(13, N'blue')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(14, N'teal')
GO
INSERT[dbo].[Color]([Id], [Color]) VALUES(15, N'aqua')
GO
INSERT [dbo].[TextObject] ([Index], [Text], [ForeColor], [BackColor]) VALUES (0, N'Hei', 5, 4)
GO
INSERT [dbo].[TextObject] ([Index], [Text], [ForeColor], [BackColor]) VALUES (1, N'Terje', 2, 1)
GO
INSERT [dbo].[TextObject] ([Index], [Text], [ForeColor], [BackColor]) VALUES (3, N'asdsa', 4, 3)
GO
INSERT [dbo].[TextObjectV1] ([Index], [Text], [ForeColor], [BackColor]) VALUES (3, N'Hei', N'White', N'Green')
GO
INSERT [dbo].[TextObjectV1] ([Index], [Text], [ForeColor], [BackColor]) VALUES (5, N'På', N'Red', N'Red')
GO
INSERT [dbo].[TextObjectV1] ([Index], [Text], [ForeColor], [BackColor]) VALUES (7, N'Deg', N'Blue', N'Pink')
GO
ALTER TABLE [dbo].[TextObject]  WITH CHECK ADD  CONSTRAINT [FK_TextObject_Color] FOREIGN KEY([ForeColor])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[TextObject] CHECK CONSTRAINT [FK_TextObject_Color]
GO
ALTER TABLE [dbo].[TextObject]  WITH CHECK ADD  CONSTRAINT [FK_TextObject_Color1] FOREIGN KEY([BackColor])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[TextObject] CHECK CONSTRAINT [FK_TextObject_Color1]
GO
USE [master]
GO
ALTER DATABASE [TextObjects] SET  READ_WRITE 
GO
