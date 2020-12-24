CREATE TABLE [dbo].[IT_Produccion](
	[ID_IT_Produccion] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ID_Produccion] [int] NOT NULL,
	[ID_Figura] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Total_Costo] [decimal](19, 4) NOT NULL, 
    CONSTRAINT [FK_IT_Produccion_ID_Produccion] FOREIGN KEY ([ID_Produccion]) REFERENCES [Produccion]([ID_Produccion]),
	CONSTRAINT [FK_IT_Produccion_ID_Figura] FOREIGN KEY ([ID_Figura]) REFERENCES [Figuras]([ID_Figura])
)

