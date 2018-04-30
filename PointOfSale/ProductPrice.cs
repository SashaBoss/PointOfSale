namespace PointOfSale
{
    public class ProductPrice
    {
        public char Code { get; set; }
        public decimal PriceForOneItem { get; set; }
        public int SpecialPriceCount { get; set; }
        public decimal SpecialPrice { get; set; }
    }
}