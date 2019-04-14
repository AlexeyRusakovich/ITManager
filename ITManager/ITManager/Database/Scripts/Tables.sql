USE [ITManager]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 04/14/2019 9:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[University] [nvarchar](100) NOT NULL,
	[Faculty] [nvarchar](100) NOT NULL,
	[Speciality] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 04/14/2019 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LanguageLevelId] [int] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguageLevel]    Script Date: 04/14/2019 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LanguageLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 04/14/2019 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessionalSkill]    Script Date: 04/14/2019 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalSkill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionalGroupId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProfessionalSkill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessionalSummary]    Script Date: 04/14/2019 9:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalSummary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProfessionalSummary] [nvarchar](1000) NULL,
 CONSTRAINT [PK_ProfessionalSummary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 04/14/2019 9:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[PositionId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Query]    Script Date: 04/14/2019 9:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Query](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[QueryString] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04/14/2019 9:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sertificate]    Script Date: 04/14/2019 9:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sertificate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Sertificate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkillLevel]    Script Date: 04/14/2019 9:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SkillLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechnicalGroup]    Script Date: 04/14/2019 9:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TechnicalGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/14/2019 9:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[PositionId] [int] NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Salt] [nvarchar](56) NOT NULL,
	[IsInitial] [bit] NOT NULL,
	[DefaultPassword] [nvarchar](32) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/14/2019 9:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSkills]    Script Date: 04/14/2019 9:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
	[SkillLevelId] [int] NOT NULL,
 CONSTRAINT [PK_UserSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [FK_Education_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_Education_User]
GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_LanguageLevel] FOREIGN KEY([LanguageLevelId])
REFERENCES [dbo].[LanguageLevel] ([Id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_LanguageLevel]
GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_User]
GO
ALTER TABLE [dbo].[ProfessionalSkill]  WITH CHECK ADD  CONSTRAINT [FK_ProfessionalSkill_TechnicalGroup] FOREIGN KEY([ProfessionalGroupId])
REFERENCES [dbo].[TechnicalGroup] ([Id])
GO
ALTER TABLE [dbo].[ProfessionalSkill] CHECK CONSTRAINT [FK_ProfessionalSkill_TechnicalGroup]
GO
ALTER TABLE [dbo].[ProfessionalSkill]  WITH CHECK ADD  CONSTRAINT [FK_ProfessionalSkill_UserSkills] FOREIGN KEY([Id])
REFERENCES [dbo].[UserSkills] ([Id])
GO
ALTER TABLE [dbo].[ProfessionalSkill] CHECK CONSTRAINT [FK_ProfessionalSkill_UserSkills]
GO
ALTER TABLE [dbo].[ProfessionalSummary]  WITH CHECK ADD  CONSTRAINT [FK_ProfessionalSummary_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ProfessionalSummary] CHECK CONSTRAINT [FK_ProfessionalSummary_User]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Position]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_User]
GO
ALTER TABLE [dbo].[Query]  WITH CHECK ADD  CONSTRAINT [FK_Query_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Query] CHECK CONSTRAINT [FK_Query_User]
GO
ALTER TABLE [dbo].[Sertificate]  WITH CHECK ADD  CONSTRAINT [FK_Sertificate_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Sertificate] CHECK CONSTRAINT [FK_Sertificate_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Position]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_SkillLevel] FOREIGN KEY([SkillLevelId])
REFERENCES [dbo].[SkillLevel] ([Id])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_SkillLevel]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_User]
GO
