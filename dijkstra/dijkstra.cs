using System;
using System.Collections.Generic;

class Node
{
    public int X, Y;
    public int G, H;
    public Node Parent;

    public int F => G + H;

    public Node(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class AStar
{
    private readonly int[,] maze;
    private readonly int rows;
    private readonly int cols;

    public AStar(int[,] maze)
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
            int currentIndex = 0;

            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].F < current.F)
                {
                    current = openList[i];
                    currentIndex = i;
                }
            }

            openList.RemoveAt(currentIndex);
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

                int tentativeG = current.G + 1;

                if (!openList.Contains(neighbor) || tentativeG < neighbor.G)
                {
                    neighbor.Parent = current;
                    neighbor.G = tentativeG;
                    neighbor.H = CalculateHeuristic(neighbor, goal);

                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
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

    private int CalculateHeuristic(Node a, Node b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}

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

