namespace BusinessApp
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public bool IsEven(int number) => number % 2 == 0;
        public string? GetUserName(int userId)
        {
            return userId == 1 ? "Admin" : null;
        }

        public List<int> GetNumbers()
        {
            return new List<int> { 1, 2, 3 };
        }
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }
        // Asynchronous version of Divide method
        public async Task<int> DivideAsync(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return await Task.FromResult(a / b);
        }

    }

}
