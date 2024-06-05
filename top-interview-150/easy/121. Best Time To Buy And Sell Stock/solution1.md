We keep track of three things while iterating through the array
1. MaxSpread
2. Minimum value
3. Current value

At each iteration check if the current value - minimum value is greater than the max spread. If yes, update max spread.

Also check if current value is less than the minimum value. If so replace the minimum value.

This ensures at each iteration, we are getting the spread of the current value less the smallest value prior to it which will result in the max spread.


```cs
public class Solution {
    public int MaxProfit(int[] prices) {
        var minimumPrice = prices[0];

        var currentPrice = prices[0];

        var maxSpread = currentPrice - minimumPrice;

        for(var i = 1; i < prices.Length; i++)
        {
            currentPrice = prices[i];

            if( currentPrice < minimumPrice )
            {
                minimumPrice = currentPrice;
            }

            if(currentPrice - minimumPrice > maxSpread)
            {
                maxSpread = currentPrice - minimumPrice;
            }
        }

        return maxSpread;
    }      
}
```

