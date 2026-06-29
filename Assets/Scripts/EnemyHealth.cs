using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Sağlık Ayarları")]
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        // Oyun başladığında canı maksimum değere ayarla
        currentHealth = maxHealth;
    }

    // Oyuncunun silahı veya mermisi çarptığında bu fonksiyonu tetiklemelisin
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Düşman öldüğünde animasyon olmadığı için objeyi anında yok ediyoruz.
        // Ekranda kalıntı bırakmamak için en pratik yöntem budur.
        Destroy(gameObject);
    }
}