/*
 * @lc app=leetcode.cn id=208 lang=csharp
 *
 * [208] 实现 Trie (前缀树)
 */

// @lc code=start
public class Trie {
    private bool isEnd;
    private Trie[] next;

    /** Initialize your data structure here. */
    public Trie() {
        this.isEnd = false;
        next = new Trie[26];
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        if (word == null || word.Length == 0) return;
        Trie curr = this;
        char[] charArray = word.ToCharArray();
        foreach (var w in charArray) {
            var n = w - 'a';
            if (curr.next[n] == null) curr.next[n] = new Trie();
            curr = curr.next[n];
        }
        curr.isEnd = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        Trie node = SearchPrefix(word);
        return node!=null && node.isEnd;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        Trie node = SearchPrefix(prefix);
        return node != null;
    }

    public Trie SearchPrefix(string prefix) {
        Trie node = this;
        char[] charArray = prefix.ToCharArray();
        foreach (var w in charArray) {
            node = node.next[w - 'a'];
            if (node == null) return null;
        }
        return node;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

