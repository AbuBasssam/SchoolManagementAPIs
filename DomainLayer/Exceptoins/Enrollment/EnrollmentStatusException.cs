namespace DomainLayer.Exceptoins.Enrollment
{
    public class EnrollmentStatusException : Exception
    {
        public EnrollmentStatusException()
            : base($"This Enrollment is unmodifyed.") { }
    }
    public class EnrollmentPassedCourseException : BadRequestException
    {
        public EnrollmentPassedCourseException(string StudentNumber, string CourseCode)
            : base($" Student With {StudentNumber} already passed   Course : {CourseCode}.") { }
    }


    //EnrollmentLimitExceededException: Thrown if a student exceeds the maximum number of enrollments allowed per semester.
    //EnrollmentStatusException: Ensures that only active enrollments can be modified or canceled.
}
