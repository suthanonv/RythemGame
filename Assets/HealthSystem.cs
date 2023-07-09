using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] int MaxHealth;
    [SerializeField] int HealthToReduce;
    [SerializeField] int HealthToHeal;
    int currentHealth;

    [SerializeField] Slider healthbar;

    [SerializeField] UnityEvent GameOver;

    private void Start()
    {
        currentHealth = MaxHealth;
        healthbar.maxValue = MaxHealth;
        healthbar.value = currentHealth;
    }

    public void ReduceHelth()
    {

        currentHealth -= HealthToReduce;
        healthbar.value = currentHealth;

        if(currentHealth <= 0)
        {
            GameOver.Invoke();
        }
    }


    public void Heal()
    {
        currentHealth += HealthToHeal;
        if(currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        healthbar.value = currentHealth;
    }
}
