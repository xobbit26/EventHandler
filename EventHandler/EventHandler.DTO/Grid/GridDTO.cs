using System.Collections.Generic;

namespace EventHandler.DTO.Grid
{
    public class GridDTO<T>
    {
        public GridDTO()
        {
            IsGridEmpty = true;
        }

        public List<GridColumn> Columns { get; set; }
        public List<T> Data { get; set; }
        public long TotalItems { get; set; }
        public bool IsGridEmpty { get; set; }
    }
}
