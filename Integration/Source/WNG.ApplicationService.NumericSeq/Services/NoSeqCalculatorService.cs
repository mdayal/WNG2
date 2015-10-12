using System;
using System.Text;
using CT.Utility.ExtensionMethods;
using CT.Utility.Interfaces;
using WNG.ApplicationService.NumericSeq.Interfaces;

namespace WNG.ApplicationService.NumericSeq.Services
{
    public class NoSeqCalculatorService : INoSeqCalculatorService
    {

        private readonly ICTLogger _logger;


        public NoSeqCalculatorService(ICTLogger logger)
        {
            _logger = logger;
        }


        #region INoSeqCalculatorService Members

        public string NumericSeqResult(int number)
        {
            var sb = new StringBuilder();
            try
            {
                sb.AppendLine("<div class=\"alert \">");
                sb.AppendFormat("<strong>Number series:</strong> {0}", number.GenerateNumberSeries().ToCommaDelimitedText());
                sb.AppendLine("</div>");

                sb.AppendLine("<div class=\"alert alert-info\">");
                sb.AppendFormat("<strong>Even Number series</strong>: {0}", number.GenerateEvenNumberSeries().ToCommaDelimitedText());
                sb.AppendLine("</div>");

                sb.AppendLine("<div class=\"alert alert-warning\">");
                sb.AppendFormat("<strong>Odd Number series:</strong> {0}", number.GenerateOddNumberSeries().ToCommaDelimitedText());
                sb.AppendLine("</div>");

                sb.AppendLine("<div class=\"alert alert-danger\">");
                sb.AppendFormat("<strong>Multiple of 3,5 and both 3 and 5 series:</strong> {0}", number.GenerateNumberSeries().ToCommaDelimitedTextParseMultiplesOf3And5());
                sb.AppendLine("</div>");

                sb.AppendLine("<div class=\"alert alert-danger\">");
                sb.AppendFormat("<strong>Fibonacci Series:</strong> {0}", number.GenerateFibonacciSeries().ToCommaDelimitedText());
                sb.AppendLine("</div>");

                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

            return sb.ToString();
        }

        #endregion



    }
}
