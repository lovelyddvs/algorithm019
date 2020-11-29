/*
 * @lc app=leetcode.cn id=127 lang=csharp
 *
 * [127] 单词接龙
 */

// @lc code=start
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        ISet<string> wordSet = new HashSet<string>(wordList);
        if (wordSet.Count == 0 || !wordSet.Contains(endWord)) {
            return 0;
        }
        
        ISet<string> visited = new HashSet<string>();
        ISet<string> beginVisited = new HashSet<string>();
        beginVisited.Add(beginWord);
        ISet<string> endVisited = new HashSet<string>();
        endVisited.Add(endWord);

        int step = 1;
        while (beginVisited.Count >0 && endVisited.Count>0) {
            if (beginVisited.Count > endVisited.Count) {
                ISet<string> temp = beginVisited;
                beginVisited = endVisited;
                endVisited =temp;
            }

            ISet<string> nextLevelVisited = new HashSet<string>();
            foreach (var word in beginVisited) {
                if (ChangeWordByOne(word, endVisited, visited, wordSet, nextLevelVisited))
                {
                    return step+1;
                }
            }
            beginVisited = nextLevelVisited;
            step++;
        }
        return 0;
    }

    public bool ChangeWordByOne(string word, ISet<string> endVisited, ISet<string> visited, ISet<string> wordSet,
                                ISet<string> nextLevelVisited) 
    {
        var charArray = word.ToCharArray();
        for (int i=0; i<word.Length; i++) {
            char originChar = charArray[i];
            for (char k = 'a'; k<='z'; k++) {
                if (k==originChar) continue;

                charArray[i] = k;
                string nextWord = new string(charArray);
                if (wordSet.Contains(nextWord)) {
                    if (endVisited.Contains(nextWord)) {
                        return true;
                    }

                    if (!visited.Contains(nextWord)) {
                        visited.Add(nextWord);
                        nextLevelVisited.Add(nextWord);
                    }
                }
            }
            charArray[i] = originChar;
        }
        return false;
    }


}
// @lc code=end

