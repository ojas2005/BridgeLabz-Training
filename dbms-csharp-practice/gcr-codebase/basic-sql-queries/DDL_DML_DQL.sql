--Creating Database
--Syntax:- CREATE DATABASE database_name;
CREATE DATABASE CollegeDB;
GO

--Syntax:- USE database_name;
USE CollegeDB;
GO

--DDL Commands
--Syntax:- CREATE TABLE table_name(column_name datatype constraints);
CREATE TABLE Department(DeptID INT PRIMARY KEY,DeptName VARCHAR(50) UNIQUE);

--Syntax:- CREATE TABLE table_name(column_name datatype constraints, FOREIGN KEY(column) REFERENCES parent_table(column));
CREATE TABLE Student(StudentID INT PRIMARY KEY,Name VARCHAR(50) NOT NULL,Age INT CHECK (Age > 0),DeptID INT,FOREIGN KEY (DeptID) REFERENCES Department(DeptID));

CREATE TABLE Course(CourseID INT PRIMARY KEY,CourseName VARCHAR(50),DeptID INT,FOREIGN KEY (DeptID) REFERENCES Department(DeptID));

--ALTER TABLE
--Syntax:- ALTER TABLE table_name ADD column_name datatype;
ALTER TABLE Student ADD Email VARCHAR(100);

--Syntax:- ALTER TABLE table_name ALTER COLUMN column_name datatype;
ALTER TABLE Student ALTER COLUMN Email VARCHAR(150);

--Syntax:- ALTER TABLE table_name DROP COLUMN column_name;
ALTER TABLE Student DROP COLUMN Email;

--DML Commands

--INSERT Values into table
--Syntax:- INSERT INTO table_name VALUES(value1,value2,...);
INSERT INTO Department VALUES(1,'CSE'),(2,'ECE'),(3,'ME'),(4,'CE'),(5,'EEE'),(6,'IT'),(7,'AI'),(8,'DS'),(9,'Cyber'),(10,'BioTech');
INSERT INTO Student VALUES(101,'Ojas',21,1),(102,'Aman',22,2),(103,'Riya',20,1),(104,'Karan',23,3),(105,'Neha',22,4),
(106,'Simran',21,5),(107,'Rahul',24,6),
(108,'Priya',20,7),(109,'Arjun',22,8),(110,'Sneha',21,9),(111,'Rohit',23,10),(112,'Anjali',20,1),(113,'Vikas',22,2),
(114,'Meera',21,3),(115,'Tarun',24,4),(116,'Pooja',20,5),(117,'Nikhil',22,6),(118,'Isha',21,7),(119,'Yash',23,8),(120,'Divya',20,9),
(121,'Aditya',22,10),(122,'Sanya',21,1),(123,'Manav',23,2),(124,'Kriti',20,3),(125,'Harsh',22,4),(126,'Tanya',21,5),
(127,'Kabir',24,6),(128,'Naina',20,7),(129,'Aryan',22,8),(130,'Muskan',21,9),(131,'Dev',23,10),(132,'Aditi',20,1),(133,'Siddharth',22,2),
(134,'Lavanya',21,3),(135,'Gaurav',24,4),
(136,'Ritika',20,5),(137,'Mohit',22,6),(138,'Shreya',21,7),(139,'Laksh',23,8),(140,'Preeti',20,9),(141,'Chirag',22,10),(142,'Ananya',21,1),(143,'Varun',23,2),(144,'Tanvi',20,3),(145,'Raghav',22,4),(146,'Palak',21,5),(147,'Kush',24,6),(148,'Jiya',20,7),(149,'Aarav',22,8),(150,'Mahi',21,9);

INSERT INTO Course VALUES(201,'DBMS',1),(202,'Networks',2),(203,'Thermodynamics',3),(204,'Structures',4),
(205,'Circuits',5),(206,'Operating Systems',1),(207,'Data Science',8),
(208,'Machine Learning',7),(209,'Cyber Security',9),(210,'Genetics',10),
(211,'Cloud Computing',6),(212,'Microprocessors',2),(213,'AI Basics',7),(214,'Big Data',8),
(215,'Digital Logic',5),(216,'Compiler Design',1),(217,'Robotics',3),(218,'Environmental Engg',4),
(219,'Ethical Hacking',9),(220,'Biochemistry',10);


--UPDATE values
--Syntax:- UPDATE table_name SET column=value WHERE condition;
UPDATE Student SET Age=23 WHERE StudentID=102;

--DELETE a row
--Syntax:- DELETE FROM table_name WHERE condition;
DELETE FROM Student WHERE StudentID=103;

--DQL Commands
--Syntax:- SELECT * FROM table_name;
SELECT * FROM Student;

--Syntax:- SELECT * FROM table_name WHERE condition;
SELECT * FROM Student WHERE DeptID=1;

--Syntax:- SELECT * FROM table_name ORDER BY column DESC/ASC;
SELECT * FROM Student ORDER BY Age DESC;

--Syntax:- SELECT column,AGGREGATE_FUNCTION(column) FROM table_name GROUP BY column;
SELECT DeptID,COUNT(*) AS TotalStudents FROM Student GROUP BY DeptID;

--Syntax:- SELECT column,AGGREGATE_FUNCTION(column) FROM table_name GROUP BY column HAVING condition;
SELECT DeptID,COUNT(*) AS TotalStudents FROM Student GROUP BY DeptID HAVING COUNT(*)>0;

--DISTINCT
--Syntax:- SELECT DISTINCT column FROM table_name;
SELECT DISTINCT DeptID FROM Student;

--TOP
--Syntax:- SELECT TOP number * FROM table_name;
SELECT TOP 2 * FROM Student;

--TRUNCATE & DROP examples(DDL)

--Syntax:- TRUNCATE TABLE table_name;
TRUNCATE TABLE Course; -- deletes data but keeps structure

--DROP TABLE example(commented for safety)
--Syntax:- DROP TABLE table_name;
--DROP TABLE Course; -- table along with its structure will be removed


