using System.Collections.Generic;

namespace EventHandler.DTO.Grid
{
    public class GridDTO<T>
    {
        public List<GridColumn> Columns { get; set; }
        public List<T> Data { get; set; }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public bool IsGridEmpty { get; set; }
    }
}
