CREATE FUNCTION ultimoCodigo(@tableName VARCHAR(20))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @tablePrefix CHAR(3)
	DECLARE @query nvarchar(max)
	DECLARE @lastCode VARCHAR(10)

	SET @tablePrefix = SUBSTRING(@tableName,3,3)
	SET @query = 'SELECT TOP 1 @lastCode='+@tablePrefix+'_Codigo FROM [' + @tablename + '] ORDER BY '+@tablePrefix+'_Codigo DESC'
	EXEC sp_executesql @query, N'@lastCode VARCHAR(10) out', @lastCode out
	RETURN @lastCode
END
GO

CREATE FUNCTION nuevoCodigo(@tableName VARCHAR(20))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @tablePrefix CHAR(3)
	DECLARE @query nvarchar(max)
	DECLARE @lastCode VARCHAR(10)

	SET @tablePrefix = SUBSTRING(@tableName,3,3)
	SET @query = 'SELECT TOP 1 @lastCode='+@tablePrefix+'_Codigo FROM [' + @tablename + '] ORDER BY '+@tablePrefix+'_Codigo DESC'
	EXEC sp_executesql @query, N'@lastCode VARCHAR(10) out', @lastCode out
	RETURN UPPER(@tablePrefix)+REPLACE(STR(CONVERT(INT,SUBSTRING(@lastCode,4,7))+1, 7), SPACE(1), '0')
END
GO

DECLARE @lastCode VARCHAR(10)
EXEC @lastCode = ultimoCodigo 'tbdocumento'
PRINT @lastCode