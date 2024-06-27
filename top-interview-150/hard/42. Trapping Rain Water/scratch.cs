public class Solution {
    private const string _PEAK = "P";
    private const string _VALLEY = "V";
    private const string _STEP = "S";
    private string _currentLimitProperty = "";
    private int _currentLimitIndex = -1;
    private int _currentLimitHeight = -1;

    public int Trap(int[] height) {

        _currentLimitHeight = height[0];

        for(var i = 1; i < height.Length; i++)
        {
            var currentHeight = height[i];

            if(currentHeight == _currentLimitHeight) continue;

            if(currentHeight > _currentLimitHeight)
            {
                _currentLimitProperty = _VALLEY;
                break;
            }
            else
            {
                _currentLimitProperty = _PEAK;
                break;
            }
        }

        // Console.WriteLine("firstHeight: " + _currentLimitHeight); 
        // Console.WriteLine("firstHeightProperty: " + _currentLimitProperty); 

        var propertiesArray = new string[height.Length];
        propertiesArray[0] = _currentLimitProperty;

        if (_currentLimitProperty == _VALLEY) // find next peak
        {
            FindNextPeakFromCurrentValley(height, propertiesArray);
        }
        else if (_currentLimitProperty == _PEAK)
        {
            FindNextValleyFromCurrentPeak(height, propertiesArray);
        }

        for(var i = 0; i < propertiesArray.Length; i++)
        {
            Console.WriteLine("Property for index " + i + " is: " + propertiesArray[i]);
        }

        return -1;
    }


    private void FindNextValleyFromCurrentPeak(int[] height, string[] propertiesArray)
    {
        for (var i = _currentLimitIndex + 1; i < height.Length; i++)
        {
            var current = height[i];
            var next = height[i + 1];
            bool isValley = CurrentIsValley(current, next);

            if(!isValley && current == _currentLimitHeight)
            {
                propertiesArray[i] = _PEAK;
            }
            else if (!isValley && current < _currentLimitHeight)
            {
                propertiesArray[i] = _STEP;                    
            }
            else
            {
                propertiesArray[i] = _VALLEY;
                _currentLimitProperty = _VALLEY;
                _currentLimitIndex = i;
                _currentLimitHeight = current;
                break;                    
            }
        }
    }


    private void FindNextPeakFromCurrentValley(int[] height, string[] propertiesArray)
    {
        for (var i = _currentLimitIndex + 1; i < height.Length; i++)
        {
            var current = height[i];
            var next = height[i + 1];

            bool isPeak = CurrentIsPeak(current, next);

            if(!isPeak && current == _currentLimitHeight)
            {
                propertiesArray[i] = _VALLEY;
            }
            else if(!isPeak && current > _currentLimitHeight)
            {
                propertiesArray[i] = _STEP;
            }
            else
            {
                propertiesArray[i] = _PEAK;
                _currentLimitProperty = _PEAK;
                _currentLimitIndex = i;
                _currentLimitHeight = current;
                break;
            }
        }
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