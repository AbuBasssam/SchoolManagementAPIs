namespace DomainLayer.Exceptoins.Schedule
{
    public class ScheduleConflictException : BadRequestException
    {
        public ScheduleConflictException(int scheduleId, DateTime startTime)
            : base($"Schedule with ID {scheduleId} conflicts with another schedule starting at {startTime}.") { }
        public ScheduleConflictException(int scheduleId, int ClassID)
           : base($"Schedule with ID {scheduleId}  conflicts with another Class {ClassID}.") { }
        public ScheduleConflictException(string Message)
           : base(Message) { }

    }
}
