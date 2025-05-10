// Written By Jay Gunderson
// 04/07/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class DestroyBullet : MonoBehaviour
    {
        public float yLimit = 6f; // Player's out of bounds

        void Update()
        {
            if (transform.position.y > yLimit) // If bullet instance is off screen
            {
                Destroy(gameObject); // Remove bullet instance from scene
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

    }
}