namespace DomainLayer.Exceptoins.Enrollment
{
    public class EnrollmentNotFoundException : EntityNotFoundException
    {
        public EnrollmentNotFoundException(int EnrollmentId)
            : base($"Enrollment with ID {EnrollmentId} not found.") { }
    }


    //EnrollmentLimitExceededException: Thrown if a student exceeds the maximum number of enrollments allowed per semester.
    //EnrollmentStatusException: Ensures that only active enrollments can be modified or canceled.
}
