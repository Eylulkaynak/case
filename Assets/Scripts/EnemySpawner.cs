using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Ayarları")]
    public GameObject enemyPrefab; // Üretilecek düşman objesi
    public float spawnRate = 2f;   // Kaç saniyede bir düşman çıkacak?
    
    [Header("Konum Ayarları")]
    public float spawnRadius = 3f; // Spawner'ın etrafında ne kadar geniş bir alanda çıkacaklar?

    private float nextSpawnTime = 0f;

    void Update()
    {
        // Oyun içi zaman, bir sonraki doğma zamanını geçtiyse yeni düşman üret
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            
            // Bir sonraki doğma zamanını ayarla
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // Spawner'ın merkezinden rastgele bir 2D nokta seç (Düşmanlar hep aynı noktada üst üste binmesin diye)
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Düşmanı bu rastgele noktada yarat
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}