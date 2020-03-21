using X.PagedList;

namespace WebApi.Responses
{
    public class PagedListResponse<T>
    {
        public IPagedList<T> PagedList { get; set; }
        public int TotalItemCount { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public bool IsLastPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool HasNextPage { get; set; }

        public PagedListResponse(IPagedList<T> pagedList)
        {
            PagedList = pagedList;
            TotalItemCount = pagedList.TotalItemCount;
            PageCount = pagedList.PageCount;
            PageNumber = pagedList.PageNumber;
            IsLastPage = pagedList.IsLastPage;
            IsFirstPage = pagedList.IsFirstPage;
            HasNextPage = pagedList.HasNextPage;
        }
        
    }
}