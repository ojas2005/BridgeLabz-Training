CREATE DATABASE HealthClinicDB;
GO
USE HealthClinicDB;

CREATE TABLE Patients(patientId INT IDENTITY(1,1) PRIMARY KEY,name NVARCHAR(100) NOT NULL,dob DATE,phone NVARCHAR(15) UNIQUE,email NVARCHAR(100) UNIQUE,address NVARCHAR(255),blood_group NVARCHAR(5));
INSERT INTO Patients (name,dob,phone,email,address,blood_group) VALUES ('Rahul Sharma','1998-05-10','9897851033','rahul@gmail.com','Delhi','O+');