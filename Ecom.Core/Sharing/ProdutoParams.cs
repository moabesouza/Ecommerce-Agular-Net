namespace Ecom.Core.Sharing
{
    public class ProdutoParams
    {
        public int max_page_size { get; set; } = 10;
        private int _pageSize = 10;

        public int PageSize 
        { 
           get { return _pageSize; }
           set { _pageSize = value > max_page_size ? max_page_size : value ; } 
        }

        public int page_number { get; set; } = 1;

        public string sort { get; set; }

        public int? categoria_id { get; set; }

        private string _search;

        public string search 
        { 
            get { return _search; }
            set {  _search = value.ToLower(); }
        }
    }
}
