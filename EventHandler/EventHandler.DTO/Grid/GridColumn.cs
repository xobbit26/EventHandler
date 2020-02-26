namespace EventHandler.DTO.Grid
{
    public class GridColumn
    {
        public GridColumn(string id, string sortKey, string label, string columnType, bool isSortable)
        {
            Id = id;
            SortKey = sortKey;
            Label = label;
            ColumnType = columnType;
            IsSortable = isSortable;
        }

        public string Id { get; set; }
        public string SortKey { get; set; }
        public string Label { get; set; }
        public string ColumnType { get; set; }
        public bool IsSortable { get; set; }
    }
}
