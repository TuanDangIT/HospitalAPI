namespace HospitalAPI.Errors
{
    public class DoctorErrors
    {
        public static readonly Error NotFound = new Error("doctor-not-found", "Doctor not found");
        public static readonly Error CannotInsert = new Error("cannot-insert-data", "Cannot insert a doctor");
        public static readonly Error CannotUpdate = new Error("cannot-update-data", "Cannot update a doctor");
    }
}
