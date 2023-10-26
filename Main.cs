using DataStructuresPortfolio;
using DataStrucures;

/**
 * This Main class has test code for each Data Structure in the portfolio.
 * It tests each mandatory method for each structure as well as a couple of
 * edge cases as well.
 * 
 * To test any structure: simply look for the header comment, uncommment the "/*"
 * at the top and bottom the block of code, and run the portfolio. 
 * To test another structure: just exit the console, replace the "/* back 
 * and repeat prior steps.
 * 
 * If there are more cases desired to be tested, just modify the code for that
 * particular structure, as none of the structures are reliant on this class.
 */

//Test Code for DynamicArray
/*
Console.WriteLine("These are outputs for DynamicArray Test Code:");
DynamicArray<int> array = new DynamicArray<int>();
Console.WriteLine("Empty Array: " + array.ToString());
Console.WriteLine("Trying to add a value at a negative position.");
array.Add(3, -1);
array.Add(4, 0);
array.Add(5, 1);
array.Add(6, 2);
Console.WriteLine("Array with some values: " + array.ToString());
array.Add(25, 2);
Console.WriteLine("Array after adding 25 to the second position: " + array.ToString());
array.Remove(0);
Console.WriteLine("Array after removing the item at position 0: " + array.ToString());
Console.WriteLine("Array Size: " + array.Size());
Console.WriteLine();
*/


//Test Code for Queue
/*
Console.WriteLine("These are outputs for Queue Test Code:");
DataStructuresPortfolio.Queue<int> ints = new DataStructuresPortfolio.Queue<int>();
Console.WriteLine("Is the Queue empty? " + ints.IsEmpty());
Console.WriteLine("Test for the empty Queue print: " + ints.ToString());
ints.Enqueue(0);
Console.WriteLine("Enqueue 0: " + ints.ToString());
ints.Enqueue(1);
ints.Enqueue(2);
ints.Enqueue(3); 
Console.WriteLine("Enqueue 3 more items: " + ints.ToString());
Console.WriteLine("Is the Queue empty? " + ints.IsEmpty());
ints.Dequeue();
Console.WriteLine("Queue after dequeuing once: " + ints.ToString());
Console.WriteLine("Peek: " + ints.Peek());
Console.WriteLine("Queue Size: " + ints.Size());
ints.Dequeue();
ints.Dequeue();
ints.Dequeue();
Console.WriteLine("Size after 3 more dequeues: " + ints.Size());
Console.WriteLine("Is the Queue empty? " + ints.IsEmpty() + "\n");
*/


//Test Code for Stack

Console.WriteLine("These are outputs for Stack Test Code:");
DataStructuresPortfolio.Stack<int> stack = new DataStructuresPortfolio.Stack<int>();
Console.WriteLine("Is the Stack empty? " + stack.IsEmpty());
Console.WriteLine("Test print empty Stack: " + stack.ToString());
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine("Stack after pushing three items: " + stack.ToString());
Console.WriteLine("Peek: " + stack.Peek());
stack.Pop();
Console.WriteLine("Stack after popping once: " + stack.ToString());
Console.WriteLine("Is the Stack empty? " + stack.IsEmpty());
stack.Pop();
stack.Pop(); 
Console.WriteLine("Is the Stack empty after two more pops? " + stack.IsEmpty() + "\n");



//Test Code for SlowSort
/*
Console.WriteLine("These are outputs for SlowSort Test Code:");

IEnumerable<int> randoms1 = Utils.NumGen(0, 100, 25);
int[] slowArray = randoms1.ToArray<int>();

Console.WriteLine("Array before BubbleSort: ");
Console.Write("[");
for (int i = 0; i < slowArray.Length - 1; i++)
{
    Console.Write(slowArray[i] + ", ");
}
Console.WriteLine(slowArray[slowArray.Length - 1] + "]");

SlowSort.BubbleSort(slowArray);

Console.WriteLine("Array after BubbleSort: ");
Console.Write("[");
for (int i = 0; i < slowArray.Length - 1; i++)
{
    Console.Write(slowArray[i] + ", ");
}
Console.WriteLine(slowArray[slowArray.Length - 1] + "]\n");
*/


//Test Code for FastSort
/*
Console.WriteLine("These are outputs for FastSort Test Code:");

IEnumerable<int> randoms2 = Utils.NumGen(0, 100, 25);
int[] fastArray = randoms2.ToArray<int>();

Console.WriteLine("Array before MergeSort:");
Console.Write("[");
for (int i = 0; i < fastArray.Length - 1; i++)
{
    Console.Write(fastArray[i] + ", ");
}
Console.WriteLine(fastArray[fastArray.Length - 1] + "]");

FastSort.MergeSort(fastArray);

Console.WriteLine("Array after MergeSort:");
Console.Write("[");
for (int i = 0; i < fastArray.Length - 1; i++)
{
    Console.Write(fastArray[i] + ", ");
}
Console.WriteLine(fastArray[fastArray.Length - 1] + "]\n");
*/


