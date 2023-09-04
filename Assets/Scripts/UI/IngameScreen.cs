using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameScreen : UIScreen
{
    [SerializeField] Text m_levelText;
    [SerializeField] Button m_replayButton;
    [SerializeField] Button m_nextLevelButton;

    public void SetLevelText(int level)
    {
        m_levelText.text = "LEVEL " + level;
    }
    public void ShowNextLevelButton()
    {
        m_replayButton.gameObject.SetActive(false);
        m_nextLevelButton.gameObject.SetActive(true);
    }
    public void HideNextLevelButton()
    {
        m_replayButton.gameObject.SetActive(true);
        m_nextLevelButton.gameObject.SetActive(false);
    }
    public void OnMenuButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.BackToHome();
    }
    public void OnReplayButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.Replay();
    }
    public void OnNextLevelButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.StartLevel();
    }
}
