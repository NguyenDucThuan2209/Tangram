using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : UIScreen
{
    [SerializeField] LevelUIItem[] m_levelArray;

    private void Awake()
    {
        for (int i = 1; i < m_levelArray.Length; i++)
        {
            m_levelArray[i].SetLevelData(true);
        }
    }

    public void OnBackButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.BackToHome();
    }
    public void OnLevelButtonPressed(int level)
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.StartLevel(level);
    }

    public void SetLevelData(int level, bool isLock)
    {
        level = (level % 9 == 0)? 9: level % 9;
        m_levelArray[level - 1].SetLevelData(isLock);
    }
}
