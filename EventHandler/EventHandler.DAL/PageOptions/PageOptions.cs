namespace EventHandler.DAL
{
    public class PageOptions
    {
        public PageOptions()
        {
            Direction = SortDirection.Ascending;
        }

        public bool IsPageable { get => Take != 0; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public bool IsSortable => !string.IsNullOrEmpty(SortBy);
        public string SortBy { get; set; }
        public string Direction { get; set; }
    }
}
