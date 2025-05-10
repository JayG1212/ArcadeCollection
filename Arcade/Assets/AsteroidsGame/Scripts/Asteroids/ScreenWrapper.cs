using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    public float padding = 0.1f; // Extra space outside the screen before wrapping

    void Update()
    {
        WrapAroundScreen();
    }

    void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.x > 1 + padding)
            newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(0 - padding, 0, 0)).x;
        else if (viewportPos.x < 0 - padding)
            newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(1 + padding, 0, 0)).x;

        if (viewportPos.y > 1 + padding)
            newPosition.y = Camera.main.ViewportToWorldPoint(new Vector3(0, 0 - padding, 0)).y;
        else if (viewportPos.y < 0 - padding)
            newPosition.y = Camera.main.ViewportToWorldPoint(new Vector3(0, 1 + padding, 0)).y;

        transform.position = newPosition;
    }
}
