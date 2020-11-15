/*
 * @lc app=leetcode.cn id=589 lang=csharp
 *
 * [589] N叉树的前序遍历
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {

    public IList<int> Preorder(Node root) {
        List<int> list = new List<int>();
        if (root == null) return list;

        Stack st = new Stack();
        st.Push(root);
        while (st.Count > 0) {
            Node node = st.Pop() as Node;
            list.Add(node.val);
            for (int i=node.children.Count-1; i>=0; i--) {
                st.Push(node.children[i]);
            }
        }
        return list;
    }

/*     public IList<int> Preorder(Node root) {
        List<int> list =new List<int>();
        if (root == null) return list;
        RecursivePreorder(root, list);
        return list;
    }

    public void RecursivePreorder(Node node, List<int> list) {
        if(node == null) return;

        list.Add(node.val);
        for (int i=0; i<node.children.Count; i++) {
            Node n = node.children[i];
            if (n!=null) {
                RecursivePreoder(n, list);
            }
        }
    } */

}
// @lc code=end

