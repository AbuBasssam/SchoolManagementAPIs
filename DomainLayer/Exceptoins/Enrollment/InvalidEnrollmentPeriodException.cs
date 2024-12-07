namespace DomainLayer.Exceptoins.Enrollment
{
    public class InvalidEnrollmentPeriodException : Exception
    {
        public InvalidEnrollmentPeriodException()
            : base($"is not allow to enrolle Courses for now.") { }
    }


    //EnrollmentLimitExceededException: Thrown if a student exceeds the maximum number of enrollments allowed per semester.
    //EnrollmentStatusException: Ensures that only active enrollments can be modified or canceled.
}
