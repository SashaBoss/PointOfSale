namespace PointOfSale
{
    public interface IPointOfSaleTerminal
    {
        void Scan(char productCode);
        decimal CalculateTotal();
    }
}