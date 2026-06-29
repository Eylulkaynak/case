using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Düşman sınıfı hem MonoBehaviour özelliklerini taşır hem de IDamageable kurallarına uyar
public class Enemy : MonoBehaviour, IDamageable 
{
    public int pointsValue = 10;
    public int health = 100;
    public GameObject deathEffect;

    // IDamageable arayüzünün zorunlu kıldığı metodumuz (Zaten yazmıştın)
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(pointsValue);
        }

        Destroy(gameObject);
    }
}