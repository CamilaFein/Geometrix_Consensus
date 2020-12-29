CREATE PROCEDURE Detalle_Sets
	@Fecha DATETIME = NULL
AS
BEGIN
	DECLARE @sql NVARCHAR(MAX) = N'', @sqlVal NVARCHAR(MAX) = N'', @cols NVARCHAR(MAX) = N'', @colsName NVARCHAR(MAX) = N'',  @colsVal NVARCHAR(MAX) = N'',  @colsValName NVARCHAR(MAX) = N'';

	SELECT  @cols += STUFF((SELECT ',' + QUOTENAME(descripcion) 
						   FROM figuras
						   FOR XML PATH('')), 1, 1, '');

	SELECT  @colsName += STUFF((SELECT ',sum(' + a.value + ') as '+ a.value +''
						FROM STRING_SPLIT(@cols, ',') AS A
							 FOR XML PATH('')), 1, 1, '');

	SELECT @colsVal += STUFF((SELECT ',' + QUOTENAME('Valorizado ' + replace(replace(a.value, '[', ''), ']', ''))
						   FROM STRING_SPLIT(@cols, ',') AS A
						   FOR XML PATH('')), 1, 1, '');

	SELECT @colsValName += STUFF((SELECT ',sum(' + QUOTENAME(replace(replace(a.value, '[', ''), ']', '')) + ') as ' + a.value
						   FROM STRING_SPLIT(@colsVal, ',') AS A
						   FOR XML PATH('')), 1, 1, '');
	CREATE TABLE #Temp(ID_Set INT, Cuadrado INT, Rectangulo INT, Triangulo INT, Circulo INT, Valorizado_Cuadrado DECIMAL(19,4), Valorizado_Rectangulo DECIMAL(19,4), Valorizado_Triangulo DECIMAL(19,4), Valorizado_Circulo DECIMAL(19,4), Total_Set DECIMAL(19,4));
	SET @sql = N'INSERT INTO #Temp
				SELECT ID_SET, ' + @colsName + ', ' + @colsValName + ', sum(precio) as [Total_Set]
				FROM 
					(SELECT s.id_set, f.descripcion, SF.Cantidad as cantidad, ''Valorizado '' + f.descripcion as valorizado, SF.Precio_Set, SF.Precio_Set as precio
					FROM Sets S (NOLOCK)
					JOIN Sets_Figuras SF (NOLOCK) ON S.ID_Set = SF.ID_Set
					JOIN Figuras F (NOLOCK) ON SF.ID_Figura = F.ID_Figura
					WHERE s.Fecha = '+ @Fecha +'
				) AS d
				PIVOT (sum([cantidad]) FOR [descripcion] IN (' + @cols + ')) AS p
				PIVOT (sum([Precio_Set]) FOR [valorizado] IN (' + @colsVal + ')) AS pv
			group by ID_Set'

	EXEC sp_executesql @sql;
	
	select * from #Temp

	DROP TABLE #Temp
END