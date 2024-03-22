namespace Ecom.API.Helper
{
    public class Pagination<T> where T: class
    {
        public Pagination(int page_number, int page_size, int count, IReadOnlyList<T> data)
        {
            PageNumber = page_number;
            PageSize = page_size;
            Count = count;
            Data = data;
        }

        public int PageNumber {  get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
