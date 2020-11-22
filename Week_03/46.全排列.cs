/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
public class Solution {
    IList<IList<int>> lists = new List<IList<int>>();
    public IList<IList<int>> Permute(int[] nums) {
        DoPermute(nums, new List<int>());
        return lists;
    }

    public void DoPermute(int[] nums, IList<int> temp) {
        if (temp.Count == nums.Length) {
            lists.Add(new List<int>(temp));
            return;
        }

        for (int i=0; i<nums.Length; i++) {
            if (temp.Contains(nums[i])) continue;
            temp.Add(nums[i]);
            DoPermute(nums, temp);
            temp.RemoveAt
            (temp.Count-1);
        }
    }
}
// @lc code=end

