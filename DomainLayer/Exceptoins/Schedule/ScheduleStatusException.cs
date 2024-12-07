namespace DomainLayer.Exceptoins.Schedule
{
    public class ScheduleStatusException : Exception
    {
        public ScheduleStatusException(int scheduleId)
            : base($"Schedule with ID {scheduleId} is unmodifyed.") { }
    }
        
        
        
    //ScheduleCapacityExceededException: Thrown if the scheduled class exceeds allowed capacity for the room.
        
    //ScheduleStatusException: Ensures only active schedules can be modified or deleted.


}
