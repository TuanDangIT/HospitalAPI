namespace HospitalAPI.Errors
{
    public class VisitErrors
    {
        public static readonly Error NotFound = new Error("visit-not-found", "Visit not found");
        public static readonly Error CannotInsert = new Error("cannot-insert-data", "Cannot insert a visit");
        public static readonly Error CannotUpdate = new Error("cannot-update-data", "Cannot update a visit");
    }
}
