using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    public static HealthComponent instance;
    public float maxhealth;
    public static float currenthealth;
    public Image healthbar;
    public bool hasHealthBar;
    private float time;

    public void Awake()
    {
        currenthealth = maxhealth;
    }

    void Update()
    {
        if (hasHealthBar)
        {
            healthbar.fillAmount = currenthealth / maxhealth;
        }
        if (currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
    }
    public static void HaveHealth(float health)
    {
        currenthealth += health;
        
    }
    public static void TakeDamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            SceneManager.LoadScene(5);
            SceneManager.LoadScene("EndScreen");
        }
    }
}