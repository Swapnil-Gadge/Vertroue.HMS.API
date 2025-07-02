--Below script needs to be run on app's database (nonprod and prod databases) after passing the app name appropriately
DECLARE @AppName VARCHAR(100) = '';

IF EXISTS (SELECT * FROM sys.sysusers WHERE [name] = @AppName)
BEGIN
	EXECUTE ('DROP USER ['+ @AppName + ']')
END
EXECUTE ('CREATE USER ['+ @AppName + '] FROM EXTERNAL PROVIDER;')
EXECUTE ('ALTER ROLE db_datareader ADD MEMBER ['+ @AppName + '];')
EXECUTE ('ALTER ROLE db_datawriter ADD MEMBER ['+ @AppName + '];')
EXECUTE ('ALTER ROLE db_owner ADD MEMBER ['+ @AppName + '];')
GO