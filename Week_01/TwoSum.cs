/* 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。

 

示例:

给定 nums = [2, 7, 11, 15], target = 9

因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1] */

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var n = nums.Length;
        Dictionary<int, int> myMaps = new Dictionary<int, int>();
        for (int i=0; i<n; i++) {
            if (myMaps.ContainsKey(target-nums[i])) {
                return new int[] {myMaps[target-nums[i]], i};
            } else {
                if (!myMaps.ContainsKey(nums[i])) {
                    myMaps.Add(nums[i], i);
                }
            }
        }

        return new int[0];
    }
}