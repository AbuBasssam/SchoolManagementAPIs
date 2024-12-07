using DomainLayer.Contracts;

public class MedicalCondition : IEntity
{
    #region var/prop
    public int Id { get; set; }
    public string ConditionName { get; set; } = null!;
    #endregion

}