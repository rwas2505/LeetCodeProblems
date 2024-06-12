#### This only solves the two simplest cases and has notes in the approach as to where I see it starting to fail in more complex situations.

There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
Return the minimum number of candies you need to have to distribute the candies to the children.

 

Example 1:

Input: ratings = [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.

Basic case approach::

1. Loop through the array and at each element check:
    - left neighbor rating
    - current element rating
    - right neighbor rating
    - left neighbor candy count
2. Handle when there is no left neighbor (first element)
3. Buncha conditionals
   - if current rating is less than left nieghbor 
     - AND current rating is LESS than the right neighbor: currentCandy = 1
     - AND current rating is MORE than the right neighbor: would have to be at least 2 to be more than the right neighbor, but what if the left neighbor was also 2? Then we'd have to increment the left neighbor but that has consequences for its left neighobrs too... At this point I wonder if I should go the find the min, assign 1 to it, and work outwwards solution....
   - if current rating is equal to left neighbor: currentCandy = left neighbor candy
   - if current rating is higher than left neighbor: current candy = left neighbor candy +1

Notes: Since we are checking the right neighbor on each iteration, we could probably handle its candy assignment during the previous kids assesssment and iterate to every other index in the loop. This would elminate needing special consideartion for the first and last elements with no left and rigt neighbor respectively.  

```cs
public class Solution {
    public int Candy(int[] ratings) {
        var candyAssignments = new int[ratings.Length];

        var leftRating = -1;
        var rightRating = -1;
        var currentRating = -1;


        // handle first element
        rightRating = ratings[1];
        currentRating = ratings[0];
        if(currentRating < rightRating)
        {
            candyAssignments[0] = 1;
        }
        else if(currentRating > rightRating)
        {
            candyAssignments[0] = 2;
        }
        else
        {
            candyAssignments[0] = 1;
        }

        for(var i = 1; i < ratings.Length - 1; i++)
        {
            leftRating = ratings[i - 1];
            currentRating = ratings[i];
            rightRating = ratings[i + 1];

            var leftCandy = candyAssignments[i-1];

            if(currentRating < leftRating && currentRating < rightRating)
            {
                candyAssignments[i] = 1;
            }

            if(currentRating < leftRating && currentRating > rightRating)
            {
                candyAssignments[i] = 2;
            }

            if(currentRating == leftRating)
            {
                candyAssignments[i] = leftRating;
            }

            if (currentRating > leftRating)
            {
                candyAssignments[i] = leftRating + 1;
            }
        }

        // handle last element
        currentRating = ratings[ratings.Length-1];
        leftRating = ratings[ratings.Length-2];

        if(currentRating > leftRating)
        {
            candyAssignments[ratings.Length-1] = (candyAssignments[ratings.Length-2] + 1);
        }

        if(currentRating < leftRating)
        {
            candyAssignments[ratings.Length-1] = 1;
        }

        if(currentRating == leftRating)
        {
            candyAssignments[ratings.Length-1] = 1;
        }


        var counter = 0;

        for (int i = 0; i < candyAssignments.Length; i++)
        {
            counter += candyAssignments[i];
        }

        return counter;        
    }
}

```







Example 2:

Input: ratings = [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.