using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager m_instance;
    public static MenuManager Instance => m_instance;

    [SerializeField] MenuScreen m_menuScreen;
    [SerializeField] SettingScreen m_settingScreen;
    [SerializeField] LevelScreen m_levelScreen;
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
        m_levelScreen.HideScreen();
        m_ingameScreen.HideScreen();
        m_settingScreen.HideScreen();
    }

    public void OpenSettings()
    {
        HideAllScreen();
        m_settingScreen.ShowScreen();
    }
    public void OpenPolicy()
    {
        Application.OpenURL("https://doc-hosting.flycricket.io/tangram-privacy-policy/9ac70c5c-0fa8-4fb0-b083-2ded5203d92e/privacy");
    }
    public void PlayGame()
    {
        HideAllScreen();
        m_levelScreen.ShowScreen();
    }
    public void Replay()
    {
        GameManager.Instance.Replay();
    }
    public void StartLevel(int level = -1)
    {
        HideAllScreen();
        m_ingameScreen.ShowScreen();
        m_ingameScreen.HideNextLevelButton();

        GameManager.Instance.StartLevel(level);
    }
    public void CompleteLevel(int level = -1)
    {
        if (level > 0) m_levelScreen.SetLevelData(level, false);

        m_ingameScreen.ShowNextLevelButton();
        SoundManager.Instance.PlaySound("LevelWin");
    }
    public void BackToHome()
    {
        HideAllScreen();
        m_menuScreen.ShowScreen();

        GameManager.Instance.ClearData();
    }

    public void SetLevelInGame(int level)
    {
        m_ingameScreen.SetLevelText(level);
    }
}
