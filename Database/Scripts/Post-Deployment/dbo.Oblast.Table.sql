set IDENTITY_INSERT LearnByPractice.dbo.Oblast On
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
WHEN Matched Then 
UPDATE SET Ime=[source].[ime]
When Not Matched By Target then
insert ( [ID], [Ime]) Values ([source].[id], [source].[ime])
When not matched by source then
DELETE;
set IDENTITY_INSERT LearnByPractice.dbo.Oblast Off
