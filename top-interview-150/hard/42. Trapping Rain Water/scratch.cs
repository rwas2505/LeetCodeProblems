public class Solution {
    private const string _PEAK = "P";
    private const string _VALLEY = "V";
    private const string _STEP = "S";
    private string _currentLimitProperty = "";
    private int _currentLimitIndex = 0;
    private int _currentLimitHeight = -1;
    private string[] _propertiesArray = null;
    private int[] _waterLevels = null;
    private int[] _height;

    public int Trap(int[] height) {
        _height = height;
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

        _propertiesArray = new string[height.Length];
        _propertiesArray[0] = _currentLimitProperty;

        while(_currentLimitIndex < height.Length - 1)
        {
            if (_currentLimitProperty == _VALLEY)
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

        _waterLevels = new int[height.Length];
        AssignWaterLevels();

        for(var w = 0; w < _waterLevels.Length; w++)
        {
            Console.WriteLine("Water Level for index " + w + " is: " + _waterLevels[w]);
        }

        return -1;
    }


    private void AssignWaterLevels()
    {
        for(var i = 0; i < _waterLevels.Length; i++)
        {
            if(_propertiesArray[i] == _PEAK)
            {
                _waterLevels[i] = 0;
            }
            else
            {
                // Ensure there is a left and right peak from this location

                var leftPeakHeight = GetLeftPeakHeight(i);
                var rightPeakHeight = GetRightPeakHeight(i);
                
                var canHoldWater = leftPeakHeight > -1 && rightPeakHeight > -1;

                // If not, it can't hold water so assign zero
                if(!canHoldWater)
                {
                    _waterLevels[i] = 0;
                }
                else
                {
                    // If yes, take the lower of the two peaks as the peak value
                    var ceiling = leftPeakHeight <= rightPeakHeight
                        ? leftPeakHeight
                        : rightPeakHeight;

                    var waterLevel = ceiling - _height[i];

                    _waterLevels[i] = waterLevel;
                }
            }
        }
    }

    private int GetLeftPeakHeight(int currentIndex)
    {
        if(currentIndex == 0) return -1;

        for(var i = currentIndex - 1; i >= 0; i--)
        {
            if(_propertiesArray[i] == _PEAK)
            {
                return _height[i];
            }
        }

        return -1;
    }

    private int GetRightPeakHeight(int currentIndex)
    {
        if(currentIndex == _propertiesArray.Length - 1) return -1;

        for(var i = currentIndex + 1; i <= _propertiesArray.Length - 1; i++)
        {
            if(_propertiesArray[i] == _PEAK)
            {
                return _height[i];
            }
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

                while(i >= 0 && height[i] == _currentLimitHeight)
                {
                    _propertiesArray[i] = _PEAK;
                    i--;
                }

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