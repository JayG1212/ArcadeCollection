using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class EnemyMove : MonoBehaviour
    {

        public float speed = 1f;

        public void TryMove(Vector2 direction)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}