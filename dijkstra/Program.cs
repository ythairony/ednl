class Program
{
    static void Main()
    {
        int[,] maze = {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 2, 0, 0, 0, 1, 0, 1, 0, 1},
            {1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 1, 1, 0, 3},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
            {3, 1, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 1, 0, 1, 0, 0, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 3, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };

        Node start = new Node(2, 1);
        Node goal = new Node(5, 8);

        AStar aStar = new AStar(maze);
        List<Node> aStarPath = aStar.FindPath(start, goal);

        Dijkstra dijkstra = new Dijkstra(maze);
        List<Node> dijkstraPath = dijkstra.FindPath(start, goal);

        Console.WriteLine("A* Path:");
        PrintPath(aStarPath);

        Console.WriteLine("\nDijkstra Path:");
        PrintPath(dijkstraPath);
    }

    static void PrintPath(List<Node> path)
    {
        if (path == null)
        {
            Console.WriteLine("No path found.");
            return;
        }

        foreach (var node in path)
        {
            Console.WriteLine($"({node.X}, {node.Y})");
        }
    }
}
