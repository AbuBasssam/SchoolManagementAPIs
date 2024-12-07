namespace DomainLayer.Exceptoins.Schedule
{
    public class ScheduleNotFoundException : EntityNotFoundException
    {
        public ScheduleNotFoundException(int scheduleId)
            : base($"Schedule with ID {scheduleId} is not found.") { }
    }
//ScheduleConflictException: Raised if a new schedule conflicts with an existing one for the same classroom, teacher, or student.
//InvalidScheduleTimeException: Ensures scheduled times fall within allowable hours (e.g., during school hours).
//ScheduleCapacityExceededException: Thrown if the scheduled class exceeds allowed capacity for the room.
//ScheduleStatusException: Ensures only active schedules can be modified or deleted.


}
