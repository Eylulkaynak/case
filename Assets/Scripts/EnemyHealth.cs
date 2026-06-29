using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Sağlık Ayarları")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Skor Ayarları")]
    public int pointsValue = 10; // Bu düşman öldüğünde kazanılacak puan

    void Start()
    {
        currentHealth = maxHealth;
    }

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
        // GameManager sahnede varsa ve aktifse skoru artır
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(pointsValue);
        }

        // Düşmanı sahneden sil
        Destroy(gameObject);
    }
}