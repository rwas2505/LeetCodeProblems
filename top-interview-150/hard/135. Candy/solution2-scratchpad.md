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


[1,0,2]
[6,4,4,3,5,5,4,6,4,3,2,4]

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

            if(i > 0)
            {
                previous = ratings[i-1];
            }

            if(i < ratings.Length - 1)
            {
                next = ratings[i+1];
            }


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

        for(var i = 0; i < locations.Length; i++)
        {
            Console.WriteLine("Location: " + locations[i]);
        }

        return 0;
    }
}
```





[1,2,2]