# 动态规划课后总结

动态规划比较适合用来求解最优问题，比如求最小值、最大值等，它可以显著地降低时间复杂度，提高代码地执行效率。

# 动态规划实现爬楼梯
    public int ClimbStairs(int n) {
        if (n==0) return 0;

        int[] dp= new int[n+1];
        dp[0]=1;
        dp[1]=1;

        for (int i=2; i<=n; i++) {
            dp[i] = dp[i-1] + dp[i-2];
        }
        return dp[n];
    }

# 不同路径
    public int UniquePaths(int m, int n) {
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        
        for (int i=1; i<m; i++) {
            for (int j=1; j<n; j++) {
                dp[j] += dp[j-1];
            }
        }

        return dp[n-1];
    }

# 最长公共子序列
    public int LongestCommonSubsequence(string text1, string text2) {
        if (text1.Length == 0 || text2.Length == 0) return 0;
        int m = text1.Length, n = text2.Length;
        int[][] dp = new int[m+1][];
        dp[0] = new int[n+1];

        for (int i=1; i<=m; i++) {
            dp[i] = new int[n+1];
            for (int j=1; j<=n; j++) {
                if (text1[i-1] == text2[j-1]) {
                    dp[i][j] = dp[i-1][j-1] + 1;
                } else {
                    dp[i][j] = Math.Max(dp[i-1][j], dp[i][j-1]);
                }
            }
        }
        return dp[m][n];
    }

# 三角形最小路径和
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count;
        int[] dp = new int[n+1];
        for (int i=n-1; i>=0; i--) {
            for (int j=0; j<=i; j++) {
                dp[j] = Math.Min(dp[j], dp[j+1]) + triangle[i][j];
            }
        }
        return dp[0];
    }

# 最大子序和
     public int MaxSubArray(int[] nums) {
        int pre = 0, ans = nums[0];
        foreach (var x in nums) {
            pre = Math.Max(pre+x, x);
            ans = Math.Max(ans, pre);
        }

        return ans;
    }