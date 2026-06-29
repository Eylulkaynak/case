using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))] // Animator bileşenini zorunlu kılıyoruz
public class EnemyMovement2D : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float speed = 3f; 
    public Transform player; 

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Animator'ı kodumuza bağlıyoruz

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Oyuncu ile düşman arasındaki mesafeyi kontrol et
            float distance = Vector2.Distance(transform.position, player.position);

            // Eğer oyuncuya henüz ulaşmadıysa (mesafe çok küçük değilse) hareket et
            if (distance > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                
                // Yürüme animasyonunu başlat
                animator.SetBool("isWalking", true);
            }
            else
            {
                // Oyuncunun dibine geldiyse veya duruyorsa animasyonu durdur
                animator.SetBool("isWalking", false);
            }

            // Yön değiştirme (Flip) işlemleri
            if (player.position.x < transform.position.x)
            {
                spriteRenderer.flipX = true; 
            }
            else if (player.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false; 
            }
        }
        else
        {
            // Eğer player yoksa (öldüyse vs.) yürüme animasyonunu kapat
            animator.SetBool("isWalking", false);
        }
    }
}