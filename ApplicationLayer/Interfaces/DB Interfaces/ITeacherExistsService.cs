using DomainLayer.Entities;

public interface ITeacherExistsService
{
    IQueryable<Teacher> GetByUserName(string UserName);

}
