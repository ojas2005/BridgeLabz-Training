/*
CREATE TABLE table_name (
    column_name data_type [constraints],
    PRIMARY KEY (col1, col2)
);
*/
USE CollegeDB;
GO

-- 1NF(Repeating values removed)
CREATE TABLE Student_1NF(StudentID INT,Name VARCHAR(50),Course VARCHAR(50));

-- 2NF(Remove partial dependency)
CREATE TABLE Student_2NF(StudentID INT PRIMARY KEY,Name VARCHAR(50));

CREATE TABLE Course_2NF(CourseID INT PRIMARY KEY,CourseName VARCHAR(50));

-- 3NF(Remove transitive dependency)
CREATE TABLE Department_3NF(DeptID INT PRIMARY KEY,DeptName VARCHAR(50));

-- BCNF(Every determinant is candidate key)
CREATE TABLE Enrollment_BCNF(StudentID INT,CourseID INT,PRIMARY KEY (StudentID, CourseID));
