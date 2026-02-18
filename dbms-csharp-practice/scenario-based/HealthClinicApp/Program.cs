//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using HealthClinic.Menu;
using HealthClinic.UserSecurity;
using HealthClinic.Utility;


// Utilities
var patientUtil = new PatientUtility();
var apptUtil = new AppointmentUtility();
var billUtil = new BillingUtility();
var specUtil = new SpecialtyUtility();
var doctorUtil = new DoctorUtility();
var visitUtil = new VisitUtility();
var rxUtil = new PrescriptionUtility();
var auditUtil = new AuditUtility();

// Sub menus
var patientMenu = new PatientMenu(patientUtil);
var appointmentMenu = new AppointmentMenu(apptUtil);
var billingMenu = new BillingMenu(billUtil);
var specialtyMenu = new SpecialtyMenu(specUtil);
var doctorMgmtMenu = new DoctorManagementMenu(doctorUtil);
var auditMenu = new AuditMenu(auditUtil);
var visitRxMenu = new VisitPrescriptionMenu(visitUtil, rxUtil);

// Role menus
var receptionistMenu = new ReceptionistMenu(patientMenu, appointmentMenu, billingMenu);
var doctorMenu = new DoctorMenu(appointmentMenu, visitRxMenu);
var adminMenu = new AdminMenu(specialtyMenu, doctorMgmtMenu, auditMenu, billingMenu);

// Auth + App menu
var auth = new AuthService();
var appMenu = new AppMenu(auth, receptionistMenu, doctorMenu, adminMenu);

appMenu.Start();
