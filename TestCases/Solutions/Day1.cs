using System.IO;
using System.Linq;
using NUnit.Framework;
using Utilities;

namespace TestCases.Solutions;

public class Day1
{
    private readonly double[] _nums = File.ReadAllLines("Inputs/Day1Input.txt")
        .Select(double.Parse)
        .ToArray();

    [Test]
    public void CountNumIncreases_ShouldPass()
    {
        var increaseCount = _nums.CountIncreases();

        Assert.Pass("Increase count is {0}", increaseCount);
    }

    [Test]
    public void SlidingWindowNumIncreases_ShouldPass()
    {
        var increaseCount = _nums
            .GetSlidingWindowAverages(3)
            .CountIncreases();

        Assert.Pass("Increase count is {0}", increaseCount);
    }
}