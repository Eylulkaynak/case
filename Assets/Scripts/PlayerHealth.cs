using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour, IDamageable 
{
    [Header("Can Ayarları")]
    public int maxHealth = 100; // Float yerine int yaptık
    private int currentHealth;  // Float yerine int yaptık

    void Start()
    {
        currentHealth = maxHealth;
    }

    // IDamageable arayüzü ile uyumlu olması için 'int' kullanıyoruz
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        
        Debug.Log("Oyuncu hasar aldı! Kalan Can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Oyuncu Öldü!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetCurrentScore();
        }

        // Mevcut sahneyi yeniden başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}