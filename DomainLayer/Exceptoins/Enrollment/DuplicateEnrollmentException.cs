namespace DomainLayer.Exceptoins.Enrollment
{
    public class DuplicateEnrollmentException : BadRequestException
    {
        public DuplicateEnrollmentException(string StudentNumber, string CourseCode)
            : base($"Student with Number {StudentNumber} already Assigned in this Course: {CourseCode}.") { }
    }


    //EnrollmentLimitExceededException: Thrown if a student exceeds the maximum number of enrollments allowed per semester.
    //EnrollmentStatusException: Ensures that only active enrollments can be modified or canceled.
}
