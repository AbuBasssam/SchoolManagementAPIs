using ApplicationLayer.Interfaces;
using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Services
{
    public class ClassServices : IClassServices
    {
        #region Fields
        private readonly IClassRepository _Classes;

        #endregion

        #region Constructure(s)
        public ClassServices(IClassRepository classRepository)
        {
            _Classes = classRepository;

        }
        #endregion

        #region Action Methods

        public IQueryable<Class> GetById(int id) => _Classes.GetById(id);

        public IQueryable<Class> GetByName(string ClassName) => _Classes.GetByName(ClassName);

        public async Task<IList<Class>> GetFilterClasses(FilterClasses filter) => await _Classes.GetClassesFilter(filter);

        public Task<PaginatingResult> GetPaginateInfo() => _Classes.GetPaginateInfo();

        public IQueryable<Class> GetClassesPage(int PageNumber = 1) => _Classes.GetPage(PageNumber);

        public Task<bool> IsExistsByName(string ClassName) => _Classes.IsExistsByName(ClassName);

        #endregion

    }


}
