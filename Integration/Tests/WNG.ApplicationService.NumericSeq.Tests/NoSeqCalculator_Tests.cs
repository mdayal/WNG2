using System.Collections.Generic;
using CT.Utility.ExtensionMethods;
using NUnit.Framework;
using WNG.ApplicationService.NumericSeq.Services;

namespace WNG.ApplicationService.NumericSeq.Tests
{
    [TestFixture]
    public class NoSeqCalculator_Tests : MockTestBase
    {

        private NoSeqCalculatorService _noSeqCalculatorService;
        private int _number;
        private List<int> _numberSeries;

        [SetUp]
        public override void TestSetup()
        {
            _number = 4;
            _numberSeries = new List<int>() { 3, 10, 15 };
            base.TestSetup();
            _noSeqCalculatorService = Container.Create<NoSeqCalculatorService>();

        }

        [Test]
        public void GenerateNumericSequence_PostiveUnsignedNumber_ReturnsIntListOfAllNumbersUptoANumber()
        {
            var result = _noSeqCalculatorService.NumericSeqResult(4);
            const string series = "<div class=\"alert \">\r\n<strong>Number series:</strong> 1, 2, 3, and 4</div>\r\n<div class=\"alert alert-info\">\r\n<strong>Even Number series</strong>: 2, and 4</div>\r\n<div class=\"alert alert-warning\">\r\n<strong>Odd Number series:</strong> 1, and 3</div>\r\n<div class=\"alert alert-danger\">\r\n<strong>Multiple of 3,5 and both 3 and 5 series:</strong> 1, 2, C, and 4</div>\r\n";
            Assert.AreEqual(result, series);
        }

        [Test]
        public void GenerateNumberSeries_PostiveUnsignedNumber_ReturnsIntListOfAllNumbersUptoANumber()
        {
            var result = _number.GenerateNumberSeries();
            Assert.AreEqual(result, new List<int>() { 1, 2, 3, 4 });
        }


        [Test]
        public void GenerateEvenNumberSeries_PostiveUnsignedNumber_ReturnsIntListOfAllEvenNumbersUptoANumber()
        {
            var result = _number.GenerateEvenNumberSeries();
            Assert.AreEqual(result, new List<int>() { 2, 4 });
        }


        [Test]
        public void GenerateEvenNumberSeries_PostiveUnsignedNumber_ReturnsIntListOfAllOddNumbersUptoANumber()
        {

            var result = _number.GenerateOddNumberSeries();
            Assert.AreEqual(result, new List<int>() { 1, 3 });
        }


        [Test]
        public void GenerateEvenNumberSeries_ListOfTypeInt_ReturnsCommaDelimitedTextWhereMultipeof3OutputsCMultipeof5OutputsEMultipeof3and5Outputsz()
        {

            var result = _numberSeries.ToCommaDelimitedTextParseMultiplesOf3And5();
            Assert.AreEqual(result, "C, E, and Z");
        }


        [Test]
        public void IsEvenNumber_PostiveUnsignedNumber_ReturnsTrue()
        {

            var result = _number.IsEven();
            Assert.AreEqual(result, true);
        }



        [Test]
        public void IsOddNumber_PostiveUnsignedNumber_ReturnsFalse()
        {

            var result = _number.IsOdd();
            Assert.AreEqual(result, false);
        }

        [TearDown]
        public void TearDown()
        {
            _number = 0;
            _noSeqCalculatorService = null;
        }
    }
}
