SET IDenTITY_INSERT dbo.Studiska_Programa ON
GO

MERGE INTO [dbo].[Studiska_Programa] AS [target]
USING 
	(VALUES
		(1, N'Компјутерски науки и инженерство'),
		(2, N'Информатички науки и комуникациско инженерство')
	)
	AS [source] (id, ime)
ON [target].ID = [source].id
WHEN MATCHED THEN
	UPDATE SET [target].Ime = [source].ime
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([ID], [Ime]) VALUES ([source].id,[source].ime)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDenTITY_INSERT dbo.Studiska_Programa OFF
GO
