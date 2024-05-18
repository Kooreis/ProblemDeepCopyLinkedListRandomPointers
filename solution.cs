Here is a C# console application that performs a deep copy of a linked list with random pointers:

```C#
using System;
using System.Collections.Generic;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

public class Solution
{
    Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

    public Node GetClonedNode(Node node)
    {
        if (node != null)
        {
            if (this.visited.ContainsKey(node))
            {
                return this.visited[node];
            }
            else
            {
                this.visited[node] = new Node(node.val);
                return this.visited[node];
            }
        }
        return null;
    }

    public Node CopyRandomList(Node head)
    {
        if (head == null) return null;

        Node oldNode = head;
        Node newNode = new Node(oldNode.val);
        this.visited[oldNode] = newNode;

        while (oldNode != null)
        {
            newNode.random = this.GetClonedNode(oldNode.random);
            newNode.next = this.GetClonedNode(oldNode.next);

            oldNode = oldNode.next;
            newNode = newNode.next;
        }
        return this.visited[head];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;

        node1.random = node3;
        node2.random = node1;
        node3.random = node2;
        node4.random = node4;

        Solution solution = new Solution();
        Node newHead = solution.CopyRandomList(node1);

        Node temp = newHead;
        while (temp != null)
        {
            Console.WriteLine("Value: " + temp.val + ", Random: " + (temp.random != null ? temp.random.val.ToString() : "null"));
            temp = temp.next;
        }
    }
}
```
This program creates a linked list with random pointers and then makes a deep copy of it. The deep copy is then printed to the console.