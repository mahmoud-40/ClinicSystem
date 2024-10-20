namespace ClinicSystem
{
    public interface IAppointment
    {
        bool AppointmentDoctorAvailable(DateTime date, string time);
        bool TimeAvailable(DateTime date, string time);
    }
    public class Appointment : IAppointment
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Customer Customer { get; set; }
        public Assistant Assistant { get; set; }
        public Doctor Doctor { get; set; }
        public string Status { get; set; } = "Scheduled";
        public double TotalPrice { get; set; }

        public bool AppointmentDoctorAvailable(DateTime date, string time)
        {
            return !Doctor.Appointments.Any(a => a.Date.Date == date.Date && a.Time == time);
        }

        public bool TimeAvailable(DateTime date, string time)
        {
            return !Assistant.Appointments.Any(a => a.Date.Date == date.Date && a.Time == time);
        }
    }
}