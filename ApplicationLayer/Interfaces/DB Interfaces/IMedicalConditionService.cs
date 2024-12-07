namespace ApplicationLayer.Interfaces
{
    public interface IMedicalConditionRepository : IReadOnlyRepository<MedicalCondition>
    {
        IQueryable<MedicalCondition> GetByName(string conditionName);
    }
}
