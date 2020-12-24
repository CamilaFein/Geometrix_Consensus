CREATE TABLE [dbo].[Figuras]
(
	[ID_Figura] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Descripcion] [varchar](100) NOT NULL,
	[Precio] [decimal](19, 4) NOT NULL,
)
