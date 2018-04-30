namespace PointOfSale
{
    using System.Collections.Generic;

    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly IDictionary<char, ProductPrice> _priceList;
        private readonly IDictionary<char, ScannedProduct> _scannedProducts;

        public PointOfSaleTerminal()
        {
            _priceList = new Dictionary<char, ProductPrice>();
            _scannedProducts = new Dictionary<char, ScannedProduct>();
        }

        public void Scan(char productCode)
        {
            if (_scannedProducts.ContainsKey(productCode))
            {
                _scannedProducts[productCode].Count++;
            }
            else
            {
                _scannedProducts.Add(productCode, new ScannedProduct(productCode));
            }
        }

        public void SetPricing(ProductPrice product)
        {
            _priceList.Add(product.Code, product);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0.00M;

            foreach (var sp in _scannedProducts)
            {
                decimal subtotal;

                if (sp.Value.Count % _priceList[sp.Key].SpecialPriceCount >= 0)
                {
                    subtotal = sp.Value.Count / _priceList[sp.Key].SpecialPriceCount
                                      * _priceList[sp.Key].SpecialPrice + sp.Value.Count %
                                      _priceList[sp.Key].SpecialPriceCount *
                                      _priceList[sp.Key].PriceForOneItem;
                }
                else
                {
                    subtotal = sp.Value.Count * _priceList[sp.Key].PriceForOneItem;
                }

                total += subtotal;
            }

            return total;
        }
    }
}