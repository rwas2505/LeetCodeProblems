https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solutions/5083343/buy-the-dip-easy-solution

not my solution, interesting way to look at it though as solution1 wasn't super intuitive. This solution is similar to this one https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solutions/208241/explanation-for-the-dummy-like-me/?envType=study-plan-v2&envId=top-interview-150 which talks about buying on the smallest consecutive decreasing value and selling on the largest consecutive increasing value.

Intuition
Buy stock att every local min and sell at following local max. Keep track of the price of acquisition and the profit.

Approach
Interate through the array and check the nearest values prices[i-1] and prices[i+1]. In essence, buy the dip.
The first and last elements have to be handled separately.



```cs
public class Solution {
    public int MaxProfit(int[] prices) {
    int profit = 0;
    int priceBuy = 0;
    int pricesSize = prices.Length;

    if (pricesSize == 1) return 0;

    if (prices[0] < prices[1]){
        priceBuy = prices[0];
    }

    // Loop until the 2nd to last element
    for (int i = 1; i<prices.Length-1; i++){
        // If prices[i] is a local minimum in other words
        // i.e. its the smallest value in a decreasing progression
        if (prices[i-1] >= prices[i] && prices[i+1] > prices[i]){
            priceBuy = prices[i];
        }
        // If prices[i] is a local maximum in other words
        // i.e. its the largest value in an increasing progression
        else if(prices[i-1] < prices[i] && prices[i+1] <= prices[i]){
            profit += (prices[i]-priceBuy);
        }

        // Otherwise do nothing (no else) because we are in the middle of a progression
        // Progression may be either increasing or decreasing
    }

    // If the last price is higher than the 2nd to last price
    // Then use the last price as a sell point against the current buy price
    // This feels like it was forced in after the fact maybe after watching failures happen on submission?
    // In th eabove loop we ony loop until the 2nd to last element
    // And then check if its in a local relative max, min, or neither
    // So I guess this final check is to include the last element since the loop misses it?

    if (prices[pricesSize-1] > prices[pricesSize-2]){
        profit += (prices[pricesSize-1] - priceBuy);
    }

    return profit;
    }
}
```