namespace Core.Specifications
{
    public class ProductSpecParams:BaseSpecParams
    {
        public string Sort { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }

        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}