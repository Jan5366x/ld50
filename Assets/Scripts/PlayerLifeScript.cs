
using System;
using UnityEngine;

public class PlayerLifeScript : MonoBehaviour
{
    public int MaxHealth = 100;

    private int currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void Hit(int damage)
    {
        currentHealth = Math.Clamp(currentHealth - damage, 0, MaxHealth);
        
        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
