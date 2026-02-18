-- Health Care App Database

CREATE DATABASE HealthClinicDB;
GO

USE HealthClinicDB;
GO

-- Created a schema to store all the table rather than in the default dbo
CREATE SCHEMA clinic;
GO


-- Patients Table 
CREATE TABLE clinic.patients (
    patient_id      INT IDENTITY(1,1) PRIMARY KEY,
    full_name       VARCHAR(100) NOT NULL,
    dob             DATE NOT NULL,
    phone           VARCHAR(20) NOT NULL,
    email           VARCHAR(150) NULL,
    address         VARCHAR(250) NULL,
    blood_group     VARCHAR(5) NULL,
    created_at      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_at      DATETIME2 NULL,

    CONSTRAINT uq_patients_phone UNIQUE (phone),
    CONSTRAINT uq_patients_email UNIQUE (email)
);
GO

CREATE INDEX ix_patients_name ON clinic.patients(full_name);
GO


-- Specialties Table
CREATE TABLE clinic.specialties (
    specialty_id    INT IDENTITY(1,1) PRIMARY KEY,
    specialty_name  VARCHAR(100) NOT NULL UNIQUE,
    is_active       BIT NOT NULL DEFAULT 1,
    created_at      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO


-- Doctors Table 
CREATE TABLE clinic.doctors (
    doctor_id           INT IDENTITY(1,1) PRIMARY KEY,
    doctor_name         VARCHAR(120) NOT NULL,
    contact             VARCHAR(20) NULL,
    consultation_fee    DECIMAL(10,2) NOT NULL,
    specialty_id        INT NOT NULL,
    is_active           BIT NOT NULL DEFAULT 1,
    created_at          DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_at          DATETIME2 NULL,

    CONSTRAINT fk_doctors_specialty 
        FOREIGN KEY (specialty_id)  
        REFERENCES clinic.specialties(specialty_id) 
        ON UPDATE CASCADE 
        ON DELETE NO ACTION
);
GO

CREATE INDEX ix_doctors_specialty 
ON clinic.doctors(specialty_id, is_active);
GO


-- Appointments Table
CREATE TABLE clinic.appointments (
    appointment_id   INT IDENTITY(1,1) PRIMARY KEY,
    patient_id       INT NOT NULL,
    doctor_id        INT NOT NULL,
    appointment_date DATE NOT NULL,
    appointment_time TIME(0) NOT NULL,
    status           VARCHAR(20) NOT NULL DEFAULT 'SCHEDULED',
    created_at       DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_at       DATETIME2 NULL,

    CONSTRAINT fk_appt_patient 
        FOREIGN KEY(patient_id) 
        REFERENCES clinic.patients(patient_id) 
        ON UPDATE CASCADE 
        ON DELETE NO ACTION,

    CONSTRAINT fk_appt_doctor 
        FOREIGN KEY(doctor_id) 
        REFERENCES clinic.doctors(doctor_id) 
        ON UPDATE CASCADE 
        ON DELETE NO ACTION,

    CONSTRAINT chk_appt_status 
        CHECK (status IN ('SCHEDULED','CANCELLED','COMPLETED','NO_SHOW','RESCHEDULED'))
);
GO

CREATE UNIQUE INDEX uq_doctor_slot 
ON clinic.appointments(doctor_id, appointment_date, appointment_time) 
WHERE status IN ('SCHEDULED','RESCHEDULED');
GO

CREATE INDEX ix_appt_patient_date 
ON clinic.appointments(patient_id, appointment_date);
GO


-- Appointment Audit
CREATE TABLE clinic.appointment_audit (
    audit_id        BIGINT IDENTITY(1,1) PRIMARY KEY,
    appointment_id  INT NOT NULL,
    action_type     VARCHAR(30) NOT NULL, 
    old_status      VARCHAR(20) NULL,
    new_status      VARCHAR(20) NULL,
    changed_by      VARCHAR(80) NULL,
    reason          VARCHAR(250) NULL,
    changed_at      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO


-- Visits
CREATE TABLE clinic.visits (
    visit_id         INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id   INT NOT NULL UNIQUE,
    diagnosis        VARCHAR(300) NOT NULL,
    notes            VARCHAR(500) NULL,
    visit_date       DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

    CONSTRAINT fk_visits_appointment 
        FOREIGN KEY(appointment_id) 
        REFERENCES clinic.appointments(appointment_id) 
        ON UPDATE CASCADE 
        ON DELETE CASCADE
);
GO


-- Prescriptions
CREATE TABLE clinic.prescriptions (
    prescription_id  INT IDENTITY(1,1) PRIMARY KEY,
    visit_id         INT NOT NULL,
    medicine_name    VARCHAR(120) NOT NULL,
    dosage           VARCHAR(60) NOT NULL,
    duration_days    INT NOT NULL,
    instructions     VARCHAR(250) NULL,

    CONSTRAINT fk_presc_visit 
        FOREIGN KEY(visit_id) 
        REFERENCES clinic.visits(visit_id) 
        ON UPDATE CASCADE 
        ON DELETE CASCADE
);
GO

CREATE INDEX ix_presc_visit 
ON clinic.prescriptions(visit_id);
GO


-- Bills
CREATE TABLE clinic.bills (
    bill_id         INT IDENTITY(1,1) PRIMARY KEY,
    visit_id        INT NOT NULL UNIQUE,
    bill_date       DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    total_amount    DECIMAL(12,2) NOT NULL DEFAULT 0,
    payment_status  VARCHAR(10) NOT NULL DEFAULT 'UNPAID',
    payment_date    DATETIME2 NULL,
    payment_mode    VARCHAR(20) NULL,

    CONSTRAINT chk_bill_status 
        CHECK (payment_status IN ('PAID','UNPAID')),

    CONSTRAINT fk_bill_visit 
        FOREIGN KEY(visit_id) 
        REFERENCES clinic.visits(visit_id) 
        ON UPDATE CASCADE 
        ON DELETE CASCADE
);
GO


-- Bill Items
CREATE TABLE clinic.bill_items (
    item_id     INT IDENTITY(1,1) PRIMARY KEY,
    bill_id     INT NOT NULL,
    item_name   VARCHAR(120) NOT NULL,
    amount      DECIMAL(12,2) NOT NULL,

    CONSTRAINT fk_billitems_bill 
        FOREIGN KEY(bill_id) 
        REFERENCES clinic.bills(bill_id) 
        ON UPDATE CASCADE 
        ON DELETE CASCADE
);
GO


-- Payment Transactions
CREATE TABLE clinic.payment_transactions (
    payment_id      BIGINT IDENTITY(1,1) PRIMARY KEY,
    bill_id         INT NOT NULL,
    amount_paid     DECIMAL(12,2) NOT NULL,
    payment_mode    VARCHAR(20) NOT NULL,
    paid_at         DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    reference_no    VARCHAR(60) NULL,

    CONSTRAINT fk_pay_bill 
        FOREIGN KEY(bill_id) 
        REFERENCES clinic.bills(bill_id) 
        ON UPDATE CASCADE 
        ON DELETE CASCADE
);
GO

CREATE INDEX ix_bills_status 
ON clinic.bills(payment_status, bill_date);
GO


-- Audit Log
CREATE TABLE clinic.audit_log (
    audit_id        BIGINT IDENTITY(1,1) PRIMARY KEY,
    table_name      VARCHAR(128) NOT NULL,
    action_type     VARCHAR(10) NOT NULL,
    record_pk       VARCHAR(200) NOT NULL,
    changed_at      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    changed_by      VARCHAR(80) NULL DEFAULT SUSER_SNAME(),
    old_data        NVARCHAR(MAX) NULL,
    new_data        NVARCHAR(MAX) NULL
);
GO


CREATE TABLE clinic.insert_history (
    hist_id     BIGINT IDENTITY PRIMARY KEY,
    table_name  VARCHAR(128),
    record_pk   VARCHAR(100),
    inserted_at DATETIME2 DEFAULT SYSUTCDATETIME(),
    inserted_by VARCHAR(80) DEFAULT SUSER_SNAME(),
    row_data    NVARCHAR(MAX)
);
GO


CREATE TABLE clinic.delete_history (
    hist_id     BIGINT IDENTITY PRIMARY KEY,
    table_name  VARCHAR(128),
    record_pk   VARCHAR(100),
    deleted_at  DATETIME2 DEFAULT SYSUTCDATETIME(),
    deleted_by  VARCHAR(80) DEFAULT SUSER_SNAME(),
    row_data    NVARCHAR(MAX)
);
GO
