# 哈希表 (hash table)
哈希表使用的是数组支持按照下标随机访问的特性，所以哈希表是数组的扩展，由数组演化而来。
哈希函数：哈希表由Key和Value组成，其中Key用来表示一个存储的数据，通过哈希函数转化为数组下标的映射。
散列冲突：当不同的Key被转换为相同的数组下标时即为散列冲突，可以通过链表的方式将不同的值存储起来，但这样会增加查找的时间复杂度。
# Java Hash Map 分析：
/**
 * 返回指定 key 所对应的 value 值，当不存在指定的 key 时，返回 null。
 *
 * 当返回 null 的时候并不表明哈希表中不存在这种关系的映射，有可能对于指定的 key，其对应的值就是 null。
 * 因此可以通过 containsKey 来区分这两种情况。
 */
public V get(Object key) {
    Node<K,V> e;
    return (e = getNode(hash(key), key)) == null ? null : e.value;
}

/**
 * 1.首先通过 key 的哈希值找到其所在的哈希桶
 * 2.对于 key 所在的哈希桶只有一个元素，此时就是 key 对应的节点，
 * 3.对于 key 所在的哈希桶超过一个节点，此时分两种情况：
 *     如果这是一个 TreeNode，表明通过红黑树存储，在红黑树中查找
 *     如果不是一个 TreeNode，表明通过链表存储（链地址法），在链表中查找
 * 4.查找不到相应的 key，返回 null
 */
final Node<K,V> getNode(int hash, Object key) {
    Node<K,V>[] tab; Node<K,V> first, e; int n; K k;
    if ((tab = table) != null && (n = tab.length) > 0 &&
        (first = tab[(n - 1) & hash]) != null) {
        if (first.hash == hash && // always check first node
            ((k = first.key) == key || (key != null && key.equals(k))))
            return first;
        if ((e = first.next) != null) {
            if (first instanceof TreeNode)
                return ((TreeNode<K,V>)first).getTreeNode(hash, key);
            do {
                if (e.hash == hash &&
                    ((k = e.key) == key || (key != null && key.equals(k))))
                    return e;
            } while ((e = e.next) != null);
        }
    }
    return null;
}

/**
 * 在映射中，将指定的键与指定的值相关联。如果映射关系之前已经有指定的键，那么旧值就会被替换
 */
public V put(K key, V value) {
    return putVal(hash(key), key, value, false, true);
}

/**
 * * @param onlyIfAbsent if true, don't change existing value
 *   @param evict 判断是否移除，为 false时，表示哈希表正在创建
 *
 * 1.判断哈希表 table 是否为空，是的话进行扩容操作
 * 2.根据键 key 计算得到的 哈希桶数组索引，如果 table[i] 为空，那么直接新建节点
 * 3.判断 table[i] 的首个元素是否等于 key，如果是的话就更新旧的 value 值
 * 4.判断 table[i] 是否为 TreeNode，是的话即为红黑树，直接在树中进行插入
 * 5.遍历 table[i]，遍历过程发现 key 已经存在，更新旧的 value 值，否则进行插入操作，插入后发现链表长度大于8，则将链表转换为红黑树
 */
final V putVal(int hash, K key, V value, boolean onlyIfAbsent,
               boolean evict) {
    Node<K,V>[] tab; Node<K,V> p; int n, i;
    //哈希表 table 为空，进行扩容操作
    if ((tab = table) == null || (n = tab.length) == 0)
        n = (tab = resize()).length;
    // tab[i] 为空，直接新建节点
    if ((p = tab[i = (n - 1) & hash]) == null)
        tab[i] = newNode(hash, key, value, null);
    else {
        Node<K,V> e; K k;
        //tab[i] 首个元素即为 key，更新旧值
        if (p.hash == hash &&
            ((k = p.key) == key || (key != null && key.equals(k))))
            e = p;
        //当前节点为 TreeNode，在红黑树中进行插入
        else if (p instanceof TreeNode)
            e = ((TreeNode<K,V>)p).putTreeVal(this, tab, hash, key, value);
        else {
            //遍历 tab[i]，key 已经存在，更新旧的 value 值，否则进行插入操作，插入后链表长度大于8，将链表转换为红黑树
            for (int binCount = 0; ; ++binCount) {
                if ((e = p.next) == null) {
                    p.next = newNode(hash, key, value, null);
                    //链表长度大于8
                    if (binCount >= TREEIFY_THRESHOLD - 1) // -1 for 1st
                        treeifyBin(tab, hash);
                    break;
                }
                // key 已经存在
                if (e.hash == hash &&
                    ((k = e.key) == key || (key != null && key.equals(k))))
                    break;
                p = e;
            }
        }
        //key 已经存在，更新旧值
        if (e != null) { // existing mapping for key
            V oldValue = e.value;
            if (!onlyIfAbsent || oldValue == null)
                e.value = value;
            afterNodeAccess(e);
            return oldValue;
        }
    }
    //HashMap插入元素表明进行了结构性调整
    ++modCount;
    //实际键值对数量超过 threshold，进行扩容操作
    if (++size > threshold)
        resize();
    afterNodeInsertion(evict);
    return null;
}
