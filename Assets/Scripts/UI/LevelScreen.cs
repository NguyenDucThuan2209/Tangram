using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : UIScreen
{
    [SerializeField] LevelItem[] m_levelArray;

    public void OnBackButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
    }
    public void OnLevelButtonPressed(int level)
    {
        SoundManager.Instance.PlaySound("Click");
    }

    public void SetLevelData(int level, bool isLock)
    {
        m_levelArray[level - 1].SetLevelData(isLock);
    }
}
