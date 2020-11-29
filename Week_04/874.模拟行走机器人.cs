/*
 * @lc app=leetcode.cn id=874 lang=csharp
 *
 * [874] 模拟行走机器人
 */

// @lc code=start
public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        if (commands.Length == 0) return 0;
        ISet<long> set= new HashSet<long>();
        foreach (int[] ob in obstacles) {
            set.Add(GetHash(ob[0], ob[1]));
        }

        int[,] dirs = new int[,] {{0,1},{1,0},{0,-1},{-1,0}};
        int d = 0, x = 0, y = 0, ans = 0;
        foreach (var c in commands) {
            if (c < 0) {
                d = (d + (c == -2? 3 : 1)) % 4;
            }

            int steps = c;
            while (steps-- > 0) {
                int newX = x + dirs[d,0];
                int newY = y + dirs[d,1];
                if (!set.Contains(GetHash(newX, newY))) {
                    x = newX;
                    y = newY;
                }
                ans = Math.Max(ans, x*x + y*y);
            }
        }

        return ans;
        
    }

    public long GetHash(int x, int y) {
        return ((x+30000) << 16) + y + 30000;
    }
}
// @lc code=end

