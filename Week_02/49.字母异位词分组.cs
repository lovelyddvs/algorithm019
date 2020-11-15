/*
 * @lc app=leetcode.cn id=49 lang=csharp
 *
 * [49] 字母异位词分组
 */

// @lc code=start


    
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        
        var anagrams = new List<IList<string>>();
        if(strs.Length == 0) return anagrams;

        Dictionary<string, List<string>> temps = new Dictionary<string, List<string>>();
        for (int i=0; i<strs.Length; i++) {
            var ap = strs[i].ToCharArray();
            Array.Sort(ap);
            string key = new string(ap);
            if (temps.ContainsKey(key)) {
                temps[key].Add(strs[i]);
            } else {
                List<string> nList= new List<string>();
                nList.Add(strs[i]);
                temps.Add(key, nList);
            }
        }

        foreach (string key in temps.Keys) {
            anagrams.Add(temps[key]);
        }

        return anagrams;

    }

    
}
// @lc code=end

