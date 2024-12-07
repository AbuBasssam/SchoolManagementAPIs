namespace ApplicationLayer.Interfaces
{
    public interface IAddCourseValidation
    {
        Task<bool> IsExistsByNameAsync(string CourseName);

    }
}
