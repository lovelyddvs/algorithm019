/*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 */

// @lc code=start
public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        IList<int> list = new List<int>();
        if (s.Length == 0 || p.Length ==0 || s.Length < p.Length) return list;
        
        int[] needs = new int[26];
        int[] windows = new int[26];

        for (int i=0; i<p.Length; i++) {
            needs[p[i] - 'a']++;
        }

        int left = 0, right = 0;
        while (right < s.Length) {
            int curR = s[right] - 'a';
            right++; windows[curR]++;

            while (windows[curR] > needs[curR]) {
                int curL = s[left] - 'a';
                left++; windows[curL]--;
            }

            if (right-left == p.Length) {
                list.Add(left);
            }
        }

        return list;
    }
}
// @lc code=end

