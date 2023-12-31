using System;
using System.Collections.Generic;

class Dijkstra
{
    private readonly int[,] maze;
    private readonly int rows;
    private readonly int cols;

    public Dijkstra(int[,] maze)
    {
        this.maze = maze;
        this.rows = maze.GetLength(0);
        this.cols = maze.GetLength(1);
    }

    public List<Node> FindPath(Node start, Node goal)
    {
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();

        openList.Add(start);

        while (openList.Count > 0)
        {
            Node current = openList[0];
            openList.RemoveAt(0);
            closedList.Add(current);

            if (current.X == goal.X && current.Y == goal.Y)
            {
                return CalculatePath(current);
            }

            List<Node> neighbors = GetNeighbors(current);

            foreach (var neighbor in neighbors)
            {
                if (closedList.Contains(neighbor))
                    continue;

                if (!openList.Contains(neighbor))
                {
                    openList.Add(neighbor);
                    neighbor.Parent = current;
                    neighbor.G = current.G + 1;
                }
                else if (current.G + 1 < neighbor.G)
                {
                    neighbor.Parent = current;
                    neighbor.G = current.G + 1;
                }
            }
        }

        return null; // No path found
    }

    private List<Node> CalculatePath(Node node)
    {
        List<Node> path = new List<Node>();

        while (node != null)
        {
            path.Add(node);
            node = node.Parent;
        }

        path.Reverse();
        return path;
    }

    private List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        int[] dx = { -1, 0, 1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = node.X + dx[i];
            int newY = node.Y + dy[i];

            if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && maze[newX, newY] == 0)
            {
                neighbors.Add(new Node(newX, newY));
            }
        }

        return neighbors;
    }
}

