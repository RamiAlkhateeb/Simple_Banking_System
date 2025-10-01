using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Project
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("Fizz", 3)]
        [InlineData("4", 4)]
        [InlineData("Buzz", 5)]
        [InlineData("Fizz", 6)]
        [InlineData("7", 7)]
        [InlineData("8", 8)]
        [InlineData("Fizz", 9)]
        [InlineData("Buzz", 10)]
        [InlineData("11", 11)]
        [InlineData("Fizz", 12)]
        [InlineData("13", 13)]
        [InlineData("14", 14)]
        [InlineData("FizzBuzz", 15)]
        public void TestFizzBuzz(string expected, int number)
        {
            Assert.Equal(expected, FizzBuzz(number));
        }
      
       

        private string FizzBuzz(int number) {
            if (number % 3 == 0 && number % 5 == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";
            return number.ToString();
        }
    }
}
