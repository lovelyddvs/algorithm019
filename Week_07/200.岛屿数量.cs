/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        int count = 0;

        for (int i=0; i<grid.Length; i++) {
            for (int j=0; j<grid[0].Length; j++) {
                if (grid[i][j] == '1') {
                    count++;
                    ChangeToWater(i, j, grid);
                }
            }
        }
        return count;
    }

    public void ChangeToWater (int i, int j, char[][] grid) {
        //terminator
        if (i<0  || j<0 || i>=grid.Length || j>=grid[0].Length || grid[i][j] == '0') return ;

        grid[i][j] = '0';
        ChangeToWater(i+1, j, grid);
        ChangeToWater(i-1, j, grid);
        ChangeToWater(i, j+1, grid);
        ChangeToWater(i, j-1, grid);
    }
}
// @lc code=end

