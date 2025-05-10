using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class EnemyShoot : MonoBehaviour
    {
        public GameObject enemyBullet;
        public Transform enemyAim;
        public float bulletSpeed = 5f;

        public void TryShoot()
        {


            GameObject bullet = Instantiate(enemyBullet, enemyAim.position, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.down * bulletSpeed;
            }
        }
    }
}