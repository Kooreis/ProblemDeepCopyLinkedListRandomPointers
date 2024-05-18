Here is a Python solution for the problem:

```python
class Node:
    def __init__(self, x: int, next: 'Node' = None, random: 'Node' = None):
        self.val = int(x)
        self.next = next
        self.random = random

def copyRandomList(head: 'Node') -> 'Node':
    if not head:
        return head

    old_node = head
    new_node = Node(old_node.val, None, None)
    node_dict = {old_node: new_node}

    while old_node:
        new_node.random = getClonedNode(old_node.random, node_dict)
        new_node.next = getClonedNode(old_node.next, node_dict)

        old_node = old_node.next
        new_node = new_node.next

    return node_dict[head]

def getClonedNode(node: 'Node', node_dict: dict) -> 'Node':
    if node:
        if node in node_dict:
            return node_dict[node]
        else:
            node_dict[node] = Node(node.val, None, None)
            return node_dict[node]
    return None

def printList(node: 'Node'):
    while node:
        print('Value:', node.val, 'Random:', node.random.val if node.random else None)
        node = node.next

node1 = Node(1)
node2 = Node(2)
node3 = Node(3)
node4 = Node(4)
node5 = Node(5)

node1.next = node2
node2.next = node3
node3.next = node4
node4.next = node5

node1.random = node3
node2.random = node1
node3.random = node5
node4.random = node3
node5.random = node2

print('Original List:')
printList(node1)

copy = copyRandomList(node1)

print('Copied List:')
printList(copy)
```

This Python script creates a linked list with random pointers and then creates a deep copy of it. The `copyRandomList` function creates a new node for each node in the original list and stores them in a dictionary. The `getClonedNode` function is used to avoid creating duplicate nodes. The script then prints the original list and the copied list to the console.