using DomainLayer.Contracts;
using DomainLayer.Entities;

public class MedicalInformation:IEntity
{
    #region  var/prop
    public int Id { get; set; }
    public int ConditionID { get; set; }
    public int StudentID { get; set; }
    public Student Student { get; set; } = null!;
    public MedicalCondition Condition { get; set; } = null!; 
    #endregion

}
