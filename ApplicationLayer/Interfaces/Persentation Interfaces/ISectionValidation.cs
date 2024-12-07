namespace ApplicationLayer.Interfaces
{
    public interface ISectionValidation
    {
        Task<bool> IsExistsByNumberAsync(string SectionNumber);

    }
}