//Test Code for SinglyLinkedList
/*
Console.WriteLine("These are outputs for SinglyLinkedList Test Code:");
SinglyLinkedList<int> list = new SinglyLinkedList<int>();
Console.WriteLine("Empty List: " + list.ToString());
list.AddHead(0);
Console.WriteLine("List after adding 0: " + list.ToString());
list.AddTail(1);
list.AddHead(2);
list.AddTail(3);
Console.WriteLine("List after adding 1 to tail, 2 to head, and then 3 to tail: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
list.AddAt(24, 2);
Console.WriteLine("List after adding 24 to position 2: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
list.AddAt(9, 0);
list.AddAt(10, 10);
Console.WriteLine("List after adding 9 to position 0 and 10 to position 10: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
Console.WriteLine("Trying to add 11 and position -1: ");
list.AddAt(11, -1);

list.RemoveHead();
Console.WriteLine("List after removing the head: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
Console.WriteLine(list.RemoveTail());
Console.WriteLine("List after removing the tail: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
Console.WriteLine("Removing item in position 2: " + list.RemoveAt(2));
Console.WriteLine("List after removing that item: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
Console.WriteLine("Removing item in position 2: " + list.RemoveAt(2));
Console.WriteLine("Removing item in position 0: " + list.RemoveAt(0));
Console.WriteLine("Removing item in position 5: " + list.RemoveAt(5));
Console.WriteLine("List after removing those items: " + list.ToString());
Console.WriteLine("Length of List: " + list.Size());
*/


//Test Code for BinarySearchTree
/*
BinarySearchTree tree = new BinarySearchTree();
int[] treeArray1 = { 8, 3, 15, 1, 5, 13, 20, 7 };
for(int i = 0; i < treeArray1.Length; i++)
{
    tree.Add(treeArray1[i]);
}
Console.WriteLine("Printing the Tree from top to bottom: \n" + tree.ToString());
Console.WriteLine("Height of the Tree: " + tree.Height());
Console.WriteLine("Does the Tree have Node 13? " + tree.Has(13));
Console.WriteLine("Does the Tree have Node 12? " + tree.Has(12));
tree.Remove(13);
Console.WriteLine("Tree after removing node 13: \n" + tree.ToString());
tree.Remove(3);
Console.WriteLine("Tree after removing node 3: \n" + tree.ToString());
tree.Remove(15);
Console.WriteLine("Tree after removing node 15: \n" + tree.ToString());
*/


//Test Code for Trie
/*
Trie trie = new Trie();
trie.Add("apple");
trie.Add("banana");
trie.Add("orange");

Console.WriteLine(trie.Has("apple"));   // Output: True
Console.WriteLine(trie.Has("grape"));   // Output: False

Console.WriteLine(trie.Remove("apple"));   // Output: apple
Console.WriteLine(trie.Has("apple"));   // Output: False
Console.WriteLine(trie.Remove("grape"));   // Output: grape (word not found)

Console.WriteLine(trie.Has("123456"));
*/


//Test Code for HashTable
/*
HashTable<string> myHashTable = new HashTable<string>();

myHashTable.Add("Chicken");
myHashTable.Add("Cow");
myHashTable.Add("Horse");

Console.WriteLine("Contains value 'Cow': " + myHashTable.Has("Cow"));
Console.WriteLine(myHashTable.Remove("Chicken"));
Console.WriteLine("Count: " + myHashTable.Count());
myHashTable.Clear();
Console.WriteLine("Count after clearing: " + myHashTable.Count());
*/


//Test Code for MaxHeapSort
/*
MaxHeap max = new MaxHeap(20);
IEnumerable<int> randoms3 = Utils.NumGen(0, 100, 20);
int[] heapArray = randoms3.ToArray<int>();

max.HeapSort(heapArray);
int[] heapArray2 = max.SortedVals().ToArray<int>();

Console.Write("[");
for (int i = 0; i < heapArray2.Length - 1; i++)
{
    Console.Write(heapArray2[i] + ", ");
}
Console.WriteLine(heapArray[heapArray.Length - 1] + "]");

MaxHeap maxHeap = new MaxHeap(6);
int[] arr = { 12, 11, 13, 5, 6, 7 };
maxHeap.HeapSort(arr);

foreach (int val in arr)
{
    Console.WriteLine(val);
}
*/


//Test Code for BloomFilter

BloomFilter bloomFilter = new BloomFilter(100);

// Add items to the Bloom filter
IEnumerable<string> bloomList = Utils.PasswordWordlist();
foreach (string pass in bloomList)
{
    bloomFilter.Add(pass);
}

// Check if items are contained in the Bloom filter
Console.WriteLine(bloomFilter.Has("123456"));   // True
Console.WriteLine(bloomFilter.Has("banana"));  // True
Console.WriteLine(bloomFilter.Has("password"));  // True