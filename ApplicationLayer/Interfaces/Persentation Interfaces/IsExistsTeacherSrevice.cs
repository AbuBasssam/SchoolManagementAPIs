namespace ApplicationLayer.Interfaces
{
    public interface IsExistsTeacherSrevice
    {
        public Task<bool> IsExistsByTeacherNumber(string TeacherNumber);

    }

}
