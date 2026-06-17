--USE database_name;
USE CollegeDB;
GO

--CREATE TABLE table_name(column_name datatype,PRIMARY KEY(column1, column2),FOREIGN KEY(column) REFERENCES parent_table(parent_column) ON DELETE CASCADE ON UPDATE CASCADE);
--Composite key syntax;- PRIMARY KEY(column1, column2)
CREATE TABLE Enrollment (StudentID INT,
            CourseID INT,
            EnrollDate DATE,
            PRIMARY KEY(StudentID, CourseID),
            FOREIGN KEY(StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE ON UPDATE CASCADE,
            FOREIGN KEY(CourseID) REFERENCES Course(CourseID) ON DELETE CASCADE ON UPDATE CASCADE
            );
-- Candidate key example
--CREATE TABLE TABLE_NAME(column_name datatype PRIMARY KEY;column_name datatype UNIQUE;)
CREATE TABLE LibraryCard (CardID INT PRIMARY KEY,Email VARCHAR(100) UNIQUE);
