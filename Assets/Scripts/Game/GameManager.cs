using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None,
    Initializing,
    Playing,
    Pausing,
    End
}

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance => m_instance;

    [SerializeField] GameState m_state;
    [SerializeField] Vector2 m_vertical;
    [SerializeField] Vector2 m_horizontal;

    public GameState State => m_state;
    public Vector2 Vertical => m_vertical;
    public Vector2 Horizontal => m_horizontal;

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
    }
    private void ResetGameData()
    {
    }

    public void StartGame()
    {
        Debug.LogWarning("Start Game");
        m_state = GameState.Playing;
    }
    public void PauseGame()
    {
        Debug.LogWarning("Pause Game");
        m_state = GameState.Pausing;
    }
    public void ResumeGame()
    {
        Debug.LogWarning("Resume Game");
        m_state = GameState.Playing;
    }
    public void EndGame()
    {
        Debug.LogWarning("End Game");
        m_state = GameState.End;
    }
}
