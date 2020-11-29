/*
 * @lc app=leetcode.cn id=455 lang=csharp
 *
 * [455] 分发饼干
 */

// @lc code=start
public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        if (s.Length == 0) return 0;
        int child=0, biscuits=0;
        Array.Sort(g);
        Array.Sort(s);
        while (child < g.Length && biscuits < s.Length) {
            if (s[biscuits] >= g[child]) {
                biscuits++;
                child++;
            } else {
                biscuits++;
            }
        }

        return child;
    }
}
// @lc code=end

