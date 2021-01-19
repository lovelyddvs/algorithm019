# 毕业总结

# 高效学习
  五毒神掌 （过遍数，不少于5遍 不要死磕）
  * 第一遍 尝试思考5分钟解题
  * 第二遍 5分钟解不出来，立即看题解，默写和背诵题解，然后敲出代码
  * 第三遍 隔一天把题目再做一遍
  * 第四遍 隔一星期再把题目做一遍
  * 第五遍 面试前一到两个礼拜把题目再做一遍

# 数据结构
  * 一维： 
    ~ 基础：数组 array, 链表 linked list
    ~ 高级：栈 stack, 队列 queue, 双端队列 deque, 集合 set, 映射 map (hash or map)

  * 二维：
    ~ 基础：树 tree, 图 graph
    ~ 高级：二叉搜索树 binary search tree (red-black tree, AVL)，堆 heap, 并查集 disjoint set, 字典树 Trie

  * 特殊：
    ~ 位运算 Bitwise, 布隆过滤器 BloomFilter
    ~ LRU Cache

# 算法
  * If-else, switch-->branch
  * for, while loop-->Iteration
  * 递归 Recursion (Divide & Conquer, Backtrace)
    public void Recursion () {
        //termination
        if (condition) return

        //process
        DoProcess

        //Drill Down
        Recursion()

        //Retrive
    }

    public static int divide_conquer(Problem problem) {
        if (problem == null) {
            int res = process_last_result();
            return res;
        }

        subProblems = split_problem(problem);

        res0 = divide_conque(subProblems[0]);
        res1 = divide_conque(subProblems[1]);
        
        result = process_result(res0, res1);
        return result;
    }
  * 搜索 Search: 
      ~ 深度优先搜索 Deth First Search
        public List<List<int>> LevelOrder(TreeNode root) {
            List<List<int>> lists = new List<List<int>>();
            if (root == null) return lists;
            Travel(root, 0, lists);
            return lists;
        }

        private void Travel(TreeNode root, int level, List<List<int>> lists) {
            if (lists.Count == level) {
                lists.Add(new List<int>());
            }
            lists[level].Add(root.val);
            if (root.left != null) {
                Travel(root.left, level+1, lists);
            }
            if (root.right != null) {
                Travel(root.right, level+1, lists);
            }
        }
      ~ 广度优先搜素 Breadth First Search, 
        public List<List<int>> LevelOrder(TreeNode root) {
            List<List<int>> lists = new List<List<int>>();
            if (root == null) return lists;

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Add(root);
            while (nodes.Count > 0) {
                int size = nodes.Count;
                List<int> list = new List<int>();
                for (int i=0; i<size; i++) {
                    TreeNode node = Queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null) {
                        nodes.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        nodes.Enqueue(node.right);
                    }
                }
                lists.Add(list);
            }
            return lists;
        }
      ~ *A
  * 动态规划 Dynamic Programming
    
  * 二分查找 Binary Search
    public int BinarySearch(int[] array, int target) {
        int left = 0, right = array.Length - 1, mid;
        while (left <= right) {
            mid = left + (right-left)/2;
            if (array[mid] == target) {
                return mid;
            } else if (array[mid] > target) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
    }
  * 贪心 Greedy
  * 数学 Math, 几何 Geometry