/*
CREATE LOGIN needs master DB
CREATE USER needs CollegeDB
*/

USE master;
GO
CREATE LOGIN testuser WITH PASSWORD='Test@123';
GO

--Syntax:- USE database_name;
USE CollegeDB;
GO
CREATE USER testuser FOR LOGIN testuser;
GO

--DCL

/*
Grant & Revoke Permissions(DCL)
Syntax:- GRANT/REVOKE permissions ON table TO user;
*/

GRANT SELECT, INSERT ON Student TO testuser; --testuser will be having Select and Insert permissions
GO

REVOKE INSERT ON Student FROM testuser; --Insert permission removed from test user
GO


--TCL

--Syntax:- BEGIN TRANSACTION;
BEGIN TRANSACTION;

--Syntax:- INSERT INTO table_name VALUES(values);
INSERT INTO Student VALUES (110, 'Karan',22,1); 

--Syntax:- ROLLBACK;
ROLLBACK;
GO
SELECT * FROM Student WHERE StudentID=110;
GO


--Syntax:- BEGIN TRANSACTION;
BEGIN TRANSACTION;

--Syntax:- INSERT INTO table_name VALUES(values);
INSERT INTO Student VALUES (111,'Neha',23,2);

--Syntax:- COMMIT;
COMMIT;
GO

-- Check (should return the row)
SELECT * FROM Student WHERE StudentID=111;
GO

