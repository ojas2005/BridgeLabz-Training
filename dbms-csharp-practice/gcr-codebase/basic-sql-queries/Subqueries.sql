--Syntax:- USE database_name;
USE CollegeDB;
GO

-- Subquery in WHERE
--Syntax:- SELECT column FROM table WHERE column=(SELECT column FROM table WHERE condition);
SELECT Name FROM Student WHERE DeptID=(SELECT DeptID FROM Department WHERE DeptName='CSE');

-- Subquery with EXISTS
--Syntax:- SELECT column FROM table1 WHERE EXISTS (SELECT 1 FROM table2 WHERE table1.column=table2.column);
SELECT Name FROM Student s WHERE EXISTS (SELECT 1 FROM Enrollment e WHERE s.StudentID=e.StudentID);

-- Subquery in FROM
--Syntax:- SELECT column FROM (SELECT aggregate_function(column) AS alias FROM table) AS alias_table;
SELECT AvgAge FROM (SELECT AVG(Age) AS AvgAge FROM Student) AS AgeTable;
