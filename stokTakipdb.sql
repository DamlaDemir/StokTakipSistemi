USE [stokTakipdb]
GO
/****** Object:  Table [dbo].[Demirbas]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demirbas](
	[demirbasId] [int] IDENTITY(1,1) NOT NULL,
	[demirbasAdi] [nvarchar](250) NOT NULL,
	[fiyat] [decimal](18, 0) NOT NULL,
	[alımTarihi] [datetime] NOT NULL,
	[demirbasTuruId] [int] NOT NULL,
	[adet] [int] NOT NULL,
	[silindiMi] [int] NOT NULL CONSTRAINT [DF_Demirbas_silindiMi]  DEFAULT ((0)),
	[model] [nvarchar](75) NOT NULL,
	[marka] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_Demirbas] PRIMARY KEY CLUSTERED 
(
	[demirbasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DemirbasTur]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DemirbasTur](
	[demirbasTuruId] [int] IDENTITY(1,1) NOT NULL,
	[demirbasTuruAdi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DemirbasTur_1] PRIMARY KEY CLUSTERED 
(
	[demirbasTuruId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departman]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departman](
	[departmanId] [int] IDENTITY(1,1) NOT NULL,
	[departmanAdi] [nvarchar](250) NOT NULL,
	[fakulteId] [int] NOT NULL,
 CONSTRAINT [PK_Departman] PRIMARY KEY CLUSTERED 
(
	[departmanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fakulte]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fakulte](
	[fakulteId] [int] IDENTITY(1,1) NOT NULL,
	[fakulteAdi] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Fakulte] PRIMARY KEY CLUSTERED 
(
	[fakulteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[kullaniciId] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciAdi] [nvarchar](50) NOT NULL,
	[Yetki] [int] NOT NULL,
	[sifre] [nvarchar](50) NOT NULL,
	[personelId] [int] NOT NULL,
	[aktifMi] [bit] NOT NULL CONSTRAINT [DF_Kullanici_aktifMi]  DEFAULT ((0)),
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[kullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Oda]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda](
	[odaId] [int] IDENTITY(1,1) NOT NULL,
	[departmanId] [int] NOT NULL,
	[odaKat] [int] NOT NULL,
	[odaNumarasi] [nvarchar](50) NOT NULL,
	[personelId] [int] NULL,
 CONSTRAINT [PK_Oda] PRIMARY KEY CLUSTERED 
(
	[odaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OdaDemirbasAtama]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdaDemirbasAtama](
	[odaDemirbasId] [int] IDENTITY(1,1) NOT NULL,
	[odaId] [int] NOT NULL,
	[demirbasId] [int] NOT NULL,
	[adet] [int] NOT NULL,
	[demirbasKodu] [nvarchar](50) NULL,
 CONSTRAINT [PK_OdaDemirbasAtama] PRIMARY KEY CLUSTERED 
(
	[odaDemirbasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personel]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[personelId] [int] IDENTITY(1,1) NOT NULL,
	[personelAdi] [nvarchar](50) NOT NULL,
	[personelSoyadi] [nvarchar](50) NOT NULL,
	[personelSicilNo] [nvarchar](50) NULL,
	[departmanId] [int] NOT NULL,
	[fotograf] [nvarchar](150) NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[personelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stok]    Script Date: 15.01.2018 17:59:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok](
	[stokId] [int] IDENTITY(1,1) NOT NULL,
	[demirbasId] [int] NOT NULL,
	[stokAdet] [int] NOT NULL,
 CONSTRAINT [PK_Stok] PRIMARY KEY CLUSTERED 
(
	[stokId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Demirbas] ON 

INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (1, N'bilgisayar', CAST(3000 AS Decimal(18, 0)), CAST(N'2017-12-24 20:24:04.107' AS DateTime), 1, 300, 0, N'x556u', N'asus')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (2, N'bilgisayar', CAST(2542 AS Decimal(18, 0)), CAST(N'2017-12-24 20:29:41.457' AS DateTime), 1, 50, 0, N'v310', N'lenovo')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (3, N'projeksiyon cihazı', CAST(3465 AS Decimal(18, 0)), CAST(N'2017-12-15 20:34:37.000' AS DateTime), 1, 100, 0, N'eh-tw5300', N'epson')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (4, N'projeksiyon perdesi', CAST(1275 AS Decimal(18, 0)), CAST(N'2017-12-06 23:50:53.000' AS DateTime), 1, 350, 0, N'axino', N'axino')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (5, N'sıra', CAST(135 AS Decimal(18, 0)), CAST(N'2017-12-05 23:50:53.000' AS DateTime), 2, 500, 0, N'ç-50', N'değirmenciler')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (6, N'perde', CAST(110 AS Decimal(18, 0)), CAST(N'2017-12-25 12:43:54.697' AS DateTime), 3, 10, 0, N'taç', N'taç')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (7, N'kürsü', CAST(150 AS Decimal(18, 0)), CAST(N'2017-12-25 19:46:22.463' AS DateTime), 2, 150, 0, N'ab-01', N'boğa')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (8, N'klavye', CAST(13 AS Decimal(18, 0)), CAST(N'2017-12-21 23:39:28.000' AS DateTime), 1, 350, 0, N'compaxe', N'compaxe')
INSERT [dbo].[Demirbas] ([demirbasId], [demirbasAdi], [fiyat], [alımTarihi], [demirbasTuruId], [adet], [silindiMi], [model], [marka]) VALUES (9, N'asus i7', CAST(99999 AS Decimal(18, 0)), CAST(N'2018-10-28 14:19:30.000' AS DateTime), 1, 100, 0, N'k', N'x')
SET IDENTITY_INSERT [dbo].[Demirbas] OFF
SET IDENTITY_INSERT [dbo].[DemirbasTur] ON 

INSERT [dbo].[DemirbasTur] ([demirbasTuruId], [demirbasTuruAdi]) VALUES (1, N'Elektronik')
INSERT [dbo].[DemirbasTur] ([demirbasTuruId], [demirbasTuruAdi]) VALUES (2, N'Mobilya')
INSERT [dbo].[DemirbasTur] ([demirbasTuruId], [demirbasTuruAdi]) VALUES (3, N'Tekstil')
INSERT [dbo].[DemirbasTur] ([demirbasTuruId], [demirbasTuruAdi]) VALUES (4, N'Kırtasiye')
INSERT [dbo].[DemirbasTur] ([demirbasTuruId], [demirbasTuruAdi]) VALUES (5, N'Ekstra Materyaller')
SET IDENTITY_INSERT [dbo].[DemirbasTur] OFF
SET IDENTITY_INSERT [dbo].[Departman] ON 

INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (1, N'Yazılım Mühendisliği', 1)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (2, N'Mekatronik Mühendisliği', 1)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (3, N'Enerji Sistemleri Mühendisliği', 1)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (4, N'Otomotiv Mühendisliği', 1)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (5, N'İmalat Mühendisliği', 1)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (6, N'Temel Tıp Bilimleri', 2)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (7, N'Dahili Tıp Bilimleri', 2)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (8, N'Cerrahi Tıp Bilimleri', 2)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (9, N'İktisat', 3)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (10, N'İşletme', 3)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (11, N'Maliye', 3)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (12, N'Kamu Yönetimi', 3)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (13, N'Biyoloji', 4)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (14, N'Kimya', 4)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (15, N'Tarih', 4)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (16, N'Matematik', 4)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (17, N'Arkeoloji', 4)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (18, N'Sınıf Öğretmenliği', 5)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (19, N'Türkçe Öğretmenliği', 5)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (20, N'Sosyal Bilgiler', 5)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (21, N'Rehberlik ve Psikolojik Danışmanlık', 5)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (22, N'Temel İslam Bilimleri', 6)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (23, N'Felsefe ve Din Bilimleri', 6)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (24, N'İslam Tarihi ve Sanatları', 6)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (25, N'Grafik Tasarım', 7)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (26, N'Müzik', 7)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (27, N'Mimarlık', 7)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (28, N'İç Mimarlık', 7)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (29, N'Hemşirelik', 8)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (30, N'Ebelik', 8)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (31, N'Fizyoterapi Rehabilitasyon', 8)
INSERT [dbo].[Departman] ([departmanId], [departmanAdi], [fakulteId]) VALUES (32, N'Sosyal Hizmet', 8)
SET IDENTITY_INSERT [dbo].[Departman] OFF
SET IDENTITY_INSERT [dbo].[Fakulte] ON 

INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (1, N'Hasan Ferdi Turgutlu Teknoloji Fakültesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (2, N'Tıp Fakültesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (3, N'İktisadi Ve İdari Bilimler Fakültesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (4, N'Fen Edebiyat Fakültesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (5, N'Eğitim Fakültesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (6, N'İlahiyat Fakütesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (7, N'Güzel Sanatlar ve Mimarlık Fakültesi')
INSERT [dbo].[Fakulte] ([fakulteId], [fakulteAdi]) VALUES (8, N'Sağlık Bilimleri Fakültesi')
SET IDENTITY_INSERT [dbo].[Fakulte] OFF
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (6, N'DamlaDemir', 1, N'1234', 1, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (10, N'NilayBilir', 1, N'1234', 13, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (11, N'BurakCagri', 0, N'1234', 15, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (12, N'ElifCan', 0, N'1234', 16, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (13, N'EminBorandag', 1, N'1234', 17, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (14, N'AsenaBoga', 0, N'1234', 18, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (15, N'HasanOkur', 0, N'1234', 19, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (16, N'GulCakmak', 0, N'1234', 20, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (17, N'DidemOzkan', 0, N'1234', 21, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (18, N'AhmetBilir', 1, N'1234', 22, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (19, N'EmreAtabek', 0, N'1234', 23, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (20, N'EdaDemir', 1, N'1234', 24, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (21, N'OzgeAlgan', 1, N'1234', 25, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (22, N'HiraBilir', 0, N'1234', 26, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (23, N'EcemTurhan', 0, N'1234', 28, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (24, N'AliErcan', 0, N'1234', 29, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (25, N'EnesBerberoglu', 0, N'1234', 30, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (26, N'LatifeCiftci', 0, N'1234', 31, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (27, N'BusraSahin', 0, N'1234', 32, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (28, N'DuruDemirel', 0, N'1234', 33, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (29, N'MehmetYilmaz', 0, N'1234', 34, 0)
INSERT [dbo].[Kullanici] ([kullaniciId], [kullaniciAdi], [Yetki], [sifre], [personelId], [aktifMi]) VALUES (30, N'OkanKaya', 0, N'1234', 35, 0)
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
SET IDENTITY_INSERT [dbo].[Oda] ON 

INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (10, 1, 2, N'201', 1)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (11, 1, 2, N'202', 17)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (12, 1, 2, N'203', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (13, 1, 2, N'204', 13)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (14, 1, 2, N'205', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (15, 1, 2, N'206', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (16, 6, 2, N'201', 22)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (17, 6, 2, N'202', 23)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (18, 6, 2, N'203', 22)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (19, 7, 3, N'301', 24)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (20, 7, 3, N'302', 24)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (21, 7, 3, N'303', 24)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (22, 8, 4, N'401', 25)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (23, 8, 4, N'402', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (24, 2, 3, N'301', 18)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (25, 2, 3, N'302', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (26, 2, 3, N'303', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (27, 3, 4, N'401', 16)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (28, 3, 4, N'402', 16)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (29, 3, 4, N'403', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (30, 13, 2, N'201', 31)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (31, 13, 2, N'202', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (32, 13, 2, N'203', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (33, 14, 3, N'301', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (34, 14, 3, N'302', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (35, 14, 3, N'303', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (36, 15, 4, N'401', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (37, 15, 4, N'402', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (38, 16, 5, N'501', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (39, 16, 5, N'502', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (40, 16, 5, N'503', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (41, 18, 2, N'201', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (42, 18, 2, N'202', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (43, 18, 2, N'203', 28)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (44, 19, 2, N'204', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (45, 19, 2, N'205', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (46, 19, 2, N'206', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (47, 20, 3, N'301', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (48, 20, 3, N'302', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (49, 20, 3, N'303', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (50, 21, 4, N'401', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (51, 20, 4, N'402', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (52, 21, 4, N'403', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (53, 22, 2, N'201', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (54, 22, 2, N'202', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (55, 23, 3, N'301', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (56, 23, 3, N'302', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (57, 24, 4, N'401', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (58, 24, 4, N'402', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (59, 25, 2, N'201', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (60, 25, 2, N'202', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (61, 26, 3, N'301', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (62, 26, 3, N'302', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (63, 27, 4, N'401', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (64, 27, 4, N'402', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (65, 28, 4, N'403', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (66, 28, 4, N'404', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (67, 29, 2, N'201', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (68, 29, 2, N'202', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (69, 29, 2, N'203', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (70, 30, 3, N'301', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (71, 30, 3, N'302', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (72, 31, 4, N'401', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (73, 31, 4, N'402', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (74, 32, 5, N'501', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (75, 32, 5, N'502', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (76, 4, 3, N'304', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (77, 4, 3, N'305', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (78, 5, 3, N'306', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (79, 5, 3, N'307', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (80, 16, 4, N'404', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (81, 9, 2, N'201', 29)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (82, 10, 3, N'301', NULL)
INSERT [dbo].[Oda] ([odaId], [departmanId], [odaKat], [odaNumarasi], [personelId]) VALUES (83, 1, 3, N'102', 1)
SET IDENTITY_INSERT [dbo].[Oda] OFF
SET IDENTITY_INSERT [dbo].[OdaDemirbasAtama] ON 

INSERT [dbo].[OdaDemirbasAtama] ([odaDemirbasId], [odaId], [demirbasId], [adet], [demirbasKodu]) VALUES (19, 10, 1, 30, N'01.01.01.01')
INSERT [dbo].[OdaDemirbasAtama] ([odaDemirbasId], [odaId], [demirbasId], [adet], [demirbasKodu]) VALUES (20, 11, 7, 1, N'01.01.02.07')
INSERT [dbo].[OdaDemirbasAtama] ([odaDemirbasId], [odaId], [demirbasId], [adet], [demirbasKodu]) VALUES (21, 27, 6, 1, N'01.03.03.06')
INSERT [dbo].[OdaDemirbasAtama] ([odaDemirbasId], [odaId], [demirbasId], [adet], [demirbasKodu]) VALUES (22, 11, 6, 1, N'01.01.03.06')
INSERT [dbo].[OdaDemirbasAtama] ([odaDemirbasId], [odaId], [demirbasId], [adet], [demirbasKodu]) VALUES (23, 83, 9, 0, N'01.01.01.09')
SET IDENTITY_INSERT [dbo].[OdaDemirbasAtama] OFF
SET IDENTITY_INSERT [dbo].[Personel] ON 

INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (1, N'Damla', N'Demir', N'010101', 1, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (13, N'Nilay', N'Bilir', N'010113', 1, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (15, N'Burak Çağrı', N'Duba', N'010215', 2, N'erkek.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (16, N'Elif', N'Can', N'010316', 3, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (17, N'Emin', N'Borandağ', N'010117', 1, N'erkek.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (18, N'Asena', N'Boğa', N'010218', 2, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (19, N'Hasan ', N'Okur', N'010419', 4, N'erkek.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (20, N'Gül', N'Çakmak', N'010520', 5, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (21, N'Didem', N'Özkan', N'010421', 4, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (22, N'Ahmet', N'Bilir', N'020622', 6, N'erkek.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (23, N'Emre', N'Atabek', N'020623', 6, N'erkek.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (24, N'Eda', N'Demir', N'020724', 7, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (25, N'Özge', N'Algan', N'020825', 8, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (26, N'Hira', N'Bilir', N'020826', 8, N'bayan.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (28, N'Ecem', N'Turhan', N'051828', 18, N'woman_icon.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (29, N'Ali', N'Ercan', N'030929', 9, N'icono-hombre.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (30, N'Enes', N'Berberoğlu', N'031230', 12, N'icono-hombre.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (31, N'Latife', N'Çiftçi', N'041331', 13, N'woman_icon.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (32, N'Büşra', N'Şahin', N'041332', 13, N'woman_icon.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (33, N'Duru', N'Demirel', N'062233', 22, N'woman_icon.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (34, N'Mehmet', N'Yılmaz', N'062334', 23, N'icono-hombre.jpg')
INSERT [dbo].[Personel] ([personelId], [personelAdi], [personelSoyadi], [personelSicilNo], [departmanId], [fotograf]) VALUES (35, N'Okan', N'Kaya', N'062435', 24, N'icono-hombre.jpg')
SET IDENTITY_INSERT [dbo].[Personel] OFF
SET IDENTITY_INSERT [dbo].[Stok] ON 

INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (14, 1, 270)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (15, 2, 50)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (16, 3, 100)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (17, 4, 350)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (18, 5, 500)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (19, 6, 8)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (20, 7, 149)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (21, 8, 350)
INSERT [dbo].[Stok] ([stokId], [demirbasId], [stokAdet]) VALUES (22, 9, 100)
SET IDENTITY_INSERT [dbo].[Stok] OFF
ALTER TABLE [dbo].[Demirbas]  WITH CHECK ADD  CONSTRAINT [FK_Demirbas_DemirbasTur] FOREIGN KEY([demirbasTuruId])
REFERENCES [dbo].[DemirbasTur] ([demirbasTuruId])
GO
ALTER TABLE [dbo].[Demirbas] CHECK CONSTRAINT [FK_Demirbas_DemirbasTur]
GO
ALTER TABLE [dbo].[Departman]  WITH CHECK ADD  CONSTRAINT [FK_Departman_Fakulte] FOREIGN KEY([fakulteId])
REFERENCES [dbo].[Fakulte] ([fakulteId])
GO
ALTER TABLE [dbo].[Departman] CHECK CONSTRAINT [FK_Departman_Fakulte]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Personel] FOREIGN KEY([personelId])
REFERENCES [dbo].[Personel] ([personelId])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Personel]
GO
ALTER TABLE [dbo].[Oda]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Departman] FOREIGN KEY([departmanId])
REFERENCES [dbo].[Departman] ([departmanId])
GO
ALTER TABLE [dbo].[Oda] CHECK CONSTRAINT [FK_Oda_Departman]
GO
ALTER TABLE [dbo].[Oda]  WITH CHECK ADD  CONSTRAINT [FK_Oda_Personel] FOREIGN KEY([personelId])
REFERENCES [dbo].[Personel] ([personelId])
GO
ALTER TABLE [dbo].[Oda] CHECK CONSTRAINT [FK_Oda_Personel]
GO
ALTER TABLE [dbo].[OdaDemirbasAtama]  WITH CHECK ADD  CONSTRAINT [FK_OdaDemirbasAtama_Demirbas] FOREIGN KEY([demirbasId])
REFERENCES [dbo].[Demirbas] ([demirbasId])
GO
ALTER TABLE [dbo].[OdaDemirbasAtama] CHECK CONSTRAINT [FK_OdaDemirbasAtama_Demirbas]
GO
ALTER TABLE [dbo].[OdaDemirbasAtama]  WITH CHECK ADD  CONSTRAINT [FK_OdaDemirbasAtama_Oda] FOREIGN KEY([odaId])
REFERENCES [dbo].[Oda] ([odaId])
GO
ALTER TABLE [dbo].[OdaDemirbasAtama] CHECK CONSTRAINT [FK_OdaDemirbasAtama_Oda]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Departman] FOREIGN KEY([departmanId])
REFERENCES [dbo].[Departman] ([departmanId])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Personel_Departman]
GO
ALTER TABLE [dbo].[Stok]  WITH CHECK ADD  CONSTRAINT [FK_Stok_Demirbas] FOREIGN KEY([demirbasId])
REFERENCES [dbo].[Demirbas] ([demirbasId])
GO
ALTER TABLE [dbo].[Stok] CHECK CONSTRAINT [FK_Stok_Demirbas]
GO
