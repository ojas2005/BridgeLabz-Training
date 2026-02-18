USE HealthClinicDB;
GO

-- 1) PATIENTS
CREATE OR ALTER PROCEDURE clinic.SPPatients_Insert
    @full_name       VARCHAR(100),
    @dob             DATE,
    @phone           VARCHAR(20),
    @email           VARCHAR(150)=NULL,
    @address         VARCHAR(250)=NULL,
    @blood_group     VARCHAR(5)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM clinic.patients WHERE phone = @phone)
        RAISERROR('Phone already exists',16,1);

    IF @email IS NOT NULL AND EXISTS (SELECT 1 FROM clinic.patients WHERE email = @email)
        RAISERROR('Email already exists',16,1);

    INSERT INTO clinic.patients(full_name,dob,phone,email,address,blood_group)
    VALUES(@full_name,@dob,@phone,@email,@address,@blood_group);
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPPatients_Update
    @patient_id      INT,
    @full_name       VARCHAR(100),
    @dob             DATE,
    @phone           VARCHAR(20),
    @email           VARCHAR(150)=NULL,
    @address         VARCHAR(250)=NULL,
    @blood_group     VARCHAR(5)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.patients WHERE patient_id=@patient_id)
        RAISERROR('Patient not found',16,1);

    -- uniqueness checks for update (exclude same patient)
    IF EXISTS (SELECT 1 FROM clinic.patients WHERE phone=@phone AND patient_id<>@patient_id)
        RAISERROR('Phone already exists',16,1);

    IF @email IS NOT NULL AND EXISTS (
        SELECT 1 FROM clinic.patients WHERE email=@email AND patient_id<>@patient_id
    )
        RAISERROR('Email already exists',16,1);

    UPDATE clinic.patients
    SET full_name=@full_name,
        dob=@dob,
        phone=@phone,
        email=@email,
        address=@address,
        blood_group=@blood_group,
        updated_at=SYSUTCDATETIME()
    WHERE patient_id=@patient_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPPatients_Delete
    @patient_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM clinic.appointments WHERE patient_id=@patient_id)
        RAISERROR('Cannot delete patient: appointments exist',16,1);

    DELETE FROM clinic.patients WHERE patient_id=@patient_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPPatients_Search
    @keyword VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM clinic.patients
    WHERE full_name LIKE '%' + @keyword + '%'
       OR phone = @keyword
       OR email = @keyword;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPPatients_Visithistory
    @patient_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.appointment_date,
           a.appointment_time,
           d.doctor_name,
           v.diagnosis,
           v.notes,
           v.visit_date,
           a.status
    FROM clinic.appointments a
    INNER JOIN clinic.doctors d ON a.doctor_id = d.doctor_id
    LEFT JOIN clinic.visits v ON a.appointment_id = v.appointment_id
    WHERE a.patient_id = @patient_id
    ORDER BY a.appointment_date DESC, a.appointment_time DESC;
END;
GO

-- 2) SPECIALTIES
CREATE OR ALTER PROCEDURE clinic.SPSpecialties_Insert
    @specialty_name VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM clinic.specialties WHERE specialty_name=@specialty_name)
        RAISERROR('Specialty already exists',16,1);

    INSERT INTO clinic.specialties(specialty_name)
    VALUES(@specialty_name);
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPSpecialties_Update
    @specialty_id INT,
    @specialty_name VARCHAR(100),
    @is_active BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.specialties WHERE specialty_id=@specialty_id)
        RAISERROR('Specialty not found',16,1);

    IF EXISTS (
        SELECT 1 FROM clinic.specialties
        WHERE specialty_name=@specialty_name AND specialty_id<>@specialty_id
    )
        RAISERROR('Specialty name already used',16,1);

    UPDATE clinic.specialties
    SET specialty_name=@specialty_name,
        is_active=@is_active
    WHERE specialty_id=@specialty_id;
END;
GO

-- UC-6.1: soft delete specialty (block if active doctors exist)
CREATE OR ALTER PROCEDURE clinic.SPSpecialties_Delete
    @specialty_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.specialties WHERE specialty_id=@specialty_id)
        RAISERROR('Specialty not found',16,1);

    IF EXISTS (SELECT 1 FROM clinic.doctors WHERE specialty_id=@specialty_id AND is_active=1)
        RAISERROR('Cannot deactivate specialty: active doctors exist',16,1);

    UPDATE clinic.specialties
    SET is_active=0
    WHERE specialty_id=@specialty_id;
