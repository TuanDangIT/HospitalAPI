namespace HospitalAPI.Errors
{
    public class PatientErrors
    {
        //public static readonly Error InvalidFirstName = new Error("invalid-first-name", "Invalid first name");
        //public static readonly Error InvalidLastName = new Error("invalid-last-name", "Invalid last name");
        //public static readonly Error InvalidPesel = new Error("invalid-pesel", "Invalid pesel");
        //public static readonly Error InvalidPhoneNumber = new Error("invalid-phone-number", "Invalid phone number");
        //public static readonly Error InvalidAddress = new Error("invalid-address", "Invalid address");
        public static readonly Error NotFound = new Error("patient-not-found", "Patient not found");
        public static readonly Error CannotInsert = new Error("cannot-insert-data", "Cannot insert a patient");
        public static readonly Error CannotUpdate = new Error("cannot-update-data", "Cannot update a patient");
    }
}
