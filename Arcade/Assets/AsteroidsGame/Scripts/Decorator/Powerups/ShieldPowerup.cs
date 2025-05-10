using Asteroid;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehaviorController controller = other.GetComponent<PlayerBehaviorController>();
            if (controller != null)
            {
                controller.ActivateShield();
            }

            Destroy(gameObject); // Remove the power-up after pickup
        }
    }

    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < -0.1f || viewPos.x > 1.1f || viewPos.y < -0.1f || viewPos.y > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}
