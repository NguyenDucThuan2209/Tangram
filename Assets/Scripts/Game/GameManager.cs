using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None,
    Initializing,
    Playing,
    End
}

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance => m_instance;

    [SerializeField] GameState m_state;
    [SerializeField] LevelManager[] m_levelPrefab;

    private int m_level;
    private Square m_currentSquare;
    private LevelManager m_currentLevel;

    public GameState State => m_state;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
    }
    private void Update()
    {
        if (m_state != GameState.Playing) return;

        InputProcessHandling();
        CheckLevelComplete();
    }

    private void InputProcessHandling()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hitObject = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitObject)
            {
                if (hitObject.transform.TryGetComponent(out Square square))
                {
                    if (square.ID != -1)
                    {
                        m_currentSquare = square;
                        Debug.LogWarning(square.transform.name);
                    }
                }
            }
        }
        else if (Input.GetMouseButton(0) && m_currentSquare != null)
        {
            var hitObject = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitObject)
            {
                if (hitObject.transform.TryGetComponent(out Square square))
                {
                    if (square.Type == SquareType.Empty)
                    {
                        square.SetSquareType(m_currentSquare);
                        m_currentLevel.TickSquare(m_currentSquare.ID, square.CoorX, square.CoorY);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && m_currentSquare != null)
        {
            m_currentSquare = null;
        }
    }
    private void CheckLevelComplete()
    {
        if (m_currentLevel.IsLevelCompleted() && m_state == GameState.Playing)
        {
            Debug.LogWarning("GameManager: EndGame");
            EndGame();
        }
    }
    private void ResetGameProperties()
    {
        ClearData();
        m_currentLevel = Instantiate(m_levelPrefab[m_level - 1], transform).GetComponent<LevelManager>();
    }

    public void ClearData()
    {
        if (m_currentLevel != null)
        {
            Destroy(m_currentLevel.gameObject);
        }
    }
    public void StartLevel(int level = -1)
    {
        m_state = GameState.Playing;
        m_level = (level > 0) ? level : m_level;

        ResetGameProperties();
        MenuManager.Instance.SetLevelInGame(m_level);
    }
    public void Replay()
    {
        ResetGameProperties();
    }
    public void EndGame()
    {
        m_level++;
        m_state = GameState.End;

        if (m_level > 9) m_level = 1;

        MenuManager.Instance.CompleteLevel(m_level);
    }
}
