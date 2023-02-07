namespace CrudDemoApp.Dto
{
    public class PaginationDto<TEntity>
    {
        public PaginationDto()
        {

        }

        public PaginationDto(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public List<TEntity> Entities { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int Totalpages
        { 
            get
            {
                return (int)Math.Ceiling((double)Count / (double)PageSize);
            }
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < Totalpages;
    }
}
