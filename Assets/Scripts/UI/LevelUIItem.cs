using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIItem : MonoBehaviour
{
    [SerializeField] Text m_levelText;
    [SerializeField] Image m_levelIcon;
    [SerializeField] Sprite m_levelLock;
    [SerializeField] Sprite m_levelUnlock;

    public void SetLevelData(bool isLock, int level = 0)
    {
        if (isLock)
        {
            m_levelIcon.sprite = m_levelLock;
            m_levelText.gameObject.SetActive(false);
        }
        else
        {
            m_levelIcon.sprite = m_levelUnlock;
            m_levelText.gameObject.SetActive(true);
        }

        if (level > 0)
        {
            m_levelText.text = level.ToString();
        }
    }
}
