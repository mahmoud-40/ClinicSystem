namespace ClinicSystem
{
    public static class ClinicSystem
    {
        public static void Run(DB db)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Login as a Doctor");
            Console.WriteLine("2. Login as an Assistant");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UserLogin(db, UserType.Doctor);
                    break;
                case "2":
                    UserLogin(db, UserType.Assistant);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void UserLogin(DB db, UserType userType)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (userType == UserType.Doctor)
            {
                var doctor = db.DoctorList.FirstOrDefault(d => d.Login(username, password));
                if (doctor != null)
                {
                    Console.WriteLine("Login successful.");
                    DoctorMenu.Show(doctor, db);
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
            else
            {
                var assistant = db.AssistantList.FirstOrDefault(a => a.Login(username, password));
                if (assistant != null)
                {
                    Console.WriteLine("Login successful.");
                    assistant.SetDatabase(db);
                    AssistantMenu.Show(assistant, db);
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
        }
    }
    public enum UserType
    {
        Doctor,
        Assistant
    }
}
