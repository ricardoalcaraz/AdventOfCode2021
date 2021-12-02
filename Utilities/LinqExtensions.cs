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

    public static IEnumerable<Movement> ConvertToMovement(this IEnumerable<string> str)
    {
        foreach (var movement in str)
        {
            var brokenDown = movement.Split(' ');
            var direction = Enum.TryParse<Direction>(brokenDown[0], true, out var result);
            int.TryParse(brokenDown[1], out var units);
            yield return new Movement()
            {
                Units = units,
                Direction = result
            };
        }
    }
}

public class Movement
{
    public int Units { get; set; }
    public Direction Direction { get; set; }
}

public enum Direction
{
    Invalid,
    Forward,
    Down,
    Up
}