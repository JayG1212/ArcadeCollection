using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        public void MoveLeft()
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        public void MoveRight()
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}