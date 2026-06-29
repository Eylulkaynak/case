using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : MonoBehaviour
{

    [Header("Pool Settings")]
    public GameObject bulletPrefab;
    public int poolSize = 10;

    private List<GameObject> bullets = new List<GameObject>();

        void Start()
    {
        for (int i = 0; i < poolSize; i++)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullets.Add(bullet);
    }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject GetBullet()
{
    for (int i = 0; i < bullets.Count; i++)
    {
        if (!bullets[i].activeInHierarchy)
        {
            return bullets[i];
        }
    }

    return null;
}
}