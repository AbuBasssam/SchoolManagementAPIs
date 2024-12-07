using DomainLayer.Entities;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DomainLayer.Exceptoins.Enrollment
{
    public class EnrollmentLimitExceededException : Exception
    {
        public EnrollmentLimitExceededException(int studentId)
            : base($"Student with ID {studentId} has exceeded the maximum allowed enrollments.") { }
    }


}
