MERGE INTO [dbo].[Korisnik] AS[target]
USING
	(VALUES
		(
			N'jasmina', 0x65B2464F2D2DAD5D319EDA267467E983E36BFAB6016B91C0F3CD9B70263C13178352E1C057D9757D1F03DA37692D7968, 
			N'Јасмина', N'Кукуноска', N'Ж', 1, 1, N'jasminakukunoska@gmail.com', NULL, 1, 1, 1
		),
		(
			N'marija', 0x453A5093E3605249FBCF5FDCA571BCB8ECE54FD3400161DC560363A1226D14F79E31CD14EE74BD8F746FDD2329D94FFE,
			N'Марија', N'Кузмановска', N'Ж', 1, 1, N'm_kuzmanovska08@yahoo.com', NULL, 1, 1, 1
		),
		(
			N'simona', 0x,
			N'Симона', N'Апостолоска', N'Ж', 1, 1, N'simonaapostoloska@gmail.com', NULL, 1, 1, 1
		),
		(
			N'evgenija', 0x,
			N'Евгенија', N'Конеска', N'Ж', 1, 1, N'koneskaevgenija@gmail.com', NULL, 1, 1, 1
		),
		(
			N'frosina', 0x,
			N'Фросина', N'Христоска', N'Ж', 1, 1, N'frosinahristoska@icloud.com', NULL, 1, 1, 1
		),
		(
			N'sara', 0x,
			N'Сара', N'Богоеска', N'Ж', 1, 1, N'bogoeskasara4@gmail.com', NULL, 1, 1, 1
		),
		(
			N'zoran', 0x,
			N'Зоран', N'Котевски', N'М', 1, 1, N'zoran.kotevski@gmail.com', NULL, 1, 1, 1
		),
		(
			N'goce', 0x,
			N'Гоце', N'Смилевски', N'М', 1, 1, N'g_smilevski@hotmail.com', NULL, 1, 1, 1
		),

		(
			N'admin', 0x,
			N'Администратор', N'Администратор', N'М', NULL, 1, N'learnbypractice@fikt.edu.mk', NULL, 1, 0, 0
		),
		(
			N'mentor', 0x,
			N'Ментор', N'Ментор', N'М', NULL, 1, N'learnbypractice@fikt.edu.mk', NULL, 0, 0, 1
		),
		(
			N'student', 0x,
			N'Студент', N'Студент', N'М', 1, 1, N'learnbypractice@fikt.edu.mk', NULL, 0, 1, 0
		)
	)
	AS [source] (korisnichkoIme, lozinka, ime, prezime, pol, studiskaProgramaID, organizacijaID,
				 email, telefonskiBroj, administrator, student, mentor)
ON [target].Korisnichko_Ime = [source].korisnichkoIme
WHEN MATCHED THEN
	UPDATE SET [target].Korisnichko_Ime = [source].korisnichkoIme,
				[target].Lozinka = [source].lozinka,
				[target].Ime = [source].ime, 
				[target].Prezime = [source].prezime,
				[target].Pol = [source].pol,
				[target].Studiska_Programa_ID = [source].studiskaProgramaID,
				[target].Organizacija_ID = [source].organizacijaID,
				[target].Email = [source].email,
				[target].Telefonski_Broj = [source].telefonskiBroj,
				[target].Administrator = [source].administrator,
				[target].Student = [source].student,
				[target].Mentor = [source].mentor
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Korisnichko_Ime], [Lozinka], [Ime], [Prezime], [Pol], [Studiska_Programa_ID],
			[Organizacija_ID], [Email], [Telefonski_Broj], [Administrator], [Student], [Mentor])
		VALUES ([source].[korisnichkoIme], [source].[lozinka], [source].[ime], [source].[prezime],
				[source].[pol], [source].[studiskaProgramaID], [source].[organizacijaID],
				[source].[email], [source].[telefonskiBroj], [source].[administrator],
				[source].[student], [source].[mentor])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;