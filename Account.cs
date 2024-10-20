namespace ClinicSystem
{
    public interface IAccount
    {
        bool Login(string username, string password);
        bool Logout();
    }
    public class Account : IAccount
    {
        public int Id { get; set; }
        public bool Online { get; set; }
        public string Phone { get; set; }
        public string Shift { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }

        public bool Logout()
        {
            Console.WriteLine("Logging out...");
            LastLoggedIn = DateTime.Now;
            Online = false;
            return true;
        }
    }
}