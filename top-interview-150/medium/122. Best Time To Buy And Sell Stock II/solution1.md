https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solutions/4836121/simple-beginner-friendly-dry-run-greedy-approach-readable-sol-time-o-n-space-o-1-gits

(not my solution ( see link above) )

Intuition 👈
In the given problem, we are provided with an array named "prices," where prices[i] represents the current price of a stock on day i. The task is to determine the maximum profit that can be achieved from selling the stock.

Approach 👈
To solve this question we will use Greedy Algorithm.

Now if you don't know anything about Greedy algorithm here is the small explanation of the Greedy.

Greedy algorithms are a class of algorithms that make locally optimal choices at each step with the hope of finding a global optimum solution. In these algorithms, decisions are made based on the information available at the current moment without considering the consequences of these decisions in the future. The key idea is to select the best possible choice at each step, leading to a solution that may not always be the most optimal but is often good enough for many problems.

Code Explanation 👈
Variable Initialization:

max is initialized to 0. This variable will accumulate the maximum profit throughout the iteration.
start is initialized to prices[0], the price of the stock on the first day. This variable represents the buying price of the stock.
len is initialized to prices.length, the length of the prices array, representing the total number of days.
Iteration: A for loop iterates through the prices array starting from the second element (i = 1) to the end of the array (i < len). This loop is used to calculate the profit for each transaction.

Profit Calculation:

Within the loop, there's an if statement checking if the current price (prices[i]) is greater than the buying price (start). If true, it indicates a potential profit opportunity.
The difference between the current price and the buying price (prices[i] - start) is calculated and added to max. This step simulates selling the stock bought at start price, capturing the profit, and then considering the current price as a new buying price for potential future transactions.
Regardless of whether a profit was made or not, the start is updated to the current price (prices[i]). This step prepares for the next iteration, considering the current day's price as the new buying price.
Return Statement: After the loop finishes executing, the method returns the accumulated max value, which represents the maximum profit that could have been achieved based on the given stock prices.

Complexity 👈
Time complexity: O(N)

Space complexity: O(1)



my c# code:

```cs
public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        int start = prices[0];

        for(var i =1; i < prices.Length; i++)
        {
            var currentProfit = prices[i] - start;

            if(currentProfit > 0)
            {
                maxProfit += currentProfit;
            }

            start = prices[i];
        }

        return maxProfit;
    }
}
```