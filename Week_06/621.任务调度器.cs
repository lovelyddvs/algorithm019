/*
 * @lc app=leetcode.cn id=621 lang=csharp
 *
 * [621] 任务调度器
 */

// @lc code=start
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] counter = new int[26];
        int max = 0;
        int maxCount = 0;

        foreach (var task in tasks) {
            counter[task - 'A']++;
            if (max == counter[task - 'A']) {
                maxCount++;
            } else if(max < counter[task - 'A'])
            {
                max = counter[task - 'A'];
                maxCount = 1;
            }
        }

        int partCount = max - 1;
        int partLength = n - (maxCount-1);
        int emptySlots = partCount * partLength;
        int availableTasks = tasks.Length - max * maxCount;
        int idles = Math.Max(0, emptySlots - availableTasks);
        return tasks.Length + idles;
    }
}
// @lc code=end

