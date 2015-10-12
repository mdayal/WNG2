using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Utility.ExtensionMethods
{
    public static class IntExtensions
    {

        public static bool IsEven(this Int32 number)
        {
            return number%2 == 0;
        }

        public static List<int> GenerateNumberSeries(this Int32 number)
        {
            var numberSeries = new List<int>();
            for (var x = 1; x <= number; x++)
                numberSeries.Add(x);
            
            return numberSeries;
        }


        public static List<int> GenerateEvenNumberSeries(this Int32 number)
        {
            var oddNumberSeries = new List<int>();
            for (var x = 1; x <= number; x++)
            {
                if (x.IsEven())
                     oddNumberSeries.Add(x);
            }
            return oddNumberSeries;
        }

        public static List<int> GenerateOddNumberSeries(this Int32 number)
        {
            var numberSeries = new List<int>();
            for (var x = 1; x <= number; x++)
            {
                if (x.IsOdd())
                    numberSeries.Add(x);
            }
            return numberSeries;
        }

        public static List<int> GenerateFibonacciSeries(this Int32 number)
        {
            var t1 = 0;
            var t2 = 1;
            var numberSeries = new List<int> {t1, t2};
            var count = 2;
            while (count < number)
            {
                var t3 = t1 + t2;
                t1 = t2;
                t2 = t3;
                ++count;
                if(t3 <= number)
                numberSeries.Add(t3);
            }
            return numberSeries;
        }
      
        public static string ToCommaDelimitedText(this List<int> numberlist)
        {
            var stb = new StringBuilder();
            for (var x = 0; x < numberlist.Count; x++)
                stb.AppendFormat(x == numberlist.Count -1 ? "and {0}" : "{0}, ", numberlist[x]);
           
            return stb.ToString();
        }

        public static string ToCommaDelimitedTextParseMultiplesOf3And5(this List<int> numberlist)
        {
            var stb = new StringBuilder();
            for (var x = 0; x < numberlist.Count; x++)
            {
                var parsedNo = String.Format("{0}",numberlist[x]);
                if (numberlist[x].IsMultipleOf3And5())
                    parsedNo = "Z";
                else if (numberlist[x].IsMultipleOf3())
                    parsedNo = "C";

                else if (numberlist[x].IsMultipleOf5())
                    parsedNo = "E";

                stb.AppendFormat(x == numberlist.Count -1 ? "and {0}" : "{0}, ", parsedNo);
            }

            return stb.ToString();
        }

        public static bool IsOdd(this Int32 number)
        {
            return !number.IsEven();
        }


        public static bool IsMultipleOf3(this Int32 number)
        {
            return number % 3 == 0;
        }


        public static bool IsMultipleOf5(this Int32 number)
        {
            return number % 5 == 0;
        }


        public static bool IsMultipleOf3And5(this Int32 number)
        {
            return number.IsMultipleOf3() && number.IsMultipleOf5();
        }


       
    }
}
