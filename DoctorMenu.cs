namespace ClinicSystem
{
    public static class DoctorMenu
    {
        public static void Show(Doctor doctor, DB db)
        {
            while (true)
            {
                Console.WriteLine("\nDoctor Menu:");
                Console.WriteLine("1. View Schedule");
                Console.WriteLine("2. Add New Assistant");
                Console.WriteLine("3. Remove Assistant");
                Console.WriteLine("4. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        doctor.GetSchedule();
                        break;
                    case "2":
                        AddNewAssistant(doctor, db);
                        break;
                    case "3":
                        RemoveAssistant(db);
                        break;
                    case "4":
                        doctor.Logout();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddNewAssistant(Doctor doctor, DB db)
        {
            Console.Write("Enter assistant's username: ");
            string username = Console.ReadLine();
            Console.Write("Enter assistant's password: ");
            string password = Console.ReadLine();
            Assistant assistant = new Assistant { Username = username, Password = password };
            doctor.AddAssistant(assistant);
            db.AssistantList.Add(assistant);
            Console.WriteLine("Assistant added successfully.");
        }

        static void RemoveAssistant(DB db)
        {
            Console.Write("Enter the ID of the assistant to remove: ");
            foreach (var assistant in db.AssistantList)
            {
                Console.WriteLine($"ID: {assistant.Id}, Username: {assistant.Username}");
            }

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                db.Delete(id);
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
    }
}
