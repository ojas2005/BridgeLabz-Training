CREATE DATABASE HealthClinicDB;
GO
USE HealthClinicDB;

CREATE TABLE Patients(patientId INT IDENTITY(1,1) PRIMARY KEY,name NVARCHAR(100) NOT NULL,dob DATE,phone NVARCHAR(15) UNIQUE,email NVARCHAR(100) UNIQUE,address NVARCHAR(255),blood_group NVARCHAR(5));

--taking data so that its easy to explain searching
INSERT INTO Patients (name,dob,phone,email,address,blood_group) VALUES ('Rahul Sharma','1998-05-10','9897851033','rahul@gmail.com','Delhi','O+'),
('Amit Verma','1995-03-21','9897851034','amit2@gmail.com','Mumbai','A+'),
('Sneha Kapoor','1992-11-02','9897851035','sneha3@gmail.com','Pune','B+'),
('Rohit Mehta','1990-07-15','9897851036','rohit4@gmail.com','Chennai','AB+'),
('Neha Singh','1998-01-30','9897851037','neha5@gmail.com','Kolkata','O-'),
('Vikas Yadav','1993-09-09','9897851038','vikas6@gmail.com','Jaipur','A-'),
('Priya Nair','1997-06-18','9897851039','priya7@gmail.com','Bangalore','B-'),
('Karan Malhotra','1994-12-25','9897851040','karan8@gmail.com','Hyderabad','O+'),
('Anjali Desai','1991-04-14','9897851041','anjali9@gmail.com','Ahmedabad','A+'),
('Suresh Reddy','1989-08-08','9897851042','suresh10@gmail.com','Vizag','B+'),
('Meena Joshi','1996-02-19','9897851043','meena11@gmail.com','Lucknow','AB-'),
('Arjun Patel','1993-05-27','9897851044','arjun12@gmail.com','Surat','O+'),
('Pooja Roy','1999-10-10','9897851045','pooja13@gmail.com','Patna','A+'),
('Manish Gupta','1992-07-07','9897851046','manish14@gmail.com','Bhopal','B+'),
('Ritika Shah','1995-09-17','9897851047','ritika15@gmail.com','Indore','O-'),
('Deepak Kumar','1991-03-03','9897851048','deepak16@gmail.com','Noida','A-'),
('Shalini Rao','1994-11-11','9897851049','shalini17@gmail.com','Nagpur','B-'),
('Gaurav Jain','1990-06-06','9897851050','gaurav18@gmail.com','Chandigarh','O+'),
('Nikita Arora','1998-08-28','9897851051','nikita19@gmail.com','Gurgaon','AB+'),
('Harsh Vardhan','1997-12-01','9897851052','harsh20@gmail.com','Ranchi','A+'),
('Tanya Mishra','1993-01-22','9897851053','tanya21@gmail.com','Kanpur','B+'),
('Yash Thakur','1996-04-09','9897851054','yash22@gmail.com','Agra','O-'),
('Divya Iyer','1992-10-30','9897851055','divya23@gmail.com','Coimbatore','A+'),
('Aditya Sen','1991-05-16','9897851056','aditya24@gmail.com','Dehradun','B+'),
('Komal Bansal','1999-09-05','9897851057','komal25@gmail.com','Jodhpur','O+'),
('Ramesh Pillai','1988-02-12','9897851058','ramesh26@gmail.com','Trivandrum','AB-'),
('Ishita Bose','1997-07-19','9897851059','ishita27@gmail.com','Shillong','A-'),
('Naveen Choudhary','1995-03-08','9897851060','naveen28@gmail.com','Udaipur','B-'),
('Sakshi Khanna','1994-06-26','9897851061','sakshi29@gmail.com','Amritsar','O+'),
('Varun Saxena','1992-12-14','9897851062','varun30@gmail.com','Meerut','A+');

UPDATE Patients SET address = 'Goa',blood_group = 'A+' WHERE patientId = 1;
--Searching By name
SELECT * FROM Patients WHERE name LIKE '%Ramesh%';
--Searching By phone number
SELECT * FROM Patients WHERE phone = '9897851038';
