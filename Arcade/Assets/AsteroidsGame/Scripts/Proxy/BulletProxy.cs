using UnityEngine;

/* Pattern Explained:
   Stands between the firing logic and the bullet instantiation, helps me add a cooldown to the normal shooting logic
   and easier to add the Rapid fire power up
 
 */
public class BulletProxy
{
    private GameObject bulletPrefab;
    private float cooldown = 0.5f;
    private float lastFireTime = -999f;

    public BulletProxy(GameObject prefab, float cooldown)
    {
        bulletPrefab = prefab;
        this.cooldown = cooldown;
    }

    // Normal fire with cooldown
    public void Fire(Vector3 position, Quaternion rotation, float speed)
    {
        Debug.Log("Fire with cooldown");
        if (Time.time - lastFireTime < cooldown)
            return;

        SpawnBullet(position, rotation, speed);
        lastFireTime = Time.time;
    }

    // Instant fire with no cooldown check — used by TripleShot
    public void FireImmediate(Vector3 position, Quaternion rotation, float speed)
    {
        Debug.Log("Immediate fire (triple shot)");

        SpawnBullet(position, rotation, speed);
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation, float speed)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, position, rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = bullet.transform.up * speed;
        }

        Object.Destroy(bullet, 2f);
    }
}
