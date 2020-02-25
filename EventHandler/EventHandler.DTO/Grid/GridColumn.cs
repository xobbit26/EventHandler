namespace EventHandler.DTO.Grid
{
    public class GridColumn
    {
        public GridColumn(string id, string sortKey, string label, bool isSortable)
        {
            Id = id;
            SortKey = sortKey;
            Label = label;
            IsSortable = isSortable;
        }

        public string Id { get; set; }
        public string SortKey { get; set; }
        public string Label { get; set; }
        public bool IsSortable { get; set; }
    }
}
