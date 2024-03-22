namespace Ecom.API.Sharing
{
    public class ProdutoParams
    {
        public int MaxPageSize { get; set; } = 10;
        private int _pageSize = 10;

        public int PageSize 
        { 
           get { return _pageSize; }
           set { _pageSize = value > MaxPageSize ? MaxPageSize : value ; } 
        }

        public int PageNuber { get; set; } = 1;

        public string Sort { get; set; }

        public int? categoria_id { get; set; }  
    }
}
