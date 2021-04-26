--IF SCHEMA_ID(N'Movies') IS NULL
IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'Movies'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [Movies] AUTHORIZATION [dbo]');
END
--GO