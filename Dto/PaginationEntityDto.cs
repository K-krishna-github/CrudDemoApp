namespace CrudDemoApp.Dto
{
    public class PaginationEntityDto<TEntity>
    {
        public PaginationEntityDto()
        {

        }
        public PaginationEntityDto(int pageindex,int pagesize):this()
        {
            PageIndex = pageindex;
            Pagesize = pagesize;
        }
        public List<TEntity> Entities { get; set; }
        public int PageIndex { get; set; }
        public int Pagesize { get; set; }
        public int Count { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(Count /(double) Pagesize);
            }
        }

        public bool HasPreviouspage => PageIndex > 1;
        public bool HasNextpage => PageIndex < TotalPages;


    }
}
