# 第四周学习总结

# 深度优先搜索

递归模板：
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> allResults = new ArrayList<>();
        if(root==null){
            return allResults;
        }
        travel(root,0,allResults);
        return allResults;
    }


    private void travel(TreeNode root,int level,List<List<Integer>> results){
        if(results.size()==level){
            results.add(new ArrayList<>());
        }
        results.get(level).add(root.val);
        if(root.left!=null){
            travel(root.left,level+1,results);
        }
        if(root.right!=null){
            travel(root.right,level+1,results);
        }
    }

非递归模板：
    public void dfs(TreeNode root) {
    HashMap<int, int> visited= new HashMap<int, int>();
    if(root == null) return ;

    Stack stackNode = new Stack();
    stackNode.Push(root);

    while (!stackNode.Count>0) {
        TreeNode node = stackNode.Pop() as TreeNode;

        if (visited.ContainsKey(node.val)) continue;
        visited[node.val] = 1;


        for (int i = node.children.Count - 1; i >= 0; --i) {
            stackNode.Push(node.children[i]);
        }
    }

    return ;
    }

# 广度优先搜素

BFS模板：
    public class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;

        TreeNode(int x) {
            val = x;
        }
    }

    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> allResults = new ArrayList<>();
        if (root == null) {
            return allResults;
        }
        Queue<TreeNode> nodes = new LinkedList<>();
        nodes.add(root);
        while (!nodes.isEmpty()) {
            int size = nodes.size();
            List<Integer> results = new ArrayList<>();
            for (int i = 0; i < size; i++) {
                TreeNode node = nodes.poll();
                results.add(node.val);
                if (node.left != null) {
                    nodes.add(node.left);
                }
                if (node.right != null) {
                    nodes.add(node.right);
                }
            }
            allResults.add(results);
        }
        return allResults;
    }

# 贪心算法
  概念：贪心算法是一种在每一步选择中都采取在当前状态下最好或最优的选择，从而希望导致结果是最好或最优的算法。
  
  贪心算法和动态规划之际的区别在于它对每个子问题的解决方案都做出选择，不能回退。动态规划则会保存以前的运算
  结果，并根据以前的结果对当前进行选择，有回退功能。

# 二分查找
  二分查找是将一组有序数据不断地切割成两个部分进行查找，直到找到最接近的那个值。

  使用二分查找的前提条件：
  1. 目标函数单调性 （单调递增或递减）
  2. 存在上下界 （bounded）
  3. 能够通过所以访问 （index accessible）

  二分查找模板：
  public int binarySearch(int[] array, int target) {
    int left = 0, right = array.length - 1, mid;
    while (left <= right) {
        mid = (right - left) / 2 + left;

        if (array[mid] == target) {
            return mid;
        } else if (array[mid] > target) {
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }

    return -1;
 }