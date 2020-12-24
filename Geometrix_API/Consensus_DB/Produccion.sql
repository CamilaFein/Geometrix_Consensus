CREATE TABLE [dbo].[Produccion]
(
	[ID_Produccion] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Precio_Total] [decimal](19, 4) NOT NULL,
	[Total_Costo] [decimal](19, 4) NOT NULL,
	[Ganancia] [decimal](19, 4) NOT NULL,
)
