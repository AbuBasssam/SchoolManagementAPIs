namespace DomainLayer.Exceptoins.Schedule
{
    public class InvalidScheduleTimeException : Exception
    {
        public InvalidScheduleTimeException(int scheduleId, DateTime startTime)
            : base($"Schedule with ID {scheduleId}have invalid schedule time at {startTime}.") { }
    }


    //InvalidScheduleTimeException: Ensures scheduled times fall within allowable hours (e.g., during school hours).

    //ScheduleCapacityExceededException: Thrown if the scheduled class exceeds allowed capacity for the room.

    //ScheduleStatusException: Ensures only active schedules can be modified or deleted.


}
