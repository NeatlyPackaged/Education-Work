using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_StatsManager : MonoBehaviour
{
    public Image healthBar;
    public Image expBar;
    public Text levelText;
    public Text exptext;

    public void UpdateHealthBarAmount(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth/ maxHealth;
    }

    public void UpdateExpBarAmount(float ExpIntoLevel, float ExpRequiredToLevel)
    {
        expBar.fillAmount = ExpIntoLevel / ExpRequiredToLevel;
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }
    public void UpdateExpText(int exp)
    {
        exptext.text = exp.ToString();
    }
}
