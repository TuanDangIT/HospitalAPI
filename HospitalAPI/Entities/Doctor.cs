namespace HospitalAPI.Entities
{
    public class Doctor
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Pesel { get; set; } = default!;
        public DateTime DateOfHire { get; set; } 
        public List<Number> PhoneNumbers { get; set; } = new List<Number>();
    }
}
