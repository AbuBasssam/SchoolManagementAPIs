namespace DomainLayer.Exceptoins.Schedule
{
    public class InvalidScheduleDayException : Exception
    {
        public InvalidScheduleDayException(): base("Invalid Schedule Day .") { }
    }


    //InvalidScheduleTimeException: Ensures scheduled times fall within allowable hours (e.g., during school hours).

    //ScheduleCapacityExceededException: Thrown if the scheduled class exceeds allowed capacity for the room.

    //ScheduleStatusException: Ensures only active schedules can be modified or deleted.


}
