using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class PlayerShoot : MonoBehaviour
    {
        public GameObject bullet;

        public Transform aim; // Where the bullet spawns 
        public float bulletSpeed = 10f;

        public void Shoot()
        {
            GameObject newBullet = Instantiate(bullet, aim.position, Quaternion.identity); // Instantiate bullet
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = Vector2.up * bulletSpeed; // Give it upward velocity
            }
        }
    }
}