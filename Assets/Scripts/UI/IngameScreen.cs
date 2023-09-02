using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameScreen : UIScreen
{
    [SerializeField] Text m_levelText;

    public void SetLevelText(int level)
    {
        m_levelText.text = "LEVEL " + level;
    }
    public void OnLevelButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
    }
    public void OnReplayButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
    }
}
