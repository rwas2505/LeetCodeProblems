public class Solution {
    private const string _PEAK = "P";
    private const string _VALLEY = "V";
    private const string _STEP = "S";

    public int Trap(int[] height) {
        string currentLimitProperty = "";
        int currentLimitIndex = -1;
        var currentLimitHeight = height[0];

        for(var i = 1; i < height.Length; i++)
        {
            var currentHeight = height[i];

            if(currentHeight == currentLimitHeight) continue;

            if(currentHeight > currentLimitHeight)
            {
                currentLimitProperty = _VALLEY;
                break;
            }
            else
            {
                currentLimitProperty = _PEAK;
                break;
            }
        }

        Console.WriteLine("firstHeight: " + currentLimitHeight); 
        Console.WriteLine("firstHeightProperty: " + currentLimitProperty); 

        var propertiesArray = new string[height.Length];
        propertiesArray[0] = currentLimitProperty;

        if (currentLimitProperty == _VALLEY)
        {
            for (var i = 1; i < height.Length; i++)
            {
                var current = height[i];
                var next = height[i + 1];

                bool isPeak = CurrentIsPeak(current, next);

                if(!isPeak && current == currentLimitHeight)
                {
                    propertiesArray[i] = _VALLEY;
                }
                else if(!isPeak && current > currentLimitHeight)
                {
                    propertiesArray[i] = _STEP;
                }
                else
                {
                    propertiesArray[i] = _PEAK;
                    currentLimitProperty = _PEAK;
                    currentLimitIndex = i;
                    break;
                }
            }
        }
        else if (currentLimitProperty == _PEAK)
        {
            for (var i = 1; i < height.Length; i++)
            {
                var current = height[i];
                var next = height[i + 1];
                bool isValley = CurrentIsValley(current, next);

                if(!isValley && current == currentLimitHeight)
                {
                    propertiesArray[i] = _PEAK;
                }
                else if (!isValley && current < currentLimitHeight)
                {
                    propertiesArray[i] = _STEP;                    
                }
                else
                {
                    propertiesArray[i] = _VALLEY;
                    currentLimitProperty = _VALLEY;
                    currentLimitIndex = i;
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