/*
 * @lc app=leetcode.cn id=529 lang=csharp
 *
 * [529] 扫雷游戏
 */

// @lc code=start
public class Solution {
    int[] dirX = new int[]{0, 1, 0, -1, 1, 1, -1, -1};
    int[] dirY = new int[]{1, 0 ,-1, 0, 1, -1, 1, -1};
    public char[][] UpdateBoard(char[][] board, int[] click) {
        int x = click[0], y = click[1];
        if (board[x][y] == 'M') {
            board[x][y] = 'X';
        } else {
            Dfs(board, x, y);
        }

        return board;
    }

    public void Dfs(char[][] board, int x, int y) {
        int ans = 0;
        for (int i=0; i<8; i++) {
            int newX = x + dirX[i];
            int newY = y + dirY[i];

            if (newX<0 || newY<0 || newX >= board.Length || newY>=board[0].Length) continue;

            if (board[newX][newY] == 'M') ans++;
        }

        if (ans>0) {
            board[x][y] = (char) (ans + '0');
        } else {
            board[x][y] = 'B';
            for (int i=0; i<8; i++) {
                int newX = x + dirX[i];
                int newY = y + dirY[i];

                if (newX<0 || newY<0 || newX >= board.Length || newY>=board[0].Length || board[newX][newY] != 'E') continue;

                Dfs(board, newX, newY);
            }
        }
    }
}
// @lc code=end

