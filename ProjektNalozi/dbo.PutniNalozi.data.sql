SET IDENTITY_INSERT [dbo].[PutniNalozi] ON
INSERT INTO [dbo].[PutniNalozi] ([PutniNalogId], [RazlogPutovanja], [Polazak], [Povratak], [BrojPutnika], [PutnikId], [Polazište], [Odredište], [Prijevoz], [RegistracijaVozila], [Komentar], [Email]) VALUES (1, 'Moralo se', '20120618 10:34:09 AM', '20120619 10:34:09 AM', 1, 1, 'Osijek', 'Zagreb', 'Službeni automobil', 'OS123AB', NULL, 'marko@gmail.com')
SET IDENTITY_INSERT [dbo].[PutniNalozi] OFF
