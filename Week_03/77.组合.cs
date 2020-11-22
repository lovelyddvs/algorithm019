/*
 * @lc app=leetcode.cn id=77 lang=csharp
 *
 * [77] 组合
 */

// @lc code=start
public class Solution {
    IList<IList<int>> lists = new List<IList<int>>();
    public IList<IList<int>> Combine(int n, int k) {
        DoCombine(1, n, k, new List<int>());
        return lists;
    }

    public void DoCombine(int cur, int n, int k, IList<int> temp) {
        if (k==0) {
            lists.Add(new List<int>(temp));
            return;
        }

        for (int i=cur; i<=n-k+1; i++) {
            temp.Add(i);
            DoCombine(i+1, n, k-1, temp);
            temp.RemoveAt(temp.Count-1);
        }
    }
}
// @lc code=end

