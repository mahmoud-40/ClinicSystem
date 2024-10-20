namespace ClinicSystem
{
    public interface IDoctor
    {
        void AddAssistant(Assistant assistant);
        void RemoveAssistant(int assistantId);
        void GetSchedule();
    }

    public class Doctor : Account, IDoctor
    {
        private DB db;

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool FullAuth { get; set; } = true;

        public void AddAssistant(Assistant assistant)
        {
            if (db != null && db.AssistantList != null)
            {
                if (db.Insert(assistant))
                {
                    Console.WriteLine("Assistant added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add assistant. It might already exist.");
                }
            }
            else
            {
                Console.WriteLine("Database or Assistant list is not initialized.");
            }
        }

        public void RemoveAssistant(int assistantId)
        {
            var assistant = db.AssistantList.FirstOrDefault(a => a.Id == assistantId);
            if (assistant != null)
            {
                db.AssistantList.Remove(assistant);
                Console.WriteLine("Assistant removed successfully.");
            }
            else
            {
                Console.WriteLine("Assistant not found.");
            }
        }


        public void GetSchedule()
        {
            Console.WriteLine("Doctor's Schedule:");
            foreach (var appointment in Appointments)
            {
                Console.WriteLine($"Date: {appointment.Date.ToShortDateString()}, Time: {appointment.Time}, Customer: {appointment.Customer.Name}, Status: {appointment.Status}");
            }
        }
    }
}