/*
 * @lc app=leetcode.cn id=363 lang=csharp
 *
 * [363] 矩形区域不超过 K 的最大数值和
 */

// @lc code=start
public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int rows=matrix.Length, cols=matrix[0].Length,  max=int.MinValue;
        for (int l=0; l<cols; l++) {
            int[] rowSum = new int[rows];
            for (int r=l; r<cols; r++) {
                for (int i=0; i<rows; i++) {
                    rowSum[i] += matrix[i][r];
                }
                max = Math.Max(max, dpmax(rowSum,k));
                if (max == k) return k;
            }
        }
        return max;
    }

    public int dpmax(int[] arr, int k) {
        int rollSum = arr[0], maxSum = rollSum;
        for (int i=1; i<arr.Length; i++) {
            if (rollSum > 0) rollSum += arr[i];
            else rollSum = arr[i];
            if (rollSum > maxSum) maxSum = rollSum;
        }
        if (maxSum <= k) return maxSum;

        int max = int.MinValue;
        for (int l=0; l<arr.Length; l++) {
            int sum = 0;
            for (int r=l; r<arr.Length; r++) {
                sum += arr[r];
                if (sum>max && sum<=k) max = sum;
                if (max==k) return k;
            }
        }
        return max;
    }
}
// @lc code=end

