namespace ApplicationLayer.Comman
{
    using System;
    using System.Collections.Generic;

    public class PaginatedResultBuilder<T> where T : class
    {
        private readonly PaginatedResult<T> _result;

        public PaginatedResultBuilder()
        {
            _result = new PaginatedResult<T>();
        }

        public PaginatedResultBuilder<T> WithData(List<T> data)
        {
            _result.Data = data;
            return this;
        }

        public PaginatedResultBuilder<T> WithCurrentPage(int currentPage)
        {
            _result.CurrentPage = currentPage;
            return this;
        }

        public PaginatedResultBuilder<T> WithTotalPages(int totalPages)
        {
            _result.TotalPages = totalPages;    

            return this;
        }
        public PaginatedResultBuilder<T> WithTotaCount(int totalCount)
        {
            _result.TotalCount = totalCount;

            return this;
        }

        public PaginatedResultBuilder<T> WithPageSize(int pageSize)
        {
            _result.PageSize = pageSize;
            return this;
        }

        public PaginatedResultBuilder<T> WithMeta(object meta)
        {
            _result.Meta = meta;
            return this;
        }

        public PaginatedResultBuilder<T> WithMessages(List<string> messages)
        {
            _result.Messages = messages;
            return this;
        }

        public PaginatedResultBuilder<T> WithSucceeded(bool succeeded)
        {
            _result.Succeeded = succeeded;
            return this;
        }

        public PaginatedResult<T> Build() =>_result;
        
    }

}