END;
GO

-- 3) DOCTORS
CREATE OR ALTER PROCEDURE clinic.SPDoctors_Insert
    @doctor_name VARCHAR(120),
    @contact VARCHAR(20)=NULL,
    @consultation_fee DECIMAL(10,2),
    @specialty_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.specialties WHERE specialty_id=@specialty_id AND is_active=1)
        RAISERROR('Invalid/Inactive specialty',16,1);

    INSERT INTO clinic.doctors(doctor_name,contact,consultation_fee,specialty_id)
    VALUES(@doctor_name,@contact,@consultation_fee,@specialty_id);
END;
GO

-- Full update (UC-2.2 + profile maintenance)
CREATE OR ALTER PROCEDURE clinic.SPDoctors_Update
    @doctor_id INT,
    @doctor_name VARCHAR(120),
    @contact VARCHAR(20)=NULL,
    @consultation_fee DECIMAL(10,2),
    @specialty_id INT,
    @is_active BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.doctors WHERE doctor_id=@doctor_id)
        RAISERROR('Doctor not found',16,1);

    IF NOT EXISTS (SELECT 1 FROM clinic.specialties WHERE specialty_id=@specialty_id AND is_active=1)
        RAISERROR('Invalid/Inactive specialty',16,1);

    UPDATE clinic.doctors
    SET doctor_name=@doctor_name,
        contact=@contact,
        consultation_fee=@consultation_fee,
        specialty_id=@specialty_id,
        is_active=@is_active,
        updated_at=SYSUTCDATETIME()
    WHERE doctor_id=@doctor_id;
END;
GO

-- Keep your specialty-only update as a convenience
CREATE OR ALTER PROCEDURE clinic.SPDoctors_UpdateSpecialty
    @doctor_id INT,
    @specialty_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.doctors WHERE doctor_id=@doctor_id)
        RAISERROR('Doctor not found',16,1);

    IF NOT EXISTS (SELECT 1 FROM clinic.specialties WHERE specialty_id=@specialty_id AND is_active=1)
        RAISERROR('Invalid/Inactive specialty',16,1);

    UPDATE clinic.doctors
    SET specialty_id=@specialty_id,
        updated_at=SYSUTCDATETIME()
    WHERE doctor_id=@doctor_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPDoctors_BySpecialty
    @specialty_name VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT d.doctor_id,
           d.doctor_name,
           d.consultation_fee,
           d.contact
    FROM clinic.doctors d
    INNER JOIN clinic.specialties s ON d.specialty_id=s.specialty_id
    WHERE s.specialty_name=@specialty_name
      AND d.is_active=1
      AND s.is_active=1
    ORDER BY d.doctor_name;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPDoctors_Deactivate
    @doctor_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.doctors WHERE doctor_id=@doctor_id)
        RAISERROR('Doctor not found',16,1);

    IF EXISTS (
        SELECT 1 FROM clinic.appointments
        WHERE doctor_id=@doctor_id
          AND appointment_date >= CAST(GETDATE() AS DATE)
          AND status IN ('SCHEDULED','RESCHEDULED')
    )
        RAISERROR('Cannot deactivate: doctor has future appointments',16,1);

    UPDATE clinic.doctors
    SET is_active=0,
        updated_at=SYSUTCDATETIME()
    WHERE doctor_id=@doctor_id;
END;
GO

-- 4) APPOINTMENTS
CREATE OR ALTER PROCEDURE clinic.SPAppointments_Book
    @patient_id INT,
    @doctor_id INT,
    @appointment_date DATE,
    @appointment_time TIME(0)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.patients WHERE patient_id=@patient_id)
        RAISERROR('Patient not found',16,1);

    IF NOT EXISTS (SELECT 1 FROM clinic.doctors WHERE doctor_id=@doctor_id AND is_active=1)
        RAISERROR('Doctor not found or inactive',16,1);

    IF EXISTS (
        SELECT 1 FROM clinic.appointments
        WHERE doctor_id=@doctor_id
          AND appointment_date=@appointment_date
          AND appointment_time=@appointment_time
          AND status IN ('SCHEDULED','RESCHEDULED')
    )
        RAISERROR('Slot already booked',16,1);

    INSERT INTO clinic.appointments(patient_id,doctor_id,appointment_date,appointment_time,status)
    VALUES(@patient_id,@doctor_id,@appointment_date,@appointment_time,'SCHEDULED');
