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