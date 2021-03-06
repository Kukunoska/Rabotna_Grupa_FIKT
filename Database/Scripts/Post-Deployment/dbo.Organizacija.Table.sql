MERGE INTO [dbo].[Organizacija] AS [target]
USING 
	(VALUES 
		(N'Факултет за информатички и комуникациски технологи', 
			N'ул. Партизанска бб 7000 Битола', 
			N'+389 47 259 917',
			N'http://www.fikt.uklo.edu.mk', 1
		),
		(N'iSOURCE', 
			N'ул. Солунска бр. 226 7000 Битола', 
			N'+389 78 603 374', 
			N'http://isource.com.mk', 2
		)
	)
	AS [source] (ime, adresa, kontaktTelefon, vebStrana, vidOrganizacijaID)
ON [target].Ime = [source].ime
WHEN MATCHED THEN
	UPDATE SET [target].Ime = [source].ime, [target].Adresa = [source].adresa,
		[target].Kontakt_Telefon = [source].kontaktTelefon,
		[target].Veb_Strana = [source].vebStrana,
		[target].Vid_Organizacija_ID = [source].vidOrganizacijaID
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Ime], [Adresa], [Kontakt_Telefon], [Veb_Strana], [Vid_Organizacija_ID]) 
		VALUES ([source].ime, [source].adresa, [source].kontaktTelefon, [source].vebStrana,
			[source].vidOrganizacijaID)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;