END;
GO

-- UC-3.2: availability (slot-wise booking count per time for a doctor/date)
CREATE OR ALTER PROCEDURE clinic.SPAppointments_CheckAvailability
    @doctor_id INT,
    @appointment_date DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT appointment_time,
           COUNT(*) AS booked_count
    FROM clinic.appointments
    WHERE doctor_id=@doctor_id
      AND appointment_date=@appointment_date
      AND status IN ('SCHEDULED','RESCHEDULED')
    GROUP BY appointment_time
    ORDER BY appointment_time;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPAppointments_Cancel
    @appointment_id INT,
    @reason VARCHAR(250)=NULL,
    @changed_by VARCHAR(80)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @old_status VARCHAR(20);

    IF NOT EXISTS (SELECT 1 FROM clinic.appointments WHERE appointment_id=@appointment_id)
        RAISERROR('Appointment not found',16,1);

    SELECT @old_status=status
    FROM clinic.appointments
    WHERE appointment_id=@appointment_id;

    IF @old_status IN ('COMPLETED','CANCELLED')
        RAISERROR('Cannot cancel: already completed/cancelled',16,1);

    BEGIN TRY
        BEGIN TRAN;

        UPDATE clinic.appointments
        SET status='CANCELLED',
            updated_at=SYSUTCDATETIME()
        WHERE appointment_id=@appointment_id;

        INSERT INTO clinic.appointment_audit
            (appointment_id,action_type,old_status,new_status,changed_by,reason)
        VALUES(@appointment_id,'CANCEL',@old_status,'CANCELLED',@changed_by,@reason);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPAppointments_Reschedule
    @appointment_id INT,
    @new_date DATE,
    @new_time TIME(0),
    @new_doctor_id INT = NULL,
    @reason VARCHAR(250)=NULL,
    @changed_by VARCHAR(80)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @doctor_id INT;
    DECLARE @old_status VARCHAR(20);

    IF NOT EXISTS (SELECT 1 FROM clinic.appointments WHERE appointment_id=@appointment_id)
        RAISERROR('Appointment not found',16,1);

    SELECT @doctor_id = doctor_id, @old_status = status
    FROM clinic.appointments
    WHERE appointment_id=@appointment_id;

    IF @old_status IN ('COMPLETED','CANCELLED')
        RAISERROR('Cannot reschedule: already completed/cancelled',16,1);

    IF @new_doctor_id IS NOT NULL
        SET @doctor_id = @new_doctor_id;

    IF NOT EXISTS (SELECT 1 FROM clinic.doctors WHERE doctor_id=@doctor_id AND is_active=1)
        RAISERROR('Doctor not found or inactive',16,1);

    IF EXISTS (
        SELECT 1 FROM clinic.appointments
        WHERE doctor_id=@doctor_id
          AND appointment_date=@new_date
          AND appointment_time=@new_time
          AND status IN ('SCHEDULED','RESCHEDULED')
          AND appointment_id<>@appointment_id
    )
        RAISERROR('Slot conflict',16,1);

    BEGIN TRY
        BEGIN TRAN;

        UPDATE clinic.appointments
        SET doctor_id=@doctor_id,
            appointment_date=@new_date,
            appointment_time=@new_time,
            status='RESCHEDULED',
            updated_at=SYSUTCDATETIME()
        WHERE appointment_id=@appointment_id;

        INSERT INTO clinic.appointment_audit
            (appointment_id,action_type,old_status,new_status,changed_by,reason)
        VALUES(@appointment_id,'RESCHEDULE',@old_status,'RESCHEDULED',@changed_by,@reason);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPAppointments_DailySchedule
    @date DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.appointment_time,
           p.full_name,
           d.doctor_name,
           a.status
    FROM clinic.appointments a
    INNER JOIN clinic.patients p ON a.patient_id=p.patient_id
    INNER JOIN clinic.doctors d ON a.doctor_id=d.doctor_id
    WHERE a.appointment_date=@date
    ORDER BY a.appointment_time;
END;
GO

