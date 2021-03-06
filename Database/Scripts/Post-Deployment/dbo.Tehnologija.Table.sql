set identity_insert LearnByPractice.dbo.Tehnologija On
MERGE INTO [dbo].[Tehnologija] AS [target]
USING 
(VALUES
(1,'C#, Dot.NET',1),
(2,'Java', 1),
(3,'PHP', 1),
(4,'HTML 5,CSS 3, JavaScript,PhotoShop', 1)
)
AS [source] (id, ime, oblastId)
ON [target].[ID] = [source].[id]
WHEN Matched Then 
UPDATE SET Ime=[source].[ime],
Oblast_ID=[source].[oblastId]
When Not Matched By Target then
insert ( [ID], [Ime],[Oblast_ID]) Values ([source].[id],[source].[ime], [source].[oblastId])
When not matched by source then
DELETE
;
set identity_insert LearnByPractice.dbo.Tehnologija Off