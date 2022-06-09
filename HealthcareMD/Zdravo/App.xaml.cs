using Controller;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HealthcareMD.Controller;
using HealthcareMD.Repository;
using HealthcareMD.Service;


namespace HealthcareMD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public AppointmentController appointmentController;
        public AllergenController allergenController;
        public PatientController patientController;
        public RoomController roomController;
        public VacationController vacationController;
        public DrugController drugController;
        public IngredientController ingredientController;
        public App()
        {
            
            var allergenRepository = new AllergenRepository();
            var doctorRepository = new DoctorRepository();
            var drugRepository=new DrugRepository();
            var reportRepository = new ReportRepository();
            var equipmentRepository = new EquipmentRepository();
            var patientRepository=new PatientRepository();
            var prescriptionRepository = new PrescriptionRepository();
            var appointmentRepository = new AppointmentRepository(doctorRepository,patientRepository);
            var vacationRepository = new VacationRepository();
            var drugReportRepository = new DrugReportRepository();
            var ingredientRepository = new IngredientRepository();


            var patientService = new PatientService();
            var drugService = new DrugService(drugRepository,drugReportRepository);
            var appointmentService = new AppointmentService(appointmentRepository, drugRepository, prescriptionRepository, reportRepository,patientService);
            var vacationService = new VacationService(vacationRepository,doctorRepository);
            var allergenService = new AllergenService();
            var roomService = new RoomService();
            //var timeService = new TimeService();
            var reportPrescriptionService = new ReportPrescriptionService(reportRepository,patientRepository,prescriptionRepository);
            var ingredientService = new IngredientService(ingredientRepository);

            drugController = new DrugController(drugService);
            patientController = new PatientController();
            appointmentController = new AppointmentController(appointmentService,patientController,doctorRepository,drugController,reportPrescriptionService);
            allergenController = new AllergenController();
            roomController = new RoomController();
            vacationController = new VacationController(vacationService);
            ingredientController = new IngredientController(ingredientService);

            
        }
    }
}
