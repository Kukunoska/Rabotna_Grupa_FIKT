SET IDENTITY_INSERT LearnByPractice.dbo.Oblast ON
GO

MERGE INTO [dbo].[Oblast] AS [target]
USING 
	(VALUES
		(1,N'Софтверско инженерство'),
		(2, N'Мрежни сервиси'),
		(3,'Embedded software development'),
		(4,'Online marketing')
	)
	AS [source] (id, ime)
ON [target].[ID] = [source].[id]
WHEN MATCHED THEN
	UPDATE SET Ime = [source].[ime]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ( [ID], [Ime]) Values ([source].[id], [source].[ime])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT LearnByPractice.dbo.Oblast OFF
GO
