using ApplicationLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories.Helper
{
    public static class ContextHelper<T> where T : class
    {
        public static async Task<PaginatingResult> PageInfo(DbSet<T> _set)
        {
            var TotalCount = await _set.AsQueryable().CountAsync();
            var Pages = Math.Ceiling(TotalCount / (double)10);
            return new PaginatingResult() { NumberOfPages = (int)Pages, TotalCount = TotalCount };
        }
    }
}
