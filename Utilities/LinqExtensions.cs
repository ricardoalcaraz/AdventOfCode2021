namespace Utilities;

public static class LinqExtensions
{
    public static int CountIncreases(this IEnumerable<double> nums)
    {
        var increases = 0;
        var lastNum = double.MaxValue;
        foreach (var num in nums)
        {
            if (num > lastNum)
                increases++;

            lastNum = num;
        }

        return increases;
    }


    public static IEnumerable<double> GetSlidingWindowAverages(this double[] nums, int windowSize)
    {
        for (var i = 0; i <= nums.Length - windowSize; i++)
        {
            var stopIndex = i + windowSize;
            var window = nums[i..stopIndex];
            yield return window.Average();
        }
    }
}