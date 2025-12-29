using BusinessApp;
namespace XunitTestProject
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            // Arrange(Create objects and test data)
            var calculator = new Calculator();
            var expectedSum = 30;

            // Act(Call the method under test)
            var result = calculator.Add(10, 20);

            // Assert(Verify the expected outcome)
            Assert.Equal(expectedSum, result);
        }
        //Theory attribute for parameterized tests
        [Theory] //Multiple input scenarios
        [InlineData(2, 3, 5)] // to pass parameters to the test method
        [InlineData(10, 20, 30)]
        [InlineData(-5, 5, 10)]
        public void Add_MultipleInputs_ReturnsCorrectSum(
       int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
        [Theory] //Indicates a parameterized test method
        [MemberData(nameof(AddTestData))] //Reference to a property that provides test data
        public void Add_UsingMemberData_ReturnsCorrectSum(
    int a, int b, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(a, b);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> AddTestData =>
    new List<object[]>
    {
        new object[] { 1, 2, 3 },
        new object[] { 100, 200, 300 },
        new object[] { -10, -20, 30 }
    };

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void IsEven_EvenNumber_ReturnsTrue(int number)
        {
            var calculator = new Calculator();

            var result = calculator.IsEven(number);

            Assert.True(result);// Check that result is true
        }

        [Fact]
        public void IsEven_OddNumber_ReturnsFalse()
        {
            var calculator = new Calculator();

            var result = calculator.IsEven(3);

            Assert.False(result);// Check that result is false
        }
        [Fact]
        public void GetUserName_InvalidUser_ReturnsNull()
        {
            var calculator = new Calculator();

            var result = calculator.GetUserName(99);

            Assert.Null(result);// Check that result is null
        }

        [Fact]
        public void GetUserName_ValidUser_ReturnsName()
        {
            var calculator = new Calculator();

            var result = calculator.GetUserName(1);

            Assert.NotNull(result);// Check that result is not null
        }
        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            var calculator = new Calculator();
            // Assert that Divide method throws DivideByZeroException
            Assert.Throws<DivideByZeroException>(() =>
                calculator.Divide(10, 0));
        }
        // Asynchronous test method
        [Fact]
        public async Task DivideAsync_ByZero_ThrowsException()
        {
            var calculator = new Calculator();
            // Await the asynchronous method and assert exception
            await Assert.ThrowsAsync<DivideByZeroException>(() =>
                calculator.DivideAsync(10, 0));
        }
        [Fact]
        public void GetNumbers_ShouldContainValue()
        {
            var calculator = new Calculator();

            var result = calculator.GetNumbers();

            Assert.Contains(2, result);// Check if the collection contains the value 2
            Assert.DoesNotContain(5, result);// Check if the collection does not contain the value 5
        }

        [Fact]
        public void Collection_ShouldHaveSingleItem()
        {
            var list = new List<int> { 10 };

            Assert.Single(list);// Check if the collection has exactly one item
        }

        [Fact]
        public void Collection_ShouldBeEmpty()
        {
            var list = new List<int>();

            Assert.Empty(list);// Check if the collection is empty
        }
        [Fact]
        public void Result_ShouldBeOfExpectedType()
        {
            object value = 10;

            Assert.IsType<int>(value);// Check if value is of type int
            Assert.IsNotType<string>(value);// Check if value is not of type string
        }
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void Number_ShouldBeWithinRange(int number)
        {
            Assert.InRange(number, 1, 100);// Check if number is between 1 and 100
        }
    }
}