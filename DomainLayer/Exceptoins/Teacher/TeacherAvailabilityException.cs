namespace DomainLayer.Exceptoins.Teacher
{
    public class TeacherAvailabilityException : Exception
    {
        public TeacherAvailabilityException(int TeacherID,int ScheduleID) : base($"Tecaher with ID {TeacherID} unavailabel for this Schedule {ScheduleID}.") { }
    }
}
//DuplicateTeacherAssignmentException: Thrown if a teacher is assigned to a course or class multiple times unintentionally.