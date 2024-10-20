namespace ClinicSystem
{
    public static class AssistantMenu
    {
        public static void Show(Assistant assistant, DB db)
        {
            while (true)
            {
                Console.WriteLine("\nAssistant Menu:");
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Add Appointment");
                Console.WriteLine("3. Change Appointment Date");
                Console.WriteLine("4. Change Appointment Status");
                Console.WriteLine("5. Remove Appointment");
                Console.WriteLine("6. View Appointments");
                Console.WriteLine("7. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewCustomer(assistant);
                        break;
                    case "2":
                        AddAppointment(assistant, db);
                        break;
                    case "3":
                        ChangeAppointment(assistant);
                        break;
                    case "4":
                        ChangeAppointmentStatus(assistant);
                        break;
                    case "5":
                        DeleteAppointment(assistant);
                        break;
                    case "6":
                        ViewAppointments(assistant);
                        break;
                    case "7":
                        assistant.Logout();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddNewCustomer(Assistant assistant)
        {
            Console.Write("Enter customer's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter customer's address: ");
            string address = Console.ReadLine();

            Console.Write("Enter customer's age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Console.Write("Enter customer's gender: ");
                string gender = Console.ReadLine();

                assistant.AddNewCustomer(name, address, age, gender);
                Console.WriteLine("Customer added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid age format.");
            }
        }

        static void AddAppointment(Assistant assistant, DB db)
        {
            Console.Write("Enter appointment date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.Write("Enter appointment time: ");
                string time = Console.ReadLine();

                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();

                var customer = db.CustomerList.FirstOrDefault(c => c.Name == name);
                var doctor = db.DoctorList.FirstOrDefault();
                if (customer != null && doctor != null)
                {
                    bool isAdded = assistant.AddAppointment(date, time, customer, doctor);
                    Console.WriteLine(isAdded ? "Appointment added successfully." : "Appointment time is not available.");
                }
                else
                {
                    Console.WriteLine("Customer or doctor not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        static void ChangeAppointment(Assistant assistant)
        {
            Console.Write("Enter appointment date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.Write("Enter appointment time: ");
                string time = Console.ReadLine();

                Console.Write("Enter new date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                {
                    if (assistant.ChangeAppointment(date, time, newDate))
                    {
                        Console.WriteLine("Appointment changed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Appointment not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid new date format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        static void DeleteAppointment(Assistant assistant)
        {
            Console.Write("Enter appointment date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.Write("Enter appointment time: ");
                string time = Console.ReadLine();

                assistant.DeleteAppointment(date, time);
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        static void ViewAppointments(Assistant assistant)
        {
            Console.WriteLine("Appointments:");
            foreach (var appointment in assistant.Appointments)
            {
                Console.WriteLine($"{appointment.Date.ToShortDateString()} at {appointment.Time} with {appointment.Customer.Name}");
            }
        }

        static void ChangeAppointmentStatus(Assistant assistant)
        {
            Console.Write("Enter appointment date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.Write("Enter appointment time: ");
                string time = Console.ReadLine();
                Console.Write("Enter new status: ");
                string status = Console.ReadLine();

                assistant.ChangeAppointmentStatus(date, time, status);
                Console.WriteLine("Appointment status changed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }
    }
}
