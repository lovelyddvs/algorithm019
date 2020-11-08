# 第一周学习总结

# 数组 (Array)
  数组是一个存储在连续空间内的线性表，用来存放相同类型的数据。
  特性：可以“随机访问”，通过地址直接访问存储的数据。
  缺点：1，创建一个数组需要为其分配一个连续的内存空间，如果没有足够大的连续空间，即使总的碎片空间总和大于数组的长度，
          也会导致创建失败。
        2，数组的操作非常低效，如果要对在数组中删除、插入一个数据，因为要保证连续性，需要对数据做大量的搬移工作。
           当数组的长度超出给定大小的时候，需要重新分配一个更大连续的内存空间。
  复杂度：delete  O(n)
         lookup  O(1)
         insert  O(1)

# 链表 (Linked List)
  链表是一种通过‘指针’将一组分散在零散内存空间的数据串联起来的数据结构。
  特性：因为链表的存储空间不是连续的，所以不需要移动节点，使得删除和插入的操作十分快速。
  缺点：1，因为链表的空间不是连续的，所以查询的效率很忙，需要通过指针遍历链表中的元素。
        2，因为链表中的每个数据都存储了指针信息，所以占用的空间会比数组大很多。
  种类：1，单链表，是指每个元素只存储了一个指向下一个元素的next指针的链表。
        2，循环链表，是指元素的尾指针指向头指针的闭环链表。
        3，双向链表，是指每个元素都存储了指向前后两个元素的指针。
        4，双向循环链表，是指链表的头尾节点的指针互相指向对方。
  复杂的： prepend  O(1)
           appen   O(1)
           delete  O(1)
           lookup  O(n)
           insert  O(1)

# 跳表 (Skip List)
  跳表是一种取代平衡树和二分查找的数据结构，以有序的方式保存元素。
  特性：通过创建多级索引来提高删除、查找、插入的效率。
  缺点：占用的存储空间大。
  复杂度：delete  O(logN)
          lookup  O(logN)
          insert  O(logN)

# 栈 (Stack)
  栈是一种操作受限的数据结构，只支持入栈和出栈操作。
  特性： 先进后出
  复杂度： 出栈和入栈的复杂度均为 O(1)

  实现数组栈
  pubic class ArrayStack<T> {
    private T[] items;
    private int count;
    private int n;

    pblic ArrayStack(int n) {
      this.items = new T[n];
      this.n=n;
      this.count = 0;
    }

    public boolean push(T item) {
      if(count == n) return false;
      items[count] =item;
      ++count;
      return true;
    }

    public T pop() {
      if (count == 0) return null;
      T tmp = items[count-1];
      --count;
      return tmp;
    }
  }


# 队列 (Queue)
  队列是一种和栈相似的数据结构，最基本的操作是入队和出队。
  特性： 先进先出
  复杂度： 入队和出队的复杂度均为 O(1)

  实现数组队列:
  public class ArrayQueue<T> {
    private T[] items;
    private int n = 0;
    private int head = 0;
    private int tail = 0;

    public ArrayQueue(int capacity) {
      items = new T[capacity];
      n = capacity;
    }

    public boolean enqueue(T item) {
      if (tail == n) return false;
      item[tail] = item;
      ++tail;
      return true
    }

    public T dequeue() {
      if(head == tail) return null;
      T ret = itens[head];
      ++head;
      return ret;
    }
  }