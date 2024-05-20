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