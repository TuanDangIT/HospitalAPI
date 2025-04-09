namespace HospitalAPI.Entities
{
    public class Patient
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Pesel { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
