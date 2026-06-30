using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Hasar Ayarları")]
    // BURASI INT OLMALI
    public int damageAmount = 20; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();

            if (damageableObject != null)
            {
                damageableObject.TakeDamage(damageAmount);
            }
        }
    }
}