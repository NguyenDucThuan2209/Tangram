using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : UIScreen
{
    public void OnPlayButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.StartGame();
    }
    public void OnPolicyButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
    }
    public void OnSettingButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
    }
}
