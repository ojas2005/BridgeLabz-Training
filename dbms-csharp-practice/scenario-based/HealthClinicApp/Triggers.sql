USE HealthClinicDB;
GO


-- PATIENTS audit
CREATE OR ALTER TRIGGER clinic.TR_Patients_Audit
ON clinic.patients
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Track inserts
    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.patients', 'INSERT', CAST(i.patient_id AS VARCHAR(200)), NULL,
        (SELECT i.patient_id, i.full_name, i.dob, i.phone, i.email, i.address, i.blood_group, 
                i.created_at, i.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i
    LEFT JOIN deleted d ON d.patient_id = i.patient_id
    WHERE d.patient_id IS NULL;

    -- Track deletes
    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.patients', 'DELETE', CAST(d.patient_id AS VARCHAR(200)),
        (SELECT d.patient_id, d.full_name, d.dob, d.phone, d.email, d.address, d.blood_group, 
                d.created_at, d.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d
    LEFT JOIN inserted i ON i.patient_id = d.patient_id
    WHERE i.patient_id IS NULL;

    -- Track updates
    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.patients', 'UPDATE', CAST(i.patient_id AS VARCHAR(200)),
        (SELECT d.patient_id, d.full_name, d.dob, d.phone, d.email, d.address, d.blood_group, 
                d.created_at, d.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.patient_id, i.full_name, i.dob, i.phone, i.email, i.address, i.blood_group, 
                i.created_at, i.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i
    INNER JOIN deleted d ON d.patient_id = i.patient_id;
END;
GO

-- SPECIALTIES audit
CREATE OR ALTER TRIGGER clinic.TR_Specialties_Audit
ON clinic.specialties
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.specialties', 'INSERT', CAST(i.specialty_id AS VARCHAR(200)), NULL,
        (SELECT i.specialty_id, i.specialty_name, i.is_active, i.created_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.specialty_id = i.specialty_id WHERE d.specialty_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.specialties', 'DELETE', CAST(d.specialty_id AS VARCHAR(200)),
        (SELECT d.specialty_id, d.specialty_name, d.is_active, d.created_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.specialty_id = d.specialty_id WHERE i.specialty_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.specialties', 'UPDATE', CAST(i.specialty_id AS VARCHAR(200)),
        (SELECT d.specialty_id, d.specialty_name, d.is_active, d.created_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.specialty_id, i.specialty_name, i.is_active, i.created_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.specialty_id = i.specialty_id;
END;
GO

-- DOCTORS audit
CREATE OR ALTER TRIGGER clinic.TR_Doctors_Audit
ON clinic.doctors
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.doctors', 'INSERT', CAST(i.doctor_id AS VARCHAR(200)), NULL,
        (SELECT i.doctor_id, i.doctor_name, i.contact, i.consultation_fee, i.specialty_id, 
                i.is_active, i.created_at, i.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.doctor_id = i.doctor_id WHERE d.doctor_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.doctors', 'DELETE', CAST(d.doctor_id AS VARCHAR(200)),
        (SELECT d.doctor_id, d.doctor_name, d.contact, d.consultation_fee, d.specialty_id, 
                d.is_active, d.created_at, d.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.doctor_id = d.doctor_id WHERE i.doctor_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.doctors', 'UPDATE', CAST(i.doctor_id AS VARCHAR(200)),
        (SELECT d.doctor_id, d.doctor_name, d.contact, d.consultation_fee, d.specialty_id, 
                d.is_active, d.created_at, d.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.doctor_id, i.doctor_name, i.contact, i.consultation_fee, i.specialty_id, 
                i.is_active, i.created_at, i.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.doctor_id = i.doctor_id;
END;
GO

-- APPOINTMENTS audit
CREATE OR ALTER TRIGGER clinic.TR_Appointments_Audit
ON clinic.appointments
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.appointments', 'INSERT', CAST(i.appointment_id AS VARCHAR(200)), NULL,
        (SELECT i.appointment_id, i.patient_id, i.doctor_id, i.appointment_date, i.appointment_time, 
                i.status, i.created_at, i.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.appointment_id = i.appointment_id WHERE d.appointment_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.appointments', 'DELETE', CAST(d.appointment_id AS VARCHAR(200)),
        (SELECT d.appointment_id, d.patient_id, d.doctor_id, d.appointment_date, d.appointment_time, 
                d.status, d.created_at, d.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.appointment_id = d.appointment_id WHERE i.appointment_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.appointments', 'UPDATE', CAST(i.appointment_id AS VARCHAR(200)),
        (SELECT d.appointment_id, d.patient_id, d.doctor_id, d.appointment_date, d.appointment_time, 
                d.status, d.created_at, d.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.appointment_id, i.patient_id, i.doctor_id, i.appointment_date, i.appointment_time, 
                i.status, i.created_at, i.updated_at FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.appointment_id = i.appointment_id;
END;
GO

-- VISITS audit
CREATE OR ALTER TRIGGER clinic.TR_Visits_Audit
ON clinic.visits
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.visits', 'INSERT', CAST(i.visit_id AS VARCHAR(200)), NULL,
        (SELECT i.visit_id, i.appointment_id, i.diagnosis, i.notes, i.visit_date FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.visit_id = i.visit_id WHERE d.visit_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.visits', 'DELETE', CAST(d.visit_id AS VARCHAR(200)),
        (SELECT d.visit_id, d.appointment_id, d.diagnosis, d.notes, d.visit_date FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.visit_id = d.visit_id WHERE i.visit_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.visits', 'UPDATE', CAST(i.visit_id AS VARCHAR(200)),
        (SELECT d.visit_id, d.appointment_id, d.diagnosis, d.notes, d.visit_date FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.visit_id, i.appointment_id, i.diagnosis, i.notes, i.visit_date FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.visit_id = i.visit_id;
END;
GO

-- PRESCRIPTIONS audit
CREATE OR ALTER TRIGGER clinic.TR_Prescriptions_Audit
ON clinic.prescriptions
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.prescriptions', 'INSERT', CAST(i.prescription_id AS VARCHAR(200)), NULL,
        (SELECT i.prescription_id, i.visit_id, i.medicine_name, i.dosage, i.duration_days, i.instructions 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.prescription_id = i.prescription_id WHERE d.prescription_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.prescriptions', 'DELETE', CAST(d.prescription_id AS VARCHAR(200)),
        (SELECT d.prescription_id, d.visit_id, d.medicine_name, d.dosage, d.duration_days, d.instructions 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.prescription_id = d.prescription_id WHERE i.prescription_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.prescriptions', 'UPDATE', CAST(i.prescription_id AS VARCHAR(200)),
        (SELECT d.prescription_id, d.visit_id, d.medicine_name, d.dosage, d.duration_days, d.instructions 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.prescription_id, i.visit_id, i.medicine_name, i.dosage, i.duration_days, i.instructions 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.prescription_id = i.prescription_id;
END;
GO

-- BILLS audit
CREATE OR ALTER TRIGGER clinic.TR_Bills_Audit
ON clinic.bills
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.bills', 'INSERT', CAST(i.bill_id AS VARCHAR(200)), NULL,
        (SELECT i.bill_id, i.visit_id, i.bill_date, i.total_amount, i.payment_status, 
                i.payment_date, i.payment_mode FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.bill_id = i.bill_id WHERE d.bill_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.bills', 'DELETE', CAST(d.bill_id AS VARCHAR(200)),
        (SELECT d.bill_id, d.visit_id, d.bill_date, d.total_amount, d.payment_status, 
                d.payment_date, d.payment_mode FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.bill_id = d.bill_id WHERE i.bill_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.bills', 'UPDATE', CAST(i.bill_id AS VARCHAR(200)),
        (SELECT d.bill_id, d.visit_id, d.bill_date, d.total_amount, d.payment_status, 
                d.payment_date, d.payment_mode FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.bill_id, i.visit_id, i.bill_date, i.total_amount, i.payment_status, 
                i.payment_date, i.payment_mode FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.bill_id = i.bill_id;
END;
GO

-- BILL ITEMS audit
CREATE OR ALTER TRIGGER clinic.TR_BillItems_Audit
ON clinic.bill_items
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.bill_items', 'INSERT', CAST(i.item_id AS VARCHAR(200)), NULL,
        (SELECT i.item_id, i.bill_id, i.item_name, i.amount FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.item_id = i.item_id WHERE d.item_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.bill_items', 'DELETE', CAST(d.item_id AS VARCHAR(200)),
        (SELECT d.item_id, d.bill_id, d.item_name, d.amount FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.item_id = d.item_id WHERE i.item_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.bill_items', 'UPDATE', CAST(i.item_id AS VARCHAR(200)),
        (SELECT d.item_id, d.bill_id, d.item_name, d.amount FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.item_id, i.bill_id, i.item_name, i.amount FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.item_id = i.item_id;
END;
GO

-- PAYMENT TRANSACTIONS audit
CREATE OR ALTER TRIGGER clinic.TR_PaymentTransactions_Audit
ON clinic.payment_transactions
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.payment_transactions', 'INSERT', CAST(i.payment_id AS VARCHAR(200)), NULL,
        (SELECT i.payment_id, i.bill_id, i.amount_paid, i.payment_mode, i.paid_at, i.reference_no 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i LEFT JOIN deleted d ON d.payment_id = i.payment_id WHERE d.payment_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.payment_transactions', 'DELETE', CAST(d.payment_id AS VARCHAR(200)),
        (SELECT d.payment_id, d.bill_id, d.amount_paid, d.payment_mode, d.paid_at, d.reference_no 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), NULL,
        SUSER_SNAME()
    FROM deleted d LEFT JOIN inserted i ON i.payment_id = d.payment_id WHERE i.payment_id IS NULL;

    INSERT INTO clinic.audit_log(table_name, action_type, record_pk, old_data, new_data, changed_by)
    SELECT 'clinic.payment_transactions', 'UPDATE', CAST(i.payment_id AS VARCHAR(200)),
        (SELECT d.payment_id, d.bill_id, d.amount_paid, d.payment_mode, d.paid_at, d.reference_no 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.payment_id, i.bill_id, i.amount_paid, i.payment_mode, i.paid_at, i.reference_no 
         FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SUSER_SNAME()
    FROM inserted i INNER JOIN deleted d ON d.payment_id = i.payment_id;
END;
GO

-- =====================================================
-- SECTION 2: BUSINESS TRIGGERS
-- Maintain data integrity and computed values
-- =====================================================

-- Auto-sync bill total when items change
-- Recalculates bill.total_amount based on sum of bill_items
CREATE OR ALTER TRIGGER clinic.TR_BillItems_RecalcTotal
ON clinic.bill_items
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH affected_bills AS (
        SELECT bill_id FROM inserted
        UNION
        SELECT bill_id FROM deleted
    )
    UPDATE b
    SET total_amount = ISNULL(x.total_sum, 0)
    FROM clinic.bills b
    INNER JOIN affected_bills ab ON ab.bill_id = b.bill_id
    OUTER APPLY (
        SELECT SUM(bi.amount) AS total_sum
        FROM clinic.bill_items bi
        WHERE bi.bill_id = b.bill_id
    ) x;
END;
GO
