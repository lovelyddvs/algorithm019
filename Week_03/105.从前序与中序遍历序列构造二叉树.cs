/*
 * @lc app=leetcode.cn id=105 lang=csharp
 *
 * [105] 从前序与中序遍历序列构造二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    Hashtable inOrderMap = new Hashtable();
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length;

        for (int i=0; i<n; i++) {
            inOrderMap.Add(inorder[i], i);
        }

        return BuildTreeNodes(preorder, inorder, 0, n-1, 0, n-1);
    }

    public TreeNode BuildTreeNodes(int[] preorder, int[] inorder, int preLeft, int preRight, int inLeft, int inRight) {
        if (preLeft > preRight) return null;

        int preRoot = preLeft;
        int inRoot = Convert.ToInt32(inOrderMap[preorder[preRoot]]);

        TreeNode node = new TreeNode(preorder[preRoot]);
        int inLeftSubTree = inRoot - inLeft;

        node.left = BuildTreeNodes(preorder, inorder, preLeft+1, preLeft+inLeftSubTree, inLeft, inRoot-1);
        node.right = BuildTreeNodes(preorder, inorder, preLeft+inLeftSubTree+1, preRight, inRoot+1, inRight);

        return node;
    }

}
// @lc code=end

