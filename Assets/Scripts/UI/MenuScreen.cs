using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : UIScreen
{
    public void OnPlayButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.PlayGame();
    }
    public void OnPolicyButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.OpenPolicy();
    }
    public void OnSettingButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.OpenSettings();
    }
}
