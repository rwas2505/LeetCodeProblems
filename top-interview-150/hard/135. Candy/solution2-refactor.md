#### Changes

Slight improvements by removing the loops that were just used for logging.
Also used the ratings array for storing candy count rather than making a new one.
Should be able to use a counter instead of looping over the array again at the end to get a count but when I tried it I'm getting the wrong value initially so need ot look more into it.
May also be able to improve the while loops for steps and clean this up with helper methods extracted.

```cs
public class Solution {
    private const string PEAK = "P";
    private const string VALLEY = "V";
    private const string STEP = "S";

    public int Candy(int[] ratings) {

        var locations = new string[ratings.Length];

        // Loop through and assign P, V, or S
        for(var i = 0; i < ratings.Length; i++)
        {
            var current = ratings[i];
            var previous = 0;
            var next = 0;

            if(i > 0) previous = ratings[i-1];

            if(i < ratings.Length - 1) next = ratings[i+1];


            // Handle first element
            if( i==0 )
            {
                if(current > next)
                {
                    locations[i] = PEAK;
                }
                else
                {
                    locations[i] = VALLEY;
                }
            }
            // Handle last element
            else if(i == ratings.Length - 1)
            {
                if(current > previous)
                {
                    locations[i] = PEAK;
                }
                else
                {
                    locations[i] = VALLEY;
                }
            }
            // Handle all but first and last
            else
            {
                if( (previous == current && next < current) || (previous < current && next == current) || (previous < current && next < current) )
                {
                    locations[i] = PEAK;
                }
                else if ( (previous > current && next == current) || (previous > current && next > current) || (previous == current && next == current) || (previous == current && next > current) )
                {
                    locations[i] = VALLEY;
                }
                else
                {
                    locations[i] = STEP;
                }
            }
        } 

        // Step 2: Loop through locations array and assign values to the S elements  

        //TODO: should be able to overwrite the ratings array instead, and eventually just increment a count

        for(var j = 0; j < locations.Length; j++)
        {
            if(locations[j] == VALLEY)
            {
                ratings[j] = 1;
            }
            else if(locations[j] == STEP) // step will always have neighbors to left and right
            {
                var hasStepNeighbors = locations[j-1] == STEP || locations[j+1] == STEP;

                if(!hasStepNeighbors) 
                {
                    ratings[j] = 2;
                }
                else
                {
                    //must be either ascending or descending 
                    // ascending if the first non-s value moving to front of array is a VALLEY else descending
                    // may need to do another loop for this cluster while the value isn't STEP to maintain a local counter

                    var isAscending = locations[j-1] == VALLEY;
                    var stepClusterSize = 0;

                    var c = j;

                    //TODO: we have 3 while(locations[c] == steps) here where we just increment c++
                    // can probably reduce that to 1 and incorporate the if logic for asc/desc in the single loop
                    while(locations[c] == STEP)
                    {
                        stepClusterSize++;
                        c++;
                    }

                    c = j;

                    if(isAscending)
                    {
                        var counter = 2;

                        while(locations[c] == STEP)
                        {
                            ratings[c] = counter;
                            counter++;
                            c++;
                        }
                    }
                    else //descending
                    {
                        while(locations[c] == STEP)
                        {
                            ratings[c] = stepClusterSize + 1;
                            stepClusterSize--;
                            c++;
                        }
                    }

                    // Set j to the last step so that when it increments in this for loop it will be the next non-step element
                    j = c - 1;
                }
                    
            }
        }   

        // start from beginning to get to peaks that now should have all valleys and steps assigned
        // could improve this to do it during the first iteration when assigning valleys and steps


        // *3. Assign values to P*

        for( var k = 1; k < locations.Length - 1; k++) // we take care of first and last element later
        {
            if(locations[k] == PEAK)
            {
                var hasPeakNeighbors = locations[k-1] == PEAK || locations[k+1] == PEAK;

                if(!hasPeakNeighbors)
                {
                    var left = ratings[k-1];
                    var right = ratings[k+1];
                    var peakValue = -1;

                    // Console.WriteLine("Left: " + left);
                    // Console.WriteLine("Right: " + right);

                    if(left > right || left == right)
                    {
                        peakValue = left + 1;
                    }
                    else
                    {
                        peakValue = right + 1;
                    }

                    ratings[k] = peakValue;
                }
                else
                {
                    var leftPeakIndex = k;
                    var rightPeakIndex = k + 1;

                    ratings[leftPeakIndex] = ratings[leftPeakIndex - 1] + 1;
                    ratings[rightPeakIndex] = ratings[rightPeakIndex + 1] + 1;
                    k++;
                }
            }
        }

        if(locations[0] == VALLEY)
        {
            ratings[0] = 1;
        }
        else
        {
            ratings[0] = ratings[1] +1;
        }

        if(locations[locations.Length - 1] == VALLEY)
        {
            ratings[locations.Length - 1] = 1;
        }
        else
        {
            ratings[locations.Length -1] = ratings[locations.Length - 2] + 1;
        }


        var answer = 0;

        for(var candy=0; candy < ratings.Length; candy++)
        {
            answer += ratings[candy];
        }

        return answer;
    }
}
```
