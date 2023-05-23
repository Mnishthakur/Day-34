-- create database if not exists
DECLARE @dbname nvarchar(128)
--set your required database name
SET @dbname = N'MyDatabase'
IF (NOT EXISTS (SELECT name FROM dbo.sysdatabases
WHERE ('[' + name + ']' = @dbname 
OR name = @dbname)))
BEGIN
 SET @dbname = 'CREATE DATABASE '+@dbname;
 EXEC (@dbname);
 select 'created db';
 END
