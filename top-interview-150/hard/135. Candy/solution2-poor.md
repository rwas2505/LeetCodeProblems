#### After a lot of manual note taking

1. Iterate through the list and assign each element as a P, V, or S (Peak, Valley, or Step)
2. Loop through again** and assign numbers to the step (S) elements
3. Loop through again** and assign numbers to the peak (P) elements

* **Can probably improve from 3 iterations to 1 iteration but this step makes building it out simpler and then can refactor further


- -1 = previous element
- +1 = next element
- CE = current element


*1. P, V, or S?*
   
Peak if:
- CE is first element AND +1 is less
- CE is last element AND -1 is less
- -1 is same and +1 is less
- -1 is less and +1 is same
- -1 is less and +1 is less

Valley if:
- CE is first element AND +1 is same
- CE is first element and +1 is greater
- CE is last element AND -1 is same
- CE is last element and - 1 is greater
- -1 is greater and +1 is same
- -1 is greater and +1 is greater
- -1 is same and +1 is same
- -1 is same and +1 is greater

Step if:
- None of the peak or valley conditions are true

*2. Assign values to S*
- If S is on an island (no S neighbors), assign it a value of 2
- If S is ascending (value before first S is 1/V), increment each S starting at 2
- If S is descendng (value bfore first S is a P), get the count of the current cluster of S's and decrement starting at count + 1

*3. Assign values to P*
- If P is on an island (no P neighbors) set it to the max(leftElementValue, rightElementValue) since Vs and Ss have been assigned
- If P is not on an island, it means there can only be two Ps in a row (if more than two, the middle values would be V) and so set the left P to value of element to left of P +1 and the right P to value right of P +1. This allows for the two peaks to be the minimum necessary value for their respective side of the plateau.

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

        var locationsStr = "";

        for(var i = 0; i < locations.Length; i++)
        {
            locationsStr = locationsStr + ", " + locations[i];

            // Console.WriteLine("Location: " + locations[i]);
        }

        Console.WriteLine("locationsStr: " + locationsStr);

        // Step 2: Loop through locations array and assign values to the S elements  

        //TODO: should be able to overwrite the ratings array instead, and eventually just increment a count
        var candyArray = new int[ratings.Length];

        for(var j = 0; j < locations.Length; j++)
        {
            if(locations[j] == VALLEY)
            {
                candyArray[j] = 1;
            }
            else if(locations[j] == STEP) // step will always have neighbors to let and right
            {
                var hasStepNeighbors = locations[j-1] == STEP || locations[j+1] == STEP;

                if(!hasStepNeighbors) 
                {
                    candyArray[j] = 2;
                }
                else
                {
                    //must be either ascending or descending 
                    // ascending if the first non-s value moving to front of array is a VALLEY else descending
                    // may need to do another loop for this cluster while the value isn't STEP to maintain a local counter

                    var isAscending = locations[j-1] == VALLEY;
                    var stepClusterSize = 0;

                    var c = j;

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
                            candyArray[c] = counter;
                            counter++;
                            c++;
                        }
                    }
                    else
                    {
                        while(locations[c] == STEP)
                        {
                            candyArray[c] = stepClusterSize + 1;
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

        // - If P is on an island (no P neighbors) set it to the max(leftElementValue, rightElementValue) +1 since Vs and Ss have been assigned

        // - If P is not on an island, it means there can only be two Ps in a row (if more than two, the middle values would be V) and so set the left P to value of element to left of P +1 and the right P to value right of P +1. This allows for the two peaks to be the minimum necessary value for their respective side of the plateau.

        for( var k = 1; k < locations.Length - 1; k++) // we take care of first and last element later
        {
            if(locations[k] == PEAK)
            {
                var hasPeakNeighbors = locations[k-1] == PEAK || locations[k+1] == PEAK;

                if(!hasPeakNeighbors)
                {
                    var left = candyArray[k-1];
                    var right = candyArray[k+1];
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

                    candyArray[k] = peakValue;
                }
                else
                {
                    var leftPeakIndex = k;
                    var rightPeakIndex = k + 1;

                    candyArray[leftPeakIndex] = candyArray[leftPeakIndex - 1] + 1;
                    candyArray[rightPeakIndex] = candyArray[rightPeakIndex + 1] + 1;
                    k++;
                }
            }
        }

        if(locations[0] == VALLEY)
        {
            candyArray[0] = 1;
        }
        else
        {
            candyArray[0] = candyArray[1] +1;
        }

        if(locations[locations.Length - 1] == VALLEY)
        {
            candyArray[locations.Length - 1] = 1;
        }
        else
        {
            candyArray[locations.Length -1] = candyArray[locations.Length - 2] + 1;
        }


        // Step 3: Loop through locations array and assign values to the P elements

        var answer = 0;
        var candyStr = "";

        for(var candy=0; candy < candyArray.Length; candy++)
        {
            candyStr = candyStr + ", " + candyArray[candy];
            // Console.WriteLine("Candy: " + candyArray[candy]);
            answer += candyArray[candy];
        }

        Console.WriteLine("____CandyStr: " + candyStr);
        return answer;
    }
}
```
