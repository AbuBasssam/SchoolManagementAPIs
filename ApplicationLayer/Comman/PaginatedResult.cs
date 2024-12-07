namespace ApplicationLayer.Comman
{
    public class PaginatedResult<T> where T : class
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public object? Meta { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public List<string> Messages { get; set; } = null!;

        public bool Succeeded { get; set; }

        public List<T> Data { get; set; } = null!;

        internal PaginatedResult() { }

        //_________________________________________________________________________________________________

        //public class PaginatedResultBuilder
        //{
        //    private readonly PaginatedResult<T> _result;

        //    public PaginatedResultBuilder()
        //    {
        //        _result = new PaginatedResult<T>();
        //    }

        //    public PaginatedResultBuilder WithData(List<T> data)
        //    {
        //        _result.Data = data;
        //        return this;
        //    }

        //    public PaginatedResultBuilder WithCurrentPage(int currentPage)
        //    {
        //        _result.CrurentPage = currentPage;
        //        return this;
        //    }

        //    public PaginatedResultBuilder WithTotalCount(int totalCount)
        //    {
        //        _result.TotalCount = totalCount;
        //        return this;
        //    }

        //    public PaginatedResultBuilder WithPageSize(int pageSize)
        //    {
        //        _result.PageSize = pageSize;
        //        return this;
        //    }

        //    public PaginatedResultBuilder WithMeta(object meta)
        //    {
        //        _result.Meta = meta;
        //        return this;
        //    }

        //    public PaginatedResultBuilder WithMessages(List<string> messages)
        //    {
        //        _result.Messages = messages;
        //        return this;
        //    }

        //    public PaginatedResultBuilder WithSucceeded(bool succeeded)
        //    {
        //        _result.Succeeded = succeeded;
        //        return this;
        //    }

        //    public PaginatedResult<T> Build()
        //    {
        //        if (_result.PageSize > 0 && _result.TotalCount > 0)
        //        {
        //            _result.TotalPages = (int)Math.Ceiling(_result.TotalCount / (double)_result.PageSize);
        //        }
        //        return _result;
        //    }
        // Static factory method to create a builder
        public static PaginatedResultBuilder<T> Create() => new PaginatedResultBuilder<T>();

    }


}

