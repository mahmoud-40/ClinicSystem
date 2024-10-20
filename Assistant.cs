namespace ClinicSystem
{
    public interface IAssistant
    {
        void AddNewCustomer(string name, string address, int age, string gender);
        bool AddToWaitingList(Customer customer);
        bool AddAppointment(DateTime date, string time, Customer customer, Doctor doctor);
        bool TimeAvailable(DateTime date, string time);
        void DeleteAppointment(DateTime date, string time);
        bool ChangeAppointment(DateTime date, string time, DateTime newDate);
        void ChangeAppointmentStatus(DateTime date, string time, string status);
    }
    public class Assistant : Account, IAssistant
    {
        private DB db;

        public List<Customer> WaitingList { get; set; } = new List<Customer>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool FullAuth { get; set; } = false;

        public void SetDatabase(DB database)
        {
            db = database;
        }

        public void AddNewCustomer(string name, string address, int age, string gender)
        {
            Customer customer = new Customer { Name = name, Address = address, Age = age, Gender = gender };
            WaitingList.Add(customer);
            db.CustomerList.Add(customer);
        }

        public bool AddToWaitingList(Customer customer)
        {
            WaitingList.Add(customer);
            return true;
        }

        public bool AddAppointment(DateTime date, string time, Customer customer, Doctor doctor)
        {
            if (TimeAvailable(date, time))
            {
                Appointment appointment = new Appointment
                {
                    Date = date,
                    Time = time,
                    Customer = customer,
                    Assistant = this,
                    Doctor = doctor,
                    Status = "Scheduled"
                };

                Appointments.Add(appointment);

                if (doctor.Appointments != null)
                {
                    doctor.Appointments.Add(appointment);
                }

                return true;
            }
            return false;
        }


        public bool TimeAvailable(DateTime date, string time)
        {
            return !Appointments.Any(a => a.Date.Date == date.Date && a.Time == time);
        }

        public void DeleteAppointment(DateTime date, string time)
        {
            var appointment = Appointments.FirstOrDefault(a => a.Date.Date == date.Date && a.Time == time);
            if (appointment != null)
            {
                Appointments.Remove(appointment);
                Console.WriteLine("Appointment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        public bool ChangeAppointment(DateTime date, string time, DateTime newDate)
        {
            var appointment = Appointments.FirstOrDefault(a => a.Date == date && a.Time == time);
            if (appointment != null)
            {
                appointment.Date = newDate;
                return true;
            }
            return false;
        }


        public void ChangeAppointmentStatus(DateTime date, string time, string status)
        {
            var appointment = Appointments.FirstOrDefault(a => a.Date.Date == date.Date && a.Time == time);
            if (appointment != null)
            {
                appointment.Status = status;
                Console.WriteLine("Appointment status changed successfully.");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }
    }
}