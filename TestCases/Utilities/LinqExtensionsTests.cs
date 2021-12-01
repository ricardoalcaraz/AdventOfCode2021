using NUnit.Framework;
using Utilities;

namespace TestCases.Utilities;

public class LinqExtensionsTests
{
    [Test]
    public void GetSlidingWindows_ShouldPass()
    {
        var nums = new double[] {1, 2, 3, 4, 5};
        var expectedResult = new[] {2, 3, 4};
        
        var averages = nums.GetSlidingWindowAverages(3);
        
        CollectionAssert.AreEqual(expectedResult, averages);
    }

    [Test]
    public void CountIncreases_ShouldPass()
    {
        var nums = new double[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
        
        var increaseCount = nums
            .GetSlidingWindowAverages(3)
            .CountIncreases();
        
        Assert.AreEqual(5, increaseCount);
    }
}