namespace ePlatform.Api.Core
{
    public class PagingModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortedColumn { get; set; }
        public string QueryFilter { get; set; }
        public bool IsDesc { get; set; }
    }
}
