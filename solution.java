Here is a Java console application that performs a deep copy of a linked list with random pointers:

```java
import java.util.HashMap;
import java.util.Map;

class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}

public class Main {
    public static Node copyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        Map<Node, Node> map = new HashMap<>();
        Node node = head;

        while (node != null) {
            map.put(node, new Node(node.val));
            node = node.next;
        }

        node = head;

        while (node != null) {
            map.get(node).next = map.get(node.next);
            map.get(node).random = map.get(node.random);
            node = node.next;
        }

        return map.get(head);
    }

    public static void printList(Node head) {
        while (head != null) {
            System.out.println("Value: " + head.val + ", Random: " + (head.random != null ? head.random.val : "null"));
            head = head.next;
        }
    }

    public static void main(String[] args) {
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

        Node copiedList = copyRandomList(node1);

        System.out.println("Original List:");
        printList(node1);

        System.out.println("\nCopied List:");
        printList(copiedList);
    }
}
```

This program first creates a mapping of original nodes to their corresponding new nodes. Then it assigns the next and random pointers for the new nodes using the mapping. The `printList` function is used to print the values and random pointers of the nodes in the list. The `main` function creates a linked list with random pointers and then makes a deep copy of it.