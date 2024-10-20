namespace ClinicSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB();

            Console.WriteLine("Welcome to the Clinic System!");
            Console.WriteLine();

            while (true)
            {
                ClinicSystem.Run(db);
            }
        }
    }
}