/*
 * @lc app=leetcode.cn id=300 lang=csharp
 *
 * [300] 最长递增子序列
 */

// @lc code=start
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        int[] tails = new int[n];
        int res = 0;
        foreach (int num in nums) {
            int i=0, j=res;
            while (i<j) {
                int  m = (i+j) >> 1;
                if (tails[m] < num) {
                    i = m + 1;
                } else {
                    j = m;
                }
            }
            tails[i] = num;
            if (j==res) res++;
        }
        return res;
    }
}
// @lc code=end

