using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody2D'yi zorunlu kılıyoruz
public class Bullet : MonoBehaviour
{
    [Header("Mermi Ayarları")]
    
    public float damage = 25f; // Merminin vereceği hasar
    public float speed = 10f; // Merminin hızı

    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // Mermiyi yok et
        }
    }
}