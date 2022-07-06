using ClassLibrary;
using Xunit;

namespace CorsoCSharp;

public class _12_UnitTest
{
    [Fact]
    public void TestAdding2And2()
    {
        // ARRANGE: this part declare and instantiate variable
        double a = 2;
        double b = 2;
        double expected = 4;

        Calculator calc = new();


        // ACT: this part execute the unit that you are testing
        double actualResult = calc.Add(a, b);

        // ASSERT: the part will make one or more assertion about the output
        Assert.Equal(expected, actualResult);
    }


    [Fact]
    public void TestAdding2And3()
    {
        // ARRANGE: this part declare and instantiate variable
        double a = 2;
        double b = 3;
        double expected = 5;

        Calculator calc = new();


        // ACT: this part execute the unit that you are testing
        double actualResult = calc.Add(a, b);

        // ASSERT: the part will make one or more assertion about the output
        Assert.Equal(expected, actualResult);
    }
}