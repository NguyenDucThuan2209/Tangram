using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] int col;
    [SerializeField] int row;

    private bool m_isInitialized;
    private int[,] m_squareMaxtrix;
    private List<Vector2Int> m_mainSquareList = new List<Vector2Int>();

    private readonly int[] dx = new int[]{ -1, 1, 0, 0 };
    private readonly int[] dy = new int[]{ 0, 0, -1, 1 };

    public int Level => level;

    private void Start()
    {
        if (!m_isInitialized) InitializeLevel();
    }

    private int GetChildIndex(int x, int y)
    {
        return x + y * col;
    }
    private bool IsValidIndex(int x, int y)
    {
        return 0 <= x && x < col && 0 <= y && y < row;
    }
    private bool MeasureConnectionMainSquare(int id, int x, int y)
    {
        bool[,] visited = new bool[col, row];
        Stack<Vector2Int> stack = new Stack<Vector2Int>();

        visited[x, y] = true;
        stack.Push(new Vector2Int(x, y));

        while (stack.Count > 0)
        {
            Vector2Int currentSquare = stack.Pop();

            for (int i = 0; i < 4; i++)
            {
                var newY = currentSquare.y + dy[i];
                var newX = currentSquare.x + dx[i];

                if (IsValidIndex(newX, newY))
                {
                    if (m_squareMaxtrix[newX, newY] == id && !visited[newX, newY])
                    {
                        stack.Push(new Vector2Int(newX, newY));
                        visited[newX, newY] = true;
                    }
                }
            }
        }

        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < col; i++)
            {
                if (m_squareMaxtrix[i, j] == id && !visited[i, j])
                {
                    Debug.LogWarning($"m_squareMaxtrix[{i}, {j}] = {m_squareMaxtrix[i, j]} is not connected with ID = {id}");
                    return false;
                }
            }
        }

        return true;
    }

    private void InitializeLevel()
    {
        var childIndex = 0;
        m_isInitialized = true;
        m_squareMaxtrix = new int[col, row];
        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < col; i++)
            {
                var square = transform.GetChild(childIndex).GetComponent<Square>();
                square.transform.name = $"{i}_{j}";
                m_squareMaxtrix[i, j] = square.ID;
                square.CoorX = i;
                square.CoorY = j;
                childIndex++;
                if (square.ID != -1)
                {
                    m_mainSquareList.Add(new Vector2Int(i, j));
                    square.transform.name += $" (Main: {square.ID})";
                }
            }
        }
    }
    private void SweepMatrix()
    {
        for (int i = 0; i < m_mainSquareList.Count; i++)
        {
            var square = transform.GetChild(GetChildIndex(m_mainSquareList[i].x, m_mainSquareList[i].y)).GetComponent<Square>();
            square.IsConnected = MeasureConnectionMainSquare(square.ID, square.CoorX, square.CoorY);
        }
    }

    public void TickSquare(int id, int x, int y)
    {
        if (m_squareMaxtrix[x, y] != id)
        {
            m_squareMaxtrix[x, y] = id;
            SweepMatrix();
        }
    }
    public bool IsLevelCompleted()
    {
        if (!m_isInitialized) InitializeLevel();

        for (int i = 0; i < m_mainSquareList.Count; i++)
        {
            var index = GetChildIndex(m_mainSquareList[i].x, m_mainSquareList[i].y);
            var square = transform.GetChild(index).GetComponent<Square>();
            if (!square.IsComplete || !square.IsConnected)
            {
                return false;
            }
        }
        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < col; i++)
            {
                if (m_squareMaxtrix[i, j] == -1)
                {
                    return false;
                }

            }
        }

                return true;
    }
}
