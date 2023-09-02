using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager m_instance;
    public static MenuManager Instance => m_instance;

    [SerializeField] MenuScreen m_menuScreen;
    [SerializeField] SettingScreen m_settingScreen;
    [SerializeField] LevelScreen m_pauseScreen;
    [SerializeField] IngameScreen m_ingameScreen;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        m_instance = this;
    }
    
    private void HideAllScreen()
    {
        m_menuScreen.HideScreen();
        m_pauseScreen.HideScreen();
        m_ingameScreen.HideScreen();
        m_settingScreen.HideScreen();
    }

    public void StartGame()
    {
        HideAllScreen();
        m_ingameScreen.ShowScreen();
        GameManager.Instance.StartGame();
    }
    public void PauseGame()
    {
        HideAllScreen();
        m_pauseScreen.ShowScreen();
        GameManager.Instance.PauseGame();
    }
    public void ResumeGame()
    {
        HideAllScreen();
        m_ingameScreen.ShowScreen();
        GameManager.Instance.ResumeGame();
    }
    public void ReplayGame()
    {
        HideAllScreen();
        m_ingameScreen.ShowScreen();
        GameManager.Instance.StartGame();
    }
    public void EndGame()
    {
        HideAllScreen();
    }
    public void BackToHome()
    {
        HideAllScreen();
        m_menuScreen.ShowScreen();
    }
}
