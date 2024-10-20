namespace ClinicSystem
{
    public interface IDB
    {
        bool Insert<T>(T item) where T : class;
        bool Update<T>(T item) where T : class;
        void Delete(int id);
        Appointment Select(List<Appointment> list);
    }

    public class DB : IDB
    {
        public List<Appointment> AppointmentList { get; set; } = new List<Appointment>();
        public List<Customer> CustomerList { get; set; } = new List<Customer>();
        public List<Assistant> AssistantList { get; set; } = new List<Assistant>();
        public List<Doctor> DoctorList { get; set; } = new List<Doctor>();
        public List<Account> AccountList { get; set; } = new List<Account>();

        public DB()
        {
            Doctor doctor = new Doctor { Username = "doc", Password = "doc", Phone = "1234567890", Shift = "Morning", Id = 1 };
            Assistant assistant = new Assistant { Username = "mahmoud", Password = "2004", Phone = "0987654321", Shift = "Morning", Id = 1 };

            AccountList.Add(doctor);
            AccountList.Add(assistant);
            DoctorList.Add(doctor);
            AssistantList.Add(assistant);
        }

        public bool Insert<T>(T item) where T : class
        {
            switch (item)
            {
                case Appointment appointment:
                    AppointmentList.Add(appointment);
                    return true;
                case Customer customer:
                    CustomerList.Add(customer);
                    return true;
                case Assistant assistant:
                    AssistantList.Add(assistant);
                    AccountList.Add(assistant);
                    return true;
                case Doctor doctor:
                    DoctorList.Add(doctor);
                    AccountList.Add(doctor);
                    return true;
                default:
                    return false;
            }
        }

        public bool Update<T>(T item) where T : class
        {
            switch (item)
            {
                case Appointment appointment:
                    var _appointment = AppointmentList.FirstOrDefault(a => a.Date == appointment.Date && a.Time == appointment.Time && a.Customer.Name == appointment.Customer.Name);
                    if (_appointment != null)
                    {
                        _appointment.Status = appointment.Status;
                        _appointment.TotalPrice = appointment.TotalPrice;
                        return true;
                    }
                    break;
                case Customer customer:
                    var _customer = CustomerList.FirstOrDefault(c => c.Name == customer.Name);
                    if (_customer != null)
                    {
                        _customer.Address = customer.Address;
                        _customer.Age = customer.Age;
                        _customer.Gender = customer.Gender;
                        _customer.History = customer.History;
                        return true;
                    }
                    break;
                case Assistant assistant:
                    var _assistant = AssistantList.FirstOrDefault(a => a.Username == assistant.Username);
                    if (_assistant != null)
                    {
                        _assistant.Phone = assistant.Phone;
                        _assistant.Shift = assistant.Shift;
                        _assistant.FullAuth = assistant.FullAuth;
                        return true;
                    }
                    break;
                case Doctor doctor:
                    var _doctor = DoctorList.FirstOrDefault(d => d.Username == doctor.Username);
                    if (_doctor != null)
                    {
                        _doctor.Phone = doctor.Phone;
                        _doctor.Shift = doctor.Shift;
                        _doctor.FullAuth = doctor.FullAuth;
                        return true;
                    }
                    break;
                default:
                    return false;
            }
            return false;
        }

        public void Delete(int id)
        {
            var assistant = AssistantList.FirstOrDefault(a => a.Id == id);

            if (assistant != null)
            {
                AssistantList.Remove(assistant);
                Console.WriteLine($"Assistant with ID {id} has been successfully deleted.");
            }
            else
            {
                Console.WriteLine($"No assistant found with ID {id}.");
            }
        }

        public Appointment Select(List<Appointment> list)
        {
            return list.FirstOrDefault();
        }
    }
}