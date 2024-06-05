h3. Other users solution

This looks interesting because it does less loops than what I did I think

https://leetcode.com/problems/h-index/solutions/70768/java-bucket-sort-o-n-solution-with-detail-explanation

This type of problems always throw me off, but it just takes some getting used to. The idea behind it is some bucket sort mechanisms. First, you may ask why bucket sort. Well, the h-index is defined as the number of papers with reference greater than the number. So assume n is the total number of papers, if we have n+1 buckets, number from 0 to n, then for any paper with reference corresponding to the index of the bucket, we increment the count for that bucket. The only exception is that for any paper with larger number of reference than n, we put in the n-th bucket.

Then we iterate from the back to the front of the buckets, whenever the total count exceeds the index of the bucket, meaning that we have the index number of papers that have reference greater than or equal to the index. Which will be our h-index result. The reason to scan from the end of the array is that we are looking for the greatest h-index. For example, given array [3,0,6,5,1], we have 6 buckets to contain how many papers have the corresponding index. Hope to image and explanation help.

```java
public int hIndex(int[] citations) {
    int n = citations.length;
    int[] buckets = new int[n+1];
    for(int c : citations) {
        if(c >= n) {
            buckets[n]++;
        } else {
            buckets[c]++;
        }
    }
    int count = 0;
    for(int i = n; i >= 0; i--) {
        count += buckets[i];
        if(count >= i) {
            return i;
        }
    }
    return 0;
}
```


So I think the buckets would look like this


[0, 0, 0, 0, 0, 0]

Then we fill them up based on the largest bucket the citation count would fill up, so it would be 

[1, 1, 0, 1, 0, 2]

Then starting from the end you increment a counter by the index value until the counter is equal to or greater than the bucket index