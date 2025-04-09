namespace HospitalAPI.Entities
{
    public class Visit
    {
        public string PatientFullName { get; set; } = default!;
        public string DoctorFullName { get; set; } = default!;
        public int Price { get; set; }
        public string TypeOfVisit { get; set; } = default!;
        public string AdditionalInformation { get; set; } = default!;
    }
}
