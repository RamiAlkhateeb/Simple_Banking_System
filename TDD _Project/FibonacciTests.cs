namespace TDD_Project
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void TestFibonacci(int expected, int index)
        {
            Assert.Equal(expected, GetFibonacci(index));
        }

        private int GetFibonacci(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;
            return GetFibonacci(index - 1) + GetFibonacci(index - 2);
        }
    }
}
