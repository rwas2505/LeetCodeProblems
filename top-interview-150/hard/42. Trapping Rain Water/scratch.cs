public class Solution {
    private const string _PEAK = "P";
    private const string _VALLEY = "V";
    private const string _STEP = "S";
    private string _currentLimitProperty = "";
    private int _currentLimitIndex = 0;
    private int _currentLimitHeight = -1;
    private string[] _propertiesArray = null;

    public int Trap(int[] height) {

        _currentLimitHeight = height[0];

        // Determine the first elements property Peak or Valley
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

        _propertiesArray = new string[height.Length];
        _propertiesArray[0] = _currentLimitProperty;

        while(_currentLimitIndex < height.Length - 1)
        {
            if (_currentLimitProperty == _VALLEY) // find next peak
            {
                FindNextPeakFromCurrentValley(height);
            }
            else if (_currentLimitProperty == _PEAK)
            {
                FindNextValleyFromCurrentPeak(height);
            }
        }

        for(var i = 0; i < _propertiesArray.Length; i++)
        {
            Console.WriteLine("Property for index " + i + " is: " + _propertiesArray[i]);
        }

        return -1;
    }


    private void FindNextValleyFromCurrentPeak(int[] height)
    {
        for (var i = _currentLimitIndex + 1; i < height.Length; i++)
        {
            var current = height[i];

            if(i == height.Length - 1)
            {
                _propertiesArray[i] = _VALLEY;
                _currentLimitProperty = _VALLEY;
                _currentLimitIndex = i;
                _currentLimitHeight = current;

                while(i >= 0 && height[i] == _currentLimitHeight)
                {
                    _propertiesArray[i] = _VALLEY;
                    i--;
                }

                break;       
            }

            var next = height[i + 1];
            bool isValley = CurrentIsValley(current, next);

            if(!isValley && current == _currentLimitHeight)
            {
                _propertiesArray[i] = _PEAK;
            }
            else if (!isValley && current < _currentLimitHeight)
            {
                _propertiesArray[i] = _STEP;                    
            }
            else
            {
                _propertiesArray[i] = _VALLEY;
                _currentLimitProperty = _VALLEY;
                _currentLimitIndex = i;
                _currentLimitHeight = current;

                while(i >= 0 && height[i] == _currentLimitHeight)
                {
                    _propertiesArray[i] = _VALLEY;
                    i--;
                }
                // Thought:
                // Traverse backwards now and assign any left neighbors with same height as a valley
                // since at this point they would have been assigned step

                break;                    
            }
        }
    }


    private void FindNextPeakFromCurrentValley(int[] height)
    {
        for (var i = _currentLimitIndex + 1; i < height.Length; i++)
        {
            var current = height[i];

            if(i == height.Length - 1)
            {
                _propertiesArray[i] = _PEAK;
                _currentLimitProperty = _PEAK;
                _currentLimitIndex = i;
                _currentLimitHeight = current;

                while(i >= 0 && height[i] == _currentLimitHeight)
                {
                    _propertiesArray[i] = _PEAK;
                    i--;
                }

                break;
            }

            var next = height[i + 1];

            bool isPeak = CurrentIsPeak(current, next);

            if(!isPeak && current == _currentLimitHeight)
            {
                _propertiesArray[i] = _VALLEY;
            }
            else if(!isPeak && current > _currentLimitHeight)
            {
                _propertiesArray[i] = _STEP;
            }
            else
            {
                _propertiesArray[i] = _PEAK;
                _currentLimitProperty = _PEAK;
                _currentLimitIndex = i;
                _currentLimitHeight = current;

                // Thought:
                // Traverse backwards now and assign any left neighbors with same height as a peak
                // since at this point they would have been assigned step
                while(i >= 0 && height[i] == _currentLimitHeight)
                {
                    _propertiesArray[i] = _PEAK;
                    i--;
                }

                break;
            }
        }
    }


    // TODO: These don't solve for when the valley or peak is a plateau, i.e. next == current

    private bool CurrentIsPeak(int current, int next)
    {
        return next < current;
    }

    private bool CurrentIsValley(int current, int next)
    {
        return next > current;
    }
}