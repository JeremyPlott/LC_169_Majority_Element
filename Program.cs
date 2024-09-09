# Intuition
Count and track the number of occurrences of elements, then stop as soon as one hits the minimum threshold.

# Approach
Loop through the array and store each element in a dictionary as the key. If it already exists, increment the value. Since we are guaranteed a majority element, we can return the result as soon as one elements reaches that threshold.

# Complexity
- Time complexity:
(O)n

- Space complexity:
(O)n

# Code
```csharp[]
public class Solution
{
    public int MajorityElement(int[] nums)
    {
        if (nums.Length == 1 || nums.Length == 2)
        {
            return nums[0];
        }

        var minimumElementsToCheck = (int)Math.Ceiling(nums.Length / 2.0);
        var elementCounts = new Dictionary<int, int>();

        var majorityElement = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var element = nums[i];
            if (elementCounts.ContainsKey(element))
            {
                elementCounts[element]++;
                if (elementCounts[element] == minimumElementsToCheck)
                {
                    majorityElement = element;
                    break;
                }
            }
            else
            {
                elementCounts.Add(element, 1);
            }
        }

        return majorityElement;
    }
}
```

# Commented Code
```csharp[]
public class Solution
{
    public int MajorityElement(int[] nums)
    {
        //get rid of cheesy test cases immediately. Both situations are guaranteed to be only a single unique element, no need to waste time or resources processing further.
        if (nums.Length == 1 || nums.Length == 2)
        {
            return nums[0];
        }

        //no need to go through the whole array once we have a majority.
        //if even length: a majority is guaranteed, so once an element has appeared in half of the spaces, it must be the majority.
        //if odd  length: divide in half and then round up for the minimum
        var minimumElementsToCheck = (int)Math.Ceiling(nums.Length / 2.0);

        //store the counts of each unique element
        var elementCounts = new Dictionary<int, int>();

        //just instantiate with any number. We are guaranteed a majority element, so it will always get overwritten.
        var majorityElement = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var element = nums[i]; //optional for readability

            //if it has already been added, increase the occurrence count by 1. Then check if the number of occurrences has reached the minimum amount to have a majority.
            if (elementCounts.ContainsKey(element))
            {
                elementCounts[element]++;
                if (elementCounts[element] == minimumElementsToCheck)
                {
                    majorityElement = element;
                    break; //found a majority, no need to go further

                    //Note: it is possible to return here directly, but then you'd also need a return later since methods expect all paths to return a value.
                }
            }
            else //add new element with a count of 1
            {
                elementCounts.Add(element, 1);
            }
        }

        //it is fine to do no further checking since we are guaranteed a majority element.
        return majorityElement;
    }
}
```