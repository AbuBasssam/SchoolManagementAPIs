namespace ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage
{
    public class FilterInfo
    {
        #region Field(s)
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        #endregion

        #region Constructure(s)
        public FilterInfo()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        #endregion
    }

}
