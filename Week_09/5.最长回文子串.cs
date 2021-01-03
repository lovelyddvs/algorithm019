/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
public class Solution {
    public string LongestPalindrome(string s) {
        int len = s.Length;
        if (len < 2) return s;

        bool[][] dp = new bool[len][];
        for (int i=0; i<len; i++) {
            dp[i] = new bool[len];
            Array.Fill(dp[i], false);
            dp[i][i] = true;
        }

        int start = 0, maxLen = 1;

        for (int r=1; r<len; r++) {
            for (int l=r-1; l>=0; l--) {
                if(s[r] == s[l]) {
                    if (r-l<3) {
                        dp[l][r] = true;
                    } else {
                        dp[l][r] = dp[l+1][r-1];
                    }
                } else {
                    dp[l][r] = false;
                }

                if (dp[l][r]) {
                    int newLen = r-l+1;
                    if (newLen > maxLen) {
                        maxLen = newLen;
                        start = l;
                    }
                }
            }
        }

        return s.Substring(start, maxLen);
    }
}
// @lc code=end

