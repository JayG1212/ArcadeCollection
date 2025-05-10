using UnityEngine;

public class ShipFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;
    public float bulletSpeed = 10f;

    private float nextFireTime = 0f;

    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) ) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed;
        }

        Destroy(bullet, 2f); // optional: destroy after 2 seconds
    }
}
