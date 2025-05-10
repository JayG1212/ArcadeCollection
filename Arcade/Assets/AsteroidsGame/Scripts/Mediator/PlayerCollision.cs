using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public class PlayerCollision : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Asteroid"))
            {
                GameMediator.Instance.PlayerHitByAsteroid(); // Takes Damage
                other.gameObject.GetComponent<Asteroid>().DestroyAsteroid(false);
            }
        }
    }
}   