-- Optional hard delete with safety rules
CREATE OR ALTER PROCEDURE clinic.SPAppointments_Delete
    @appointment_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.appointments WHERE appointment_id=@appointment_id)
        RAISERROR('Appointment not found',16,1);

    IF EXISTS (SELECT 1 FROM clinic.visits WHERE appointment_id=@appointment_id)
        RAISERROR('Cannot delete appointment: visit exists',16,1);

    DECLARE @st VARCHAR(20);
    SELECT @st=status FROM clinic.appointments WHERE appointment_id=@appointment_id;

    IF @st NOT IN ('CANCELLED','NO_SHOW')
        RAISERROR('Hard delete allowed only for CANCELLED/NO_SHOW',16,1);

    DELETE FROM clinic.appointments WHERE appointment_id=@appointment_id;
END;
GO

-- 5) VISITS
CREATE OR ALTER PROCEDURE clinic.SPVisits_Record
    @appointment_id INT,
    @diagnosis VARCHAR(300),
    @notes VARCHAR(500)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.appointments WHERE appointment_id=@appointment_id)
        RAISERROR('Appointment not found',16,1);

    IF EXISTS (SELECT 1 FROM clinic.visits WHERE appointment_id=@appointment_id)
        RAISERROR('Visit already recorded for this appointment',16,1);

    DECLARE @st VARCHAR(20);
    SELECT @st=status FROM clinic.appointments WHERE appointment_id=@appointment_id;

    IF @st IN ('CANCELLED')
        RAISERROR('Cannot record visit for cancelled appointment',16,1);

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO clinic.visits(appointment_id,diagnosis,notes)
        VALUES(@appointment_id,@diagnosis,@notes);

        UPDATE clinic.appointments
        SET status='COMPLETED',
            updated_at=SYSUTCDATETIME()
        WHERE appointment_id=@appointment_id;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPVisits_Update
    @visit_id INT,
    @diagnosis VARCHAR(300),
    @notes VARCHAR(500)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.visits WHERE visit_id=@visit_id)
        RAISERROR('Visit not found',16,1);

    UPDATE clinic.visits
    SET diagnosis=@diagnosis,
        notes=@notes
    WHERE visit_id=@visit_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPVisits_Delete
    @visit_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.visits WHERE visit_id=@visit_id)
        RAISERROR('Visit not found',16,1);

    IF EXISTS (SELECT 1 FROM clinic.bills WHERE visit_id=@visit_id)
        RAISERROR('Cannot delete visit: bill exists',16,1);

    DELETE FROM clinic.visits WHERE visit_id=@visit_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPVisits_MedicalHistory
    @patient_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT v.visit_date,
           d.doctor_name,
           v.diagnosis,
           pr.medicine_name,
           pr.dosage,
           pr.duration_days,
           pr.instructions
    FROM clinic.visits v
    INNER JOIN clinic.appointments a ON v.appointment_id=a.appointment_id
    INNER JOIN clinic.doctors d ON a.doctor_id=d.doctor_id
    LEFT JOIN clinic.prescriptions pr ON v.visit_id=pr.visit_id
    WHERE a.patient_id=@patient_id
    ORDER BY v.visit_date DESC;
END;
GO

-- 6) PRESCRIPTIONS
CREATE OR ALTER PROCEDURE clinic.SPPrescriptions_Insert
    @visit_id INT,
    @medicine_name VARCHAR(120),
    @dosage VARCHAR(60),
    @duration_days INT,
    @instructions VARCHAR(250)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.visits WHERE visit_id=@visit_id)
        RAISERROR('Visit not found',16,1);

    INSERT INTO clinic.prescriptions(visit_id,medicine_name,dosage,duration_days,instructions)
    VALUES(@visit_id,@medicine_name,@dosage,@duration_days,@instructions);
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPPrescriptions_Update
    @prescription_id INT,
    @medicine_name VARCHAR(120),
    @dosage VARCHAR(60),
    @duration_days INT,
    @instructions VARCHAR(250)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.prescriptions WHERE prescription_id=@prescription_id)
        RAISERROR('Prescription not found',16,1);

    UPDATE clinic.prescriptions
    SET medicine_name=@medicine_name,
        dosage=@dosage,
        duration_days=@duration_days,
        instructions=@instructions
    WHERE prescription_id=@prescription_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPPrescriptions_Delete
    @prescription_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.prescriptions WHERE prescription_id=@prescription_id)
        RAISERROR('Prescription not found',16,1);

    DELETE FROM clinic.prescriptions WHERE prescription_id=@prescription_id;
END;
GO

