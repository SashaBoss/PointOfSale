namespace PointOfSale
{
    public class ScannedProduct
    {
        public ScannedProduct(char code)
        {
            Code = code;
            Count = 1;
        }

        public char Code { get; }
        public int Count { get; set; }
    }
}