# Trie 树
  字典树，又称为单词查找树，Tire数，是一种树形结构，它是一种哈希树的变种。

  基本性质：
  根节点不包含字符，除根节点外的每一个子节点都包含一个字符；
  从根节点到某一节点。路径上经过的字符连接起来，就是该节点对应的字符串；
  每个节点的所有子节点包含的字符都不相同。

  优点：利用字符串的公共前缀来减少查询时间，最大限度的减少无谓的字符串比较，查询效率比哈希树高。
  
  代码实现Trie 树：
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

# 剪枝 
  在搜索算法中优化中，剪枝，就是通过某种判断，避免一些不必要的遍历过程，形象的说，就是剪去了搜索树中的某些“枝条”，故称剪枝。应用剪枝优化的核心问题是设计剪枝判断方法，即确定哪些枝条应当舍弃，哪些枝条应当保留的方法。

# 双向BFS的实现
  双向bfs适用于知道起点和终点的状态下使用，从起点和终点两个方向开始进行搜索，可以非常大的提高单个bfs的搜索效率。

# 启发式搜素
  启发式搜索要用启发函数来导航，其搜索算法就要在状态图一般搜索算法基础上再增加启发函数值的计算与传播过程，并且由启发函数值来确定节点的扩展顺序。
  
  两种策略:
  1、全局择优搜索
  在OPEN表中保留所有已生成而未考察的节点，并用启发函数f(x)对它们全部进行估价，从中选出最优节点进行扩展，而不管这个节点出现在搜索树的什么地方。
  2、局部择优搜索
  扩展节点N后仅对N的子节点按启发函数值大小以升序排序，再将它们依次放入OPEN表的首部。


# AVL树和红黑树
  平衡二叉搜索树（Self-balancing binary search tree）又被称为AVL树（有别于AVL算法），且具有以下性质：它是一 棵空树或它的左右两个子树的高度差的绝对值不超过1，并且左右两个子树都是一棵平衡二叉树。
  平衡因子
  某结点的左子树与右子树的高度(深度)差即为该结点的平衡因子（BF,Balance Factor）。平衡二叉树上所有结点的平衡因子只可能是 -1，0 或 1。

  红黑树是一棵二叉搜索树，它在每个节点增加了一个存储位记录节点的颜色，可以是RED,也可以是BLACK；通过任意一条从根到叶子简单路径上颜色的约束，红黑树保证最长路径不超过最短路径的二倍，因而近似平衡。
  红黑树性质：
  1、每个节点颜色不是黑色，就是红色
  2、根节点是黑色的
  3、如果一个节点是红色，那么它的两个子节点就是黑色的（没有连续的红节点）
  4、对于每个节点，从该节点到其后代叶节点的简单路径上，均包含相同数目的黑色节点

