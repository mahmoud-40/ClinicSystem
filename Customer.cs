namespace ClinicSystem
{
    public interface ICustomer { }
    public class Customer : ICustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string History { get; set; }
    }

}