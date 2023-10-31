namespace NetCoreAPI.Dtos
{
    public class GetAll
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
