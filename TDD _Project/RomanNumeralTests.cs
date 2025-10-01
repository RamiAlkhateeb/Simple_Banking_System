using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Project
{
    public class RomanNumeralTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(2, "II")]
        [InlineData(6, "VI")]
        [InlineData(4, "IV")]
        [InlineData(14, "XIV")]

        public void TestRomanNumerals(int expected, string roman)
        {
            Assert.Equal(expected, RomanNumeral.Parse(roman));

        }

        public class RomanNumeral
        {

            private static Dictionary<char, int> RomanMap = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            

            #region commented out code
            //    public int ToInteger(string roman)
            //    {
            //        int total = 0;
            //        int prevValue = 0;
            //        foreach (char c in roman.Reverse())
            //        {
            //            if (!RomanMap.TryGetValue(c, out int value))
            //            {
            //                throw new ArgumentException($"Invalid Roman numeral character: {c}");
            //            }
            //            if (value < prevValue)
            //            {
            //                total -= value;
            //            }
            //            else
            //            {
            //                total += value;
            //            }
            //            prevValue = value;
            //        }
            //        return total;
            //    }
            #endregion

            public static int Parse(string roman)
            {
                if (roman.Length > 1)
                {
                    int result = 0;
                    for (int i = 0; i < roman.Length; i++)
                    {
                        if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                            result -= RomanMap[roman[i]];
                        else
                            result += RomanMap[roman[i]];


                    }
                    return result;
                }
                else
                    return RomanMap[roman[0]];
            }
        }
    }
}