-- 7) BILLING
-- Generate bill + insert consultation fee as item + total via SUM(items)
CREATE OR ALTER PROCEDURE clinic.SPBills_Generate
    @visit_id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.visits WHERE visit_id=@visit_id)
        RAISERROR('Visit not found',16,1);

    IF EXISTS (SELECT 1 FROM clinic.bills WHERE visit_id=@visit_id)
        RAISERROR('Bill already exists for this visit',16,1);

    DECLARE @fee DECIMAL(12,2);

    SELECT @fee = d.consultation_fee
    FROM clinic.visits v
    INNER JOIN clinic.appointments a ON v.appointment_id=a.appointment_id
    INNER JOIN clinic.doctors d ON a.doctor_id=d.doctor_id
    WHERE v.visit_id=@visit_id;

    IF @fee IS NULL
        RAISERROR('Consultation fee not found',16,1);

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO clinic.bills(visit_id,total_amount,payment_status)
        VALUES(@visit_id,0,'UNPAID');

        DECLARE @bill_id INT = SCOPE_IDENTITY();

        INSERT INTO clinic.bill_items(bill_id,item_name,amount)
        VALUES(@bill_id,'Consultation Fee',@fee);

        UPDATE clinic.bills
        SET total_amount = (SELECT SUM(amount) FROM clinic.bill_items WHERE bill_id=@bill_id)
        WHERE bill_id=@bill_id;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPBillItems_Insert
    @bill_id INT,
    @item_name VARCHAR(120),
    @amount DECIMAL(12,2)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clinic.bills WHERE bill_id=@bill_id)
        RAISERROR('Bill not found',16,1);

    INSERT INTO clinic.bill_items(bill_id,item_name,amount)
    VALUES(@bill_id,@item_name,@amount);

    UPDATE clinic.bills
    SET total_amount = (SELECT SUM(amount) FROM clinic.bill_items WHERE bill_id=@bill_id)
    WHERE bill_id=@bill_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPBillItems_Update
    @item_id INT,
    @item_name VARCHAR(120),
    @amount DECIMAL(12,2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @bill_id INT;
    SELECT @bill_id=bill_id FROM clinic.bill_items WHERE item_id=@item_id;

    IF @bill_id IS NULL
        RAISERROR('Bill item not found',16,1);

    UPDATE clinic.bill_items
    SET item_name=@item_name,
        amount=@amount
    WHERE item_id=@item_id;

    UPDATE clinic.bills
    SET total_amount = (SELECT SUM(amount) FROM clinic.bill_items WHERE bill_id=@bill_id)
    WHERE bill_id=@bill_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPBillItems_Delete
    @item_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @bill_id INT;
    SELECT @bill_id=bill_id FROM clinic.bill_items WHERE item_id=@item_id;

    IF @bill_id IS NULL
        RAISERROR('Bill item not found',16,1);

    DELETE FROM clinic.bill_items WHERE item_id=@item_id;

    UPDATE clinic.bills
    SET total_amount = (SELECT SUM(amount) FROM clinic.bill_items WHERE bill_id=@bill_id)
    WHERE bill_id=@bill_id;
END;
GO

CREATE OR ALTER PROCEDURE clinic.SPBills_RecordPayment
    @bill_id INT,
    @amount_paid DECIMAL(12,2),
    @payment_mode VARCHAR(20),
    @reference_no VARCHAR(60)=NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @total DECIMAL(12,2);
    DECLARE @balance DECIMAL(12,2);

    IF NOT EXISTS (SELECT 1 FROM clinic.bills WHERE bill_id=@bill_id)
        RAISERROR('Bill not found',16,1);

    SELECT @total=total_amount FROM clinic.bills WHERE bill_id=@bill_id;
    SET @balance = @total - @amount_paid;

    IF @balance < 0
        RAISERROR('Payment exceeds bill amount',16,1);

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO clinic.payment_transactions(bill_id,amount_paid,payment_mode,reference_no)
        VALUES(@bill_id,@amount_paid,@payment_mode,@reference_no);

        IF @balance = 0
        BEGIN
            UPDATE clinic.bills
            SET payment_status='PAID',
                payment_date=SYSUTCDATETIME(),
                payment_mode=@payment_mode
            WHERE bill_id=@bill_id;
        END

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- 8) AUDIT
CREATE OR ALTER PROCEDURE clinic.SPAudit_View
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 50
           audit_id,
           table_name,
           action_type,
           record_pk,
           changed_at,
           changed_by,
           old_data,
           new_data
    FROM clinic.audit_log
    ORDER BY changed_at DESC;
END;
GO
