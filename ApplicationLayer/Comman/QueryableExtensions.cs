namespace ApplicationLayer.Comman
{
    public static class QueryableExtensions
    {
        /*public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> soruce, int pageNumber, int pageSize)
            where T : class
        {
            if (soruce == null)
            {
                throw new Exception("Empty");
            }

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await soruce.AsNoTracking().CountAsync();

            if (count == 0)
            {
                // Build an empty PaginatedResult with default values
                return PaginatedResult<T>.Create()
                    .WithData(new List<T>())
                    .WithCurrentPage(pageNumber)
                    .WithTotalPages(count)
                    .WithPageSize(pageSize)
                    .WithSucceeded(false)  // Indicates no data was found
                    .WithMessages(new List<string> { "No records found." })
                    .Build();
            }
            else
            {
                var items = await soruce.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                return PaginatedResult<T>.Create()
                    .WithData(items)
                    .WithCurrentPage(pageNumber)
                    .WithTotalPages(count)
                    .WithPageSize(pageSize)
                    .WithSucceeded(true)  // Indicates data retrieval was successful
                    .Build();
            }*/
        //}
    }
}
