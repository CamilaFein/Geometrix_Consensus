CREATE TABLE [dbo].[Sets_Figuras](
	[ID_Figura] [int] NOT NULL,
	[ID_Set] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio_Set] [decimal](19, 4) NOT NULL, 
    CONSTRAINT [PK_Sets_Figuras] PRIMARY KEY ([ID_Figura], [ID_Set]))
