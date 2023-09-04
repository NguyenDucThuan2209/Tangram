using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScreen : UIScreen
{
    [SerializeField] Slider m_soundSlider;
    [SerializeField] Slider m_musicSlider;

    public void OnSoundButtonPressed()
    {
        m_soundSlider.value = (m_soundSlider.value == 0) ? 1 : 0;
        
        SoundManager.Instance.PlaySound("Click");
        SoundManager.Instance.SetSoundState(m_soundSlider.value == 0);
    }
    public void OnMusicButtonPressed()
    {
        m_musicSlider.value = (m_musicSlider.value == 0) ? 1 : 0;
        
        SoundManager.Instance.PlaySound("Click");
        SoundManager.Instance.SetMusicState(m_musicSlider.value == 0);
    }
    public void OnBackButtonPressed()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.BackToHome();
    }
}
