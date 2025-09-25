namespace Hospital.Data.AppRouting
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "v1";
        public const string Rule = root + "/" + version;
        public static class PatientRouting
        {
            public const string GetAll = Rule + "/Patient/GetAll";
            public const string GetById = Rule + "/Patient/GetById/{id}";
            public const string Create = Rule + "/Patient/Create";
            public const string Update = Rule + "/Patient/Update";
            public const string Delete = Rule + "/Patient/Delete/{id}";
            public const string Paginated = Rule + "/Patient/Paginated";
        }
        public static class DoctorRouting
        {
            public const string GetAll = Rule + "/Doctor/GetAll";
            public const string GetById = Rule + "/Doctor/GetById/{id}";
            public const string Create = Rule + "/Doctor/Create";
            public const string Update = Rule + "/Doctor/Update";
            public const string Delete = Rule + "/Doctor/Delete/{Id}";
            public const string Paginated = Rule + "/Doctor/Paginated";

        }
        public static class AppointmentRouting
        {
            public const string GetAll = Rule + "/Appointment/GetAll";
            public const string GetById = Rule + "/Appointment/GetById/{id}";
            public const string Update = Rule + "/Appointment/Update";
            public const string GetByPatientId = Rule + "/Appointment/Patient/{patientId}";
            public const string GetByDoctorId = Rule + "/Appointment/Doctor/{doctorId}";
            public const string GetTodayAppointments = Rule + "/Appointment/Today";
            public const string CheckDoctorAvailability = Rule + "/Appointment/Doctor/{doctorId}/Available";
        }
        public static class MedicalRecordRouting
        {
            public const string GetAll = Rule + "/MedicalRecord/GetAll";
            public const string GetById = Rule + "/MedicalRecord/GetById/{id}";
            public const string Create = Rule + "/MedicalRecord/Create";
            public const string Update = Rule + "/MedicalRecord/Update";
            public const string Delete = Rule + "/MedicalRecord/Delete/{Id}";
            public const string GetByPatientId = Rule + "/MedicalRecord/Patient/{patientId}";
        }
        public static class AccountRouting
        {
            public const string Register = Rule + "/Account/Register";
            public const string Login = Rule + "/Account/Login";

        }

    }
}
