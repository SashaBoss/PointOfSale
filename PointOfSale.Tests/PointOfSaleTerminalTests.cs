namespace PointOfSale.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PointOfSaleTerminalTests
    {
        private PointOfSaleTerminal _terminal;

        [SetUp]
        public void Init()
        {
            _terminal = new PointOfSaleTerminal();
            var productAPrice = new ProductPrice
            {
                Code = 'A',
                PriceForOneItem = 1.25M,
                SpecialPriceCount = 3,
                SpecialPrice = 3.00M
            };
            var productBPrice = new ProductPrice
            {
                Code = 'B',
                PriceForOneItem = 4.25M,
                SpecialPriceCount = 1,
                SpecialPrice = 4.25M
            };
            var productCPrice = new ProductPrice
            {
                Code = 'C',
                PriceForOneItem = 1.00M,
                SpecialPriceCount = 6,
                SpecialPrice = 5.00M
            };
            var productDPrice = new ProductPrice
            {
                Code = 'D',
                PriceForOneItem = 0.75M,
                SpecialPriceCount = 1,

                SpecialPrice = 0.75M
            };
            _terminal.SetPricing(productAPrice);
            _terminal.SetPricing(productBPrice);
            _terminal.SetPricing(productCPrice);
            _terminal.SetPricing(productDPrice);
        }

        [Test]
        public void CalculateTotal_ABCD_Total7And25()
        {
            // Arrange
            var expectedTotal = 7.25M;
           
            // Act
            _terminal.Scan('A');
            _terminal.Scan('B');
            _terminal.Scan('C');
            _terminal.Scan('D');
            var total = _terminal.CalculateTotal();

            // Assert
            Assert.AreEqual(expectedTotal, total);
        }

        [Test]
        public void CalculateTotal_CCCCCCC_Total6()
        {
            // Arrange
            var expectedTotal = 6.00M;
           
            // Act
            _terminal.Scan('C');
            _terminal.Scan('C');
            _terminal.Scan('C');
            _terminal.Scan('C');
            _terminal.Scan('C');
            _terminal.Scan('C');
            _terminal.Scan('C');
            var total = _terminal.CalculateTotal();

            // Assert
            Assert.AreEqual(expectedTotal, total);
        }

        [Test]
        public void CalculateTotal_ABCDABA_Total13And25()
        {
            // Arrange
            var expectedTotal = 13.25M;
           
            // Act
            _terminal.Scan('A');
            _terminal.Scan('B');
            _terminal.Scan('C');
            _terminal.Scan('D');
            _terminal.Scan('A');
            _terminal.Scan('B');
            _terminal.Scan('A');
            var total = _terminal.CalculateTotal();

            // Assert
            Assert.AreEqual(expectedTotal, total);
        }
    }
}