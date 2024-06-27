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

        var propertiesArray = new string[height.Length];
        propertiesArray[0] = firstHeightProperty;

        if (firstHeightProperty == _VALLEY)
        {
            for (var i = 1; i < height.Length; i++)
            {
                var current = height[i];
                var next = height[i + 1];

                bool isPeak = CurrentIsPeak(current, next);

                if(!isPeak && current == firstHeight)
                {
                    propertiesArray[i] = _VALLEY;
                    continue;
                }
                else if(!isPeak && current > firstHeight)
                {
                    propertiesArray[i] = _STEP;
                    continue;
                }
                else
                {
                    propertiesArray[i] = _PEAK;
                    break;
                }
            }
        }
        else if (firstHeightProperty == _PEAK)
        {
            for (var i = 1; i < height.Length; i++)
            {
                var current = height[i];
                var next = height[i + 1];
                bool isValley = CurrentIsValley(current, next);

                if(!isValley && current == firstHeight)
                {
                    propertiesArray[i] = _PEAK;
                }
                else if (!isValley && current < firstHeight)
                {
                    propertiesArray[i] = _STEP;                    
                }
                else
                {
                    propertiesArray[i] = _VALLEY;
                    break;                    
                }
            }
        }

        for(var i = 0; i < propertiesArray.Length; i++)
        {
            Console.WriteLine("Property for index " + i + " is: " + propertiesArray[i]);
        }

        return -1;
    }


    private bool CurrentIsPeak(int current, int next)
    {
        return next < current;
    }

    private bool CurrentIsValley(int current, int next)
    {
        return next > current;
    }
}