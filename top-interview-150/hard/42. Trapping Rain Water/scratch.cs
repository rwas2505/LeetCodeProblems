public class Solution {
    private const string _PEAK = "P";
    private const string _VALLEY = "V";
    private const string _STEP = "S";

    public int Trap(int[] height) {
        string firstHeightProperty = null;
        var firstHeight = height[0];

        for(var i = 1; i < height.Length; i++)
        {
            var currentHeight = height[i];

            if(currentHeight == firstHeight) continue;

            if(currentHeight > firstHeight)
            {
                firstHeightProperty = _VALLEY;
                break;
            }
            else
            {
                firstHeightProperty = _PEAK;
                break;
            }
        }

        Console.WriteLine("firstHeight: " + firstHeight); 
        Console.WriteLine("firstHeightProperty: " + firstHeightProperty); 

        return -1;
    }
}