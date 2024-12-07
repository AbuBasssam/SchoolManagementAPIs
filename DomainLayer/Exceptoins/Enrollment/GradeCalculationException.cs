namespace DomainLayer.Exceptoins.Enrollment
{
    public class GradeCalculationException : Exception
    {
        public GradeCalculationException() : base("An error occurred while calculating the final grade.") { }
    }



}
