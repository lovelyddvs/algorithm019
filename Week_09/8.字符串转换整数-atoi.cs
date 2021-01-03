/*
 * @lc app=leetcode.cn id=8 lang=csharp
 *
 * [8] 字符串转换整数 (atoi)
 */

// @lc code=start
public class Solution {
    public int MyAtoi(string s) {
        if (s.Length == 0) return 0;

        int index = 0, sign = 1, total = 0;

        while (index<s.Length && s[index] == ' ') index++;

        if (index<s.Length && (s[index] == '+' || s[index] == '-')) {
            sign = s[index] == '+' ? 1 : -1;
            index++;
        }

        while (index<s.Length) {
            int digit = s[index] - '0';
            if (digit < 0 || digit > 9) break;

            if (int.MaxValue/10 < total || (int.MaxValue/10 == total && int.MaxValue%10 < digit)) {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            total  = 10 * total + digit;
            index++;
        }

        return total*sign;
    }
}
// @lc code=end

