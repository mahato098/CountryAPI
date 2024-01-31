namespace CountryDropDownAPI.PageExtension
{
    public class PagedList<T> : List<T>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PagedList(List<T> items, int pageNumber, int pageSize, int totalCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            AddRange(items);
        }

        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

    }
}
