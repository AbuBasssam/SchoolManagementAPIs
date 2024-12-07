namespace DomainLayer.Exceptoins.Schedule
{
    public class ScheduleCapacityExceededException : Exception
    {
        public ScheduleCapacityExceededException(int NumberofStudents)
            : base($"the class for this Schedule  reach to maximan numbers {NumberofStudents}.") { }
    }
        
        
        
    //ScheduleCapacityExceededException: Thrown if the scheduled class exceeds allowed capacity for the room.
        


}
