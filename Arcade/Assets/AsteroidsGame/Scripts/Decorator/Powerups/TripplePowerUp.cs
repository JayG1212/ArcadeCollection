using Asteroid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripplePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = other.GetComponent<PlayerBehaviorController>();
            if (controller != null)
            {
                controller.ActivateTripleShot();
            }


            Destroy(gameObject); // Remove the power-up after pickup
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < -0.1f || viewPos.x > 1.1f || viewPos.y < -0.1f || viewPos.y > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}
