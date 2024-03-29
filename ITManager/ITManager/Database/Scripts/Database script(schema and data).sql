USE [ITManager]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[Language]    Script Date: 21.05.2019 14:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[LanguageLevelId] [int] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguageLevel]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[LanguagesList]    Script Date: 21.05.2019 14:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguagesList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LanguagesList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[ProfessionalSkill]    Script Date: 21.05.2019 14:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalSkill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProfessionalSkill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessionalSummary]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[Project]    Script Date: 21.05.2019 14:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Query]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[Sertificate]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[SkillLevel]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 21.05.2019 14:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Surname] [nvarchar](20) NOT NULL,
	[Birthday] [date] NOT NULL,
	[PositionId] [int] NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Salt] [nvarchar](56) NOT NULL,
	[IsInitial] [bit] NOT NULL,
	[DefaultPassword] [nvarchar](32) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProjects]    Script Date: 21.05.2019 14:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
 CONSTRAINT [PK_UserProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 21.05.2019 14:12:04 ******/
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
/****** Object:  Table [dbo].[UserSkills]    Script Date: 21.05.2019 14:12:04 ******/
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
SET IDENTITY_INSERT [dbo].[Education] ON 

INSERT [dbo].[Education] ([Id], [UserId], [StartDate], [EndDate], [University], [Faculty], [Speciality]) VALUES (1, 2, CAST(N'2015-01-09' AS Date), CAST(N'2019-11-06' AS Date), N'BSTU', N'IT', N'POIT')
SET IDENTITY_INSERT [dbo].[Education] OFF
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([Id], [UserId], [LanguageId], [LanguageLevelId]) VALUES (2, 2, 386, 4)
SET IDENTITY_INSERT [dbo].[Language] OFF
SET IDENTITY_INSERT [dbo].[LanguageLevel] ON 

INSERT [dbo].[LanguageLevel] ([Id], [Name]) VALUES (1, N'A1')
INSERT [dbo].[LanguageLevel] ([Id], [Name]) VALUES (2, N'A2')
INSERT [dbo].[LanguageLevel] ([Id], [Name]) VALUES (3, N'B1')
INSERT [dbo].[LanguageLevel] ([Id], [Name]) VALUES (4, N'B2')
INSERT [dbo].[LanguageLevel] ([Id], [Name]) VALUES (5, N'C1')
INSERT [dbo].[LanguageLevel] ([Id], [Name]) VALUES (6, N'C2')
SET IDENTITY_INSERT [dbo].[LanguageLevel] OFF
SET IDENTITY_INSERT [dbo].[LanguagesList] ON 

INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (351, N'Acholi')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (352, N'Afrikaans')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (353, N'Albanian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (354, N'Amharic')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (355, N'Arabic')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (356, N'Ashante')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (357, N'Assyrian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (358, N'Azerbaijani')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (359, N'Azeri')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (360, N'Bajuni')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (361, N'Basque')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (362, N'Behdini')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (363, N'Belorussian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (364, N'Bengali')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (365, N'Berber')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (366, N'Bosnian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (367, N'Bravanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (368, N'Bulgarian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (369, N'Burmese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (370, N'Cakchiquel')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (371, N'Cambodian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (372, N'Cantonese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (373, N'Catalan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (374, N'Chaldean')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (375, N'Chamorro')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (376, N'Chao-chow')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (377, N'Chavacano')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (378, N'Chuukese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (379, N'Croatian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (380, N'Czech')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (381, N'Danish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (382, N'Dari')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (383, N'Dinka')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (384, N'Diula')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (385, N'Dutch')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (386, N'English')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (387, N'Estonian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (388, N'Espanol')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (389, N'Fante')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (390, N'Farsi')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (391, N'Finnish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (392, N'Flemish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (393, N'French')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (394, N'Fukienese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (395, N'Fula')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (396, N'Fulani')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (397, N'Fuzhou')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (398, N'Gaddang')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (399, N'Gaelic')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (400, N'Gaelic-irish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (401, N'Gaelic-scottish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (402, N'Georgian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (403, N'German')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (404, N'Gorani')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (405, N'Greek')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (406, N'Gujarati')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (407, N'Haitian Creole')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (408, N'Hakka')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (409, N'Hakka-chinese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (410, N'Hausa')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (411, N'Hebrew')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (412, N'Hindi')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (413, N'Hmong')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (414, N'Hungarian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (415, N'Ibanag')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (416, N'Icelandic')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (417, N'Igbo')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (418, N'Ilocano')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (419, N'Indonesian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (420, N'Inuktitut')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (421, N'Italian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (422, N'Jakartanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (423, N'Japanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (424, N'Javanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (425, N'Kanjobal')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (426, N'Karen')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (427, N'Karenni')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (428, N'Kashmiri')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (429, N'Kazakh')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (430, N'Kikuyu')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (431, N'Kinyarwanda')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (432, N'Kirundi')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (433, N'Korean')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (434, N'Kosovan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (435, N'Kotokoli')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (436, N'Krio')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (437, N'Kurdish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (438, N'Kurmanji')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (439, N'Kyrgyz')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (440, N'Lakota')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (441, N'Laotian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (442, N'Latvian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (443, N'Lingala')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (444, N'Lithuanian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (445, N'Luganda')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (446, N'Maay')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (447, N'Macedonian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (448, N'Malay')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (449, N'Malayalam')
GO
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (450, N'Maltese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (451, N'Mandarin')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (452, N'Mandingo')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (453, N'Mandinka')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (454, N'Marathi')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (455, N'Marshallese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (456, N'Mirpuri')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (457, N'Mixteco')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (458, N'Moldavan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (459, N'Mongolian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (460, N'Montenegrin')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (461, N'Navajo')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (462, N'Neapolitan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (463, N'Nepali')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (464, N'Nigerian Pidgin')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (465, N'Norwegian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (466, N'Oromo')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (467, N'Pahari')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (468, N'Papago')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (469, N'Papiamento')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (470, N'Pashto')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (471, N'Patois')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (472, N'Pidgin English')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (473, N'Polish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (474, N'Portug.creole')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (475, N'Portuguese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (476, N'Pothwari')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (477, N'Pulaar')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (478, N'Punjabi')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (479, N'Putian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (480, N'Quichua')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (481, N'Romanian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (482, N'Russian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (483, N'Samoan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (484, N'Serbian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (485, N'Shanghainese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (486, N'Shona')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (487, N'Sichuan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (488, N'Sicilian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (489, N'Sinhalese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (490, N'Slovak')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (491, N'Somali')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (492, N'Sorani')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (493, N'Spanish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (494, N'Sudanese Arabic')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (495, N'Sundanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (496, N'Susu')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (497, N'Swahili')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (498, N'Swedish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (499, N'Sylhetti')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (500, N'Tagalog')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (501, N'Taiwanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (502, N'Tajik')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (503, N'Tamil')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (504, N'Telugu')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (505, N'Thai')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (506, N'Tibetan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (507, N'Tigre')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (508, N'Tigrinya')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (509, N'Toishanese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (510, N'Tongan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (511, N'Toucouleur')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (512, N'Trique')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (513, N'Tshiluba')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (514, N'Turkish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (515, N'Ukrainian')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (516, N'Urdu')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (517, N'Uyghur')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (518, N'Uzbek')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (519, N'Vietnamese')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (520, N'Visayan')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (521, N'Welsh')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (522, N'Wolof')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (523, N'Yiddish')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (524, N'Yoruba')
INSERT [dbo].[LanguagesList] ([Id], [Name]) VALUES (525, N'Yupik')
SET IDENTITY_INSERT [dbo].[LanguagesList] OFF
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([Id], [Name]) VALUES (1, N'Technical Writer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (2, N'Software Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (3, N'QA Engineer/ Tester')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (4, N'Project Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (5, N'Senior Software Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (6, N'Marketing Manager (IT)')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (7, N'Junior Software Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (8, N'Lead Software Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (9, N'Senior QA Engineer/ Tester')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (10, N'Team Leader')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (11, N'Junior QA Engineer/ Tester')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (12, N'HTML Coder')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (13, N'Business Analyst')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (14, N'System Administrator')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (15, N'Senior Project Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (16, N'QA')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (17, N'Team Leader')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (18, N'HR')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (19, N'GUI Designer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (20, N'Web Designer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (21, N'Software Maintenance Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (22, N'SEO Specialist')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (23, N'Copywriter')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (24, N'Support Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (25, N'Department Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (26, N'PR Manager (IT)')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (27, N'Content Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (28, N'Solution Architect')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (29, N'Support Specialist')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (30, N'Data Analyst')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (31, N'Chief Technical Officer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (32, N'Data Scientist')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (33, N'QA Automation Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (34, N'DevOps Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (35, N'Product Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (36, N'Solution Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (37, N'System Analyst')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (38, N'Solution Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (39, N'Support Specialist')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (40, N'3D Artist')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (41, N'Support Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (42, N'ETL Developer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (43, N'CTO')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (44, N'Performance Analyst')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (45, N'Content Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (46, N'Data Analyst')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (47, N'Solution Architect')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (48, N'Sales Manager')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (49, N'Data Engineer')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (50, N'Recruiter')
SET IDENTITY_INSERT [dbo].[Position] OFF
SET IDENTITY_INSERT [dbo].[ProfessionalSkill] ON 

INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (1, N'Java')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (2, N'C/C++')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (3, N'C#.NET')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (4, N'ASP.NET')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (5, N'Delphi')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (6, N'HTML')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (7, N'DHTML')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (8, N'JavaScript')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (9, N'AngularJS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (10, N'CSS/CSS3')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (11, N'SQL')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (12, N'MVC')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (13, N'Telerik MVC')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (14, N'Kendo UI')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (15, N'ASP.NET Razor')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (16, N'jQuery')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (17, N'TypeScript')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (18, N'SignalR')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (19, N'Ajax')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (20, N'Unity (IoC/DI)')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (21, N'NHibernate')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (22, N'Ninject (IoC/DI)')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (23, N'Entity Eramework')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (24, N'Autofac')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (25, N'Automapper')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (26, N'PostSharp')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (27, N'COM')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (28, N'POP3')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (29, N'SMTP')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (30, N'QuickReport')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (31, N'ReportBuilder')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (32, N'MS Windows')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (33, N'MS SQL ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (34, N'MySQL')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (35, N'Oracle')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (36, N'Microsoft IIS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (37, N'Visual Studio')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (38, N'Delphi ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (39, N'SQL Server Management Studio')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (40, N'Intellij Idea')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (41, N'GIT')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (42, N'Adobe Photoshop')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (43, N'Visual Studio Code')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (44, N'Postman')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (45, N'Eclipse')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (46, N'ClearCase')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (47, N'UML')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (48, N'Bash')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (49, N'Ruby')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (50, N'Perl')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (51, N'Atlassian JIRA')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (52, N'MS TFS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (53, N'Cocoa Frameworks')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (54, N'MFC ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (55, N'ATL')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (56, N'Qt')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (57, N'Reporting with MS Word/Excel')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (58, N'Objective-C')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (59, N'OS X')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (60, N'SQL Lite')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (61, N'ASP.NET Core')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (62, N'XCode')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (63, N'SOAP')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (64, N'WSDL')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (65, N'Kylix ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (66, N'Sun OS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (67, N'Solaris ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (68, N'DB2')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (69, N'MongoDB')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (70, N'Interbase/Firebird')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (71, N'Apache')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (72, N'Tomcat')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (73, N'JBOSS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (74, N'WSO2 AS/ESB')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (75, N'Enterprise Architect')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (76, N'MS Word')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (77, N'MS Excel')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (78, N'MS Outlook')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (79, N'MS Visio')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (80, N'MS PowerPoint')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (81, N'MS Project')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (82, N'TCP/IP')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (83, N'NetBIOS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (84, N'Cassandra')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (85, N'JDBC')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (86, N'Log4j')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (87, N'JUnit')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (88, N'XML ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (89, N'MS SQL Prifiler')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (90, N'Fiddler')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (91, N'Tor ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (92, N'WCF')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (93, N'NodeJS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (94, N'Unix-base')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (95, N'Spring')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (96, N'Gulp')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (97, N'Jenkins')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (98, N'JMeter')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (99, N'Jetty')
GO
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (100, N'Weblogic12')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (101, N'Manual Testing')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (102, N'Agile')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (103, N'Scrum')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (104, N'Websphere')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (105, N'Telerik Controls')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (106, N'SiteCore ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (107, N'Business analysis planning and monitoring')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (108, N'Requirements elicitation')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (109, N'Requirements management and communication')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (110, N'Enterprise analysis')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (111, N'Requirements analysis')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (112, N'Stakeholders analysis')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (113, N'Windows Communication Foundation (WPF)')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (114, N'XSL')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (115, N'XSLT ')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (116, N'ADO.NET')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (117, N'ODBC')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (118, N'CVS')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (119, N'ActiveX')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (120, N'COM/DCOM')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (121, N'SOA')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (122, N'Docker')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (123, N'VirtualBox')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (124, N'REST')
INSERT [dbo].[ProfessionalSkill] ([Id], [Name]) VALUES (125, N'Bootstrap')
SET IDENTITY_INSERT [dbo].[ProfessionalSkill] OFF
SET IDENTITY_INSERT [dbo].[ProfessionalSummary] ON 

INSERT [dbo].[ProfessionalSummary] ([Id], [UserId], [ProfessionalSummary]) VALUES (1, 2, N'Professional .Net backend and WPF developer. ')
SET IDENTITY_INSERT [dbo].[ProfessionalSummary] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [Description]) VALUES (1, N'Cool project', CAST(N'2019-01-01' AS Date), NULL, N'Cool project description')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [Description]) VALUES (2, N'Cool project 2', CAST(N'2018-01-02' AS Date), NULL, N'Cool project description 2')
INSERT [dbo].[Project] ([Id], [Name], [StartDate], [EndDate], [Description]) VALUES (3, N'Asd', CAST(N'2019-05-06' AS Date), CAST(N'2019-05-07' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Query] ON 

INSERT [dbo].[Query] ([Id], [UserId], [QueryString], [Description]) VALUES (2, 3, N'2:1-3,3:1-3&386:1-6&1', N'New query')
SET IDENTITY_INSERT [dbo].[Query] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Administrator')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Manager')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Sertificate] ON 

INSERT [dbo].[Sertificate] ([Id], [UserId], [Date], [Name]) VALUES (1, 2, CAST(N'2018-02-01' AS Date), N'WPF specialist')
SET IDENTITY_INSERT [dbo].[Sertificate] OFF
SET IDENTITY_INSERT [dbo].[SkillLevel] ON 

INSERT [dbo].[SkillLevel] ([Id], [Level]) VALUES (1, N'Basic')
INSERT [dbo].[SkillLevel] ([Id], [Level]) VALUES (2, N'Good')
INSERT [dbo].[SkillLevel] ([Id], [Level]) VALUES (3, N'Excellent')
SET IDENTITY_INSERT [dbo].[SkillLevel] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Birthday], [PositionId], [Login], [Password], [Salt], [IsInitial], [DefaultPassword], [IsActive]) VALUES (1, N'admin', N'admin', CAST(N'1998-02-27' AS Date), 14, N'admin', N'9+pjxTUxE8NdpZ8g5Ei7oy9mDaniMWXhMtmxdtRzPvkyXj4oqzMe7NBtlxWMRq8NdBOgfeZpagGuzKWytFgEXxbrZuzmCeF/BB+Bz5Kkr0EVQ/nIH7gl6crxW1crOhXaj2z2Rp2dmz07+z7Mf2uiJPbY6aGBhyswHkoSvKIbjsM=', N'MKRLzk0M3S2eZHCShoaprRyK0i+Vmryc', 0, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Birthday], [PositionId], [Login], [Password], [Salt], [IsInitial], [DefaultPassword], [IsActive]) VALUES (2, N'Alexey', N'Rusakovich', CAST(N'1998-02-27' AS Date), 2, N'alru', N'WDOC219gC/2qZtuBQ4z3/4722Bgcj4mtN3JQz4S6e43euHqgOB923maa5wQN9mbBq6vmhL7ubE+OBgvLJbkowO0QLddlXCZ4uKuO5fq4+rdO3UpzXM89jgX3CTiyP8eg39GcfW8KZEgm4XPoIBTV0bh3Q3B+7A6grZ/3B29248g=', N'1iWzSnCN9KsiLDUXb5KEB1lbdE52GoNU', 0, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Birthday], [PositionId], [Login], [Password], [Salt], [IsInitial], [DefaultPassword], [IsActive]) VALUES (3, N'Anna', N'Petrovskaya', CAST(N'1995-05-02' AS Date), 4, N'Manager', N'ZsgpYSvx89l4VTvCJwN33yyuKM2jtZDO9a/J5jWy+6UoeU5/FWyqz06zRPzyK/sjoHaF1gICrKER2bV/nOJkmdw+0HRVTK3T83yNUU+WZiPwATtkS3m+oj+CP4PxgQ0VSp3WMpXZXNdjWVDJnhN88mLs7Wy3wfMBanlI8WCMOqA=', N'Lpn4KGaMBl2qRjw4q9oqBWQfRc3eHZsL', 0, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Birthday], [PositionId], [Login], [Password], [Salt], [IsInitial], [DefaultPassword], [IsActive]) VALUES (4, N'Misha', N'Tonikov', CAST(N'2019-05-02' AS Date), 3, N'misha', N'sc3hopozpJG/yqLOw9CaDc37yCXUzbPUQ+OqYOGKt98zy3GtYI6Q6f7MiQoa/3tXFRBLK09YGyPu10fqGrXqKWkzGlqQZ3fimd1vsYR4UWCySZVtuGHx3sa/3XBQlaLOGfB7muZNgIsM7Zas428HG62anrT6XHuilrPXsHtELkc=', N'Uwsy+TfHE1gb27lBfAqjVl0V7ksDV8vC', 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserProjects] ON 

INSERT [dbo].[UserProjects] ([Id], [ProjectId], [UserId], [PositionId]) VALUES (1, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[UserProjects] OFF
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (2, 2, 3)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (3, 3, 2)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (4, 4, 3)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
SET IDENTITY_INSERT [dbo].[UserSkills] ON 

INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (1, 4, 2, 2)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (2, 4, 5, 2)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (3, 2, 1, 1)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (4, 2, 2, 1)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (5, 2, 3, 3)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (6, 2, 26, 2)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (7, 2, 76, 3)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (8, 2, 4, 2)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (9, 2, 11, 2)
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId], [SkillLevelId]) VALUES (10, 2, 20, 2)
SET IDENTITY_INSERT [dbo].[UserSkills] OFF
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
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_LanguagesList] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[LanguagesList] ([Id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_LanguagesList]
GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_User]
GO
ALTER TABLE [dbo].[ProfessionalSummary]  WITH CHECK ADD  CONSTRAINT [FK_ProfessionalSummary_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ProfessionalSummary] CHECK CONSTRAINT [FK_ProfessionalSummary_User]
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
ALTER TABLE [dbo].[UserProjects]  WITH CHECK ADD  CONSTRAINT [FK_UserProjects_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProjects] CHECK CONSTRAINT [FK_UserProjects_Project]
GO
ALTER TABLE [dbo].[UserProjects]  WITH CHECK ADD  CONSTRAINT [FK_UserProjects_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserProjects] CHECK CONSTRAINT [FK_UserProjects_User]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_ProfessionalSkill] FOREIGN KEY([SkillId])
REFERENCES [dbo].[ProfessionalSkill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_ProfessionalSkill]
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
