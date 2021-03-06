﻿CREATE TABLE [dbo].[Predmet] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [Shifra_Na_Predmet] NVARCHAR (10) NOT NULL,
    [Ime]               NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Predmet] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UK_Predmet_Ime] UNIQUE NONCLUSTERED ([Ime] ASC),
    CONSTRAINT [UK_Predmet_Shifra_Na_Predmet] UNIQUE NONCLUSTERED ([Shifra_Na_Predmet] ASC)
);