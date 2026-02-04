--Syntax:- USE database_name;
USE CollegeDB;
GO

-- INNER JOIN
--Syntax:- SELECT columns FROM table1 INNER JOIN table2 ON table1.column=table2.column;
SELECT s.Name, d.DeptName FROM Student s INNER JOIN Department d ON s.DeptID=d.DeptID;

-- LEFT JOIN
--Syntax:- SELECT columns FROM table1 LEFT JOIN table2 ON table1.column=table2.column;
SELECT s.Name, c.CourseName FROM Student s LEFT JOIN Enrollment e ON s.StudentID=e.StudentID LEFT JOIN Course c ON e.CourseID=c.CourseID;

-- RIGHT JOIN
--Syntax:- SELECT columns FROM table1 RIGHT JOIN table2 ON table1.column=table2.column;
SELECT s.Name, d.DeptName FROM Student s RIGHT JOIN Department d ON s.DeptID=d.DeptID;

-- FULL JOIN
--Syntax:- SELECT columns FROM table1 FULL JOIN table2 ON table1.column=table2.column;
SELECT s.Name, d.DeptName FROM Student s FULL JOIN Department d ON s.DeptID=d.DeptID;

-- SELF JOIN
--Syntax:- SELECT A.column, B.column FROM table A, table B WHERE A.common_column=B.common_column AND A.primary_key <> B.primary_key;
SELECT A.Name, B.Name FROM Student A, Student B WHERE A.DeptID=B.DeptID AND A.StudentID <> B.StudentID;

-- CROSS JOIN
--Syntax:- SELECT columns FROM table1 CROSS JOIN table2;
SELECT s.Name, c.CourseName FROM Student s CROSS JOIN Course c;
