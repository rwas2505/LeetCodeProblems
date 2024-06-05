Example 1:

Input: citations = [3,0,6,1,5]
Output: 3
Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively.
Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, their h-index is 3.
Example 2:

Input: citations = [1,3,1]
Output: 1       



[3,0,6,1,5]

5: 2

4: 2

3: 3

2: 3

1: 4


create a dictionary with keys 1 through papers.Length

we know the max h-index would be papers.Length

foreach paper increment the dict value by one from 1 to paper.value

at the end find the largest key whose value is equal to or greater than the key

```cs
var citationsToPaperCount = new Dictionary<int, int>();
var maxHIndex = 0;

for(var i = 0; i < citations.Length; i++)
{
    var currentCitation = citations[i];

    if(currentCitation > 0)
    {
        for(var j = 1; j <= currentCitation; j++)
        {
            if(!citationsToPaperCount.ContainsKey(j))
            {
                citationsToPaperCount[j] = 1;
            }
            else
            {
                citationsToPaperCount[j] = citationsToPaperCount[j] + 1;
            }
        }

    }
}

for(var k = citations.Length; k > 0; k--)
{
    if(citationsToPaperCount.ContainsKey(k) && citationsToPaperCount[k] >= k)
    {
        maxHIndex = k;
        break;
    }
}

return maxHIndex;
```