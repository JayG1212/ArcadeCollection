using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipMovement : MonoBehaviour
    {
        public float thrustForce = 5f;
        public float rotationSpeed = 180f;

        private Rigidbody2D rb;
        private Animator animator;

        private bool isThrusting;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            // Check thrust input
            isThrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            animator.SetBool("isThrusting", isThrusting);

            // Rotate with A/D
            float rotationInput = -Input.GetAxisRaw("Horizontal"); // Left = positive rotation
            rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.deltaTime);
        }

        void FixedUpdate()
        {
            // Apply forward thrust
            if (isThrusting)
            {
                rb.AddForce(transform.up * thrustForce);
            }
        }
    }
}